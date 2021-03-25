using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    //SOLID
    //Open Closed Principle -> Yaptığın yazılıma yeni bir özellik ekliyorsan mevcuttaki hiçbir koduna dokunmazsın. (SOLID -> O Harfi demek) 
    class Program
    {
        static void Main(string[] args)
        {
            // Data Tranformation Object -> DTO
            ProductTest();
            //IoC
            //CategoryTest();
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

            foreach (var category in categoryManager.GetAll().Data)
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            //                                                 Hangi veri türü kullanıyorsun yaz, entityframework mü inmemory mi ? Mantığı bu şekilde 
            ProductManager productManager = new ProductManager(new EfProductDal(), new CategoryManager(new EfCategoryDal()));

            var result = productManager.GetProductDetails();

            if (result.Success==true)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductName + " / " + product.CategoryName);
                }
            }

            else
            {
                Console.WriteLine(result.Message);
            }

            foreach (var product in productManager.GetAll().Data)
            {
                Console.WriteLine(product.ProductName);
            }
            Console.WriteLine("\n");
            Console.WriteLine("2 numaralı category idsine sahip ürünleri filtrele");
            Console.WriteLine("\n");
            foreach (var product in productManager.GetAllByCategoryId(2).Data)
            {
                Console.WriteLine(product.ProductName);
            }
            Console.WriteLine("\n");
            Console.WriteLine("Fiyatı min 50 max 100 olan ürünleri getir");
            Console.WriteLine("\n");
            foreach (var product in productManager.GetByUnitPrice(50, 100).Data)
            {
                Console.WriteLine(product.ProductName);
            }
            Console.WriteLine("\n");
            foreach (var product in productManager.GetProductDetails().Data)
            {
                Console.WriteLine(product.ProductName + " / " + product.CategoryName);
            }
        }
    }
}
