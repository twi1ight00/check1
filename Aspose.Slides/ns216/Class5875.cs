using System.Xml;
using ns215;

namespace ns216;

internal class Class5875 : Class5782
{
	internal const string string_4 = "integer";

	private int int_0;

	public int Value
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
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

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_91(this);
	}

	public override object Clone()
	{
		Class5875 @class = (Class5875)base.Clone();
		@class.int_0 = int_0;
		return @class;
	}

	internal override void vmethod_5(Class5932 reader, XmlNode node)
	{
		int_0 = reader.method_5(node);
		base.vmethod_5(reader, node);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5875();
	}

	internal override string vmethod_8()
	{
		return "integer";
	}
}
