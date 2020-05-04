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
    /// SCL90Page.xaml 的交互逻辑
    /// </summary>
    public partial class SCL90Page : Page
    {
        RecordRepository recordRepository = new RecordRepository();
        public int[] count = new int[90];   //更改数字后可以复用
        public SCL90Page()
        {
            InitializeComponent();
            SCL90ViewModel viewModel = new SCL90ViewModel();
            DataContext = viewModel;

            //这里是为了让正常滑动，直接复用就好
            listbox.PreviewMouseWheel += (sender, e) =>
            {

                var eventArg = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta);

                eventArg.RoutedEvent = UIElement.MouseWheelEvent;

                eventArg.Source = sender;

                this.listbox.RaiseEvent(eventArg);

            };
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = (sender as RadioButton);
            //这个Convert预设了五种选项的转换，可以复用
            count[int.Parse(radioButton.GroupName) - 1] = DataConvert.QuizNumConvert(radioButton.Name);
        }
       
        private void Ensure_Button_Click(object sender, RoutedEventArgs e)
        {
            //记录未选择的题号，可以复用
            if (Array.IndexOf(count, 0) != -1)
            {
                Console.WriteLine(string.Join("/",count));
                MessageBox.Show("第" + DataConvert.UnSelectConvert(count) + "题未选择");
                
            }
            else
            {
                //这里就不可以复用，需要自己写答题卡的存储
                ViewModelInfo.endTime = DateTime.Now;
                string recordID = recordRepository.SaveRecord();
                recordRepository.SaveAnswerCard_SCL90(count, recordID);
                MessageBox.Show("成功录入！");
                Window window = Window.GetWindow(this);
                Console.WriteLine(window);
                window.Close();

            }
        }

        private void Close_Button_Click(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Close();
        }
    }
}
