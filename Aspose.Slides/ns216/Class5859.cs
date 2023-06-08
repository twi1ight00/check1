using ns215;

namespace ns216;

internal class Class5859 : Class5782
{
	internal static string Tag => "bindItems";

	public Class5859()
	{
		Class5906.smethod_4(this, "connection", string.Empty);
		Class5906.smethod_4(this, "labelRef", string.Empty);
		Class5906.smethod_4(this, "ref", string.Empty);
		Class5906.smethod_4(this, "valueRef", string.Empty);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_11(this);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5859();
	}

	internal override string vmethod_8()
	{
		return Tag;
	}
}
