using ns215;

namespace ns216;

internal class Class5853 : Class5783
{
	internal static string Tag => "traversal";

	public Class5853()
	{
		Class5906.smethod_4(this, "use", string.Empty);
		Class5906.smethod_4(this, "usehref", string.Empty);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_169(this);
		base.vmethod_4(visitor);
		visitor.vmethod_170(this);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5853();
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
			Class5854.Tag
		};
	}
}
