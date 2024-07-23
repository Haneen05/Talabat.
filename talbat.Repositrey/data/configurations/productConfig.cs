using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using talbat.core.Entities;

namespace talbat.Repositrey.data.configurations
{
    public class productConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(p => p.productType)
                .WithMany()
                .HasForeignKey(p => p.productTypeId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(p => p.ProductBrand)
                .WithMany()
                .HasForeignKey(p => p.ProductBrandId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Property(x => x.PictureUrl).IsRequired();
            builder.Property(x => x.Name).IsRequired();

        }
    }
}
