using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEnumFlags.Entity
{
	public class Product
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public virtual WarrantyCard WarrantyCard { get; set; }

		public virtual Invoice Invoice { get; set; }
		public int? InvoiceId { get; set; }

		public virtual Certification Certification { get; set; }
		public int CertificationId { get; set; }

		public virtual ICollection<ProductPhoto> ProductPhotos { get; set; }
		public virtual ICollection<Tag> ProductTags { get; set; }
	}

	public class WarrantyCard
	{
		public int ProductId { get; set; }
		public DateTime ExpiredDate { get; set; }
		public virtual Product Product { get; set; }
	}
}
