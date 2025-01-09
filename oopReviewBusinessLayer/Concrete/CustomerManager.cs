using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using oopReviewBusinessLayer.Abstract;
using oopReviewDataAccessLayer.Abstract;
using oopReviewEntityLayer.Concrete;

namespace oopReviewBusinessLayer.Concrete
{
    public class CustomerManager : ICustomerService
    {

        private readonly ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public void TDelete(Customer entity)
        {
            _customerDal.Delete(entity);
        }

        public List<Customer> TGetAll()
        {
            //YETKIN VARSA YAP YOKSA YAPMA GIBI SEYLERI YAPABILIRIZ BU BUSINESS ICIN UYGUNDUR! 
            return _customerDal.GetAll();   
        }

        public Customer TGetById(int id)
        {
            return _customerDal.GetById(id);
        }

        public void TInsert(Customer entity)
        {
            if (entity.CustomerName != "" && entity.CustomerName.Length >= 3 && entity.CustomerCity != null && entity.CustomerSurname != "" && entity.CustomerName.Length <= 30) 
            {
                //Ekleme yap
                _customerDal.Insert(entity);
            }
            else
            {
                //Hata ver BUNLAR BIR VALIDATION KURALIDIR!
            }
        }

        public void TUpdate(Customer entity)
        {
            _customerDal.Update(entity);
        }

        //BIZ AYNI SEYLERI YAPTIK FAKAT BUSINESS KATMANINDA YUKARIDAKI IF GIBI SEYLERI YAPARIZ 
    }
}
