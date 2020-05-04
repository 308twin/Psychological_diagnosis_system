using System;
using System.Windows.Controls;
using System.Linq;
using Psychological_diagnosis_system.ViewModels;

namespace Psychological_diagnosis_system.Views.AnalysisPages
{
    /// <summary>
    /// SDSAnalysisPage.xaml 的交互逻辑
    /// </summary>
    public partial class SDSAnalysisPage : Page
    {
        public SDSAnalysisPage()
        {
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

            //从这里开始是具体数据分析，每个量表不可复用
            var originScore = pds.sds_answer_card.Where(x => x.RECORD_ID == ViewModelInfo.analysisRecrod.Record_id).Sum(x => x.WEIGHT);
            OriginScore_TextBlock.Text = originScore.ToString();

            try
            { StandardScore_TextBlock.Text = ((double)originScore * 1.25).ToString(); }
            catch (ArgumentNullException e)
            {
                throw (e);
            }

            double standardScore = double.Parse(StandardScore_TextBlock.Text);
            if (standardScore < 50)
                Suggestion_TextBlock.Text = "受试者没有抑郁倾向。";
            else if (standardScore >= 50 && standardScore < 60)
                Suggestion_TextBlock.Text = "受试者有轻度焦虑倾向。";
            else if (standardScore >= 60 && standardScore < 70)
                Suggestion_TextBlock.Text = "受试者有中度抑郁倾向，请咨询专业医生。";
            else
                Suggestion_TextBlock.Text = "受试者有重度抑郁倾向，请尽快咨询专业医生获取专业建议。";
        }
    }
}
