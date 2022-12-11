using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class RoleRepo : Repo, IRepo<Role, int, Role>
    {
        public Role Add(Role obj)
        {
            db.Roles.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var dbRole = Get(id);
            db.Roles.Remove(dbRole);
            return db.SaveChanges() > 0;
        }

        public List<Role> Get()
        {
            return db.Roles.ToList();
        }

        public Role Get(int id)
        {
            return db.Roles.Find(id);
        }

        public Role Update(Role obj)
        {
            var dbRole = Get(obj.Id);
            db.Entry(dbRole).CurrentValues.SetValues(obj);
            if(db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
