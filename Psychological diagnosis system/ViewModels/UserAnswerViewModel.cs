using System.Collections.Generic;
using Prism.Mvvm;
using Psychological_diagnosis_system.Services;
using System.Collections.ObjectModel;

namespace Psychological_diagnosis_system.ViewModels
{
    class UserAnswerViewModel: BindableBase
    {
        static readonly pdsEntities pds = new pdsEntities();
        DataService dataService = new DataService(pds);
        private List<self_rating_depression_scale> self_Rating_Depression_Scale;
        private ObservableCollection<self_rating_depression_scale> sds;

        public List<self_rating_depression_scale> Self_Rating_Depression_Scale
        {
            get { return self_Rating_Depression_Scale; }
            set
            {
                self_Rating_Depression_Scale = value;
                this.RaisePropertyChanged("Self_Rating_Depression_Scale");
            }
        }
        public UserAnswerViewModel()
        {
            LoadScale();
        }
        public void LoadScale()
        {
            self_Rating_Depression_Scale = dataService.GetSelf_Rating_Depression_Scales();
            
        }
    }
}
