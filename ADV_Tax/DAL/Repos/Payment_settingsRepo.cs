using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class Payment_settingsRepo : Repo, IRepo<PaymentSetting, int, PaymentSetting>
    {
        public PaymentSetting Add(PaymentSetting obj)
        {
            db.PaymentSettings.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var dbPaymentSettings = Get(id);
            db.PaymentSettings.Remove(dbPaymentSettings);
            return db.SaveChanges() > 0;
        }

        public List<PaymentSetting> Get()
        {
            return db.PaymentSettings.ToList();
        }

        public PaymentSetting Get(int id)
        {
            return db.PaymentSettings.Find(id);
        }

        public PaymentSetting Update(PaymentSetting obj)
        {
            var dbPaymentSettings = Get(obj.Id);
            db.Entry(dbPaymentSettings).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
