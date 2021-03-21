
using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleCar.UI
{
    class Program
    {
        static void Main(string[] args)
        {

            CarManager carManager = new CarManager(new InMemoryDal());
            foreach (var cars in carManager.GetAll())
            {
                Console.WriteLine("Yeni Arabaların açıklamaları : " + cars.Description);
            }


        }
    }
}
