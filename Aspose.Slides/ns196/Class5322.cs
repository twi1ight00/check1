using System;
using ns173;
using ns182;
using ns190;
using ns198;

namespace ns196;

internal class Class5322 : Class5320
{
	private Class5691 class5691_0;

	public Class5322(Class4872 ath, Class5127 pseq)
		: base(ath, pseq)
	{
		class5691_0 = new Class5691(ath, pseq);
	}

	public Class5691 method_34()
	{
		return class5691_0;
	}

	internal Class5127 method_35()
	{
		return (Class5127)class5125_0;
	}

	public override Class5322 imethod_4()
	{
		return this;
	}

	public override void imethod_27()
	{
		imethod_3();
		if (class4872_0.method_4())
		{
			Class5433.smethod_0(method_35());
		}
		Class4972 title = null;
		if (method_35().method_55() != null)
		{
			try
			{
				Class5323 @class = method_24().imethod_5(this, method_35().method_55());
				title = (Class4972)@class.imethod_7(null);
			}
			catch (InvalidOperationException)
			{
			}
		}
		Class4979 class2 = class4872_0.method_1();
		Class4975 class3 = new Class4975(title);
		method_20(class3);
		class3.method_16(method_35().method_65());
		class3.method_18(method_35().method_64());
		class2.vmethod_0(class3);
		class5690_0 = vmethod_3(isBlank: false);
		Class5272 class4 = new Class5272(this);
		int flowBPD = method_15().method_32().method_51();
		class4.method_7(flowBPD);
		vmethod_4();
	}

	public override void imethod_29()
	{
		if (class5125_0.method_39())
		{
			class5494_0.method_2(class5125_0.vmethod_31());
		}
		class5125_0.vmethod_20().method_54(int_2, int_2 - int_3 + 1);
		class4872_0.method_8(class5125_0, int_2 - int_3 + 1);
		method_35().method_66();
		string masterName = method_35().method_63();
		class5125_0.vmethod_20().method_57().method_54(masterName)?.method_51();
	}

	protected override Class5690 vmethod_2(int pageNumber, bool isBlank)
	{
		return class5691_0.method_9(isBlank, pageNumber, Class5691.int_0);
	}

	public override Class5690 vmethod_3(bool isBlank)
	{
		Class5690 @class = base.vmethod_3(isBlank);
		if (!isBlank)
		{
			while (!method_35().method_56().method_48().Equals(@class.method_0().method_51(58).method_53()))
			{
				@class = base.vmethod_3(isBlank);
			}
		}
		return @class;
	}

	private void method_36(int regionID)
	{
		Class5136 @class = (Class5136)class5690_0.method_0().method_51(regionID);
		if (@class != null)
		{
			Class5129 class2 = method_35().method_54(@class.method_53());
			if (class2 != null)
			{
				Class5295 class3 = method_24().imethod_6(this, class2, @class);
				class3.method_53();
			}
		}
	}

	protected override void vmethod_4()
	{
		method_36(57);
		method_36(56);
		method_36(61);
		method_36(59);
		base.vmethod_4();
	}

	internal int method_37(int lastPageNum)
	{
		int num = lastPageNum;
		if (lastPageNum % 2 != 0 && (method_35().method_51() == 43 || method_35().method_51() == 40))
		{
			num++;
		}
		else if (lastPageNum % 2 == 0 && (method_35().method_51() == 99 || method_35().method_51() == 41))
		{
			num++;
		}
		return num;
	}
}
