using System.Xml;
using ns215;

namespace ns216;

internal class Class5864 : Class5782
{
	internal const string string_4 = "date";

	private string string_5;

	public string Value
	{
		get
		{
			return string_5;
		}
		set
		{
			string_5 = value;
		}
	}

	internal string Use
	{
		get
		{
			return (string)method_5("use").Value;
		}
		set
		{
			method_5("use").Value = value;
		}
	}

	internal string Usehref
	{
		get
		{
			return (string)method_5("usehref").Value;
		}
		set
		{
			method_5("usehref").Value = value;
		}
	}

	public Class5864()
	{
		Class5906.smethod_4(this, "use", string.Empty);
		Class5906.smethod_4(this, "usehref", string.Empty);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_44(this);
	}

	public override object Clone()
	{
		Class5864 @class = (Class5864)base.Clone();
		@class.string_5 = string_5;
		return @class;
	}

	internal override void vmethod_5(Class5932 reader, XmlNode node)
	{
		string_5 = reader.method_6(node);
		base.vmethod_5(reader, node);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5864();
	}

	internal override string vmethod_8()
	{
		return "date";
	}
}
