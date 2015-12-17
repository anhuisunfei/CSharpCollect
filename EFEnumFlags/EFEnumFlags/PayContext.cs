using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EFEnumFlags
{
	public class PayContext : DbContext
	{
		static PayContext()
		{
			Database.SetInitializer(new DropCreateDatabaseIfModelChanges<PayContext>());
		}

		public PayContext()
			: base("EfConnection")
		{

		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
				.Where(type => !String.IsNullOrEmpty(type.Namespace))
				.Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
			foreach (var type in typesToRegister)
			{
				dynamic configurationInstance = Activator.CreateInstance(type);
				modelBuilder.Configurations.Add(configurationInstance);
			}
			base.OnModelCreating(modelBuilder);
		}
	}
}
