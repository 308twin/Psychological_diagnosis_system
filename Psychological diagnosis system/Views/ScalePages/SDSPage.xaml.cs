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
    /// SDSPage.xaml 的交互逻辑
    /// </summary>
    public partial class SDSPage : Page
    {
        RecordRepository recordRepository = new RecordRepository();
        public int[] count = new int[20];
        public SDSPage()
        {
            InitializeComponent();
            SDSViewModel sdsViewModel = new SDSViewModel();
            DataContext = sdsViewModel;

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
            count[int.Parse(radioButton.GroupName) - 1] = DataConvert.QuizNumConvert(radioButton.Name);           
        }
        private void Ensure_Button_Click(object sender, RoutedEventArgs e)
        {

            if (Array.IndexOf(count, 0) != -1)
            {
                MessageBox.Show("第" + DataConvert.UnSelectConvert(count) + "未选择");
            }
            else
            {
                ViewModelInfo.endTime = DateTime.Now;
                string recordID = recordRepository.SaveRecord();
                recordRepository.SaveAnswerCard_SAS(count, recordID);

            }
        }

        private void Close_Button_Click(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            Console.WriteLine(window);
            window.Close();
        }
    }
}
