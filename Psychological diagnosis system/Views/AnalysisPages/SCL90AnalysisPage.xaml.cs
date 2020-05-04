using System;
using System.Windows.Controls;
using System.Linq;
using Psychological_diagnosis_system.ViewModels;
using Psychological_diagnosis_system.Services;

namespace Psychological_diagnosis_system.Views.AnalysisPages
{
    /// <summary>
    /// SCL90AnalysisPage.xaml 的交互逻辑
    /// </summary>
    public partial class SCL90AnalysisPage : Page
    {
        public SCL90AnalysisPage()
        {
            InitializeComponent();
            InitializeComponent();
            Date_TextBlock.Text = DateTime.Now.ToString("d");
            pdsEntities pds = new pdsEntities();

            //这边的是从答题记录导过来的，通用的，可以复用
            ID_TextBlock.Text = "编 号：" + ViewModelInfo.analysisRecrod.Record_id;
            Name_TextBlock.Text = "姓 名：" + ViewModelInfo.analysisRecrod.Name;
            Sex_TextBlock.Text = "性 别：" + ViewModelInfo.analysisRecrod.Sex;
            Age_TextBlock.Text = "年 龄：" + ViewModelInfo.analysisRecrod.Age;
            Education_TextBlock.Text = "文化程度：" + ViewModelInfo.analysisRecrod.Education;
            Career_TextBlock.Text = "职 业：" + ViewModelInfo.analysisRecrod.Career;
            Marriage_TextBlock.Text = "婚 姻：" + ViewModelInfo.analysisRecrod.Marriage;
            Address_TextBlock.Text = "居住地址：" + ViewModelInfo.analysisRecrod.Address;

            //无法复用
            //对于TextBlock.Text的填充
            var answerCard = pds.scl90_answer_card.Where(x => x.RECORD_ID == ViewModelInfo.analysisRecrod.Record_id);
            Sum_Score.Text = answerCard.Sum(x => x.WEIGHT).ToString();
            Symptom_Index.Text = (answerCard.Sum(x => x.WEIGHT) / 90).ToString();
            Positive_Count.Text = answerCard.Count(x => x.WEIGHT > 1).ToString();
            Positive_Averange_Score.Text = answerCard.Where(x => x.WEIGHT > 1).Average(x => x.WEIGHT).ToString("0.00");
            //以下是分值
            Somatization_Score.Text = answerCard.Where(x => x.TENDENCY=="躯体化").Average(x => x.WEIGHT).ToString("0.00");
            ObsessiveCompulsive_Score.Text = answerCard.Where(x => x.TENDENCY == "强迫症状").Average(x => x.WEIGHT).ToString("0.00");
            InterpersonalSensitivity_Score.Text = answerCard.Where(x => x.TENDENCY == "人际关系敏感").Average(x => x.WEIGHT).ToString("0.00");
            Depression_Score.Text = answerCard.Where(x => x.TENDENCY == "抑郁").Average(x => x.WEIGHT).ToString("0.00");
            Anxiety_Score.Text = answerCard.Where(x => x.TENDENCY == "焦虑").Average(x => x.WEIGHT).ToString("0.00");
            
            Hostility_Score.Text = answerCard.Where(x => x.TENDENCY == "敌对").Average(x => x.WEIGHT).ToString("0.00"); ;
            PhoticAnxiety_Score.Text = answerCard.Where(x => x.TENDENCY == "恐怖").Average(x => x.WEIGHT).ToString("0.00");
            ParanoidIdeation_Score.Text = answerCard.Where(x => x.TENDENCY == "偏执").Average(x => x.WEIGHT).ToString("0.00");
            Psychoticism_Score.Text = answerCard.Where(x => x.TENDENCY == "精神病性").Average(x => x.WEIGHT).ToString("0.00");
            Other_Score.Text = answerCard.Where(x => x.TENDENCY == "附加项目").Average(x => x.WEIGHT).ToString("0.00");

            //以下是程度
            Somatization_Level.Text = DataConvert.SCL90_ScoreToLevel(Somatization_Score.Text);
            ObsessiveCompulsive_Level.Text = DataConvert.SCL90_ScoreToLevel(ObsessiveCompulsive_Score.Text);
            InterpersonalSensitivity_Level.Text = DataConvert.SCL90_ScoreToLevel(InterpersonalSensitivity_Score.Text);
            Depression_Level.Text = DataConvert.SCL90_ScoreToLevel(Depression_Score.Text);
            Anxiety_Level.Text = DataConvert.SCL90_ScoreToLevel(Anxiety_Score.Text);
            Hostility_Level.Text = DataConvert.SCL90_ScoreToLevel(Hostility_Score.Text);
            PhoticAnxiety_Level.Text = DataConvert.SCL90_ScoreToLevel(PhoticAnxiety_Score.Text);
            ParanoidIdeation_Level.Text = DataConvert.SCL90_ScoreToLevel(ParanoidIdeation_Score.Text);
            Psychoticism_Level.Text = DataConvert.SCL90_ScoreToLevel(Psychoticism_Score.Text);
            Other_Level.Text = DataConvert.SCL90_ScoreToLevel(Other_Score.Text);

            //以下是绘图
            First_Line.Y1 = DataConvert.SCL90_ScoreToCoordinate(Somatization_Score.Text);
            Second_Line.Y1 = DataConvert.SCL90_ScoreToCoordinate(ObsessiveCompulsive_Score.Text);
            Third_Line.Y1 = DataConvert.SCL90_ScoreToCoordinate(InterpersonalSensitivity_Score.Text);
            Fourth_Line.Y1 = DataConvert.SCL90_ScoreToCoordinate(Depression_Score.Text);
            Fifth_Line . Y1 = DataConvert.SCL90_ScoreToCoordinate(Anxiety_Score.Text);
            Six_Line.Y1 = DataConvert.SCL90_ScoreToCoordinate(Hostility_Score.Text); 
            Eigth_Line.Y1 = DataConvert.SCL90_ScoreToCoordinate(PhoticAnxiety_Score.Text);
            Nineth_Line.Y1 = DataConvert.SCL90_ScoreToCoordinate(Psychoticism_Score.Text);
            Nineth_Line.Y2 = DataConvert.SCL90_ScoreToCoordinate(Other_Score.Text);

            //以下是建议部分
            string suggestion="";


            if (double.Parse(Somatization_Score.Text) >= 2)
                suggestion += "存在" + Somatization_Level.Text + "心血管、胃肠道、呼吸和其他系统的主诉不适，和头痛、背痛、肌肉酸痛，以及焦虑的其他躯体表现。\r\n\r\n";

            if (double.Parse(ObsessiveCompulsive_Score.Text) >= 2)            
                suggestion += "存在"+ ObsessiveCompulsive_Level.Text + "明知没有必要，但又无法摆脱的无意义的思想、冲动和行为，还有一些比较一般的认知障碍的行为征象。\r\n\r\n";

            if (double.Parse(InterpersonalSensitivity_Score.Text) >= 2)
                suggestion += "存在" + InterpersonalSensitivity_Level.Text + "不自在与自卑感，特别是与其他人相比较时更加突出。在人际交往中的自卑感，心神不安，明显不自在，以及人际交流中的自我意识，消极的期待亦是这方面症状的典型原因。\r\n\r\n";

            if (double.Parse(InterpersonalSensitivity_Score.Text) >= 2)
                suggestion += "存在" + Depression_Level.Text + "苦闷的情感与心境，以生活兴趣的减退，动力缺乏，活力丧失等为特征，以反映失望，悲观以及与抑郁相联系的认知和躯体方面的感受。另外，还包括有关死亡的思想和自杀观念。\r\n\r\n";

            if (double.Parse(InterpersonalSensitivity_Score.Text) >= 2)
                suggestion += "存在" + Anxiety_Level.Text + "烦燥，坐立不安，神经过敏，紧张以及由此产生的躯体征象，如震颤等。\r\n\r\n";

            if (double.Parse(InterpersonalSensitivity_Score.Text) >= 2)
                suggestion += "存在" + Hostility_Level.Text + "厌烦的感觉，摔物，争论直到不可控制的脾气暴发。\r\n\r\n";

            if (double.Parse(InterpersonalSensitivity_Score.Text) >= 2)
                suggestion += "存在" + PhoticAnxiety_Level.Text + "恐怖。恐惧的对象包括出门旅行，空旷场地，人群，或公共场所和交通工具。此外，还有反映社交恐怖的一些项目。\r\n\r\n";

            if (double.Parse(InterpersonalSensitivity_Score.Text) >= 2)
                suggestion += "存在" + ParanoidIdeation_Level.Text + "敌对，猜疑，关系观念，妄想，被动体验和夸大等。\r\n\r\n";

            if (double.Parse(InterpersonalSensitivity_Score.Text) >= 2)
                suggestion += "存在" + Psychoticism_Level.Text + "无法信任别人，怀疑别人要阴谋，认为受到监视，被人跟踪，会采取逃避的行为，或者紧张。\r\n\r\n";

            if (double.Parse(InterpersonalSensitivity_Score.Text) >= 2)
                suggestion += "存在" + Other_Level.Text + "想象死亡，早醒，难以入睡等迹象。\r\n\r\n";

            Suggestion_TextBlock.Text = suggestion;

        }
    }
}
