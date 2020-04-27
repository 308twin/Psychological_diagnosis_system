using Psychological_diagnosis_system.Models;
using Prism.Mvvm;

namespace Psychological_diagnosis_system.ViewModels
{
    class UserGridViewModel:BindableBase
    {
        public UserShowDto UserShowDto { get; set; }
        private bool isSelected;

        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                RaisePropertyChanged("IsSeleted");

            }
        }
    }
}
