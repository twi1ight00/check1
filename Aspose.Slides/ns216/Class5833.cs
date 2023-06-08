using Aspose.XfaConverter.Elements;
using ns215;

namespace ns216;

internal class Class5833 : Class5783
{
	internal static string Tag => "oids";

	public Class5833()
	{
		Class5906.smethod_6(this, "type", XfaEnums.Enum692.const_0);
		Class5906.smethod_4(this, "use", string.Empty);
		Class5906.smethod_4(this, "usehref", string.Empty);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_117(this);
		base.vmethod_4(visitor);
		visitor.vmethod_118(this);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5833();
	}

	internal override string vmethod_8()
	{
		return Tag;
	}

	internal override string[] vmethod_10()
	{
		return new string[1] { Class5880.Tag };
	}
}
