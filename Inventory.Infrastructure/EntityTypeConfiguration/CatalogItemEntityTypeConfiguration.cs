using Inventory.Domain.CatalogItemAggregate;
using Inventory.Domain.CatalogProviderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Infrastructure.EntityTypeConfiguration
{
    public class CatalogItemEntityTypeConfiguration : IEntityTypeConfiguration<CatalogItem>, IEntityTypeConfiguration<Sku>
    {
        public void Configure(EntityTypeBuilder<CatalogItem> builder)
        {
            builder.ToTable("catalog_items");

            builder.OwnsOne(x => x.Price);

            builder.HasOne<CatalogProvider>()
                .WithMany()
                .HasForeignKey(t => t.ProviderId);
            // builder.HasMany(x => x.Skus)
            //     .WithOne()
            //     .HasForeignKey("CatalogItemId");
        }

        public void Configure(EntityTypeBuilder<Sku> sku)
        {
            sku.ToTable("skus");
            sku.HasOne<CatalogItem>()
                .WithMany(x => x.Skus)
                .HasForeignKey("catalog_item_id");
            sku.Property<int>("catalog_item_id");
        }
    }
}