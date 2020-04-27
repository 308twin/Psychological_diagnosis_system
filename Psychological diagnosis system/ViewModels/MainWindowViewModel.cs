using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using Psychological_diagnosis_system.Entities;
using Psychological_diagnosis_system.Services;
using Psychological_diagnosis_system.Models;
using Psychological_diagnosis_system.DtoParameters;
using System.Windows;
using Psychological_diagnosis_system.Views;
using System.Collections.ObjectModel;

namespace Psychological_diagnosis_system.ViewModels
{
    class MainWindowViewModel: BindableBase
    {
        static pdsEntities pds = new pdsEntities();
        DataService dataService = new DataService(pds);
        private  RecordShowDtoParameter recordShowDtoParameter ;

        public DelegateCommand SelectRecordCommand { get; set; }   //命令属性
        public DelegateCommand DeleteRecordCommand { get; set; }
        public DelegateCommand SearchRecordCommand { get; set; }
        public DelegateCommand RefreshRecordCommand { get; set; }
        public DelegateCommand SortByIdCommand { get; set; }
        static bool ifOrderId; 

        //public DelegateCommand SelectRecordCountCommand { get; set; }
        //private List<String> selectedId { get; set; }
        private List<RecordViewModel> record;   //数据属性
        private ObservableCollection<RecordViewModel> records;
        private int count;
        public List<RecordViewModel> Record
        {
            get { return record;}
            set
            {
                record = value;
                this.RaisePropertyChanged("Record");//告诉是Record这个属性发生了改变
            }

        }
        public ObservableCollection<RecordViewModel> Records
        {
            get { return records; }
            set
            {
                records = value;
                this.RaisePropertyChanged("Records");//告诉是Record这个属性发生了改变
            }

        }
        public int Count 
        {
            get { return count; }
            set
            {
                count = value;
                this.RaisePropertyChanged("Count");
            }
        }
        public RecordShowDtoParameter RecordShowDtoParameter
        {
            get { return RecordShowDtoParameter; }
            set
            {
                RecordShowDtoParameter = value;
                this.RaisePropertyChanged("RecordShowDtoParameter");
            }
        }


        public MainWindowViewModel()
        {

            ifOrderId = false;
            this.LoadRecordShowDto();//数据初始化
            this.DeleteRecordCommand = new DelegateCommand(new Action(this.DeleteRecord));
            this.SelectRecordCommand = new DelegateCommand(new Action(this.SelectRecord));
            this.SearchRecordCommand = new DelegateCommand(new Action(this.SearchRecord));
            this.RefreshRecordCommand = new DelegateCommand(new Action(this.RefreshRecord));

        }
        private void RefreshRecord()
        {
            RecordViewModel recordViewModel = new RecordViewModel();
            recordViewModel.RecordShowDto = new RecordShowDto();

            recordViewModel.RecordShowDto.Name = "test";
            this.Records.Add(recordViewModel);
            Console.WriteLine(records.Count());
            this.records.Where(x => x.RecordShowDto.Name.Contains("a"));
        }
        private void LoadRecordShowDto()
        {
            //this.Record = new List<RecordViewModel>();
            //Record.Clear();
            this.Records = new ObservableCollection<RecordViewModel>();
            List<RecordShowDto> recordShowDtos = dataService.GetRecordShowDtos();
            foreach(var recordShowDto in recordShowDtos)
            {
                
                RecordViewModel recordViewModel = new RecordViewModel();
                recordViewModel.RecordShowDto = recordShowDto;             
                
                this.Records.Add(recordViewModel);
            }
            this.Record = new List<RecordViewModel>(Records);


        }
        private void DeleteRecord()
        {
            Console.WriteLine(count);
            var selectedUser = this.record.Where(x => x.IsSelected == true).Select(x => x.RecordShowDto.Name).ToList();
            if (selectedUser==null||selectedUser.Count==0)
                MessageBox.Show("无选择");
            else
                MessageBox.Show(selectedUser[0]);
        }
        private void SortById()
        {
            if (!ifOrderId)
            {
                Record = Record.OrderBy(x => x.RecordShowDto.User_id).ToList();
                ifOrderId = true;
            }
            else
            {
                Record = Record.OrderByDescending(x => x.RecordShowDto.User_id).ToList();
                ifOrderId = false;
            }
        }
        private void LoadRecordList()
        {
            
            List<RecordShowDto> recordShowDtos = dataService.GetRecordShowDtos();
            Record = new List<RecordViewModel>();
            foreach (var recordShowDto in recordShowDtos)
            {

                RecordViewModel recordViewModel = new RecordViewModel();
                recordViewModel.RecordShowDto = recordShowDto;

                this.Record.Add(recordViewModel);
            }
           
        }
        private void SearchRecord()
        {
            
            //this.Record = new List<RecordViewModel>();
            SearchWindow searchWindow = new SearchWindow();
            searchWindow.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            searchWindow.ShowDialog();
            LoadRecordList();

            //Console.WriteLine(ViewModelInfo.recordShowDtoParameter.age);
            if (string.IsNullOrEmpty(ViewModelInfo.recordShowDtoParameter.id)
                && string.IsNullOrEmpty(ViewModelInfo.recordShowDtoParameter.name)
                && string.IsNullOrEmpty(ViewModelInfo.recordShowDtoParameter.idNumber)
                && string.IsNullOrEmpty(ViewModelInfo.recordShowDtoParameter.sex)
                && ViewModelInfo.recordShowDtoParameter.age == 0
                && string.IsNullOrEmpty(ViewModelInfo.recordShowDtoParameter.education)
                && string.IsNullOrEmpty(ViewModelInfo.recordShowDtoParameter.marriage))
            { this.LoadRecordShowDto(); }
            else
            {
               
                this.record = this.record.Where(x =>
               (x.RecordShowDto.User_id.Contains(ViewModelInfo.recordShowDtoParameter.id) || string.IsNullOrEmpty(ViewModelInfo.recordShowDtoParameter.id))
               && (x.RecordShowDto.Name.Contains(ViewModelInfo.recordShowDtoParameter.name) || string.IsNullOrEmpty(ViewModelInfo.recordShowDtoParameter.name))
               && (x.RecordShowDto.IdNumber.Contains(ViewModelInfo.recordShowDtoParameter.idNumber) || string.IsNullOrEmpty(ViewModelInfo.recordShowDtoParameter.idNumber))
               && (x.RecordShowDto.Sex.Contains(ViewModelInfo.recordShowDtoParameter.sex) || string.IsNullOrEmpty(ViewModelInfo.recordShowDtoParameter.sex))
               && (x.RecordShowDto.Age.Equals(ViewModelInfo.recordShowDtoParameter.age) || ViewModelInfo.recordShowDtoParameter.age == 0)
               && (x.RecordShowDto.Education.Contains(ViewModelInfo.recordShowDtoParameter.education) || string.IsNullOrEmpty(ViewModelInfo.recordShowDtoParameter.education))
               && (x.RecordShowDto.Marriage.Contains(ViewModelInfo.recordShowDtoParameter.marriage) || string.IsNullOrEmpty(ViewModelInfo.recordShowDtoParameter.marriage)))
                    .ToList();
                this.Records =new ObservableCollection<RecordViewModel>(record);
            }
            Console.WriteLine(records.Count());
        }
        private void SelectRecord()
        {
            
            this.Count = this.Records.Count(x => x.IsSelected == true);
        }
        private void GetParameter(RecordShowDtoParameter recordShowDtoParameter)
        {
           
        }
       
        

    }
}
