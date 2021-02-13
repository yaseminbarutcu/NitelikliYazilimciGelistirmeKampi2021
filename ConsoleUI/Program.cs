using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, start listed!");
            // ProductManager productManager = new ProductManager(new InMemoryProductDal());
            ProductTest();
            //CategoryTest();

        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var item in productManager.GetAllByCategoryId(2))
            {
                Console.WriteLine(item.ProductName);
            }
            Console.WriteLine("-------------Unit Price---------------");
            foreach (var item in productManager.GetByUnitPrice(50, 100))
            {
                Console.WriteLine(item.ProductName);
            }
            Console.WriteLine("-------------Product Details---------------");
            foreach (var item in productManager.GetProductDetails())
            {
                Console.WriteLine(item.ProductName + "/" + item.CategoryName);
            }
        }
    }
}
