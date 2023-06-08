using System.Xml;
using ns215;

namespace ns216;

internal class Class5871 : Class5782
{
	internal const string string_4 = "float";

	private float float_0;

	public float Value
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
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

	public Class5871()
	{
		Class5906.smethod_4(this, "use", string.Empty);
		Class5906.smethod_4(this, "usehref", string.Empty);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_81(this);
	}

	public override object Clone()
	{
		Class5871 @class = (Class5871)base.Clone();
		@class.float_0 = float_0;
		return @class;
	}

	internal override void vmethod_5(Class5932 reader, XmlNode node)
	{
		float_0 = reader.method_4(node);
		base.vmethod_5(reader, node);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5871();
	}

	internal override string vmethod_8()
	{
		return "float";
	}
}
