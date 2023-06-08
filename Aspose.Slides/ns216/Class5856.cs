using Aspose.XfaConverter.Elements;
using ns215;

namespace ns216;

internal class Class5856 : Class5783
{
	internal static string Tag => "validate";

	public Class5856()
	{
		Class5906.smethod_6(this, "formatTest", XfaEnums.Enum729.const_0);
		Class5906.smethod_6(this, "nullTest", XfaEnums.Enum729.const_1);
		Class5906.smethod_6(this, "scriptTest", XfaEnums.Enum729.const_2);
		Class5906.smethod_4(this, "use", string.Empty);
		Class5906.smethod_4(this, "usehref", string.Empty);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_175(this);
		base.vmethod_4(visitor);
		visitor.vmethod_176(this);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5856();
	}

	internal override string vmethod_8()
	{
		return Tag;
	}

	internal override string[] vmethod_10()
	{
		return new string[4]
		{
			Class5816.Tag,
			Class5830.Tag,
			Class5882.Tag,
			Class5885.Tag
		};
	}
}
