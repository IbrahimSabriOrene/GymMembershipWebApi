using MemberInfo.Domain.Models;
using MemberInfo.Domain.Person.ValueObjects;
using MemberInfo.Domain.Products.ValueObjects;
using System.Collections.Generic;

namespace MemberInfo.Domain.Products
{
    public sealed class Product : AggregateRoot<ProductId>
    {
        public string ProductName { get; private set; }
        public List<Price> Prices { get; private set; }
        public int Months { get; private set; }
        public DateTime? CreationDate { get; private set; }
        public DateTime? LastUpdateDate { get; private set; }

        public HashSet<PersonId> PersonIds { get; private set; }

        public Product(
            ProductId productId,
            string productName,
            List<Price> prices,
            int months,
            DateTime? creationDate,
            DateTime lastUpdateDate) : base(productId)
        {
            ProductName = productName;
            Prices = prices;
            Months = months;
            CreationDate = creationDate;
            LastUpdateDate = lastUpdateDate;
            PersonIds = new HashSet<PersonId>();
        }

        public DateTime GetExpirationDate()
        {
            return CreationDate.GetValueOrDefault().AddMonths(Months);
        }

        public bool AddPersonId(PersonId personId)
        {
            return personId is not null && PersonIds.Add(personId);
        }

        public static Product Create(
            string productName,
            List<Price> prices, // price is null somehow
            int months,
            HashSet<PersonId> personIds)
        {
            var productId = ProductId.CreateUnique(); // This is the only place where we create a new ProductId
            var product = new Product(
                productId: productId,
                productName: productName,
                prices: prices,
                months: months,
                creationDate: DateTime.UtcNow,
                lastUpdateDate:DateTime.UtcNow
                );

            
            
            foreach (var personId in personIds)
            {
                product.AddPersonId(personId);
            }

            return product;


            
        }
    }
}
