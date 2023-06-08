using System.Collections;
using System.Drawing;

namespace ns44;

internal class Class1332 : CollectionBase
{
	public Class1331 this[int int_0] => (Class1331)base.InnerList[int_0];

	public int Add(Class1331 class1331_0)
	{
		base.InnerList.Add(class1331_0);
		return base.Count - 1;
	}

	internal int method_0(Enum196 enum196_0, int int_0)
	{
		Class1331 value = new Class1331(enum196_0, int_0);
		base.InnerList.Add(value);
		return base.Count - 1;
	}

	internal void method_1(Enum196 enum196_0, int int_0)
	{
		int num = 0;
		while (true)
		{
			if (num < base.Count)
			{
				if (this[num].enum196_0 == enum196_0)
				{
					break;
				}
				num++;
				continue;
			}
			Class1331 value = new Class1331(enum196_0, int_0);
			base.InnerList.Add(value);
			return;
		}
		this[num].int_0 = int_0;
	}

	internal int method_2(Enum196 enum196_0)
	{
		int num = 0;
		while (true)
		{
			if (num < base.Count)
			{
				if (this[num].enum196_0 == enum196_0)
				{
					break;
				}
				num++;
				continue;
			}
			return 0;
		}
		return this[num].int_0;
	}

	internal Color method_3(Color color_0, bool bool_0)
	{
		if (!bool_0)
		{
			int num = method_2(Enum196.const_0);
			return Class1336.smethod_2(color_0, (double)num / 100000.0);
		}
		for (int i = 0; i < base.Count; i++)
		{
			Class1331 @class = this[i];
			switch (@class.enum196_0)
			{
			case Enum196.const_0:
				color_0 = Class1336.smethod_0(color_0, (double)@class.int_0 / 100000.0);
				break;
			case Enum196.const_1:
				color_0 = Class1336.smethod_1(color_0, (double)@class.int_0 / 100000.0);
				break;
			case Enum196.const_2:
				color_0 = Class1336.smethod_3(color_0, (double)@class.int_0 / 100000.0);
				break;
			case Enum196.const_3:
				color_0 = Class1336.smethod_4(color_0, (double)@class.int_0 / 100000.0);
				break;
			case Enum196.const_4:
				color_0 = Class1336.smethod_5(color_0, (double)@class.int_0 / 100000.0);
				break;
			case Enum196.const_5:
				color_0 = Class1336.smethod_6(color_0, (double)@class.int_0 / 100000.0);
				break;
			case Enum196.const_6:
				color_0 = Class1336.smethod_7(color_0, (double)@class.int_0 / 100000.0);
				break;
			case Enum196.const_7:
				color_0 = Class1336.smethod_8(color_0, (double)@class.int_0 / 100000.0);
				break;
			case Enum196.const_8:
				color_0 = Class1336.smethod_9(color_0, (double)@class.int_0 / 100000.0);
				break;
			case Enum196.const_9:
				color_0 = Class1336.smethod_10(color_0, (double)@class.int_0 / 100000.0);
				break;
			case Enum196.const_10:
				color_0 = Class1336.smethod_11(color_0, (double)@class.int_0 / 100000.0);
				break;
			case Enum196.const_11:
				color_0 = Class1336.smethod_12(color_0, (double)@class.int_0 / 100000.0);
				break;
			case Enum196.const_12:
				color_0 = Class1336.smethod_13(color_0, (double)@class.int_0 / 100000.0);
				break;
			case Enum196.const_13:
				color_0 = Class1336.smethod_14(color_0, (double)@class.int_0 / 100000.0);
				break;
			case Enum196.const_14:
				color_0 = Class1336.smethod_19(color_0, (double)@class.int_0 / 60000.0);
				break;
			case Enum196.const_15:
				color_0 = Class1336.smethod_20(color_0, (double)@class.int_0 / 100000.0);
				break;
			case Enum196.const_16:
				color_0 = Class1336.smethod_21(color_0, (double)@class.int_0 / 60000.0);
				break;
			case Enum196.const_17:
				color_0 = Class1336.smethod_22(color_0, (double)@class.int_0 / 100000.0);
				break;
			case Enum196.const_18:
				color_0 = Class1336.smethod_23(color_0, (double)@class.int_0 / 100000.0);
				break;
			case Enum196.const_19:
				color_0 = Class1336.smethod_24(color_0, (double)@class.int_0 / 100000.0);
				break;
			case Enum196.const_20:
				color_0 = Class1336.smethod_25(color_0, (double)@class.int_0 / 100000.0);
				break;
			case Enum196.const_21:
				color_0 = Class1336.smethod_26(color_0, (double)@class.int_0 / 100000.0);
				break;
			case Enum196.const_22:
				color_0 = Class1336.smethod_27(color_0, (double)@class.int_0 / 100000.0);
				break;
			case Enum196.const_23:
				color_0 = Class1336.smethod_28(color_0);
				break;
			case Enum196.const_24:
				color_0 = Class1336.smethod_29(color_0);
				break;
			case Enum196.const_25:
				color_0 = Class1336.smethod_15(color_0);
				break;
			case Enum196.const_26:
				color_0 = Class1336.smethod_30(color_0);
				break;
			case Enum196.const_27:
				color_0 = Class1336.smethod_16(color_0);
				break;
			}
		}
		return color_0;
	}

	internal void Copy(Class1332 class1332_0)
	{
		for (int i = 0; i < class1332_0.Count; i++)
		{
			Class1331 @class = class1332_0[i];
			method_0(@class.enum196_0, @class.int_0);
		}
	}

	internal bool method_4(Class1332 class1332_0)
	{
		if (base.Count == class1332_0.Count)
		{
			int num = 0;
			while (true)
			{
				if (num < base.Count)
				{
					Class1331 @class = this[num];
					if (@class.int_0 != class1332_0.method_2(@class.enum196_0))
					{
						break;
					}
					num++;
					continue;
				}
				return true;
			}
			return false;
		}
		return false;
	}

	internal Class1331 method_5(Enum196 enum196_0)
	{
		int num = 0;
		while (true)
		{
			if (num < base.Count)
			{
				if (this[num].enum196_0 == enum196_0)
				{
					break;
				}
				num++;
				continue;
			}
			return null;
		}
		return this[num];
	}
}
