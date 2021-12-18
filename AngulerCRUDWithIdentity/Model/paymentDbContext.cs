using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngulerCRUDWithIdentity.Model
{
    public class paymentDbContext:DbContext
    {
        public paymentDbContext(DbContextOptions<paymentDbContext> options) : base(options)
        {

        }
        public DbSet<PaymentInfo> paymentInfos { get; set; }
    }
}
