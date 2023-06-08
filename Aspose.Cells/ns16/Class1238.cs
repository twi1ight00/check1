using System.Collections;
using System.Drawing;
using System.IO;
using System.Xml;
using Aspose.Cells;
using Aspose.Cells.Charts;
using Aspose.Cells.Drawing;
using ns21;
using ns22;
using ns25;
using ns44;
using ns7;

namespace ns16;

internal class Class1238
{
	private Class1547 class1547_0;

	private Chart chart_0;

	private ShapePropertyCollection shapePropertyCollection_0;

	private Hashtable hashtable_0;

	private Workbook workbook_0;

	internal Class1238(ShapePropertyCollection shapePropertyCollection_1, Class1548 class1548_0, Chart chart_1, Hashtable hashtable_1)
	{
		shapePropertyCollection_0 = shapePropertyCollection_1;
		chart_0 = chart_1;
		hashtable_0 = hashtable_1;
		class1547_0 = class1548_0.class1547_0;
		workbook_0 = class1547_0.workbook_0;
	}

	internal Class1238(Class1548 class1548_0, Hashtable hashtable_1)
	{
		hashtable_0 = hashtable_1;
		class1547_0 = class1548_0.class1547_0;
		workbook_0 = class1547_0.workbook_0;
	}

	internal void Read(XmlTextReader xmlTextReader_0, object object_0)
	{
		Area area = new Area(chart_0, object_0);
		shapePropertyCollection_0.method_13()?.method_27(Enum229.const_0);
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "noFill")
			{
				area.Formatting = FormattingType.None;
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "solidFill" && !xmlTextReader_0.IsEmptyElement)
			{
				Class923 @class = new Class923();
				InternalColor internalColor = smethod_0(xmlTextReader_0, @class);
				if (!internalColor.method_2())
				{
					area.FillFormat.Type = FillType.Solid;
					area.FillFormat.SolidFill.internalColor_0 = internalColor;
					object obj = @class.method_1(Enum230.const_10);
					if (obj != null)
					{
						area.FillFormat.SolidFill.method_1((int)obj);
					}
				}
			}
			else if (xmlTextReader_0.LocalName == "pattFill" && !xmlTextReader_0.IsEmptyElement)
			{
				method_24(xmlTextReader_0, area.FillFormat);
			}
			else if (xmlTextReader_0.LocalName == "gradFill" && !xmlTextReader_0.IsEmptyElement)
			{
				area.FillFormat.Type = FillType.Gradient;
				GradientFill gradientFill = area.FillFormat.GradientFill;
				method_20(xmlTextReader_0, gradientFill);
			}
			else if (xmlTextReader_0.LocalName == "blipFill" && !xmlTextReader_0.IsEmptyElement)
			{
				method_16(xmlTextReader_0, area.FillFormat);
			}
			else if (xmlTextReader_0.LocalName == "ln")
			{
				method_25(xmlTextReader_0, shapePropertyCollection_0.Line);
			}
			else if (xmlTextReader_0.LocalName == "scene3d")
			{
				method_10(xmlTextReader_0, shapePropertyCollection_0);
			}
			else if (xmlTextReader_0.LocalName == "sp3d")
			{
				method_8(xmlTextReader_0, shapePropertyCollection_0);
			}
			else if (xmlTextReader_0.LocalName == "effectLst" && !xmlTextReader_0.IsEmptyElement)
			{
				method_0(xmlTextReader_0, shapePropertyCollection_0);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
		if (area.Formatting != 0)
		{
			shapePropertyCollection_0.Area?.Copy(area);
		}
		shapePropertyCollection_0.method_6();
	}

	[Attribute0(true)]
	private void method_0(XmlTextReader xmlTextReader_0, ShapePropertyCollection shapePropertyCollection_1)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		Class1288 @class = shapePropertyCollection_1.method_5();
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "blur")
			{
				method_7(xmlTextReader_0, @class.method_1());
			}
			else if (xmlTextReader_0.LocalName == "glow")
			{
				method_6(xmlTextReader_0, @class.GlowEffect);
			}
			else if (xmlTextReader_0.LocalName == "innerShdw")
			{
				method_4(xmlTextReader_0, @class.method_6());
			}
			else if (xmlTextReader_0.LocalName == "outerShdw")
			{
				method_3(xmlTextReader_0, @class.method_8());
			}
			else if (xmlTextReader_0.LocalName == "prstShdw")
			{
				method_2(xmlTextReader_0, @class.method_10());
			}
			else if (xmlTextReader_0.LocalName == "reflection")
			{
				method_1(xmlTextReader_0, @class.method_12());
			}
			else if (xmlTextReader_0.LocalName == "softEdge")
			{
				string attribute = xmlTextReader_0.GetAttribute("rad");
				if (attribute != null)
				{
					@class.int_0 = Class1618.smethod_87(attribute);
				}
				xmlTextReader_0.Skip();
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	[Attribute0(true)]
	private void method_1(XmlTextReader xmlTextReader_0, Class1293 class1293_0)
	{
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				if (xmlTextReader_0.LocalName == "blurRad")
				{
					class1293_0.int_0 = Class1618.smethod_87(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "dist")
				{
					class1293_0.double_1 = Class1618.smethod_87(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "dir")
				{
					class1293_0.double_0 = Class1618.smethod_87(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "sx")
				{
					class1293_0.double_5 = Class1618.smethod_87(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "sy")
				{
					class1293_0.double_6 = Class1618.smethod_87(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "kx")
				{
					class1293_0.double_3 = Class1618.smethod_87(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "ky")
				{
					class1293_0.double_4 = Class1618.smethod_87(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "algn")
				{
					class1293_0.rectangleAlignmentType_0 = Class1618.smethod_193(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "rotWithShape")
				{
					class1293_0.bool_0 = ((!(xmlTextReader_0.Value == "0")) ? true : false);
				}
				else if (xmlTextReader_0.LocalName == "fadeDir")
				{
					class1293_0.double_2 = Class1618.smethod_87(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "stA")
				{
					class1293_0.int_3 = Class1618.smethod_87(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "stPos")
				{
					class1293_0.int_4 = Class1618.smethod_87(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "endA")
				{
					class1293_0.int_1 = Class1618.smethod_87(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "endPos")
				{
					class1293_0.int_2 = Class1618.smethod_87(xmlTextReader_0.Value);
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		xmlTextReader_0.Skip();
	}

	[Attribute0(true)]
	private void method_2(XmlTextReader xmlTextReader_0, Class1292 class1292_0)
	{
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				if (xmlTextReader_0.LocalName == "prst")
				{
					class1292_0.string_0 = xmlTextReader_0.Value;
				}
				else if (xmlTextReader_0.LocalName == "dist")
				{
					class1292_0.int_1 = Class1618.smethod_87(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "dir")
				{
					class1292_0.int_0 = Class1618.smethod_87(xmlTextReader_0.Value);
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		CellsColor cellsColor_ = method_5(xmlTextReader_0, class1292_0.Properties);
		class1292_0.method_1(cellsColor_);
	}

	[Attribute0(true)]
	private void method_3(XmlTextReader xmlTextReader_0, Class1291 class1291_0)
	{
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				if (xmlTextReader_0.LocalName == "blurRad")
				{
					class1291_0.int_0 = Class1618.smethod_87(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "dist")
				{
					class1291_0.int_2 = Class1618.smethod_87(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "dir")
				{
					class1291_0.int_1 = Class1618.smethod_87(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "sx")
				{
					class1291_0.int_5 = Class1618.smethod_87(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "sy")
				{
					class1291_0.int_6 = Class1618.smethod_87(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "kx")
				{
					class1291_0.int_3 = Class1618.smethod_87(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "ky")
				{
					class1291_0.int_4 = Class1618.smethod_87(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "algn")
				{
					class1291_0.rectangleAlignmentType_0 = Class1618.smethod_193(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "rotWithShape")
				{
					class1291_0.bool_0 = ((!(xmlTextReader_0.Value == "0")) ? true : false);
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		CellsColor cellsColor_ = method_5(xmlTextReader_0, class1291_0.Properties);
		class1291_0.method_1(cellsColor_);
	}

	[Attribute0(true)]
	private void method_4(XmlTextReader xmlTextReader_0, Class1289 class1289_0)
	{
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				if (xmlTextReader_0.LocalName == "blurRad")
				{
					class1289_0.int_0 = Class1618.smethod_87(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "dist")
				{
					class1289_0.int_2 = Class1618.smethod_87(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "dir")
				{
					class1289_0.int_1 = Class1618.smethod_87(xmlTextReader_0.Value);
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		CellsColor color = method_5(xmlTextReader_0, class1289_0.Properties);
		class1289_0.SetColor(color);
	}

	private CellsColor method_5(XmlTextReader xmlTextReader_0, Class923 class923_0)
	{
		InternalColor internalColor = smethod_0(xmlTextReader_0, class923_0);
		if (!internalColor.method_2())
		{
			CellsColor cellsColor = new CellsColor(workbook_0);
			cellsColor.internalColor_0 = internalColor;
			return cellsColor;
		}
		return null;
	}

	[Attribute0(true)]
	private void method_6(XmlTextReader xmlTextReader_0, GlowEffect glowEffect_0)
	{
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				if (xmlTextReader_0.LocalName == "rad")
				{
					glowEffect_0.int_0 = Class1618.smethod_87(xmlTextReader_0.Value);
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		CellsColor color = method_5(xmlTextReader_0, glowEffect_0.Properties);
		glowEffect_0.SetColor(color);
	}

	[Attribute0(true)]
	private void method_7(XmlTextReader xmlTextReader_0, Class1287 class1287_0)
	{
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				if (xmlTextReader_0.LocalName == "rad")
				{
					class1287_0.int_0 = Class1618.smethod_87(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "grow")
				{
					class1287_0.method_1((!(xmlTextReader_0.Value == "0")) ? true : false);
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		xmlTextReader_0.Skip();
	}

	[Attribute0(true)]
	private void method_8(XmlTextReader xmlTextReader_0, ShapePropertyCollection shapePropertyCollection_1)
	{
		Class1113 @class = shapePropertyCollection_1.method_1();
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				if (xmlTextReader_0.LocalName == "z")
				{
					@class.int_2 = Class1618.smethod_87(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "extrusionH")
				{
					@class.int_1 = Class1618.smethod_87(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "contourW")
				{
					@class.int_0 = Class1618.smethod_87(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "prstMaterial")
				{
					@class.method_5(Class1618.smethod_219(xmlTextReader_0.Value));
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "bevelT")
			{
				method_9(xmlTextReader_0, @class.TopBevel);
			}
			else if (xmlTextReader_0.LocalName == "bevelB")
			{
				method_9(xmlTextReader_0, @class.method_2());
			}
			else if (xmlTextReader_0.LocalName == "extrusionClr")
			{
				CellsColor cellsColor = new CellsColor(workbook_0);
				cellsColor.internalColor_0 = smethod_0(xmlTextReader_0, null);
				@class.method_9(cellsColor);
			}
			else if (xmlTextReader_0.LocalName == "contourClr")
			{
				CellsColor cellsColor2 = new CellsColor(workbook_0);
				cellsColor2.internalColor_0 = smethod_0(xmlTextReader_0, null);
				@class.method_7(cellsColor2);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	[Attribute0(true)]
	private void method_9(XmlTextReader xmlTextReader_0, Bevel bevel_0)
	{
		bevel_0.int_0 = 76200;
		bevel_0.int_1 = 76200;
		bevel_0.Type = BevelPresetType.Circle;
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				if (xmlTextReader_0.LocalName == "w")
				{
					bevel_0.int_0 = Class1618.smethod_87(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "h")
				{
					bevel_0.int_1 = Class1618.smethod_87(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "prst")
				{
					bevel_0.Type = Class1618.smethod_221(xmlTextReader_0.Value);
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		xmlTextReader_0.Skip();
	}

	[Attribute0(true)]
	private void method_10(XmlTextReader xmlTextReader_0, ShapePropertyCollection shapePropertyCollection_1)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		Class1295 class1295_ = shapePropertyCollection_1.method_3();
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "backdrop")
			{
				method_14(xmlTextReader_0, class1295_);
			}
			else if (xmlTextReader_0.LocalName == "camera")
			{
				method_12(xmlTextReader_0, class1295_);
			}
			else if (xmlTextReader_0.LocalName == "lightRig")
			{
				method_11(xmlTextReader_0, class1295_);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	[Attribute0(true)]
	private void method_11(XmlTextReader xmlTextReader_0, Class1295 class1295_0)
	{
		Class1290 @class = class1295_0.method_1();
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				if (xmlTextReader_0.LocalName == "rig")
				{
					@class.method_2(Class1618.smethod_215(xmlTextReader_0.Value));
				}
				else if (xmlTextReader_0.LocalName == "dir")
				{
					@class.method_4(Class1618.smethod_217(xmlTextReader_0.Value));
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.LocalName == "rot" && xmlTextReader_0.NodeType == XmlNodeType.Element)
			{
				method_13(xmlTextReader_0, @class.method_0());
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	[Attribute0(true)]
	private void method_12(XmlTextReader xmlTextReader_0, Class1295 class1295_0)
	{
		Class1296 @class = class1295_0.method_0();
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				if (xmlTextReader_0.LocalName == "fov")
				{
					@class.int_1 = Class1618.smethod_87(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "prst")
				{
					@class.method_1(Class1618.smethod_213(xmlTextReader_0.Value));
				}
				else if (xmlTextReader_0.LocalName == "zoom")
				{
					@class.int_0 = Class1618.smethod_87(xmlTextReader_0.Value);
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.LocalName == "rot" && xmlTextReader_0.NodeType == XmlNodeType.Element)
			{
				method_13(xmlTextReader_0, @class.method_2());
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	[Attribute0(true)]
	private void method_13(XmlTextReader xmlTextReader_0, Class1294 class1294_0)
	{
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				if (xmlTextReader_0.LocalName == "lat")
				{
					class1294_0.int_0 = Class1618.smethod_87(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "lon")
				{
					class1294_0.int_1 = Class1618.smethod_87(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "rev")
				{
					class1294_0.int_2 = Class1618.smethod_87(xmlTextReader_0.Value);
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		xmlTextReader_0.Skip();
	}

	[Attribute0(true)]
	private void method_14(XmlTextReader xmlTextReader_0, Class1295 class1295_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		Class1286 @class = class1295_0.method_3();
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "anchor")
			{
				method_15(xmlTextReader_0, @class.class1112_0);
			}
			else if (xmlTextReader_0.LocalName == "norm")
			{
				method_15(xmlTextReader_0, @class.class1112_1);
			}
			else if (xmlTextReader_0.LocalName == "up")
			{
				method_15(xmlTextReader_0, @class.class1112_2);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	[Attribute0(true)]
	private void method_15(XmlTextReader xmlTextReader_0, Class1112 class1112_0)
	{
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				if (xmlTextReader_0.LocalName == "dx")
				{
					class1112_0.int_0 = Class1618.smethod_87(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "dy")
				{
					class1112_0.int_1 = Class1618.smethod_87(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "dz")
				{
					class1112_0.int_2 = Class1618.smethod_87(xmlTextReader_0.Value);
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		xmlTextReader_0.Skip();
	}

	internal void method_16(XmlTextReader xmlTextReader_0, FillFormat fillFormat_0)
	{
		fillFormat_0.Type = FillType.Texture;
		TextureFill textureFill = fillFormat_0.TextureFill;
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "blip")
			{
				method_18(xmlTextReader_0, textureFill);
			}
			else if (xmlTextReader_0.LocalName == "stretch")
			{
				method_19(xmlTextReader_0, textureFill);
			}
			else if (xmlTextReader_0.LocalName == "tile")
			{
				method_17(xmlTextReader_0, textureFill);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	[Attribute0(true)]
	private void method_17(XmlTextReader xmlTextReader_0, TextureFill textureFill_0)
	{
		textureFill_0.TilePicOption = new TilePicOption();
		if (xmlTextReader_0.HasAttributes)
		{
			TilePicOption tilePicOption = textureFill_0.TilePicOption;
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				if (xmlTextReader_0.LocalName == "tx")
				{
					tilePicOption.OffsetX = Class1618.smethod_85(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "ty")
				{
					tilePicOption.OffsetY = Class1618.smethod_85(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "sx")
				{
					tilePicOption.ScaleX = Class1618.smethod_85(xmlTextReader_0.Value) / 1000.0;
				}
				else if (xmlTextReader_0.LocalName == "sy")
				{
					tilePicOption.ScaleY = Class1618.smethod_85(xmlTextReader_0.Value) / 1000.0;
				}
				else if (xmlTextReader_0.LocalName == "flip")
				{
					tilePicOption.MirrorType = Class1618.smethod_191(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "algn")
				{
					tilePicOption.AlignmentType = Class1618.smethod_193(xmlTextReader_0.Value);
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		xmlTextReader_0.Skip();
	}

	private void method_18(XmlTextReader xmlTextReader_0, TextureFill textureFill_0)
	{
		if (class1547_0 == null)
		{
			xmlTextReader_0.Skip();
			return;
		}
		string attribute = xmlTextReader_0.GetAttribute("embed", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
		if (attribute == null)
		{
			xmlTextReader_0.Skip();
			return;
		}
		if (hashtable_0 != null)
		{
			object obj = hashtable_0[attribute];
			if (obj != null)
			{
				Class1564 @class = (Class1564)obj;
				string string_ = "xl/" + @class.string_3.Substring(3);
				Class746 class746_ = class1547_0.workbook_0.class1558_0.class1553_0.class746_0;
				Class744 class2 = class746_.method_38(string_);
				Stream stream = class746_.method_39(class2);
				byte[] array = new byte[(int)class2.Size];
				stream.Read(array, 0, (int)class2.Size);
				textureFill_0.ImageData = array;
				class1547_0.workbook_0.class1558_0.arrayList_2.Add(Path.GetFileName(@class.string_3));
			}
		}
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "alphaModFix")
			{
				string attribute2 = xmlTextReader_0.GetAttribute("amt");
				xmlTextReader_0.Skip();
				if (attribute2 != null)
				{
					textureFill_0.method_7(Class1618.smethod_87(attribute2));
				}
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	[Attribute0(true)]
	private void method_19(XmlTextReader xmlTextReader_0, TextureFill textureFill_0)
	{
		textureFill_0.PicFormatOption = new PicFormatOption();
		PicFormatOption picFormatOption = textureFill_0.PicFormatOption;
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "fillRect")
			{
				string attribute = xmlTextReader_0.GetAttribute("1");
				string attribute2 = xmlTextReader_0.GetAttribute("t");
				string attribute3 = xmlTextReader_0.GetAttribute("r");
				string attribute4 = xmlTextReader_0.GetAttribute("b");
				xmlTextReader_0.Skip();
				if (attribute != null)
				{
					picFormatOption.Left = Class1618.smethod_87(attribute);
				}
				if (attribute2 != null)
				{
					picFormatOption.Top = Class1618.smethod_87(attribute2);
				}
				if (attribute3 != null)
				{
					picFormatOption.Right = Class1618.smethod_87(attribute3);
				}
				if (attribute4 != null)
				{
					picFormatOption.Bottom = Class1618.smethod_87(attribute4);
				}
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	[Attribute0(true)]
	internal void method_20(XmlTextReader xmlTextReader_0, GradientFill gradientFill_0)
	{
		string attribute = xmlTextReader_0.GetAttribute("rotWithShape");
		if (attribute != null)
		{
			gradientFill_0.bool_0 = ((attribute == "1") ? true : false);
		}
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "gsLst" && !xmlTextReader_0.IsEmptyElement)
			{
				method_23(xmlTextReader_0, gradientFill_0);
			}
			else if (xmlTextReader_0.LocalName == "lin")
			{
				gradientFill_0.object_0 = new Class925();
				Class925 @class = gradientFill_0.method_1();
				string attribute2 = xmlTextReader_0.GetAttribute("ang");
				if (attribute2 != null)
				{
					@class.int_0 = Class1618.smethod_87(attribute2);
				}
				string attribute3 = xmlTextReader_0.GetAttribute("scaled");
				if (attribute3 == "1")
				{
					@class.bool_0 = true;
				}
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "path")
			{
				gradientFill_0.object_0 = new Class926();
				method_21(xmlTextReader_0, gradientFill_0);
			}
			else if (xmlTextReader_0.LocalName == "tileRect")
			{
				method_22(xmlTextReader_0, gradientFill_0.method_3());
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	[Attribute0(true)]
	private void method_21(XmlTextReader xmlTextReader_0, GradientFill gradientFill_0)
	{
		Class926 @class = gradientFill_0.method_2();
		string attribute = xmlTextReader_0.GetAttribute("path");
		if (attribute != null)
		{
			@class.enum128_0 = Class1618.smethod_187(attribute);
		}
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "fillToRect")
			{
				method_22(xmlTextReader_0, @class);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	private void method_22(XmlTextReader xmlTextReader_0, Class926 class926_0)
	{
		string attribute = xmlTextReader_0.GetAttribute("l");
		string attribute2 = xmlTextReader_0.GetAttribute("t");
		string attribute3 = xmlTextReader_0.GetAttribute("r");
		string attribute4 = xmlTextReader_0.GetAttribute("b");
		xmlTextReader_0.Skip();
		if (attribute != null)
		{
			class926_0.int_0 = Class1618.smethod_87(attribute);
		}
		if (attribute2 != null)
		{
			class926_0.int_1 = Class1618.smethod_87(attribute2);
		}
		if (attribute3 != null)
		{
			class926_0.int_3 = Class1618.smethod_87(attribute3);
		}
		if (attribute4 != null)
		{
			class926_0.int_2 = Class1618.smethod_87(attribute4);
		}
	}

	[Attribute0(true)]
	private void method_23(XmlTextReader xmlTextReader_0, GradientFill gradientFill_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "gs")
			{
				GradientStop gradientStop = new GradientStop(gradientFill_0.GradientStops);
				string attribute = xmlTextReader_0.GetAttribute("pos");
				if (attribute != null)
				{
					gradientStop.Position = (double)Class1618.smethod_87(attribute) / 1000.0;
				}
				Class923 @class = new Class923();
				gradientStop.internalColor_0 = smethod_0(xmlTextReader_0, @class);
				object obj = @class.method_1(Enum230.const_10);
				if (obj != null)
				{
					gradientStop.method_1((int)obj);
				}
				gradientFill_0.GradientStops.Add(gradientStop);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	[Attribute0(true)]
	internal void method_24(XmlTextReader xmlTextReader_0, FillFormat fillFormat_0)
	{
		fillFormat_0.Type = FillType.Pattern;
		string attribute = xmlTextReader_0.GetAttribute("prst");
		PatternFill patternFill = fillFormat_0.PatternFill;
		if (attribute != null)
		{
			patternFill.Pattern = Class1618.smethod_133(attribute);
		}
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "fgClr" && !xmlTextReader_0.IsEmptyElement)
			{
				Class923 @class = new Class923();
				patternFill.internalColor_1 = smethod_0(xmlTextReader_0, @class);
				object obj = @class.method_1(Enum230.const_10);
				if (obj != null)
				{
					patternFill.method_1((int)obj / 1000);
				}
			}
			else if (xmlTextReader_0.LocalName == "bgClr" && !xmlTextReader_0.IsEmptyElement)
			{
				Class923 class2 = new Class923();
				patternFill.internalColor_0 = smethod_0(xmlTextReader_0, class2);
				object obj2 = class2.method_1(Enum230.const_10);
				if (obj2 != null)
				{
					patternFill.method_5((int)obj2 / 1000);
				}
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	[Attribute0(true)]
	private void method_25(XmlTextReader xmlTextReader_0, Line line_0)
	{
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				if (xmlTextReader_0.LocalName == "w")
				{
					line_0.WeightPt = Class1618.smethod_49(Class1618.smethod_87(xmlTextReader_0.Value));
				}
				else if (xmlTextReader_0.LocalName == "cap")
				{
					line_0.method_6(Class1618.smethod_163(xmlTextReader_0.Value));
				}
				else if (xmlTextReader_0.LocalName == "cmpd")
				{
					line_0.method_2(Class1618.smethod_165(xmlTextReader_0.Value));
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "noFill")
			{
				line_0.method_27(Enum229.const_2);
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "solidFill" && !xmlTextReader_0.IsEmptyElement)
			{
				line_0.method_27(Enum229.const_1);
				line_0.internalColor_0 = smethod_0(xmlTextReader_0, line_0.Properties);
				line_0.method_30(bool_0: true);
			}
			else if (xmlTextReader_0.LocalName == "gradFill" && !xmlTextReader_0.IsEmptyElement)
			{
				line_0.method_27(Enum229.const_3);
				method_20(xmlTextReader_0, line_0.GradientFill);
				line_0.method_30(bool_0: true);
			}
			else if (xmlTextReader_0.LocalName == "pattFill")
			{
				line_0.method_27(Enum229.const_1);
				switch (xmlTextReader_0.GetAttribute("prst"))
				{
				case "pct75":
					line_0.method_25(LineType.DarkGray);
					break;
				case "pct50":
					line_0.method_25(LineType.MediumGray);
					break;
				case "pct25":
					line_0.method_25(LineType.LightGray);
					break;
				default:
					line_0.method_25(LineType.Solid);
					break;
				}
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "prstDash")
			{
				string text = smethod_2(xmlTextReader_0);
				if (text != null)
				{
					line_0.method_4(Class1618.smethod_59(text));
				}
			}
			else if (xmlTextReader_0.LocalName == "miter")
			{
				line_0.method_8(Enum232.const_2);
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "round")
			{
				line_0.method_8(Enum232.const_0);
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "bevel")
			{
				line_0.method_8(Enum232.const_1);
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "headEnd")
			{
				method_26(xmlTextReader_0, line_0, bool_0: true);
			}
			else if (xmlTextReader_0.LocalName == "tailEnd")
			{
				method_26(xmlTextReader_0, line_0, bool_0: false);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	[Attribute0(true)]
	private void method_26(XmlTextReader xmlTextReader_0, Line line_0, bool bool_0)
	{
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				if (xmlTextReader_0.LocalName == "len")
				{
					if (bool_0)
					{
						line_0.method_14(Class1618.smethod_166(xmlTextReader_0.Value));
					}
					else
					{
						line_0.method_16(Class1618.smethod_166(xmlTextReader_0.Value));
					}
				}
				else if (xmlTextReader_0.LocalName == "type")
				{
					if (bool_0)
					{
						line_0.method_10(Class1618.smethod_168(xmlTextReader_0.Value));
					}
					else
					{
						line_0.method_12(Class1618.smethod_168(xmlTextReader_0.Value));
					}
				}
				else if (xmlTextReader_0.LocalName == "w")
				{
					if (bool_0)
					{
						line_0.method_18(Class1618.smethod_170(xmlTextReader_0.Value));
					}
					else
					{
						line_0.method_20(Class1618.smethod_170(xmlTextReader_0.Value));
					}
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		xmlTextReader_0.Skip();
	}

	[Attribute0(true)]
	internal static InternalColor smethod_0(XmlTextReader xmlTextReader_0, Class923 class923_0)
	{
		InternalColor internalColor = new InternalColor(bool_0: true);
		xmlTextReader_0.Read();
		while (Class536.smethod_4(xmlTextReader_0))
		{
			if (xmlTextReader_0.LocalName == "srgbClr")
			{
				string attribute = xmlTextReader_0.GetAttribute("val");
				if (attribute != null)
				{
					internalColor.SetColor(ColorType.RGB, Class1618.smethod_63(attribute).ToArgb());
				}
				smethod_1(xmlTextReader_0, internalColor);
			}
			else if (xmlTextReader_0.LocalName == "scrgbClr")
			{
				string attribute2 = xmlTextReader_0.GetAttribute("r");
				string attribute3 = xmlTextReader_0.GetAttribute("g");
				string attribute4 = xmlTextReader_0.GetAttribute("b");
				if (attribute2 != null && attribute3 != null && attribute4 != null)
				{
					try
					{
						int red = Class1336.smethod_18((double)Class1618.smethod_87(attribute2) / 100000.0);
						int green = Class1336.smethod_18((double)Class1618.smethod_87(attribute3) / 100000.0);
						int blue = Class1336.smethod_18((double)Class1618.smethod_87(attribute4) / 100000.0);
						internalColor.SetColor(ColorType.RGB, Color.FromArgb(red, green, blue).ToArgb());
					}
					catch
					{
					}
				}
				smethod_1(xmlTextReader_0, internalColor);
			}
			else if (xmlTextReader_0.LocalName == "schemeClr")
			{
				string attribute5 = xmlTextReader_0.GetAttribute("val");
				if (attribute5 != null)
				{
					int int_ = Class1618.smethod_159(attribute5);
					internalColor.SetColor(ColorType.Theme, int_);
				}
				smethod_1(xmlTextReader_0, internalColor);
			}
			else if (xmlTextReader_0.LocalName == "sysClr")
			{
				string attribute6 = xmlTextReader_0.GetAttribute("val");
				string text = xmlTextReader_0.GetAttribute("lastClr");
				if (text == null)
				{
					if (attribute6.Equals("window"))
					{
						text = "ffffff";
					}
					else if (attribute6.Equals("windowText"))
					{
						text = "000000";
					}
				}
				if (text != null)
				{
					internalColor.SetColor(ColorType.RGB, Class1618.smethod_63(text).ToArgb());
				}
				smethod_1(xmlTextReader_0, internalColor);
			}
			else if (xmlTextReader_0.LocalName == "prstClr")
			{
				string attribute7 = xmlTextReader_0.GetAttribute("val");
				if (attribute7 != null)
				{
					internalColor.SetColor(ColorType.RGB, Class1618.smethod_223(attribute7).ToArgb());
				}
				smethod_1(xmlTextReader_0, internalColor);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		if (class923_0 != null && internalColor.method_17() != null)
		{
			foreach (Class1331 item in internalColor.method_18())
			{
				if (item.enum196_0 == Enum196.const_2)
				{
					class923_0.method_0(Enum230.const_10, item.int_0);
				}
			}
		}
		return internalColor;
	}

	[Attribute0(true)]
	private static void smethod_1(XmlTextReader xmlTextReader_0, InternalColor internalColor_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		Class1332 @class = internalColor_0.method_18();
		internalColor_0.IsShapeColor = true;
		xmlTextReader_0.Read();
		while (Class536.smethod_4(xmlTextReader_0))
		{
			if (xmlTextReader_0.LocalName == "alpha")
			{
				string string_ = smethod_2(xmlTextReader_0);
				@class.method_0(Enum196.const_2, Class1618.smethod_87(string_));
			}
			else if (xmlTextReader_0.LocalName == "alphaMod")
			{
				string string_2 = smethod_2(xmlTextReader_0);
				@class.method_0(Enum196.const_3, Class1618.smethod_87(string_2));
			}
			else if (xmlTextReader_0.LocalName == "alphaOff")
			{
				string string_3 = smethod_2(xmlTextReader_0);
				@class.method_0(Enum196.const_4, Class1618.smethod_87(string_3));
			}
			else if (xmlTextReader_0.LocalName == "red")
			{
				string string_4 = smethod_2(xmlTextReader_0);
				@class.method_0(Enum196.const_5, Class1618.smethod_87(string_4));
			}
			else if (xmlTextReader_0.LocalName == "redMod")
			{
				string string_5 = smethod_2(xmlTextReader_0);
				@class.method_0(Enum196.const_6, Class1618.smethod_87(string_5));
			}
			else if (xmlTextReader_0.LocalName == "redOff")
			{
				string string_6 = smethod_2(xmlTextReader_0);
				@class.method_0(Enum196.const_7, Class1618.smethod_87(string_6));
			}
			else if (xmlTextReader_0.LocalName == "green")
			{
				string string_7 = smethod_2(xmlTextReader_0);
				@class.method_0(Enum196.const_8, Class1618.smethod_87(string_7));
			}
			else if (xmlTextReader_0.LocalName == "greenMod")
			{
				string string_8 = smethod_2(xmlTextReader_0);
				@class.method_0(Enum196.const_9, Class1618.smethod_87(string_8));
			}
			else if (xmlTextReader_0.LocalName == "greenOff")
			{
				string string_9 = smethod_2(xmlTextReader_0);
				@class.method_0(Enum196.const_10, Class1618.smethod_87(string_9));
			}
			else if (xmlTextReader_0.LocalName == "blue")
			{
				string string_10 = smethod_2(xmlTextReader_0);
				@class.method_0(Enum196.const_11, Class1618.smethod_87(string_10));
			}
			else if (xmlTextReader_0.LocalName == "blueMod")
			{
				string string_11 = smethod_2(xmlTextReader_0);
				@class.method_0(Enum196.const_12, Class1618.smethod_87(string_11));
			}
			else if (xmlTextReader_0.LocalName == "blueOff")
			{
				string string_12 = smethod_2(xmlTextReader_0);
				@class.method_0(Enum196.const_13, Class1618.smethod_87(string_12));
			}
			else if (xmlTextReader_0.LocalName == "hue")
			{
				string string_13 = smethod_2(xmlTextReader_0);
				@class.method_0(Enum196.const_14, Class1618.smethod_87(string_13));
			}
			else if (xmlTextReader_0.LocalName == "hueMod")
			{
				string string_14 = smethod_2(xmlTextReader_0);
				@class.method_0(Enum196.const_15, Class1618.smethod_87(string_14));
			}
			else if (xmlTextReader_0.LocalName == "hueOff")
			{
				string string_15 = smethod_2(xmlTextReader_0);
				@class.method_0(Enum196.const_16, Class1618.smethod_87(string_15));
			}
			else if (xmlTextReader_0.LocalName == "sat")
			{
				string string_16 = smethod_2(xmlTextReader_0);
				@class.method_0(Enum196.const_17, Class1618.smethod_87(string_16));
			}
			else if (xmlTextReader_0.LocalName == "satMod")
			{
				string string_17 = smethod_2(xmlTextReader_0);
				@class.method_0(Enum196.const_18, Class1618.smethod_87(string_17));
			}
			else if (xmlTextReader_0.LocalName == "satOff")
			{
				string string_18 = smethod_2(xmlTextReader_0);
				@class.method_0(Enum196.const_19, Class1618.smethod_87(string_18));
			}
			else if (xmlTextReader_0.LocalName == "lum")
			{
				string string_19 = smethod_2(xmlTextReader_0);
				@class.method_0(Enum196.const_20, Class1618.smethod_87(string_19));
			}
			else if (xmlTextReader_0.LocalName == "lumMod")
			{
				string string_20 = smethod_2(xmlTextReader_0);
				@class.method_0(Enum196.const_21, Class1618.smethod_87(string_20));
			}
			else if (xmlTextReader_0.LocalName == "lumOff")
			{
				string string_21 = smethod_2(xmlTextReader_0);
				@class.method_0(Enum196.const_22, Class1618.smethod_87(string_21));
			}
			else if (xmlTextReader_0.LocalName == "shade")
			{
				string string_22 = smethod_2(xmlTextReader_0);
				@class.method_0(Enum196.const_1, Class1618.smethod_87(string_22));
			}
			else if (xmlTextReader_0.LocalName == "tint")
			{
				string string_23 = smethod_2(xmlTextReader_0);
				@class.method_0(Enum196.const_0, Class1618.smethod_87(string_23));
			}
			else if (xmlTextReader_0.LocalName == "comp")
			{
				smethod_2(xmlTextReader_0);
				@class.method_0(Enum196.const_25, 0);
			}
			else if (xmlTextReader_0.LocalName == "inv")
			{
				smethod_2(xmlTextReader_0);
				@class.method_0(Enum196.const_27, 0);
			}
			else if (xmlTextReader_0.LocalName == "gamma")
			{
				smethod_2(xmlTextReader_0);
				@class.method_0(Enum196.const_23, 0);
			}
			else if (xmlTextReader_0.LocalName == "invGamma")
			{
				smethod_2(xmlTextReader_0);
				@class.method_0(Enum196.const_24, 0);
			}
			else if (xmlTextReader_0.LocalName == "gray")
			{
				smethod_2(xmlTextReader_0);
				@class.method_0(Enum196.const_26, 0);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
	}

	private static string smethod_2(XmlTextReader xmlTextReader_0)
	{
		string attribute = xmlTextReader_0.GetAttribute("val");
		xmlTextReader_0.Skip();
		return attribute;
	}
}
