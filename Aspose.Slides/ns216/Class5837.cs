using Aspose.XfaConverter.Elements;
using ns215;

namespace ns216;

internal class Class5837 : Class5783
{
	internal static string Tag => "passwordEdit";

	public Class5837()
	{
		Class5906.smethod_6(this, "hScrollPolicy", XfaEnums.Enum714.const_0);
		Class5906.smethod_4(this, "passwordChar", string.Empty);
		Class5906.smethod_4(this, "use", string.Empty);
		Class5906.smethod_4(this, "usehref", string.Empty);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_126(this);
		base.vmethod_4(visitor);
		visitor.vmethod_127(this);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5837();
	}

	internal override string vmethod_8()
	{
		return Tag;
	}

	internal override string[] vmethod_10()
	{
		return new string[3]
		{
			Class5790.Tag,
			Class5816.Tag,
			Class5829.Tag
		};
	}
}
