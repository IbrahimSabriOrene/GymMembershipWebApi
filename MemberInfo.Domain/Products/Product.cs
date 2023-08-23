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

        private readonly List<PersonId> _personIds = new();
        public IReadOnlyCollection<PersonId> PersonIds => _personIds.ToList();

        public Product(
            ProductId productId,
            string productName,
            List<Price> prices,
            int months,
            DateTime creationDate,
            DateTime lastUpdateDate,
            List<PersonId> personIds) : base(productId)
        {
            ProductName = productName;
            Prices = prices;
            Months = months;
            CreationDate = creationDate;
            LastUpdateDate = lastUpdateDate;
            _personIds.AddRange(personIds);
        }

        public static Product Create(
            string productName,
            List<Price> prices,
            int months,
            List<PersonId> personIds)
        {
            var productId = ProductId.CreateUnique();
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
