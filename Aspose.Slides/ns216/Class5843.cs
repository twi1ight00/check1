using ns215;

namespace ns216;

internal class Class5843 : Class5783
{
	internal static string Tag => "signature";

	public Class5843()
	{
		Class5906.smethod_4(this, "type", string.Empty);
		Class5906.smethod_4(this, "use", string.Empty);
		Class5906.smethod_4(this, "usehref", string.Empty);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_143(this);
		base.vmethod_4(visitor);
		visitor.vmethod_144(this);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5843();
	}

	internal override string vmethod_8()
	{
		return Tag;
	}

	internal override string[] vmethod_10()
	{
		return new string[5]
		{
			Class5790.Tag,
			Class5816.Tag,
			Class5819.Tag,
			Class5828.Tag,
			Class5829.Tag
		};
	}
}
