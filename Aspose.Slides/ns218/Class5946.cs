using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml;
using ns221;
using ns234;

namespace ns218;

internal class Class5946
{
	private readonly XmlTextWriter xmlTextWriter_0;

	private readonly StringBuilder stringBuilder_0;

	public XmlTextWriter XmlWriter => xmlTextWriter_0;

	public Class5946(Stream stream, Encoding encoding, bool isPrettyFormat)
	{
		if (encoding.CodePage == 65000)
		{
			byte[] preamble = encoding.GetPreamble();
			if (preamble.Length == 0)
			{
				preamble = Class5954.Utf7Bom;
				stream.Write(preamble, 0, preamble.Length);
			}
		}
		xmlTextWriter_0 = Class6169.smethod_0(stream, encoding);
		stringBuilder_0 = new StringBuilder(2048);
		xmlTextWriter_0.Namespaces = false;
		if (isPrettyFormat)
		{
			xmlTextWriter_0.Formatting = Formatting.Indented;
			xmlTextWriter_0.Indentation = 1;
			xmlTextWriter_0.IndentChar = '\t';
		}
	}

	public Class5946(Stream stream, bool isPrettyFormat)
		: this(stream, Encoding.UTF8, isPrettyFormat)
	{
	}

	[Attribute7(true)]
	public void method_0(string rootElementName)
	{
		xmlTextWriter_0.WriteStartDocument(standalone: true);
		method_2(rootElementName);
	}

	[Attribute7(true)]
	public void method_1()
	{
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndDocument();
		xmlTextWriter_0.Flush();
	}

	[Attribute7(true)]
	public void method_2(string elementName)
	{
		xmlTextWriter_0.WriteStartElement(elementName);
	}

	[Attribute7(true)]
	public void method_3()
	{
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute7(true)]
	public void method_4(string elementName)
	{
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute7(true)]
	public void method_5()
	{
		xmlTextWriter_0.WriteFullEndElement();
	}

	[Attribute7(true)]
	public void method_6(string elementName)
	{
		xmlTextWriter_0.WriteFullEndElement();
	}

	[Attribute7(true)]
	public void method_7(string text)
	{
		xmlTextWriter_0.WriteRaw(text);
	}

	public void method_8(string elementName)
	{
		method_9(elementName, null);
	}

	public void method_9(string elementName, string value)
	{
		method_2(elementName);
		method_13(value);
		method_3();
	}

	public void method_10(string elementName, string value)
	{
		if (Class5964.smethod_20(value))
		{
			method_9(elementName, value);
		}
	}

	public void method_11(string elementName, DateTime value)
	{
		if (value.Year > 1)
		{
			method_9(elementName, Class6159.smethod_0(value));
		}
	}

	public void method_12(string elementName, int value)
	{
		method_9(elementName, Class6159.smethod_6(value));
	}

	[Attribute7(true)]
	public void method_13(string value)
	{
		xmlTextWriter_0.WriteString(method_18(value));
	}

	[Attribute7(true)]
	public void method_14(string name, string value)
	{
		xmlTextWriter_0.WriteAttributeString(name, method_18(value));
	}

	[Attribute7(true)]
	public void method_15(Stream stream)
	{
		if (stream is MemoryStream memoryStream)
		{
			method_16(memoryStream.GetBuffer(), 0, (int)stream.Length);
		}
		else
		{
			method_16(Class5964.smethod_11(stream), 0, (int)stream.Length);
		}
	}

	[Attribute7(true)]
	public void method_16(byte[] buffer, int index, int count)
	{
		Class5949 @class = new Class5949(buffer, index, count);
		while (!@class.IsEof)
		{
			method_13(@class.method_0());
			xmlTextWriter_0.WriteWhitespace("\r\n");
		}
	}

	internal string method_17(string text, bool replaceOnWhyteSpace)
	{
		if (!smethod_0(text))
		{
			return text;
		}
		stringBuilder_0.Length = 0;
		foreach (char c in text)
		{
			if (smethod_1(c))
			{
				stringBuilder_0.Append(c);
			}
			else if (replaceOnWhyteSpace)
			{
				stringBuilder_0.Append(" ");
			}
		}
		return stringBuilder_0.ToString();
	}

	public string method_18(string text)
	{
		return method_17(text, replaceOnWhyteSpace: false);
	}

	private static bool smethod_0(string text)
	{
		if (!Class5964.smethod_20(text))
		{
			return false;
		}
		int num = 0;
		while (true)
		{
			if (num < text.Length)
			{
				if (!smethod_1(text[num]))
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

	private static bool smethod_1(char c)
	{
		if (c != '\t' && c != '\n' && c != '\r' && (c < ' ' || c > '\ud7ff'))
		{
			if (c >= '\ue000')
			{
				return c <= '\ufffd';
			}
			return false;
		}
		return true;
	}

	public static IDictionary smethod_2(IDictionary source)
	{
		IDictionary dictionary = null;
		StringBuilder stringBuilder = new StringBuilder(1024);
		foreach (string key in source.Keys)
		{
			if (smethod_3(key))
			{
				continue;
			}
			if (dictionary == null)
			{
				dictionary = Class6152.smethod_0();
			}
			smethod_4(key, stringBuilder);
			string text2 = stringBuilder.ToString();
			string text3 = text2;
			for (int i = 1; i < 1000; i++)
			{
				if (source.Contains(text3) || dictionary.Contains(text3))
				{
					text3 = $"{text2}_{i}";
					continue;
				}
				dictionary.Add(key, text3);
				break;
			}
		}
		return dictionary;
	}

	private static bool smethod_3(string id)
	{
		if (id.Length != 0 && smethod_5(id[0]))
		{
			int num = 1;
			while (true)
			{
				if (num < id.Length)
				{
					if (!smethod_6(id[num]))
					{
						break;
					}
					num++;
					continue;
				}
				return true;
			}
			return false;
		}
		return false;
	}

	private static void smethod_4(string id, StringBuilder sb)
	{
		sb.Length = 0;
		if (id.Length != 0)
		{
			sb.Append(smethod_5(id[0]) ? id[0] : '_');
			for (int i = 1; i < id.Length; i++)
			{
				sb.Append(smethod_6(id[i]) ? id[i] : '_');
			}
		}
	}

	private static bool smethod_5(char c)
	{
		if (c < 'A' || c > 'Z')
		{
			switch (c)
			{
			default:
				if ((c < 'À' || c > 'Ö') && (c < 'Ø' || c > 'ö') && (c < 'ø' || c > '\u02ff') && (c < 'Ͱ' || c > 'ͽ') && (c < 'Ϳ' || c > '\u1fff') && (c < '\u200c' || c > '\u200d') && (c < '⁰' || c > '\u218f') && (c < 'Ⰰ' || c > '\u2fef') && (c < '、' || c > '\ud7ff') && (c < '豈' || c > '\ufdcf'))
				{
					if (c >= 'ﷰ')
					{
						return c <= '\ufffd';
					}
					return false;
				}
				break;
			case '_':
			case 'a':
			case 'b':
			case 'c':
			case 'd':
			case 'e':
			case 'f':
			case 'g':
			case 'h':
			case 'i':
			case 'j':
			case 'k':
			case 'l':
			case 'm':
			case 'n':
			case 'o':
			case 'p':
			case 'q':
			case 'r':
			case 's':
			case 't':
			case 'u':
			case 'v':
			case 'w':
			case 'x':
			case 'y':
			case 'z':
				break;
			}
		}
		return true;
	}

	private static bool smethod_6(char c)
	{
		if (!smethod_5(c))
		{
			switch (c)
			{
			default:
				if (c != '·' && (c < '\u0300' || c > '\u036f'))
				{
					if (c >= '\u203f')
					{
						return c <= '\u2040';
					}
					return false;
				}
				break;
			case '-':
			case '.':
			case '0':
			case '1':
			case '2':
			case '3':
			case '4':
			case '5':
			case '6':
			case '7':
			case '8':
			case '9':
				break;
			}
		}
		return true;
	}

	[Conditional("DEBUG")]
	private static void smethod_7()
	{
	}

	[Conditional("DEBUG")]
	private static void smethod_8(string elementName)
	{
	}

	[Conditional("DEBUG")]
	private static void smethod_9(string elementName)
	{
	}
}
