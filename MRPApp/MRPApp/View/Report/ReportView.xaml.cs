﻿using System;
using System.Windows;
using System.Windows.Controls;

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
                DisplayChar();
            }
            catch (Exception ex)
            {
                Commons.LOGGER.Error($"예외발생 Report Loaded : {ex}");
                throw ex;
            }
        }

        private void DisplayChar()
        {
            double[] ys1 = new double[] { 10.4, 34.6, 22.1, 15.4, 40.0 };
            double[] ys2 = new double[] { 9.7, 8.3, 2.6, 3.4, 7.7 };

            var series1 = new LiveCharts.Wpf.ColumnSeries { Title="First Val", Values=new LiveCharts.ChartValues<double>(ys1) };
            var series2 = new LiveCharts.Wpf.ColumnSeries { Title="Second Val", Values=new LiveCharts.ChartValues<double>(ys2) };
            //차트할당
            ChtReport.Series.Clear();
            ChtReport.Series.Add(series1);
            ChtReport.Series.Add(series2);
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
                DisplayChar();
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
