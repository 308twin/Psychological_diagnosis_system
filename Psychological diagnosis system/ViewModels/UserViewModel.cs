﻿using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Commands;
using Prism.Mvvm;
using Psychological_diagnosis_system.Services;
using Psychological_diagnosis_system.Models;
using Psychological_diagnosis_system.DtoParameters;
using System.Collections.ObjectModel;
using Psychological_diagnosis_system.Views;
using Psychological_diagnosis_system.Repositories;
using System.Windows;

namespace Psychological_diagnosis_system.ViewModels
{

    class UserViewModel: BindableBase
    {
        #region 数据成员
        static readonly pdsEntities pds = new pdsEntities();

        DataService dataService = new DataService(pds);
        public DelegateCommand SelectRecordCommand { get; set; }
        public DelegateCommand DeleteRecordCommand { get; set; }
        public DelegateCommand DeleteUserCommand { get; set; }
        public DelegateCommand SearchUserCommand { get; set; }
        public DelegateCommand AddUserCommand { get; set; }


        private UserShowDtoParameter userShowDtoParameter;
        private List<UserGridViewModel> userList;
        private ObservableCollection<UserGridViewModel> userObserv;
        #endregion

        #region 属性
        public List<UserGridViewModel> UserList
        {
            get { return userList; }
            set
            {
                userList = value;
                this.RaisePropertyChanged("UserList");
            }
        }

        public ObservableCollection<UserGridViewModel> UserObserv
        {
            get { return userObserv; }
            set
            {
                userObserv = value;
                this.RaisePropertyChanged("UserObserv");
            }
        }
        public UserShowDtoParameter UserShowDtoParameter
        {
            get { return userShowDtoParameter; }
            set
            {
                userShowDtoParameter = value;
                this.RaisePropertyChanged("UserShowDtoParameter");
            }

        }
        #endregion

        #region 构造函数
        public UserViewModel()
        {
            LoadUserShowDto();
            SearchUserCommand = new DelegateCommand(new Action(SearchUser));
            AddUserCommand = new DelegateCommand(new Action(AddUser));
            DeleteUserCommand = new DelegateCommand(new Action(DeleteUser));
        }
        #endregion

        #region 方法
        private void LoadUserShowDto()
        {
            UserObserv = new ObservableCollection<UserGridViewModel>();
            List<UserShowDto> userShowDtos = dataService.GetUserShowDtos();
            foreach(var userShowDto in userShowDtos)
            {
                UserGridViewModel userGridViewModel = new UserGridViewModel();
                userGridViewModel.UserShowDto = userShowDto;

                UserObserv.Add(userGridViewModel);
            }
            UserList = new List<UserGridViewModel>(UserObserv);
        }
        //读取List，之后要转换为OberservCollection，不必关心内部实现
        private void LoadUserList()
        {
            List<UserShowDto> userShowDtos = dataService.GetUserShowDtos();
            UserList = new List<UserGridViewModel>();
            foreach (var userShowDto in userShowDtos)
            {
                UserGridViewModel userGridViewModel = new UserGridViewModel();
                userGridViewModel.UserShowDto = userShowDto;

                UserList.Add(userGridViewModel);
            }
        }
        private void SearchUser()
        {
            Console.WriteLine(ViewModelInfo.userShowDtoParameter.idNumber);
            if (string.IsNullOrEmpty(ViewModelInfo.userShowDtoParameter.id)
                && string.IsNullOrEmpty(ViewModelInfo.userShowDtoParameter.name)
                && string.IsNullOrEmpty(ViewModelInfo.userShowDtoParameter.idNumber)
                && string.IsNullOrEmpty(ViewModelInfo.userShowDtoParameter.sex)
                && ViewModelInfo.userShowDtoParameter.age == 0
                && string.IsNullOrEmpty(ViewModelInfo.userShowDtoParameter.education)
                && string.IsNullOrEmpty(ViewModelInfo.userShowDtoParameter.marriage))
            { this.LoadUserShowDto(); }
            else
            {
                LoadUserList();
                //UserList = UserList.Where(x =>
                //(x.UserShowDto.Sex.Contains(ViewModelInfo.userShowDtoParameter.sex) || string.IsNullOrEmpty(ViewModelInfo.userShowDtoParameter.sex)))
                //.ToList();

                Console.WriteLine(UserObserv.Count() + " " + UserList.Count());
                this.UserList = this.UserList.Where(x =>
               (x.UserShowDto.User_id.Contains(ViewModelInfo.userShowDtoParameter.id) || string.IsNullOrEmpty(ViewModelInfo.userShowDtoParameter.id))
               && (x.UserShowDto.Name.Contains(ViewModelInfo.userShowDtoParameter.name) || string.IsNullOrEmpty(ViewModelInfo.userShowDtoParameter.name))
               && (x.UserShowDto.IdNumber.Contains(ViewModelInfo.userShowDtoParameter.idNumber) || string.IsNullOrEmpty(ViewModelInfo.userShowDtoParameter.idNumber))
               && (x.UserShowDto.Sex.Contains(ViewModelInfo.userShowDtoParameter.sex) || string.IsNullOrEmpty(ViewModelInfo.userShowDtoParameter.sex))
               && (x.UserShowDto.Age.Equals(ViewModelInfo.userShowDtoParameter.age) || ViewModelInfo.userShowDtoParameter.age == 0)
               && (x.UserShowDto.Education.Contains(ViewModelInfo.userShowDtoParameter.education) || string.IsNullOrEmpty(ViewModelInfo.userShowDtoParameter.education))
               && (x.UserShowDto.Marriage.Contains(ViewModelInfo.userShowDtoParameter.marriage) || string.IsNullOrEmpty(ViewModelInfo.userShowDtoParameter.marriage))
                    ).ToList();
                this.UserObserv = new ObservableCollection<UserGridViewModel>(UserList);
            }
            ViewModelInfo.userShowDtoParameter = new UserShowDtoParameter()
            {
                id = "",
                name = "",
                age = 0,
                idNumber = "",
                sex = "",
                education = "",
                marriage = ""
            };
            Console.WriteLine(UserObserv.Count()+" "+UserList.Count());
        }

        private void AddUser()
        {
            AddUserWindows addUserWindows = new AddUserWindows();
            addUserWindows.ShowDialog();
            LoadUserShowDto();
        }
        private void DeleteUser()
        {
            foreach(var user in UserObserv)
            {
                if (user.IsSelected == true)
                {
                    UserRepository userRepository = new UserRepository();
                    userRepository.DeleteUser(user.UserShowDto.User_id);
                }
                   
            }
            LoadUserShowDto();
            MessageBox.Show("用户删除完毕！主窗口请重新查询记录");
        }
        #endregion

    }
}
