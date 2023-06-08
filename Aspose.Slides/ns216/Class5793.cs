using Aspose.XfaConverter.Elements;
using ns215;

namespace ns216;

internal class Class5793 : Class5783
{
	internal static string Tag => "breakBefore";

	public Class5793()
	{
		Class5906.smethod_4(this, "leader", string.Empty);
		Class5906.smethod_3(this, "startNew", @default: false);
		Class5906.smethod_4(this, "target", string.Empty);
		Class5906.smethod_4(this, "trailer", string.Empty);
		Class5906.smethod_6(this, "targetType", XfaEnums.Enum688.const_0);
		Class5906.smethod_4(this, "use", string.Empty);
		Class5906.smethod_4(this, "usehref", string.Empty);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_20(this);
		base.vmethod_4(visitor);
		visitor.vmethod_21(this);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5793();
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
