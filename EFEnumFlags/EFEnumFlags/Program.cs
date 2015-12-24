using EFEnumFlags.Entity;
using EFEnumFlags.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
namespace EFEnumFlags
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var context = new PayContext())
			{
				// context.Database.Log = Console.WriteLine;
				//var payRecords1 = new Payrecords
				//{
				//	PayDate = DateTime.Now,
				//	PayType = PayType.BaiDu
				//};
				//var payRecords2 = new Payrecords
				//{
				//	PayDate = DateTime.Now,
				//	PayType = PayType.WebChat | PayType.CreditCard | PayType.BaiDu | PayType.DebitCard
				//};

				////var payRecords3 = new Payrecords
				////{
				////	PayDate = DateTime.Now,
				////	PayType = PayType.DebitCard
				////};
				////context.Set<Payrecords>().Add(payRecords1);
				//context.Set<Payrecords>().Add(payRecords2);
				////context.Set<Payrecords>().Add(payRecords3);

				//var i = context.SaveChanges();
				////Console.WriteLine(i);

				//var list = context.Set<Payrecords>().Where(p => p.PayType == PayType.WebChat).ToList();
				//list = context.Set<Payrecords>().ToList();
				//list = context.Set<Payrecords>().Where(p => (p.PayType & PayType.WebChat) != 0).ToList();
				//foreach (var item in list)
				//{
				//	Console.WriteLine("{0}\t{1}\t{2}", item.ID, item.PayType, item.PayDate);
				//}
				context.Database.Log = Console.WriteLine;
				//var dbSet = context.Set<Payrecords>();
				//var aa = (from p in dbSet
				//		  select p)
				//		  .Union(
				//		  from p in dbSet
				//		  select p
				//		  ).ToList();


				//var Product = new Product
				//{
				//	Name = "苹果6S",
				//	Description = "手机",
				//	WarrantyCard = new WarrantyCard
				//	{
				//		ExpiredDate = DateTime.Now.AddYears(1)
				//	}
				//};

				//context.Set<Product>().Add(Product);
				//context.SaveChanges();
				//var entity = context.Set<Product>().Find(1);
				//entity.Invoice = new Invoice
				//{
				//	CreateDate = DateTime.Now,
				//	InvoiceNo = "20151224001"
				//};
				//context.SaveChanges();
				// var list = context.Set<Product>().ToList();
				//context.Set<Product>().Include(p => p.Invoice).Include(p => p.Certification).FirstOrDefault();
				context.Set<Product>().ToList();
				Console.ReadKey();
			}
		}
	}
}
