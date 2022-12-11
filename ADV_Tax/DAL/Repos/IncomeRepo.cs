using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class IncomeRepo : Repo, IRepo<Income, int, Income>
    {
        public Income Add(Income obj)
        {
            db.Incomes.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var dbIncome = Get(id);
            db.Incomes.Remove(dbIncome);
            return db.SaveChanges() > 0;
        }

        public List<Income> Get()
        {
            return db.Incomes.ToList();
        }

        public Income Get(int id)
        {
            return db.Incomes.Find(id);
        }

        public Income Update(Income obj)
        {
            var dbIncome = Get(obj.Id);
            db.Entry(dbIncome).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
