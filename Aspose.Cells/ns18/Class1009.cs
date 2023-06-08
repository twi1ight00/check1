using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml;
using ns22;

namespace ns18;

internal class Class1009
{
	private readonly XmlTextWriter xmlTextWriter_0;

	private readonly StringBuilder stringBuilder_0;

	public Class1009(Stream stream_0, Encoding encoding_0, bool bool_0)
	{
		if (encoding_0.CodePage == 65000)
		{
			byte[] preamble = encoding_0.GetPreamble();
			if (preamble.Length == 0)
			{
				preamble = Class1011.smethod_0();
				stream_0.Write(preamble, 0, preamble.Length);
			}
		}
		xmlTextWriter_0 = Class1029.smethod_0(stream_0, encoding_0);
		stringBuilder_0 = new StringBuilder(2048);
		xmlTextWriter_0.Namespaces = false;
		if (bool_0)
		{
			xmlTextWriter_0.Formatting = Formatting.Indented;
			xmlTextWriter_0.Indentation = 1;
			xmlTextWriter_0.IndentChar = '\t';
		}
	}

	public Class1009(Stream stream_0, bool bool_0)
		: this(stream_0, Encoding.UTF8, bool_0)
	{
	}

	[SpecialName]
	public XmlTextWriter method_0()
	{
		return xmlTextWriter_0;
	}

	[Attribute0(true)]
	public void method_1(string string_0)
	{
		xmlTextWriter_0.WriteStartDocument(standalone: true);
		method_3(string_0);
	}

	[Attribute0(true)]
	public void method_2()
	{
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndDocument();
		xmlTextWriter_0.Flush();
	}

	[Attribute0(true)]
	public void method_3(string string_0)
	{
		xmlTextWriter_0.WriteStartElement(string_0);
	}

	[Attribute0(true)]
	public void method_4()
	{
		xmlTextWriter_0.WriteEndElement();
	}

	public void method_5(string string_0, string string_1)
	{
		method_3(string_0);
		method_8(string_1);
		method_4();
	}

	public void method_6(string string_0, string string_1)
	{
		if (Class1015.smethod_11(string_1))
		{
			method_5(string_0, string_1);
		}
	}

	public void method_7(string string_0, DateTime dateTime_0)
	{
		if (dateTime_0.Year > 1)
		{
			method_5(string_0, Class1025.smethod_0(dateTime_0));
		}
	}

	[Attribute0(true)]
	public void method_8(string string_0)
	{
		xmlTextWriter_0.WriteString(method_10(string_0));
	}

	[Attribute0(true)]
	public void method_9(string string_0, string string_1)
	{
		xmlTextWriter_0.WriteAttributeString(string_0, method_10(string_1));
	}

	public string method_10(string string_0)
	{
		if (!smethod_0(string_0))
		{
			return string_0;
		}
		stringBuilder_0.Length = 0;
		foreach (char c in string_0)
		{
			if (smethod_1(c))
			{
				stringBuilder_0.Append(c);
			}
		}
		return stringBuilder_0.ToString();
	}

	private static bool smethod_0(string string_0)
	{
		if (!Class1015.smethod_11(string_0))
		{
			return false;
		}
		int num = 0;
		while (true)
		{
			if (num < string_0.Length)
			{
				if (!smethod_1(string_0[num]))
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}

	private static bool smethod_1(char char_0)
	{
		if (char_0 != '\t' && char_0 != '\n' && char_0 != '\r' && (char_0 < ' ' || char_0 > '\ud7ff'))
		{
			if (char_0 >= '\ue000')
			{
				return char_0 <= '\ufffd';
			}
			return false;
		}
		return true;
	}
}
