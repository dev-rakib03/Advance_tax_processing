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
    public class PaymentService
    {
        public static List<PaymentDTO> GetPayment()
        {
            var data = DataAccessFactory.PaymentDataAccess().Get();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Payment, PaymentDTO>();
            });
            var mapper = new Mapper(config);
            var rt = mapper.Map<List<PaymentDTO>>(data);
            return rt;
        }
        public static PaymentDTO GetPayment(int id)
        {
            var data = DataAccessFactory.PaymentDataAccess().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Payment, PaymentDTO>();
            });
            var mapper = new Mapper(config);
            var rt = mapper.Map<PaymentDTO>(data);
            return rt;
        }
        public static PaymentDTO AddPayment(PaymentDTO payment)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<PaymentDTO, Payment>();
                cfg.CreateMap<Payment, PaymentDTO>();
            });
            var mapper = new Mapper(config);
            var dbpayment = mapper.Map<Payment>(payment);
            var rt = DataAccessFactory.PaymentDataAccess().Add(dbpayment);
            if (rt != null)
            {
                return mapper.Map<PaymentDTO>(rt);
            }
            return null;
        }
        public static PaymentDTO UpdatePayment(PaymentDTO payment)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PaymentDTO, Payment>();
                cfg.CreateMap<Payment, PaymentDTO>();
            });
            var mapper = new Mapper(config);
            var dbpayment = mapper.Map<Payment>(payment);
            var rt = DataAccessFactory.PaymentDataAccess().Update(dbpayment);
            if (rt != null)
            {
                return mapper.Map<PaymentDTO>(rt);

            }
            return null;
        }
        public static bool DeletePayment(int Id)
        {
            return DataAccessFactory.PaymentDataAccess().Delete(Id);
        }
    }
}
