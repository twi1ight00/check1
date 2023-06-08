using System.Xml;
using ns215;

namespace ns216;

internal class Class5866 : Class5782
{
	internal const string string_4 = "decimal";

	private decimal decimal_0;

	public decimal Value
	{
		get
		{
			return decimal_0;
		}
		set
		{
			decimal_0 = value;
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

	public Class5866()
	{
		Class5906.smethod_2(this, "fracDigits", 2);
		Class5906.smethod_2(this, "leadDigits", -1);
		Class5906.smethod_4(this, "use", string.Empty);
		Class5906.smethod_4(this, "usehref", string.Empty);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_48(this);
	}

	public override object Clone()
	{
		Class5866 @class = (Class5866)base.Clone();
		@class.decimal_0 = decimal_0;
		return @class;
	}

	internal override void vmethod_5(Class5932 reader, XmlNode node)
	{
		decimal_0 = reader.method_3(node);
		base.vmethod_5(reader, node);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5866();
	}

	internal override string vmethod_8()
	{
		return "decimal";
	}
}
