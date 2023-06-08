using System.Drawing;
using System.Xml;
using Aspose.Cells;
using Aspose.Cells.Charts;
using Aspose.Cells.Drawing;
using ns21;
using ns22;
using ns44;
using ns7;

namespace ns16;

internal class Class1236
{
	private Class1533 class1533_0;

	private ShapePropertyCollection shapePropertyCollection_0;

	private Workbook workbook_0;

	private bool bool_0;

	private Class1359 class1359_0;

	internal static bool Write(XmlTextWriter xmlTextWriter_0, Class1533 class1533_1, ShapePropertyCollection shapePropertyCollection_1)
	{
		if (shapePropertyCollection_1 == null)
		{
			return false;
		}
		Class1236 @class = new Class1236(class1533_1, shapePropertyCollection_1);
		return @class.method_0(xmlTextWriter_0);
	}

	private Class1236(Class1533 class1533_1, ShapePropertyCollection shapePropertyCollection_1)
	{
		class1533_0 = class1533_1;
		workbook_0 = class1533_1.class1540_0.workbook_0;
		shapePropertyCollection_0 = shapePropertyCollection_1;
	}

	internal Class1236(Class1359 class1359_1)
	{
		bool_0 = true;
		class1359_0 = class1359_1;
		workbook_0 = class1359_1.class1540_0.workbook_0;
	}

	private bool method_0(XmlTextWriter xmlTextWriter_0)
	{
		Area area = shapePropertyCollection_0.method_11();
		Line line = shapePropertyCollection_0.method_13();
		if (line == null && shapePropertyCollection_0.enum178_0 == Enum178.const_8)
		{
			Series series = (Series)shapePropertyCollection_0.object_0;
			if (series.Type == ChartType.Scatter)
			{
				line = series.method_28().method_8();
			}
		}
		shapePropertyCollection_0.method_7();
		bool flag = method_19(area);
		bool flag2 = ((line != null && !line.IsAuto) ? true : false);
		bool flag3 = method_1();
		if (!flag && !flag2 && !flag3)
		{
			return false;
		}
		xmlTextWriter_0.WriteStartElement("c:spPr", null);
		if (flag)
		{
			method_20(xmlTextWriter_0, area.FillFormat);
		}
		else if (shapePropertyCollection_0.enum178_0 == Enum178.const_5 && shapePropertyCollection_0.object_0 is ChartPoint)
		{
			ChartPoint chartPoint = (ChartPoint)shapePropertyCollection_0.object_0;
			Series series2 = chartPoint.method_0();
			if (series2 != null)
			{
				Area area2 = series2.ShapeProperties.method_11();
				if (area2 != null && method_19(area))
				{
					method_20(xmlTextWriter_0, area2.FillFormat);
				}
			}
		}
		if (flag2)
		{
			method_27(xmlTextWriter_0, line);
		}
		else if (shapePropertyCollection_0.enum178_0 == Enum178.const_5 && shapePropertyCollection_0.object_0 is ChartPoint)
		{
			ChartPoint chartPoint2 = (ChartPoint)shapePropertyCollection_0.object_0;
			Series series3 = chartPoint2.method_0();
			if (series3 != null)
			{
				Line line2 = series3.ShapeProperties.method_13();
				if (line2 != null && !line2.IsAuto)
				{
					method_27(xmlTextWriter_0, line2);
				}
			}
		}
		method_10(xmlTextWriter_0);
		method_4(xmlTextWriter_0);
		method_2(xmlTextWriter_0);
		xmlTextWriter_0.WriteEndElement();
		return true;
	}

	private bool method_1()
	{
		if ((shapePropertyCollection_0.method_4() == null || shapePropertyCollection_0.method_4().method_0()) && shapePropertyCollection_0.method_2() == null && shapePropertyCollection_0.method_0() == null)
		{
			return false;
		}
		return true;
	}

	[Attribute0(true)]
	private void method_2(XmlTextWriter xmlTextWriter_0)
	{
		Class1113 @class = shapePropertyCollection_0.method_0();
		if (@class == null && shapePropertyCollection_0.enum178_0 == Enum178.const_5 && shapePropertyCollection_0.object_0 is ChartPoint)
		{
			ChartPoint chartPoint = (ChartPoint)shapePropertyCollection_0.object_0;
			Series series = chartPoint.method_0();
			if (series != null)
			{
				Class1113 class2 = series.ShapeProperties.method_0();
				if (class2 != null)
				{
					shapePropertyCollection_0.method_1().Copy(class2);
					@class = shapePropertyCollection_0.method_0();
				}
			}
		}
		if (@class != null)
		{
			xmlTextWriter_0.WriteStartElement("a:sp3d", null);
			if (@class.int_2 != 0)
			{
				xmlTextWriter_0.WriteAttributeString("z", Class1618.smethod_80(@class.int_2));
			}
			if (@class.int_1 != 0)
			{
				xmlTextWriter_0.WriteAttributeString("extrusionH", Class1618.smethod_80(@class.int_1));
			}
			if (@class.int_0 != 0)
			{
				xmlTextWriter_0.WriteAttributeString("contourW", Class1618.smethod_80(@class.int_0));
			}
			if (@class.method_4() != PresetMaterialType.WarmMatte)
			{
				xmlTextWriter_0.WriteAttributeString("prstMaterial", Class1618.smethod_220(@class.method_4()));
			}
			if (@class.method_3() != null)
			{
				method_3(xmlTextWriter_0, @class.method_3(), "bevelT");
			}
			if (@class.method_1() != null)
			{
				method_3(xmlTextWriter_0, @class.method_1(), "bevelB");
			}
			if (@class.method_8() != null)
			{
				xmlTextWriter_0.WriteStartElement("a:extrusionClr", null);
				smethod_0(xmlTextWriter_0, @class.method_8().internalColor_0, -1, workbook_0);
				xmlTextWriter_0.WriteEndElement();
			}
			if (@class.method_6() != null)
			{
				xmlTextWriter_0.WriteStartElement("a:contourClr", null);
				smethod_0(xmlTextWriter_0, @class.method_6().internalColor_0, -1, workbook_0);
				xmlTextWriter_0.WriteEndElement();
			}
			xmlTextWriter_0.WriteEndElement();
		}
	}

	[Attribute0(true)]
	private void method_3(XmlTextWriter xmlTextWriter_0, Bevel bevel_0, string string_0)
	{
		if (bevel_0.Type != 0)
		{
			xmlTextWriter_0.WriteStartElement("a:" + string_0, null);
			if (bevel_0.int_0 != 76200)
			{
				xmlTextWriter_0.WriteAttributeString("w", Class1618.smethod_80(bevel_0.int_0));
			}
			if (bevel_0.int_1 != 76200)
			{
				xmlTextWriter_0.WriteAttributeString("h", Class1618.smethod_80(bevel_0.int_1));
			}
			if (bevel_0.Type != BevelPresetType.Circle)
			{
				xmlTextWriter_0.WriteAttributeString("prst", Class1618.smethod_222(bevel_0.Type));
			}
			xmlTextWriter_0.WriteEndElement();
		}
	}

	private void method_4(XmlTextWriter xmlTextWriter_0)
	{
		Class1295 @class = shapePropertyCollection_0.method_2();
		if (@class == null && shapePropertyCollection_0.enum178_0 == Enum178.const_5 && shapePropertyCollection_0.object_0 is ChartPoint)
		{
			ChartPoint chartPoint = (ChartPoint)shapePropertyCollection_0.object_0;
			Series series = chartPoint.method_0();
			if (series != null)
			{
				Class1295 class2 = series.ShapeProperties.method_2();
				if (class2 != null)
				{
					shapePropertyCollection_0.method_3().Copy(class2);
					@class = shapePropertyCollection_0.method_2();
				}
			}
		}
		if (@class != null)
		{
			xmlTextWriter_0.WriteStartElement("a:scene3d", null);
			method_8(xmlTextWriter_0, @class.method_0());
			method_7(xmlTextWriter_0, @class.method_1());
			if (@class.method_2() != null)
			{
				method_5(xmlTextWriter_0, @class.method_2());
			}
			xmlTextWriter_0.WriteEndElement();
		}
	}

	private void method_5(XmlTextWriter xmlTextWriter_0, Class1286 class1286_0)
	{
		xmlTextWriter_0.WriteStartElement("a:backdrop", null);
		method_6(xmlTextWriter_0, class1286_0.class1112_0, "anchor", "");
		method_6(xmlTextWriter_0, class1286_0.class1112_1, "norm", "d");
		method_6(xmlTextWriter_0, class1286_0.class1112_2, "up", "d");
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_6(XmlTextWriter xmlTextWriter_0, Class1112 class1112_0, string string_0, string string_1)
	{
		xmlTextWriter_0.WriteStartElement("a:" + string_0, null);
		xmlTextWriter_0.WriteAttributeString(string_1 + "x", Class1618.smethod_80(class1112_0.int_0));
		xmlTextWriter_0.WriteAttributeString(string_1 + "y", Class1618.smethod_80(class1112_0.int_1));
		xmlTextWriter_0.WriteAttributeString(string_1 + "z", Class1618.smethod_80(class1112_0.int_2));
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_7(XmlTextWriter xmlTextWriter_0, Class1290 class1290_0)
	{
		xmlTextWriter_0.WriteStartElement("a:lightRig", null);
		xmlTextWriter_0.WriteAttributeString("rig", Class1618.smethod_216(class1290_0.method_1()));
		xmlTextWriter_0.WriteAttributeString("dir", Class1618.smethod_218(class1290_0.method_3()));
		if (class1290_0.class1294_0 != null)
		{
			method_9(xmlTextWriter_0, class1290_0.class1294_0);
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_8(XmlTextWriter xmlTextWriter_0, Class1296 class1296_0)
	{
		xmlTextWriter_0.WriteStartElement("a:camera", null);
		xmlTextWriter_0.WriteAttributeString("prst", Class1618.smethod_214(class1296_0.method_0()));
		if (class1296_0.int_1 != 0)
		{
			xmlTextWriter_0.WriteAttributeString("fov", Class1618.smethod_80(class1296_0.int_1));
		}
		if (class1296_0.int_0 != 100000)
		{
			xmlTextWriter_0.WriteAttributeString("zoom", Class1618.smethod_80(class1296_0.int_0));
		}
		if (class1296_0.class1294_0 != null)
		{
			method_9(xmlTextWriter_0, class1296_0.class1294_0);
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_9(XmlTextWriter xmlTextWriter_0, Class1294 class1294_0)
	{
		xmlTextWriter_0.WriteStartElement("a:rot", null);
		xmlTextWriter_0.WriteAttributeString("lat", Class1618.smethod_80(class1294_0.int_0));
		xmlTextWriter_0.WriteAttributeString("lon", Class1618.smethod_80(class1294_0.int_1));
		xmlTextWriter_0.WriteAttributeString("rev", Class1618.smethod_80(class1294_0.int_2));
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_10(XmlTextWriter xmlTextWriter_0)
	{
		Class1288 @class = shapePropertyCollection_0.method_4();
		if ((@class == null || @class.method_0()) && shapePropertyCollection_0.enum178_0 == Enum178.const_5 && shapePropertyCollection_0.object_0 is ChartPoint)
		{
			ChartPoint chartPoint = (ChartPoint)shapePropertyCollection_0.object_0;
			Series series = chartPoint.method_0();
			if (series != null)
			{
				Class1288 class2 = series.ShapeProperties.method_4();
				if (class2 != null && !class2.method_0())
				{
					shapePropertyCollection_0.method_5().Copy(class2);
					@class = shapePropertyCollection_0.method_4();
				}
			}
		}
		if (@class != null && !@class.method_0())
		{
			xmlTextWriter_0.WriteStartElement("a:effectLst", null);
			if (@class.method_2() != null)
			{
				method_18(xmlTextWriter_0, @class.method_2());
			}
			if (@class.method_4() != null)
			{
				method_17(xmlTextWriter_0, @class.method_4());
			}
			if (@class.method_7() != null)
			{
				method_15(xmlTextWriter_0, @class.method_7());
			}
			else if (@class.method_9() != null)
			{
				method_13(xmlTextWriter_0, @class.method_9());
			}
			else if (@class.method_11() != null)
			{
				method_12(xmlTextWriter_0, @class.method_11());
			}
			if (@class.method_13() != null)
			{
				method_11(xmlTextWriter_0, @class.method_13());
			}
			if (@class.int_0 != 0)
			{
				xmlTextWriter_0.WriteStartElement("a:softEdge", null);
				xmlTextWriter_0.WriteAttributeString("rad", Class1618.smethod_80(@class.int_0));
				xmlTextWriter_0.WriteEndElement();
			}
			xmlTextWriter_0.WriteEndElement();
		}
	}

	[Attribute0(true)]
	private void method_11(XmlTextWriter xmlTextWriter_0, Class1293 class1293_0)
	{
		xmlTextWriter_0.WriteStartElement("a:OuterShdw", null);
		if (class1293_0.int_0 != 0)
		{
			xmlTextWriter_0.WriteAttributeString("blurRad", Class1618.smethod_80(class1293_0.int_0));
		}
		if (class1293_0.int_3 != 100000)
		{
			xmlTextWriter_0.WriteAttributeString("stA", Class1618.smethod_80(class1293_0.int_3));
		}
		if (class1293_0.int_4 != 0)
		{
			xmlTextWriter_0.WriteAttributeString("stPos", Class1618.smethod_80(class1293_0.int_4));
		}
		if (class1293_0.int_1 != 0)
		{
			xmlTextWriter_0.WriteAttributeString("endA", Class1618.smethod_80(class1293_0.int_1));
		}
		if (class1293_0.int_2 != 100000)
		{
			xmlTextWriter_0.WriteAttributeString("endPos", Class1618.smethod_80(class1293_0.int_2));
		}
		if (class1293_0.double_1 != 0.0)
		{
			xmlTextWriter_0.WriteAttributeString("dist", Class1618.smethod_79(class1293_0.double_1));
		}
		if (class1293_0.double_0 != 0.0)
		{
			xmlTextWriter_0.WriteAttributeString("dir", Class1618.smethod_79(class1293_0.double_0));
		}
		if (class1293_0.double_2 != 0.0)
		{
			xmlTextWriter_0.WriteAttributeString("fadeDir", Class1618.smethod_79(class1293_0.double_2));
		}
		if (class1293_0.double_5 != 100000.0)
		{
			xmlTextWriter_0.WriteAttributeString("sx", Class1618.smethod_79(class1293_0.double_5));
		}
		if (class1293_0.double_6 != 100000.0)
		{
			xmlTextWriter_0.WriteAttributeString("sy", Class1618.smethod_79(class1293_0.double_6));
		}
		if (class1293_0.double_3 != 0.0)
		{
			xmlTextWriter_0.WriteAttributeString("kx", Class1618.smethod_79(class1293_0.double_3));
		}
		if (class1293_0.double_4 != 0.0)
		{
			xmlTextWriter_0.WriteAttributeString("ky", Class1618.smethod_79(class1293_0.double_4));
		}
		if (class1293_0.rectangleAlignmentType_0 != 0)
		{
			xmlTextWriter_0.WriteAttributeString("algn", Class1618.smethod_192(class1293_0.rectangleAlignmentType_0));
		}
		if (!class1293_0.bool_0)
		{
			xmlTextWriter_0.WriteAttributeString("rotWithShape", "0");
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_12(XmlTextWriter xmlTextWriter_0, Class1292 class1292_0)
	{
		xmlTextWriter_0.WriteStartElement("a:prstShdw", null);
		if (class1292_0.string_0 != null && class1292_0.string_0.Length != 0)
		{
			xmlTextWriter_0.WriteAttributeString("prst", class1292_0.string_0);
		}
		if (class1292_0.int_1 != 0)
		{
			xmlTextWriter_0.WriteAttributeString("dist", Class1618.smethod_80(class1292_0.int_1));
		}
		if (class1292_0.int_0 != 0)
		{
			xmlTextWriter_0.WriteAttributeString("dir", Class1618.smethod_80(class1292_0.int_0));
		}
		if (class1292_0.method_0() != null)
		{
			int int_ = method_16(class1292_0.Properties);
			smethod_0(xmlTextWriter_0, class1292_0.method_0().internalColor_0, int_, workbook_0);
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_13(XmlTextWriter xmlTextWriter_0, Class1291 class1291_0)
	{
		xmlTextWriter_0.WriteStartElement("a:outerShdw", null);
		if (class1291_0.int_0 != 0)
		{
			xmlTextWriter_0.WriteAttributeString("blurRad", Class1618.smethod_80(class1291_0.int_0));
		}
		if (class1291_0.int_2 != 0)
		{
			xmlTextWriter_0.WriteAttributeString("dist", Class1618.smethod_80(class1291_0.int_2));
		}
		if (class1291_0.int_1 != 0)
		{
			xmlTextWriter_0.WriteAttributeString("dir", Class1618.smethod_80(class1291_0.int_1));
		}
		if (class1291_0.int_5 != 100000)
		{
			xmlTextWriter_0.WriteAttributeString("sx", Class1618.smethod_80(class1291_0.int_5));
		}
		if (class1291_0.int_6 != 100000)
		{
			xmlTextWriter_0.WriteAttributeString("sy", Class1618.smethod_80(class1291_0.int_6));
		}
		if (class1291_0.int_3 != 0)
		{
			xmlTextWriter_0.WriteAttributeString("kx", Class1618.smethod_80(class1291_0.int_3));
		}
		if (class1291_0.int_4 != 0)
		{
			xmlTextWriter_0.WriteAttributeString("ky", Class1618.smethod_80(class1291_0.int_4));
		}
		if (class1291_0.rectangleAlignmentType_0 != 0)
		{
			xmlTextWriter_0.WriteAttributeString("algn", Class1618.smethod_192(class1291_0.rectangleAlignmentType_0));
		}
		if (!class1291_0.bool_0)
		{
			xmlTextWriter_0.WriteAttributeString("rotWithShape", "0");
		}
		if (class1291_0.method_0() != null)
		{
			int int_ = method_16(class1291_0.Properties);
			bool bool_ = method_14(class1291_0.method_0());
			smethod_1(xmlTextWriter_0, class1291_0.method_0().internalColor_0, int_, workbook_0, bool_);
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private bool method_14(CellsColor cellsColor_0)
	{
		if (!cellsColor_0.internalColor_0.method_2() && cellsColor_0.internalColor_0.ColorType == ColorType.RGB && cellsColor_0.internalColor_0.method_4() == 0)
		{
			return true;
		}
		return false;
	}

	[Attribute0(true)]
	private void method_15(XmlTextWriter xmlTextWriter_0, Class1289 class1289_0)
	{
		xmlTextWriter_0.WriteStartElement("a:innerShdw", null);
		if (class1289_0.int_0 != 0)
		{
			xmlTextWriter_0.WriteAttributeString("blurRad", Class1618.smethod_80(class1289_0.int_0));
		}
		if (class1289_0.int_2 != 0)
		{
			xmlTextWriter_0.WriteAttributeString("dist", Class1618.smethod_80(class1289_0.int_2));
		}
		if (class1289_0.int_1 != 0)
		{
			xmlTextWriter_0.WriteAttributeString("dir", Class1618.smethod_80(class1289_0.int_1));
		}
		if (class1289_0.GetColor() != null)
		{
			int int_ = method_16(class1289_0.Properties);
			bool bool_ = method_14(class1289_0.GetColor());
			smethod_1(xmlTextWriter_0, class1289_0.GetColor().internalColor_0, int_, workbook_0, bool_);
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private int method_16(Class923 class923_0)
	{
		if (class923_0 != null && class923_0.Count != -1)
		{
			object obj = class923_0.method_1(Enum230.const_10);
			if (obj != null)
			{
				return (int)obj;
			}
			return -1;
		}
		return -1;
	}

	[Attribute0(true)]
	private void method_17(XmlTextWriter xmlTextWriter_0, GlowEffect glowEffect_0)
	{
		if (glowEffect_0.method_0())
		{
			xmlTextWriter_0.WriteStartElement("a:glow", null);
			if (glowEffect_0.int_0 != 0)
			{
				xmlTextWriter_0.WriteAttributeString("rad", Class1618.smethod_80(glowEffect_0.int_0));
			}
			if (glowEffect_0.GetColor() != null)
			{
				int int_ = method_16(glowEffect_0.Properties);
				smethod_0(xmlTextWriter_0, glowEffect_0.GetColor().internalColor_0, int_, workbook_0);
			}
			xmlTextWriter_0.WriteEndElement();
		}
	}

	[Attribute0(true)]
	private void method_18(XmlTextWriter xmlTextWriter_0, Class1287 class1287_0)
	{
		xmlTextWriter_0.WriteStartElement("a:blur", null);
		if (class1287_0.int_0 != 0)
		{
			xmlTextWriter_0.WriteAttributeString("rad", Class1618.smethod_80(class1287_0.int_0));
		}
		if (!class1287_0.method_0())
		{
			xmlTextWriter_0.WriteAttributeString("grow", "0");
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private bool method_19(Area area_0)
	{
		bool result;
		if ((result = ((area_0 != null && area_0.Formatting != 0) ? true : false)) && area_0.FillFormat.SetType == FormatSetType.IsPatternSet && area_0.FillFormat.Pattern == FillPattern.Solid && area_0.FillFormat.PatternFill.internalColor_1.method_2())
		{
			result = false;
		}
		return result;
	}

	internal void method_20(XmlTextWriter xmlTextWriter_0, FillFormat fillFormat_0)
	{
		if (fillFormat_0.Type == FillType.None)
		{
			xmlTextWriter_0.WriteElementString("a:noFill", null);
		}
		else if (fillFormat_0.Type == FillType.Gradient)
		{
			GradientFill gradientFill = fillFormat_0.GradientFill;
			method_24(xmlTextWriter_0, gradientFill);
		}
		else if (fillFormat_0.Type == FillType.Pattern)
		{
			method_26(xmlTextWriter_0, fillFormat_0);
		}
		else if (fillFormat_0.Type == FillType.Texture)
		{
			method_21(xmlTextWriter_0, fillFormat_0);
		}
		else if (fillFormat_0.Type == FillType.Solid)
		{
			xmlTextWriter_0.WriteStartElement("a:solidFill", null);
			int int_ = ((fillFormat_0.SolidFill.method_0() == 100000) ? (-1) : fillFormat_0.SolidFill.method_0());
			smethod_0(xmlTextWriter_0, fillFormat_0.SolidFill.internalColor_0, int_, workbook_0);
			xmlTextWriter_0.WriteEndElement();
		}
	}

	private void method_21(XmlTextWriter xmlTextWriter_0, FillFormat fillFormat_0)
	{
		TextureFill textureFill = fillFormat_0.TextureFill;
		string text = null;
		text = ((!bool_0) ? class1533_0.method_0(textureFill.ImageData) : class1359_0.class1358_0.method_2(textureFill.ImageData));
		xmlTextWriter_0.WriteStartElement("a:blipFill", null);
		xmlTextWriter_0.WriteStartElement("a:blip", null);
		xmlTextWriter_0.WriteAttributeString("r:embed", text);
		if (textureFill.method_6() != 100000)
		{
			xmlTextWriter_0.WriteStartElement("a:alphaModFix", null);
			xmlTextWriter_0.WriteAttributeString("amt", Class1618.smethod_80(textureFill.method_6()));
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteElementString("a:srcRect", null);
		if (textureFill.method_3())
		{
			method_22(xmlTextWriter_0, textureFill);
		}
		else
		{
			method_23(xmlTextWriter_0, textureFill);
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_22(XmlTextWriter xmlTextWriter_0, TextureFill textureFill_0)
	{
		TilePicOption tilePicOption = textureFill_0.TilePicOption;
		xmlTextWriter_0.WriteStartElement("a:tile", null);
		if (tilePicOption.OffsetX != 0.0)
		{
			xmlTextWriter_0.WriteAttributeString("tx", Class1618.smethod_80((int)tilePicOption.OffsetX));
		}
		if (tilePicOption.OffsetY != 0.0)
		{
			xmlTextWriter_0.WriteAttributeString("ty", Class1618.smethod_80((int)tilePicOption.OffsetY));
		}
		if (tilePicOption.ScaleX != 0.0)
		{
			xmlTextWriter_0.WriteAttributeString("sx", Class1618.smethod_80((int)tilePicOption.ScaleX * 1000));
		}
		if (tilePicOption.ScaleY != 0.0)
		{
			xmlTextWriter_0.WriteAttributeString("sy", Class1618.smethod_80((int)tilePicOption.ScaleY * 1000));
		}
		xmlTextWriter_0.WriteAttributeString("flip", Class1618.smethod_190(tilePicOption.MirrorType));
		xmlTextWriter_0.WriteAttributeString("algn", Class1618.smethod_192(tilePicOption.AlignmentType));
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_23(XmlTextWriter xmlTextWriter_0, TextureFill textureFill_0)
	{
		PicFormatOption picFormatOption = textureFill_0.PicFormatOption;
		xmlTextWriter_0.WriteStartElement("a:stretch", null);
		xmlTextWriter_0.WriteStartElement("a:fillRect", null);
		if (picFormatOption.Left != 0.0)
		{
			xmlTextWriter_0.WriteAttributeString("l", Class1618.smethod_80((int)picFormatOption.Left));
		}
		if (picFormatOption.Top != 0.0)
		{
			xmlTextWriter_0.WriteAttributeString("t", Class1618.smethod_80((int)picFormatOption.Top));
		}
		if (picFormatOption.Right != 0.0)
		{
			xmlTextWriter_0.WriteAttributeString("r", Class1618.smethod_80((int)picFormatOption.Right));
		}
		if (picFormatOption.Bottom != 0.0)
		{
			xmlTextWriter_0.WriteAttributeString("b", Class1618.smethod_80((int)picFormatOption.Bottom));
		}
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_24(XmlTextWriter xmlTextWriter_0, GradientFill gradientFill_0)
	{
		xmlTextWriter_0.WriteStartElement("a:gradFill", null);
		string value = (gradientFill_0.bool_0 ? "1" : "0");
		xmlTextWriter_0.WriteAttributeString("rotWithShape", value);
		if (gradientFill_0.GradientStops.Count > 0)
		{
			xmlTextWriter_0.WriteStartElement("a:gsLst", null);
			for (int i = 0; i < gradientFill_0.GradientStops.Count; i++)
			{
				GradientStop gradientStop = gradientFill_0.GradientStops[i];
				xmlTextWriter_0.WriteStartElement("a:gs", null);
				xmlTextWriter_0.WriteAttributeString("pos", Class1618.smethod_79(gradientStop.Position * 1000.0));
				int int_ = ((gradientStop.method_0() == 100000) ? (-1) : gradientStop.method_0());
				smethod_0(xmlTextWriter_0, gradientStop.internalColor_0, int_, workbook_0);
				xmlTextWriter_0.WriteEndElement();
			}
			xmlTextWriter_0.WriteEndElement();
		}
		if (gradientFill_0.object_0 != null)
		{
			if (gradientFill_0.method_0())
			{
				xmlTextWriter_0.WriteStartElement("a:lin", null);
				xmlTextWriter_0.WriteAttributeString("ang", Class1618.smethod_80(gradientFill_0.method_1().int_0));
				if (gradientFill_0.method_1().bool_0)
				{
					xmlTextWriter_0.WriteAttributeString("scaled", "1");
				}
				xmlTextWriter_0.WriteEndElement();
			}
			else
			{
				Class926 @class = gradientFill_0.method_2();
				xmlTextWriter_0.WriteStartElement("a:path", null);
				xmlTextWriter_0.WriteAttributeString("path", Class1618.smethod_184(@class.enum128_0));
				method_25(xmlTextWriter_0, @class, "fillToRect");
				xmlTextWriter_0.WriteEndElement();
			}
		}
		if (gradientFill_0.method_4() != null)
		{
			method_25(xmlTextWriter_0, gradientFill_0.method_4(), "tileRect");
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_25(XmlTextWriter xmlTextWriter_0, Class926 class926_0, string string_0)
	{
		xmlTextWriter_0.WriteStartElement("a:" + string_0, null);
		if (class926_0.int_0 != 0)
		{
			xmlTextWriter_0.WriteAttributeString("l", Class1618.smethod_80(class926_0.int_0));
		}
		if (class926_0.int_1 != 0)
		{
			xmlTextWriter_0.WriteAttributeString("t", Class1618.smethod_80(class926_0.int_1));
		}
		if (class926_0.int_3 != 0)
		{
			xmlTextWriter_0.WriteAttributeString("r", Class1618.smethod_80(class926_0.int_3));
		}
		if (class926_0.int_2 != 0)
		{
			xmlTextWriter_0.WriteAttributeString("b", Class1618.smethod_80(class926_0.int_2));
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_26(XmlTextWriter xmlTextWriter_0, FillFormat fillFormat_0)
	{
		PatternFill patternFill = fillFormat_0.PatternFill;
		string value = Class1618.smethod_132(patternFill.Pattern);
		xmlTextWriter_0.WriteStartElement("a:pattFill", null);
		xmlTextWriter_0.WriteAttributeString("prst", value);
		xmlTextWriter_0.WriteStartElement("a:fgClr", null);
		int int_ = ((patternFill.method_0() == 100) ? (-1) : (patternFill.method_0() * 1000));
		smethod_0(xmlTextWriter_0, patternFill.internalColor_1, int_, workbook_0);
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteStartElement("a:bgClr", null);
		int_ = ((patternFill.method_4() == 100) ? (-1) : (patternFill.method_4() * 1000));
		smethod_0(xmlTextWriter_0, patternFill.internalColor_0, int_, workbook_0);
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_27(XmlTextWriter xmlTextWriter_0, Line line_0)
	{
		xmlTextWriter_0.WriteStartElement("a:ln", null);
		object obj = null;
		if (line_0.method_28())
		{
			string value = Class1618.smethod_80(Class1618.smethod_51(line_0.WeightPt));
			xmlTextWriter_0.WriteAttributeString("w", value);
		}
		if (line_0.IsVisible)
		{
			obj = line_0.Properties.method_1(Enum230.const_2);
			if (obj != null)
			{
				Enum231 enum231_ = (Enum231)obj;
				xmlTextWriter_0.WriteAttributeString("cap", Class1618.smethod_164(enum231_));
			}
			obj = line_0.Properties.method_1(Enum230.const_0);
			if (obj != null)
			{
				MsoLineStyle msoLineStyle_ = (MsoLineStyle)obj;
				xmlTextWriter_0.WriteAttributeString("cmpd", Class1618.smethod_54(msoLineStyle_));
			}
		}
		if (!line_0.IsVisible)
		{
			xmlTextWriter_0.WriteElementString("a:noFill", null);
		}
		else if (line_0.Style != LineType.LightGray && line_0.Style != LineType.MediumGray && line_0.Style != LineType.DarkGray)
		{
			if (line_0.method_29())
			{
				if (line_0.method_26() == Enum229.const_3)
				{
					method_24(xmlTextWriter_0, line_0.GradientFill);
				}
				else if (line_0.method_26() == Enum229.const_1)
				{
					method_30(xmlTextWriter_0, line_0);
				}
			}
		}
		else
		{
			method_31(xmlTextWriter_0, line_0);
		}
		obj = line_0.Properties.method_1(Enum230.const_1);
		if (obj != null)
		{
			string string_ = Class1618.smethod_58(line_0.method_3());
			smethod_4(xmlTextWriter_0, "a", "prstDash", string_);
		}
		method_29(xmlTextWriter_0, line_0);
		method_28(xmlTextWriter_0, line_0, bool_1: true);
		method_28(xmlTextWriter_0, line_0, bool_1: false);
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_28(XmlTextWriter xmlTextWriter_0, Line line_0, bool bool_1)
	{
		object obj = null;
		object obj2 = null;
		object obj3 = null;
		string text = null;
		if (bool_1)
		{
			obj = line_0.Properties.method_1(Enum230.const_4);
			obj2 = line_0.Properties.method_1(Enum230.const_5);
			obj3 = line_0.Properties.method_1(Enum230.const_6);
			text = "headEnd";
		}
		else
		{
			obj = line_0.Properties.method_1(Enum230.const_7);
			obj2 = line_0.Properties.method_1(Enum230.const_8);
			obj3 = line_0.Properties.method_1(Enum230.const_9);
			text = "tailEnd";
		}
		if (obj3 != null || obj != null || obj2 != null)
		{
			xmlTextWriter_0.WriteStartElement("a:" + text, null);
			if (obj != null)
			{
				xmlTextWriter_0.WriteAttributeString("type", Class1618.smethod_169((MsoArrowheadStyle)obj));
			}
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
	private void method_29(XmlTextWriter xmlTextWriter_0, Line line_0)
	{
		object obj = line_0.Properties.method_1(Enum230.const_3);
		if (obj != null)
		{
			switch ((Enum232)obj)
			{
			case Enum232.const_1:
				xmlTextWriter_0.WriteElementString("a:bevel", null);
				break;
			case Enum232.const_2:
				xmlTextWriter_0.WriteStartElement("a:miter", null);
				xmlTextWriter_0.WriteAttributeString("lim", "800000");
				xmlTextWriter_0.WriteEndElement();
				break;
			case Enum232.const_0:
				xmlTextWriter_0.WriteElementString("a:round", null);
				break;
			}
		}
	}

	private void method_30(XmlTextWriter xmlTextWriter_0, Line line_0)
	{
		xmlTextWriter_0.WriteStartElement("a:solidFill", null);
		int int_ = -1;
		object obj = line_0.Properties.method_1(Enum230.const_10);
		if (obj != null)
		{
			int_ = (int)obj;
		}
		smethod_0(xmlTextWriter_0, line_0.internalColor_0, int_, workbook_0);
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_31(XmlTextWriter xmlTextWriter_0, Line line_0)
	{
		string value = "pct25";
		if (line_0.Style == LineType.MediumGray)
		{
			value = "pct50";
		}
		else if (line_0.Style == LineType.DarkGray)
		{
			value = "pct75";
		}
		xmlTextWriter_0.WriteStartElement("a:pattFill", null);
		xmlTextWriter_0.WriteAttributeString("prst", value);
		xmlTextWriter_0.WriteStartElement("a:fgClr", null);
		smethod_4(xmlTextWriter_0, "a", "srgbClr", "000000");
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteStartElement("a:bgClr", null);
		smethod_4(xmlTextWriter_0, "a", "srgbClr", "FFFFFF");
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndElement();
	}

	internal static void smethod_0(XmlTextWriter xmlTextWriter_0, InternalColor internalColor_0, int int_0, Workbook workbook_1)
	{
		smethod_1(xmlTextWriter_0, internalColor_0, int_0, workbook_1, bool_1: false);
	}

	[Attribute0(true)]
	internal static void smethod_1(XmlTextWriter xmlTextWriter_0, InternalColor internalColor_0, int int_0, Workbook workbook_1, bool bool_1)
	{
		bool flag = false;
		if (bool_1)
		{
			string text = Class1618.smethod_224(internalColor_0.method_7(workbook_1));
			if (text != null)
			{
				xmlTextWriter_0.WriteStartElement("a", "prstClr", null);
				xmlTextWriter_0.WriteAttributeString("val", text);
				flag = true;
			}
		}
		if (!flag)
		{
			if (internalColor_0.ColorType == ColorType.Theme)
			{
				xmlTextWriter_0.WriteStartElement("a", "schemeClr", null);
				xmlTextWriter_0.WriteAttributeString("val", Class1618.smethod_161(internalColor_0.method_4()));
			}
			else
			{
				xmlTextWriter_0.WriteStartElement("a", "srgbClr", null);
				if (internalColor_0.ColorType == ColorType.RGB)
				{
					xmlTextWriter_0.WriteAttributeString("val", Class1618.smethod_64(Color.FromArgb(internalColor_0.method_4())));
				}
				else
				{
					xmlTextWriter_0.WriteAttributeString("val", Class1618.smethod_64(internalColor_0.method_6(workbook_1)));
				}
			}
		}
		if (int_0 != -1)
		{
			smethod_2(internalColor_0, int_0);
		}
		if (internalColor_0.method_17() != null)
		{
			foreach (Class1331 item in internalColor_0.method_18())
			{
				string text2 = smethod_3(item.enum196_0);
				if (text2 != null)
				{
					if (item.enum196_0 != Enum196.const_23 && item.enum196_0 != Enum196.const_24)
					{
						smethod_4(xmlTextWriter_0, "a", text2, Class1618.smethod_80(item.int_0));
					}
					else
					{
						xmlTextWriter_0.WriteElementString("a:" + text2, null);
					}
				}
			}
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private static void smethod_2(InternalColor internalColor_0, int int_0)
	{
		if (int_0 != -1)
		{
			Class1331 @class = internalColor_0.method_18().method_5(Enum196.const_2);
			if (@class != null)
			{
				@class.int_0 = int_0;
			}
			else
			{
				internalColor_0.method_18().method_0(Enum196.const_2, int_0);
			}
		}
	}

	private static string smethod_3(Enum196 enum196_0)
	{
		return enum196_0 switch
		{
			Enum196.const_0 => "tint", 
			Enum196.const_1 => "shade", 
			Enum196.const_2 => "alpha", 
			Enum196.const_3 => "alphaMod", 
			Enum196.const_4 => "alphaOff", 
			Enum196.const_5 => "red", 
			Enum196.const_6 => "redMod", 
			Enum196.const_7 => "redOff", 
			Enum196.const_8 => "green", 
			Enum196.const_9 => "greenMod", 
			Enum196.const_10 => "greenOff", 
			Enum196.const_11 => "blue", 
			Enum196.const_12 => "blueMod", 
			Enum196.const_13 => "blueOff", 
			Enum196.const_14 => "hue", 
			Enum196.const_15 => "hueMod", 
			Enum196.const_16 => "hueOff", 
			Enum196.const_17 => "sat", 
			Enum196.const_18 => "satMod", 
			Enum196.const_19 => "satOff", 
			Enum196.const_20 => "lum", 
			Enum196.const_21 => "lumMod", 
			Enum196.const_22 => "lumOff", 
			Enum196.const_23 => "gamma", 
			Enum196.const_24 => "invGamma", 
			Enum196.const_25 => "comp", 
			Enum196.const_26 => "gray", 
			Enum196.const_27 => "inv", 
			_ => null, 
		};
	}

	[Attribute0(true)]
	private static void smethod_4(XmlTextWriter xmlTextWriter_0, string string_0, string string_1, string string_2)
	{
		xmlTextWriter_0.WriteStartElement(string_0 + ":" + string_1, null);
		xmlTextWriter_0.WriteAttributeString("val", string_2);
		xmlTextWriter_0.WriteEndElement();
	}
}
