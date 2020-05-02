using System.Collections.Generic;
using System.Linq;
using Prism.Mvvm;
using Psychological_diagnosis_system.Services;
using System;
using Psychological_diagnosis_system.ViewModels;
using System.Data;

namespace Psychological_diagnosis_system.Repositories
{
    class RecordRepository
    {
        
        public string SaveRecord()
        {
            pdsEntities pdsEntity = new pdsEntities();
           
            DataTable dt = new DataTable();
            DateTime today = DateTime.Now;
            String todayString = today.ToString("yyyyMMdd");
            string recordTodayLastId = "";
            try
            {
                 recordTodayLastId = pdsEntity.record.Where(x => x.ID.Contains(todayString)).OrderByDescending(x => x.ID).FirstOrDefault().ID;    //根据当天自增长001-999
            }
            catch (NullReferenceException)
            {
                 recordTodayLastId=todayString+"000";
            }
            record newRecord = new record();
            newRecord.GUID = Guid.NewGuid().ToString();
            newRecord.USER_ID = ViewModelInfo.respondentId;
            newRecord.ID = (long.Parse(recordTodayLastId) + 1).ToString();    
            newRecord.TEST_NAME = DataConvert.ScaleDbNameToScaleName(ViewModelInfo.usingScaleDtoParameter.DbName);
            newRecord.DATE = System.DateTime.Now;
            newRecord.TIME = ViewModelInfo.endTime - ViewModelInfo.startTime;
            pdsEntity.record.Add(newRecord);
            pdsEntity.SaveChanges();

            return newRecord.ID;
        }
        public void SaveAnswerCard_SAS(int[] card,string recordID)
        {
            pdsEntities pdsEntity = new pdsEntities();
            int n = 0;
            foreach(var i in card)
            {
                n++;
                sas_answer_card answerCard = new sas_answer_card
                {
                    GUID = Guid.NewGuid().ToString(),
                    RECORD_ID = recordID,
                    QUES_NUM = n,
                    SELECT = i.ToString(),
                    TENDENCY = pdsEntity.self_rating_anxiety_scale.Where(x => x.ID == i).FirstOrDefault().TENDENCY,
                    WEIGHT = GetSASSelectWeight(i)
                };
                pdsEntity.sas_answer_card.Add(answerCard);
            }
            pdsEntity.SaveChanges();

        }
        public void SaveAnswerCard_SDS(int[] card, string recordID)
        {
            pdsEntities pdsEntity = new pdsEntities();
            int n = 0;
            foreach (var i in card)
            {
                n++;
                sds_answer_card answerCard = new sds_answer_card
                {
                    GUID = Guid.NewGuid().ToString(),
                    RECORD_ID = recordID,
                    QUES_NUM = n,
                    SELECT = i.ToString(),
                    TENDENCY = pdsEntity.self_rating_depression_scale.Where(x => x.ID == i).FirstOrDefault().TENDENCY,
                    WEIGHT = GetSASSelectWeight(i)
                };
                pdsEntity.sds_answer_card.Add(answerCard);
            }
            pdsEntity.SaveChanges();

        }
        public int GetSASSelectWeight(int select)
        {
            pdsEntities pdsEntity = new pdsEntities();

            switch (select)
            {
                case 1:
                    return pdsEntity.self_rating_anxiety_scale.Where(x => x.ID == select).FirstOrDefault().A_WEIGHT;
                case 2:
                    return pdsEntity.self_rating_anxiety_scale.Where(x => x.ID == select).FirstOrDefault().B_WEIGHT;
                case 3:
                    return pdsEntity.self_rating_anxiety_scale.Where(x => x.ID == select).FirstOrDefault().C_WEIGHT;
                case 4:
                    return pdsEntity.self_rating_anxiety_scale.Where(x => x.ID == select).FirstOrDefault().D_WEIGHT;
            }
            return 0;
        }

        public int GetSDSSelectWeight(int select)
        {
            pdsEntities pdsEntity = new pdsEntities();

            switch (select)
            {
                case 1:
                    return pdsEntity.self_rating_depression_scale.Where(x => x.ID == select).FirstOrDefault().A_WEIGHT;
                case 2:
                    return pdsEntity.self_rating_depression_scale.Where(x => x.ID == select).FirstOrDefault().B_WEIGHT;
                case 3:
                    return pdsEntity.self_rating_depression_scale.Where(x => x.ID == select).FirstOrDefault().C_WEIGHT;
                case 4:
                    return pdsEntity.self_rating_depression_scale.Where(x => x.ID == select).FirstOrDefault().D_WEIGHT;
            }
            return 0;
        }

        public int GetTwoSelectWeight(int select)
        {
            pdsEntities pdsEntity = new pdsEntities();

            switch (select)
            {
                case 1:
                    return pdsEntity.self_rating_anxiety_scale.Where(x => x.ID == select).FirstOrDefault().A_WEIGHT;
                case 2:
                    return pdsEntity.self_rating_anxiety_scale.Where(x => x.ID == select).FirstOrDefault().B_WEIGHT;               
            }
            return 0;
        }
    }
}
