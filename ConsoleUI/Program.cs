using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarTest();
            //ModelTest();

        }

        //private static void ModelTest()
        //{
        //    ModelManager modelManager = new ModelManager(new EfModelDal());
        //    foreach (var model in modelManager.GetAll())
        //    {
        //        Console.WriteLine(model.ModelName);
        //    }
        //}

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success==true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName + "/" + car.BrandName); ;
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }
    }
}
