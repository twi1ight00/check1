using ns215;

namespace ns216;

internal class Class5819 : Class5783
{
	internal static string Tag => "filter";

	public Class5819()
	{
		Class5906.smethod_4(this, "addRevocationInfo", string.Empty);
		Class5906.smethod_4(this, "version", string.Empty);
		Class5906.smethod_4(this, "use", string.Empty);
		Class5906.smethod_4(this, "usehref", string.Empty);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_79(this);
		base.vmethod_4(visitor);
		visitor.vmethod_80(this);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5819();
	}

	internal override string vmethod_8()
	{
		return Tag;
	}

	internal override string[] vmethod_10()
	{
		return new string[9]
		{
			Class5858.Tag,
			Class5797.Tag,
			Class5867.Tag,
			Class5811.Tag,
			Class5872.Tag,
			Class5877.Tag,
			Class5878.Tag,
			Class5841.Tag,
			Class5891.Tag
		};
	}
}
