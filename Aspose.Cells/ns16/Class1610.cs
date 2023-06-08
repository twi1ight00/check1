using System;
using System.Text;
using System.Xml;
using Aspose.Cells;
using ns2;
using ns22;

namespace ns16;

internal class Class1610
{
	private Class1547 class1547_0;

	private string string_0;

	private Class1301 class1301_0;

	private int int_0;

	internal Class1610(Class1547 class1547_1)
	{
		class1547_0 = class1547_1;
		class1301_0 = class1547_0.workbook_0.Worksheets.class1301_0;
	}

	internal void Read(XmlTextReader xmlTextReader_0)
	{
		method_2(xmlTextReader_0);
		if (xmlTextReader_0.IsEmptyElement)
		{
			return;
		}
		int_0 = 0;
		xmlTextReader_0.Read();
		while (Class1188.smethod_15(xmlTextReader_0))
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "si")
			{
				if (xmlTextReader_0.IsEmptyElement)
				{
					xmlTextReader_0.Skip();
					Class1719 class1719_ = new Class1719("", 0);
					class1301_0.method_6(class1719_, int_0);
					int_0++;
				}
				else
				{
					method_0(xmlTextReader_0);
				}
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
	}

	internal int method_0(XmlTextReader xmlTextReader_0)
	{
		string text = null;
		StringBuilder stringBuilder = null;
		short[] array = null;
		int num = 0;
		xmlTextReader_0.Read();
		while (Class1188.smethod_15(xmlTextReader_0))
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && xmlTextReader_0.LocalName == "t" && !xmlTextReader_0.IsEmptyElement)
			{
				text = Class1618.smethod_8(xmlTextReader_0.ReadElementString());
			}
			else if (xmlTextReader_0.NodeType == XmlNodeType.Element && xmlTextReader_0.LocalName == "r" && !xmlTextReader_0.IsEmptyElement)
			{
				if (stringBuilder == null)
				{
					stringBuilder = new StringBuilder();
					array = new short[2];
				}
				else if (num * 2 >= array.Length)
				{
					short[] array2 = new short[num * 2 + 50];
					Array.Copy(array, array2, array.Length);
					array = array2;
				}
				method_1(xmlTextReader_0, stringBuilder, num, array);
				num++;
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		if (num == 0)
		{
			if (text == null)
			{
				text = "";
			}
			Class1719 class1719_ = new Class1719(text, 0);
			class1301_0.method_6(class1719_, int_0);
		}
		else
		{
			int num2 = 0;
			int num3 = num;
			if (array[1] == -1)
			{
				num3--;
				num2 = 1;
			}
			byte[] byte_ = new byte[num3 * 4];
			for (int i = 0; i < num3; i++)
			{
				short short_ = array[num2 * 2];
				short short_2 = array[num2 * 2 + 1];
				num2++;
				Class1618.smethod_13(byte_, i * 4, short_);
				Class1618.smethod_13(byte_, i * 4 + 2, short_2);
			}
			string text2 = stringBuilder.ToString();
			class1301_0.method_7(text2, int_0, byte_);
		}
		int result = int_0;
		int_0++;
		return result;
	}

	private void method_1(XmlTextReader xmlTextReader_0, StringBuilder stringBuilder_0, int int_1, short[] short_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			throw new CellsException(ExceptionType.InvalidData, "Invalid r element");
		}
		short num = (short)stringBuilder_0.Length;
		Class1542 @class = null;
		xmlTextReader_0.Read();
		while (Class1188.smethod_15(xmlTextReader_0))
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && xmlTextReader_0.LocalName == "rPr" && !xmlTextReader_0.IsEmptyElement)
			{
				@class = Class1611.smethod_1(xmlTextReader_0, class1547_0, "rFont");
			}
			else if (xmlTextReader_0.NodeType == XmlNodeType.Element && xmlTextReader_0.LocalName == "t" && !xmlTextReader_0.IsEmptyElement)
			{
				string string_ = xmlTextReader_0.ReadElementString();
				stringBuilder_0.Append(Class1618.smethod_8(string_));
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		int num2 = 0;
		if (int_1 == 0 && @class == null)
		{
			num2 = -1;
		}
		if (@class != null)
		{
			num2 = Class1618.smethod_119(@class, class1547_0.workbook_0.Worksheets);
		}
		short_0[int_1 * 2] = num;
		short_0[int_1 * 2 + 1] = (short)num2;
	}

	private void method_2(XmlTextReader xmlTextReader_0)
	{
		xmlTextReader_0.WhitespaceHandling = WhitespaceHandling.Significant;
		xmlTextReader_0.MoveToContent();
		string namespaceURI = xmlTextReader_0.NamespaceURI;
		if (!Class1618.smethod_0(namespaceURI))
		{
			throw new CellsException(ExceptionType.InvalidData, "Error xml namespace " + namespaceURI);
		}
		if (xmlTextReader_0.NodeType != XmlNodeType.Element || xmlTextReader_0.LocalName != "sst")
		{
			throw new CellsException(ExceptionType.InvalidData, "SharedStringTable root element eror");
		}
		XmlNameTable nameTable = xmlTextReader_0.NameTable;
		string_0 = nameTable.Add(namespaceURI);
	}
}
