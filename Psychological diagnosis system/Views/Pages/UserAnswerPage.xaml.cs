using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Psychological_diagnosis_system.ViewModels;

namespace Psychological_diagnosis_system.Views.Pages
{
    /// <summary>
    /// UserAnswerPage.xaml 的交互逻辑
    /// </summary>
    public partial class UserAnswerPage : Page
    {
        public UserAnswerPage()
        {
            InitializeComponent();
            UserAnswerViewModel userAnswerViewModel = new UserAnswerViewModel();
            DataContext = userAnswerViewModel;

            listbox.PreviewMouseWheel += (sender, e) =>
            {

                var eventArg = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta);

                eventArg.RoutedEvent = UIElement.MouseWheelEvent;

                eventArg.Source = sender;

                this.listbox.RaiseEvent(eventArg);

            };
        }
        
    }
}
