using JSONProcessing.Common;
using JSONProcessing.Models.ProductsShop;
using System;
using System.Data.Entity;

namespace JSONProcessing.Data
{
    class SeedOnInit : CreateDatabaseIfNotExists<ProductsShopContext>
    {
        protected override void Seed(ProductsShopContext context)
        {
            var products = Importer<Product>.ImportFromJSON();
            var users = Importer<User>.ImportFromJSON();
            var categories = Importer<Category>.ImportFromJSON();
            Random rnd = new Random();

            foreach (var user in users)
            {
                for (int i = 0; i < rnd.Next(1, 10); i++)
                {
                    var friend = users[rnd.Next(0, users.Length)];

                    if (user == friend)
                    {
                        continue;
                    }

                    if (!user.Friends.Contains(friend))
                    {
                        AddFriend(user, friend);
                    }
                }
            }

            foreach (var product in products)
            {

                for (int i = 0; i < rnd.Next(0, 5); i++)
                {
                    var category = categories[rnd.Next(0, categories.Length)];
                    if (!product.Categories.Contains(category))
                    {
                        product.Categories.Add(category);
                    }
                }

                product.Seller = users[rnd.Next(users.Length)];

                try
                {
                    var buyer = users[rnd.Next(0, users.Length * 2)];
                    if (buyer != product.Seller)
                    {
                        product.Buyer = buyer;
                    }
                }
                catch
                {
                    product.BuyerId = null;
                }
            }

            context.Users.AddRange(users);
            context.Categories.AddRange(categories);
            context.Products.AddRange(products);

            base.Seed(context);
        }

        private static void AddFriend(User user, User friend)
        {
            user.Friends.Add(friend);
            friend.Friends.Add(user);
        }
    }
}