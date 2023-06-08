using System.Text;
using ns176;
using ns187;
using ns205;

namespace ns196;

internal class Class5331 : Class5330
{
	public Class5331(Class5254 position, Class5034 condLength, Class5695 side, bool isFirst, bool isLast, Interface172 context)
		: base(position, Class5746.smethod_1(condLength.vmethod_0().imethod_6(context)), side, conditional: true, isFirst, isLast)
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
		StringBuilder stringBuilder = new StringBuilder("Outline[");
		stringBuilder.Append(base.ToString());
		stringBuilder.Append("]");
		return stringBuilder.ToString();
	}
}
