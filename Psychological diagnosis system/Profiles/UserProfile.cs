using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Psychological_diagnosis_system.Entities;
using FluentNHibernate.Mapping;


namespace Psychological_diagnosis_system.Profiles
{
    class UserProfile : ClassMap<User>
    {
        public UserProfile()
        {
            Id(x => x.Id).Column("ID");
            Map(x => x.Name).Column("NAME");
            Table("user_info");

        }
            
    }
}
