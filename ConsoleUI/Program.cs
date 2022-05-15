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
            ColorManager colorManager = new ColorManager(new EfColorDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            
            //DataBaseAdded(carManager, colorManager, brandManager);
            
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

            Console.WriteLine("----------------------------------------------");

            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine($"Adı: {car.CarName} / Fiyat:{car.DailyPrice} / Marka:{car.BrandName} / Renk:{car.ColorName}");
            }


            //Console.WriteLine("----------------------------------------------");

            //Car addedCar = new Car {CarId = 4, CarName = "Solkay", BrandId = 1, ColorId = 1, Description = "Fena Araba", ModelYear = 2021, DailyPrice = 195 };
            //carManager.Add(addedCar);
            //Car updatedCar = new Car { //CarId = 4, CarName = "Solomon", BrandId = 2, ColorId = 3, Description = "Güncellenen Araba", ModelYear = 2022, DailyPrice = 190 };
            //carManager.Update(updatedCar);
            //Car deletedCar = new Car { CarId = 4 };
            //carManager.Delete(deletedCar);

            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine($"Araba Adı: {car.CarName} Fiyatı:{car.DailyPrice}");
            //}


        }

        private static void DataBaseAdded(CarManager carManager, ColorManager colorManager, BrandManager brandManager)
        {
            Car car1 = new Car { CarId = 1, CarName = "Sabrina", BrandId = 1, ColorId = 1, Description = "Güzel Araba", ModelYear = 2021, DailyPrice = 150 };
            Car car2 = new Car { CarId = 2, CarName = "Savorona", BrandId = 2, ColorId = 1, Description = "Fena Araba", ModelYear = 2022, DailyPrice = 380 };
            Car car3 = new Car { CarId = 3, CarName = "Serkidoryan", BrandId = 2, ColorId = 2, Description = "Ama Ne Araba", ModelYear = 2022, DailyPrice = 450 };
            carManager.Add(car1);
            carManager.Add(car2);
            carManager.Add(car3);
            Color color1 = new Color { ColorId = 1, ColorName = "Beyaz" };
            Color color2 = new Color { ColorId = 2, ColorName = "Siyah" };
            Color color3 = new Color { ColorId = 3, ColorName = "Kırmızı" };
            colorManager.Add(color1);
            colorManager.Add(color2);
            colorManager.Add(color3);
            Brand brand1 = new Brand { BrandId = 1, BrandName = "BMW" };
            Brand brand2 = new Brand { BrandId = 2, BrandName = "Mercedes" };
            Brand brand3 = new Brand { BrandId = 3, BrandName = "Toyota" };
            brandManager.Add(brand1);
            brandManager.Add(brand2);
            brandManager.Add(brand3);
        }
    }
}
