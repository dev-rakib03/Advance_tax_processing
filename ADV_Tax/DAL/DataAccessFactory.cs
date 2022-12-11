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
        public static IRepo<PaymentSetting, int, PaymentSetting> PaymentSettingDataAccess()
        {
            return new Payment_settingsRepo();
        }
        public static IRepo<Payment, int, Payment> PaymentDataAccess()
        {
            return new PaymentRepo();
        }
        public static IRepo<Setting, int, Setting> SettingDataAccess()
        {
            return new SettingsRepo();
        }
        public static IRepo<Ticket, int, Ticket> TicketDataAccess()
        {
            return new TicketsRepo();
        }
    }
}
