using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class SettingsRepo : Repo, IRepo<Setting, int, Setting>
    {
        public Setting Add(Setting obj)
        {
            db.Settings.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var dbSettings = Get(id);
            db.Settings.Remove(dbSettings);
            return db.SaveChanges() > 0;
        }

        public List<Setting> Get()
        {
            return db.Settings.ToList();
        }

        public Setting Get(int id)
        {
            return db.Settings.Find(id);
        }

        public Setting Update(Setting obj)
        {
            var dbSettings = Get(obj.Id);
            db.Entry(dbSettings).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
