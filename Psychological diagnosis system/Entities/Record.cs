using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psychological_diagnosis_system.Entities
{
    class Record
    {
        Guid guid;
        private string id;
        private string userId;
        private string testName;
        private DateTime date;
        private DateTime time;

        public Guid Guid { get => guid; set => guid = value; }
        public string Id { get => id; set => id = value; }
        public string UserId { get => userId; set => userId = value; }
        public string TestName { get => testName; set => testName = value; }
        public DateTime Date { get => date; set => date = value; }
        public DateTime Time { get => time; set => time = value; }
    }
}
