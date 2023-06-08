using ns215;

namespace ns216;

internal class Class5888 : Class5782
{
	internal static string Tag => "subjectDN";

	public Class5888()
	{
		Class5906.smethod_4(this, "delimiter", ",");
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_158(this);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5888();
	}

	internal override string vmethod_8()
	{
		return Tag;
	}
}
