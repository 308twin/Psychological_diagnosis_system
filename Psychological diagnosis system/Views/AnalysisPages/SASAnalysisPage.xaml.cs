using System;
using System.Windows.Controls;
using System.Linq;
using Psychological_diagnosis_system.ViewModels;

namespace Psychological_diagnosis_system.Views.AnalysisPages
{
    /// <summary>
    /// SASAnalysisPage.xaml 的交互逻辑
    /// </summary>
    public partial class SASAnalysisPage : Page
    {
        public SASAnalysisPage()
        {
            InitializeComponent();
            Date_TextBlock.Text = DateTime.Now.ToString("d");
            pdsEntities pds = new pdsEntities();
            var originScore = pds.sas_answer_card.Where(x => x.RECORD_ID == ViewModelInfo.analysisRecrod.Record_id).Sum(x => x.WEIGHT);
            OriginScore_TextBlock.Text = originScore.ToString();

            try
            { StandardScore_TextBlock.Text = ((double)originScore * 1.25).ToString(); }
            catch(ArgumentNullException e)
            {
                throw (e );
            }

            ID_TextBlock.Text = "编 号：" + ViewModelInfo.analysisRecrod.Record_id;
            Name_TextBlock.Text = "姓 名：" + ViewModelInfo.analysisRecrod.Name;
            Sex_TextBlock.Text = "性 别：" + ViewModelInfo.analysisRecrod.Sex;
            Age_TextBlock.Text = "年 龄：" + ViewModelInfo.analysisRecrod.Age;
            Education_TextBlock.Text = "文化程度：" + ViewModelInfo.analysisRecrod.Education;
            Career_TextBlock.Text = "职 业：" + ViewModelInfo.analysisRecrod.Career;
            Marriage_TextBlock.Text = "婚 姻：" + ViewModelInfo.analysisRecrod.Marriage;
            Address_TextBlock.Text = "居住地址：" + ViewModelInfo.analysisRecrod.Address;

            if (int.Parse(StandardScore_TextBlock.Text) < 50)
                Suggestion_TextBlock.Text = "受试者没有焦虑倾向。";
            else if (int.Parse(StandardScore_TextBlock.Text) >= 50 && int.Parse(StandardScore_TextBlock.Text) < 60)
                Suggestion_TextBlock.Text = "受试者有轻度焦虑倾向。";
            else if (int.Parse(StandardScore_TextBlock.Text) >= 60 && int.Parse(StandardScore_TextBlock.Text) < 70)
                Suggestion_TextBlock.Text = "受试者有重度焦虑倾向，请咨询专业医生。";
            else
                Suggestion_TextBlock.Text = "受试者有重度焦虑倾向，请尽快咨询专业医生获取专业建议。";
        }
    }
}
