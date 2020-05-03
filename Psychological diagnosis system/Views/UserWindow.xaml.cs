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
    /// UserWindow.xaml 的交互逻辑
    /// </summary>
    public partial class UserWindow : Window
    {
        public UserWindow()
        {
            InitializeComponent();
            this.DataContext = new UserViewModel();
            ViewModelInfo.userShowDtoParameter = new UserShowDtoParameter
            {
                id = ID.Text,
                name = Name.Text,
                age = 0,
                idNumber = IdNumber.Text,
                sex = Sex.Text,
                education = Education.Text,
                marriage = Marriage.Text
            };
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void Ensure_Click(object sender, RoutedEventArgs e)
        {
           
            if (select_ID.IsChecked == true)
                ViewModelInfo.userShowDtoParameter.id = ID.Text;
            if (select_Name.IsChecked == true)
                ViewModelInfo.userShowDtoParameter.name = Name.Text;
            if (select_IdNumber.IsChecked == true)
                ViewModelInfo.userShowDtoParameter.idNumber = IdNumber.Text;
            if (select_Age.IsChecked == true)
            {
                try
                {
                    int age = int.Parse(Age.Text);
                    ViewModelInfo.userShowDtoParameter.age = age;
                }
                catch (FormatException)
                {
                    MessageBox.Show("输入的不是数字");
                    
                }
            }
            if (select_Sex.IsChecked == true)
                ViewModelInfo.userShowDtoParameter.sex = Sex.Text;
            if (select_Education.IsChecked == true)
                ViewModelInfo.userShowDtoParameter.education = Education.Text;
            if (select_Marriage.IsChecked == true)
                ViewModelInfo.userShowDtoParameter.marriage = Marriage.Text;

           
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
