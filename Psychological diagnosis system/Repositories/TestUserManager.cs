using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Psychological_diagnosis_system.Entities;
using Psychological_diagnosis_system.Helpers;

namespace Psychological_diagnosis_system.Repositories
{
    class TestUserManager
    {
        public IList<TestUser> GetAllUser()

        {

            using (var session = NHibernateHelper.OpenSession())

            {

                using (var transaction = session.BeginTransaction())

                {

                    var userList = session.QueryOver<TestUser>();

                    transaction.Commit();

                    return userList.List();

                }

            }

        }
    }
}
