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
        public void SaveAnswerCard_SCL90(int[] card, string recordID)
        {
            pdsEntities pdsEntity = new pdsEntities();
            int n = 0;
            foreach (var i in card)
            {
                n++;
                scl90_answer_card answerCard = new scl90_answer_card
                {
                    GUID = Guid.NewGuid().ToString(),
                    RECORD_ID = recordID,
                    QUES_NUM = n,
                    SELECT = i.ToString(),
                    TENDENCY = pdsEntity.scl90_scale.Where(x => x.ID == n).FirstOrDefault().TENDENCY,   //复用这里也需要修改,这里n用成了i出了bug
                    WEIGHT = GetSASSelectWeight(i)
                };
                pdsEntity.scl90_answer_card.Add(answerCard);
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

        public void DeleteUserAllRecord(string userID)
        {
            pdsEntities pds = new pdsEntities();
            var record = pds.record.FirstOrDefault(x => x.USER_ID == userID);
            //先删除答题卡，然后删除答题记录
            //由于每个答题卡是一个表，所以每次都要写
            if(record.TEST_NAME== "SAS焦虑自评量表")
            {
                var answer = pds.sas_answer_card.Where(x => x.RECORD_ID == record.ID);
                foreach(var i in answer)
                {
                    pds.sas_answer_card.Remove(i);
                }
            }
            if (record.TEST_NAME == "SDS抑郁自评量表")
            {
                var answer = pds.sds_answer_card.Where(x => x.RECORD_ID == record.ID);
                foreach (var i in answer)
                {
                    pds.sds_answer_card.Remove(i);
                }
            }
            if (record.TEST_NAME == "UPI大学生人格健康调查表")
            {
                var answer = pds.upi_answer_card.Where(x => x.RECORD_ID == record.ID);
                foreach (var i in answer)
                {
                    pds.upi_answer_card.Remove(i);
                }
            }
            if (record.TEST_NAME == "SCL90症状自评量表")
            {
                var answer = pds.scl90_answer_card.Where(x => x.RECORD_ID == record.ID);
                foreach (var i in answer)
                {
                    pds.scl90_answer_card.Remove(i);
                }
            }
            pds.record.Remove(record);
            pds.SaveChanges();
        }

        public void DeleteRecord(string recordID)
        {
            pdsEntities pds = new pdsEntities();
            var record = pds.record.FirstOrDefault(x => x.ID == recordID);
            if (record.TEST_NAME == "SAS焦虑自评量表")
            {
                var answer = pds.sas_answer_card.Where(x => x.RECORD_ID == record.ID);
                foreach (var i in answer)
                {
                    pds.sas_answer_card.Remove(i);
                    Console.WriteLine("已删除"+i.GUID);
                }
            }
            if (record.TEST_NAME == "SDS抑郁自评量表")
            {
                var answer = pds.sds_answer_card.Where(x => x.RECORD_ID == record.ID);
                foreach (var i in answer)
                {
                    pds.sds_answer_card.Remove(i);
                    Console.WriteLine("已删除" + i.GUID);
                }
            }
            if (record.TEST_NAME == "UPI大学生人格健康调查表")
            {
                var answer = pds.upi_answer_card.Where(x => x.RECORD_ID == record.ID);
                foreach (var i in answer)
                {
                    pds.upi_answer_card.Remove(i);
                    Console.WriteLine("已删除" + i.GUID);
                }
            }
            if (record.TEST_NAME == "SCL90症状自评量表")
            {
                var answer = pds.scl90_answer_card.Where(x => x.RECORD_ID == record.ID);
                foreach (var i in answer)
                {
                    pds.scl90_answer_card.Remove(i);
                    Console.WriteLine("已删除" + i.GUID);
                }
            }
            pds.record.Remove(record);
            pds.SaveChanges();
        }
       
    }
}
