using Aspose.XfaConverter.Elements;
using ns215;

namespace ns216;

internal class Class5878 : Class5782
{
	internal static string Tag => "mdp";

	public Class5878()
	{
		Class5906.smethod_2(this, "permissions", 2);
		Class5906.smethod_6(this, "signatureType", XfaEnums.Enum735.const_0);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_108(this);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5878();
	}

	internal override string vmethod_8()
	{
		return Tag;
	}
}
