using Psychological_diagnosis_system.Models;
using System;
using System.Windows;
using Psychological_diagnosis_system.Services;
using Psychological_diagnosis_system.ViewModels;
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
            AnalysisPage.Source = new Uri("/Psychological diagnosis system;component/Views/AnalysisPages/"+
                DataConvert.ScaleNameToAnalysisPageName(record.Item), UriKind.RelativeOrAbsolute);
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
