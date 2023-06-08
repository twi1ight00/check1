using Aspose.XfaConverter.Elements;
using ns215;

namespace ns216;

internal class Class5824 : Class5783
{
	internal static string Tag => "items";

	public Class5824()
	{
		Class5906.smethod_6(this, "presence", XfaEnums.Enum687.const_0);
		Class5906.smethod_4(this, "ref", string.Empty);
		Class5906.smethod_4(this, "use", string.Empty);
		Class5906.smethod_4(this, "usehref", string.Empty);
		Class5906.smethod_3(this, "save", @default: false);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_94(this);
		base.vmethod_4(visitor);
		visitor.vmethod_95(this);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5824();
	}

	internal override string vmethod_8()
	{
		return Tag;
	}

	internal override string[] vmethod_10()
	{
		return new string[10]
		{
			"boolean",
			"date",
			"dateTime",
			"decimal",
			"exData",
			"float",
			Class5874.Tag,
			"integer",
			"text",
			"time"
		};
	}

	internal string method_8()
	{
		if (base.Nodes.Length == 0)
		{
			return string.Empty;
		}
		return Class5893.smethod_2((Class5782)base.Nodes.List[0]);
	}
}
