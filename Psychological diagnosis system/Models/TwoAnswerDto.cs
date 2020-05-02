using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psychological_diagnosis_system.Models
{
    class TwoAnswerDto
    {
        public int ID { get; set; }
        public int AWeight { get; set; }
        public int BWeight { get; set; }
        public int CWeight { get; set; }
        public int DWeight { get; set; }
        public string AContent { get; set; }
        public string BContent { get; set; }
        public string CContent { get; set; }
        public string DContent { get; set; }
    }
}
