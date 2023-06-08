using System.Text;
using ns176;
using ns187;
using ns205;

namespace ns196;

internal class Class5333 : Class5332
{
	public Class5333(Class5254 position, Class5032 condLength, Class5695 side, bool isFirst, bool isLast, Interface172 context)
		: base(position, condLength, side, isFirst, isLast, context)
	{
	}

	public override void vmethod_6(Class5746 effectiveLength)
	{
		Interface173 @interface = method_3();
		if (@interface is Interface184)
		{
			((Interface184)@interface).imethod_39(method_6(), effectiveLength);
		}
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder("Border[");
		stringBuilder.Append(base.ToString());
		stringBuilder.Append("]");
		return stringBuilder.ToString();
	}
}
