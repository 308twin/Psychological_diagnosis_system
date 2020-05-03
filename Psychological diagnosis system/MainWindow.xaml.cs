using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using Psychological_diagnosis_system.Entities;
using Psychological_diagnosis_system.Helpers;
using Psychological_diagnosis_system.Models;
using Psychological_diagnosis_system.Profiles;
using Psychological_diagnosis_system.Services;
using Psychological_diagnosis_system.Repositories;
using Psychological_diagnosis_system.ViewModels;
using Psychological_diagnosis_system.Views;
using System.Globalization;

namespace Psychological_diagnosis_system
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        
        static pdsEntities pds = new pdsEntities();
        string cs = @"server=localhost;userid=root;
            password=root;database=psychological_diagnosis_system";
        MySqlConnection conn = null;
        MySqlDataReader rdr = null;
        DataService dataService = new DataService(pds);
        MainWindowViewModel _mainWindowViewModel;
        public MainWindow()
        {
            InitializeComponent();
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            _mainWindowViewModel = mainWindowViewModel;
            this.DataContext = _mainWindowViewModel;
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void ToolBar_Loaded(object sender, RoutedEventArgs e)
        {
            ToolBar toolBar = sender as ToolBar;
            var overflowGrid = toolBar.Template.FindName("OverflowGrid", toolBar) as FrameworkElement;
            if (overflowGrid != null)
            {
                overflowGrid.Visibility = Visibility.Collapsed;
            }

            var mainPanelBorder = toolBar.Template.FindName("MainPanelBorder", toolBar) as FrameworkElement;
            if (mainPanelBorder != null)
            {
                mainPanelBorder.Margin = new Thickness(0);
            }
        }

        private void Start_Answer_Click(object sender, RoutedEventArgs e)
        {
            AnswerWindow answerWindow = new AnswerWindow();
            answerWindow.Owner = this;
            answerWindow.ShowDialog();
           
        }

        private void quit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void user_manage_Click(object sender, RoutedEventArgs e)
        {

            UserWindow userWindow = new UserWindow();
            userWindow.Owner = this;
            userWindow.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
            userWindow.ShowDialog();

        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            SearchWindow searchWindow = new SearchWindow();
            searchWindow.Owner = this;
            searchWindow.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
            searchWindow.ShowDialog();
        }

        private void analytics_Click(object sender, RoutedEventArgs e)
        {
            if(int.Parse(Count_TextBox.Text)>1)
            {
                MessageBox.Show("单次只能生产一张分析表格，请只选择一条记录");
            }
            else if(int.Parse(Count_TextBox.Text) ==0)
            {
                MessageBox.Show("请选择一条记录");
            }
            else
            {
                RecordViewModel record = new RecordViewModel();
                
                //record = _mainWindowViewModel.Records.Where(x => x.IsSelected == true).FirstOrDefault();
                record = _mainWindowViewModel.Records.FirstOrDefault(x => x.IsSelected == true);
                AnalysisWindows analysisWindows = new AnalysisWindows(record.RecordShowDto);
                analysisWindows.ShowDialog();
            }
            //try
            //{
            //    this.IsEnabled = false;
            //    PrintDialog printDialog = new PrintDialog();
            //    if (printDialog.ShowDialog() == true)
            //    {
            //        printDialog.PrintVisual(print, "invoice");
            //    }
            //}
            //finally
            //{
            //    this.IsEnabled = true;
            //}
        }
        public class TimeConverter : IValueConverter
        {
            //当值从绑定源传播给绑定目标时，调用方法Convert
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value == null)
                    return DependencyProperty.UnsetValue;
                DateTime date = (DateTime)value;
                return date.ToString("yyyy-MM-dd");
            }
            //当值从绑定目标传播给绑定源时，调用此方法ConvertBack
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                string str = value as string;
                DateTime txtDate;
                if (DateTime.TryParse(str, out txtDate))
                {
                    return txtDate;
                }
                return DependencyProperty.UnsetValue;
            }
        }
    }
    
}
