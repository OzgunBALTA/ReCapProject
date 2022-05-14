using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car {CarId=1, BrandId=1, CarName ="Sabri", ModelYear=2020, ColorId=1, DailyPrice=120, Description="Günlük 500km ile sınırlı"},
                new Car {CarId=2, BrandId=1, CarName ="Selcuk", ModelYear=2021, ColorId=2, DailyPrice=150, Description="Günlük 600km ile sınırlı"},
                new Car {CarId=3, BrandId=2, CarName= "Melo", ModelYear=2021, ColorId=1, DailyPrice=450, Description="Günlük 300km ile sınırlı"},
                new Car {CarId=4, BrandId=2, CarName="Sneijder", ModelYear=2022, ColorId=3, DailyPrice=500, Description="Günlük 200km ile sınırlı"},
                new Car {CarId=5, BrandId=3, CarName="Drogba", ModelYear=2022, ColorId=2, DailyPrice=800, Description="Günlük 150km ile sınırlı"}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(x => x.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return (List<Car>)_cars.OrderBy(x=>x.CarId).ToList();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(x => x.CarId == id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(x => x.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
        }
    }
}
