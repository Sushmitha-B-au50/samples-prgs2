using Microsoft.EntityFrameworkCore;
using System;


namespace EntityFrameSecondApproach
{
    class Program
    {
        //public static EFContext db = new EFContext();
        public static Product p = new Product();



        static void Main(string[] args)
        {
            //p = AcceptDetails();
            //AddProducts(p);
            Console.WriteLine("plase enter productid to update");
            int id = Convert.ToInt32(Console.ReadLine());
            //DeleteProduct(id);
            UpdateProducts(id);
            DisplayProducts();
        }
        public static void DisplayProducts()
        {
            using (var db = new EFContext())
            {
                foreach (var item in db.Products)
                {
                    Console.WriteLine(item.ProductId + " " + item.ProductName + " " + item.Price + " " + item.Quality);
                }
            }
        }
        
        private static void AddProducts(Product p1)
         {
            using (var db = new EFContext())
            {
                db.Products.Add(p1);
                db.SaveChanges();
                Console.WriteLine("Record Added successfully");
            }
         }
        private static Product GetProductById(int id)
        {
            using (var db = new EFContext())
            {
                p = db.Products.Find(id);
            }
            return p;
        }
        private static void UpdateProducts(int id)
        {
            using (var db = new EFContext())
            {
                p = GetProductById(id);
                Console.WriteLine(p.ToString());
                p = AcceptDetails();
                db.Entry(p).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        private static void DeleteProduct(int id)
        {
            using (var db = new EFContext())
            {
                p = db.Products.Find(id);
                if (p == null)
                {
                    Console.WriteLine("no such product");
                }
                else
                {
                    db.Products.Remove(p);
                    db.SaveChanges();
                    Console.WriteLine("product removed");
                }
            }
        }

        private static Product AcceptDetails()
        {
            //Console.WriteLine("enter product id");
            //p.ProductId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter product name");
             p.ProductName =(Console.ReadLine());
             Console.WriteLine("enter product price");
             p.Price = Convert.ToInt32(Console.ReadLine());
             Console.WriteLine("enter product quality");
            p.Quality= Convert.ToInt32(Console.ReadLine());
            return p;
        }
    }
}
