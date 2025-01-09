using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using oopReviewDataAccessLayer.Abstract;
using oopReviewDataAccessLayer.Context;
using oopReviewDataAccessLayer.Repositories;
using oopReviewEntityLayer.Concrete;

namespace oopReviewDataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public List<Object> GetProductsWithCategory()
        {
            var context = new CourseContext();
            var values = context.Products.Select(z=>new 
            {
                ProductId = z.ProductId,
                ProductName = z.ProductName,
                ProductStock=z.ProductStock,
                ProductPrice=z.ProductPrice,
                ProductDescription=z.ProductDescription,
                CategoryName=z.Category.CategoryName,
            }).ToList();
            return values.Cast<object>().ToList();
        }
    }
}
