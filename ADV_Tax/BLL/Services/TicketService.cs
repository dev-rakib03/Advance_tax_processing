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
    public class TicketService
    {
        public static List<TicketDTO> GetTicket()
        {
            var data = DataAccessFactory.TicketDataAccess().Get();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Ticket, TicketDTO>();
            });
            var mapper = new Mapper(config);
            var rt = mapper.Map<List<TicketDTO>>(data);
            return rt;
        }
        public static TicketDTO GetTicket(int id)
        {
            var data = DataAccessFactory.TicketDataAccess().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Ticket, TicketDTO>();
            });
            var mapper = new Mapper(config);
            var rt = mapper.Map<TicketDTO>(data);
            return rt;
        }
        public static TicketDTO AddTicket(TicketDTO Ticket)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<TicketDTO, Ticket>();
                cfg.CreateMap<Ticket, TicketDTO>();
            });
            var mapper = new Mapper(config);
            var dbTicket = mapper.Map<Ticket>(Ticket);
            var rt = DataAccessFactory.TicketDataAccess().Add(dbTicket);
            if (rt != null)
            {
                return mapper.Map<TicketDTO>(rt);
            }
            return null;
        }
        public static TicketDTO UpdateTicket(TicketDTO Ticket)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TicketDTO, Ticket>();
                cfg.CreateMap<Ticket, TicketDTO>();
            });
            var mapper = new Mapper(config);
            var dbTicket = mapper.Map<Ticket>(Ticket);
            var rt = DataAccessFactory.TicketDataAccess().Update(dbTicket);
            if (rt != null)
            {
                return mapper.Map<TicketDTO>(rt);

            }
            return null;
        }
        public static bool DeleteTicket(int Id)
        {
            return DataAccessFactory.TicketDataAccess().Delete(Id);
        }
    }
}
