using ns215;

namespace ns216;

internal class Class5847 : Class5783
{
	internal static string Tag => "stipple";

	public Class5847()
	{
		Class5906.smethod_2(this, "rate", 50);
		Class5906.smethod_4(this, "use", string.Empty);
		Class5906.smethod_4(this, "usehref", string.Empty);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_152(this);
		base.vmethod_4(visitor);
		visitor.vmethod_153(this);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5847();
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
