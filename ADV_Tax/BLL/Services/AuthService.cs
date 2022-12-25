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
    public class AuthService
    {
        public static TokenDTO Authenticate(string email, string password)
        {
            var user = DataAccessFactory.AuthDataAccess().Authentication(email, password);
            if(user != null)
            {
                var tk = new Token();
                tk.Email = user.Email;
                tk.CreationTime = DateTime.Now;
                tk.ExpirationTime = null;
                tk.TKey = Guid.NewGuid().ToString();
                var rttk = DataAccessFactory.TokenDataAccess().Add(tk);
                if (rttk != null)
                {
                    var cfg = new MapperConfiguration(c => {
                        c.CreateMap<Token, TokenDTO>();
                    });
                    var mapper = new Mapper(cfg);
                    var data = mapper.Map<TokenDTO>(rttk);

                    //role
                    var role = DataAccessFactory.RoleDataAccess().Get(user.RoleId);
                    var config = new MapperConfiguration(roles =>
                    {
                        roles.CreateMap<Role, RoleDTO>();
                    });
                    var mapper_role = new Mapper(config);
                    var rt = mapper.Map<RoleDTO>(role);

                    //marge data and rt.Permission and rt.Name

                    return data;
                }
            }
            return null;
        }
        public static bool IsTokenValid(string token)
        {
            var tk = DataAccessFactory.TokenDataAccess().Get(token);
            if (tk != null && tk.ExpirationTime == null)
            {
                return true;
            }
            return false;


        }
    }
}
