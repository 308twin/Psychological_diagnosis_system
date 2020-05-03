using System.Collections;

namespace Psychological_diagnosis_system.Services
{
     class DataConvert
    {
        public static string ScaleNameConvert(string DbName)
        {
            switch (DbName)
            {
                case "self-rating_depression_scale":
                    return "SDSPage.xaml";                    
                case "self-rating_anxiety_scale":
                    return "SASPAGE.xaml";                 
                    
            }
            return null;
        }
        public static int QuizNumConvert(string QuizNum)
        {
            switch(QuizNum)
            {
                case "Button_A":
                    return 1;
                case "Button_B":
                    return 2;
                case "Button_C":
                    return 3;
                case "Button_D":
                    return 4;
            }
            return 0;
        }
        public static string UnSelectConvert(int [] array)
        {
            ArrayList arrList = new ArrayList();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == 0)
                {
                    arrList.Add(i+1);
                }
            }
            var newArray = arrList.ToArray();
           return string.Join("、", newArray);
        }
        public static string ScaleDbNameToScaleName(string DbName)
        {
            switch (DbName)
            {
                case "self-rating_depression_scale":
                    return "SDS抑郁自评量表";
                case "self-rating_anxiety_scale":
                    return "SAS焦虑自评量表";

            }
            return null;
        }
        public static string ScaleNameToAnalysisPageName(string scaleName)
        {
            switch(scaleName)
            {
                case "SAS焦虑自评量表":
                    return "SASAnalysisPage.xaml";
            }
            return null;
        }
    }
}
