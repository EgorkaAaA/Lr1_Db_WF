using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lr1_Db_WF
{
    class Manufacturer
    {
        public int Id { get; set; }

        public string county { get; set; }

        public string companyName { get; set; }

        public int yearsOfCooperation { get; set; }

        public List<Furniture> furnitures { get; set; }

        public void ManufacturerAdd (Manufacturer manufacturer)
        {
            using (Context db = new Context())
            {
                db.manufacturers.Add(manufacturer);
                db.SaveChanges();
            }
            
        }
    }
}
