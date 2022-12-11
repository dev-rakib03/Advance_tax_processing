using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class RoleService
    {
        public static List<RoleDTO> GetRole()
        {
            var data = DataAccessFactory.RoleDataAccess().Get();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Role, RoleDTO>();
            });
            var mapper = new Mapper(config);
            var rt = mapper.Map<List<RoleDTO>>(data);
            return rt;
        }
        public static RoleDTO GetRole(int id)
        {
            var data = DataAccessFactory.RoleDataAccess().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Role, RoleDTO>();
            });
            var mapper = new Mapper(config);
            var rt = mapper.Map<RoleDTO>(data);
            return rt;
        }
        public static RoleDTO AddRole(RoleDTO role)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<RoleDTO, Role>();
                cfg.CreateMap<Role, RoleDTO>();
            });
            var mapper = new Mapper(config);
            var dbrole = mapper.Map<Role>(role);
            var rt = DataAccessFactory.RoleDataAccess().Add(dbrole);
            if (rt != null)
            {
                return mapper.Map<RoleDTO>(rt);
            }
            return null;
        }
        public static RoleDTO UpdateRole(RoleDTO role)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<RoleDTO, Role>();
                cfg.CreateMap<Role, RoleDTO>();
            });
            var mapper = new Mapper(config);
            var dbrole = mapper.Map<Role>(role);
            var rt = DataAccessFactory.RoleDataAccess().Update(dbrole);
            if (rt != null)
            {
                return mapper.Map<RoleDTO>(rt);
            }
            return null;
        }

        public static bool DeleteRole(int Id)
        {
            return DataAccessFactory.RoleDataAccess().Delete(Id);
        }
    }
}
