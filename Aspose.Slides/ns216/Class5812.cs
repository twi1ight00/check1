using ns215;

namespace ns216;

internal class Class5812 : Class5783
{
	internal static string Tag => "encrypt";

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_63(this);
		base.vmethod_4(visitor);
		visitor.vmethod_64(this);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5812();
	}

	internal override string vmethod_8()
	{
		return Tag;
	}

	internal override string[] vmethod_10()
	{
		return new string[1] { Class5862.Tag };
	}
}
