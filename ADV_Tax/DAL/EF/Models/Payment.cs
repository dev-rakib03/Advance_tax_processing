using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Income")]
        [Required]
        public int IncomeId { get; set; }
        public virtual Income Income { get; set; }
        [Required]
        public long PaymentAccount { get; set; }
        [Required]
        public int TrxId { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public DateTime PaymentDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
