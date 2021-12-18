using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AngulerCRUDWithIdentity.Model
{
    public class PaymentInfo
    {
        [Key]
        public int paymentId { get; set; }
        [Column(TypeName ="nvarchar(100)")]
        public string cardOwnerName { get; set; }
        [Column(TypeName ="nvarchar(16)")]
        public string cardNumber { get; set; }
        public int cvcNumber { get; set; }
        public DateTime? expiryDate { get; set; }
        public int status { get; set; }
        public decimal? amount { get; set; }
        public DateTime? paymentDate { get; set; }
        [Column(TypeName = "nvarchar(500)")]
        public string remarks { get; set; }
    }
}
