using AutoMapper;
using BLL.DTOs;
using DAL.EF.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class SettingService
    {
        public static List<SettingDTO> GetSetting()
        {
            var data = DataAccessFactory.SettingDataAccess().Get();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Setting, SettingDTO>();
            });
            var mapper = new Mapper(config);
            var rt = mapper.Map<List<SettingDTO>>(data);
            return rt;
        }
        public static SettingDTO GetSetting(int id)
        {
            var data = DataAccessFactory.SettingDataAccess().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Setting, SettingDTO>();
            });
            var mapper = new Mapper(config);
            var rt = mapper.Map<SettingDTO>(data);
            return rt;
        }
        public static SettingDTO AddSetting(SettingDTO Setting)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<SettingDTO, Setting>();
                cfg.CreateMap<Setting, SettingDTO>();
            });
            var mapper = new Mapper(config);
            var dbSetting = mapper.Map<Setting>(Setting);
            var rt = DataAccessFactory.SettingDataAccess().Add(dbSetting);
            if (rt != null)
            {
                return mapper.Map<SettingDTO>(rt);
            }
            return null;
        }
        public static SettingDTO UpdateSetting(SettingDTO Setting)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SettingDTO, Setting>();
                cfg.CreateMap<Setting, SettingDTO>();
            });
            var mapper = new Mapper(config);
            var dbSetting = mapper.Map<Setting>(Setting);
            var rt = DataAccessFactory.SettingDataAccess().Update(dbSetting);
            if (rt != null)
            {
                return mapper.Map<SettingDTO>(rt);

            }
            return null;
        }
        public static bool DeleteSetting(int Id)
        {
            return DataAccessFactory.SettingDataAccess().Delete(Id);
        }
    }
}
