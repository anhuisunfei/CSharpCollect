using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEnumFlags.Entity
{
	public class Invoice
	{
		public int Id { get; set; }
		public string InvoiceNo { get; set; } 
		public DateTime CreateDate { get; set; }
	}
}
