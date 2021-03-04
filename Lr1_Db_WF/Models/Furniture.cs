using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lr1_Db_WF
{
    class Furniture
    {
        public int Id { get; set; }

        public int Price { get; set; }

        public Kategories kategories { get; set; }

        public Manufacturer manufacturer { get; set; }

        public List<Delivery> deliveries { get; set; }

        public void FurnitureAdd(int price, int IdK, int IdM)
        {
            Context db = new Context();

            Kategories a = db.kategories.Find(IdK);

            Manufacturer b = db.manufacturers.Find(IdM);

            Furniture furniture = new Furniture { kategories = a, manufacturer = b, Price = price };

            db.furnitures.Add(furniture);
            db.SaveChanges();
        }
    }
}
