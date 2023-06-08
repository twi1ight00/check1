using System.Xml;
using Aspose.Cells;
using ns2;
using ns22;

namespace ns15;

internal class Class1510
{
	[Attribute0(true)]
	internal static void smethod_0(XmlWriter xmlWriter_0, Class1737 class1737_0, string string_0)
	{
		if (class1737_0 == null || class1737_0.Text == null || class1737_0.Text == "")
		{
			return;
		}
		string text = class1737_0.Text;
		xmlWriter_0.WriteStartElement("text:p");
		if (string_0 != null && string_0 != "")
		{
			xmlWriter_0.WriteAttributeString("text", "style-name", null, string_0);
		}
		if (class1737_0.method_12() != null && class1737_0.method_12().Count != 0)
		{
			class1737_0.method_11();
			int num = -1;
			string text2 = null;
			for (int i = 0; i < class1737_0.method_12().Count; i++)
			{
				FontSetting fontSetting = (FontSetting)class1737_0.method_12()[i];
				if (fontSetting.StartIndex >= text.Length)
				{
					break;
				}
				if (fontSetting.StartIndex - num != 1)
				{
					text2 = text.Substring(num + 1, fontSetting.StartIndex - num - 1);
					smethod_1(xmlWriter_0, text2, class1737_0.method_8(), string_0);
				}
				text2 = ((fontSetting.StartIndex + fontSetting.Length < text.Length) ? text.Substring(fontSetting.StartIndex, fontSetting.Length) : text.Substring(fontSetting.StartIndex));
				smethod_1(xmlWriter_0, text2, (fontSetting.method_2() != null) ? fontSetting.Font.method_21() : 0, string_0);
				num = fontSetting.StartIndex + fontSetting.Length - 1;
				if (num >= text.Length)
				{
					break;
				}
			}
		}
		else
		{
			smethod_1(xmlWriter_0, text, class1737_0.method_8(), string_0);
		}
		xmlWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private static void smethod_1(XmlWriter xmlWriter_0, string string_0, int int_0, string string_1)
	{
		string[] array = string_0.Split('\n');
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] != null && array[i] != "")
			{
				xmlWriter_0.WriteStartElement("text:span");
				xmlWriter_0.WriteAttributeString("text", "style-name", null, "T" + Class1516.smethod_13(int_0));
				xmlWriter_0.WriteString(array[i]);
				xmlWriter_0.WriteEndElement();
			}
			if (i != array.Length - 1)
			{
				xmlWriter_0.WriteEndElement();
				xmlWriter_0.WriteStartElement("text:p");
				xmlWriter_0.WriteAttributeString("text", "style-name", null, string_1);
			}
		}
	}
}
