using ns215;

namespace ns216;

internal class Class5886 : Class5782
{
	internal static string Tag => "setProperty";

	public Class5886()
	{
		Class5906.smethod_4(this, "connection", string.Empty);
		Class5906.smethod_4(this, "target", string.Empty);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_142(this);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5886();
	}

	internal override string vmethod_8()
	{
		return Tag;
	}
}
