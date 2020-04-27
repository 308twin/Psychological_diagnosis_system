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
using System.Windows.Shapes;
using Psychological_diagnosis_system.DtoParameters;
using Psychological_diagnosis_system.ViewModels;
namespace Psychological_diagnosis_system.Views
{
    /// <summary>
    /// SearchWindow.xaml 的交互逻辑
    /// </summary>
    public partial class SearchWindow : Window
    {
        public SearchWindow()
        {
            InitializeComponent();
            ViewModelInfo.recordShowDtoParameter = new RecordShowDtoParameter();
            ViewModelInfo.recordShowDtoParameter.id = ID.Text;
            ViewModelInfo.recordShowDtoParameter.name = Name.Text;
            ViewModelInfo.recordShowDtoParameter.age = 0;
            ViewModelInfo.recordShowDtoParameter.idNumber = IdNumber.Text;
            ViewModelInfo.recordShowDtoParameter.sex = Sex.Text;
            ViewModelInfo.recordShowDtoParameter.education = Education.Text;
            ViewModelInfo.recordShowDtoParameter.marriage = Marriage.Text;


        }

        private void Ensure_Click(object sender, RoutedEventArgs e)
        {
            //MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            //MainWindow mainWindow =(MainWindow) this.Owner;                    
            //mainWindow.Record_Grid.ItemsSource = "";
            bool closeAble = true;
            if (select_ID.IsChecked == true)
                ViewModelInfo.recordShowDtoParameter.id = ID.Text;
            if (select_Name.IsChecked == true)
                ViewModelInfo.recordShowDtoParameter.name = Name.Text;
            if (select_IdNumber.IsChecked == true)
                ViewModelInfo.recordShowDtoParameter.idNumber = IdNumber.Text;
            if (select_Age.IsChecked == true)
            {
                try
                {
                    int age = int.Parse(Age.Text);
                    ViewModelInfo.recordShowDtoParameter.age = age;
                }
                catch (FormatException)
                {
                    MessageBox.Show("输入的不是数字");
                    closeAble = false;
                }
            }
            if (select_Sex.IsChecked == true)
                ViewModelInfo.recordShowDtoParameter.sex = Sex.Text;
            if (select_Education.IsChecked == true)
                ViewModelInfo.recordShowDtoParameter.education = Education.Text;
            if (select_Marriage.IsChecked == true)
                ViewModelInfo.recordShowDtoParameter.marriage = Marriage.Text;

            if (closeAble==true)
                this.Close();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
