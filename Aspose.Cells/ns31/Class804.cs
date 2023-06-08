using System;
using System.Collections;
using System.Drawing;
using System.Runtime.CompilerServices;
using ns3;
using ns32;

namespace ns31;

internal class Class804 : IDisposable, Interface23
{
	private Class794 class794_0;

	private Class787 class787_0;

	private Enum76 enum76_0;

	private Class802 class802_0;

	private Class802 class802_1;

	internal ArrayList arrayList_0 = new ArrayList();

	internal bool bool_0;

	private bool bool_1 = true;

	private bool bool_2 = true;

	private bool bool_3;

	public Interface21 LegendEntries => class802_0;

	internal Class787 Chart => class787_0;

	internal Class804(Class787 class787_1, object object_0, Enum52 enum52_0)
	{
		class794_0 = new Class794(class787_1, object_0, enum52_0);
		class787_0 = class787_1;
		enum76_0 = Enum76.const_4;
		class802_0 = new Class802(class787_1);
		class802_1 = new Class802(class787_1);
	}

	[SpecialName]
	internal Class794 method_0()
	{
		return class794_0;
	}

	[SpecialName]
	public Interface14 imethod_0()
	{
		return class794_0;
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
	internal Class802 method_1()
	{
		return class802_1;
	}

	[SpecialName]
	internal Class802 method_2()
	{
		return class802_0;
	}

	internal int method_3(Class810 class810_0)
	{
		if (class802_1.Count == 0)
		{
			return class810_0.Points.Count;
		}
		return class810_0.Points.Count - class802_1.method_0();
	}

	internal bool method_4(int int_0)
	{
		if (class802_1.Count == 0)
		{
			return false;
		}
		Class803 @class = class802_1.method_3(int_0);
		if (@class != null && @class.IsDeleted)
		{
			return true;
		}
		return false;
	}

	[SpecialName]
	internal bool method_5()
	{
		return bool_1;
	}

	[SpecialName]
	internal void method_6(bool bool_4)
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
	internal int method_7()
	{
		if (class794_0.Font != null)
		{
			return Struct40.smethod_5(class794_0.method_17());
		}
		return 0;
	}

	[SpecialName]
	internal int method_8()
	{
		int num = 0;
		if (class794_0.Font != null)
		{
			return Struct40.smethod_5(class794_0.method_17() * 0.2f);
		}
		return 0;
	}

	[SpecialName]
	internal int method_9()
	{
		int num = 0;
		if (class794_0.Font != null)
		{
			num = Struct40.smethod_5(class794_0.method_17() * 0.2f);
			if (num < 4)
			{
				return 4;
			}
			return num;
		}
		return 0;
	}

	[SpecialName]
	internal int method_10()
	{
		int num = 0;
		float num2 = 0f;
		num2 = ((!(class794_0.Font.Size <= 6f)) ? 0.465f : 0.6f);
		if (class794_0.Font != null)
		{
			num = Struct40.smethod_5(class794_0.method_17() * num2);
			if (num < 3)
			{
				return 3;
			}
			return num;
		}
		return 0;
	}

	[SpecialName]
	internal int method_11()
	{
		if (method_15())
		{
			return 36;
		}
		return 27;
	}

	[SpecialName]
	internal SizeF method_12()
	{
		return new SizeF(method_11(), class794_0.method_17());
	}

	[SpecialName]
	internal float method_13()
	{
		float num = 0f;
		if (class794_0.Font != null)
		{
			num = class794_0.method_17() * 0.25f;
			if (num < 2f)
			{
				num = 2f;
			}
			return 0f - num;
		}
		return 0f;
	}

	[SpecialName]
	internal float method_14()
	{
		float num = 0f;
		float num2 = 0.01f;
		num2 = ((!(class794_0.Font.Size <= 6f)) ? (num2 + class794_0.Font.Size * 0.02f) : 0f);
		if (class794_0.Font != null)
		{
			num = class794_0.method_17() * num2;
			if (num > 10f)
			{
				num = 10f;
			}
			return 0f - num;
		}
		return 0f;
	}

	private bool method_15()
	{
		foreach (Class803 item in method_1())
		{
			if (item.Type == Enum56.const_0)
			{
				Class810 class2 = item.method_0();
				if (class2 != null && !item.IsDeleted && class2.method_28() && class2.method_6().LineStyle.DashStyle != Enum79.const_6)
				{
					return true;
				}
			}
			else
			{
				Class815 class3 = item.method_2();
				if (class3 != null && !item.IsDeleted && class3.method_0().LineStyle.DashStyle != Enum79.const_6)
				{
					return true;
				}
			}
		}
		return false;
	}

	~Class804()
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
			if (class794_0 != null)
			{
				class794_0.Dispose();
			}
			if (class802_1 != null)
			{
				foreach (Class803 item in class802_1)
				{
					item.Dispose();
				}
			}
			if (class802_0 != null)
			{
				foreach (Class803 item2 in class802_0)
				{
					item2.Dispose();
				}
			}
		}
		bool_3 = true;
	}
}
