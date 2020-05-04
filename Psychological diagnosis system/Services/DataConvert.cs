using System.Collections;

namespace Psychological_diagnosis_system.Services
{
     class DataConvert
    {
        //每个量表对应的测试页面,数据库名字到页面名字的映射，在scale_info中
        public static string ScaleNameConvert(string DbName)
        {
            switch (DbName)
            {
                case "self-rating_depression_scale":
                    return "SDSPage.xaml";                    
                case "self-rating_anxiety_scale":
                    return "SASPage.xaml";
                case "scl90_scale":
                    return "SCL90Page.xaml";
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
                case "Button_E":
                    return 5;
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
        //每个量表都需要对应
        public static string ScaleDbNameToScaleName(string DbName)
        {
            switch (DbName)
            {
                case "self-rating_depression_scale":
                    return "SDS抑郁自评量表";
                case "self-rating_anxiety_scale":
                    return "SAS焦虑自评量表";
                case "scl90_scale":
                    return "SCL90症状自评量表";
            }
            return null;
        }
        //每个量表都需要对应
        public static string ScaleNameToAnalysisPageName(string scaleName)
        {
            switch(scaleName)
            {
                case "SAS焦虑自评量表":
                    return "SASAnalysisPage.xaml";
                case "SDS抑郁自评量表":
                    return "SDSAnalysisPage.xaml";
                case "SCL90症状自评量表":
                    return "SCL90AnalysisPage.xaml";
            }
            return null;
        }

        public static string SCL90_ScoreToLevel(string score)
        {
            double level = double.Parse(score);
            if (level < 2)
                return "无";
            else if (level < 3)
                return "轻度";
            else if (level < 4)
                return "中度";
            else
                return "重度";

        }

        public static int SCL90_ScoreToCoordinate(string stringScore)
        {
            double score = double.Parse(stringScore);
            int coordinate=83;
            coordinate = (int)(100 - (17 * score));
            return coordinate;
        }

    }
}
