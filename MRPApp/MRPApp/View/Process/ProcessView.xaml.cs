using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace MRPApp.View.Process
{
    /// <summary>
    /// ProcessView.xaml에 대한 상호 작용 논리
    /// 1. 공정계획에서 오늘의 생산계획 일정을 불러온다.
    /// 2. 없으면 에러표시, 시작버튼 클릭하지 못하게 만든다.
    /// 3. 공정이 있으면 오늘의 날짜를 표시하고, 시작버튼을 활성화한다.
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
                currSchedule = Logic.DataAccess.GetSchedules().Where(s => s.PlantCode.Equals(Commons.PLANTCODE)).Where(s=>s.SchDate.Equals(DateTime.Parse(today))).FirstOrDefault();

                if (currSchedule == null)
                {
                    await Commons.ShowMessageAsync("공정", "공정계획이 없습니다. 계획일정을 먼저 입력하시오");
                    LblProcessDate.Content = string.Empty;
                    LblSchLoadTime.Content = "None";
                    LblSchAmount.Content = "None";
                    BtnStartProcess.IsEnabled = false;
                    //TODO 시작버튼 Disable
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
                }
            }
            catch (Exception ex)
            {
                Commons.LOGGER.Error($"예외발생 ProcessView Loaded : {ex}");
                throw ex;
            }
        }

        private void BtnStartProcess_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation da = new DoubleAnimation();
            da.From = 0;
            da.To = 360;
            da.Duration = new Duration(TimeSpan.FromSeconds(currSchedule.SchLoadTime));//일정 계획로드타임
           // da.RepeatBehavior = RepeatBehavior.Forever;//무한 반복으로 돈다.

            RotateTransform rt = new RotateTransform();
            Gear1.RenderTransform = rt;
            Gear1.RenderTransformOrigin = new Point(0.5, 0.5);
            Gear2.RenderTransform = rt;
            Gear2.RenderTransformOrigin = new Point(0.5, 0.5);

            rt.BeginAnimation(RotateTransform.AngleProperty, da);
        }
    }
}
