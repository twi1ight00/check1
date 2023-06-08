using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Xml;
using Aspose.Cells;
using Aspose.Cells.Charts;
using Aspose.Cells.Drawing;
using ns1;
using ns2;
using ns22;
using ns8;

namespace ns16;

internal class Class1592
{
	private Class1541 class1541_0;

	private XmlDocument xmlDocument_0;

	private ArrayList arrayList_0;

	private ArrayList arrayList_1;

	private string string_0 = "urn:schemas-microsoft-com:vml";

	private string string_1 = "urn:schemas-microsoft-com:office:office";

	private string string_2 = "urn:schemas-microsoft-com:office:excel";

	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5;

	private bool bool_6;

	private bool bool_7;

	private int int_0;

	internal Class1592(Class1541 class1541_1)
	{
		class1541_0 = class1541_1;
		bool_1 = class1541_0.method_17();
		bool_0 = class1541_0.method_19();
		bool_3 = class1541_0.method_11();
		bool_5 = class1541_0.method_18();
		bool_7 = class1541_0.method_12();
		arrayList_0 = new ArrayList();
		arrayList_1 = new ArrayList();
	}

	internal void Write(Stream6 stream6_0, string string_3)
	{
		if (bool_1 || bool_0 || bool_3 || bool_5 || bool_7)
		{
			method_0();
			method_41(stream6_0, string_3);
		}
	}

	private void method_0()
	{
		xmlDocument_0 = new XmlDocument();
		if (bool_0)
		{
			xmlDocument_0 = Class1613.smethod_0(class1541_0.class1540_0.class746_0, class1541_0.worksheet_0.class1557_0.string_2);
			if (xmlDocument_0 != null)
			{
				method_33();
			}
		}
		else
		{
			method_1();
		}
		if (xmlDocument_0 == null)
		{
			xmlDocument_0 = new XmlDocument();
			method_1();
		}
		if (!bool_1 && !bool_3 && !bool_5 && !bool_7)
		{
			return;
		}
		if (bool_1 && !bool_2)
		{
			method_28();
		}
		if ((bool_3 || bool_7) && !bool_4)
		{
			method_29();
		}
		if (bool_5 && !bool_6)
		{
			method_30();
		}
		if (bool_1)
		{
			for (int i = 0; i < class1541_0.worksheet_0.Comments.Count; i++)
			{
				Comment comment = class1541_0.worksheet_0.Comments[i];
				if (arrayList_0.Count <= 0 || !arrayList_0.Contains(comment))
				{
					method_17(comment);
				}
			}
		}
		if (bool_3)
		{
			int count = class1541_0.arrayList_3.Count;
			for (int j = 0; j < count; j++)
			{
				Class1538 class1538_ = (Class1538)class1541_0.arrayList_3[j];
				method_23(class1538_);
			}
		}
		if (bool_7)
		{
			int count2 = class1541_0.arrayList_4.Count;
			for (int k = 0; k < count2; k++)
			{
				Class527 @class = (Class527)class1541_0.arrayList_4[k];
				if (arrayList_1.Count <= 0 || !arrayList_1.Contains(@class.picture_0))
				{
					method_24(@class);
				}
			}
		}
		if (!bool_5)
		{
			return;
		}
		foreach (object item in class1541_0.class1534_1.arrayList_1)
		{
			Shape shape_ = (Shape)item;
			method_5(shape_);
		}
	}

	private void method_1()
	{
		method_42();
		method_32();
	}

	private double method_2(double double_0)
	{
		return double_0 / 72.0 * 2.54 * 10.0;
	}

	[Attribute0(true)]
	private Class1737 method_3(XmlElement xmlElement_0, Shape shape_0)
	{
		Class1737 @class = null;
		if (shape_0.MsoDrawingType == MsoDrawingType.CheckBox)
		{
			@class = ((CheckBox)shape_0).method_63();
		}
		else if (shape_0.MsoDrawingType == MsoDrawingType.Label)
		{
			@class = ((Label)shape_0).method_63();
		}
		else if (shape_0.MsoDrawingType == MsoDrawingType.Button)
		{
			@class = ((Button)shape_0).method_63();
		}
		else if (shape_0.MsoDrawingType == MsoDrawingType.RadioButton)
		{
			@class = ((RadioButton)shape_0).method_63();
		}
		else
		{
			if (shape_0.MsoDrawingType != MsoDrawingType.GroupBox)
			{
				return null;
			}
			@class = ((GroupBox)shape_0).method_63();
		}
		MsoTextFrame textFrame = shape_0.TextFrame;
		string text = null;
		if (!textFrame.IsAutoMargin)
		{
			text = method_2(textFrame.LeftMarginPt) + "mm," + method_2(textFrame.TopMarginPt) + "mm," + method_2(textFrame.RightMarginPt) + "mm," + method_2(textFrame.BottomMarginPt) + "mm";
		}
		XmlElement xmlElement = method_45(xmlElement_0, "v", "textbox", string_0);
		string text2 = "mso-direction-alt:auto";
		if (shape_0.TextFrame.AutoSize)
		{
			text2 += ";mso-fit-shape-to-text:t";
		}
		method_43(xmlElement, "style", text2);
		if (text != null)
		{
			method_43(xmlElement, "inset", text);
		}
		method_44(xmlElement, "o", "singleclick", string_1, "f");
		XmlElement xmlElement2 = method_46(xmlElement, "div");
		method_43(xmlElement2, "style", "text-align:left");
		method_44(xmlElement2, "o", "singleclick", string_1, "f");
		Aspose.Cells.Font font = @class.Font;
		if (@class.method_12() != null && @class.method_12().Count > 0)
		{
			int count = @class.method_12().Count;
			for (int i = 0; i < count; i++)
			{
				FontSetting fontSetting = (FontSetting)@class.method_12()[i];
				Aspose.Cells.Font font2 = fontSetting.method_2();
				if (font2 == null)
				{
					font2 = font;
				}
				if (i == 0 && fontSetting.StartIndex != 0)
				{
					method_4(xmlElement2, font, @class.Text.Substring(0, fontSetting.StartIndex));
				}
				method_4(xmlElement2, font2, @class.Text.Substring(fontSetting.StartIndex, fontSetting.Length));
				if (i == count - 1)
				{
					int num = fontSetting.StartIndex + fontSetting.Length;
					int num2 = @class.Text.Length - num;
					if (num2 > 0)
					{
						method_4(xmlElement2, font, @class.Text.Substring(num, num2));
					}
				}
			}
		}
		else if (@class.Text != null)
		{
			method_4(xmlElement2, font, @class.Text);
		}
		string outerXml = xmlElement2.OuterXml;
		xmlElement.RemoveChild(xmlElement2);
		Class1188.smethod_10(xmlElement, outerXml);
		return @class;
	}

	[Attribute0(true)]
	private void method_4(XmlElement xmlElement_0, Aspose.Cells.Font font_0, string string_3)
	{
		XmlElement xmlElement = method_46(xmlElement_0, "font");
		method_43(xmlElement, "face", font_0.Name);
		method_43(xmlElement, "size", Class1618.smethod_80(font_0.Size * 20));
		string string_4 = "auto";
		if (!font_0.InternalColor.method_2())
		{
			string_4 = Class1618.smethod_80(font_0.ColorIndex);
		}
		method_43(xmlElement, "color", string_4);
		string_3 = Class1486.smethod_2(string_3);
		Class1188.smethod_10(xmlElement, string_3);
	}

	private void method_5(Shape shape_0)
	{
		MsoDrawingType msoDrawingType = shape_0.MsoDrawingType;
		XmlElement xmlElement_ = method_45(xmlDocument_0.DocumentElement, "v", "shape", string_0);
		method_6(xmlElement_, shape_0);
		method_22(xmlElement_, shape_0);
		if (shape_0.LineFormat.IsVisible)
		{
			XmlElement xmlElement_2 = method_45(xmlElement_, "v", "stroke", string_0);
			method_43(xmlElement_2, "dashstyle", Class1618.smethod_60(shape_0.LineFormat.DashStyle));
			method_43(xmlElement_2, "linestyle", Class1618.smethod_56(shape_0.LineFormat.Style));
		}
		if (msoDrawingType == MsoDrawingType.CheckBox || msoDrawingType == MsoDrawingType.RadioButton)
		{
			XmlElement xmlElement_3 = method_45(xmlElement_, "v", "path", string_0);
			method_43(xmlElement_3, "shadowok", "t");
			method_43(xmlElement_3, "strokeok", "t");
			method_43(xmlElement_3, "fillok", "t");
		}
		XmlElement xmlElement_4 = method_45(xmlElement_, "o", "lock", string_1);
		method_44(xmlElement_4, "v", "ext", string_0, "edit");
		method_43(xmlElement_4, "rotation", "t");
		if (msoDrawingType == MsoDrawingType.Button || msoDrawingType == MsoDrawingType.ComboBox || msoDrawingType == MsoDrawingType.ListBox || msoDrawingType == MsoDrawingType.ScrollBar || msoDrawingType == MsoDrawingType.Spinner)
		{
			method_43(xmlElement_4, "text", "t");
		}
		Class1737 class1737_ = method_3(xmlElement_, shape_0);
		method_7(xmlElement_, shape_0, class1737_);
	}

	private void method_6(XmlElement xmlElement_0, Shape shape_0)
	{
		MsoDrawingType msoDrawingType = shape_0.MsoDrawingType;
		string text = method_20(shape_0);
		if (text != null)
		{
			method_43(xmlElement_0, "id", text);
		}
		string text2 = method_21(shape_0);
		if (text2 != null)
		{
			method_44(xmlElement_0, "o", "spid", string_1, text2);
		}
		method_43(xmlElement_0, "type", "#_x0000_t201");
		Hyperlink hyperlink = shape_0.Hyperlink;
		if (hyperlink != null)
		{
			method_43(xmlElement_0, "href", hyperlink.Address);
		}
		method_43(xmlElement_0, "style", method_26(shape_0));
		switch (msoDrawingType)
		{
		case MsoDrawingType.Button:
			method_44(xmlElement_0, "o", "button", string_1, "t");
			break;
		default:
		{
			string string_ = ((shape_0.FillFormat == null || !shape_0.FillFormat.IsVisible) ? "f" : "t");
			method_43(xmlElement_0, "filled", string_);
			break;
		}
		case MsoDrawingType.ScrollBar:
		case MsoDrawingType.ListBox:
			break;
		}
		if (msoDrawingType != MsoDrawingType.ListBox && msoDrawingType != MsoDrawingType.ScrollBar)
		{
			method_43(xmlElement_0, "fillcolor", method_19(shape_0));
		}
		string string_2 = "t";
		if (!shape_0.LineFormat.IsVisible)
		{
			string_2 = "f";
		}
		method_43(xmlElement_0, "stroked", string_2);
		if (shape_0.LineFormat.IsVisible)
		{
			method_43(xmlElement_0, "strokecolor", method_18(shape_0));
			method_43(xmlElement_0, "strokeweight", shape_0.LineFormat.Weight + "pt");
		}
		if (shape_0.bool_1)
		{
			method_44(xmlElement_0, "o", "insetmode", string_1, "auto");
		}
	}

	private void method_7(XmlElement xmlElement_0, Shape shape_0, Class1737 class1737_0)
	{
		MsoDrawingType msoDrawingType = shape_0.MsoDrawingType;
		XmlElement xmlElement_ = method_45(xmlElement_0, "x", "ClientData", this.string_2);
		string string_ = method_16(shape_0);
		method_43(xmlElement_, "ObjectType", string_);
		if (shape_0.Placement == PlacementType.FreeFloating)
		{
			method_45(xmlElement_, "x", "MoveWithCells", this.string_2);
		}
		if (shape_0.Placement == PlacementType.FreeFloating || shape_0.Placement == PlacementType.Move)
		{
			method_45(xmlElement_, "x", "SizeWithCells", this.string_2);
		}
		XmlElement xmlNode_ = method_45(xmlElement_, "x", "Anchor", this.string_2);
		Class1188.smethod_12(xmlNode_, method_25(shape_0));
		if (!shape_0.IsLocked)
		{
			XmlElement xmlNode_2 = method_45(xmlElement_, "x", "Locked", this.string_2);
			Class1188.smethod_12(xmlNode_2, "False");
		}
		if (!shape_0.IsPrintable)
		{
			XmlElement xmlNode_3 = method_45(xmlElement_, "x", "PrintObject", this.string_2);
			Class1188.smethod_12(xmlNode_3, "False");
		}
		if (msoDrawingType != MsoDrawingType.Spinner && msoDrawingType != MsoDrawingType.ScrollBar)
		{
			XmlElement xmlNode_4 = method_45(xmlElement_, "x", "AutoFill", this.string_2);
			Class1188.smethod_12(xmlNode_4, "False");
			if (msoDrawingType != MsoDrawingType.ListBox && msoDrawingType != MsoDrawingType.GroupBox)
			{
				XmlElement xmlNode_5 = method_45(xmlElement_, "x", "AutoLine", this.string_2);
				Class1188.smethod_12(xmlNode_5, "False");
			}
		}
		if (shape_0.method_0() != null)
		{
			XmlElement xmlNode_6 = method_45(xmlElement_, "x", "FmlaMacro", this.string_2);
			Class1188.smethod_12(xmlNode_6, shape_0.method_0());
		}
		if (msoDrawingType != MsoDrawingType.GroupBox)
		{
			method_15(xmlElement_, class1737_0);
		}
		if (msoDrawingType == MsoDrawingType.CheckBox)
		{
			method_14(xmlElement_, shape_0);
		}
		if (shape_0.method_58() != null)
		{
			string string_2 = "FmlaLink";
			if (msoDrawingType == MsoDrawingType.Button || msoDrawingType == MsoDrawingType.GroupBox)
			{
				string_2 = "FmlaTxbx";
			}
			XmlElement xmlNode_7 = method_45(xmlElement_, "x", string_2, this.string_2);
			Class1188.smethod_12(xmlNode_7, shape_0.LinkedCell);
		}
		method_11(xmlElement_, shape_0);
		switch (msoDrawingType)
		{
		case MsoDrawingType.ComboBox:
			method_13(xmlElement_, shape_0);
			break;
		case MsoDrawingType.Spinner:
			method_12(xmlElement_, shape_0);
			break;
		case MsoDrawingType.ListBox:
			method_10(xmlElement_, shape_0);
			break;
		case MsoDrawingType.RadioButton:
			method_8(xmlElement_, shape_0);
			break;
		case MsoDrawingType.ScrollBar:
			method_9(xmlElement_, shape_0);
			break;
		}
	}

	private void method_8(XmlElement xmlElement_0, Shape shape_0)
	{
		RadioButton radioButton = (RadioButton)shape_0;
		XmlElement xmlElement = null;
		if (radioButton.IsChecked)
		{
			xmlElement = method_45(xmlElement_0, "x", "Checked", string_2);
			Class1188.smethod_12(xmlElement, "1");
		}
	}

	private void method_9(XmlElement xmlElement_0, Shape shape_0)
	{
		ScrollBar scrollBar = (ScrollBar)shape_0;
		XmlElement xmlElement = null;
		xmlElement = method_45(xmlElement_0, "x", "Val", string_2);
		Class1188.smethod_12(xmlElement, Class1618.smethod_80(scrollBar.CurrentValue));
		xmlElement = method_45(xmlElement_0, "x", "Min", string_2);
		Class1188.smethod_12(xmlElement, Class1618.smethod_80(scrollBar.Min));
		xmlElement = method_45(xmlElement_0, "x", "Max", string_2);
		Class1188.smethod_12(xmlElement, Class1618.smethod_80(scrollBar.Max));
		xmlElement = method_45(xmlElement_0, "x", "Inc", string_2);
		Class1188.smethod_12(xmlElement, Class1618.smethod_80(scrollBar.IncrementalChange));
		xmlElement = method_45(xmlElement_0, "x", "Page", string_2);
		Class1188.smethod_12(xmlElement, Class1618.smethod_80(scrollBar.PageChange));
		if (scrollBar.IsHorizontal)
		{
			xmlElement = method_45(xmlElement_0, "x", "Horiz", string_2);
		}
		xmlElement = method_45(xmlElement_0, "x", "Dx", string_2);
		Class1188.smethod_12(xmlElement, Class1618.smethod_80(15));
	}

	private void method_10(XmlElement xmlElement_0, Shape shape_0)
	{
		ListBox listBox = (ListBox)shape_0;
		XmlElement xmlElement = null;
		xmlElement = method_45(xmlElement_0, "x", "Val", string_2);
		Class1188.smethod_12(xmlElement, Class1618.smethod_80(listBox.method_74()));
		xmlElement = method_45(xmlElement_0, "x", "Min", string_2);
		Class1188.smethod_12(xmlElement, Class1618.smethod_80(listBox.method_76()));
		xmlElement = method_45(xmlElement_0, "x", "Max", string_2);
		Class1188.smethod_12(xmlElement, Class1618.smethod_80(listBox.method_78()));
		xmlElement = method_45(xmlElement_0, "x", "Inc", string_2);
		Class1188.smethod_12(xmlElement, Class1618.smethod_80(listBox.IncrementalChange));
		xmlElement = method_45(xmlElement_0, "x", "Page", string_2);
		Class1188.smethod_12(xmlElement, Class1618.smethod_80(listBox.PageChange));
		xmlElement = method_45(xmlElement_0, "x", "Dx", string_2);
		Class1188.smethod_12(xmlElement, Class1618.smethod_80(15));
		string inputRange = listBox.InputRange;
		if (inputRange != null)
		{
			xmlElement = method_45(xmlElement_0, "x", "FmlaRange", string_2);
			Class1188.smethod_12(xmlElement, inputRange);
		}
		int num = listBox.SelectedIndex + 1;
		xmlElement = method_45(xmlElement_0, "x", "Sel", string_2);
		Class1188.smethod_12(xmlElement, Class1618.smethod_80(num));
		if (!listBox.Shadow)
		{
			method_45(xmlElement_0, "x", "NoThreeD2", string_2);
		}
		xmlElement = method_45(xmlElement_0, "x", "SelType", string_2);
		Class1188.smethod_12(xmlElement, Class1618.smethod_199(listBox.SelectionType));
		if (listBox.SelectionType != 0 && listBox.method_72() != null && listBox.method_72().Count > 0)
		{
			StringBuilder stringBuilder = new StringBuilder(((ushort)listBox.method_72()[0] + 1).ToString());
			for (int i = 1; i < listBox.method_72().Count; i++)
			{
				stringBuilder.Append(", ").Append(((ushort)listBox.method_72()[i] + 1).ToString());
			}
			xmlElement = method_45(xmlElement_0, "x", "MultiSel", string_2);
			Class1188.smethod_12(xmlElement, stringBuilder.ToString());
		}
		xmlElement = method_45(xmlElement_0, "x", "LCT", string_2);
		Class1188.smethod_12(xmlElement, "Normal");
	}

	private void method_11(XmlElement xmlElement_0, Shape shape_0)
	{
		switch (shape_0.MsoDrawingType)
		{
		case MsoDrawingType.CheckBox:
		{
			CheckBox checkBox = (CheckBox)shape_0;
			if (!checkBox.Shadow)
			{
				method_45(xmlElement_0, "x", "NoThreeD", string_2);
			}
			break;
		}
		case MsoDrawingType.Spinner:
		{
			Spinner spinner = (Spinner)shape_0;
			if (!spinner.Shadow)
			{
				method_45(xmlElement_0, "x", "NoThreeD", string_2);
			}
			break;
		}
		case MsoDrawingType.RadioButton:
		{
			RadioButton radioButton = (RadioButton)shape_0;
			if (!radioButton.Shadow)
			{
				method_45(xmlElement_0, "x", "NoThreeD", string_2);
			}
			break;
		}
		case MsoDrawingType.GroupBox:
		{
			GroupBox groupBox = (GroupBox)shape_0;
			if (!groupBox.Shadow)
			{
				method_45(xmlElement_0, "x", "NoThreeD", string_2);
			}
			break;
		}
		}
	}

	private void method_12(XmlElement xmlElement_0, Shape shape_0)
	{
		Spinner spinner = (Spinner)shape_0;
		XmlElement xmlElement = null;
		xmlElement = method_45(xmlElement_0, "x", "Val", string_2);
		Class1188.smethod_12(xmlElement, Class1618.smethod_80(spinner.CurrentValue));
		xmlElement = method_45(xmlElement_0, "x", "Min", string_2);
		Class1188.smethod_12(xmlElement, Class1618.smethod_80(spinner.Min));
		xmlElement = method_45(xmlElement_0, "x", "Max", string_2);
		Class1188.smethod_12(xmlElement, Class1618.smethod_80(spinner.Max));
		xmlElement = method_45(xmlElement_0, "x", "Inc", string_2);
		Class1188.smethod_12(xmlElement, Class1618.smethod_80(spinner.IncrementalChange));
		xmlElement = method_45(xmlElement_0, "x", "Page", string_2);
		Class1188.smethod_12(xmlElement, Class1618.smethod_80(spinner.PageChange));
		xmlElement = method_45(xmlElement_0, "x", "Dx", string_2);
		Class1188.smethod_12(xmlElement, Class1618.smethod_80(15));
	}

	private void method_13(XmlElement xmlElement_0, Shape shape_0)
	{
		ComboBox comboBox = (ComboBox)shape_0;
		XmlElement xmlElement = null;
		xmlElement = method_45(xmlElement_0, "x", "Inc", string_2);
		Class1188.smethod_12(xmlElement, Class1618.smethod_80(1));
		xmlElement = method_45(xmlElement_0, "x", "Dx", string_2);
		Class1188.smethod_12(xmlElement, Class1618.smethod_80(15));
		string inputRange = comboBox.InputRange;
		if (inputRange != null)
		{
			xmlElement = method_45(xmlElement_0, "x", "FmlaRange", string_2);
			Class1188.smethod_12(xmlElement, inputRange);
		}
		int num = Math.Max(0, comboBox.SelectedIndex + 1);
		xmlElement = method_45(xmlElement_0, "x", "Sel", string_2);
		Class1188.smethod_12(xmlElement, Class1618.smethod_80(num));
		if (!comboBox.Shadow)
		{
			method_45(xmlElement_0, "x", "NoThreeD2", string_2);
		}
		xmlElement = method_45(xmlElement_0, "x", "LCT", string_2);
		Class1188.smethod_12(xmlElement, "Normal");
		if (comboBox.string_4 != null)
		{
			int num2 = comboBox.string_4.Length;
			for (int i = 0; i < num2; i++)
			{
				string text = comboBox.string_4[i];
				xmlElement = method_45(xmlElement_0, "x", "ListItem", string_2);
				Class1188.smethod_12(xmlElement, text);
			}
		}
		xmlElement = method_45(xmlElement_0, "x", "DropStyle", string_2);
		Class1188.smethod_12(xmlElement, "Combo");
		xmlElement = method_45(xmlElement_0, "x", "DropLines", string_2);
		Class1188.smethod_12(xmlElement, Class1618.smethod_80(comboBox.DropDownLines));
	}

	private void method_14(XmlElement xmlElement_0, Shape shape_0)
	{
		CheckBox checkBox = (CheckBox)shape_0;
		if (checkBox.method_70() != 0)
		{
			string text = "1";
			if (checkBox.method_70() == CheckValueType.Mixed)
			{
				text = "2";
			}
			XmlElement xmlNode_ = method_45(xmlElement_0, "x", "Checked", string_2);
			Class1188.smethod_12(xmlNode_, text);
		}
	}

	private void method_15(XmlElement xmlElement_0, Class1737 class1737_0)
	{
		if (class1737_0 == null)
		{
			return;
		}
		if (class1737_0.TextVerticalAlignment != TextAlignmentType.General)
		{
			string text = Class1618.smethod_157(class1737_0.TextVerticalAlignment);
			if (text != null)
			{
				XmlElement xmlNode_ = method_45(xmlElement_0, "x", "TextVAlign", string_2);
				Class1188.smethod_12(xmlNode_, text);
			}
		}
		if (class1737_0.TextHorizontalAlignment != TextAlignmentType.General)
		{
			string text2 = Class1618.smethod_157(class1737_0.TextHorizontalAlignment);
			if (text2 != null)
			{
				XmlElement xmlNode_2 = method_45(xmlElement_0, "x", "TextHAlign", string_2);
				Class1188.smethod_12(xmlNode_2, text2);
			}
		}
	}

	private string method_16(Shape shape_0)
	{
		return shape_0.MsoDrawingType switch
		{
			MsoDrawingType.Button => "Button", 
			MsoDrawingType.CheckBox => "Checkbox", 
			MsoDrawingType.RadioButton => "Radio", 
			MsoDrawingType.Label => "Label", 
			MsoDrawingType.Spinner => "Spin", 
			MsoDrawingType.ScrollBar => "Scroll", 
			MsoDrawingType.ListBox => "List", 
			MsoDrawingType.GroupBox => "GBox", 
			MsoDrawingType.ComboBox => "Drop", 
			_ => null, 
		};
	}

	private void method_17(Comment comment_0)
	{
		CommentShape commentShape = comment_0.CommentShape;
		XmlElement xmlElement_ = method_45(xmlDocument_0.DocumentElement, "v", "shape", string_0);
		string text = method_20(commentShape);
		if (text != null)
		{
			method_43(xmlElement_, "id", text);
		}
		string string_ = method_19(commentShape);
		string string_2 = method_18(commentShape);
		method_43(xmlElement_, "type", "#_x0000_t202");
		method_43(xmlElement_, "style", method_26(commentShape));
		method_43(xmlElement_, "fillcolor", string_);
		if (commentShape.LineFormat.IsVisible)
		{
			method_43(xmlElement_, "strokecolor", string_2);
			method_43(xmlElement_, "strokeweight", commentShape.LineFormat.Weight + "pt");
		}
		method_44(xmlElement_, "o", "insetmode", string_1, "auto");
		method_22(xmlElement_, commentShape);
		if (commentShape.LineFormat.IsVisible)
		{
			XmlElement xmlElement_2 = method_45(xmlElement_, "v", "stroke", string_0);
			method_43(xmlElement_2, "dashstyle", Class1618.smethod_60(commentShape.LineFormat.DashStyle));
			method_43(xmlElement_2, "linestyle", Class1618.smethod_56(commentShape.LineFormat.Style));
		}
		XmlElement xmlElement_3 = method_45(xmlElement_, "v", "shadow", string_0);
		method_43(xmlElement_3, "on", "t");
		method_43(xmlElement_3, "color", "silver");
		method_43(xmlElement_3, "opacity", ".5");
		method_43(xmlElement_3, "obscured", "t");
		method_45(xmlElement_, "v", "path", string_0);
		method_44(xmlElement_, "o", "connecttype", string_1, "none");
		XmlElement xmlElement_4 = method_45(xmlElement_, "v", "textbox", string_0);
		string text2 = "mso-direction-alt:auto";
		if (commentShape.TextFrame.AutoSize)
		{
			text2 += ";mso-fit-shape-to-text:t";
		}
		method_43(xmlElement_4, "style", text2);
		XmlElement xmlElement_5 = method_46(xmlElement_4, "div");
		method_43(xmlElement_5, "style", "text-align:left");
		XmlElement xmlElement_6 = method_45(xmlElement_, "x", "ClientData", this.string_2);
		method_43(xmlElement_6, "ObjectType", "Note");
		XmlElement xmlNode_ = method_45(xmlElement_6, "x", "Anchor", this.string_2);
		Class1188.smethod_12(xmlNode_, method_25(commentShape));
		XmlElement xmlNode_2 = method_45(xmlElement_6, "x", "Row", this.string_2);
		Class1188.smethod_12(xmlNode_2, Class1618.smethod_80(comment_0.Row));
		XmlElement xmlNode_3 = method_45(xmlElement_6, "x", "Column", this.string_2);
		Class1188.smethod_12(xmlNode_3, Class1618.smethod_80(comment_0.Column));
	}

	private string method_18(Shape shape_0)
	{
		if (!shape_0.LineFormat.IsVisible)
		{
			return null;
		}
		return "#" + Class1618.smethod_64(shape_0.LineFormat.ForeColor);
	}

	private string method_19(Shape shape_0)
	{
		string text = null;
		MsoDrawingType msoDrawingType = shape_0.MsoDrawingType;
		if (msoDrawingType != MsoDrawingType.ListBox && msoDrawingType != MsoDrawingType.ScrollBar)
		{
			if (shape_0.Fill.Type == FillType.Solid)
			{
				Color color = shape_0.Fill.SolidFill.Color;
				if (color.IsEmpty)
				{
					return "window [65]";
				}
				return "#" + Class1618.smethod_64(color);
			}
			if (msoDrawingType == MsoDrawingType.Button)
			{
				return "buttonFace [67]";
			}
			return "window [65]";
		}
		return null;
	}

	private string method_20(Shape shape_0)
	{
		string text = null;
		if (shape_0.class1556_0 != null)
		{
			text = shape_0.class1556_0.string_0;
		}
		string stringValue = shape_0.method_27().method_2().GetStringValue(50048);
		if (stringValue != null && stringValue != "")
		{
			text = stringValue;
		}
		if (shape_0.MsoDrawingType == MsoDrawingType.OleObject)
		{
			return XmlConvert.EncodeName(text);
		}
		if (text == null)
		{
			text = shape_0.Name;
		}
		return XmlConvert.EncodeName(text);
	}

	private string method_21(Shape shape_0)
	{
		if (shape_0.class1556_0 != null)
		{
			return XmlConvert.EncodeName(shape_0.class1556_0.string_1);
		}
		return null;
	}

	private void method_22(XmlElement xmlElement_0, Shape shape_0)
	{
		string text = class1541_0.class1534_1.method_1(shape_0);
		if (shape_0.MsoDrawingType == MsoDrawingType.OleObject)
		{
			XmlElement xmlElement_ = method_45(xmlElement_0, "v", "fill", string_0);
			if (text != null)
			{
				method_44(xmlElement_, "o", "relid", string_1, text);
			}
			method_43(xmlElement_, "color2", "window [65]");
			if (text != null)
			{
				method_43(xmlElement_, "type", "frame");
			}
		}
		else if (shape_0.MsoDrawingType == MsoDrawingType.Comment)
		{
			XmlElement xmlElement_2 = method_45(xmlElement_0, "v", "fill", string_0);
			if (text != null)
			{
				method_44(xmlElement_2, "o", "relid", string_1, text);
			}
			if (shape_0.FillFormat.method_0() != 1.0)
			{
				method_43(xmlElement_2, "opacity", Class1618.smethod_79(shape_0.FillFormat.method_0()));
			}
			method_43(xmlElement_2, "color2", method_19(shape_0));
			if (text != null)
			{
				method_43(xmlElement_2, "type", "frame");
			}
		}
		else if (shape_0.MsoDrawingType == MsoDrawingType.Button)
		{
			XmlElement xmlElement_3 = method_45(xmlElement_0, "v", "fill", string_0);
			method_43(xmlElement_3, "color2", "buttonFace [67]");
			method_44(xmlElement_3, "o", "detectmouseclick", string_1, "t");
		}
		else if (text != null || shape_0.FillFormat.method_0() != 1.0)
		{
			XmlElement xmlElement_4 = method_45(xmlElement_0, "v", "fill", string_0);
			if (text != null)
			{
				method_44(xmlElement_4, "o", "relid", string_1, text);
			}
			if (shape_0.FillFormat.method_0() != 1.0)
			{
				method_43(xmlElement_4, "opacity", Class1618.smethod_79(shape_0.FillFormat.method_0()));
			}
			if (text != null)
			{
				method_43(xmlElement_4, "type", "frame");
			}
		}
	}

	private void method_23(Class1538 class1538_0)
	{
		Shape oleObject_ = class1538_0.oleObject_0;
		XmlElement xmlElement_ = method_45(xmlDocument_0.DocumentElement, "v", "shape", string_0);
		string text = method_20(oleObject_);
		if (text != null)
		{
			method_43(xmlElement_, "id", text);
		}
		string text2 = method_21(oleObject_);
		if (text2 != null)
		{
			method_44(xmlElement_, "o", "spid", string_1, text2);
		}
		else if (text == null)
		{
			method_43(xmlElement_, "id", "_x0000_s" + class1538_0.string_0);
		}
		else if (Class1618.smethod_145(text) != Class1618.smethod_145(class1538_0.string_0))
		{
			method_44(xmlElement_, "o", "spid", string_1, "_x0000_s" + class1538_0.string_0);
		}
		method_43(xmlElement_, "type", "#_x0000_t75");
		string alternativeText = oleObject_.AlternativeText;
		if (alternativeText != null && alternativeText != "")
		{
			method_43(xmlElement_, "alt", alternativeText);
		}
		Hyperlink hyperlink = oleObject_.Hyperlink;
		if (hyperlink != null)
		{
			method_43(xmlElement_, "href", hyperlink.Address);
		}
		method_43(xmlElement_, "style", method_26(oleObject_));
		method_43(xmlElement_, "filled", "t");
		method_43(xmlElement_, "fillcolor", method_19(oleObject_));
		if (oleObject_.LineFormat.IsVisible)
		{
			method_43(xmlElement_, "stroked", "t");
			method_43(xmlElement_, "strokecolor", method_18(oleObject_));
			if (oleObject_.class1556_0 != null && oleObject_.class1556_0.class1230_0 != null && oleObject_.class1556_0.class1230_0.method_0(Enum169.const_30))
			{
				method_43(xmlElement_, "strokeweight", oleObject_.LineFormat.Weight + "pt");
			}
		}
		method_44(xmlElement_, "o", "insetmode", string_1, "auto");
		method_22(xmlElement_, oleObject_);
		if (oleObject_.LineFormat.IsVisible)
		{
			XmlElement xmlElement_2 = method_45(xmlElement_, "v", "stroke", string_0);
			method_43(xmlElement_2, "dashstyle", Class1618.smethod_60(oleObject_.LineFormat.DashStyle));
			method_43(xmlElement_2, "linestyle", Class1618.smethod_56(oleObject_.LineFormat.Style));
		}
		if (class1538_0.string_3 != null)
		{
			XmlElement xmlElement_3 = method_45(xmlElement_, "v", "imagedata", string_0);
			method_44(xmlElement_3, "o", "relid", string_1, class1538_0.string_3);
			method_44(xmlElement_3, "o", "title", string_1, "");
			double topCrop = oleObject_.FormatPicture.TopCrop;
			if (topCrop != 0.0)
			{
				method_44(xmlElement_3, "o", "croptop", string_1, (int)(topCrop * 65536.0) + "f");
			}
			topCrop = oleObject_.FormatPicture.BottomCrop;
			if (topCrop != 0.0)
			{
				method_44(xmlElement_3, "o", "cropbottom", string_1, (int)(topCrop * 65536.0) + "f");
			}
			topCrop = oleObject_.FormatPicture.LeftCrop;
			if (topCrop != 0.0)
			{
				method_44(xmlElement_3, "o", "cropleft", string_1, (int)(topCrop * 65536.0) + "f");
			}
			topCrop = oleObject_.FormatPicture.RightCrop;
			if (topCrop != 0.0)
			{
				method_44(xmlElement_3, "o", "cropright", string_1, (int)(topCrop * 65536.0) + "f");
			}
		}
		XmlElement xmlElement_4 = method_45(xmlElement_, "x", "ClientData", string_2);
		method_43(xmlElement_4, "ObjectType", "Pict");
		if (oleObject_.Placement == PlacementType.FreeFloating)
		{
			method_45(xmlElement_4, "x", "MoveWithCells", string_2);
		}
		if (oleObject_.Placement == PlacementType.FreeFloating || oleObject_.Placement == PlacementType.Move)
		{
			method_45(xmlElement_4, "x", "SizeWithCells", string_2);
		}
		XmlElement xmlNode_ = method_45(xmlElement_4, "x", "Anchor", string_2);
		Class1188.smethod_12(xmlNode_, method_25(oleObject_));
		if (oleObject_.method_0() != null)
		{
			XmlElement xmlNode_2 = method_45(xmlElement_4, "x", "FmlaMacro", string_2);
			Class1188.smethod_12(xmlNode_2, oleObject_.method_0());
		}
		if (class1538_0.string_3 != null)
		{
			XmlElement xmlNode_3 = method_45(xmlElement_4, "x", "CF", string_2);
			Class1188.smethod_12(xmlNode_3, "Pict");
		}
		else
		{
			method_45(xmlElement_4, "x", "DDE", string_2);
		}
		if (class1538_0.oleObject_0.IsAutoSize)
		{
			method_45(xmlElement_4, "x", "AutoPict", string_2);
		}
	}

	private void method_24(Class527 class527_0)
	{
		Shape picture_ = class527_0.picture_0;
		XmlElement xmlElement_ = method_45(xmlDocument_0.DocumentElement, "v", "shape", string_0);
		string text = method_20(picture_);
		if (text != null)
		{
			method_43(xmlElement_, "id", text);
		}
		string text2 = method_21(picture_);
		if (text2 != null)
		{
			method_44(xmlElement_, "o", "spid", string_1, text2);
		}
		else if (text == null)
		{
			method_43(xmlElement_, "id", "_x0000_s" + class527_0.string_0);
		}
		else if (Class1618.smethod_145(text) != Class1618.smethod_145(class527_0.string_0))
		{
			method_44(xmlElement_, "o", "spid", string_1, "_x0000_s" + class527_0.string_0);
		}
		method_43(xmlElement_, "type", "#_x0000_t75");
		string alternativeText = picture_.AlternativeText;
		if (alternativeText != null && alternativeText != "")
		{
			method_43(xmlElement_, "alt", alternativeText);
		}
		Hyperlink hyperlink = picture_.Hyperlink;
		if (hyperlink != null)
		{
			method_43(xmlElement_, "href", hyperlink.Address);
		}
		method_43(xmlElement_, "style", method_26(picture_));
		method_43(xmlElement_, "filled", "t");
		method_43(xmlElement_, "fillcolor", method_19(picture_));
		if (picture_.LineFormat.IsVisible)
		{
			method_43(xmlElement_, "stroked", "t");
			method_43(xmlElement_, "strokecolor", method_18(picture_));
			if (picture_.class1556_0 != null && picture_.class1556_0.class1230_0 != null && picture_.class1556_0.class1230_0.method_0(Enum169.const_30))
			{
				method_43(xmlElement_, "strokeweight", picture_.LineFormat.Weight + "pt");
			}
		}
		method_44(xmlElement_, "o", "insetmode", string_1, "auto");
		XmlElement xmlElement_2 = method_45(xmlElement_, "v", "fill", string_0);
		method_43(xmlElement_2, "color2", "window [65]");
		if (picture_.LineFormat.IsVisible)
		{
			XmlElement xmlElement_3 = method_45(xmlElement_, "v", "stroke", string_0);
			method_43(xmlElement_3, "dashstyle", Class1618.smethod_60(picture_.LineFormat.DashStyle));
			method_43(xmlElement_3, "linestyle", Class1618.smethod_56(picture_.LineFormat.Style));
		}
		if (class527_0.string_1 != null)
		{
			XmlElement xmlElement_4 = method_45(xmlElement_, "v", "imagedata", string_0);
			method_44(xmlElement_4, "o", "relid", string_1, class527_0.string_1);
			method_44(xmlElement_4, "o", "title", string_1, "");
			double topCrop = picture_.FormatPicture.TopCrop;
			if (topCrop != 0.0)
			{
				method_44(xmlElement_4, "o", "croptop", string_1, (int)(topCrop * 65536.0) + "f");
			}
			topCrop = picture_.FormatPicture.BottomCrop;
			if (topCrop != 0.0)
			{
				method_44(xmlElement_4, "o", "cropbottom", string_1, (int)(topCrop * 65536.0) + "f");
			}
			topCrop = picture_.FormatPicture.LeftCrop;
			if (topCrop != 0.0)
			{
				method_44(xmlElement_4, "o", "cropleft", string_1, (int)(topCrop * 65536.0) + "f");
			}
			topCrop = picture_.FormatPicture.RightCrop;
			if (topCrop != 0.0)
			{
				method_44(xmlElement_4, "o", "cropright", string_1, (int)(topCrop * 65536.0) + "f");
			}
		}
		method_22(xmlElement_, picture_);
		XmlElement xmlElement_5 = method_45(xmlElement_, "x", "ClientData", string_2);
		method_43(xmlElement_5, "ObjectType", "Pict");
		if (picture_.Placement == PlacementType.FreeFloating)
		{
			method_45(xmlElement_5, "x", "MoveWithCells", string_2);
		}
		if (picture_.Placement == PlacementType.FreeFloating || picture_.Placement == PlacementType.Move)
		{
			method_45(xmlElement_5, "x", "SizeWithCells", string_2);
		}
		XmlElement xmlNode_ = method_45(xmlElement_5, "x", "Anchor", string_2);
		Class1188.smethod_12(xmlNode_, method_25(picture_));
		if (picture_.method_0() != null)
		{
			XmlElement xmlNode_2 = method_45(xmlElement_5, "x", "FmlaMacro", string_2);
			Class1188.smethod_12(xmlNode_2, picture_.method_0());
		}
		XmlElement xmlNode_3 = method_45(xmlElement_5, "x", "FmlaPict", string_2);
		Class1188.smethod_12(xmlNode_3, picture_.method_65());
		if (class527_0.string_1 != null)
		{
			XmlElement xmlNode_4 = method_45(xmlElement_5, "x", "CF", string_2);
			Class1188.smethod_12(xmlNode_4, "Pict");
		}
		else
		{
			method_45(xmlElement_5, "x", "DDE", string_2);
		}
		method_45(xmlElement_5, "x", "Camera", string_2);
	}

	private string method_25(Shape shape_0)
	{
		if (shape_0.method_30())
		{
			Chart chart = (Chart)((ShapeCollection)shape_0.method_13()).method_35();
			ChartShape chartObject = chart.ChartObject;
			Cells cells = shape_0.method_26().Cells;
			int num = (int)((double)chartObject.method_38() + (double)(shape_0.LeftInShape * chartObject.Width) / 4000.0 + 0.5);
			int num2 = (int)((double)chartObject.method_36() + (double)(shape_0.TopInShape * chartObject.Height) / 4000.0 + 0.5);
			int num3 = (int)((double)(shape_0.WidthInShape * chartObject.Width) / 4000.0 + 0.5);
			int num4 = (int)((double)(shape_0.HeightInShape * chartObject.Height) / 4000.0 + 0.5);
			int num5 = -1;
			int val = -1;
			int num6 = -1;
			int val2 = -1;
			int num7 = -1;
			int val3 = -1;
			int num8 = -1;
			int val4 = -1;
			int num9 = 0;
			for (int i = 0; i <= chartObject.LowerRightColumn; i++)
			{
				int viewColumnWidthPixel = cells.GetViewColumnWidthPixel(i);
				num9 += viewColumnWidthPixel;
				if (num9 >= num && num5 == -1)
				{
					num5 = i;
					val = num - (num9 - viewColumnWidthPixel);
				}
				if (num9 >= num + num3 && num7 == -1)
				{
					num7 = i;
					val3 = num + num3 - (num9 - viewColumnWidthPixel);
				}
			}
			num9 = 0;
			for (int j = 0; j <= chartObject.LowerRightRow; j++)
			{
				int rowHeightPixel = cells.GetRowHeightPixel(j);
				num9 += rowHeightPixel;
				if (num9 >= num2 && num6 == -1)
				{
					num6 = j;
					val2 = num2 - (num9 - rowHeightPixel);
				}
				if (num9 >= num2 + num4 && num8 == -1)
				{
					num8 = j;
					val4 = num2 + num4 - (num9 - rowHeightPixel);
				}
			}
			return num5 + "," + Math.Max(0, val) + "," + num6 + "," + Math.Max(0, val2) + "," + num7 + "," + Math.Max(0, val3) + "," + num8 + "," + Math.Max(0, val4);
		}
		return shape_0.method_21();
	}

	private string method_26(Shape shape_0)
	{
		string text = null;
		if (shape_0.method_30())
		{
			Chart chart = (Chart)((ShapeCollection)shape_0.method_13()).method_35();
			ChartShape chartObject = chart.ChartObject;
			_ = shape_0.method_26().Cells;
			int num = (int)((double)chartObject.method_38() + (double)(shape_0.LeftInShape * chartObject.Width) / 4000.0 + 0.5);
			int num2 = (int)((double)chartObject.method_36() + (double)(shape_0.TopInShape * chartObject.Height) / 4000.0 + 0.5);
			int num3 = (int)((double)(shape_0.WidthInShape * chartObject.Width) / 4000.0 + 0.5);
			int num4 = (int)((double)(shape_0.HeightInShape * chartObject.Height) / 4000.0 + 0.5);
			text = "position:absolute;margin-left:" + num + "px;margin-top:" + num2 + "px;width:" + Class1618.smethod_80(num3) + "px;height:" + Class1618.smethod_80(num4) + "px;z-index:" + method_27(shape_0) + ";";
		}
		else
		{
			text = "position:absolute;margin-left:" + shape_0.method_38() + "px;margin-top:" + shape_0.method_36() + "px;width:" + Class1618.smethod_80(shape_0.Width) + "px;height:" + Class1618.smethod_80(shape_0.Height) + "px;z-index:" + method_27(shape_0) + ";";
		}
		if (shape_0.MsoDrawingType == MsoDrawingType.Comment)
		{
			Comment comment = ((CommentShape)shape_0).method_69();
			text = ((!comment.IsVisible) ? (text + " visibility:hidden;") : (text + " visibility:visible;"));
		}
		else if (shape_0.IsHidden)
		{
			text += " visibility:hidden;";
		}
		if (shape_0.MsoDrawingType == MsoDrawingType.Button)
		{
			text += "mso-wrap-style:tight";
		}
		return text;
	}

	private int method_27(Shape shape_0)
	{
		if (shape_0.class1556_0 != null && shape_0.class1556_0.int_0 != -1)
		{
			if (int_0 <= shape_0.class1556_0.int_0)
			{
				int_0 = shape_0.class1556_0.int_0 + 1;
			}
			return shape_0.class1556_0.int_0;
		}
		return int_0++;
	}

	private void method_28()
	{
		XmlElement xmlElement_ = method_45(xmlDocument_0.DocumentElement, "v", "shapetype", string_0);
		method_43(xmlElement_, "id", "_x0000_t202");
		method_43(xmlElement_, "coordsize", "21600,21600");
		method_44(xmlElement_, "o", "spt", string_1, "202");
		method_43(xmlElement_, "path", "m,l,21600r21600,l21600,xe");
		XmlElement xmlElement_2 = method_45(xmlElement_, "v", "stroke", string_0);
		method_43(xmlElement_2, "joinstyle", "miter");
		XmlElement xmlElement_3 = method_45(xmlElement_, "v", "path", string_0);
		method_43(xmlElement_3, "gradientshapeok", "t");
		method_44(xmlElement_3, "o", "connecttype", string_1, "rect");
	}

	private void method_29()
	{
		XmlElement xmlElement_ = method_45(xmlDocument_0.DocumentElement, "v", "shapetype", string_0);
		method_43(xmlElement_, "id", "_x0000_t75");
		method_43(xmlElement_, "coordsize", "21600,21600");
		method_44(xmlElement_, "o", "spt", string_1, "75");
		method_44(xmlElement_, "o", "preferrelative", string_1, "t");
		method_43(xmlElement_, "path", "m@4@5l@4@11@9@11@9@5xe");
		method_43(xmlElement_, "filled", "f");
		method_43(xmlElement_, "stroked", "f");
		XmlElement xmlElement_2 = method_45(xmlElement_, "v", "stroke", string_0);
		method_43(xmlElement_2, "joinstyle", "miter");
		XmlElement xmlElement_3 = method_45(xmlElement_, "v", "formulas", string_0);
		method_31(xmlElement_3, "if lineDrawn pixelLineWidth 0");
		method_31(xmlElement_3, "sum @0 1 0");
		method_31(xmlElement_3, "sum 0 0 @1");
		method_31(xmlElement_3, "prod @2 1 2");
		method_31(xmlElement_3, "prod @3 21600 pixelWidth");
		method_31(xmlElement_3, "prod @3 21600 pixelHeight");
		method_31(xmlElement_3, "sum @0 0 1");
		method_31(xmlElement_3, "prod @6 1 2");
		method_31(xmlElement_3, "prod @7 21600 pixelWidth");
		method_31(xmlElement_3, "sum @8 21600 0");
		method_31(xmlElement_3, "prod @7 21600 pixelHeight");
		method_31(xmlElement_3, "sum @10 21600 0");
	}

	private void method_30()
	{
		XmlElement xmlElement_ = method_45(xmlDocument_0.DocumentElement, "v", "shapetype", string_0);
		method_43(xmlElement_, "id", "_x0000_t201");
		method_43(xmlElement_, "coordsize", "21600,21600");
		method_44(xmlElement_, "o", "spt", string_1, "201");
		method_43(xmlElement_, "path", "m,l,21600r21600,l21600,xe");
		XmlElement xmlElement_2 = method_45(xmlElement_, "v", "stroke", string_0);
		method_43(xmlElement_2, "joinstyle", "miter");
		XmlElement xmlElement_3 = method_45(xmlElement_, "v", "path", string_0);
		method_43(xmlElement_3, "shadowok", "f");
		method_44(xmlElement_3, "o", "extrusionok", string_1, "f");
		method_43(xmlElement_3, "strokeok", "f");
		method_43(xmlElement_3, "fillok", "f");
		method_44(xmlElement_3, "o", "connecttype", string_1, "rect");
		XmlElement xmlElement_4 = method_45(xmlElement_, "o", "lock", string_1);
		method_44(xmlElement_4, "v", "ext", string_0, "edit");
		method_43(xmlElement_4, "shapetype", "t");
	}

	private void method_31(XmlElement xmlElement_0, string string_3)
	{
		XmlElement xmlElement_ = method_45(xmlElement_0, "v", "f", string_0);
		method_43(xmlElement_, "eqn", string_3);
	}

	private void method_32()
	{
		XmlElement xmlElement_ = method_45(xmlDocument_0.DocumentElement, "o", "shapelayout", string_1);
		method_44(xmlElement_, "v", "ext", string_0, "edit");
		XmlElement xmlElement_2 = method_45(xmlElement_, "o", "idmap", string_1);
		method_44(xmlElement_2, "v", "ext", string_0, "edit");
		method_43(xmlElement_2, "data", "1");
	}

	private void method_33()
	{
		ArrayList arrayList = new ArrayList();
		XmlNodeList childNodes = xmlDocument_0.DocumentElement.ChildNodes;
		for (int i = 0; i < childNodes.Count; i++)
		{
			if (!(childNodes[i] is XmlElement))
			{
				continue;
			}
			XmlElement xmlElement = (XmlElement)childNodes[i];
			if (xmlElement.LocalName == "shape")
			{
				if (method_38(xmlElement))
				{
					arrayList.Add(xmlElement);
				}
				else if (method_34(xmlElement) || method_36(xmlElement))
				{
					arrayList.Add(xmlElement);
				}
			}
			else if (xmlElement.LocalName == "shapetype")
			{
				switch (Class1188.smethod_6(xmlElement, "id").Value)
				{
				case "_x0000_t202":
					bool_2 = true;
					break;
				case "_x0000_t75":
					bool_4 = true;
					break;
				case "_x0000_t201":
					bool_6 = true;
					break;
				}
			}
		}
		for (int j = 0; j < arrayList.Count; j++)
		{
			XmlNode oldChild = (XmlNode)arrayList[j];
			xmlDocument_0.DocumentElement.RemoveChild(oldChild);
		}
	}

	private bool method_34(XmlNode xmlNode_0)
	{
		XmlElement xmlElement = Class1618.smethod_173(xmlNode_0, "ClientData");
		if (xmlElement != null)
		{
			string string_ = Class1618.smethod_172(xmlElement, "ObjectType");
			if (method_35(string_))
			{
				return true;
			}
		}
		XmlAttribute xmlAttribute = Class1188.smethod_6((XmlElement)xmlNode_0, "id");
		if (xmlAttribute != null)
		{
			string item = Class1618.smethod_8(xmlAttribute.Value);
			if (class1541_0.worksheet_0.class1557_0.arrayList_7.Contains(item))
			{
				return true;
			}
		}
		return false;
	}

	private bool method_35(string string_3)
	{
		if (string_3 == null)
		{
			return false;
		}
		string key;
		if ((key = string_3) != null)
		{
			if (Class1742.dictionary_127 == null)
			{
				Class1742.dictionary_127 = new Dictionary<string, int>(9)
				{
					{ "Checkbox", 0 },
					{ "Label", 1 },
					{ "Button", 2 },
					{ "Drop", 3 },
					{ "Spin", 4 },
					{ "List", 5 },
					{ "Radio", 6 },
					{ "GBox", 7 },
					{ "Scroll", 8 }
				};
			}
			if (Class1742.dictionary_127.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
				case 1:
				case 2:
				case 3:
				case 4:
				case 5:
				case 6:
				case 7:
				case 8:
					return true;
				}
			}
		}
		return false;
	}

	private bool method_36(XmlNode xmlNode_0)
	{
		XmlNode xmlNode_ = null;
		bool result = false;
		XmlNodeList childNodes = xmlNode_0.ChildNodes;
		for (int i = 0; i < childNodes.Count; i++)
		{
			if (!(childNodes[i] is XmlElement))
			{
				continue;
			}
			XmlElement xmlElement = (XmlElement)childNodes[i];
			if (xmlElement.LocalName == "textbox")
			{
				xmlNode_ = xmlElement;
			}
			if (!(xmlElement.LocalName == "ClientData") || xmlElement.Attributes.Count <= 0)
			{
				continue;
			}
			XmlAttribute xmlAttribute = Class1188.smethod_6(xmlElement, "ObjectType");
			if (xmlAttribute == null || xmlAttribute.Value != "Note")
			{
				continue;
			}
			string text = null;
			string text2 = null;
			XmlNode xmlNode_2 = null;
			XmlNode xmlNode_3 = null;
			XmlNodeList childNodes2 = xmlElement.ChildNodes;
			for (int j = 0; j < childNodes2.Count; j++)
			{
				if (childNodes2[j] is XmlElement)
				{
					XmlElement xmlElement2 = (XmlElement)childNodes2[j];
					if (xmlElement2.LocalName == "Row")
					{
						text = Class1188.smethod_13(xmlElement2);
						xmlNode_3 = xmlElement2;
					}
					else if (xmlElement2.LocalName == "Column")
					{
						text2 = Class1188.smethod_13(xmlElement2);
					}
					else if (xmlElement2.LocalName == "Anchor")
					{
						xmlNode_2 = xmlElement2;
					}
				}
			}
			if (text != null && text2 != null && text.Length != 0 && text2.Length != 0)
			{
				int row = Class1618.smethod_87(text);
				int column = Class1618.smethod_87(text2);
				string cellName = CellsHelper.CellIndexToName(row, column);
				Comment comment = class1541_0.worksheet_0.Comments[cellName];
				if (comment == null)
				{
					result = true;
					continue;
				}
				method_40(xmlNode_0, xmlElement, xmlNode_2, xmlNode_3, xmlNode_, comment);
				arrayList_0.Add(comment);
			}
			else
			{
				result = true;
			}
		}
		return result;
	}

	private string method_37(XmlNode xmlNode_0)
	{
		XmlNodeList childNodes = xmlNode_0.ChildNodes;
		int num = 0;
		XmlElement xmlElement;
		while (true)
		{
			if (num < childNodes.Count)
			{
				if (childNodes[num] is XmlElement)
				{
					xmlElement = (XmlElement)childNodes[num];
					if (xmlElement.LocalName == "ClientData")
					{
						break;
					}
				}
				num++;
				continue;
			}
			return null;
		}
		return Class1618.smethod_172(xmlElement, "ObjectType");
	}

	private bool method_38(XmlNode xmlNode_0)
	{
		string text = method_37(xmlNode_0);
		if (text != "Pict")
		{
			return false;
		}
		string text2 = Class1618.smethod_8(Class1618.smethod_172(xmlNode_0, "id"));
		string text3 = Class1618.smethod_8(Class1618.smethod_172(xmlNode_0, "spid"));
		string item = text2 + "|" + text3;
		if (!class1541_0.worksheet_0.class1557_0.arrayList_9.Contains(item))
		{
			return false;
		}
		Shape shape = method_39(text2, text3);
		if (shape == null)
		{
			return true;
		}
		XmlElement xmlElement = Class1618.smethod_173((XmlElement)xmlNode_0, "ClientData");
		if (xmlElement != null)
		{
			if (shape.MsoDrawingType == MsoDrawingType.Picture)
			{
				XmlElement xmlElement_ = Class1618.smethod_173((XmlElement)xmlNode_0, "imagedata");
				XmlAttribute xmlAttribute = Class1188.smethod_6(xmlElement_, "relid");
				xmlAttribute.Value = (string)class1541_0.class1534_1.hashtable_0[((Picture)shape).method_70()];
			}
			XmlElement xmlElement2 = Class1618.smethod_173(xmlElement, "Anchor");
			XmlElement xmlElement3 = Class1618.smethod_173(xmlElement, "FmlaPict");
			string text4 = method_26(shape);
			XmlAttribute xmlAttribute2 = Class1188.smethod_6((XmlElement)xmlNode_0, "style");
			if (xmlAttribute2 != null)
			{
				xmlAttribute2.Value = text4;
			}
			else
			{
				method_43((XmlElement)xmlNode_0, "style", text4);
			}
			string text5 = method_25(shape);
			if (xmlElement2 != null)
			{
				Class1188.smethod_12(xmlElement2, text5);
			}
			if (xmlElement3 != null && shape.method_65() != null && shape.method_65().Length > 0)
			{
				arrayList_1.Add(shape);
				Class1188.smethod_12(xmlElement3, shape.method_65());
			}
		}
		return false;
	}

	private Shape method_39(string string_3, string string_4)
	{
		foreach (Shape shape in class1541_0.worksheet_0.Shapes)
		{
			if (shape.class1556_0 != null && shape.class1556_0.string_0 == string_3 && shape.class1556_0.string_1 == string_4)
			{
				return shape;
			}
		}
		return null;
	}

	private void method_40(XmlNode xmlNode_0, XmlNode xmlNode_1, XmlNode xmlNode_2, XmlNode xmlNode_3, XmlNode xmlNode_4, Comment comment_0)
	{
		string text = method_26(comment_0.CommentShape);
		XmlAttribute xmlAttribute = Class1188.smethod_6((XmlElement)xmlNode_0, "style");
		if (xmlAttribute != null)
		{
			xmlAttribute.Value = text;
		}
		else
		{
			method_43((XmlElement)xmlNode_0, "style", text);
		}
		string text2 = method_25(comment_0.CommentShape);
		if (xmlNode_2 != null)
		{
			Class1188.smethod_12(xmlNode_2, text2);
		}
		else
		{
			xmlNode_2 = xmlDocument_0.CreateElement("x:Anchor", ((XmlElement)xmlNode_3).NamespaceURI);
			Class1188.smethod_12(xmlNode_2, text2);
			Class1188.smethod_9(xmlNode_1, xmlNode_2, xmlNode_3);
		}
		if (xmlNode_4 != null)
		{
			string text3 = "mso-direction-alt:auto";
			if (comment_0.AutoSize)
			{
				text3 += ";mso-fit-shape-to-text:t";
			}
			XmlAttribute xmlAttribute2 = Class1188.smethod_6((XmlElement)xmlNode_4, "style");
			if (xmlAttribute2 != null)
			{
				xmlAttribute2.Value = text3;
			}
			else
			{
				method_43((XmlElement)xmlNode_4, "style", text3);
			}
		}
		string text4 = class1541_0.class1534_1.method_1(comment_0.CommentShape);
		if (text4 == null)
		{
			return;
		}
		XmlNode xmlNode = Class1618.smethod_173(xmlNode_0, "fill");
		if (xmlNode != null)
		{
			XmlAttribute xmlAttribute3 = Class1188.smethod_6((XmlElement)xmlNode, "relid");
			if (xmlAttribute3 != null)
			{
				xmlAttribute3.Value = text4;
			}
			else
			{
				method_43((XmlElement)xmlNode, "relid", text4);
			}
		}
	}

	private void method_41(Stream6 stream6_0, string string_3)
	{
		MemoryStream memoryStream = new MemoryStream();
		xmlDocument_0.Save(memoryStream);
		if (memoryStream.Length >= int.MaxValue)
		{
			throw new CellsException(ExceptionType.InvalidData, "Internal Error: VmlDrawing data too large...");
		}
		Class744 @class = stream6_0.method_18(string_3);
		@class.method_5(DateTime.Now);
		memoryStream.Position = 0L;
		byte[] array = new byte[1024];
		int num = 0;
		do
		{
			num = memoryStream.Read(array, 0, array.Length);
			stream6_0.Write(array, 0, num);
		}
		while (num > 0);
		stream6_0.Flush();
	}

	private void method_42()
	{
		XmlElement xmlElement = xmlDocument_0.CreateElement("xml");
		xmlDocument_0.AppendChild(xmlElement);
		string namespaceURI = "http://www.w3.org/2000/xmlns/";
		XmlAttribute xmlAttribute = xmlDocument_0.CreateAttribute("xmlns", "v", namespaceURI);
		xmlAttribute.Value = string_0;
		xmlElement.Attributes.Append(xmlAttribute);
		xmlAttribute = xmlDocument_0.CreateAttribute("xmlns", "o", namespaceURI);
		xmlAttribute.Value = string_1;
		xmlElement.Attributes.Append(xmlAttribute);
		xmlAttribute = xmlDocument_0.CreateAttribute("xmlns", "x", namespaceURI);
		xmlAttribute.Value = string_2;
		xmlElement.Attributes.Append(xmlAttribute);
	}

	private void method_43(XmlElement xmlElement_0, string string_3, string string_4)
	{
		XmlAttribute xmlAttribute = xmlDocument_0.CreateAttribute(string_3);
		xmlAttribute.Value = string_4;
		xmlElement_0.Attributes.Append(xmlAttribute);
	}

	private void method_44(XmlElement xmlElement_0, string string_3, string string_4, string string_5, string string_6)
	{
		XmlAttribute xmlAttribute = xmlDocument_0.CreateAttribute(string_3, string_4, string_5);
		xmlAttribute.Value = string_6;
		xmlElement_0.Attributes.Append(xmlAttribute);
	}

	private XmlElement method_45(XmlElement xmlElement_0, string string_3, string string_4, string string_5)
	{
		XmlElement xmlElement = xmlDocument_0.CreateElement(string_3, string_4, string_5);
		xmlElement_0.AppendChild(xmlElement);
		return xmlElement;
	}

	private XmlElement method_46(XmlElement xmlElement_0, string string_3)
	{
		XmlElement xmlElement = xmlDocument_0.CreateElement(string_3);
		xmlElement_0.AppendChild(xmlElement);
		return xmlElement;
	}
}
