using System;
using System.Collections.Generic;
using System.Drawing;
using System.Xml;
using Aspose.Slides;
using ns16;
using ns224;
using ns26;
using ns53;
using ns56;
using ns7;

namespace ns18;

internal class Class1203 : Class1188
{
	internal void method_5(Class290 smartArtUnsupported, Class1030 slideDeserializationContext)
	{
		method_0();
		while (base.XmlPartReader.Read())
		{
			if (base.XmlPartReader.NodeType != XmlNodeType.Element || !(base.XmlPartReader.LocalName == "drawing"))
			{
				continue;
			}
			Class2192 drawingElementData = new Class2192(base.XmlPartReader);
			smartArtUnsupported.DrawingElementData = drawingElementData;
			List<uint> list = new List<uint>();
			Class2605[] shapeList = smartArtUnsupported.DrawingElementData.SpTree.ShapeList;
			Class2605[] array = shapeList;
			foreach (Class2605 @class in array)
			{
				if (!(@class.Name == "sp"))
				{
					continue;
				}
				Class2011 class2 = (Class2011)@class.Object;
				uint id = class2.NvSpPr.CNvPr.Id;
				if (id != 0)
				{
					if (list.Contains(id))
					{
						class2.NvSpPr.CNvPr.Id = 0u;
					}
					else
					{
						list.Add(id);
					}
				}
			}
			Class961.smethod_0(smartArtUnsupported.ShapesRoot, smartArtUnsupported.DrawingElementData.SpTree, slideDeserializationContext);
			foreach (Shape shape in smartArtUnsupported.ShapesRoot.Shapes)
			{
				if (!(shape is AutoShape autoShape) || autoShape.PPTXUnsupportedProps.TxXfrm == null)
				{
					continue;
				}
				Class154 rawFrameImpl = autoShape.RawFrameImpl;
				if (!double.IsNaN(rawFrameImpl.Rotation))
				{
					bool flag = true;
					DocumentProperties documentProperties = (DocumentProperties)slideDeserializationContext.DeserializationContext.Presentation.DocumentProperties;
					string[] array2 = documentProperties.string_15.Split('.');
					if (array2.Length > 0 && int.TryParse(array2[0], out var result))
					{
						flag = result > 12;
					}
					if (!flag)
					{
						Class154 class3 = new Class154();
						Class1021.smethod_1(class3, autoShape.PPTXUnsupportedProps.TxXfrm);
						RectangleF rect = autoShape.Geometry.method_0(autoShape, (float)rawFrameImpl.X, (float)rawFrameImpl.Y, (float)rawFrameImpl.Width, (float)rawFrameImpl.Height);
						Class6002 class4 = new Class6002();
						class4.method_14(class3.Rotation, new PointF((float)(class3.X + class3.Width / 2.0), (float)(class3.Y + class3.Height / 2.0)));
						rect = class4.method_4(rect);
						autoShape.PPTXUnsupportedProps.TxXfrm.Ext.Cy = Math.Abs(rect.Height);
						autoShape.PPTXUnsupportedProps.TxXfrm.Ext.Cx = Math.Abs(rect.Width);
						autoShape.PPTXUnsupportedProps.TxXfrm.Off.X = rect.X + Math.Min(rect.Width, 0f);
						autoShape.PPTXUnsupportedProps.TxXfrm.Off.Y = rect.Y + Math.Min(rect.Height, 0f);
						autoShape.PPTXUnsupportedProps.TxXfrm.Rot = (double.IsNaN(class3.Rotation) ? 0f : (0f - class3.Rotation));
					}
				}
			}
		}
		method_2();
	}

	internal void method_6(Class290 smartArtUnsupported, Class1031 slideSerializationContext)
	{
		method_3();
		Class2192 @class = new Class2192();
		Class961.smethod_3(smartArtUnsupported.ShapesRoot, @class.SpTree, slideSerializationContext, null);
		@class.vmethod_4(null, base.XmlPartWriter, "drawing");
		method_4();
	}

	public Class1203(Class1342 part, Class1341 deserializationContext)
		: base(part, deserializationContext)
	{
	}

	public Class1203(Class1342 part, Class1346 serializationContext)
		: base(part, serializationContext)
	{
	}
}
