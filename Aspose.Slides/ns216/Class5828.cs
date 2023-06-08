using Aspose.XfaConverter.Elements;
using ns215;

namespace ns216;

internal class Class5828 : Class5783
{
	internal static string Tag => "manifest";

	public Class5828()
	{
		Class5906.smethod_6(this, "action", XfaEnums.Enum713.const_0);
		Class5906.smethod_4(this, "use", string.Empty);
		Class5906.smethod_4(this, "usehref", string.Empty);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_104(this);
		base.vmethod_4(visitor);
		visitor.vmethod_105(this);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5828();
	}

	internal override string vmethod_8()
	{
		return Tag;
	}

	internal override string[] vmethod_10()
	{
		return new string[2]
		{
			Class5816.Tag,
			Class5884.Tag
		};
	}
}
