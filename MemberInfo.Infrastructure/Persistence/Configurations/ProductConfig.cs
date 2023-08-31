using MemberInfo.Domain.ProductAggregate;
using MemberInfo.Domain.ProductAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MemberInfo.Infrastructure.Persistence.Configurations
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            ConfigureProduct(builder);
        }

        private void ConfigureProduct(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            // Configure the ProductId as the primary key
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasConversion(id => id.Value, value => ProductId.Create());

            builder.Property(x => x.ProductName).HasMaxLength(100);
            builder.Property(x => x.Price).HasColumnType("decimal(18, 2)"); // Assuming it's a decimal
            builder.Property(x => x.Months); // Assuming it's an integer
        }
    }
}
