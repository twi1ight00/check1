using Aspose.XfaConverter.Elements;
using ns215;

namespace ns216;

internal class Class5844 : Class5783
{
	internal static string Tag => "signData";

	public Class5844()
	{
		Class5906.smethod_6(this, "operation", XfaEnums.Enum723.const_0);
		Class5906.smethod_4(this, "target", string.Empty);
		Class5906.smethod_4(this, "use", string.Empty);
		Class5906.smethod_4(this, "usehref", string.Empty);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_145(this);
		base.vmethod_4(visitor);
		visitor.vmethod_146(this);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5844();
	}

	internal override string vmethod_8()
	{
		return Tag;
	}

	internal override string[] vmethod_10()
	{
		return new string[2]
		{
			Class5819.Tag,
			Class5828.Tag
		};
	}
}
