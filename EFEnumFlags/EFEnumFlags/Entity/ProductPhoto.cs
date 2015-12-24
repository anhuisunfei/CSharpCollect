using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEnumFlags.Entity
{
	public class ProductPhoto
	{
		public int Id { get; set; }
		public string FileName { get; set; }
		public float FileSize { get; set; }
		public virtual Product Product { get; set; }
		public int ProductId { get; set; }
	}
}
