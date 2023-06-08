using Aspose.XfaConverter.Elements;
using ns215;

namespace ns216;

internal class Class5785 : Class5783
{
	internal static string Tag => "arc";

	public Class5785()
	{
		Class5906.smethod_6(this, "hand", XfaEnums.Enum680.const_0);
		Class5906.smethod_3(this, "circular", @default: false);
		Class5906.smethod_2(this, "startAngle", 0);
		Class5906.smethod_2(this, "sweepAngle", 360);
		Class5906.smethod_4(this, "use", string.Empty);
		Class5906.smethod_4(this, "usehref", string.Empty);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_1(this);
		base.vmethod_4(visitor);
		visitor.vmethod_2(this);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5785();
	}

	internal override string vmethod_8()
	{
		return Tag;
	}

	internal override string[] vmethod_10()
	{
		return new string[2]
		{
			Class5810.Tag,
			Class5818.Tag
		};
	}
}
