
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleCar.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            //efCarDal();

            //brand();

            //color();

            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine($"Car ID:{car.Id}" + " / " +  $"Brand Name:{car.BrandName}" + " / " + $"ModelYear:{car.CarName}" + " / " + $"Daily Price:{car.DailyPrice}");


            }


        }

        private static void color()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine($"Color Id:{color.ColorId}" + "/" + $"Color Name:{color.ColorName}..");
            }
        }

        private static void brand()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine($"Brand Id:{brand.BrandId}" + " / " + $"Brand Name:{brand.BrandName}");
            }
        }

        private static void efCarDal()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine($"Car ID:{car.Id}" + " / " + $"Brand ID:{car.BrandId}" + " / " + $"Color ID:{car.ColorId}" + " / " + $"ModelYear:{car.ModelYear}" + " / " + $"Daily Price:{car.DailyPrice}" + " / " + $"Description:{car.Description}");


            }
        }
    }
}
