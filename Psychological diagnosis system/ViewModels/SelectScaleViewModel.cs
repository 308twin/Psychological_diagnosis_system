using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Commands;
using Prism.Mvvm;
using Psychological_diagnosis_system.Services;
using Psychological_diagnosis_system.Models;
using Psychological_diagnosis_system.DtoParameters;
using System.Collections.ObjectModel;

namespace Psychological_diagnosis_system.ViewModels
{
    class SelectScaleViewModel : BindableBase
    {
        static readonly pdsEntities pds = new pdsEntities();

        DataService dataService = new DataService(pds);
        public DelegateCommand SelectScaledCommand { get; set; }
        public DelegateCommand QuitCommand { get; set; }

        private List<ScaleInfoShowDto> scaleList;
        private ObservableCollection<ScaleInfoShowDto> scaleObserv;
        private ScaleInfoShowDto selectItem;
         
        //private UsingScaleDtoParameter usingScaleDtoParameter;
        public Action CloseFormAction { get; set; }

        public List<ScaleInfoShowDto> ScaleList
        {
            get { return scaleList; }
            set
            {
                scaleList = value;
                this.RaisePropertyChanged("ScaleList");
            }
        }
        public ObservableCollection<ScaleInfoShowDto> ScaleObserv
        {
            get { return scaleObserv; }
            set
            {
                scaleObserv = value;
                this.RaisePropertyChanged("ScaleObserv");
            }
        }
        public ScaleInfoShowDto SelectItem
        {
            get { return selectItem; }
            set
            {
                //ViewModelInfo.usingScaleDtoParameter = new UsingScaleDtoParameter
                //{
                //    ID = "",
                //    DbName = "",
                //    QuesNum = 0,
                //    SelectNum = 0
                //};
                
                selectItem = value;
                this.RaisePropertyChanged("SelectItem");
                ViewModelInfo.usingScaleDtoParameter.DbName = pds.scale_info.FirstOrDefault(x => x.NAME == selectItem.Name).DB_NAME;
                ViewModelInfo.usingScaleDtoParameter.QuesNum = selectItem.QuesNum;
                ViewModelInfo.usingScaleDtoParameter.SelectNum = selectItem.SelectNum;
                Console.WriteLine(ViewModelInfo.usingScaleDtoParameter.DbName);
            }
        }
        //public UsingScaleDtoParameter UsingScaleDtoParameter
        //{
        //    get { return usingScaleDtoParameter; }
        //    set
        //    {
        //        usingScaleDtoParameter = value;
        //        this.RaisePropertyChanged("UsingScaleDtoParameter");

        //    }
        //}

        public SelectScaleViewModel()
        {
            LoadScaleShowDto();
            QuitCommand = new DelegateCommand(Close);
            

        }
        private void LoadScaleShowDto()
        {
            ScaleList = dataService.GetScaleInfoShowDtos().ToList();
            ScaleObserv = new ObservableCollection<ScaleInfoShowDto>(ScaleList);
            Console.WriteLine(ScaleObserv.Count+ScaleObserv[0].Name);
        }
        public void Close()
        {
            this.CloseFormAction();
        }
    }
}
