using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Xml;
using Aspose.Cells;
using ns1;
using ns16;
using ns22;
using ns25;

namespace ns50;

internal class Class1629
{
	private Worksheet worksheet_0;

	internal Class1629(Worksheet worksheet_1)
	{
		worksheet_0 = worksheet_1;
	}

	internal void Read(XmlTextReader xmlTextReader_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		int index = worksheet_0.ConditionalFormattings.Add();
		FormatConditionCollection formatConditionCollection = worksheet_0.ConditionalFormattings[index];
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "Range")
			{
				string text = xmlTextReader_0.ReadElementString();
				ArrayList arrayList = new ArrayList();
				if (text != null && text.Length > 0)
				{
					Class1631.smethod_12(text, arrayList);
				}
				formatConditionCollection.arrayList_1.AddRange(arrayList);
			}
			else if (xmlTextReader_0.LocalName == "Condition")
			{
				method_0(xmlTextReader_0, formatConditionCollection);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	internal void method_0(XmlTextReader xmlTextReader_0, FormatConditionCollection formatConditionCollection_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		int[] array = formatConditionCollection_0.method_9();
		int int_ = array[0];
		int int_2 = array[1];
		string text = null;
		string text2 = null;
		string text3 = null;
		string text4 = null;
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "Qualifier")
			{
				text = xmlTextReader_0.ReadElementString();
			}
			else if (xmlTextReader_0.LocalName == "Value1")
			{
				text2 = xmlTextReader_0.ReadElementString();
				text2 = Class1618.smethod_93(text2);
				text2 = Class1619.smethod_10(text2, int_, int_2);
			}
			else if (xmlTextReader_0.LocalName == "Value2")
			{
				text3 = xmlTextReader_0.ReadElementString();
				text3 = Class1618.smethod_93(text3);
				text3 = Class1619.smethod_10(text3, int_, int_2);
			}
			else if (xmlTextReader_0.LocalName == "Format")
			{
				text4 = xmlTextReader_0.GetAttribute("Style");
				xmlTextReader_0.Skip();
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
		OperatorType operatorType = OperatorType.None;
		FormatConditionType type = FormatConditionType.CellValue;
		if (text == null)
		{
			type = FormatConditionType.Expression;
			if (text2 != null && text2.Length > 0 && text2[0] != '=')
			{
				text2 = '=' + text2;
			}
			if (text3 != null && text3.Length > 0 && text3[0] != '=')
			{
				text3 = '=' + text3;
			}
		}
		else
		{
			operatorType = Class1631.smethod_1(text);
		}
		int index = formatConditionCollection_0.AddCondition(type, operatorType, text2, text3);
		if (text4 != null)
		{
			method_1(text4, formatConditionCollection_0[index]);
		}
	}

	private void method_1(string string_0, FormatCondition formatCondition_0)
	{
		Style style = formatCondition_0.Style;
		string[] array = string_0.Split(';');
		for (int i = 0; i < array.Length; i++)
		{
			string text = array[i].Trim();
			if (text.Length == 0)
			{
				continue;
			}
			string[] array2 = text.Split(':');
			if (array2.Length >= 1)
			{
				string text2 = array2[0].Trim();
				string text3 = array2[1].Trim();
				if (text2.Length != 0 && text3.Length != 0)
				{
					method_2(style, text2, text3);
				}
			}
		}
	}

	private Color GetColor(string string_0)
	{
		Color result = Color.Empty;
		try
		{
			if (string_0.StartsWith("#"))
			{
				result = Class1631.smethod_6(string_0.Substring(1));
			}
			else
			{
				result = Color.FromName(string_0);
				if (result.A == 0 && result.R == 0 && result.G == 0 && result.B == 0 && string_0.ToLower() != "black")
				{
					result = Color.Empty;
				}
			}
		}
		catch
		{
		}
		return result;
	}

	private void method_2(Style style_0, string string_0, string string_1)
	{
		string key;
		if ((key = string_0) == null)
		{
			return;
		}
		if (Class1742.dictionary_189 == null)
		{
			Class1742.dictionary_189 = new Dictionary<string, int>(13)
			{
				{ "color", 0 },
				{ "font-style", 1 },
				{ "font-weight", 2 },
				{ "text-underline-style", 3 },
				{ "text-line-through", 4 },
				{ "border-top", 5 },
				{ "border-right", 6 },
				{ "border-bottom", 7 },
				{ "border-left", 8 },
				{ "border", 9 },
				{ "background", 10 },
				{ "mso-background-source", 11 },
				{ "mso-pattern", 12 }
			};
		}
		if (!Class1742.dictionary_189.TryGetValue(key, out var value))
		{
			return;
		}
		switch (value)
		{
		case 0:
		{
			if (string_1 == "windowtext")
			{
				style_0.Font.InternalColor.method_3(bool_0: true);
				style_0.method_36(StyleModifyFlag.FontColor);
				break;
			}
			Color color = GetColor(string_1);
			if (!Class1178.smethod_0(color))
			{
				style_0.Font.Color = color;
			}
			break;
		}
		case 1:
			if (string_1 == "italic")
			{
				style_0.Font.IsItalic = true;
			}
			break;
		case 2:
			style_0.Font.Weight = int.Parse(string_1);
			break;
		case 3:
			style_0.Font.Underline = Class1631.smethod_3(string_1);
			break;
		case 4:
			if (string_1 == "none")
			{
				style_0.Font.IsStrikeout = false;
			}
			else
			{
				style_0.Font.IsStrikeout = true;
			}
			break;
		case 5:
			method_4(style_0, BorderType.TopBorder, string_1);
			break;
		case 6:
			method_4(style_0, BorderType.RightBorder, string_1);
			break;
		case 7:
			method_4(style_0, BorderType.BottomBorder, string_1);
			break;
		case 8:
			method_4(style_0, BorderType.LeftBorder, string_1);
			break;
		case 9:
			method_4(style_0, BorderType.TopBorder, string_1);
			method_4(style_0, BorderType.RightBorder, string_1);
			method_4(style_0, BorderType.BottomBorder, string_1);
			method_4(style_0, BorderType.LeftBorder, string_1);
			break;
		case 10:
			SetBackground(style_0, string_1);
			break;
		case 11:
			SetBackground(style_0, string_1);
			break;
		case 12:
			method_3(style_0, string_1);
			break;
		}
	}

	private void method_3(Style style_0, string string_0)
	{
		string text = null;
		string text2 = null;
		string[] array = string_0.Split(' ');
		if (array.Length == 2)
		{
			text = array[0];
			text2 = array[1];
		}
		else
		{
			text = array[0];
			text2 = array[0];
		}
		if (text == "auto")
		{
			style_0.ForeInternalColor.method_3(bool_0: true);
			style_0.method_36(StyleModifyFlag.ForegroundColor);
		}
		else
		{
			Color color = GetColor(text);
			if (!Class1178.smethod_0(color))
			{
				style_0.ForegroundColor = color;
			}
		}
		BackgroundType backgroundType = Class1631.smethod_8(text2);
		if (backgroundType != 0)
		{
			style_0.Pattern = backgroundType;
		}
	}

	private void SetBackground(Style style_0, string string_0)
	{
		if (string_0 == "auto")
		{
			style_0.BackgroundInternalColor.method_3(bool_0: true);
			style_0.method_36(StyleModifyFlag.BackgroundColor);
			return;
		}
		Color color = GetColor(string_0);
		if (!Class1178.smethod_0(color))
		{
			style_0.BackgroundColor = color;
		}
	}

	private void method_4(Style style_0, BorderType borderType_0, string string_0)
	{
		Border border = style_0.Borders[borderType_0];
		if (string_0 == "none")
		{
			border.LineStyle = CellBorderType.None;
			return;
		}
		string[] array = string_0.Split(' ');
		if (array.Length != 3)
		{
			return;
		}
		try
		{
			border.LineStyle = Class1631.smethod_7(array[0] + " " + array[1]);
		}
		catch
		{
		}
		string text = array[2];
		if (text == "windowtext")
		{
			border.InternalColor.method_3(bool_0: true);
			return;
		}
		Color color = GetColor(text);
		if (!Class1178.smethod_0(color))
		{
			border.Color = color;
		}
	}
}
