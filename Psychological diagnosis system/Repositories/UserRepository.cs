using System.Collections.Generic;
using System.Linq;
using Prism.Mvvm;
using Psychological_diagnosis_system.Services;
using System;
using Psychological_diagnosis_system.ViewModels;
using System.Data;
using Psychological_diagnosis_system.Models;

namespace Psychological_diagnosis_system.Repositories
{
    class UserRepository
    {
        public void AddUser(user_info newUser)
        {
            pdsEntities pds = new pdsEntities();

            newUser.USER_GUID = Guid.NewGuid().ToString();
            newUser.ID = (long.Parse(pds.user_info.OrderByDescending(x => x.ID).FirstOrDefault().ID) + 1).ToString();
            newUser.INPUT_DATE = DateTime.Now;
            pds.user_info.Add(newUser);
            pds.SaveChanges();

            //user_info user_Info = new user_info
            //{
            //    USER_GUID = Guid.NewGuid().ToString(),
            //    ID = (long.Parse(pds.user_info.OrderByDescending(x => x.ID).FirstOrDefault().ID) + 1).ToString(),
            //    NAME = newUser.NAME,
            //    INPUT_DATE = DateTime.Now,
            //    PROVINCE = newUser.PROVINCE,
            //    CITY = newUser.CITY,
            //    DISTRICT_TOWN = newUser.DISTRICT_TOWN,
            //    DETAIL_ADDRESS = newUser.DETAIL_ADDRESS,
            //    ID_NUMBER = newUser.ID_NUMBER,
            //    SEX = newUser.SEX,
            //    AGE = newUser.AGE

            //};
        }
        public void DeleteUser(string ID)
        {
            RecordRepository recordRepository = new RecordRepository();
            pdsEntities pds = new pdsEntities();
            var user = pds.user_info.FirstOrDefault(x => x.ID == ID);
            pds.user_info.Remove(user);
            recordRepository.DeleteUserAllRecord(ID);
            pds.SaveChanges();
           
        }
    }
}
