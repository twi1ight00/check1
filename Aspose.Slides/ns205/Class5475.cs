using System.Drawing;
using System.Text;
using ns195;

namespace ns205;

internal class Class5475
{
	public int int_0;

	public Color color_0;

	public int int_1;

	public Class5475(int style, int width, Color color)
	{
		int_0 = style;
		int_1 = width;
		color_0 = color;
	}

	public override int GetHashCode()
	{
		return ToString().GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (obj == this)
		{
			return true;
		}
		if (obj is Class5475)
		{
			Class5475 @class = (Class5475)obj;
			if (int_0 == @class.int_0 && color_0.Equals(@class.color_0))
			{
				return int_1 == @class.int_1;
			}
			return false;
		}
		return false;
	}

	private string method_0()
	{
		return Class5443.smethod_1(int_0).method_0();
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append('(');
		stringBuilder.Append(method_0());
		stringBuilder.Append(',');
		stringBuilder.Append(Class5713.smethod_10(color_0));
		stringBuilder.Append(',');
		stringBuilder.Append(int_1);
		stringBuilder.Append(')');
		return stringBuilder.ToString();
	}
}
