using Psychological_diagnosis_system.Models;
using System;
using System.Windows;
using Psychological_diagnosis_system.Services;
using Psychological_diagnosis_system.ViewModels;
using System.Windows.Controls;

namespace Psychological_diagnosis_system.Views
{
    /// <summary>
    /// AnalysisWindows.xaml 的交互逻辑
    /// </summary>
    public partial class AnalysisWindows : Window
    {
        public AnalysisWindows(RecordShowDto record)
        {
            InitializeComponent();
            ViewModelInfo.analysisRecrod = record;
            //因为是通过转换跳到页面，所以一个分析量表对应一个转换
            AnalysisPage.Source = new Uri("/Psychological diagnosis system;component/Views/AnalysisPages/"+
                DataConvert.ScaleNameToAnalysisPageName(record.Item), UriKind.RelativeOrAbsolute);  
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(AnalysisPage, "invoice");
                }
            }
            finally
            {
                this.IsEnabled = true;
            }
        }
    }
}
