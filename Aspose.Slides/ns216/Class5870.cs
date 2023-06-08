using Aspose.XfaConverter.Elements;
using ns215;

namespace ns216;

internal class Class5870 : Class5782
{
	internal static string Tag => "execute";

	public Class5870()
	{
		Class5906.smethod_4(this, "connection", string.Empty);
		Class5906.smethod_4(this, "use", string.Empty);
		Class5906.smethod_4(this, "usehref", string.Empty);
		Class5906.smethod_6(this, "executeType", XfaEnums.Enum732.const_0);
		Class5906.smethod_6(this, "runAt", XfaEnums.Enum733.const_0);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_70(this);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5870();
	}

	internal override string vmethod_8()
	{
		return Tag;
	}
}
