using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class PaymentDTO
    {
        public int Id { get; set; }
        public int IncomeId { get; set; }
        public long PaymentAccount { get; set; }
        public int TrxId { get; set; }
        public int Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
