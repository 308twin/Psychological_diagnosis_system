using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Psychological_diagnosis_system.Entities;
using Psychological_diagnosis_system.Models;
namespace Psychological_diagnosis_system.Services
{
    interface IDataService
    {
        //List<User> GetUsers();
        List<RecordShowDto> GetRecordShowDtos();
    }
}
