﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MRPApp.View.Report
{
    /// <summary>
    /// MyAccount.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ReportView : Page
    {
        public ReportView()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                InitControls();
            }
            catch (Exception ex)
            {
                Commons.LOGGER.Error($"예외발생 Report Loaded : {ex}");
                throw ex;
            }
        }
        
        private void DisplayChar(List<Model.Report> list)
        {
            int[] schAmount = list.Select(a => (int)a.SchAmount).ToArray();
            int[] prcOkAmounts = list.Select(a => (int)a.PrcOKAmount).ToArray();
            int[] prcFailAmounts = list.Select(a => (int)a.PrcFailAmount).ToArray();
            var series1 = new LiveCharts.Wpf.ColumnSeries { Title="계획수량",Fill= new SolidColorBrush(Colors.Green), Values=new LiveCharts.ChartValues<int>(schAmount) };
            var series2 = new LiveCharts.Wpf.ColumnSeries { Title="성공수량",  Fill = new SolidColorBrush(Colors.Blue), Values =new LiveCharts.ChartValues<int>(prcOkAmounts) };
            var series3 = new LiveCharts.Wpf.ColumnSeries { Title= "실패수량",  Fill = new SolidColorBrush(Colors.Red), Values =new LiveCharts.ChartValues<int>(prcFailAmounts) };
            //차트할당
            ChtReport.Series.Clear();
            ChtReport.Series.Add(series1);
            ChtReport.Series.Add(series2);
            ChtReport.Series.Add(series3);
            //X축 좌표값을 날짜로 표시
            ChtReport.AxisX.First().Labels = list.Select(a => a.PrcDate.ToString("yyyy-MM-dd")).ToList();
        }

        private void InitControls()
        {
            DtpSearchStartDate.SelectedDate = DateTime.Now.AddDays(-7);
            DtpSearchEndDate.SelectedDate = DateTime.Now;
        }

        private void BtnEditMyAccount_Click(object sender, RoutedEventArgs e)
        {
            //NavigationService.Navigate(new EditAccount()); // 계정정보 수정 화면으로 변경
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (IsvalidInput())
            {
                var startDate = ((DateTime)DtpSearchStartDate.SelectedDate).ToString("yyyy-MM-dd");
                var endDate=((DateTime) DtpSearchEndDate.SelectedDate).ToString("yyyy-MM-dd");
                var searchResult = Logic.DataAccess.GetReportDatas(startDate, endDate, Commons.PLANTCODE);
                DisplayChar(searchResult);
            }
        }

        private bool IsvalidInput()
        {
            var result = true;
            //검증은 To be continued....
            return result;
        }
    }
}
