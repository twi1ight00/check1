using System.Xml;
using ns215;

namespace ns216;

internal class Class5861 : Class5782
{
	internal const string string_4 = "boolean";

	private bool bool_1;

	internal bool Value
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
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

	public Class5861()
	{
		Class5906.smethod_4(this, "use", string.Empty);
		Class5906.smethod_4(this, "usehref", string.Empty);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_13(this);
	}

	public override object Clone()
	{
		Class5861 @class = (Class5861)base.Clone();
		@class.bool_1 = bool_1;
		return @class;
	}

	internal override void vmethod_5(Class5932 reader, XmlNode node)
	{
		bool_1 = reader.method_2(node);
		base.vmethod_5(reader, node);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5861();
	}

	internal override string vmethod_8()
	{
		return "boolean";
	}
}
