
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

            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine($"Car ID:{car.Id}" + " / " + $"Brand ID:{car.BrandId}" + " / " + $"Color ID:{car.ColorId}" + " / " + $"ModelYear:{car.ModelYear}" + " / " + $"Daily Price:{car.DailyPrice}" + " / " + $"Description:{car.Description}");

                
            }


        }
    }
}
