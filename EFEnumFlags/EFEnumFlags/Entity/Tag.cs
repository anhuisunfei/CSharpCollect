using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEnumFlags.Entity
{
	public class Tag
	{
		public int Id { get; set; }
		public string Text { get; set; }
		public virtual ICollection<Product> Proudcts { get; set; }
	}
}
