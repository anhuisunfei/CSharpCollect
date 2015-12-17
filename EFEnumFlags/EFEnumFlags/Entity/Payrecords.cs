using EFEnumFlags.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEnumFlags.Entity
{
	public class Payrecords
	{
		public int ID { get; set; }
		public PayType PayType { get; set; }
		public DateTime PayDate { get; set; }
	}
}
