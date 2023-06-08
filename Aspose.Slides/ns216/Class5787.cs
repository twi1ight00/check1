using ns215;

namespace ns216;

internal class Class5787 : Class5783
{
	internal static string Tag => "assist";

	public Class5787()
	{
		Class5906.smethod_4(this, "role", string.Empty);
		Class5906.smethod_4(this, "use", string.Empty);
		Class5906.smethod_4(this, "usehref", string.Empty);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_5(this);
		base.vmethod_4(visitor);
		visitor.vmethod_6(this);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5787();
	}

	internal override string vmethod_8()
	{
		return Tag;
	}

	internal override string[] vmethod_10()
	{
		return new string[2]
		{
			Class5887.Tag,
			Class5892.Tag
		};
	}
}
