using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEnumFlags.Enum
{
	[Flags]
	public enum PayType
	{
		[Description("Points")]
		Points = 0x001,
		[Description("CreditCard")]
		CreditCard = 0x002,
		[Description("DebitCard")]
		DebitCard = 0x004,
		[Description("Alipay")]
		Alipay = 0x008,
		[Description("WebChat")]
		WebChat = 0x0010,
		[Description("BaiDu")]
		BaiDu = 0x0020

	}
}
