using System.Collections;
using System.Xml;
using Aspose.Cells;
using ns22;

namespace ns16;

internal class Class1606
{
	private string string_0;

	private string string_1;

	private string string_2;

	[Attribute0(true)]
	internal ArrayList Read(XmlTextReader xmlTextReader_0)
	{
		method_2(xmlTextReader_0);
		if (xmlTextReader_0.IsEmptyElement)
		{
			return null;
		}
		ArrayList arrayList = new ArrayList();
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0))
			{
				if (xmlTextReader_0.LocalName == "shape" && !xmlTextReader_0.IsEmptyElement)
				{
					Class1545 value = method_0(xmlTextReader_0);
					arrayList.Add(value);
				}
				else
				{
					xmlTextReader_0.Skip();
				}
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		return arrayList;
	}

	[Attribute0(true)]
	private Class1545 method_0(XmlTextReader xmlTextReader_0)
	{
		Class1545 @class = new Class1545();
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				if (xmlTextReader_0.LocalName == "id")
				{
					@class.method_1(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "style")
				{
					@class.string_2 = xmlTextReader_0.Value;
				}
				else if (xmlTextReader_0.LocalName == "preferrelative")
				{
					bool bool_ = ((!(xmlTextReader_0.Value == "f")) ? true : false);
					@class.bool_0 = bool_;
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.LocalName == "imagedata")
			{
				method_1(xmlTextReader_0, @class);
			}
			else if (xmlTextReader_0.LocalName == "lock")
			{
				string attribute = xmlTextReader_0.GetAttribute("aspectratio");
				xmlTextReader_0.Skip();
				if (attribute != null)
				{
					@class.bool_1 = smethod_0(attribute);
				}
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
		return @class;
	}

	[Attribute0(true)]
	private void method_1(XmlTextReader xmlTextReader_0, Class1545 class1545_0)
	{
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				if (xmlTextReader_0.LocalName == "relid")
				{
					class1545_0.string_1 = xmlTextReader_0.Value;
				}
				else if (xmlTextReader_0.LocalName == "title")
				{
					class1545_0.string_3 = xmlTextReader_0.Value;
				}
				else if (xmlTextReader_0.LocalName == "croptop")
				{
					class1545_0.double_0 = smethod_1(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "cropbottom")
				{
					class1545_0.double_1 = smethod_1(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "cropleft")
				{
					class1545_0.double_2 = smethod_1(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "cropright")
				{
					class1545_0.double_3 = smethod_1(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "blacklevel")
				{
					class1545_0.double_5 = smethod_1(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "gain")
				{
					class1545_0.double_4 = smethod_1(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "preferrelative")
				{
					class1545_0.bool_0 = smethod_0(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "grayscale")
				{
					class1545_0.bool_2 = smethod_0(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "bilevel")
				{
					class1545_0.bool_3 = smethod_0(xmlTextReader_0.Value);
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		xmlTextReader_0.Skip();
	}

	internal static bool smethod_0(string string_3)
	{
		if (!(string_3 == "f") && !(string_3.ToLower() == "false"))
		{
			if (!(string_3 == "t") && !(string_3.ToLower() == "true"))
			{
				if (string_3 == "1")
				{
					return true;
				}
				if (string_3 == "0")
				{
					return false;
				}
				throw new CellsException(ExceptionType.InvalidData, "Error true/false format: " + string_3);
			}
			return true;
		}
		return false;
	}

	internal static double smethod_1(string string_3)
	{
		double result = 0.0;
		try
		{
			if (string_3.EndsWith("f"))
			{
				string_3 = string_3.Substring(0, string_3.Length - 1);
				double num = Class1618.smethod_85(string_3);
				result = num / 65536.0;
			}
			else if (string_3.EndsWith("%"))
			{
				string_3 = string_3.Substring(0, string_3.Length - 1);
				double num2 = Class1618.smethod_85(string_3);
				result = num2 * 0.01;
			}
			else
			{
				result = Class1618.smethod_85(string_3);
			}
		}
		catch
		{
		}
		return result;
	}

	private void method_2(XmlTextReader xmlTextReader_0)
	{
		xmlTextReader_0.WhitespaceHandling = WhitespaceHandling.Significant;
		XmlNameTable nameTable = xmlTextReader_0.NameTable;
		string_0 = nameTable.Add("urn:schemas-microsoft-com:vml");
		string_1 = nameTable.Add("urn:schemas-microsoft-com:office:office");
		string_2 = nameTable.Add("urn:schemas-microsoft-com:office:excel");
		xmlTextReader_0.MoveToContent();
		if (xmlTextReader_0.NodeType != XmlNodeType.Element || !(xmlTextReader_0.LocalName == "xml"))
		{
			throw new CellsException(ExceptionType.InvalidData, "xml root element eror");
		}
	}
}
