using System.Collections;
using System.Drawing;
using ns171;
using ns175;
using ns186;

namespace ns187;

internal class Class5720
{
	private static int int_0 = 1;

	private static int int_1 = 2;

	private static int int_2 = 4;

	private static int int_3 = 8;

	private int int_4;

	private Color color_0;

	private Color color_1;

	private Color color_2;

	public static Class5720 smethod_0(Class5634 pList)
	{
		return smethod_1(pList);
	}

	private static Class5720 smethod_1(Class5634 pList)
	{
		Class5720 @class = null;
		Class5634 class2 = pList.method_2();
		if (class2 != null)
		{
			@class = smethod_1(class2);
		}
		Class5024 class3 = pList.vmethod_0(248);
		if (class3 != null)
		{
			ArrayList arrayList = class3.vmethod_8();
			foreach (Class5024 item in arrayList)
			{
				int num = item.imethod_0();
				Class5738 foUserAgent = ((pList == null) ? null : ((pList.method_0() == null) ? null : pList.method_0().method_2()));
				switch (num)
				{
				case 153:
					if (@class == null)
					{
						@class = new Class5720();
					}
					@class.int_4 |= int_0;
					@class.color_0 = pList.method_5(72).vmethod_1(foUserAgent);
					break;
				case 92:
					if (@class != null)
					{
						@class.int_4 &= int_1 | int_2 | int_3;
						@class.color_0 = pList.method_5(72).vmethod_1(foUserAgent);
					}
					break;
				case 103:
					if (@class == null)
					{
						@class = new Class5720();
					}
					@class.int_4 |= int_1;
					@class.color_1 = pList.method_5(72).vmethod_1(foUserAgent);
					break;
				case 91:
					if (@class != null)
					{
						@class.int_4 &= int_0 | int_2 | int_3;
						@class.color_1 = pList.method_5(72).vmethod_1(foUserAgent);
					}
					break;
				case 77:
					if (@class == null)
					{
						@class = new Class5720();
					}
					@class.int_4 |= int_2;
					@class.color_2 = pList.method_5(72).vmethod_1(foUserAgent);
					break;
				case 90:
					if (@class != null)
					{
						@class.int_4 &= int_0 | int_1 | int_3;
						@class.color_2 = pList.method_5(72).vmethod_1(foUserAgent);
					}
					break;
				case 17:
					if (@class == null)
					{
						@class = new Class5720();
					}
					@class.int_4 |= int_3;
					break;
				case 86:
					if (@class != null)
					{
						@class.int_4 &= int_0 | int_1 | int_2;
					}
					break;
				case 95:
					if (@class != null)
					{
						@class.int_4 = 0;
					}
					return @class;
				default:
					throw new Exception55("Illegal value encountered: " + item.vmethod_13());
				}
			}
		}
		return @class;
	}

	public bool method_0()
	{
		return (int_4 & int_0) != 0;
	}

	public bool method_1()
	{
		return (int_4 & int_1) != 0;
	}

	public bool method_2()
	{
		return (int_4 & int_2) != 0;
	}

	public bool method_3()
	{
		return (int_4 & int_3) != 0;
	}

	public Color method_4()
	{
		return color_0;
	}

	public Color method_5()
	{
		return color_1;
	}

	public Color method_6()
	{
		return color_2;
	}
}
