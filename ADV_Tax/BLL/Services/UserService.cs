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
    public class UserService
    {
        public static List<UserDTO> GetUser()
        {
            var data = DataAccessFactory.UserDataAccess().Get();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(config);
            var rt = mapper.Map<List<UserDTO>>(data);
            return rt;
        }
        public static UserDTO GetUser(int id)
        {
            var data = DataAccessFactory.UserDataAccess().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(config);
            var rt = mapper.Map<UserDTO>(data);
            return rt;
        }
        public static UserDTO AddUser(UserDTO user)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<UserDTO, User>();
                cfg.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(config);
            var dbuser = mapper.Map<User>(user);
            var rt = DataAccessFactory.UserDataAccess().Add(dbuser);
            if (rt != null)
            {
                return mapper.Map<UserDTO>(rt);
            }
            return null;
        }
        public static UserDTO Update(UserDTO user)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<UserDTO, User>();
                cfg.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(config);
            var dbuser = mapper.Map<User>(user);
            var rt = DataAccessFactory.UserDataAccess().Update(dbuser);
            if (rt != null)
            {
                return mapper.Map<UserDTO>(rt);
            }
            return null;
        }

        public static bool Delete(int Id)
        {
            return DataAccessFactory.UserDataAccess().Delete(Id);
        }
    }
}
