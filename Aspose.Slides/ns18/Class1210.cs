using System;
using System.Xml;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Warnings;
using ns16;
using ns53;
using ns56;
using ns7;

namespace ns18;

internal class Class1210 : Class1188
{
	internal void method_5(IChart chart, Class1030 slideDeserializationContext)
	{
		method_0();
		while (base.XmlPartReader.Read())
		{
			if (base.XmlPartReader.NodeType != XmlNodeType.Element || !(base.XmlPartReader.LocalName == "userShapes"))
			{
				continue;
			}
			Class2320 @class = new Class2320(base.XmlPartReader);
			IGroupShape userShapes = chart.UserShapes;
			Class2605[] anchorList = @class.AnchorList;
			foreach (Class2605 class2 in anchorList)
			{
				Class2605 shape;
				float num;
				float num2;
				float num3;
				float num4;
				switch (class2.Name)
				{
				case "absSizeAnchor":
				{
					Class1982 class4 = (Class1982)class2.Object;
					shape = class4.Shape;
					num = (float)((double)chart.Width * 0.7);
					num2 = (float)((double)chart.Height * 0.5);
					num3 = (float)((double)chart.Width * 0.1) - num;
					num4 = (float)((double)chart.Height * 0.5) - num2;
					slideDeserializationContext.DeserializationContext.method_4("Chart UserShapes shapeX, shapeY, shapeWidth, shapeHeight loading is not implemented yet for absSizeAnchor case.", WarningType.MajorFormattingLoss);
					goto IL_0184;
				}
				case "relSizeAnchor":
				{
					Class2010 class3 = (Class2010)class2.Object;
					shape = class3.Shape;
					num = (float)((double)chart.Width * class3.From.X);
					num2 = (float)((double)chart.Height * class3.From.Y);
					num3 = (float)((double)chart.Width * class3.To.X) - num;
					num4 = (float)((double)chart.Height * class3.To.Y) - num2;
					goto IL_0184;
				}
				default:
					{
						throw new Exception("Unknown element \"" + class2.Name + "\"");
					}
					IL_0184:
					switch (shape.Name)
					{
					case "graphicFrame":
						slideDeserializationContext.DeserializationContext.method_4("graphicFrame Chart UserShapes loading is not implemented yet.", WarningType.DataLoss);
						break;
					case "pic":
					{
						Class2004 picElementData = (Class2004)shape.Object;
						PictureFrame pictureFrame = (PictureFrame)userShapes.Shapes.AddPictureFrame(ShapeType.NotDefined, 0f, 0f, 0f, 0f, null);
						Class983.smethod_3(pictureFrame);
						Class976.smethod_0(pictureFrame, picElementData, slideDeserializationContext);
						Class154 rawFrameImpl = pictureFrame.RawFrameImpl;
						rawFrameImpl.vmethod_0(num, num2, num3, num4);
						break;
					}
					case "cxnSp":
					{
						Class1983 connectorElementData = (Class1983)shape.Object;
						Connector connector = (Connector)userShapes.Shapes.AddConnector(ShapeType.Line, 0f, 0f, 0f, 0f, createFromTemplate: false);
						Class983.smethod_3(connector);
						Class934.smethod_0(connector, connectorElementData, slideDeserializationContext);
						Class154 rawFrameImpl = connector.RawFrameImpl;
						rawFrameImpl.method_0(num, num2, num3, num4, (num4 > num3) ? (rawFrameImpl.Rotation -= 90f) : rawFrameImpl.Rotation);
						break;
					}
					case "grpSp":
					{
						Class1996 groupShapeElementData = (Class1996)shape.Object;
						IGroupShape groupShape = ((ShapeCollection)userShapes.Shapes).AddGroupShape();
						Class961.smethod_0(groupShape, groupShapeElementData, slideDeserializationContext);
						break;
					}
					case "sp":
					{
						Class2011 shapeElementData = (Class2011)shape.Object;
						IAutoShape autoShape = userShapes.Shapes.AddAutoShape(ShapeType.NotDefined, 0f, 0f, 0f, 0f, createFromTemplate: false);
						Class983.smethod_3(autoShape);
						Class895.smethod_0(autoShape, shapeElementData, slideDeserializationContext);
						Class154 rawFrameImpl = ((Shape)autoShape).RawFrameImpl;
						rawFrameImpl.vmethod_0(num, num2, num3, num4);
						if (float.IsNaN(autoShape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight))
						{
							autoShape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 11f;
						}
						if (autoShape.ShapeStyle != null)
						{
							break;
						}
						foreach (Paragraph paragraph in ((AutoShape)autoShape).TextFrame.Paragraphs)
						{
							if (paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType == FillType.NotDefined)
							{
								paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
							}
						}
						break;
					}
					default:
						throw new Exception("Unknown element \"" + shape.Name + "\"");
					}
					break;
				}
			}
		}
		method_2();
	}

	internal void method_6(IChart chart, Class882 chartPartSerializationContext)
	{
		method_3();
		Class2320 @class = new Class2320();
		IGroupShape userShapes = chart.UserShapes;
		Class1346 serializationContext = chartPartSerializationContext.SlideSerializationContext.SerializationContext;
		foreach (Shape shape in userShapes.Shapes)
		{
			Class2010 class2 = (Class2010)@class.delegate2773_0("relSizeAnchor").Object;
			double x = shape.RawFrameImpl.X;
			double y = shape.RawFrameImpl.Y;
			double width = shape.RawFrameImpl.Width;
			double height = shape.RawFrameImpl.Height;
			class2.From.X = x / (double)chart.Width;
			class2.From.Y = y / (double)chart.Height;
			class2.To.X = (x + width) / (double)chart.Width;
			class2.To.Y = (y + height) / (double)chart.Height;
			if (shape is IAutoShape)
			{
				Class2011 shapeElementData = (Class2011)class2.delegate2773_0("sp").Object;
				IAutoShape autoShape = (IAutoShape)shape;
				if (autoShape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight == 11f)
				{
					autoShape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = float.NaN;
				}
				Class895.smethod_1(autoShape, shapeElementData, chartPartSerializationContext.SlideSerializationContext, chartPartSerializationContext);
			}
			else if (shape is IGroupShape)
			{
				Class1996 groupShapeElementData = (Class1996)class2.delegate2773_0("grpSp").Object;
				Class961.smethod_3((IGroupShape)shape, groupShapeElementData, chartPartSerializationContext.SlideSerializationContext, chartPartSerializationContext);
			}
			else if (shape is IConnector)
			{
				Class1984 connectorElementData = (Class1984)class2.delegate2773_0("cxnSp").Object;
				Class934.smethod_1((IConnector)shape, connectorElementData, serializationContext);
			}
			else
			{
				if (!(shape is IPictureFrame))
				{
					throw new NotImplementedException();
				}
				Class2005 picElementData = (Class2005)class2.delegate2773_0("pic").Object;
				Class976.smethod_2((IPictureFrame)shape, picElementData, serializationContext);
			}
		}
		@class.vmethod_4(null, base.XmlPartWriter, "userShapes");
		method_4();
	}

	public Class1210(Class1342 part, Class1341 deserializationContext)
		: base(part, deserializationContext)
	{
	}

	public Class1210(Class1342 part, Class1346 serializationContext)
		: base(part, serializationContext)
	{
	}
}
