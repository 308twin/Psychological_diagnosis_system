using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psychological_diagnosis_system.Models
{
    class UserShowDto
    {
        public string User_id { get; set; }
        public string Name { get; set; }
        public string IdNumber { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
        public string Marriage { get; set; }
        public string Education { get; set; }
        public string Address { get; set ; }
        public string Career { get; set; }
    }
}
