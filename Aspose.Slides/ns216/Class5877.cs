using Aspose.XfaConverter.Elements;
using ns215;

namespace ns216;

internal class Class5877 : Class5782
{
	internal static string Tag => "lockDocument";

	public Class5877()
	{
		Class5906.smethod_6(this, "type", XfaEnums.Enum692.const_0);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_103(this);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5877();
	}

	internal override string vmethod_8()
	{
		return Tag;
	}
}
