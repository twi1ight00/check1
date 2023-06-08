using ns215;

namespace ns216;

internal class Class5815 : Class5783
{
	internal static string Tag => "exObject";

	public Class5815()
	{
		Class5906.smethod_4(this, "archive", string.Empty);
		Class5906.smethod_4(this, "classId", string.Empty);
		Class5906.smethod_4(this, "codeBase", string.Empty);
		Class5906.smethod_4(this, "codeType", string.Empty);
		Class5906.smethod_4(this, "use", string.Empty);
		Class5906.smethod_4(this, "usehref", string.Empty);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_71(this);
		base.vmethod_4(visitor);
		visitor.vmethod_72(this);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5815();
	}

	internal override string vmethod_8()
	{
		return Tag;
	}

	internal override string[] vmethod_10()
	{
		return new string[12]
		{
			Class5816.Tag,
			"boolean",
			"date",
			"dateTime",
			"decimal",
			"exData",
			Tag,
			"float",
			Class5874.Tag,
			"integer",
			"text",
			"time"
		};
	}
}
