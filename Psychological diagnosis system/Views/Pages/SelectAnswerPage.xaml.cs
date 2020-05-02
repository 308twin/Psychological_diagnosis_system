using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Psychological_diagnosis_system.ViewModels;
using Psychological_diagnosis_system.DtoParameters;
using Psychological_diagnosis_system.Services;
using Psychological_diagnosis_system.ViewModels.ScalePageViewModels;
namespace Psychological_diagnosis_system.Views.Pages
{
    /// <summary>
    /// SelectAnswerPage.xaml 的交互逻辑
    /// </summary>
    public partial class SelectAnswerPage : Page
    {
        public SelectAnswerPage()
        {
            InitializeComponent();
            SelectAnswerViewModel selectAnswerViewModel = new SelectAnswerViewModel();
            DataContext = selectAnswerViewModel;
            ViewModelInfo.userShowDtoParameter = new UserShowDtoParameter
            {
                id = ID.Text,
                name = Name.Text,
                age = 0,
                idNumber = IdNumber.Text,
                sex = Sex.Text,
                education = Education.Text
            };
            ViewModelInfo.respondentId = "";
        }

        private void Search_Click(object sender, RoutedEventArgs e)
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
        }

        private void Ensure_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModelInfo.respondentId == "")
                MessageBox.Show("请选择一位答题者");
            else
            {
                string pageName = DataConvert.ScaleNameConvert(ViewModelInfo.usingScaleDtoParameter.DbName);                
                NavigationService nav = NavigationService.GetNavigationService(this);
                nav.Navigate(new Uri("/Psychological diagnosis system;component/Views/ScalePages/"+pageName, UriKind.RelativeOrAbsolute));
                ViewModelInfo.startTime = DateTime.Now;
                Console.WriteLine(ViewModelInfo.startTime);
            }
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            Console.WriteLine(window);
            window.Close();
        }
    }
}
