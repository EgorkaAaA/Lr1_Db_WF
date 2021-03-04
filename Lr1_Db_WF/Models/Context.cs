using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lr1_Db_WF
{
    class Context: DbContext
    {
        public DbSet<Manufacturer> manufacturers { get; set; }
        public DbSet<Kategories> kategories { get; set; }
        public DbSet<Furniture> furnitures { get; set; }
        public DbSet<Delivery> deliveries { get; set; }

        public Context(): base("DBConnection")
        { }
    }
}