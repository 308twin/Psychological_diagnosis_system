using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Psychological_diagnosis_system.Entities;
namespace Psychological_diagnosis_system.Models
{
    public class RecordShowDto
    {

        private string record_id;
        private string user_id;       
        private string name;         
        private string idNumber;
        private string sex;
        private int age;
        private string marriage;
        private string education;
        private string address;
        private string item;
        private string career;
        private DateTime inputDate;
        private TimeSpan answerTime;

        public string Record_id { get => record_id; set => record_id = value; }
        public string User_id { get => user_id; set => user_id = value; }
        public string Name { get => name; set => name = value; }
        public string IdNumber { get => idNumber; set => idNumber = value; }
        public string Sex { get => sex; set => sex = value; }
        public int Age { get => age; set => age = value; }
        public string Marriage { get => marriage; set => marriage = value; }
        public string Education { get => education; set => education = value; }
        public string Address { get => address; set => address = value; }
        public string Item { get => item; set => item = value; }
        public DateTime InputDate { get => inputDate; set => inputDate = value; }
        public TimeSpan AnswerTime { get => answerTime; set => answerTime = value; }
        public string Career { get => career; set => career = value; }
    }
}
