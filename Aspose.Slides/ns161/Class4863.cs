using System;
using System.Collections;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;
using ns220;
using ns221;
using ns224;
using ns235;
using ns271;

namespace ns161;

internal class Class4863
{
	private class Class4864
	{
		private string string_0;

		private string string_1;

		public string Name => string_0;

		public string Value => string_1;

		public Class4864(string name, string value)
		{
			string_0 = name;
			string_1 = value;
		}
	}

	private class Class4865
	{
		private ArrayList arrayList_0 = new ArrayList();

		private string string_0;

		private Hashtable hashtable_0 = new Hashtable();

		private Hashtable hashtable_1 = new Hashtable();

		private Class6216 class6216_0;

		private string string_1 = string.Empty;

		private Class5998 class5998_0 = Class5998.class5998_7;

		private Class5999 class5999_0;

		private Class6219 class6219_0;

		public ArrayList ApsPages => arrayList_0;

		public Class4865(string dirName)
		{
			string_0 = dirName;
		}

		private void method_0(ArrayList attributes)
		{
			float width = 0f;
			float height = 0f;
			foreach (Class4864 attribute in attributes)
			{
				if (attribute.Name == "width")
				{
					width = smethod_0(attribute.Value);
				}
				else if (attribute.Name == "height")
				{
					height = smethod_0(attribute.Value);
				}
			}
			class6216_0 = new Class6216(width, height);
		}

		private void method_1()
		{
			arrayList_0.Add(class6216_0);
			class6216_0 = null;
		}

		public Class5998 method_2(string value)
		{
			Match match = Regex.Match(value, "(?:#)+(.*)?$", RegexOptions.IgnoreCase);
			if (match.Success)
			{
				if (match.Groups[1].Value.Length == 6)
				{
					Color color = Color.FromArgb(int.Parse(match.Groups[1].Value, NumberStyles.HexNumber));
					return new Class5998(color.R, color.G, color.B);
				}
				if (match.Groups[1].Value.Length == 8)
				{
					Color color2 = Color.FromArgb(int.Parse(match.Groups[1].Value, NumberStyles.HexNumber));
					return new Class5998(color2.A, color2.R, color2.G, color2.B);
				}
			}
			return Class5998.class5998_7;
		}

		private static float smethod_0(string val)
		{
			return float.Parse(val, CultureInfo.InvariantCulture);
		}

		private void method_3(ArrayList attributes)
		{
			float sizePoints = 0f;
			string fontName = string.Empty;
			bool flag = false;
			bool flag2 = false;
			string text = string.Empty;
			foreach (Class4864 attribute in attributes)
			{
				if (attribute.Name == "size")
				{
					sizePoints = smethod_0(attribute.Value);
				}
				else if (attribute.Name == "face")
				{
					fontName = attribute.Value;
				}
				else if (attribute.Name == "color")
				{
					class5998_0 = method_2(attribute.Value);
				}
				else if (attribute.Name == "bold")
				{
					flag = attribute.Value.Trim().ToLower() == "true";
				}
				else if (attribute.Name == "italic")
				{
					flag2 = attribute.Value.Trim().ToLower() == "true";
				}
				else if (attribute.Name == "src")
				{
					text = attribute.Value;
				}
			}
			FontStyle fontStyle = FontStyle.Regular;
			if (flag2)
			{
				fontStyle |= FontStyle.Italic;
			}
			if (flag)
			{
				fontStyle |= FontStyle.Bold;
			}
			class5999_0 = Class6652.Instance.method_1("arial", sizePoints, fontStyle);
			if (text.Length > 0)
			{
				text.IndexOf("PDFKITNET-9188_tb_font3.ttf");
				Class6730 class2;
				if (hashtable_1.Contains(text))
				{
					class2 = (Class6730)hashtable_1[text];
				}
				else
				{
					using FileStream fileStream = new FileStream(string_0 + "\\" + text, FileMode.Open);
					byte[] array = new byte[fileStream.Length];
					fileStream.Read(array, 0, array.Length);
					Class6654 fontData = new Class6656(array);
					Class6732 class3 = new Class6732();
					class2 = class3.Read(fontData, fontName);
					hashtable_1[text] = class2;
				}
				class5999_0 = new Class5999(sizePoints, fontStyle, class2);
			}
			else
			{
				class5999_0 = Class6652.Instance.method_1("arial", sizePoints, fontStyle);
			}
		}

		private void method_4()
		{
			class5999_0 = null;
			class5998_0 = Class5998.class5998_7;
		}

		private void method_5(ArrayList attributes)
		{
			float x = 0f;
			float y = 0f;
			float width = 0f;
			float height = 0f;
			string text = string.Empty;
			foreach (Class4864 attribute in attributes)
			{
				if (attribute.Name == "x")
				{
					x = smethod_0(attribute.Value);
				}
				else if (attribute.Name == "y")
				{
					y = smethod_0(attribute.Value);
				}
				else if (attribute.Name == "width")
				{
					width = smethod_0(attribute.Value);
				}
				else if (attribute.Name == "height")
				{
					height = smethod_0(attribute.Value);
				}
				else if (attribute.Name == "src")
				{
					text = attribute.Value;
				}
			}
			if (text.Length <= 0)
			{
				return;
			}
			byte[] array;
			if (hashtable_0.Contains(text))
			{
				array = (byte[])hashtable_0[text];
			}
			else
			{
				using FileStream fileStream = new FileStream(string_0 + "\\" + text, FileMode.Open);
				array = new byte[fileStream.Length];
				fileStream.Read(array, 0, array.Length);
				hashtable_0[text] = array;
			}
			class6216_0.Add(new Class6220(new PointF(x, y), new SizeF(width, height), array));
		}

		private void method_6(ArrayList attributes)
		{
			float x = 0f;
			float y = 0f;
			float width = 0f;
			float height = 0f;
			foreach (Class4864 attribute in attributes)
			{
				if (attribute.Name == "x")
				{
					x = smethod_0(attribute.Value);
				}
				else if (attribute.Name == "y")
				{
					y = smethod_0(attribute.Value);
				}
				else if (attribute.Name == "width")
				{
					width = smethod_0(attribute.Value);
				}
				else if (attribute.Name == "height")
				{
					height = smethod_0(attribute.Value);
				}
			}
			class6219_0 = new Class6219(class5999_0, class5998_0, class5998_0, new PointF(x, y), string.Empty, new SizeF(width, height), 0f);
		}

		private void method_7()
		{
			class6219_0.AddText(string_1, 0f);
			class6216_0.Add(class6219_0);
			class6219_0 = null;
			string_1 = string.Empty;
		}

		public void method_8()
		{
		}

		public void method_9(string namespaceURI, string localName, string name, ArrayList attributes)
		{
			switch (localName)
			{
			case "img":
				method_5(attributes);
				break;
			case "text":
				method_6(attributes);
				break;
			case "font":
				method_3(attributes);
				break;
			case "page":
				method_0(attributes);
				break;
			}
		}

		public void method_10(string namespaceURI, string localName, string Name)
		{
			switch (localName)
			{
			case "text":
				method_7();
				break;
			case "font":
				method_4();
				break;
			case "page":
				method_1();
				break;
			}
		}

		public void method_11(string text)
		{
			string_1 = text.Replace("&amp;", "&").Replace("&lt;", "<").Replace("&gt;", ">");
		}

		public void method_12()
		{
		}
	}

	public void method_0(Stream srcXml, string outXps)
	{
		Class4865 @class = new Class4865(Path.GetDirectoryName(outXps));
		smethod_0(srcXml, @class);
		Class5956 class2 = new Class5956();
		class2.Author = "Aspose";
		class2.Creator = "Aspose";
		class2.Subject = "test";
		class2.Title = "test";
		class2.CreationDate = DateTime.Now;
		Class6596 options = new Class6596();
		Class6202 class3 = new Class6202(class2, options);
		foreach (Class6216 apsPage in @class.ApsPages)
		{
			class3.method_0(apsPage);
		}
		class3.method_1();
		using FileStream stream = new FileStream(outXps, FileMode.Create);
		class3.Package.Save(stream);
	}

	private static void smethod_0(Stream srcXml, Class4865 builder)
	{
		XmlTextReader xmlTextReader = new XmlTextReader(srcXml);
		try
		{
			builder.method_8();
			while (xmlTextReader.Read())
			{
				switch (xmlTextReader.NodeType)
				{
				case XmlNodeType.EndElement:
					builder.method_10(xmlTextReader.NamespaceURI, xmlTextReader.LocalName, xmlTextReader.Name);
					break;
				case XmlNodeType.Element:
					smethod_1(builder, xmlTextReader);
					break;
				case XmlNodeType.Text:
					builder.method_11(xmlTextReader.Value);
					if (xmlTextReader.NodeType == XmlNodeType.Element)
					{
						smethod_1(builder, xmlTextReader);
					}
					if (xmlTextReader.NodeType == XmlNodeType.EndElement)
					{
						builder.method_10(xmlTextReader.NamespaceURI, xmlTextReader.LocalName, xmlTextReader.Name);
					}
					break;
				}
			}
			builder.method_12();
		}
		finally
		{
			if (xmlTextReader.ReadState != ReadState.Closed)
			{
				xmlTextReader.Close();
			}
		}
	}

	private static void smethod_1(Class4865 builder, XmlTextReader reader)
	{
		ArrayList arrayList = new ArrayList();
		while (reader.MoveToNextAttribute())
		{
			arrayList.Add(new Class4864(reader.LocalName, reader.Value));
		}
		reader.MoveToElement();
		builder.method_9(reader.NamespaceURI, reader.LocalName, reader.Name, arrayList);
		if (reader.IsEmptyElement)
		{
			builder.method_10(reader.NamespaceURI, reader.LocalName, reader.Name);
		}
	}
}
