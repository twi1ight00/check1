using System;
using System.Globalization;
using System.Xml;

namespace ns56;

internal abstract class Class1351
{
	internal Class1351(XmlReader reader)
	{
		vmethod_1();
		vmethod_2();
		vmethod_0(reader);
	}

	internal Class1351()
	{
		vmethod_1();
		vmethod_2();
		vmethod_3();
	}

	protected abstract void vmethod_0(XmlReader reader);

	protected abstract void vmethod_1();

	protected abstract void vmethod_2();

	protected abstract void vmethod_3();

	public abstract void vmethod_4(string prefix, XmlWriter writer, string elementName);

	protected string method_0(XmlReader reader)
	{
		if (reader.NamespaceURI == "")
		{
			return reader.Name;
		}
		return reader.NamespaceURI switch
		{
			"http://schemas.microsoft.com/office/powerpoint/2010/main" => "p14:" + reader.LocalName, 
			"urn:schemas-microsoft-com:office:office" => "o:" + reader.LocalName, 
			"urn:schemas-microsoft-com:vml" => "v:" + reader.LocalName, 
			"http://schemas.openxmlformats.org/officeDocument/2006/relationships" => "r:" + reader.LocalName, 
			_ => reader.LocalName, 
		};
	}

	protected double ToDouble(string s)
	{
		if (s == "-INF")
		{
			return double.NegativeInfinity;
		}
		if (s == "INF")
		{
			return double.PositiveInfinity;
		}
		if (!double.TryParse(s, NumberStyles.Float, NumberFormatInfo.InvariantInfo, out var result))
		{
			string text = s.Trim();
			if (text.Equals("Infinity"))
			{
				return double.PositiveInfinity;
			}
			if (text.Equals("-Infinity"))
			{
				return double.NegativeInfinity;
			}
			throw new FormatException();
		}
		if (result == 0.0 && s[0] == '-')
		{
			return -0.0;
		}
		return result;
	}

	protected void method_1(string prefix, XmlWriter writer, string elementName, string value)
	{
		if (value != null && value.Length > 0 && value[value.Length - 1] == ' ')
		{
			writer.WriteStartElement(prefix, elementName, null);
			if (prefix == "ssml")
			{
				writer.WriteAttributeString("xml:space", "", "preserve");
			}
			writer.WriteString(value);
			writer.WriteEndElement();
		}
		else
		{
			writer.WriteElementString(prefix, elementName, null, value);
		}
	}
}
