using System.Text;
using System.Xml;
using Aspose.Cells;
using ns16;
using ns25;

namespace ns50;

internal class Class1628
{
	private XmlTextWriter xmlTextWriter_0;

	private Worksheet worksheet_0;

	private Workbook workbook_0;

	internal Class1628(XmlTextWriter xmlTextWriter_1, Worksheet worksheet_1, Workbook workbook_1)
	{
		xmlTextWriter_0 = xmlTextWriter_1;
		worksheet_0 = worksheet_1;
		workbook_0 = workbook_1;
	}

	internal void Write()
	{
		if (worksheet_0.ConditionalFormattings == null)
		{
			return;
		}
		XmlTextWriter xmlTextWriter = xmlTextWriter_0;
		for (int i = 0; i < worksheet_0.ConditionalFormattings.Count; i++)
		{
			FormatConditionCollection formatConditionCollection = worksheet_0.ConditionalFormattings[i];
			xmlTextWriter.WriteStartElement("x:ConditionalFormatting");
			if (formatConditionCollection.arrayList_1 != null || formatConditionCollection.Count != 0)
			{
				string value = Class1618.smethod_31(formatConditionCollection.arrayList_1, 0, formatConditionCollection.arrayList_1.Count);
				xmlTextWriter.WriteElementString("x:Range", value);
				int[] array = formatConditionCollection.method_9();
				int int_ = array[0];
				int int_2 = array[1];
				for (int j = 0; j < formatConditionCollection.Count; j++)
				{
					FormatCondition formatCondition_ = formatConditionCollection[j];
					method_0(xmlTextWriter, formatCondition_, int_, int_2);
				}
				xmlTextWriter.WriteEndElement();
			}
		}
	}

	internal void method_0(XmlTextWriter xmlTextWriter_1, FormatCondition formatCondition_0, int int_0, int int_1)
	{
		xmlTextWriter_1.WriteStartElement("x:Condition");
		if (formatCondition_0.Type == FormatConditionType.CellValue && formatCondition_0.operatorType_0 != OperatorType.None)
		{
			string value = Class1631.smethod_0(formatCondition_0.operatorType_0);
			xmlTextWriter_1.WriteElementString("x:Qualifier", value);
		}
		xmlTextWriter_1.WriteStartElement("x:Value1");
		string[] array = Class1619.smethod_3(formatCondition_0);
		string string_ = array[0];
		xmlTextWriter_1.WriteString(Class1618.smethod_93(string_));
		xmlTextWriter_1.WriteEndElement();
		if (formatCondition_0.operatorType_0 == OperatorType.Between || formatCondition_0.operatorType_0 == OperatorType.NotBetween)
		{
			xmlTextWriter_1.WriteStartElement("x:Value2");
			string_ = array[1];
			xmlTextWriter_1.WriteString(Class1618.smethod_93(string_));
			xmlTextWriter_1.WriteEndElement();
		}
		string value2 = method_1(formatCondition_0);
		xmlTextWriter_1.WriteStartElement("x:Format");
		xmlTextWriter_1.WriteAttributeString("Style", value2);
		xmlTextWriter_1.WriteEndElement();
		xmlTextWriter_1.WriteEndElement();
	}

	internal string method_1(FormatCondition formatCondition_0)
	{
		Style style = formatCondition_0.Style;
		string text = method_2(style);
		string text2 = method_3(style);
		string text3 = method_4(style);
		string text4 = text + text2 + text3;
		if (text4.EndsWith(";"))
		{
			text4 = text4.Substring(0, text4.Length - 1);
		}
		return text4;
	}

	internal string method_2(Style style_0)
	{
		if (!style_0.IsModified(StyleModifyFlag.Font))
		{
			return "";
		}
		Font font = style_0.Font;
		StringBuilder stringBuilder = new StringBuilder(100);
		if (style_0.IsModified(StyleModifyFlag.FontColor))
		{
			if (font.InternalColor.method_2())
			{
				stringBuilder.Append("color:windowtext;");
			}
			else
			{
				stringBuilder.Append("color:#" + Class1618.smethod_64(font.Color) + ";");
			}
		}
		if (font.IsItalic)
		{
			stringBuilder.Append("font-style:italic;");
		}
		if (style_0.IsModified(StyleModifyFlag.FontWeight))
		{
			if (font.IsBold)
			{
				stringBuilder.Append("font-weight:700;");
			}
			else
			{
				stringBuilder.Append("font-weight:400;");
			}
		}
		if (style_0.IsModified(StyleModifyFlag.FontUnderline))
		{
			string text = Class1631.smethod_2(font.Underline);
			stringBuilder.Append("text-underline-style:" + text + ";");
		}
		if (style_0.IsModified(StyleModifyFlag.FontStrike))
		{
			if (font.IsStrikeout)
			{
				stringBuilder.Append("text-line-through:single;");
			}
			else
			{
				stringBuilder.Append("text-line-through:none;");
			}
		}
		return stringBuilder.ToString();
	}

	internal string method_3(Style style_0)
	{
		if (!style_0.IsModified(StyleModifyFlag.Borders))
		{
			return "";
		}
		StringBuilder stringBuilder = new StringBuilder(100);
		if (style_0.method_9())
		{
			stringBuilder.Append("border-top:" + Class1631.smethod_5(style_0, BorderType.TopBorder) + ";");
			stringBuilder.Append("border-right:" + Class1631.smethod_5(style_0, BorderType.RightBorder) + ";");
			stringBuilder.Append("border-bottom:" + Class1631.smethod_5(style_0, BorderType.BottomBorder) + ";");
			stringBuilder.Append("border-left:" + Class1631.smethod_5(style_0, BorderType.LeftBorder) + ";");
		}
		else
		{
			stringBuilder.Append("border:none;");
		}
		return stringBuilder.ToString();
	}

	internal string method_4(Style style_0)
	{
		if (!style_0.IsModified(StyleModifyFlag.Pattern) && !style_0.IsModified(StyleModifyFlag.BackgroundColor) && !style_0.IsModified(StyleModifyFlag.ForegroundColor))
		{
			return "";
		}
		return Class1631.smethod_4(style_0);
	}
}
