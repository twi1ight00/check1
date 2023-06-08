using Aspose.XfaConverter.Elements;
using ns215;

namespace ns216;

internal class Class5835 : Class5783
{
	internal static string Tag => "pageSet";

	public Class5835()
	{
		Class5906.smethod_6(this, "relation", XfaEnums.Enum718.const_0);
		Class5906.smethod_4(this, "use", string.Empty);
		Class5906.smethod_4(this, "usehref", string.Empty);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_122(this);
		base.vmethod_4(visitor);
		visitor.vmethod_123(this);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5835();
	}

	internal override string vmethod_8()
	{
		return Tag;
	}

	internal override string[] vmethod_10()
	{
		return new string[4]
		{
			Class5816.Tag,
			Class5832.Tag,
			Class5834.Tag,
			Tag
		};
	}
}
