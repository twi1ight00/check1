using System.Xml;
using ns215;

namespace ns216;

internal class Class5882 : Class5782
{
	private string string_4;

	public string Value
	{
		get
		{
			return string_4;
		}
		set
		{
			string_4 = value;
		}
	}

	internal static string Tag => "picture";

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_130(this);
	}

	public override object Clone()
	{
		Class5882 @class = (Class5882)base.Clone();
		@class.string_4 = string_4;
		return @class;
	}

	internal override void vmethod_5(Class5932 reader, XmlNode node)
	{
		string_4 = reader.method_7(node);
		base.vmethod_5(reader, node);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5882();
	}

	internal override string vmethod_8()
	{
		return Tag;
	}
}
