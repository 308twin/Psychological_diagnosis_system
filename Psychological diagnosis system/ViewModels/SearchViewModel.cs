using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using Psychological_diagnosis_system.Entities;
using Psychological_diagnosis_system.Services;
using Psychological_diagnosis_system.Models;
using System.Windows;
using Psychological_diagnosis_system.DtoParameters;

namespace Psychological_diagnosis_system.ViewModels
{
    class SearchViewModel:BindableBase
    {
        static RecordShowDtoParameter recordShowDtoParameter = new RecordShowDtoParameter();

    }
}
