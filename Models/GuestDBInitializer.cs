using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Kutse_App_DM.Models
{
    public class GuestDBInitializer : CreateDatabaseIfNotExists<GuestContext>
    //DropCreateDatabaseAlways<GuestContext>
    {
        protected override void Seed(GuestContext db)
        {
            base.Seed(db);
        }
    }
}
