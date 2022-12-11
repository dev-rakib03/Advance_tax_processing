using DAL.EF.Models;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<User, int, User> UserDataAccess()
        {
            return new UserRepo();
        }
        public static IRepo<Role, int, Role> RoleDataAccess()
        {
            return new RoleRepo();
        }
        public static IRepo<Income, int, Income> IncomeDataAccess()
        {
            return new IncomeRepo();
        }
    }
}
