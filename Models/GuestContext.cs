using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Kutse_App_DM.Models
{
    public class GuestContext : DbContext
    {
        public DbSet<Guest> Guests { get; set; }
    }
}
