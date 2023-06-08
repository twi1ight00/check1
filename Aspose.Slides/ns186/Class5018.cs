using System.Collections;
using ns171;
using ns187;
using ns192;

namespace ns186;

internal class Class5018 : Class5003
{
	public override int imethod_0()
	{
		return 1;
	}

	public override bool imethod_3()
	{
		return true;
	}

	public override Class5024 imethod_2(Class5024[] args, Class5750 pInfo)
	{
		Class5094 @class = pInfo.method_3().method_0();
		int num = 0;
		if (args.Length == 0)
		{
			num = pInfo.method_4().method_0();
		}
		else
		{
			string name = args[0].vmethod_13();
			num = Class5735.smethod_3(name);
		}
		if (num != -1)
		{
			int num2 = -1;
			int num3 = 0;
			if (@class.vmethod_24() != 75)
			{
				do
				{
					@class = (Class5094)@class.method_4();
				}
				while (@class.vmethod_24() != 75 && @class.vmethod_24() != 53);
				if (@class.vmethod_24() != 75)
				{
					throw new Exception55("from-table-column() may only be used on fo:table-cell or its descendants.");
				}
				num2 = ((Class5157)@class).method_51();
				num3 = ((Class5157)@class).method_53();
			}
			else
			{
				num2 = pInfo.method_3().method_6(Enum679.const_77).vmethod_10()
					.imethod_5();
				num3 = pInfo.method_3().method_6(Enum679.const_252).vmethod_10()
					.imethod_5();
			}
			Class5156 class2 = ((Class5149)@class).vmethod_32();
			ArrayList arrayList = class2.method_57();
			Class5714 class3 = class2.imethod_3();
			if (arrayList == null)
			{
				return pInfo.method_3().vmethod_2(num, bTryInherit: false, bTryDefault: true);
			}
			if (class3.method_3(num2))
			{
				return ((Class5158)arrayList[num2 - 1]).method_61(num);
			}
			while (--num3 > 0 && !class3.method_3(++num2))
			{
			}
			if (class3.method_3(num2))
			{
				return ((Class5158)arrayList[num2 - 1]).method_61(num);
			}
			return pInfo.method_3().vmethod_2(num, bTryInherit: false, bTryDefault: true);
		}
		throw new Exception55("Incorrect parameter to from-table-column() function");
	}
}
