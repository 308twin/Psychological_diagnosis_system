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

namespace WpfApplication1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            //这里传入数据 默认绑定
            District.Province ="湖北省";
            District.City = "武汉市";
            
 
        }

        private void btn_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(District.Province + " " + District.City + " " + District.County + " "+ District.address.Text);
        }
    }
}
