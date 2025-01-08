using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using oopReviewDataAccessLayer.Abstract;
using oopReviewDataAccessLayer.Context;

namespace oopReviewDataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        CourseContext context=new CourseContext();

        private readonly DbSet<T> _object;

        public GenericRepository()
        {
            _object=context.Set<T>();//Class cagirildiginda anda objecte bir nesen olusturuyor
        }

        public void Delete(T entity)
        {
            var deletedEntity=context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }

        public List<T> GetAll()
        {
            //butun veriyi getirme
            return _object.ToList();
        }

        public T GetById(int id)
        {
            return _object.Find(id);//id bul onu getir
        }

        public void Insert(T entity)
        {
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Added;
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            var updatedEntity = context.Entry(entity);  
            updatedEntity.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
