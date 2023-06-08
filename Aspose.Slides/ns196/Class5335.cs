using System.Text;
using ns176;
using ns187;
using ns205;

namespace ns196;

internal class Class5335 : Class5330
{
	private int int_0;

	public Class5335(Class5254 position, Class5046 space, Class5695 side, bool isFirst, bool isLast, Interface172 context)
		: base(position, space.vmethod_5().vmethod_3().method_3(context), side, space.method_15(), isFirst, isLast)
	{
		int num = space.vmethod_5().method_13().imethod_0();
		if (num == 53)
		{
			int_0 = int.MaxValue;
		}
		else
		{
			int_0 = (int)space.vmethod_5().method_13().vmethod_9();
		}
	}

	public bool method_9()
	{
		return int_0 == int.MaxValue;
	}

	public int method_10()
	{
		return int_0;
	}

	public override void vmethod_6(Class5746 effectiveLength)
	{
		Interface173 @interface = method_3();
		if (@interface is Interface184)
		{
			((Interface184)@interface).imethod_38(method_6(), effectiveLength);
		}
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder("Space[");
		stringBuilder.Append(base.ToString());
		stringBuilder.Append(", precedence=");
		if (method_9())
		{
			stringBuilder.Append("forcing");
		}
		else
		{
			stringBuilder.Append(method_10());
		}
		stringBuilder.Append("]");
		return stringBuilder.ToString();
	}
}
