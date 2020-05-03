using System;
using Prism.Commands;
using Prism.Mvvm;
using Psychological_diagnosis_system.Models;
using System.Windows;
using Psychological_diagnosis_system.Repositories;
using System.Linq;
namespace Psychological_diagnosis_system.ViewModels
{
    class AddUserViewModel:BindableBase
    {
        public Action CloseFormAction { get; set; }
        private user_info newUser;
        public DelegateCommand AddUserCommand { get; set; } //注意这里是public，不然会委托失败，导致无法使用AddUser方法。
        public user_info NewUser
        {
            get
            {
                return this.newUser;
            }
            set
            {
                this.newUser = value;
                this.RaisePropertyChanged("user_info");
            }
        }

        public  AddUserViewModel()
        {
            newUser = new user_info
            {
                AGE = 0
            };
            AddUserCommand = new DelegateCommand(new Action(AddUser));
        }
        public void AddUser()
        {
            UserRepository userRepository = new UserRepository();
            bool canAdd = true;
            if (string.IsNullOrEmpty(NewUser.NAME) ||
                string.IsNullOrEmpty(NewUser.PROVINCE) ||
                string.IsNullOrEmpty(NewUser.CITY) ||
                string.IsNullOrEmpty(NewUser.DISTRICT_TOWN) ||
                string.IsNullOrEmpty(NewUser.EDUCATION) ||
                string.IsNullOrEmpty(NewUser.ID_NUMBER) ||
                string.IsNullOrEmpty(NewUser.SEX) ||
                string.IsNullOrEmpty(NewUser.MARRIAGE) ||
                string.IsNullOrEmpty(NewUser.EDUCATION) ||
                string.IsNullOrEmpty(NewUser.CAREER))
            {
                canAdd = false;
                MessageBox.Show("请填写完整个人信息");
            }
            if (canAdd == true)
            {
                userRepository.AddUser(NewUser);
                MessageBox.Show("添加成功");
                this.CloseFormAction();
            }
        }
        
    }
}
