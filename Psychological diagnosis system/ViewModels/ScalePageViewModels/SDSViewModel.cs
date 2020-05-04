using System.Collections.Generic;
using Prism.Mvvm;
using Psychological_diagnosis_system.Services;

namespace Psychological_diagnosis_system.ViewModels.ScalePageViewModels
{
    class SDSViewModel:BindableBase
    {
        static readonly pdsEntities pds = new pdsEntities();
        DataService dataService = new DataService(pds);
        private List<self_rating_depression_scale> scale;

        public List<self_rating_depression_scale> Scale
        {
            get { return scale; }
            set
            {
                scale = value;
                this.RaisePropertyChanged("Scale");
            }
        }
        public SDSViewModel()
        {
            LoadScale();
        }
        public void LoadScale()
        {
            scale = dataService.GetSelf_Rating_Depression_Scales(); //

        }
    }
}
