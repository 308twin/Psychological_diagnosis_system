﻿using System.Collections.Generic;
using Prism.Mvvm;
using Psychological_diagnosis_system.Services;

namespace Psychological_diagnosis_system.ViewModels.ScalePageViewModels
{
    class SASViewModel : BindableBase
    {
        static readonly pdsEntities pds = new pdsEntities();
        DataService dataService = new DataService(pds);
        private List<self_rating_anxiety_scale> scale;  //不可复用，量表类型需要更改
        //private int[] answerSelect = new int[20];
        //private List<sas_answer_card> answerCard;
        public List<self_rating_anxiety_scale> Scale //不可复用，量表类型需要更改
        {
            get { return scale; }
            set
            {
                scale = value;
                this.RaisePropertyChanged("Scale");
            }
        }
         
        public SASViewModel()
        {
            LoadScale();
        }
        public void LoadScale()
        {
            scale = dataService.GetSelf_Rating_Anxiety_Scales();    //读出数据，不可复用，而且需要dataService的方法

        }
    }
}
