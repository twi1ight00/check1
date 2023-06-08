using Aspose.XfaConverter.Elements;
using ns215;

namespace ns216;

internal class Class5795 : Class5783
{
	internal static string Tag => "calculate";

	public Class5795()
	{
		Class5906.smethod_6(this, "override", XfaEnums.Enum690.const_0);
		Class5906.smethod_4(this, "use", string.Empty);
		Class5906.smethod_4(this, "usehref", string.Empty);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_24(this);
		base.vmethod_4(visitor);
		visitor.vmethod_25(this);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5795();
	}

	internal override string vmethod_8()
	{
		return Tag;
	}

	internal override string[] vmethod_10()
	{
		return new string[1] { Class5885.Tag };
	}
}
