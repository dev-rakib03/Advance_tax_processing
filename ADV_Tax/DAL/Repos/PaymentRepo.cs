using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class PaymentRepo : Repo, IRepo<Payment, int, Payment>
    {
        public Payment Add(Payment obj)
        {
            db.Payments.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var dbPayment = Get(id);
            db.Payments.Remove(dbPayment);
            return db.SaveChanges() > 0;
        }

        public List<Payment> Get()
        {
            return db.Payments.ToList();
        }

        public Payment Get(int id)
        {
            return db.Payments.Find(id);
        }

        public Payment Update(Payment obj)
        {
            var dbPayments = Get(obj.Id);
            db.Entry(dbPayments).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
