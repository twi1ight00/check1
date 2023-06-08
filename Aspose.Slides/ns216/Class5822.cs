using Aspose.XfaConverter.Elements;
using ns215;

namespace ns216;

internal class Class5822 : Class5783
{
	internal static string Tag => "imageEdit";

	public Class5822()
	{
		Class5906.smethod_6(this, "data", XfaEnums.Enum711.const_0);
		Class5906.smethod_4(this, "use", string.Empty);
		Class5906.smethod_4(this, "usehref", string.Empty);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_89(this);
		base.vmethod_4(visitor);
		visitor.vmethod_90(this);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5822();
	}

	internal override string vmethod_8()
	{
		return Tag;
	}

	internal override string[] vmethod_10()
	{
		return new string[3]
		{
			Class5790.Tag,
			Class5816.Tag,
			Class5829.Tag
		};
	}
}
