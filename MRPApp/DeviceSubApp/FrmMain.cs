using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace DeviceSubApp
{
    public partial class FrmMain : Form
    {
        MqttClient client;
        string connectionString;//DB연결 문자열 | MQTT Broker address
        ulong lineCount;
        delegate void UpdateTextCallback(string message);//스레드상에서 윈폼 RichTextbox 텍스트를 출력할 때 필요한 것

        Stopwatch sw = new Stopwatch();
        public FrmMain()
        {
            InitializeComponent();
            InitailizeAllData();
        }

        private void InitailizeAllData()
        {
            connectionString = "Data Source=" + TxtConnectionString.Text + ";Initial Catalog=MRP;User ID=sa;password=mssql_p@ssw0rd!";
            lineCount = 0;
            BtnConnect.Enabled = true;
            BtnDisconnect.Enabled = false;
            IPAddress brokerAddress;
            try
            {
                brokerAddress = IPAddress.Parse(TxtConnectionString.Text);
                client = new MqttClient(brokerAddress);
                client.MqttMsgPublishReceived += Client_MqttMsgPublishReceived;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            Timer.Enabled = true;
            Timer.Interval = 1000;//1000ms-->1sec
            Timer.Tick += Timer_Tick;
            Timer.Start();
        }

        private void Client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            try
            {
                var message = Encoding.UTF8.GetString(e.Message);
                UpdateText($">>>> 받은 메세지 : {message}");
                // message(json) > C# 타입으로 바꿀 거다.
                var currentData = JsonConvert.DeserializeObject<Dictionary<string, string>>(message);//역직렬화
                PrcInputDataToList(currentData);//필요한 데이터를 받고 나머지 데이터는 다 버리겠다. 소프트웨어 적으로 정확도를 높인다.

                //받기 직전의 원본 데이터와 똑같이 받게 된다.
                sw.Stop();
                sw.Reset();//다시 0으로 시작되게 함.
                sw.Start();
            }
            catch (Exception ex)
            {
                UpdateText($">>>>ERROR!! : {ex.Message}");
            }


        }//메시지 박스가 뜨면 팝업이 뜨고 진행이 안됨.. 누가 닫아줘야 함. 에러메시지도 리치박스안에서 처리되야 함. 로그로 정상적으로 다 찍어줘야 함.
        List<Dictionary<string, string>> iotData = new List<Dictionary<string, string>>();
        //라즈베리에서 들어온 메시지를 전역리스트에 입력하는 메서드
        private void PrcInputDataToList(Dictionary<string, string> currentData)
        {
            if (currentData["PRC_MSG"] != "OK" || currentData["PRC_MSG"] != "FAIL")
                iotData.Add(currentData);//OK에서 FAIL만 들어가기 때문에 어디서든 들어올 일이 없다.
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            LblResult.Text = sw.Elapsed.Seconds.ToString();//elapsed??
            if (sw.Elapsed.Seconds >= 3)
            {
                sw.Stop();
                sw.Reset();
                //TODO 실제 처리프로세스 실행
                // UpdateText("처리!!");
                //Prc-->실제적으로 필요한 데이터만 DB에 집어넣고 나머지는 초기화//
                PrcCorrectDataDB();
            }
        }

        //여러 데이터 중 최종 데이터만 DB에 입력하는 처리 메서드
        private void PrcCorrectDataDB()
        {
            if (iotData.Count > 0)
            {
                var correctData = iotData[iotData.Count - 1];//딕셔너리 데이터
                //DB에 입력한다.
                //UpdateText("DB처리");
                using (var conn = new SqlConnection(connectionString)) 
                {
                    var PrcResult = correctData["PRC_MSG"] == "OK" ? 1 : 0;
                    string strUpQry = $"UPDATE Process_DEV " +
                                      $"  SET PrcEndTime = '{DateTime.Now.ToString("HH:mm:ss")}'" +
                                      $"  , PrcResult = '{PrcResult}' " +
                                      $"  , ModDate = '{DateTime.Now.ToString("yyyy-mm-dd HH:mm:ss")}' " +
                                      $"  , ModID = '{"SYS"}' " +
                                      $"  WHERE PrcIdx =  " +
                                      $"  (SELECT TOP 1 PrcIdx FROM Process_DEV ORDER BY PrcIdx DESC)";

                    try
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand(strUpQry, conn);
                        if (cmd.ExecuteNonQuery() == 1) UpdateText("[DB]센싱값 Update 성공");
                        else UpdateText("[DB]센싱값 Update 실패");
                    }
                    catch (Exception ex)
                    {
                        UpdateText($">>>>DB ERROR!! : {ex.Message}");
                    }
                }
            }
            iotData.Clear();//데이터 모두 삭제 메모리 누수가 일어나지 않는다.
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            client.Connect(TxtClientID.Text);//SUBSCR01
            UpdateText(">>>>> Client Connect");

            client.Subscribe(new string[] { TxtSubscriptionTopic.Text },
                new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
            UpdateText(">>>>Subscring to : " + TxtSubscriptionTopic.Text);

            BtnConnect.Enabled = false;
            BtnDisconnect.Enabled = true;
        }

        private void BtnDisconnect_Click(object sender, EventArgs e)
        {
            client.Disconnect();
            UpdateText(">>>>Client disconnected");
            BtnConnect.Enabled = true;
            BtnDisconnect.Enabled = false;
        }

        private void UpdateText(string message)//delegate는 파라미터 시그니처가 같아야 한다. 이벤트 핸들러들을 의미한다. 대리자로 처리하는 것이 에러 구문을 띄우는 것이다.
        {
            if (RtbSubscr.InvokeRequired)
            {
                UpdateTextCallback callback = new UpdateTextCallback(UpdateText);
                this.Invoke(callback, new object[] { message });
            }
            else
            {
                lineCount++;
                RtbSubscr.AppendText($"{lineCount} : {message}\n");
                RtbSubscr.ScrollToCaret();//message log나 출력이 많이 되는 거를 대리자랑 업데이트 테스트를 많이 하게 된다. 그럼 별 문제 없이 시행된다.
            }
        }
    }
}
