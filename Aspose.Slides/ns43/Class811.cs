using System;
using System.Globalization;
using System.Xml;
using ns33;
using ns42;
using ns56;

namespace ns43;

internal class Class811 : Class810
{
	internal static readonly string string_1 = "c";

	internal static readonly Class1151 class1151_0 = new Class1151("b", "n", "e", "s", "str", "inlineStr");

	internal Enum262 CellType
	{
		get
		{
			return (Enum262)method_62(class1151_0, "t", "", 1);
		}
		set
		{
			if (value == Enum262.const_1)
			{
				RemoveAttribute("t", "");
			}
			else if (value != Enum262.const_1)
			{
				method_63(class1151_0, "t", "", (int)value);
			}
		}
	}

	internal object CellValue
	{
		get
		{
			return method_57("v", NamespaceURI)?.InnerText;
		}
		set
		{
			if (value != null)
			{
				Class810 @class = method_0("v", NamespaceURI);
				@class.Prefix = "";
				@class.InnerText = Convert.ToString(value, CultureInfo.InvariantCulture);
			}
		}
	}

	internal string CellName
	{
		get
		{
			return GetAttribute("r", "");
		}
		set
		{
			SetAttribute("r", "", value);
		}
	}

	internal uint CellStyle
	{
		get
		{
			return (uint)method_11("s", "", 0);
		}
		set
		{
			method_13("s", "", (int)value);
		}
	}

	public Class811(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}
}
