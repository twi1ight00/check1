using ns215;

namespace ns216;

internal class Class5860 : Class5782
{
	internal static string Tag => "bookend";

	public Class5860()
	{
		Class5906.smethod_4(this, "leader", string.Empty);
		Class5906.smethod_4(this, "trailer", string.Empty);
		Class5906.smethod_4(this, "use", string.Empty);
		Class5906.smethod_4(this, "usehref", string.Empty);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_12(this);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5860();
	}

	internal override string vmethod_8()
	{
		return Tag;
	}
}
