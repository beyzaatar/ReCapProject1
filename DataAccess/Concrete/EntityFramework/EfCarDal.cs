using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapContext context=new ReCapContext())
            {
                var result = from x in context.Cars
                             join c in context.Colors
                             on x.ColorId equals c.Id
                             join b in context.Brands
                             on x.BrandId equals b.Id
                             select new CarDetailDto
                             {
                                 CarId = x.Id,
                                 BrandName = b.BrandName,
                                 ColorName = c.ColorName,
                                 DailyPrice = x.DailyPrice
                             };
                return result.ToList();
            }
        }
    }
}
