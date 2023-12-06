using Customer.Domain.Models;
using Customer.Domain.Person.ValueObjects;
using Customer.Domain.Products.ValueObjects;
using System.Collections.Generic;

namespace Customer.Domain.Products
{
    public sealed class Product : AggregateRoot<ProductId>
    {
        public string ProductName { get; private set; }
        public List<Price> Prices { get; private set; }
        public int Months { get; private set; }
        public DateTime? CreationDate { get; private set; }
        public DateTime? LastUpdateDate { get; private set; }

        public Product(
            ProductId productId,
            string productName,
            List<Price> prices,
            int months,
            DateTime? creationDate,
            DateTime? lastUpdateDate
            ) : base(productId)
        {
            ProductName = productName;
            Prices = prices;
            Months = months;
            CreationDate = creationDate;
            LastUpdateDate = lastUpdateDate;
        }

<<<<<<< HEAD
        public static DateTime GetExpirationDate(int months, DateTime date)
        {
            
            return date.AddMonths(months);
        }

        public bool AddPersonId(PersonId personId)
        {
            return personId is not null && PersonIds.Add(personId);
        }
=======
>>>>>>> v1.2

        public static Product Create(
            string productName,
            List<Price> prices, // price is null somehow
            int months
            )
        {
            var productId = ProductId.CreateUnique(); // This is the only place where we create a new ProductId
            var product = new Product(
                productId: productId,
                productName: productName,
                prices: prices,
                months: months,
                creationDate: DateTime.UtcNow,
                lastUpdateDate: DateTime.UtcNow // DateTime UtcNow not looking good. We should change it.
                );
            return product;

        //Make personId is null by default.

        }
    }
}
