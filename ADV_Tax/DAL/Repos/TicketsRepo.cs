using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class TicketsRepo : Repo, IRepo<Ticket, int, Ticket>
    {
        public Ticket Add(Ticket obj)
        {
            db.Tickets.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var dbTicket = Get(id);
            db.Tickets.Remove(dbTicket);
            return db.SaveChanges() > 0; ;
        }

        public List<Ticket> Get()
        {
            return db.Tickets.ToList();
        }

        public Ticket Get(int id)
        {
            return db.Tickets.Find(id);
        }

        public Ticket Update(Ticket obj)
        {
            var dbTicket = Get(obj.Id);
            db.Entry(dbTicket).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
