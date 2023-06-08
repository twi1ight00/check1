using ns215;

namespace ns216;

internal class Class5880 : Class5782
{
	internal static string Tag => "oid";

	public Class5880()
	{
		Class5906.smethod_4(this, "use", string.Empty);
		Class5906.smethod_4(this, "usehref", string.Empty);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_116(this);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5880();
	}

	internal override string vmethod_8()
	{
		return Tag;
	}
}
