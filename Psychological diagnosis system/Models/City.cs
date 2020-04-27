using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psychological_diagnosis_system.Models
{
    public class City : CodeView
    {
        public List<County> Child { get; set; }
    }
}
