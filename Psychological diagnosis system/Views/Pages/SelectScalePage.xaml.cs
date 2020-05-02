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
using Psychological_diagnosis_system.ViewModels;
using Psychological_diagnosis_system.Views.Pages;
using Psychological_diagnosis_system.DtoParameters;
namespace Psychological_diagnosis_system.Views.Pages
{
    /// <summary>
    /// SelectScalePage.xaml 的交互逻辑
    /// </summary>
    public partial class SelectScalePage : Page
    {
        public SelectScalePage()
        {
            InitializeComponent();
            SelectScaleViewModel selectScaleViewModel = new SelectScaleViewModel();
            DataContext = selectScaleViewModel;
            ViewModelInfo.usingScaleDtoParameter = new UsingScaleDtoParameter
            {
                ID = "",
                DbName = "",
                QuesNum = 0,
                SelectNum = 0
            };
            //不知道为什么这里无法显示父窗口，但是通过button事件可以获取到，是否因为加载顺序问题？
            //Window window = Window.GetWindow(this);
            //Console.WriteLine("load:"+window);
            //selectScaleViewModel.CloseFormAction = new Action(() => window.Close());

        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            Console.WriteLine(window);
            window.Close();
        }

        private void Ensure_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModelInfo.usingScaleDtoParameter.DbName == "")
                MessageBox.Show("请选择一个量表");
            else
            {
                NavigationService nav = NavigationService.GetNavigationService(this);
                nav.Navigate(new Uri("/Psychological diagnosis system;component/Views/Pages/SelectAnswerPage.xaml", UriKind.RelativeOrAbsolute));
            }
        }
    }
}
