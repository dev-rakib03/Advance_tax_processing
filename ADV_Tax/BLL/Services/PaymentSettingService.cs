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
    public class PaymentSettingService
    {
        public static List<PaymentSettingDTO> GetPaymentSetting()
        {
            var data = DataAccessFactory.PaymentSettingDataAccess().Get();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PaymentSetting, PaymentSettingDTO>();
            });
            var mapper = new Mapper(config);
            var rt = mapper.Map<List<PaymentSettingDTO>>(data);
            return rt;
        }
        public static PaymentSettingDTO GetPaymentSetting(int id)
        {
            var data = DataAccessFactory.PaymentSettingDataAccess().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PaymentSetting, PaymentSettingDTO>();
            });
            var mapper = new Mapper(config);
            var rt = mapper.Map<PaymentSettingDTO>(data);
            return rt;
        }
        public static PaymentSettingDTO AddPaymentSetting(PaymentSettingDTO PaymentSetting)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<PaymentSettingDTO, PaymentSetting>();
                cfg.CreateMap<PaymentSetting, PaymentSettingDTO>();
            });
            var mapper = new Mapper(config);
            var dbPaymentSetting = mapper.Map<PaymentSetting>(PaymentSetting);
            var rt = DataAccessFactory.PaymentSettingDataAccess().Add(dbPaymentSetting);
            if (rt != null)
            {
                return mapper.Map<PaymentSettingDTO>(rt);
            }
            return null;
        }
        public static PaymentSettingDTO UpdatePaymentSetting(PaymentSettingDTO PaymentSetting)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PaymentSettingDTO, PaymentSetting>();
                cfg.CreateMap<PaymentSetting, PaymentSettingDTO>();
            });
            var mapper = new Mapper(config);
            var dbPaymentSetting = mapper.Map<PaymentSetting>(PaymentSetting);
            var rt = DataAccessFactory.PaymentSettingDataAccess().Update(dbPaymentSetting);
            if (rt != null)
            {
                return mapper.Map<PaymentSettingDTO>(rt);

            }
            return null;
        }
        public static bool DeletePaymentSetting(int Id)
        {
            return DataAccessFactory.PaymentSettingDataAccess().Delete(Id);
        }
    }
}
