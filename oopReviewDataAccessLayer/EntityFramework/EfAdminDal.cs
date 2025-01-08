using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using oopReviewDataAccessLayer.Abstract;
using oopReviewDataAccessLayer.Repositories;
using oopReviewEntityLayer.Concrete;

namespace oopReviewDataAccessLayer.EntityFramework
{
    public class EfAdminDal : GenericRepository<Admin>,IAdminDal //bunlardan referans almasini istiyorum
    {
    }
}
