namespace TheShop
{
    using System;
    using Factory;
    using Services;
    using Services.Interfaces;
    using Suppliers;
    using TheShop.Model;
    using TheShop.Repositories;

    internal class Program
    {
        private static void Main(string[] args)
        {
            IShopService shopService = new ShopService(
                                            new DatabaseDriver<Article>(),
                                            new Logger(),
                                            new SupplierHierarchyFactory());

            try
            {
                //order and sell
                shopService.OrderAndSellArticle(1, 20, 10);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            try
            {
                //print article on console
                var article = shopService.GetById(1);
                Console.WriteLine("Found article with ID: " + article.ID);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Article not found: " + ex);
            }

            try
            {
                //print article on console				
                var article = shopService.GetById(12);
                Console.WriteLine("Found article with ID: " + article.ID);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Article not found: " + ex);
            }

            Console.ReadKey();
        }
    }
}