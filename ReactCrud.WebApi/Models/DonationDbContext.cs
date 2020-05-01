using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactCrud.WebApi.Models
{
    public class DonationDbContext : DbContext
    {
      public DonationDbContext(DbContextOptions<DonationDbContext> options) : base(options)
      {

      }

      public DbSet<DCanidate> DCanidates { get; set; }

   }
}
