using ns215;

namespace ns216;

internal class Class5863 : Class5782
{
	internal static string Tag => "comb";

	public Class5863()
	{
		Class5906.smethod_2(this, "numberOfCells", 0);
		Class5906.smethod_4(this, "use", string.Empty);
		Class5906.smethod_4(this, "usehref", string.Empty);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_37(this);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5863();
	}

	internal override string vmethod_8()
	{
		return Tag;
	}
}
