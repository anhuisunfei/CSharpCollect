using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 using EFEnumFlags.Entity;
using System.Data.Entity.ModelConfiguration;
namespace EFEnumFlags.Mapping
{
	public class PayrecordsMapping : EntityTypeConfiguration<Payrecords>
	{
		public PayrecordsMapping()
		{
			this.ToTable("t_Payrecords");
			this.HasKey(p => p.ID); 
		}
	}
}
