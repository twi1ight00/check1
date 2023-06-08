using Aspose.XfaConverter.Elements;
using ns215;

namespace ns216;

internal class Class5854 : Class5783
{
	internal static string Tag => "traverse";

	public Class5854()
	{
		Class5906.smethod_6(this, "operation", XfaEnums.Enum728.const_0);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_171(this);
		base.vmethod_4(visitor);
		visitor.vmethod_172(this);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5854();
	}

	internal override string vmethod_8()
	{
		return Tag;
	}

	internal override string[] vmethod_10()
	{
		return new string[2]
		{
			Class5816.Tag,
			Class5885.Tag
		};
	}
}
