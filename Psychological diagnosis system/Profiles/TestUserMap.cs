using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Psychological_diagnosis_system.Entities;

namespace Psychological_diagnosis_system.Profiles
{
    class TestUserMap:ClassMap<TestUser>
    {
       public TestUserMap()
        {
            Id(x => x.ID).Column("id");

            Map(x => x.Name).Column("name");            

            Map(x => x.Age).Column("age");

            Table("user_test");
        }
    }
}
