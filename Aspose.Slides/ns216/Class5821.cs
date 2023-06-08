using ns215;

namespace ns216;

internal class Class5821 : Class5783
{
	internal static string Tag => "format";

	public Class5821()
	{
		Class5906.smethod_4(this, "use", string.Empty);
		Class5906.smethod_4(this, "usehref", string.Empty);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_84(this);
		base.vmethod_4(visitor);
		visitor.vmethod_85(this);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5821();
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
			Class5882.Tag
		};
	}
}
