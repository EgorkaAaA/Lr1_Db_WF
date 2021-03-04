using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lr1_Db_WF
{
    class Delivery
    {
        public int Id { get; set; }

        public string adres { get; set; }

        public string Date { get; set; }

        public Furniture furniture { get; set; }

        public void DeliveryAdd (string adres , string date, int IdF)
        {
            Context db = new Context();
            Furniture furniture = db.furnitures.Find(IdF);

            Delivery delivery = new Delivery { adres = adres, Date = date, furniture = furniture };

            db.deliveries.Add(delivery);
            db.SaveChanges();
        }
    }
}
