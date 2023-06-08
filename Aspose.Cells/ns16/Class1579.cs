using System;
using System.Collections;
using System.Xml;
using Aspose.Cells;
using Aspose.Cells.Charts;
using Aspose.Cells.Drawing;
using ns22;

namespace ns16;

internal class Class1579
{
	private Class1541 class1541_0;

	private Chart chart_0;

	private bool bool_0;

	private Class1358 class1358_0;

	private XmlDocument xmlDocument_0;

	internal Class1579(Class1358 class1358_1)
	{
		class1358_0 = class1358_1;
		if (class1358_0.chart_0 != null)
		{
			bool_0 = true;
			chart_0 = class1358_1.chart_0;
		}
		else
		{
			class1541_0 = class1358_1.class1541_0;
		}
		method_2();
	}

	internal void Write(XmlTextWriter xmlTextWriter_0)
	{
		method_6(xmlTextWriter_0);
		method_0(xmlTextWriter_0);
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndDocument();
		xmlTextWriter_0.Flush();
	}

	private void method_0(XmlTextWriter xmlTextWriter_0)
	{
		if (!bool_0 && class1541_0.worksheet_0.Type == SheetType.Chart)
		{
			method_4(class1541_0.worksheet_0.Charts[0].ChartObject, xmlTextWriter_0);
		}
		else
		{
			if (class1358_0.shape_0 == null || class1358_0.shape_0.Length == 0)
			{
				return;
			}
			Shape[] shape_ = class1358_0.shape_0;
			foreach (Shape shape in shape_)
			{
				if (shape == null)
				{
					continue;
				}
				if (!Class1618.smethod_233(shape) && (shape.MsoDrawingType == MsoDrawingType.Group || shape.AutoShapeType != 0))
				{
					switch (shape.MsoDrawingType)
					{
					default:
						AddShape(shape, xmlTextWriter_0);
						break;
					case MsoDrawingType.Unknown:
					case MsoDrawingType.CellsDrawing:
						if (Class1618.smethod_235(shape.AutoShapeType))
						{
							method_3(shape, xmlTextWriter_0);
						}
						else
						{
							method_1(shape, xmlTextWriter_0);
						}
						break;
					case MsoDrawingType.Picture:
						if (shape.class1556_0 != null && shape.class1556_0.string_3 != null)
						{
							method_1(shape, xmlTextWriter_0);
						}
						else
						{
							AddPicture(shape, xmlTextWriter_0);
						}
						break;
					case MsoDrawingType.Chart:
						method_4(shape, xmlTextWriter_0);
						break;
					}
				}
				else
				{
					AddShape(shape, xmlTextWriter_0);
				}
			}
		}
	}

	[Attribute0(true)]
	private void method_1(Shape shape_0, XmlTextWriter xmlTextWriter_0)
	{
		if (shape_0.class1556_0 != null && shape_0.class1556_0.string_3 != null)
		{
			xmlTextWriter_0.WriteRaw(shape_0.class1556_0.string_3);
		}
	}

	private void method_2()
	{
		xmlDocument_0 = new XmlDocument();
		XmlElement xmlElement = null;
		if (bool_0)
		{
			xmlElement = xmlDocument_0.CreateElement("c", "userShapes", "http://schemas.openxmlformats.org/drawingml/2006/chart");
			xmlDocument_0.AppendChild(xmlElement);
		}
		else
		{
			xmlDocument_0.AppendChild(xmlDocument_0.CreateXmlDeclaration("1.0", "utf-8", null));
			xmlElement = xmlDocument_0.CreateElement("xdr", "wsDr", "http://schemas.openxmlformats.org/drawingml/2006/spreadsheetDrawing");
			xmlDocument_0.AppendChild(xmlElement);
		}
		string namespaceURI = "http://www.w3.org/2000/xmlns/";
		XmlAttribute xmlAttribute = xmlDocument_0.CreateAttribute("xmlns", "a", namespaceURI);
		xmlAttribute.Value = "http://schemas.openxmlformats.org/drawingml/2006/main";
		xmlElement.Attributes.Append(xmlAttribute);
	}

	private void AddShape(Shape shape_0, XmlTextWriter xmlTextWriter_0)
	{
		Class1359 class1359_ = new Class1359(class1358_0, shape_0);
		Class1367 @class = new Class1367(class1359_);
		@class.Write(xmlTextWriter_0);
	}

	private void method_3(Shape shape_0, XmlTextWriter xmlTextWriter_0)
	{
		Class1359 class1359_ = new Class1359(class1358_0, shape_0);
		Class1367 @class = new Class1367(class1359_);
		@class.method_0(xmlTextWriter_0);
	}

	private void AddPicture(Shape shape_0, XmlTextWriter xmlTextWriter_0)
	{
		if (bool_0 || class1541_0.worksheet_0.Type == SheetType.Worksheet)
		{
			Class1359 class1359_ = new Class1359(class1358_0, shape_0);
			Class1367 @class = new Class1367(class1359_);
			@class.Write(xmlTextWriter_0);
		}
	}

	private void method_4(Shape shape_0, XmlTextWriter xmlTextWriter_0)
	{
		Class1533 @class = method_5(shape_0);
		if (@class != null)
		{
			Class1359 class1359_ = new Class1359(class1358_0, @class.chart_0.ChartObject);
			Class1367 class2 = new Class1367(class1359_);
			class2.Write(xmlTextWriter_0);
		}
	}

	private Class1533 method_5(Shape shape_0)
	{
		ChartShape chartShape = (ChartShape)shape_0;
		ArrayList arrayList_ = class1358_0.arrayList_1;
		int num = arrayList_.Count;
		if (!bool_0 && class1541_0.worksheet_0.Type == SheetType.Chart)
		{
			num = Math.Min(1, num);
		}
		int num2 = 0;
		Class1533 @class;
		while (true)
		{
			if (num2 < num)
			{
				@class = (Class1533)arrayList_[num2];
				if (@class.chart_0 != null && @class.chart_0.ChartObject == chartShape)
				{
					break;
				}
				num2++;
				continue;
			}
			return null;
		}
		return @class;
	}

	[Attribute0(true)]
	private void method_6(XmlTextWriter xmlTextWriter_0)
	{
		if (bool_0)
		{
			xmlTextWriter_0.WriteStartDocument(standalone: false);
			xmlTextWriter_0.WriteStartElement("c:userShapes");
			xmlTextWriter_0.WriteAttributeString("xmlns", "c", null, "http://schemas.openxmlformats.org/drawingml/2006/chart");
		}
		else
		{
			xmlTextWriter_0.WriteStartDocument(standalone: true);
			xmlTextWriter_0.WriteStartElement("xdr:wsDr");
			xmlTextWriter_0.WriteAttributeString("xmlns", "xdr", null, "http://schemas.openxmlformats.org/drawingml/2006/spreadsheetDrawing");
		}
		xmlTextWriter_0.WriteAttributeString("xmlns", "a", null, "http://schemas.openxmlformats.org/drawingml/2006/main");
		xmlTextWriter_0.WriteAttributeString("xmlns", "r", null, "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
	}
}
