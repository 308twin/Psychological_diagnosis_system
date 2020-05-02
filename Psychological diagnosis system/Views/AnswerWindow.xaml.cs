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
using Psychological_diagnosis_system.Views.Pages;
namespace Psychological_diagnosis_system.Views
{
    /// <summary>
    /// AnswerWindow.xaml 的交互逻辑
    /// </summary>
    public partial class AnswerWindow : Window
    {
        public AnswerWindow()
        {
            InitializeComponent();
            this.DataContext = new SelectScaleViewModel();

            //var grid = SelectScalePage.Parent as Grid;
            //Console.WriteLine(grid.Parent);
            
        }
    }
}
