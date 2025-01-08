using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopReviewEntityLayer.Concrete
{
    public class Category
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public int CategoryStatus { get; set; }
        public List<Product> Products { get; set; }//List yapmamizin sebebi birden fazla urun barindirmasindan dolayidir

    }   
}
