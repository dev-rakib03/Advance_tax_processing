using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class IncomeService
    {
        public static List<IncomeDTO> GetIncome()
        {
            var data = DataAccessFactory.IncomeDataAccess().Get();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Income, IncomeDTO>();
            });
            var mapper = new Mapper(config);
            var rt = mapper.Map<List<IncomeDTO>>(data);
            return rt;
        }
        public static IncomeDTO GetIncome(int id)
        {
            var data = DataAccessFactory.IncomeDataAccess().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Income, IncomeDTO>();
            });
            var mapper = new Mapper(config);
            var rt = mapper.Map<IncomeDTO>(data);
            return rt;
        }
        public static IncomeDTO AddIncome(IncomeDTO income)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<IncomeDTO, Income>();
                cfg.CreateMap<Income, IncomeDTO>();
            });
            var mapper = new Mapper(config);
            var dbincome = mapper.Map<Income>(income);
            var rt = DataAccessFactory.IncomeDataAccess().Add(dbincome);
            if (rt != null)
            {
                return mapper.Map<IncomeDTO>(rt);
            }
            return null;
        }
        public static IncomeDTO UpdateIncome(IncomeDTO income)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<IncomeDTO, Income>();
                cfg.CreateMap<Income, IncomeDTO>();
            });
            var mapper = new Mapper(config);
            var dbincome = mapper.Map<Income>(income);
            var rt = DataAccessFactory.IncomeDataAccess().Update(dbincome);
            if(rt != null)
            {
                return mapper.Map<IncomeDTO>(rt);

            }
            return null;
        }
        public static bool DeleteIncome(int Id)
        {
            return DataAccessFactory.IncomeDataAccess().Delete(Id);
        }
    }
}
