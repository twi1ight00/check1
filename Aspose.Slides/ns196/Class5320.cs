using System;
using System.Collections;
using ns173;
using ns176;
using ns189;
using ns190;

namespace ns196;

internal abstract class Class5320 : Class5280, Interface227
{
	protected Class4872 class4872_0;

	protected Class5494 class5494_0;

	protected Class5125 class5125_0;

	protected Class5690 class5690_0;

	protected int int_2;

	protected int int_3;

	public Class5320(Class4872 ath, Class5125 pseq)
		: base(pseq)
	{
		class4872_0 = ath;
		class5494_0 = ath.method_3();
		class5125_0 = pseq;
	}

	public Interface186 method_24()
	{
		return class4872_0.method_2();
	}

	public override Class5690 vmethod_0()
	{
		return class5690_0;
	}

	internal void method_25(Class5690 currentPage)
	{
		class5690_0 = currentPage;
	}

	internal int method_26()
	{
		return int_2;
	}

	public override void imethod_3()
	{
		int_3 = class5125_0.method_49();
		int_2 = int_3 - 1;
	}

	public Class4974 method_27(string idref)
	{
		ArrayList arrayList = class5494_0.method_6(idref);
		if (arrayList != null && arrayList.Count > 0)
		{
			return (Class4974)arrayList[0];
		}
		return null;
	}

	public Class4974 method_28(string idref)
	{
		ArrayList arrayList = class5494_0.method_6(idref);
		if (arrayList != null && arrayList.Count > 0)
		{
			return (Class4974)arrayList[arrayList.Count - 1];
		}
		return null;
	}

	public void method_29(string id)
	{
		if (id != null && id.Length > 0)
		{
			class5494_0.method_0(id, class5690_0.method_1());
		}
	}

	public bool method_30(string id)
	{
		if (!class5494_0.method_3(id))
		{
			class5494_0.method_1(id);
			return false;
		}
		return true;
	}

	public void method_31(string id)
	{
		class5494_0.method_2(id);
	}

	public void method_32(string id, Interface160 res)
	{
		class5690_0.method_1().method_22(id, res);
		class5494_0.method_9(id, class5690_0.method_1());
	}

	public Class5105 method_33(Class5105 rm)
	{
		Class4979 @class = class4872_0.method_1();
		string name = rm.method_55();
		int pos = rm.method_56();
		int num = rm.method_57();
		Class5108 class2 = method_15().method_24(name, pos);
		if (class2 == null && num != 104)
		{
			bool flag = num == 34;
			int num2 = @class.method_1();
			int num3 = @class.method_2(num2) - 1;
			while (num3 < 0 && flag && num2 > 1)
			{
				num2--;
				num3 = @class.method_2(num2) - 1;
			}
			while (num3 >= 0)
			{
				Class4974 class3 = @class.method_3(num2, num3);
				class2 = class3.method_24(name, 74);
				if (class2 != null)
				{
					break;
				}
				num3--;
				if (num3 < 0 && flag && num2 > 1)
				{
					num2--;
					num3 = @class.method_2(num2) - 1;
				}
			}
		}
		if (class2 == null)
		{
			return null;
		}
		rm.method_54(class2);
		return rm;
	}

	protected abstract Class5690 vmethod_2(int pageNumber, bool isBlank);

	public virtual Class5690 vmethod_3(bool isBlank)
	{
		if (class5690_0 != null)
		{
			vmethod_4();
		}
		int_2++;
		class5690_0 = vmethod_2(int_2, isBlank);
		method_29(class5125_0.vmethod_20().vmethod_31());
		method_29(class5125_0.vmethod_31());
		return class5690_0;
	}

	protected virtual void vmethod_4()
	{
		class5494_0.method_5(class5690_0.method_1());
		class4872_0.method_1().vmethod_1(class5690_0.method_1());
		class5690_0 = null;
	}

	public abstract void imethod_27();

	public void imethod_28(Interface181 nextPageSeqInitialPageNumber)
	{
		int num = class5125_0.method_51();
		if (nextPageSeqInitialPageNumber != null && num == 9)
		{
			if (nextPageSeqInitialPageNumber.imethod_0() != 0)
			{
				num = nextPageSeqInitialPageNumber.imethod_0() switch
				{
					11 => 40, 
					10 => 41, 
					_ => 88, 
				};
			}
			else
			{
				int num2 = nextPageSeqInitialPageNumber.imethod_5();
				num2 = ((num2 <= 0) ? 1 : num2);
				num = ((num2 % 2 != 0) ? 40 : 41);
			}
		}
		switch (num)
		{
		case 43:
			if ((int_2 - int_3 + 1) % 2 != 0)
			{
				class5690_0 = vmethod_3(isBlank: true);
			}
			break;
		case 99:
			if ((int_2 - int_3 + 1) % 2 == 0)
			{
				class5690_0 = vmethod_3(isBlank: true);
			}
			break;
		case 40:
			if (int_2 % 2 != 0)
			{
				class5690_0 = vmethod_3(isBlank: true);
			}
			break;
		case 41:
			if (int_2 % 2 == 0)
			{
				class5690_0 = vmethod_3(isBlank: true);
			}
			break;
		}
		if (class5690_0 != null)
		{
			vmethod_4();
		}
	}

	public abstract void imethod_29();

	public override void imethod_23()
	{
		throw new InvalidOperationException();
	}
}
