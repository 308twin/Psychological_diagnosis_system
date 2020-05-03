using System;
using Psychological_diagnosis_system.DtoParameters;
using Psychological_diagnosis_system.Models;
namespace Psychological_diagnosis_system.ViewModels
{
    class ViewModelInfo
    {
        //信息交互DTO，VM和V在此进行信息传递。
        public static RecordShowDtoParameter recordShowDtoParameter ;   //当前选择记录参数
        public static UserShowDtoParameter userShowDtoParameter;        //当前用户参数，在查询用
        public static UsingScaleDtoParameter usingScaleDtoParameter;    //当前量表参数
        public static string respondentId;  //当前测试者ID
        public static DateTime startTime;   //测试者答题开始时间
        public static DateTime endTime;     //结束时间
        public static RecordShowDto analysisRecrod;
    }
}
