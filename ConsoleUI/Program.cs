using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
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

            //GetAll(carManager);
            //GetCarsByColorId(carManager);
            //GetCarsByBrandId(carManager);
            //GetCarDetails(carManager);

            //CarsAdded(carManager);
            //ColorsAdded(colorManager);
            //BrandsAdded(brandManager);

        }

        private static void CarsAdded(CarManager carManager)
        {
            Car car1 = new Car { CarName = "Sabrina", BrandId = 1, ColorId = 1, Description = "Güzel Araba", ModelYear = 2021, DailyPrice = 150 };
            Car car2 = new Car { CarName = "Savorona", BrandId = 2, ColorId = 1, Description = "Fena Araba", ModelYear = 2022, DailyPrice = 380 };
            Car car3 = new Car { CarName = "Serkidoryan", BrandId = 2, ColorId = 2, Description = "Ama Ne Araba", ModelYear = 2022, DailyPrice = 450 };
            carManager.Add(car1);
            carManager.Add(car2);
            carManager.Add(car3);
        }

        private static void ColorsAdded(ColorManager colorManager)
        {
            Color color1 = new Color { ColorName = "Beyaz" };
            Color color2 = new Color { ColorName = "Siyah" };
            Color color3 = new Color { ColorName = "Kırmızı" };
            colorManager.Add(color1);
            colorManager.Add(color2);
            colorManager.Add(color3);
        }

        private static void BrandsAdded(BrandManager brandManager)
        {
            Brand brand1 = new Brand { BrandName = "BMW" };
            Brand brand2 = new Brand { BrandName = "Mercedes" };
            Brand brand3 = new Brand { BrandName = "Toyota" };
            brandManager.Add(brand1);
            brandManager.Add(brand2);
            brandManager.Add(brand3);
        }

        private static void GetCarDetails(CarManager carManager)
        {
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine($"Adı: {car.CarName} / Fiyat:{car.DailyPrice} / Marka:{car.BrandName} / Renk:{car.ColorName}");
            }
        }

        private static void GetCarsByBrandId(CarManager carManager)
        {
            foreach (var car in carManager.GetCarsByBrandId(2).Data)
            {
                Console.WriteLine($"Araba Adı: {car.CarName} Fiyatı:{car.DailyPrice}");
            }
        }

        private static void GetAll(CarManager carManager)
        {
            var result = carManager.GetAll();
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine($"Araba Adı: {car.CarName} Fiyatı:{car.DailyPrice}");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void GetCarsByColorId(CarManager carManager)
        {
            foreach (var car in carManager.GetCarsByColorId(1).Data)
            {
                Console.WriteLine($"Araba Adı: {car.CarName} Fiyatı:{car.DailyPrice}");
            }
        }
    }
}
