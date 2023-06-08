using System;
using System.Collections;
using System.Drawing;
using System.Xml;
using Aspose.Cells;
using Aspose.Cells.Drawing;
using ns2;
using ns21;
using ns22;
using ns52;

namespace ns16;

internal class Class1367
{
	private Class1359 class1359_0;

	private string string_0 = "http://schemas.openxmlformats.org/drawingml/2006/chartDrawing";

	private string string_1 = "http://schemas.openxmlformats.org/drawingml/2006/spreadsheetDrawing";

	private int int_0;

	private Shape shape_0;

	private string string_2;

	private string string_3;

	private Class1230 class1230_0;

	private Class1358 class1358_0;

	internal Class1367(Class1359 class1359_1)
	{
		class1359_0 = class1359_1;
		int_0 = class1359_0.class1540_0.workbook_0.Worksheets.method_75();
		shape_0 = class1359_0.shape_0;
		class1358_0 = class1359_1.class1358_0;
		if (class1359_0.enum197_0 == Enum197.const_2)
		{
			string_2 = string_0;
			string_3 = "cdr";
		}
		else
		{
			string_2 = string_1;
			string_3 = "xdr";
		}
		if (class1359_1.shape_0.class1556_0 != null)
		{
			class1230_0 = class1359_1.shape_0.class1556_0.class1230_0;
		}
	}

	internal void Write(XmlTextWriter xmlTextWriter_0)
	{
		if (!class1359_0.bool_1)
		{
			switch (class1359_0.enum197_0)
			{
			default:
				xmlTextWriter_0.WriteStartElement("xdr:twoCellAnchor");
				break;
			case Enum197.const_1:
				xmlTextWriter_0.WriteStartElement("xdr:absoluteAnchor");
				break;
			case Enum197.const_2:
				xmlTextWriter_0.WriteStartElement("cdr:relSizeAnchor");
				xmlTextWriter_0.WriteAttributeString("xmlns:cdr", string_0);
				break;
			case Enum197.const_3:
				xmlTextWriter_0.WriteStartElement("xdr:oneCellAnchor");
				break;
			}
			if ((shape_0.MsoDrawingType != MsoDrawingType.Chart || class1359_0.enum197_0 != Enum197.const_1) && class1359_0.enum197_0 == Enum197.const_0 && shape_0.Placement != PlacementType.MoveAndSize)
			{
				string value = Class1618.smethod_52(shape_0.Placement);
				xmlTextWriter_0.WriteAttributeString("editAs", value);
			}
			method_40(xmlTextWriter_0);
		}
		method_36(xmlTextWriter_0);
		method_15(xmlTextWriter_0);
		method_1(xmlTextWriter_0);
		method_5(xmlTextWriter_0);
		if (!class1359_0.bool_1)
		{
			method_3(xmlTextWriter_0);
			xmlTextWriter_0.WriteEndElement();
		}
	}

	internal void method_0(XmlTextWriter xmlTextWriter_0)
	{
		if (!class1359_0.bool_1)
		{
			switch (class1359_0.enum197_0)
			{
			default:
				xmlTextWriter_0.WriteStartElement("xdr:twoCellAnchor");
				break;
			case Enum197.const_1:
				xmlTextWriter_0.WriteStartElement("xdr:absoluteAnchor");
				break;
			case Enum197.const_2:
				xmlTextWriter_0.WriteStartElement("cdr:relSizeAnchor");
				xmlTextWriter_0.WriteAttributeString("xmlns:cdr", string_0);
				break;
			case Enum197.const_3:
				xmlTextWriter_0.WriteStartElement("xdr:oneCellAnchor");
				break;
			}
			if ((shape_0.MsoDrawingType != MsoDrawingType.Chart || class1359_0.enum197_0 != Enum197.const_1) && class1359_0.enum197_0 == Enum197.const_0 && shape_0.Placement != PlacementType.MoveAndSize)
			{
				string value = Class1618.smethod_52(shape_0.Placement);
				xmlTextWriter_0.WriteAttributeString("editAs", value);
			}
			method_40(xmlTextWriter_0);
		}
		method_6(xmlTextWriter_0);
		if (!class1359_0.bool_1)
		{
			method_3(xmlTextWriter_0);
			xmlTextWriter_0.WriteEndElement();
		}
	}

	private void method_1(XmlTextWriter xmlTextWriter_0)
	{
		if (shape_0.MsoDrawingType == MsoDrawingType.Group)
		{
			xmlTextWriter_0.WriteStartElement(string_3 + ":grpSp");
			method_2(xmlTextWriter_0);
			method_21(xmlTextWriter_0);
			GroupShape groupShape = (GroupShape)shape_0;
			Shape[] groupedShapes = groupShape.GetGroupedShapes();
			Shape[] array = groupedShapes;
			foreach (Shape shape_ in array)
			{
				Class1359 @class = new Class1359(class1358_0, shape_);
				@class.bool_1 = true;
				Class1367 class2 = new Class1367(@class);
				class2.Write(xmlTextWriter_0);
			}
			xmlTextWriter_0.WriteEndElement();
		}
	}

	private void method_2(XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartElement(string_3 + ":nvGrpSpPr");
		method_35(xmlTextWriter_0);
		string text = method_37(Enum169.const_8);
		if (text != null)
		{
			xmlTextWriter_0.WriteRaw(text);
		}
		else
		{
			xmlTextWriter_0.WriteStartElement(string_3 + ":cNvGrpSpPr");
			xmlTextWriter_0.WriteStartElement("a:grpSpLocks");
			if (shape_0.IsLockAspectRatio)
			{
				xmlTextWriter_0.WriteAttributeString("noChangeAspect", "1");
			}
			xmlTextWriter_0.WriteEndElement();
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_3(XmlTextWriter xmlTextWriter_0)
	{
		if (class1359_0.enum197_0 == Enum197.const_2)
		{
			return;
		}
		string text = method_37(Enum169.const_46);
		if (text != null)
		{
			xmlTextWriter_0.WriteRaw(text);
			return;
		}
		xmlTextWriter_0.WriteStartElement("xdr:clientData");
		if (!shape_0.IsLocked)
		{
			xmlTextWriter_0.WriteAttributeString("fLocksWithSheet", "0");
		}
		if (!shape_0.IsPrintable)
		{
			xmlTextWriter_0.WriteAttributeString("fPrintsWithSheet", "0");
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private bool method_4(Shape shape_1)
	{
		if (shape_0.class1556_0 != null && shape_0.class1556_0.class1230_0 != null && shape_0.class1556_0.class1230_0.class1234_0 != null && shape_0.class1556_0.class1230_0.class1234_0.bool_0)
		{
			if (shape_0.MsoDrawingType == MsoDrawingType.Line)
			{
				return true;
			}
			switch (shape_0.AutoShapeType)
			{
			case AutoShapeType.Line:
			case AutoShapeType.StraightConnector:
			case AutoShapeType.BentConnector2:
			case AutoShapeType.ElbowConnector:
			case AutoShapeType.BentConnector4:
			case AutoShapeType.BentConnector5:
			case AutoShapeType.CurvedConnector2:
			case AutoShapeType.CurvedConnector:
			case AutoShapeType.CurvedConnector4:
			case AutoShapeType.CurvedConnector5:
				return true;
			}
		}
		return false;
	}

	private void method_5(XmlTextWriter xmlTextWriter_0)
	{
		if (shape_0.MsoDrawingType != MsoDrawingType.Picture && (shape_0.MsoDrawingType == MsoDrawingType.TextBox || Class1618.smethod_233(shape_0) || (shape_0.MsoDrawingType != 0 && shape_0.AutoShapeType == AutoShapeType.NotPrimitive)))
		{
			bool flag;
			if (flag = method_4(shape_0))
			{
				xmlTextWriter_0.WriteStartElement(string_3 + ":cxnSp");
			}
			else
			{
				xmlTextWriter_0.WriteStartElement(string_3 + ":sp");
			}
			method_39(xmlTextWriter_0);
			method_8(xmlTextWriter_0);
			method_21(xmlTextWriter_0);
			method_7(xmlTextWriter_0);
			if (!flag)
			{
				method_11(xmlTextWriter_0);
			}
			xmlTextWriter_0.WriteEndElement();
		}
	}

	private void method_6(XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartElement(string_3 + ":sp");
		method_39(xmlTextWriter_0);
		method_8(xmlTextWriter_0);
		method_22(xmlTextWriter_0);
		method_12(xmlTextWriter_0);
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_7(XmlTextWriter xmlTextWriter_0)
	{
		Class1110 @class = shape_0.method_3();
		if (@class != null)
		{
			xmlTextWriter_0.WriteStartElement(string_3 + ":style");
			xmlTextWriter_0.WriteStartElement("a:lnRef");
			xmlTextWriter_0.WriteAttributeString("idx", @class.class1111_0.string_0);
			Class1236.smethod_0(xmlTextWriter_0, @class.class1111_0.internalColor_0, -1, class1359_0.class1540_0.workbook_0);
			xmlTextWriter_0.WriteEndElement();
			xmlTextWriter_0.WriteStartElement("a:fillRef");
			xmlTextWriter_0.WriteAttributeString("idx", @class.class1111_2.string_0);
			Class1236.smethod_0(xmlTextWriter_0, @class.class1111_2.internalColor_0, -1, class1359_0.class1540_0.workbook_0);
			xmlTextWriter_0.WriteEndElement();
			xmlTextWriter_0.WriteStartElement("a:effectRef");
			xmlTextWriter_0.WriteAttributeString("idx", @class.class1111_3.string_0);
			Class1236.smethod_0(xmlTextWriter_0, @class.class1111_3.internalColor_0, -1, class1359_0.class1540_0.workbook_0);
			xmlTextWriter_0.WriteEndElement();
			xmlTextWriter_0.WriteStartElement("a:fontRef");
			xmlTextWriter_0.WriteAttributeString("idx", @class.class1111_1.string_0);
			Class1236.smethod_0(xmlTextWriter_0, @class.class1111_1.internalColor_0, -1, class1359_0.class1540_0.workbook_0);
			xmlTextWriter_0.WriteEndElement();
			xmlTextWriter_0.WriteEndElement();
		}
	}

	private void method_8(XmlTextWriter xmlTextWriter_0)
	{
		if (method_4(shape_0))
		{
			xmlTextWriter_0.WriteStartElement(string_3 + ":nvCxnSpPr");
		}
		else
		{
			xmlTextWriter_0.WriteStartElement(string_3 + ":nvSpPr");
		}
		method_35(xmlTextWriter_0);
		string text = method_37(Enum169.const_8);
		if (text != null)
		{
			xmlTextWriter_0.WriteRaw(text);
		}
		else if (!method_4(shape_0))
		{
			xmlTextWriter_0.WriteStartElement(string_3 + ":cNvSpPr");
			if (shape_0.MsoDrawingType == MsoDrawingType.TextBox)
			{
				xmlTextWriter_0.WriteAttributeString("txBox", "1");
			}
			xmlTextWriter_0.WriteStartElement("a:spLocks");
			if (shape_0.IsLockAspectRatio)
			{
				xmlTextWriter_0.WriteAttributeString("noChangeAspect", "1");
			}
			if (shape_0.MsoDrawingType == MsoDrawingType.TextBox)
			{
				xmlTextWriter_0.WriteAttributeString("noChangeArrowheads", "1");
			}
			xmlTextWriter_0.WriteEndElement();
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_9(XmlTextWriter xmlTextWriter_0)
	{
		Class1737 @class = shape_0.method_64();
		if (@class != null)
		{
			Class1360 class2 = null;
			if (shape_0.MsoDrawingType == MsoDrawingType.TextBox)
			{
				class2 = Class1360.smethod_3((TextBox)shape_0, class1359_0.class1540_0.workbook_0);
				if (@class.Text == null && @class.method_8() > 0)
				{
					Class1572.smethod_2(xmlTextWriter_0, class2);
				}
				else
				{
					Class1572.smethod_1(xmlTextWriter_0, class2);
				}
			}
			else
			{
				class2 = Class1360.smethod_2(@class, class1359_0.class1540_0.workbook_0);
				Class1572.smethod_1(xmlTextWriter_0, class2);
			}
		}
		else
		{
			xmlTextWriter_0.WriteElementString("a:p", null);
		}
	}

	private void method_10(XmlTextWriter xmlTextWriter_0)
	{
		TextEffectFormat textEffect = shape_0.TextEffect;
		xmlTextWriter_0.WriteStartElement("a:p");
		string text = TextEffectFormat.smethod_0(textEffect.method_3());
		if (text != null)
		{
			xmlTextWriter_0.WriteStartElement("a:pPr");
			xmlTextWriter_0.WriteAttributeString("algn", text);
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteStartElement("a:r");
		xmlTextWriter_0.WriteStartElement("a:rPr");
		xmlTextWriter_0.WriteAttributeString("sz", Class1618.smethod_80(textEffect.FontSize * 100));
		if (textEffect.FontItalic)
		{
			xmlTextWriter_0.WriteAttributeString("i", "1");
		}
		if (textEffect.FontBold)
		{
			xmlTextWriter_0.WriteAttributeString("b", "1");
		}
		if (textEffect.method_1())
		{
			xmlTextWriter_0.WriteAttributeString("kern", "10");
		}
		double num = textEffect.method_2();
		if (num < 1.0)
		{
			xmlTextWriter_0.WriteAttributeString("spc", Class1618.smethod_80((int)((double)(textEffect.FontSize * 100) * (num - 1.0) / 2.0)));
		}
		else if (num == 1.0)
		{
			xmlTextWriter_0.WriteAttributeString("spc", "0");
		}
		else
		{
			xmlTextWriter_0.WriteAttributeString("spc", Class1618.smethod_80((int)((double)(textEffect.FontSize * 100) * (num - 1.0))));
		}
		method_29(xmlTextWriter_0);
		method_20(xmlTextWriter_0);
		Class931 @class = shape_0.method_35();
		if (@class.method_16())
		{
			xmlTextWriter_0.WriteStartElement("a:effectLst");
			xmlTextWriter_0.WriteStartElement("a:outerShdw");
			double num2 = @class.method_4();
			double num3 = @class.method_5();
			double num4 = Math.Sqrt(num2 * num2 + num3 * num3);
			xmlTextWriter_0.WriteAttributeString("dist", Class1618.smethod_80((int)(num4 * Class1391.double_0)));
			string text2 = "ctr";
			double num5 = 0.0;
			if (num2 == 0.0)
			{
				num5 = ((!(num3 > 0.0)) ? (-90.0) : 90.0);
			}
			else
			{
				num5 = Math.Atan(num3 / num2) / Math.PI * 180.0;
				if (num2 > 0.0)
				{
					if (!(num3 >= 0.0))
					{
						num5 += 360.0;
					}
				}
				else if (num3 >= 0.0)
				{
					num5 += 180.0;
				}
				else
				{
					text2 = "tl";
					num5 += 180.0;
				}
			}
			xmlTextWriter_0.WriteAttributeString("dir", Class1618.smethod_80((int)(num5 * (double)Class1391.int_0)));
			double num6 = @class.method_8();
			if (num6 != 1.0)
			{
				xmlTextWriter_0.WriteAttributeString("sx", Class1618.smethod_80((int)(num6 * (double)Class1391.int_1)));
			}
			double num7 = @class.method_11();
			if (num7 != 1.0)
			{
				xmlTextWriter_0.WriteAttributeString("sy", Class1618.smethod_80((int)(num7 * (double)Class1391.int_1)));
			}
			double num8 = @class.method_9();
			if (num8 != 0.0)
			{
				xmlTextWriter_0.WriteAttributeString("kx", Class1618.smethod_80((int)(Math.Atan(num8) / Math.PI * 180.0 * (double)Class1391.int_0)));
				text2 = "bl";
			}
			double num9 = @class.method_14();
			double num10 = @class.method_15();
			text2 = ((num9 > 0.0) ? ((num10 > 0.0) ? "br" : ((num10 != 0.0) ? "tr" : "r")) : ((num9 == 0.0) ? ((num10 > 0.0) ? "b" : ((num10 != 0.0) ? "t" : "ctr")) : ((num10 > 0.0) ? "bl" : ((num10 != 0.0) ? "tl" : "l"))));
			if (text2 != "")
			{
				xmlTextWriter_0.WriteAttributeString("algn", text2);
			}
			xmlTextWriter_0.WriteStartElement("a:srgbClr");
			xmlTextWriter_0.WriteAttributeString("val", Class1618.smethod_64(@class.ForeColor));
			xmlTextWriter_0.WriteStartElement("a:alpha");
			xmlTextWriter_0.WriteAttributeString("val", Class1618.smethod_80((int)(@class.method_3() * (double)Class1391.int_1)));
			xmlTextWriter_0.WriteEndElement();
			xmlTextWriter_0.WriteEndElement();
			xmlTextWriter_0.WriteEndElement();
			xmlTextWriter_0.WriteEndElement();
		}
		if (textEffect.FontName != null)
		{
			xmlTextWriter_0.WriteStartElement("a:latin");
			xmlTextWriter_0.WriteAttributeString("typeface", textEffect.FontName);
			xmlTextWriter_0.WriteEndElement();
			xmlTextWriter_0.WriteStartElement("a:cs");
			xmlTextWriter_0.WriteAttributeString("typeface", textEffect.FontName);
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteElementString("a:t", textEffect.Text.Replace("\r", ""));
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_11(XmlTextWriter xmlTextWriter_0)
	{
		if (!method_38(Enum169.const_7))
		{
			method_24(Enum169.const_7, xmlTextWriter_0);
			return;
		}
		xmlTextWriter_0.WriteStartElement(string_3 + ":txBody");
		method_13(xmlTextWriter_0);
		method_9(xmlTextWriter_0);
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_12(XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartElement(string_3 + ":txBody");
		method_14(xmlTextWriter_0);
		method_10(xmlTextWriter_0);
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_13(XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartElement("a:bodyPr");
		if (shape_0.TextVerticalOverflow != TextOverflowType.Overflow)
		{
			xmlTextWriter_0.WriteAttributeString("vertOverflow", Class1618.smethod_240(shape_0.TextVerticalOverflow));
		}
		if (shape_0.TextHorizontalOverflow != TextOverflowType.Overflow)
		{
			xmlTextWriter_0.WriteAttributeString("horzOverflow", Class1618.smethod_240(shape_0.TextHorizontalOverflow));
		}
		string value = "square";
		Class1737 @class = shape_0.method_64();
		if (@class != null && !@class.bool_1)
		{
			value = "none";
		}
		xmlTextWriter_0.WriteAttributeString("wrap", value);
		MsoTextFrame textFrame = shape_0.TextFrame;
		if (!textFrame.IsAutoMargin)
		{
			xmlTextWriter_0.WriteAttributeString("lIns", Class1618.smethod_80(textFrame.method_1()));
			xmlTextWriter_0.WriteAttributeString("tIns", Class1618.smethod_80(textFrame.method_5()));
			xmlTextWriter_0.WriteAttributeString("rIns", Class1618.smethod_80(textFrame.method_3()));
			xmlTextWriter_0.WriteAttributeString("bIns", Class1618.smethod_80(textFrame.method_7()));
		}
		if (@class != null)
		{
			if (@class.TextVerticalAlignment != TextAlignmentType.Top)
			{
				string value2 = Class1618.smethod_94(@class.TextVerticalAlignment);
				xmlTextWriter_0.WriteAttributeString("anchor", value2);
			}
			if (@class.TextOrientationType != TextOrientationType.NoRotation)
			{
				string text = Class1618.smethod_196(@class.TextOrientationType);
				if (text != null)
				{
					xmlTextWriter_0.WriteAttributeString("vert", text);
				}
			}
		}
		if (textFrame.AutoSize)
		{
			xmlTextWriter_0.WriteElementString("a:spAutoFit", null);
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_14(XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartElement("a:bodyPr");
		xmlTextWriter_0.WriteAttributeString("fromWordArt", "1");
		xmlTextWriter_0.WriteAttributeString("wrap", "none");
		MsoTextFrame textFrame = shape_0.TextFrame;
		if (!textFrame.IsAutoMargin)
		{
			xmlTextWriter_0.WriteAttributeString("lIns", Class1618.smethod_80(textFrame.method_1()));
			xmlTextWriter_0.WriteAttributeString("tIns", Class1618.smethod_80(textFrame.method_5()));
			xmlTextWriter_0.WriteAttributeString("rIns", Class1618.smethod_80(textFrame.method_3()));
			xmlTextWriter_0.WriteAttributeString("bIns", Class1618.smethod_80(textFrame.method_7()));
		}
		if (textFrame.AutoSize)
		{
			xmlTextWriter_0.WriteElementString("a:spAutoFit", null);
		}
		xmlTextWriter_0.WriteStartElement("a:prstTxWarp");
		xmlTextWriter_0.WriteAttributeString("prst", Class1618.smethod_234(shape_0.AutoShapeType));
		Class1245 @class = shape_0.method_10();
		int num = @class?.method_6() ?? 0;
		if (num > 0)
		{
			int num2 = 1;
			xmlTextWriter_0.WriteStartElement("a:avLst");
			for (int i = 327; i <= 336; i++)
			{
				if (@class.method_5(i))
				{
					int num3 = @class.method_2(i);
					xmlTextWriter_0.WriteStartElement("a:gd");
					if (num > 1)
					{
						xmlTextWriter_0.WriteAttributeString("name", "adj" + num2);
					}
					else
					{
						xmlTextWriter_0.WriteAttributeString("name", "adj");
					}
					xmlTextWriter_0.WriteAttributeString("fmla", "val " + Class1618.smethod_80((int)((double)num3 / 21600.0 * 100000.0)));
					xmlTextWriter_0.WriteEndElement();
					num2++;
				}
			}
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteEndElement();
		Class476 class2 = new Class476(shape_0);
		if (class2.method_3())
		{
			xmlTextWriter_0.WriteStartElement("a:scene3d");
			xmlTextWriter_0.WriteStartElement("a:camera");
			string value = "legacyObliqueRight";
			double num4 = class2.method_7();
			double num5 = class2.method_8();
			double num6 = class2.method_9();
			if (num4 > 0.0)
			{
				if (num5 > 0.0)
				{
					if (num6 > 0.0)
					{
						value = "legacyPerspectiveBottomRight";
					}
				}
				else if (num5 == 0.0)
				{
					value = "legacyObliqueRight";
				}
			}
			else if (num4 == 0.0)
			{
				if (!(num5 > 0.0) && num5 == 0.0)
				{
					value = "legacyPerspectiveFront";
				}
			}
			else if (!(num5 > 0.0) && num5 != 0.0)
			{
				value = ((!(num6 > 0.0)) ? "legacyObliqueTopLeft" : "legacyPerspectiveTopLeft");
			}
			xmlTextWriter_0.WriteAttributeString("prst", value);
			if (class2.method_6() != 0.0 || class2.method_5() != 0.0)
			{
				xmlTextWriter_0.WriteStartElement("a:rot");
				double num7 = class2.method_6();
				if (num7 > 0.0)
				{
					num7 = 360.0 - num7;
				}
				xmlTextWriter_0.WriteAttributeString("lat", Class1618.smethod_80((int)(num7 * (double)Class1391.int_0)));
				double num8 = class2.method_5();
				if (num8 < 0.0)
				{
					num8 += 360.0;
				}
				xmlTextWriter_0.WriteAttributeString("lon", Class1618.smethod_80((int)(num8 * (double)Class1391.int_0)));
				xmlTextWriter_0.WriteAttributeString("rev", "0");
				xmlTextWriter_0.WriteEndElement();
			}
			xmlTextWriter_0.WriteEndElement();
			xmlTextWriter_0.WriteStartElement("a:lightRig");
			string value2 = "legacyHarsh3";
			if (!class2.method_12())
			{
				value2 = "legacyNormal3";
			}
			xmlTextWriter_0.WriteAttributeString("rig", value2);
			string value3 = "t";
			int num9 = class2.method_10();
			int num10 = class2.method_11();
			if (num9 > 0)
			{
				if (num10 > 0)
				{
					value3 = "b";
				}
				else if (num10 != 0)
				{
				}
			}
			else if (num9 == 0)
			{
				if (num10 > 0)
				{
					value3 = "l";
				}
				else if (num10 != 0)
				{
					value3 = "r";
				}
			}
			else if (num10 <= 0)
			{
			}
			xmlTextWriter_0.WriteAttributeString("dir", value3);
			xmlTextWriter_0.WriteEndElement();
			xmlTextWriter_0.WriteEndElement();
			xmlTextWriter_0.WriteStartElement("a:sp3d");
			xmlTextWriter_0.WriteAttributeString("extrusionH", Class1618.smethod_80((int)(class2.method_1() * Class1391.double_0) - 27000));
			xmlTextWriter_0.WriteAttributeString("prstMaterial", class2.method_4() ? "legacyMetal" : "legacyMatte");
			Color color_ = class2.method_2();
			if (!color_.IsEmpty)
			{
				xmlTextWriter_0.WriteStartElement("a:extrusionClr");
				xmlTextWriter_0.WriteStartElement("a:srgbClr");
				xmlTextWriter_0.WriteAttributeString("val", Class1618.smethod_64(color_));
				xmlTextWriter_0.WriteEndElement();
				xmlTextWriter_0.WriteEndElement();
			}
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_15(XmlTextWriter xmlTextWriter_0)
	{
		if (class1359_0.shape_0.MsoDrawingType == MsoDrawingType.Picture)
		{
			xmlTextWriter_0.WriteStartElement(string_3 + ":pic");
			method_39(xmlTextWriter_0);
			method_34(xmlTextWriter_0);
			method_31(xmlTextWriter_0);
			method_21(xmlTextWriter_0);
			xmlTextWriter_0.WriteEndElement();
		}
	}

	[Attribute0(true)]
	private void method_16(XmlTextWriter xmlTextWriter_0)
	{
		bool flag = shape_0.method_27().method_9().method_9();
		bool flag2 = shape_0.method_27().method_9().method_11();
		if (shape_0.MsoDrawingType == MsoDrawingType.Chart)
		{
			xmlTextWriter_0.WriteStartElement(string_3 + ":xfrm");
		}
		else
		{
			xmlTextWriter_0.WriteStartElement("a:xfrm");
		}
		if (shape_0.RotationAngle != 0.0)
		{
			xmlTextWriter_0.WriteAttributeString("rot", Class1618.smethod_80((int)(shape_0.RotationAngle * 60000.0)));
		}
		if (flag2)
		{
			xmlTextWriter_0.WriteAttributeString("flipH", "1");
		}
		if (flag)
		{
			xmlTextWriter_0.WriteAttributeString("flipV", "1");
		}
		int int_ = class1359_0.class1540_0.workbook_0.Worksheets.method_76();
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		if (shape_0.method_33())
		{
			Class1698 @class = shape_0.method_27().method_7();
			GroupShape groupShape = (GroupShape)shape_0.method_13();
			num = (int)((double)@class.Left * ((double)groupShape.method_69().int_1 / 4000.0) + 0.5) + groupShape.method_69().int_0;
			num2 = (int)((double)@class.Top * ((double)groupShape.method_69().int_3 / 4000.0) + 0.5) + groupShape.method_69().int_2;
			num3 = (int)((double)@class.Right * ((double)groupShape.method_69().int_1 / 4000.0) + 0.5);
			num4 = (int)((double)@class.Bottom * ((double)groupShape.method_69().int_3 / 4000.0) + 0.5);
		}
		else
		{
			if (class1359_0.enum197_0 == Enum197.const_2)
			{
				shape_0.method_18(out var left, out var top, out var right, out var bottom);
				double num5 = Math.Min(1.0, (double)left / 4000.0);
				double num6 = Math.Min(1.0, (double)top / 4000.0);
				Math.Min(1.0, (double)right / 4000.0);
				Math.Min(1.0, (double)bottom / 4000.0);
				double num7 = num5 * (double)class1359_0.chart_0.ChartObject.Width;
				num = Class1618.smethod_50((int)num7, int_0);
				double num8 = num6 * (double)class1359_0.chart_0.ChartObject.Height;
				num2 = Class1618.smethod_50((int)num8, int_);
			}
			else
			{
				num = Class1618.smethod_50(shape_0.method_38(), int_0);
				num2 = Class1618.smethod_50(shape_0.method_36(), int_);
			}
			num3 = Class1618.smethod_50(shape_0.Width, int_0);
			if (num3 < 0)
			{
				num3 = 0;
			}
			num4 = Class1618.smethod_50(shape_0.Height, int_);
			if (num4 < 0)
			{
				num4 = 0;
			}
		}
		xmlTextWriter_0.WriteStartElement("a:off");
		xmlTextWriter_0.WriteAttributeString("x", Class1618.smethod_80(num));
		xmlTextWriter_0.WriteAttributeString("y", Class1618.smethod_80(num2));
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteStartElement("a:ext");
		xmlTextWriter_0.WriteAttributeString("cx", Class1618.smethod_80(num3));
		xmlTextWriter_0.WriteAttributeString("cy", Class1618.smethod_80(num4));
		xmlTextWriter_0.WriteEndElement();
		if (shape_0.IsGroup)
		{
			Class1114 class2 = ((GroupShape)shape_0).method_69();
			xmlTextWriter_0.WriteStartElement("a:chOff");
			xmlTextWriter_0.WriteAttributeString("x", Class1618.smethod_80(class2.int_0));
			xmlTextWriter_0.WriteAttributeString("y", Class1618.smethod_80(class2.int_2));
			xmlTextWriter_0.WriteEndElement();
			xmlTextWriter_0.WriteStartElement("a:chExt");
			xmlTextWriter_0.WriteAttributeString("cx", Class1618.smethod_80(class2.int_1));
			xmlTextWriter_0.WriteAttributeString("cy", Class1618.smethod_80(class2.int_3));
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_17(XmlTextWriter xmlTextWriter_0, int int_1, int int_2)
	{
		xmlTextWriter_0.WriteStartElement("a:pt");
		xmlTextWriter_0.WriteAttributeString("x", Class1618.smethod_80(int_1));
		xmlTextWriter_0.WriteAttributeString("y", Class1618.smethod_80(int_2));
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_18(XmlTextWriter xmlTextWriter_0)
	{
		if (shape_0.AutoShapeType == AutoShapeType.NotPrimitive)
		{
			xmlTextWriter_0.WriteStartElement("a:custGeom");
			xmlTextWriter_0.WriteStartElement("a:pathLst");
			GeomPathsInfo pathsInfo = shape_0.PathsInfo;
			ArrayList pathList = pathsInfo.PathList;
			pathsInfo.method_1();
			for (int i = 0; i < pathList.Count; i++)
			{
				GeomPathInfo geomPathInfo = (GeomPathInfo)pathList[i];
				xmlTextWriter_0.WriteStartElement("a:path");
				if (geomPathInfo.bool_0)
				{
					xmlTextWriter_0.WriteAttributeString("extrusionOk", "1");
				}
				if (geomPathInfo.enum131_0 != Enum131.const_5)
				{
					xmlTextWriter_0.WriteAttributeString("fill", Class1673.smethod_18(geomPathInfo.enum131_0));
				}
				if (!geomPathInfo.bool_1)
				{
					xmlTextWriter_0.WriteAttributeString("stroke", "0");
				}
				xmlTextWriter_0.WriteAttributeString("h", Class1618.smethod_82(geomPathInfo.long_0));
				xmlTextWriter_0.WriteAttributeString("w", Class1618.smethod_82(geomPathInfo.long_1));
				for (int j = 0; j < geomPathInfo.PathSegementList.Count; j++)
				{
					MsoPathInfo msoPathInfo = (MsoPathInfo)geomPathInfo.PathSegementList[j];
					switch (msoPathInfo.Type)
					{
					case MsoPathType.MsopathLineTo:
						xmlTextWriter_0.WriteStartElement("a:lnTo");
						method_17(xmlTextWriter_0, ((Point)msoPathInfo.PointList[1]).X, ((Point)msoPathInfo.PointList[1]).Y);
						xmlTextWriter_0.WriteEndElement();
						break;
					case MsoPathType.MsopathCurveTo:
						xmlTextWriter_0.WriteStartElement("a:cubicBezTo");
						method_17(xmlTextWriter_0, ((Point)msoPathInfo.PointList[1]).X, ((Point)msoPathInfo.PointList[1]).Y);
						method_17(xmlTextWriter_0, ((Point)msoPathInfo.PointList[2]).X, ((Point)msoPathInfo.PointList[2]).Y);
						method_17(xmlTextWriter_0, ((Point)msoPathInfo.PointList[3]).X, ((Point)msoPathInfo.PointList[3]).Y);
						xmlTextWriter_0.WriteEndElement();
						break;
					case MsoPathType.MsopathMoveTo:
						xmlTextWriter_0.WriteStartElement("a:moveTo");
						method_17(xmlTextWriter_0, ((Point)msoPathInfo.PointList[0]).X, ((Point)msoPathInfo.PointList[0]).Y);
						xmlTextWriter_0.WriteEndElement();
						break;
					case MsoPathType.MsopathClose:
						xmlTextWriter_0.WriteStartElement("a:close");
						xmlTextWriter_0.WriteEndElement();
						break;
					}
				}
				xmlTextWriter_0.WriteEndElement();
			}
			xmlTextWriter_0.WriteEndElement();
			xmlTextWriter_0.WriteEndElement();
			return;
		}
		xmlTextWriter_0.WriteStartElement("a:prstGeom");
		Enum186 @enum = Class1618.smethod_231(shape_0.AutoShapeType);
		if (@enum != Enum186.const_187)
		{
			xmlTextWriter_0.WriteAttributeString("prst", Class1618.smethod_230(@enum));
		}
		else
		{
			xmlTextWriter_0.WriteAttributeString("prst", "rect");
		}
		if (shape_0.method_10() != null)
		{
			xmlTextWriter_0.WriteStartElement("a:avLst");
			foreach (object item in shape_0.method_9().method_0())
			{
				Class1244 class1244_ = (Class1244)item;
				method_19(xmlTextWriter_0, class1244_);
			}
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_19(XmlTextWriter xmlTextWriter_0, Class1244 class1244_0)
	{
		if (class1244_0.string_0 != null && class1244_0.string_1 != null)
		{
			xmlTextWriter_0.WriteStartElement("a:gd");
			xmlTextWriter_0.WriteAttributeString("name", class1244_0.string_0);
			xmlTextWriter_0.WriteAttributeString("fmla", class1244_0.string_1);
			xmlTextWriter_0.WriteEndElement();
		}
	}

	[Attribute0(true)]
	private void method_20(XmlTextWriter xmlTextWriter_0)
	{
		if (shape_0.Fill.Type == FillType.Automatic && shape_0.Fill.bool_0)
		{
			shape_0.Fill.Type = FillType.Solid;
			shape_0.Fill.SolidFill.Color = Color.White;
		}
		Class1236 @class = new Class1236(class1359_0);
		@class.method_20(xmlTextWriter_0, shape_0.Fill);
	}

	[Attribute0(true)]
	private void method_21(XmlTextWriter xmlTextWriter_0)
	{
		if (shape_0.IsGroup)
		{
			xmlTextWriter_0.WriteStartElement(string_3 + ":grpSpPr");
		}
		else
		{
			xmlTextWriter_0.WriteStartElement(string_3 + ":spPr");
		}
		string text = method_37(Enum169.const_15);
		if (text != null)
		{
			xmlTextWriter_0.WriteAttributeString("bwMode", text);
		}
		method_16(xmlTextWriter_0);
		if (!shape_0.IsGroup)
		{
			method_18(xmlTextWriter_0);
		}
		method_20(xmlTextWriter_0);
		if (!shape_0.IsGroup)
		{
			method_29(xmlTextWriter_0);
		}
		method_23(xmlTextWriter_0);
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_22(XmlTextWriter xmlTextWriter_0)
	{
		if (shape_0.IsGroup)
		{
			xmlTextWriter_0.WriteStartElement(string_3 + ":grpSpPr");
		}
		else
		{
			xmlTextWriter_0.WriteStartElement(string_3 + ":spPr");
		}
		method_16(xmlTextWriter_0);
		xmlTextWriter_0.WriteStartElement("a:prstGeom", null);
		xmlTextWriter_0.WriteAttributeString("prst", "rect");
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteElementString("a:noFill", null);
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_23(XmlTextWriter xmlTextWriter_0)
	{
		if (!method_24(Enum169.const_26, xmlTextWriter_0))
		{
			method_24(Enum169.const_27, xmlTextWriter_0);
		}
		method_24(Enum169.const_25, xmlTextWriter_0);
		method_24(Enum169.const_28, xmlTextWriter_0);
		method_24(Enum169.const_29, xmlTextWriter_0);
	}

	[Attribute0(true)]
	private bool method_24(Enum169 enum169_0, XmlTextWriter xmlTextWriter_0)
	{
		string text = method_37(enum169_0);
		if (text != null)
		{
			xmlTextWriter_0.WriteRaw(text);
			return true;
		}
		return false;
	}

	[Attribute0(true)]
	private void method_25(XmlTextWriter xmlTextWriter_0)
	{
		string text = method_37(Enum169.const_30);
		if (method_38(Enum169.const_30))
		{
			text = Class1618.smethod_80(Class1618.smethod_51(shape_0.LineFormat.Weight));
		}
		if (text != null)
		{
			xmlTextWriter_0.WriteAttributeString("w", text);
		}
		string text2 = method_37(Enum169.const_31);
		if (text2 != null)
		{
			xmlTextWriter_0.WriteAttributeString("cap", text2);
		}
		string text3 = method_37(Enum169.const_32);
		if (method_38(Enum169.const_32))
		{
			text3 = Class1618.smethod_54(shape_0.LineFormat.Style);
		}
		if (text3 != null)
		{
			xmlTextWriter_0.WriteAttributeString("cmpd", text3);
		}
		string text4 = method_37(Enum169.const_33);
		if (text4 != null)
		{
			xmlTextWriter_0.WriteAttributeString("algn", text4);
		}
	}

	[Attribute0(true)]
	private void method_26(XmlTextWriter xmlTextWriter_0)
	{
		if (!method_38(Enum169.const_35))
		{
			if (!method_24(Enum169.const_36, xmlTextWriter_0) && !method_24(Enum169.const_37, xmlTextWriter_0))
			{
				method_24(Enum169.const_35, xmlTextWriter_0);
			}
			return;
		}
		if (!shape_0.LineFormat.Contains(Enum182.const_18) && !shape_0.LineFormat.Contains(Enum182.const_19))
		{
			if (shape_0.LineFormat.IsVisible && Class1618.smethod_235(shape_0.AutoShapeType))
			{
				xmlTextWriter_0.WriteStartElement("a:solidFill");
				xmlTextWriter_0.WriteStartElement("a:srgbClr");
				xmlTextWriter_0.WriteAttributeString("val", "000000");
				xmlTextWriter_0.WriteEndElement();
				xmlTextWriter_0.WriteEndElement();
			}
			return;
		}
		bool flag = shape_0.LineFormat.method_1();
		Color foreColor = shape_0.LineFormat.ForeColor;
		flag = Class1178.smethod_0(foreColor);
		double num = shape_0.LineFormat.method_2();
		if (num != 1.0 || !flag)
		{
			xmlTextWriter_0.WriteStartElement("a:solidFill");
			if (!flag)
			{
				xmlTextWriter_0.WriteStartElement("a:srgbClr");
				string value = Class1025.smethod_7(foreColor.ToArgb()).Substring(2);
				xmlTextWriter_0.WriteAttributeString("val", value);
			}
			if (num != 1.0)
			{
				xmlTextWriter_0.WriteStartElement("a:alpha");
				int num2 = (int)(100000.0 * shape_0.LineFormat.method_2());
				xmlTextWriter_0.WriteAttributeString("val", Class1618.smethod_80(num2));
				xmlTextWriter_0.WriteEndElement();
			}
			xmlTextWriter_0.WriteEndElement();
			xmlTextWriter_0.WriteEndElement();
		}
	}

	[Attribute0(true)]
	private void method_27(XmlTextWriter xmlTextWriter_0)
	{
		if (!method_38(Enum169.const_39))
		{
			if (!method_24(Enum169.const_38, xmlTextWriter_0))
			{
				method_24(Enum169.const_39, xmlTextWriter_0);
			}
		}
		else if (shape_0.LineFormat.DashStyle != MsoLineDashStyle.Solid)
		{
			string value = Class1618.smethod_58(shape_0.LineFormat.DashStyle);
			xmlTextWriter_0.WriteStartElement("a:prstDash");
			xmlTextWriter_0.WriteAttributeString("val", value);
			xmlTextWriter_0.WriteEndElement();
		}
	}

	private void method_28(XmlTextWriter xmlTextWriter_0)
	{
		method_24(Enum169.const_42, xmlTextWriter_0);
		method_24(Enum169.const_40, xmlTextWriter_0);
		method_24(Enum169.const_41, xmlTextWriter_0);
		method_24(Enum169.const_45, xmlTextWriter_0);
	}

	[Attribute0(true)]
	private void method_29(XmlTextWriter xmlTextWriter_0)
	{
		if (shape_0.LineFormat.IsVisible)
		{
			xmlTextWriter_0.WriteStartElement("a:ln");
			method_25(xmlTextWriter_0);
			method_26(xmlTextWriter_0);
			method_27(xmlTextWriter_0);
			method_28(xmlTextWriter_0);
			method_30(xmlTextWriter_0, bool_0: true);
			method_30(xmlTextWriter_0, bool_0: false);
			xmlTextWriter_0.WriteEndElement();
		}
		else
		{
			xmlTextWriter_0.WriteStartElement("a:ln");
			method_25(xmlTextWriter_0);
			xmlTextWriter_0.WriteElementString("a:noFill", null);
			xmlTextWriter_0.WriteEndElement();
		}
	}

	[Attribute0(true)]
	private void method_30(XmlTextWriter xmlTextWriter_0, bool bool_0)
	{
		MsoLineFormat lineFormat = shape_0.LineFormat;
		object obj = null;
		object obj2 = null;
		object obj3 = null;
		string text = null;
		if (bool_0)
		{
			obj = lineFormat.BeginArrowheadStyle;
			object obj4 = lineFormat.method_0()[466];
			if (obj4 != null)
			{
				obj2 = lineFormat.BeginArrowheadWidth;
			}
			obj4 = lineFormat.method_0()[467];
			if (obj4 != null)
			{
				obj3 = lineFormat.BeginArrowheadLength;
			}
			text = "headEnd";
		}
		else
		{
			obj = lineFormat.EndArrowheadStyle;
			object obj5 = lineFormat.method_0()[466];
			if (obj5 != null)
			{
				obj2 = lineFormat.EndArrowheadWidth;
			}
			obj5 = lineFormat.method_0()[467];
			if (obj5 != null)
			{
				obj3 = lineFormat.EndArrowheadLength;
			}
			text = "tailEnd";
		}
		if ((MsoArrowheadStyle)obj != 0)
		{
			xmlTextWriter_0.WriteStartElement("a:" + text, null);
			xmlTextWriter_0.WriteAttributeString("type", Class1618.smethod_169((MsoArrowheadStyle)obj));
			if (obj2 != null)
			{
				xmlTextWriter_0.WriteAttributeString("w", Class1618.smethod_171((MsoArrowheadWidth)obj2));
			}
			if (obj3 != null)
			{
				xmlTextWriter_0.WriteAttributeString("len", Class1618.smethod_167((MsoArrowheadLength)obj3));
			}
			xmlTextWriter_0.WriteEndElement();
		}
	}

	[Attribute0(true)]
	private void method_31(XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartElement(string_3 + ":blipFill");
		xmlTextWriter_0.WriteStartElement("a:blip");
		if (class1359_0.bool_0)
		{
			xmlTextWriter_0.WriteAttributeString("r:link", class1359_0.string_0);
		}
		else
		{
			xmlTextWriter_0.WriteAttributeString("r:embed", class1359_0.string_0);
		}
		if (class1359_0.shape_0.FormatPicture.class1109_0 != null)
		{
			method_32(xmlTextWriter_0);
		}
		if (class1359_0.shape_0.FormatPicture.arrayList_0 != null)
		{
			for (int i = 0; i < class1359_0.shape_0.FormatPicture.arrayList_0.Count; i++)
			{
				xmlTextWriter_0.WriteRaw((string)class1359_0.shape_0.FormatPicture.arrayList_0[i]);
			}
		}
		xmlTextWriter_0.WriteEndElement();
		method_33(xmlTextWriter_0);
		if (!shape_0.bool_0)
		{
			xmlTextWriter_0.WriteStartElement("a:stretch");
			xmlTextWriter_0.WriteStartElement("a:fillRect");
			xmlTextWriter_0.WriteEndElement();
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_32(XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartElement("a:clrChange");
		xmlTextWriter_0.WriteStartElement("a:clrFrom");
		Class1236.smethod_0(xmlTextWriter_0, class1359_0.shape_0.FormatPicture.class1109_0.cellsColor_0.internalColor_0, class1359_0.shape_0.FormatPicture.class1109_0.int_0, class1359_0.class1540_0.workbook_0);
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteStartElement("a:clrTo");
		Class1236.smethod_0(xmlTextWriter_0, class1359_0.shape_0.FormatPicture.class1109_0.cellsColor_1.internalColor_0, class1359_0.shape_0.FormatPicture.class1109_0.int_1, class1359_0.class1540_0.workbook_0);
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_33(XmlTextWriter xmlTextWriter_0)
	{
		MsoFormatPicture formatPicture = shape_0.FormatPicture;
		double topCrop = formatPicture.TopCrop;
		double bottomCrop = formatPicture.BottomCrop;
		double leftCrop = formatPicture.LeftCrop;
		double rightCrop = formatPicture.RightCrop;
		if (topCrop != 0.0 || bottomCrop != 0.0 || leftCrop != 0.0 || rightCrop != 0.0)
		{
			xmlTextWriter_0.WriteStartElement("a:srcRect");
			if (leftCrop > 0.0)
			{
				xmlTextWriter_0.WriteAttributeString("l", Class1618.smethod_80((int)(leftCrop * 100000.0)));
			}
			if (topCrop > 0.0)
			{
				xmlTextWriter_0.WriteAttributeString("t", Class1618.smethod_80((int)(topCrop * 100000.0)));
			}
			if (rightCrop > 0.0)
			{
				xmlTextWriter_0.WriteAttributeString("r", Class1618.smethod_80((int)(rightCrop * 100000.0)));
			}
			if (bottomCrop > 0.0)
			{
				xmlTextWriter_0.WriteAttributeString("b", Class1618.smethod_80((int)(bottomCrop * 100000.0)));
			}
			xmlTextWriter_0.WriteEndElement();
		}
	}

	private void method_34(XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartElement(string_3 + ":nvPicPr");
		method_35(xmlTextWriter_0);
		xmlTextWriter_0.WriteStartElement(string_3 + ":cNvPicPr");
		xmlTextWriter_0.WriteStartElement("a:picLocks");
		xmlTextWriter_0.WriteAttributeString("noChangeAspect", "1");
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_35(XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartElement(string_3 + ":cNvPr");
		string text = method_37(Enum169.const_9);
		if (text != null)
		{
			xmlTextWriter_0.WriteAttributeString("id", text);
		}
		else if (class1359_0.int_0 != -1)
		{
			xmlTextWriter_0.WriteAttributeString("id", Class1618.smethod_80(class1359_0.int_0));
		}
		string name = shape_0.Name;
		if (name != null && name != "")
		{
			xmlTextWriter_0.WriteAttributeString("name", Class1618.smethod_4(name));
		}
		string alternativeText = shape_0.AlternativeText;
		if (alternativeText != null && alternativeText != "")
		{
			xmlTextWriter_0.WriteAttributeString("descr", alternativeText);
		}
		string title = shape_0.Title;
		if (title != null && title != "")
		{
			xmlTextWriter_0.WriteAttributeString("title", title);
		}
		if (shape_0.IsHidden)
		{
			xmlTextWriter_0.WriteAttributeString("hidden", "1");
		}
		if (class1359_0.string_1 != null)
		{
			xmlTextWriter_0.WriteStartElement("a:hlinkClick");
			xmlTextWriter_0.WriteAttributeString("r:id", class1359_0.string_1);
			xmlTextWriter_0.WriteEndElement();
		}
		string text2 = method_37(Enum169.const_14);
		if (text2 != null)
		{
			xmlTextWriter_0.WriteRaw(text2);
		}
		string text3 = method_37(Enum169.const_47);
		if (text3 != null)
		{
			xmlTextWriter_0.WriteRaw(text3);
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_36(XmlTextWriter xmlTextWriter_0)
	{
		if (class1359_0.shape_0.MsoDrawingType == MsoDrawingType.Chart)
		{
			xmlTextWriter_0.WriteStartElement(string_3 + ":graphicFrame");
			method_39(xmlTextWriter_0);
			xmlTextWriter_0.WriteStartElement(string_3 + ":nvGraphicFramePr");
			method_35(xmlTextWriter_0);
			xmlTextWriter_0.WriteElementString(string_3 + ":cNvGraphicFramePr", null);
			xmlTextWriter_0.WriteEndElement();
			method_16(xmlTextWriter_0);
			xmlTextWriter_0.WriteStartElement("a:graphic");
			xmlTextWriter_0.WriteStartElement("a:graphicData");
			xmlTextWriter_0.WriteAttributeString("uri", "http://schemas.openxmlformats.org/drawingml/2006/chart");
			xmlTextWriter_0.WriteStartElement("c:chart");
			xmlTextWriter_0.WriteAttributeString("xmlns:c", "http://schemas.openxmlformats.org/drawingml/2006/chart");
			xmlTextWriter_0.WriteAttributeString("r:id", class1359_0.string_0);
			xmlTextWriter_0.WriteEndElement();
			xmlTextWriter_0.WriteEndElement();
			xmlTextWriter_0.WriteEndElement();
			xmlTextWriter_0.WriteEndElement();
		}
	}

	private string method_37(Enum169 enum169_0)
	{
		if (class1230_0 != null && class1230_0.class1234_0 != null)
		{
			return class1230_0.method_3(enum169_0);
		}
		return null;
	}

	private bool method_38(Enum169 enum169_0)
	{
		if (class1230_0 != null && class1230_0.class1234_0 != null)
		{
			return class1230_0.method_0(enum169_0);
		}
		return true;
	}

	private void method_39(XmlTextWriter xmlTextWriter_0)
	{
		string text = method_37(Enum169.const_3);
		if (text != null)
		{
			xmlTextWriter_0.WriteAttributeString("macro", text);
		}
		else if (shape_0.method_0() != null)
		{
			xmlTextWriter_0.WriteAttributeString("macro", shape_0.method_0());
		}
		string text2 = method_37(Enum169.const_5);
		if (text2 != null)
		{
			xmlTextWriter_0.WriteAttributeString("fPublished", text2);
		}
		string text3 = method_37(Enum169.const_2);
		if (text3 != null)
		{
			xmlTextWriter_0.WriteAttributeString("fLocksText", text3);
		}
		else if (shape_0.MsoDrawingType == MsoDrawingType.TextBox)
		{
			TextBox textBox = (TextBox)shape_0;
			if (!textBox.method_63().method_6())
			{
				xmlTextWriter_0.WriteAttributeString("fLocksText", "0");
			}
		}
		string text4 = method_37(Enum169.const_4);
		if (text4 != null)
		{
			xmlTextWriter_0.WriteAttributeString("textlink", text4);
			return;
		}
		string linkedCell = shape_0.LinkedCell;
		if (linkedCell != null)
		{
			xmlTextWriter_0.WriteAttributeString("textlink", linkedCell);
		}
	}

	private void method_40(XmlTextWriter xmlTextWriter_0)
	{
		switch (class1359_0.enum197_0)
		{
		default:
			method_44(xmlTextWriter_0);
			break;
		case Enum197.const_1:
			method_42(xmlTextWriter_0);
			break;
		case Enum197.const_2:
			method_41(xmlTextWriter_0);
			break;
		case Enum197.const_3:
			method_43(xmlTextWriter_0);
			break;
		}
	}

	[Attribute0(true)]
	private void method_41(XmlTextWriter xmlTextWriter_0)
	{
		shape_0.method_18(out var left, out var top, out var right, out var bottom);
		double double_ = Math.Min(1.0, (double)left / 4000.0);
		double double_2 = Math.Min(1.0, (double)top / 4000.0);
		double double_3 = Math.Min(1.0, (double)right / 4000.0);
		double double_4 = Math.Min(1.0, (double)bottom / 4000.0);
		xmlTextWriter_0.WriteStartElement("cdr:from");
		xmlTextWriter_0.WriteStartElement("cdr:x");
		xmlTextWriter_0.WriteString(Class1618.smethod_79(double_));
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteStartElement("cdr:y");
		xmlTextWriter_0.WriteString(Class1618.smethod_79(double_2));
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteStartElement("cdr:to");
		xmlTextWriter_0.WriteStartElement("cdr:x");
		xmlTextWriter_0.WriteString(Class1618.smethod_79(double_3));
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteStartElement("cdr:y");
		xmlTextWriter_0.WriteString(Class1618.smethod_79(double_4));
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_42(XmlTextWriter xmlTextWriter_0)
	{
		int num = shape_0.Width;
		int num2 = shape_0.Height;
		if (num < 911)
		{
			num = 900;
			num2 = 600;
		}
		num = Class1618.smethod_50(num, int_0);
		num2 = Class1618.smethod_50(num2, int_0);
		xmlTextWriter_0.WriteStartElement("xdr:pos");
		xmlTextWriter_0.WriteAttributeString("x", "0");
		xmlTextWriter_0.WriteAttributeString("y", "0");
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteStartElement("xdr:ext");
		xmlTextWriter_0.WriteAttributeString("cx", Class1618.smethod_80(num));
		xmlTextWriter_0.WriteAttributeString("cy", Class1618.smethod_80(num2));
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_43(XmlTextWriter xmlTextWriter_0)
	{
		int upperLeftColumn = shape_0.UpperLeftColumn;
		int left = shape_0.Left;
		int upperLeftRow = shape_0.UpperLeftRow;
		int top = shape_0.Top;
		xmlTextWriter_0.WriteStartElement("xdr:from");
		xmlTextWriter_0.WriteStartElement("xdr:col");
		xmlTextWriter_0.WriteString(Class1618.smethod_80(upperLeftColumn));
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteStartElement("xdr:colOff");
		xmlTextWriter_0.WriteString(Class1618.smethod_80(Class1618.smethod_50(left, int_0)));
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteStartElement("xdr:row");
		xmlTextWriter_0.WriteString(Class1618.smethod_80(upperLeftRow));
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteStartElement("xdr:rowOff");
		xmlTextWriter_0.WriteString(Class1618.smethod_80(Class1618.smethod_50(top, int_0)));
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndElement();
		int width = shape_0.Width;
		int height = shape_0.Height;
		width = Class1618.smethod_50(width, int_0);
		height = Class1618.smethod_50(height, int_0);
		xmlTextWriter_0.WriteStartElement("xdr:ext");
		xmlTextWriter_0.WriteAttributeString("cx", Class1618.smethod_80(width));
		xmlTextWriter_0.WriteAttributeString("cy", Class1618.smethod_80(height));
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_44(XmlTextWriter xmlTextWriter_0)
	{
		int upperLeftColumn = shape_0.UpperLeftColumn;
		int upperDeltaX = shape_0.UpperDeltaX;
		upperDeltaX = shape_0.method_43(upperLeftColumn, 0, upperLeftColumn, upperDeltaX);
		int upperLeftRow = shape_0.UpperLeftRow;
		int upperDeltaY = shape_0.UpperDeltaY;
		upperDeltaY = shape_0.method_42(upperLeftRow, 0, upperLeftRow, upperDeltaY);
		int lowerRightColumn = shape_0.LowerRightColumn;
		int lowerDeltaX = shape_0.LowerDeltaX;
		lowerDeltaX = shape_0.method_43(lowerRightColumn, 0, lowerRightColumn, lowerDeltaX);
		int lowerRightRow = shape_0.LowerRightRow;
		int lowerDeltaY = shape_0.LowerDeltaY;
		lowerDeltaY = shape_0.method_42(lowerRightRow, 0, lowerRightRow, lowerDeltaY);
		xmlTextWriter_0.WriteStartElement("xdr:from");
		xmlTextWriter_0.WriteStartElement("xdr:col");
		xmlTextWriter_0.WriteString(Class1618.smethod_80(upperLeftColumn));
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteStartElement("xdr:colOff");
		xmlTextWriter_0.WriteString(Class1618.smethod_80(Class1618.smethod_50(upperDeltaX, int_0)));
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteStartElement("xdr:row");
		xmlTextWriter_0.WriteString(Class1618.smethod_80(upperLeftRow));
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteStartElement("xdr:rowOff");
		xmlTextWriter_0.WriteString(Class1618.smethod_80(Class1618.smethod_50(upperDeltaY, int_0)));
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteStartElement("xdr:to");
		xmlTextWriter_0.WriteStartElement("xdr:col");
		xmlTextWriter_0.WriteString(Class1618.smethod_80(lowerRightColumn));
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteStartElement("xdr:colOff");
		xmlTextWriter_0.WriteString(Class1618.smethod_80(Class1618.smethod_50(lowerDeltaX, int_0)));
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteStartElement("xdr:row");
		xmlTextWriter_0.WriteString(Class1618.smethod_80(lowerRightRow));
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteStartElement("xdr:rowOff");
		xmlTextWriter_0.WriteString(Class1618.smethod_80(Class1618.smethod_50(lowerDeltaY, int_0)));
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndElement();
	}
}
