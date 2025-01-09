using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using oopReviewEntityLayer.Concrete;
namespace oopReviewBusinessLayer.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
         List<object> TGetProductsWithCategory();

    }
}
