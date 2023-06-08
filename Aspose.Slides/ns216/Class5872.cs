using Aspose.XfaConverter.Elements;
using ns215;

namespace ns216;

internal class Class5872 : Class5782
{
	internal static string Tag => "handler";

	public Class5872()
	{
		Class5906.smethod_6(this, "type", XfaEnums.Enum692.const_0);
		Class5906.smethod_4(this, "use", string.Empty);
		Class5906.smethod_4(this, "usehref", string.Empty);
		Class5906.smethod_4(this, "version", string.Empty);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_86(this);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5872();
	}

	internal override string vmethod_8()
	{
		return Tag;
	}
}
