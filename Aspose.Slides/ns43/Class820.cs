using System.Xml;
using Aspose.Slides;
using ns42;

namespace ns43;

internal class Class820 : Class810
{
	internal static readonly string string_1 = "xf";

	internal NullableBool ApplyAlignment
	{
		get
		{
			return method_17("applyAlignment", "");
		}
		set
		{
			method_18("applyAlignment", "", value);
		}
	}

	internal NullableBool ApplyBorder
	{
		get
		{
			return method_17("applyBorder", "");
		}
		set
		{
			method_18("applyBorder", "", value);
		}
	}

	internal NullableBool ApplyFill
	{
		get
		{
			return method_17("applyFill", "");
		}
		set
		{
			method_18("applyFill", "", value);
		}
	}

	internal NullableBool ApplyFont
	{
		get
		{
			return method_17("applyFont", "");
		}
		set
		{
			method_18("applyFont", "", value);
		}
	}

	internal NullableBool ApplyNuberFormat
	{
		get
		{
			return method_17("applyNumberFormat", "");
		}
		set
		{
			method_18("applyNumberFormat", "", value);
		}
	}

	internal NullableBool ApplyProtection
	{
		get
		{
			return method_17("applyProtection", "");
		}
		set
		{
			method_18("applyProtection", "", value);
		}
	}

	internal uint BorderId
	{
		get
		{
			return (uint)method_11("borderId", "", 0);
		}
		set
		{
			method_13("borderId", "", (int)value);
		}
	}

	internal uint FillId
	{
		get
		{
			return (uint)method_11("fillId", "", 0);
		}
		set
		{
			method_13("fillId", "", (int)value);
		}
	}

	internal uint FontId
	{
		get
		{
			return (uint)method_11("fontId", "", 0);
		}
		set
		{
			method_13("fontId", "", (int)value);
		}
	}

	internal uint NumFmtId
	{
		get
		{
			return (uint)method_11("numFmtId", "", 0);
		}
		set
		{
			method_13("numFmtId", "", (int)value);
		}
	}

	internal bool PivotButton
	{
		get
		{
			return method_20("pivotButton", "", defaultValue: false);
		}
		set
		{
			method_21("pivotButton", "", value);
		}
	}

	internal bool QuotePrefix
	{
		get
		{
			return method_20("quotePrefix", "", defaultValue: false);
		}
		set
		{
			method_21("quotePrefix", "", value);
		}
	}

	internal uint XfId
	{
		get
		{
			return (uint)method_11("xfId", "", 0);
		}
		set
		{
			method_13("xfId", "", (int)value);
		}
	}

	public Class820(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}
}
