using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Psychological_diagnosis_system.Models;
using Psychological_diagnosis_system.Entities;
using MySql.Data.MySqlClient;

namespace Psychological_diagnosis_system.Services
{
    
    class DataService:IDataService
    {
        private readonly pdsEntities _pdsEntity;

        public DataService(pdsEntities pdsEntities)
        {
            _pdsEntity = pdsEntities;
        }
        public List<RecordShowDto> GetRecordShowDtos()
        {
           
            List<RecordShowDto> recordShowDtos = new List<RecordShowDto>();
            List<record> records = _pdsEntity.record.ToList();
            foreach(var record in records)
            {
                RecordShowDto recordShow = new RecordShowDto();

                recordShow.Record_id = record.ID;                
                recordShow.User_id = record.USER_ID;
                recordShow.Name = _pdsEntity.user_info.FirstOrDefault(x => x.ID == record.USER_ID).NAME;
                recordShow.IdNumber = _pdsEntity.user_info.FirstOrDefault(x => x.ID == record.USER_ID).ID_NUMBER;
                recordShow.Sex = _pdsEntity.user_info.FirstOrDefault(x => x.ID == record.USER_ID).SEX;
                recordShow.Age = _pdsEntity.user_info.FirstOrDefault(x => x.ID == record.USER_ID).AGE ;
                recordShow.Career = _pdsEntity.user_info.FirstOrDefault(x => x.ID == record.USER_ID).CAREER;
                recordShow.Marriage = _pdsEntity.user_info.FirstOrDefault(x => x.ID == record.USER_ID).MARRIAGE;
                recordShow.Education = _pdsEntity.user_info.FirstOrDefault(x => x.ID == record.USER_ID).EDUCATION;
                recordShow.Address = _pdsEntity.user_info.FirstOrDefault(x => x.ID == record.USER_ID).PROVINCE.ToString()
                    + _pdsEntity.user_info.FirstOrDefault(x => x.ID == record.USER_ID).CITY.ToString()
                    + _pdsEntity.user_info.FirstOrDefault(x => x.ID == record.USER_ID).DISTRICT_TOWN.ToString()
                    + _pdsEntity.user_info.FirstOrDefault(x => x.ID == record.USER_ID).DETAIL_ADDRESS.ToString();
                recordShow.Item = record.TEST_NAME;
                recordShow.InputDate = record.DATE;
                recordShow.AnswerTime = record.TIME;
                recordShowDtos.Add(recordShow);
            }
            return recordShowDtos;

        }
        public List<UserShowDto> GetUserShowDtos()
        {
            List<UserShowDto> userShowDtos = new List<UserShowDto>();
            List<user_info> user_Infos = _pdsEntity.user_info.ToList();

            foreach(var user_info in user_Infos)
            {
                UserShowDto userShowDto = new UserShowDto();

                userShowDto.User_id = user_info.ID;
                userShowDto.Name = user_info.NAME;
                userShowDto.IdNumber = user_info.ID_NUMBER;
                userShowDto.Sex = user_info.SEX;
                userShowDto.Age = user_info.AGE;
                userShowDto.Marriage = user_info.MARRIAGE;
                userShowDto.Education = user_info.EDUCATION;
                userShowDto.Address = user_info.PROVINCE.ToString()
                    + user_info.CITY.ToString() + user_info.DISTRICT_TOWN.ToString() + user_info.DETAIL_ADDRESS.ToString();
                userShowDto.Career = user_info.CAREER;

                userShowDtos.Add(userShowDto);

                
            }
            return userShowDtos;
        }
          
        public List<ScaleInfoShowDto> GetScaleInfoShowDtos()
        {
            List<scale_info> scale_Infos = new List<scale_info>();
            List<ScaleInfoShowDto> scaleInfoShowDtos = new List<ScaleInfoShowDto>();
            scale_Infos = _pdsEntity.scale_info.ToList();

            foreach(var scale_info in scale_Infos)
            {
                ScaleInfoShowDto scaleInfoShowDto = new ScaleInfoShowDto();
                scaleInfoShowDto.Name = scale_info.NAME;
                scaleInfoShowDto.QuesNum = scale_info.QUES_NUM;
                scaleInfoShowDto.SelectNum = scale_info.SELECT_NUM;

                scaleInfoShowDtos.Add(scaleInfoShowDto);
            }
            return scaleInfoShowDtos;

        }
        
        public List<self_rating_anxiety_scale> GetSelf_Rating_Anxiety_Scales()
        {
            return _pdsEntity.self_rating_anxiety_scale.ToList();
        }

        public List<self_rating_depression_scale> GetSelf_Rating_Depression_Scales()
        {
            return _pdsEntity.self_rating_depression_scale.ToList();
        }
    }
}
