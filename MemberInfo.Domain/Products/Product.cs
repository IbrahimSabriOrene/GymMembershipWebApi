using MemberInfo.Domain.Models;
using MemberInfo.Domain.Person.ValueObjects;
using MemberInfo.Domain.Products.ValueObjects;
using System.Collections.Generic;

namespace MemberInfo.Domain.Products
{
    public sealed class Product : AggregateRoot<ProductId>
    {
        public string ProductName { get; }
        public List<Price> Prices { get; }
        public int Months { get; }
        public DateTime CreationDate { get; }
        public DateTime? LastUpdateDate { get; }

        public PersonId PersonId { get; }

        public Product(
            ProductId productId,
            string productName,
            List<Price> prices,
            int months,
            DateTime creationDate,
            DateTime lastUpdateDate,
            PersonId personIds) : base(productId)
        {
            ProductName = productName;
            Prices = prices;
            Months = months;
            CreationDate = creationDate;
            LastUpdateDate = lastUpdateDate;
            PersonId = personIds;
        }

        public static Product Create(
            string productName,
            List<Price> prices, // price is null somehow
            int months,
            PersonId personIds)
        {
            var productId = ProductId.CreateUnique(); // This is the only place where we create a new ProductId
            return new Product(
                productId,
                productName,
                prices,
                months,
                DateTime.UtcNow,
                DateTime.UtcNow,
                personIds
                );
        }
    }
}
