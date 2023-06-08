using ns215;

namespace ns216;

internal class Class5816 : Class5783
{
	internal static string Tag => "extras";

	public Class5816()
	{
		Class5906.smethod_4(this, "use", string.Empty);
		Class5906.smethod_4(this, "usehref", string.Empty);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_73(this);
		base.vmethod_4(visitor);
		visitor.vmethod_74(this);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5816();
	}

	internal override string vmethod_8()
	{
		return Tag;
	}

	internal override string[] vmethod_10()
	{
		return new string[11]
		{
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
