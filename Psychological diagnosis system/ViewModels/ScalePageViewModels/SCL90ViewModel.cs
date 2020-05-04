using System.Collections.Generic;
using Prism.Mvvm;
using Psychological_diagnosis_system.Services;

namespace Psychological_diagnosis_system.ViewModels.ScalePageViewModels
{
    class SCL90ViewModel : BindableBase
    {
        static readonly pdsEntities pds = new pdsEntities();
        DataService dataService = new DataService(pds);
        private List<scl90_scale> scale;  //不可复用，量表类型需要更改

        public List<scl90_scale> Scale //不可复用，量表类型需要更改
        {
            get { return scale; }
            set
            {
                scale = value;
                this.RaisePropertyChanged("Scale");
            }
        }
        public SCL90ViewModel()
        {
            LoadScale();
        }
        public void LoadScale()
        {
            scale = dataService.GetScl90_Scales();    //读出数据，不可复用，而且需要dataService的方法

        }
    }
}
