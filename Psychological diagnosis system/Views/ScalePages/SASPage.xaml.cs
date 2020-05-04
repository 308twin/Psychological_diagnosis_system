using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Psychological_diagnosis_system.ViewModels.ScalePageViewModels;
using Psychological_diagnosis_system.ViewModels;
using Psychological_diagnosis_system.Services;
using Psychological_diagnosis_system.Repositories;
using System;
namespace Psychological_diagnosis_system.Views.ScalePages
{
    /// <summary>
    /// SASPage.xaml 的交互逻辑
    /// </summary>
    public partial class SASPage : Page
    {
        RecordRepository recordRepository = new RecordRepository();
        public int[] count = new int[20];   //更改数字后可以复用
        public SASPage()
        {
            InitializeComponent();
            SASViewModel sasViewModel = new SASViewModel(); //复用时记得修改量表ViewModel
            DataContext = sasViewModel;

            //这里是为了让正常滑动，直接复用就好
            listbox.PreviewMouseWheel += (sender, e) =>
            {

                var eventArg = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta);

                eventArg.RoutedEvent = UIElement.MouseWheelEvent;

                eventArg.Source = sender;

                this.listbox.RaiseEvent(eventArg);

            };
        }
        //直接复用，用来记录选项的
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = (sender as RadioButton);
            //这个Convert预设了五种选项的转换，可以复用
            count[int.Parse(radioButton.GroupName)-1] = DataConvert.QuizNumConvert(radioButton.Name);   
        }
        //记录未选择的题号，可以复用
        private void Ensure_Button_Click(object sender, RoutedEventArgs e)
        {
           
            if(Array.IndexOf(count, 0) != -1)
            {
                MessageBox.Show("第" + DataConvert.UnSelectConvert(count) + "题未选择");
            }
            else
            {
                ViewModelInfo.endTime = DateTime.Now;
                string recordID = recordRepository.SaveRecord();
                recordRepository.SaveAnswerCard_SAS(count, recordID);
                MessageBox.Show("成功录入！");
                Window window = Window.GetWindow(this);
                Console.WriteLine(window);
                window.Close();

            }
        }
        //关闭窗口，可以复用
        private void Close_Button_Click(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Close();
        }
    }
}
