using Aspose.XfaConverter.Elements;
using ns215;

namespace ns216;

internal class Class5801 : Class5783
{
	internal static string Tag => "connect";

	public Class5801()
	{
		Class5906.smethod_4(this, "connection", string.Empty);
		Class5906.smethod_6(this, "anchorType", XfaEnums.Enum697.const_0);
		Class5906.smethod_4(this, "ref", string.Empty);
		Class5906.smethod_4(this, "usage", string.Empty);
		Class5906.smethod_4(this, "use", string.Empty);
		Class5906.smethod_4(this, "usehref", string.Empty);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_38(this);
		base.vmethod_4(visitor);
		visitor.vmethod_39(this);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5801();
	}

	internal override string vmethod_8()
	{
		return Tag;
	}

	internal override string[] vmethod_10()
	{
		return new string[0];
	}
}
