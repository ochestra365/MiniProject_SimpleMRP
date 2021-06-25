﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Input;
namespace MRPApp.View.Schedule
{
    /// <summary>
    /// MyAccount.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SchduleList : Page
    {
        public SchduleList()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadGridData();//테이블데이터 그리드 표시
                InitErrorMessage();
            }
            catch (Exception ex)
            {
                Commons.LOGGER.Error($"예외발생 StoreList Loaded : {ex}");
                throw ex;
            }
        }

        private void InitErrorMessage()
        {

            LblPlantCode.Visibility = LblSchDate.Visibility = LblSchEndTime.Visibility = LblSchLoadTime.Visibility = LblSchStartTime.Visibility = LblSchAmount.Visibility=LblSchFacilityID.Visibility=Visibility.Hidden;
        }

        private void LoadGridData()//일반적인 명칭을 쓰는 것이 좋다. 그러면 안에 있는 명칭만 쓰면 된다.
        {
            List<Model.Schdules> list = Logic.DataAccess.GetSchedules();
            this.DataContext = list;
        }

        private void BtnEditUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //NavigationService.Navigate(new EditUser());
            }
            catch (Exception ex)
            {
                Commons.LOGGER.Error($"예외발생 BtnEditUser_Click : {ex}");
                throw ex;
            }
        }

        private void BtnAddStore_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //NavigationService.Navigate(new AddStore());
            }
            catch (Exception ex)
            {
                Commons.LOGGER.Error($"예외발생 BtnAddStore_Click : {ex}");
                throw ex;
            }
        }

        private void BtnEditStore_Click(object sender, RoutedEventArgs e)
        {
            if (GrdData.SelectedItem == null)
            {
                Commons.ShowMessageAsync("창고수정", "수정할 창고를 선택하세요");
                return;
            }

            try
            {
                
            }
            catch (Exception ex)
            {
                Commons.LOGGER.Error($"예외발생 BtnEditStore_Click : {ex}");
                throw ex;
            }
        }

        private void BtnExportExcel_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            ClearInputs();
        }

        private async void BtnInsert_Click(object sender, RoutedEventArgs e)
        {
            if (IsValidInputs() != true) return;
            //var setting = new Model.Settings();//형변환//새로운 객체를 생성함
            //setting.BasicCode = TxtBasicCode.Text;
            //setting.CodeName = TxtCodeName.Text;
            //setting.CodeDesc = TxtCodeDesc.Text;
            //setting.RegDate = DateTime.Now;
            //setting.RegID = "MRP";

            try
            {
                //var result = Logic.DataAccess.SetSettings(setting);
                //if (result == 0)
                //{
                //    Commons.LOGGER.Error("데이터 입력 시 오류발생");
                //    await Commons.ShowMessageAsync("오류", "데이터 입력실패");
                //}
                //else
                //{
                //    Commons.LOGGER.Info($"데이터 입력 성공 : {setting.BasicCode}");//로그
                //    ClearInputs();
                //    LoadGridData();
                //}
            }
            catch (Exception ex)
            {
                Commons.LOGGER.Error($"예외발생 {ex}");
            }
        }
        //입력데이터 검증 메서드(반드시 필요하다. 빈 값이 들어가는 것을 막기 위함이다.)
        public bool IsValidInputs()
        {
            var isValid = true;
            InitErrorMessage();

            //if (string.IsNullOrEmpty(TxtBasicCode.Text))
            //{
            //    LblBasicCode.Visibility = Visibility.Visible;
            //    LblBasicCode.Text = "코드를 입력하세요";
            //    isValid = false;
            //}
            //else if(Logic.DataAccess.GetSettings().Where(s=>s.BasicCode.Equals(TxtBasicCode.Text)).Count()>0){
            //    LblBasicCode.Visibility = Visibility.Visible;
            //    LblBasicCode.Text = "중복코드가 존재합니다";
            //    isValid = false;
            //}
            //if (string.IsNullOrEmpty(TxtCodeName.Text))
            //{
            //    LblCodeName.Visibility = Visibility.Visible;
            //    LblCodeName.Text = "코드를 입력하세요";
            //    isValid = false;
            //}
            return isValid;
        }

        private async void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var setting = GrdData.SelectedItem as Model.Settings;//형변환 선택한 객체를 수정
            //setting.CodeName = TxtCodeName.Text;
            //setting.CodeDesc = TxtCodeDesc.Text;
            setting.ModDate = DateTime.Now;
            setting.ModID = "MRP";


            try
            {
                var result = Logic.DataAccess.SetSettings(setting);
                if (result == 0)
                {
                    Commons.LOGGER.Error("데이터 수정 시 오류발생");
                    await Commons.ShowMessageAsync("오류", "데이터 수정실패");
                }
                else
                {
                    Commons.LOGGER.Info($"데이터 수정 성공 : {setting.BasicCode}");//로그
                    ClearInputs();
                    LoadGridData();
                }
            }
            catch (Exception ex)
            {
                Commons.LOGGER.Error($"예외발생 {ex}");
            }
        }

        private void ClearInputs()
        {
            TxtSchIdx.Text = "";
            CboPlantCode.SelectedItem = null;
            DtpSchDate.Text = "";
            TxtSchLoadTime.Text = "";
            TmpSchStartTime.SelectedDateTime = null;
            TmpSchEndTime.SelectedDateTime = null;
            CboSchFacilityID.SelectedItem = null;
            NudSchAmount.Value = 0;
            CboPlantCode.Focus();
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            var search = DtpSearchDate.Text;

            var list = Logic.DataAccess.GetSchedules().Where(s => s.SchDate.Equals(search)).ToList();
            this.DataContext = list;
        }

        private void GrdData_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                var setting = GrdData.SelectedItem as Model.Settings;//형변환
                //TxtBasicCode.Text = setting.BasicCode;
                //TxtCodeName.Text = setting.CodeName;
                //TxtCodeDesc.Text = setting.CodeDesc;

                ////컨트롤 조작-->BasicCode는 PK이다.
                //TxtBasicCode.IsReadOnly = true;//값을 지우려고 해도 지워지지 않는다.
                //TxtBasicCode.Background = new SolidColorBrush(Colors.LightGray);
            }
            catch (Exception ex)
            {
                Commons.LOGGER.Error($"예외발생 : {ex}");
                ClearInputs();
            }
        }

        private async void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var setting = GrdData.SelectedItem as Model.Settings;

            if(setting == null)
            {
                await Commons.ShowMessageAsync("삭제", "삭제할 코드를 선택하세요");
                return;
            }
            else
            {
                try
                {
                    var result = Logic.DataAccess.DelSettings(setting);

                    if (result == 0)
                    {
                        Commons.LOGGER.Error("데이터 삭제 시 오류발생");
                        await Commons.ShowMessageAsync("오류", "데이터 삭제실패");
                    }
                    else
                    {
                        Commons.LOGGER.Info($"데이터 삭제 성공 : {setting.BasicCode}");//로그
                        ClearInputs();
                        LoadGridData();
                    }
                }
                catch (Exception ex)
                {
                    Commons.LOGGER.Error($"예외발생 {ex}");
                }
               
            }
        }

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) BtnSearch_Click(sender, e);
        }
    }
}
