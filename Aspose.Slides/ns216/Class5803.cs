using Aspose.XfaConverter.Elements;
using ns215;

namespace ns216;

internal class Class5803 : Class5783
{
	internal static string Tag => "corner";

	public Class5803()
	{
		Class5906.smethod_3(this, "inverted", @default: false);
		Class5906.smethod_6(this, "join", XfaEnums.Enum698.const_0);
		Class5906.smethod_6(this, "presence", XfaEnums.Enum687.const_0);
		Class5906.smethod_1(this, "radius", 0f);
		Class5906.smethod_6(this, "stroke", XfaEnums.Enum699.const_0);
		Class5906.smethod_1(this, "thickness", 0.5f);
		Class5906.smethod_4(this, "use", string.Empty);
		Class5906.smethod_4(this, "usehref", string.Empty);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_42(this);
		base.vmethod_4(visitor);
		visitor.vmethod_43(this);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5803();
	}

	internal override string vmethod_8()
	{
		return Tag;
	}

	internal override string[] vmethod_10()
	{
		return new string[2]
		{
			Class5800.Tag,
			Class5816.Tag
		};
	}
}
