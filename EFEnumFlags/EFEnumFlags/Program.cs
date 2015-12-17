using EFEnumFlags.Entity;
using EFEnumFlags.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
				var payRecords2 = new Payrecords
				{
					PayDate = DateTime.Now,
					PayType = PayType.WebChat | PayType.CreditCard | PayType.BaiDu | PayType.DebitCard
				};

				//var payRecords3 = new Payrecords
				//{
				//	PayDate = DateTime.Now,
				//	PayType = PayType.DebitCard
				//};
				//context.Set<Payrecords>().Add(payRecords1);
				context.Set<Payrecords>().Add(payRecords2);
				//context.Set<Payrecords>().Add(payRecords3);

				var i = context.SaveChanges();
				//Console.WriteLine(i);

				var list = context.Set<Payrecords>().Where(p => p.PayType == PayType.WebChat).ToList();
				list = context.Set<Payrecords>().ToList();
				list = context.Set<Payrecords>().Where(p => (p.PayType & PayType.WebChat) != 0).ToList();
				foreach (var item in list)
				{
					Console.WriteLine("{0}\t{1}\t{2}", item.ID, item.PayType, item.PayDate);
				}
				Console.ReadKey();
			}
		}
	}
}
