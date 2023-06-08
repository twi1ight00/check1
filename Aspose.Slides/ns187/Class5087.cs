using System.Drawing;
using System.Text;
using ns171;
using ns175;
using ns176;
using ns195;

namespace ns187;

internal class Class5087
{
	private static Class5749 class5749_0 = new Class5749();

	private int int_0 = -1;

	private int int_1;

	private Color color_0;

	private Interface182 interface182_0;

	private Class5087(int style, Interface182 width, Color color)
	{
		int_1 = style;
		interface182_0 = width;
		color_0 = color;
	}

	public static Class5087 smethod_0(Class5634 pList)
	{
		Class5738 foUserAgent = pList.method_0().method_2();
		return smethod_1(pList.method_5(279).imethod_0(), pList.method_5(278).vmethod_0(), pList.method_5(280).vmethod_1(foUserAgent));
	}

	private static Class5087 smethod_1(int style, Interface182 width, Color color)
	{
		Class5087 @class = new Class5087(style, width, color);
		Class5087 class2 = (Class5087)class5749_0.method_0(@class);
		if (class2 == null)
		{
			return @class;
		}
		return class2;
	}

	public int method_0()
	{
		return int_1;
	}

	public Color method_1()
	{
		return color_0;
	}

	public Interface182 method_2()
	{
		return interface182_0;
	}

	public int method_3()
	{
		if (int_1 != 95 && int_1 != 57)
		{
			return interface182_0.imethod_5();
		}
		return 0;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder("Outline");
		stringBuilder.Append(" {");
		stringBuilder.Append(int_1);
		stringBuilder.Append(", ");
		stringBuilder.Append(color_0);
		stringBuilder.Append(", ");
		stringBuilder.Append(interface182_0);
		stringBuilder.Append("}");
		return stringBuilder.ToString();
	}

	public override bool Equals(object obj)
	{
		if (this == obj)
		{
			return true;
		}
		if (!(obj is Class5087 @class))
		{
			return false;
		}
		if (Class5721.smethod_0(color_0, @class.color_0) && int_1 == @class.int_1)
		{
			return Class5721.smethod_0(interface182_0, @class.interface182_0);
		}
		return false;
	}

	public override int GetHashCode()
	{
		if (int_0 == -1)
		{
			int num = 17;
			num = 629 + ((!color_0.IsEmpty) ? color_0.GetHashCode() : 0);
			num = 37 * num + int_1;
			num = 37 * num + ((interface182_0 != null) ? interface182_0.GetHashCode() : 0);
			int_0 = num;
		}
		return int_0;
	}
}
