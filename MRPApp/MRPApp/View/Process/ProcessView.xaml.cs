using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace MRPApp.View.Process
{
    /// <summary>
    /// ProcessView.xaml에 대한 상호 작용 논리
    /// 1. 공정계획에서 오늘의 생산계획 일정을 불러온다.
    /// 2. 없으면 에러표시, 시작버튼 클릭하지 못하게 만든다.
    /// 3. 공정이 있으면 오늘의 날짜를 표시하고, 시작버튼을 활성화한다.
    /// 3-1 Mqtt Subscription 연결해주고 factory1/machine1/data 확인...
    /// 4. 시작버튼을 누르면 클릭 시 새 공정을 생성해서 DB에 입력
    ///    공정코드: PRC20210618001(PRC+yyyy+MM+dd+NNN)
    /// 5. 공정처리 애니메이션 시작
    /// 6. 공정처리 애니메이션 중지
    /// 7. 센서링값 리턴될때까지 대기
    /// 8. 센서링값 결과값에 따라서 생산품 색상 변경
    /// 9. 현재 공저으이 DB값 업데이트
    /// 10. 결과 레이블 값 수정/표시
    /// </summary>
    public partial class ProcessView : Page
    {
        //금일 스케쥴
        private Model.Schdules currSchedule;
        public ProcessView()
        {
            InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var today = DateTime.Now.ToString("yyyy-MM-dd");
                currSchedule = Logic.DataAccess.GetSchedules().Where(s => s.PlantCode.Equals(Commons.PLANTCODE)).Where(s => s.SchDate.Equals(DateTime.Parse(today))).FirstOrDefault();

                if (currSchedule == null)
                {
                    await Commons.ShowMessageAsync("공정", "공정계획이 없습니다. 계획일정을 먼저 입력하시오");
                    LblProcessDate.Content = string.Empty;
                    LblSchLoadTime.Content = "None";
                    LblSchAmount.Content = "None";
                    BtnStartProcess.IsEnabled = false;
                    return;
                }
                else
                {
                    //공정계획 표시
                    MessageBox.Show($"{today} 공정 시작합니다.");
                    LblProcessDate.Content = currSchedule.SchDate.ToString("yyyy년 MM월 dd일");
                    LblSchLoadTime.Content = $"{currSchedule.SchLoadTime}초";
                    LblSchAmount.Content = $"{currSchedule.SchAmount}개";
                    BtnStartProcess.IsEnabled = true;

                    UpdateData();
                    InitConnectMqttBroker();//공정시작시 MQTT 브로커에 연결해야 한다.
                }
            }
            catch (Exception ex)
            {
                Commons.LOGGER.Error($"예외발생 ProcessView Loaded : {ex}");
                throw ex;
            }
        }

        MqttClient client;
        Timer timer = new Timer();
        Stopwatch sw = new Stopwatch();
        private void InitConnectMqttBroker()
        {
            var brokerAddress = IPAddress.Parse("210.119.12.99");//MQTT Mosquitto Broker IP;
            client = new MqttClient(brokerAddress);
            client.MqttMsgPublishReceived += Client_MqttMsgPublishReceived;
            client.Connect("Monitor");
            client.Subscribe(new string[] { "factory1/machine1/data/" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });

            Timer timer = new Timer();
            timer.Enabled = true;
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }
        //Stopwatch sw = new Stopwatch();
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (sw.Elapsed.Seconds >= 2) // 2초 대기후 일처리
            {
                sw.Stop();
                sw.Reset();
                if (currentData["PRC_MSG"] == "OK")
                {
                    Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate
                     {
                         Product.Fill = new SolidColorBrush(Colors.Green);
                     }
                    ));
                }
                else if (currentData["PRC_MSG"] == "FAIL")
                {
                    Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate
                    {
                        Product.Fill = new SolidColorBrush(Colors.Green);
                    }));

                    Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate
                     {
                         UpdateData();
                     }
                    ));
                }
            }
        }
        private void StartSensorAnimation()
        {
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate
            {
                DoubleAnimation ba = new DoubleAnimation();
                ba.From = 1; // 이미지 보임
                ba.To = 0; // 이미지 보이지 않음
                ba.Duration = TimeSpan.FromSeconds(2);
                ba.AutoReverse = true;
                //ba.RepeatBehavior = RepeatBehavior.Forever;

                Sensor.BeginAnimation(OpacityProperty, ba);
            }));

        }
        private void Client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {

            var message = Encoding.UTF8.GetString(e.Message);
            currentData = JsonConvert.DeserializeObject<Dictionary<string, string>>(message);

            if (currentData["PRC_MSG"] == "OK" || currentData["PRC_MSG"] == "FAIL")
            {
                sw.Stop();
                sw.Reset();
                sw.Start();

                StartSensorAnimation();
            }
        }
        Dictionary<string, string> currentData = new Dictionary<string, string>();
        private void BtnStartProcess_Click(object sender, RoutedEventArgs e)
        {
            InsertProcessData();
            StartAnimation();// HMI 애니메이션 실행
        }

        private bool InsertProcessData()
        {
            var item = new Model.Process();
            item.SchIdx = currSchedule.SchIdx;
            item.PrcCd = GetProcessCodeFromDB();
            item.PrcDate = DateTime.Now;
            item.PrcLoadTime = currSchedule.SchLoadTime;
            item.PrcStartTime = currSchedule.SchStartTime;
            item.PrcEndTime = currSchedule.SchEndTime.ToString();
            item.PrcFacilityID = Commons.FACILITYID;
            item.PrcResult = true;//참으로 시작
            item.RegDate = DateTime.Now;
            item.RegID = "MRP";
            try
            {
                var result = Logic.DataAccess.SetProcess(item);
                if (result == 0)
                {
                    Commons.LOGGER.Error("공정데이터 입력 실패!");
                    Commons.ShowMessageAsync("오류", "공정시작 오류발생, 관리자 문의");
                    return false;
                }
                else
                {
                    Commons.LOGGER.Info("공정데이터 입력!");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Commons.LOGGER.Error($"예외발생 : {ex}");
                Commons.ShowMessageAsync("오류", "공정시작 오류발생, 관리자 문의");
                return false;
            }
        }
        //return true는 공정성공, false는 공정실패
        private string GetProcessCodeFromDB()//그 날짜의 정보가 다 나와 있다.
        {
            var prefix = "PRC";
            var prePrcCode = prefix + DateTime.Now.ToString("yyyyMMdd");//PRC20210629
            var resultCode = string.Empty;
            var maxPrc = Logic.DataAccess.GetProcess().Where(p => p.PrcCd.Contains(prePrcCode)).OrderByDescending(p => p.PrcCd).FirstOrDefault();
            //이전까지 공정을 시행된 것이 없으면 NULL을 가져온다.
            //PRC20210620001, 002,003,004==>PRC20210629004--> null이 넘어오면 새로 만들면 됨.
            if (maxPrc == null)
            {
                resultCode = prePrcCode + 1.ToString("000");//"001"; 최초의 당일 공정 코드값이 나온다.
            }
            else
            {
                var maxPrcCd = maxPrc.PrcCd;//PRC20210629004
                var maxVal = int.Parse(maxPrcCd.Substring(11)) + 01;//004->4+1-->5

                resultCode = prePrcCode + maxVal.ToString("000");//최대공정코드 +1값
            }
            return resultCode;
        }
        private void UpdateData()
        {
            //성공수량
            var prcOKAmount = Logic.DataAccess.GetProcess().Where(p => p.PrcDate.Equals(DateTime.Now)).Where(p => p.SchIdx.Equals(currSchedule.SchIdx)).Where(p => p.PrcResult.Equals(true)).Count();
            //실패수량
            var prcFailAmount= Logic.DataAccess.GetProcess().Where(p => p.PrcDate.Equals(DateTime.Now)).Where(p => p.SchIdx.Equals(currSchedule.SchIdx)).Where(p => p.PrcResult.Equals(false)).Count();
            //성공률
            var prcOkRate = 100 * ((double)prcOKAmount / (double)currSchedule.SchAmount);
            //실패율
            var prcFailRate= 100 * ((double)prcFailAmount / (double)currSchedule.SchAmount);

            LBlPrcOKAmount.Content = $"{prcOKAmount}개";
            LBlPrcFailAmount.Content = $"{prcFailAmount}개";
            LBlPrcOKAmount.Content = $"{prcOkRate}개";
            LBlPrcFailAmount.Content = $"{prcFailRate}개";
        }
        private void StartAnimation()
        {
            Product.Fill = new SolidColorBrush(Colors.Gray);
            // 기어 애니메이션 속성
            DoubleAnimation da = new DoubleAnimation();
            da.From = 0;
            da.To = 360;
            da.Duration = TimeSpan.FromSeconds(currSchedule.SchLoadTime);//일정 계획로드타임
                                                                         // da.RepeatBehavior = RepeatBehavior.Forever;//무한 반복으로 돈다.

            RotateTransform rt = new RotateTransform();
            Gear1.RenderTransform = rt;
            Gear1.RenderTransformOrigin = new Point(0.5, 0.5);
            Gear2.RenderTransform = rt;
            Gear2.RenderTransformOrigin = new Point(0.5, 0.5);

            rt.BeginAnimation(RotateTransform.AngleProperty, da);
            //제품 애니메이션 속성
            DoubleAnimation ma = new DoubleAnimation();
            ma.From = 154;
            ma.To = 540;//옮겨지는 x값의 최대값
            ma.Duration = TimeSpan.FromSeconds(currSchedule.SchLoadTime);
            ma.AccelerationRatio = 0.5;
            // ma.AutoReverse = true;
            Product.BeginAnimation(Canvas.LeftProperty, ma);
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            //자원해제
            if (client.IsConnected) client.Disconnect();
            timer.Dispose();
            //new delete 자원해제가 매우 중요하다.
        }
    }
}
