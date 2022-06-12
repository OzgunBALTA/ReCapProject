using DataAccess.Abstract;
using Entities.Concrete;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.DTOs;
using DataAccess.Concrete.Context;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailsDto> GetCarDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join clr in context.Colors
                             on c.ColorId equals clr.Id
                             select new CarDetailsDto
                             {
                                 CarId = c.Id,
                                 CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = clr.ColorName,
                                 DailyPrice = c.DailyPrice
                             };
                return result.ToList();
            }
        }
    }
}
