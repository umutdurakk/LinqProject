using System;

namespace LinqProject
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Category> categories = new List<Category>
            {
                new Category{CategoryId=1 , CategoryName="Bilgisayar" },
                new Category{CategoryId=2, CategoryName="Telefon"}
            };



            List<Product> products = new List<Product>
            {
                new Product{ProductId=1,CategoryId=1,ProductName="Monster",UnitPrice=1500,UnitsInStock=3,QuantityPerUnit="32 gb ram"},
                new Product{ProductId=2,CategoryId=1,ProductName="Acer",UnitPrice=1000,UnitsInStock=4,QuantityPerUnit="16 gb ram"},
                new Product{ProductId=3,CategoryId=1,ProductName="Lenovo",UnitPrice=1300,UnitsInStock=5,QuantityPerUnit="64 gb ram"},
                new Product{ProductId=4,CategoryId=2,ProductName="Samsung",UnitPrice=500,UnitsInStock=3,QuantityPerUnit="2 gb ram"},
                new Product{ProductId=5,CategoryId=2,ProductName="GM",UnitPrice=900,UnitsInStock=3,QuantityPerUnit="4 gb ram"},
            };


            // var result = products.Any(x => x.ProductName == "Monster");

            //var result = products.FindAll(x => x.ProductName.Contains("er"));

            // var result = products.Where(x => x.ProductName.Contains("er")).OrderBy(x => x.UnitPrice).ThenBy(x=>x.ProductName);

            //TestDto(products);

            İnnnerMethod(categories, products);
        }

        private static void İnnnerMethod(List<Category> categories, List<Product> products)
        {
            var result = from p in products
                         join c in categories
                         on p.CategoryId equals c.CategoryId
                         where p.UnitPrice > 1000
                         orderby p.UnitPrice descending
                         select new ProductDto
                         { ProductId = p.ProductId, CategoryName = c.CategoryName, ProductName = p.ProductName, UnitPrice = p.UnitPrice };

            foreach (var item in result)
            {
                Console.WriteLine("{0} {1} {2} {3}", item.ProductId, item.ProductName, item.CategoryName, item.UnitPrice);
            }
        }

        private static void TestDto(List<Product> products)
        {
            var result = from p in products
                         where p.UnitPrice > 600
                         orderby p.UnitPrice descending, p.ProductName ascending
                         select new ProductDto { ProductId = p.ProductId, ProductName = p.ProductName, UnitPrice = p.UnitPrice };

            foreach (var product in result)
            {
                Console.WriteLine(product.ProductName);
            }
        }
    }


    class ProductDto
    {
        public int ProductId { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }

        public decimal UnitPrice { get; set; }
    }

    
    class Product
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
    }

    class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName{ get; set; }
    }

}