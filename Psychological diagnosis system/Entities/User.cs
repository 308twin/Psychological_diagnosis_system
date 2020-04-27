using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psychological_diagnosis_system.Entities
{
    class User
    {
        private Guid guid;
        private string id;
        private string name;
        private DateTime inputDate;
        private string province;
        private string city;
        private string district;
        private string detailAddress;
        private string idNumber;
        private Sex sex;
        private int age;
        private Marriage marriage;
        private Education education;

        public Guid Guid { get => guid; set => guid = value; }
        public string Id { get => id; set => id = value; }
        public DateTime InputDate { get => inputDate; set => inputDate = value; }
        public string Province { get => province; set => province = value; }
        public string City { get => city; set => city = value; }
        public string District { get => district; set => district = value; }
        public string DetailAddress { get => detailAddress; set => detailAddress = value; }
        public string IdNumber { get => idNumber; set => idNumber = value; }
        public Sex Sex { get => sex; set => sex = value; }
        public int Age { get => age; set => age = value; }
        public Marriage Marriage { get => marriage; set => marriage = value; }
        public string Name { get => name; set => name = value; }
        internal Education Education { get => education; set => education = value; }
    }
}
