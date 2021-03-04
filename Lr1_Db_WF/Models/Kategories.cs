using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lr1_Db_WF
{
    class Kategories
    {
        public int Id { get; set; }

        public string name { get; set; }

        public List<Furniture> furnitures { get; set; }

        public void KategoriesAdd (Kategories kategories )
        {
            Context db = new Context();
            db.kategories.Add(kategories);
            db.SaveChanges();
        }
    }
}
