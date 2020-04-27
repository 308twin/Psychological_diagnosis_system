using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Psychological_diagnosis_system.Models;
using Prism.Mvvm;

using Psychological_diagnosis_system.Entities;
using Psychological_diagnosis_system.Services;

namespace Psychological_diagnosis_system.ViewModels
{
    class RecordViewModel: BindableBase
    {
        public RecordShowDto RecordShowDto { get; set; }
        private bool isSelected;

        public bool IsSelected
        {
            get { return this.isSelected; }
            set
            {
                isSelected = value;
                this.RaisePropertyChanged("IsSelected");
            }
        }
    }
}
