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
using Psychological_diagnosis_system.ViewModels;
namespace Psychological_diagnosis_system.Views
{
    /// <summary>
    /// AddUserWindows.xaml 的交互逻辑
    /// </summary>
    public partial class AddUserWindows : Window
    {
        AddUserViewModel _addUserViewModel;
        public AddUserWindows()
        {
            InitializeComponent();
            _addUserViewModel = new AddUserViewModel();
            DataContext = _addUserViewModel;
            District_Controller.Province = "福建省";
            _addUserViewModel.CloseFormAction = new Action(() => this.Close());
        }

        private void Close_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            _addUserViewModel.NewUser.PROVINCE = District_Controller.Province;
            _addUserViewModel.NewUser.CITY = District_Controller.City;
            _addUserViewModel.NewUser.DISTRICT_TOWN = District_Controller.County;
            _addUserViewModel.NewUser.DETAIL_ADDRESS = District_Controller.address.Text;
            Console.WriteLine(_addUserViewModel.NewUser.DETAIL_ADDRESS);
        }
    }
}
