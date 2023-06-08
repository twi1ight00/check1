using System;
using System.Collections;
using System.Drawing;
using System.Runtime.CompilerServices;
using ns3;
using ns34;

namespace ns33;

internal class Class838 : IDisposable, Interface23
{
	private Class829 class829_0;

	private Enum76 enum76_0;

	private Class836 class836_0;

	private Class836 class836_1;

	internal ArrayList arrayList_0 = new ArrayList();

	internal bool bool_0;

	private bool bool_1 = true;

	private bool bool_2 = true;

	private bool bool_3;

	public Interface21 LegendEntries => class836_0;

	internal Class838(Class821 class821_0, object object_0, Enum52 enum52_0)
	{
		class829_0 = new Class829(class821_0, object_0, Enum52.const_10, Enum57.const_12);
		enum76_0 = Enum76.const_4;
		class836_0 = new Class836(class821_0);
		class836_1 = new Class836(class821_0);
	}

	[SpecialName]
	internal Class829 method_0()
	{
		return class829_0;
	}

	[SpecialName]
	public Interface14 imethod_0()
	{
		return class829_0;
	}

	[SpecialName]
	public Enum76 vmethod_0()
	{
		return enum76_0;
	}

	[SpecialName]
	public void imethod_2(Enum76 enum76_1)
	{
		enum76_0 = enum76_1;
	}

	[SpecialName]
	internal Class836 method_1()
	{
		return class836_1;
	}

	[SpecialName]
	internal Class836 method_2()
	{
		return class836_0;
	}

	[SpecialName]
	internal bool method_3()
	{
		return bool_1;
	}

	[SpecialName]
	internal void method_4(bool bool_4)
	{
		bool_1 = bool_4;
	}

	[SpecialName]
	public bool vmethod_1()
	{
		return bool_2;
	}

	[SpecialName]
	public void imethod_1(bool bool_4)
	{
		bool_2 = bool_4;
	}

	[SpecialName]
	internal int method_5()
	{
		int num = 0;
		if (class829_0.Font != null)
		{
			return Struct63.smethod_5(class829_0.method_15() * 0.2f);
		}
		return 0;
	}

	[SpecialName]
	internal int method_6()
	{
		int num = 0;
		if (class829_0.Font != null)
		{
			num = Struct63.smethod_5(class829_0.method_15() * 0.2f);
			if (num < 4)
			{
				return 4;
			}
			return num;
		}
		return 0;
	}

	[SpecialName]
	internal int method_7()
	{
		int num = 0;
		float num2 = 0f;
		num2 = ((!(class829_0.Font.Size <= 6f)) ? 0.465f : 0.6f);
		if (class829_0.Font != null)
		{
			num = Struct63.smethod_5(class829_0.method_15() * num2);
			if (num < 3)
			{
				return 3;
			}
			return num;
		}
		return 0;
	}

	[SpecialName]
	internal int method_8()
	{
		if (method_12())
		{
			return 36;
		}
		return 27;
	}

	[SpecialName]
	internal SizeF method_9()
	{
		return new SizeF(method_8(), class829_0.method_15());
	}

	[SpecialName]
	internal float method_10()
	{
		float num = 0f;
		if (class829_0.Font != null)
		{
			num = class829_0.method_15() * 0.25f;
			if (num < 2f)
			{
				num = 2f;
			}
			return 0f - num;
		}
		return 0f;
	}

	[SpecialName]
	internal float method_11()
	{
		float num = 0f;
		float num2 = 0.01f;
		num2 = ((!(class829_0.Font.Size <= 6f)) ? (num2 + class829_0.Font.Size * 0.02f) : 0f);
		if (class829_0.Font != null)
		{
			num = class829_0.method_15() * num2;
			if (num > 10f)
			{
				num = 10f;
			}
			return 0f - num;
		}
		return 0f;
	}

	private bool method_12()
	{
		foreach (Class837 item in method_1())
		{
			if (item.Type == Enum56.const_0)
			{
				Class844 class2 = item.method_0();
				if (class2 != null && !item.IsDeleted && class2.method_27() && class2.method_5().method_0().DashStyle != Enum79.const_6)
				{
					return true;
				}
			}
			else
			{
				Class850 class3 = item.method_2();
				if (class3 != null && !item.IsDeleted && class3.method_1().method_0().DashStyle != Enum79.const_6)
				{
					return true;
				}
			}
		}
		return false;
	}

	~Class838()
	{
		Dispose(bool_4: false);
	}

	public void Dispose()
	{
		Dispose(bool_4: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool bool_4)
	{
		if (bool_3)
		{
			return;
		}
		if (bool_4)
		{
			if (class829_0 != null)
			{
				class829_0.Dispose();
			}
			if (class836_1 != null)
			{
				foreach (Class837 item in class836_1)
				{
					item.Dispose();
				}
			}
			if (class836_0 != null)
			{
				foreach (Class837 item2 in class836_0)
				{
					item2.Dispose();
				}
			}
		}
		bool_3 = true;
	}
}
