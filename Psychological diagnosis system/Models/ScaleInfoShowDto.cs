using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psychological_diagnosis_system.Models
{
    class ScaleInfoShowDto
    {
        private string name;
        private int quesNum;
        private int selectNum;

        public string Name { get => name; set => name = value; }
        public int QuesNum { get => quesNum; set => quesNum = value; }
        public int SelectNum { get => selectNum; set => selectNum = value; }
    }
}
