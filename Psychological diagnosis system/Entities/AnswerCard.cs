using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psychological_diagnosis_system.Entities
{
    class AnswerCard
    {
        private Guid guid;
        private string id;
        private string recordId;
        private int quesNum;
        private char select;
        private string trendency;
        private int weight;

        public int Weight { get => weight; set => weight = value; }
        public Guid Guid { get => guid; set => guid = value; }
        public string Id { get => id; set => id = value; }
        public string RecordId { get => recordId; set => recordId = value; }
        public int QuesNum { get => quesNum; set => quesNum = value; }
        public char Select { get => select; set => select = value; }
        public string Trendency { get => trendency; set => trendency = value; }
    }
}
