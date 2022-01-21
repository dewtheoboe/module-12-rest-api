using ProductApi.Daos;
using ProductApi.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi.Models
{
    public static class ProductSeed
    {
        public static void InitData(ProductContext context)
        {
            var rnd = new Random();

            var adjectives = new[] { "Small", "Ergonomic", "Rustic",
                "Smart", "Sleek" };
            var materials = new[] { "Steel", "Wooden", "Concrete", "Plastic",
                "Granite", "Rubber" };
            var names = new[] { "Chair", "Car", "Computer", "Pants", "Shoes" };
            var revNames = new[] { "Mike", "Sally", "Linda", "Karen", "Carl" };
            var departments = new[] { "Books", "Movies", "Music",
                "Games", "Electronics" };
            var opinions = new[] { "I love it!", "I hate it.", "Meh, it's alright." };
            var numberOfReviews = 0;
            var numberOfRelatedProducts = 0;

            context.Products.AddRange(500.Times(x =>
            {
                var adjective = adjectives[rnd.Next(0, 5)];
                var material = materials[rnd.Next(0, 5)];
                var name = names[rnd.Next(0, 5)];
                var department = departments[rnd.Next(0, 5)];
                var productId = $"{x,-3:000}";

                List<Review> reviews = new List<Review>();

                var hasReview = Convert.ToBoolean(rnd.Next(0, 2));
                if (hasReview)
                {
                    var numberReviews = rnd.Next(0, 5);
                    for (int i = 0; i < numberReviews; i++)
                    {
                        numberOfReviews += 1;
                        var revadjective = adjectives[rnd.Next(0, 5)];
                        var revmaterial = materials[rnd.Next(0, 5)];
                        var revname = revNames[rnd.Next(0, 5)];
                        var revdepartment = departments[rnd.Next(0, 5)];
                        var revproductId = $"{x + numberOfReviews,-3:000}";
                        var rating = rnd.Next(1, 6);

                        reviews.Add(new Review
                        {
                            ReviewNumber =
                                $"{revname.First()}{rating}{revproductId}",
                            Rating = rating,
                            Name = $"{revname}",
                            ReviewBody = $"The {adjective} {material} {name} is {adjectives[rnd.Next(0, 5)]}. {opinions[rnd.Next(0,3)]}"
                        });
                    }

                }

                List<RelatedProduct> relatedProducts = new List<RelatedProduct>();

                var hasRelatedProduct = Convert.ToBoolean(rnd.Next(0, 2));
                if (hasRelatedProduct)
                {
                    var numberRelatedProducts = rnd.Next(0, 5);
                    for (int i = 0; i < numberRelatedProducts; i++)
                    {
                        numberOfRelatedProducts += 1;
                        var radjective = adjectives[rnd.Next(0, 5)];
                        var rmaterial = materials[rnd.Next(0, 5)];
                        var rname = names[rnd.Next(0, 5)];
                        var rdepartment = departments[rnd.Next(0, 5)];
                        var rproductId = $"{x + 500 + numberOfRelatedProducts,-3:000}";

                        relatedProducts.Add(new RelatedProduct
                        {
                            ProductNumber =
                                $"{rdepartment.First()}{rname.First()}{rproductId}",
                            Name = $"{radjective} {rmaterial} {rname}",
                            Price = (double)rnd.Next(1000, 9000) / 100,
                            Department = rdepartment
                        });
                    }

                }

                return new Product
                {
                    ProductNumber =
                        $"{department.First()}{name.First()}{productId}",
                    Name = $"{adjective} {material} {name}",
                    Price = (double)rnd.Next(1000, 9000) / 100,
                    Department = department,
                    Reviews = reviews,
                    RelatedProducts = relatedProducts
                };
            }));

            context.SaveChanges();
        }
    }
}
