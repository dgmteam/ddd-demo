using Inventory.Domain.CatalogItemAggregate;
using Inventory.Domain.CatalogProviderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Infrastructure.EntityTypeConfiguration
{
    public class CatalogItemProviderEntityTypeConfiguration : IEntityTypeConfiguration<CatalogProvider>
    {
        public void Configure(EntityTypeBuilder<CatalogProvider> builder)
        {
            builder.ToTable("catalog_item_providers");

            builder.OwnsOne(x => x.Address);
            // builder.HasMany<CatalogItem>()
            //     .WithOne()
            //     .HasForeignKey("provider_id");
        }
    }
}