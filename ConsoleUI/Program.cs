using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            //Car car1 = new Car { CarName = "Sabrina", BrandId = 1, ColorId = 1, Description = "Güzel Araba", ModelYear = 2021, DailyPrice = 150 };
            //Car car2 = new Car { CarName = "Savorona", BrandId = 2, ColorId = 1, Description = "Fena Araba", ModelYear = 2022, DailyPrice = 380 };
            //Car car3 = new Car { CarName = "Serkidoryan", BrandId = 2, ColorId = 2, Description = "Ama Ne Araba", ModelYear = 2022, DailyPrice = 450 };
            //carManager.Add(car1);
            //carManager.Add(car2);
            //carManager.Add(car3);
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine($"Araba Adı: {car.CarName} Fiyatı:{car.DailyPrice}");
            }
            
            Console.WriteLine("----------------------------------------------");

            foreach (var car in carManager.GetCarsByColorId(1))
            {
                Console.WriteLine($"Araba Adı: {car.CarName} Fiyatı:{car.DailyPrice}");
            }

            Console.WriteLine("----------------------------------------------");

            foreach (var car in carManager.GetCarsByBrandId(2))
            {
                Console.WriteLine($"Araba Adı: {car.CarName} Fiyatı:{car.DailyPrice}");
            }
        }
    }
}
