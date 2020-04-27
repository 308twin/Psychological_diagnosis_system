using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Psychological_diagnosis_system.Entities;
using Psychological_diagnosis_system.Helpers;

namespace Psychological_diagnosis_system.Repositories
{
    class UserManager
    {
        public IList<User> GetAllUser()    //获得用户表中的所有数据
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var userList = session.QueryOver<User>();
                    transaction.Commit();   //提交操作
                    return userList.List();
                }
            }
        }
        public IList<User> GetUserByUsername(string username)    //根据username查找数据
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var userList = session.QueryOver<User>().Where(user => user.Name == username);
                    transaction.Commit();
                    return userList.List();
                }
            }
        }
        public void SaveUser(User user)   //添加user并保存到数据库,相当于添加数据;
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(user);
                    transaction.Commit();
                }
            }
        }
        public void UpdateUser(User user)   //更新修改后的数据
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Update(user);
                    transaction.Commit();
                }
            }
        }
        public void DeleteById(string id)     //根据ID删除数据;
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    User tu = new User();
                    tu.Id = id;
                    session.Delete(tu);
                    transaction.Commit();
                }
            }
        }
    }
}
