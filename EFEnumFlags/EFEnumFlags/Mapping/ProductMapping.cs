using EFEnumFlags.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEnumFlags.Mapping
{
	public class ProductMapping : EntityTypeConfiguration<Product>
	{
		public ProductMapping()
		{
			this.ToTable("T_Product");

			this.HasKey(p => p.Id);

			//this.HasRequired(p => p.WarrantyCard).WithRequiredDependent(c => c.Product);
			//this.HasRequired(p => p.WarrantyCard).WithOptional(c => c.Product);

			this.HasRequired(p => p.WarrantyCard).WithRequiredPrincipal(c => c.Product);
			this.HasOptional(p => p.WarrantyCard).WithRequired(p => p.Product);

			this.HasOptional(p => p.Invoice).WithMany().HasForeignKey(i => i.InvoiceId);
			this.HasRequired(p => p.Certification).WithMany().HasForeignKey(i => i.CertificationId);

			this.HasMany(p => p.ProductPhotos).WithRequired(pp => pp.Product).HasForeignKey(i => i.ProductId);

			this.HasMany(p => p.ProductTags).WithMany(p => p.Proudcts).Map(m => m.ToTable("T_Product_Tag_Mapping"));

			// TPT
			Map<PaperProduct>(p => p.ToTable("T_PaperProduct"));
		}
	}

	public class WarrantyCardMapping : EntityTypeConfiguration<WarrantyCard>
	{
		public WarrantyCardMapping()
		{
			this.ToTable("T_WarrantyCard");
			this.HasKey(p => p.ProductId);
		}
	}

	public class InvoiceMapping : EntityTypeConfiguration<Invoice>
	{
		public InvoiceMapping()
		{
			this.ToTable("T_Invoice");
			this.HasKey(p => p.Id);
		}
	}

	public class CertificationMapping : EntityTypeConfiguration<Certification>
	{
		public CertificationMapping()
		{
			this.ToTable("T_Certification");
			this.HasKey(p => p.Id);
		}
	}

	public class ProductPhotoMapping : EntityTypeConfiguration<ProductPhoto>
	{
		public ProductPhotoMapping()
		{
			this.ToTable("T_ProductPhoto");
			this.HasKey(p => p.Id);
		}
	}

	public class TagMapping : EntityTypeConfiguration<Tag>
	{
		public TagMapping()
		{
			this.ToTable("T_ProductTag");
			this.HasKey(p => p.Id);

		}
	}

}
