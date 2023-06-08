using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;
using Aspose.Slides;
using ns16;
using ns33;
using ns53;
using ns56;

namespace ns18;

internal class Class1212 : Class1188
{
	private const string string_0 = "urn:schemas-microsoft-com:office:office";

	private static Class1151 class1151_0 = new Class1151("solid", "dot", "dash", "longdash", "dashdot", "longdashdot", "longdashdotdot", "shortdash", "shortdot", "shortdashdot", "shortdashdotdot");

	private static readonly string[] string_1 = new string[4] { "fill", "fillback", "line", "lineback" };

	internal void method_5(IBaseSlide slide, Class1030 slideDeserializationContext)
	{
		method_0();
		Dictionary<string, string> dictionary = null;
		bool flag = false;
		while ((flag && !base.XmlPartReader.EOF) || base.XmlPartReader.Read())
		{
			flag = false;
			if (base.XmlPartReader.NodeType != XmlNodeType.Element)
			{
				continue;
			}
			switch (base.XmlPartReader.LocalName)
			{
			case "shape":
			{
				Class2322 @class = new Class2322(base.XmlPartReader);
				try
				{
					string text = @class.Id ?? "";
					string text2 = @class.O_Spid ?? "";
					string text3 = null;
					ISlideComponent value = null;
					if (text != "")
					{
						slideDeserializationContext.ShapeXmlIdToShape.TryGetValue(text, out value);
					}
					if (value != null || !(text2 != ""))
					{
						goto IL_01b2;
					}
					if (text2 != "")
					{
						slideDeserializationContext.ShapeXmlIdToShape.TryGetValue(text2, out value);
					}
					if (value != null)
					{
						goto IL_01b2;
					}
					if (text2 == "")
					{
						break;
					}
					if (text2.StartsWith("_x"))
					{
						int i;
						for (i = 2; i < text2.Length && text2[i] >= '0' && text2[i] <= '9'; i++)
						{
						}
						if (i + 2 != text2.Length && text2[i] == '_' && text2[i + 1] == 's')
						{
							i += 2;
							text3 = text2.Substring(i);
							slideDeserializationContext.ShapeXmlIdToShape.TryGetValue(text3, out value);
						}
					}
					goto IL_01b2;
					IL_01b2:
					bool flag2 = true;
					if (value == null && (text != "" || text2 != ""))
					{
						if (dictionary == null)
						{
							dictionary = smethod_2(slideDeserializationContext.SlidePart);
						}
						flag2 = !dictionary.ContainsKey(text) && !dictionary.ContainsKey(text2) && (text3 == null || !dictionary.ContainsKey(text3));
					}
					if (flag2)
					{
						if (value != null && !(value is IShape))
						{
							smethod_1(slide, (IControl)value, @class, base.DeserializationContext);
						}
						else
						{
							smethod_0(slide, (IShape)value, @class, base.DeserializationContext);
						}
					}
				}
				catch (Exception ex)
				{
					Class1165.smethod_28(ex);
				}
				break;
			}
			case "shapetype":
				base.XmlPartReader.Skip();
				flag = true;
				break;
			case "shapelayout":
				base.XmlPartReader.Skip();
				flag = true;
				break;
			default:
				base.XmlPartReader.Skip();
				flag = true;
				break;
			case "xml":
				break;
			}
		}
		method_2();
	}

	public Class1212(Class1342 part, Class1341 deserializationContext)
		: base(part, deserializationContext)
	{
	}

	public Class1212(Class1342 part, Class1346 serializationContext)
		: base(part, serializationContext)
	{
	}

	private static void smethod_0(IBaseSlide slide, IShape shape, Class2322 vmlShapeElementData, Class1341 deserializationContext)
	{
		Dictionary<string, string> dictionary = smethod_4(vmlShapeElementData.Style);
		float x = new Class1149(dictionary["left"]).method_10();
		float y = new Class1149(dictionary["top"]).method_10();
		float width = new Class1149(dictionary["width"]).method_10();
		float height = new Class1149(dictionary["height"]).method_10();
		float rotationAngle = 0f;
		NullableBool flipH = NullableBool.NotDefined;
		NullableBool flipV = NullableBool.NotDefined;
		if (dictionary.TryGetValue("rotation", out var value))
		{
			rotationAngle = new Class1149(value).method_4();
		}
		if (dictionary.TryGetValue("flip", out var value2))
		{
			Class1149 @class = new Class1149(value2);
			string text;
			while ((text = @class.method_2()) != "")
			{
				if (text == "x")
				{
					flipH = NullableBool.True;
				}
				else if (text == "y")
				{
					flipV = NullableBool.True;
				}
			}
		}
		if (shape == null)
		{
			bool isSendToBack = false;
			Class2330 class2 = (Class2330)smethod_5(vmlShapeElementData.ShapeElementsList, "imagedata");
			IPPImage iPPImage = null;
			if (class2 != null)
			{
				iPPImage = smethod_6(class2.O_Relid, deserializationContext);
			}
			if (iPPImage == null)
			{
				iPPImage = smethod_7(slide, vmlShapeElementData, width, height, ref isSendToBack);
			}
			object obj;
			if (iPPImage == null)
			{
				IShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, y, width, height, createFromTemplate: false);
				obj = shape2;
			}
			else
			{
				obj = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, x, y, width, height, iPPImage);
			}
			shape = (IShape)obj;
			if (isSendToBack)
			{
				slide.Shapes.Reorder(0, shape);
			}
			IShapeStyle shapeStyle = ((IGeometryShape)shape).ShapeStyle;
			if (shapeStyle != null)
			{
				shapeStyle.LineStyleIndex = 0;
				shapeStyle.FillStyleIndex = 0;
				shapeStyle.EffectStyleIndex = 0u;
				shapeStyle.FontCollectionIndex = FontCollectionIndex.None;
			}
			shape.FillFormat.FillType = FillType.NotDefined;
			shape.LineFormat.FillFormat.FillType = FillType.NotDefined;
			shape.Frame = new ShapeFrame(x, y, width, height, flipH, flipV, rotationAngle);
		}
		else if (shape is IOleObjectFrame)
		{
			IOleObjectFrame oleObjectFrame = (IOleObjectFrame)shape;
			if (oleObjectFrame.SubstitutePictureFormat.Picture.Image == null)
			{
				Class2330 class3 = (Class2330)smethod_5(vmlShapeElementData.ShapeElementsList, "imagedata");
				oleObjectFrame.SubstitutePictureFormat.Picture.Image = smethod_6(class3.O_Relid, deserializationContext);
			}
			if (float.IsNaN(oleObjectFrame.RawFrame.X))
			{
				oleObjectFrame.Frame = new ShapeFrame(x, y, width, height, flipH, flipV, rotationAngle);
			}
			((OleObjectFrame)oleObjectFrame).PPTXUnsupportedProps.RecolorInfo = (Class2217)smethod_5(vmlShapeElementData.ShapeElementsList, "recolorinfo");
		}
		if ((shape.FillFormat != null && shape.FillFormat.FillType == FillType.NotDefined) || (shape.LineFormat != null && shape.LineFormat.FillFormat.FillType == FillType.NotDefined))
		{
			smethod_13(shape.FillFormat, shape.LineFormat, vmlShapeElementData, deserializationContext);
		}
	}

	private static void smethod_1(IBaseSlide slide, IControl control, Class2322 vmlShapeElementData, Class1341 deserializationContext)
	{
		Dictionary<string, string> dictionary = smethod_4(vmlShapeElementData.Style);
		float x = new Class1149(dictionary["left"]).method_10();
		float y = new Class1149(dictionary["top"]).method_10();
		float width = new Class1149(dictionary["width"]).method_10();
		float height = new Class1149(dictionary["height"]).method_10();
		float rotationAngle = 0f;
		NullableBool flipH = NullableBool.False;
		NullableBool flipV = NullableBool.False;
		if (dictionary.TryGetValue("rotation", out var value))
		{
			rotationAngle = new Class1149(value).method_4();
		}
		if (dictionary.TryGetValue("flip", out var value2))
		{
			Class1149 @class = new Class1149(value2);
			string text;
			while ((text = @class.method_2()) != "")
			{
				if (text == "x")
				{
					flipH = NullableBool.True;
				}
				else if (text == "y")
				{
					flipV = NullableBool.True;
				}
			}
		}
		if (((Control)control).PPTXUnsupportedProps.SubstituteImage.Picture.Image == null)
		{
			Class2330 class2 = (Class2330)smethod_5(vmlShapeElementData.ShapeElementsList, "imagedata");
			((Control)control).PPTXUnsupportedProps.SubstituteImage.Picture.Image = smethod_6(class2.O_Relid, deserializationContext);
		}
		((Control)control).method_0(x, y, width, height, flipH, flipV, rotationAngle);
	}

	private static Dictionary<string, string> smethod_2(Class1342 slidePart)
	{
		XmlDocument xmlDocument = new XmlDocument();
		using (Stream inStream = slidePart.method_0())
		{
			xmlDocument.Load(inStream);
		}
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		smethod_3(dictionary, xmlDocument.DocumentElement);
		return dictionary;
	}

	private static void smethod_3(Dictionary<string, string> found, XmlElement elem)
	{
		string attribute = elem.GetAttribute("spid", "");
		if (attribute != null && attribute != "")
		{
			found[attribute] = attribute;
			return;
		}
		foreach (XmlNode childNode in elem.ChildNodes)
		{
			if (childNode is XmlElement elem2)
			{
				smethod_3(found, elem2);
			}
		}
	}

	private static Dictionary<string, string> smethod_4(string style)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
		int i = 0;
		while (i < style.Length)
		{
			for (; i < style.Length && style[i] <= ' '; i++)
			{
			}
			int num = i;
			for (; i < style.Length && style[i] != ':' && style[i] != ';'; i++)
			{
			}
			if (style[i] == ';')
			{
				i++;
				continue;
			}
			int num2 = i;
			while (num < num2 && style[num2 - 1] <= ' ')
			{
				num2--;
			}
			for (i++; i < style.Length && style[i] <= ' '; i++)
			{
			}
			int num3 = i;
			for (; i < style.Length && style[i] != ';'; i++)
			{
			}
			int num4 = i;
			while (num3 < num4 && style[num4 - 1] <= ' ')
			{
				num4--;
			}
			if (num < num2 && num3 < num4)
			{
				dictionary[style.Substring(num, num2 - num)] = style.Substring(num3, num4 - num3);
			}
			i++;
		}
		return dictionary;
	}

	internal static object smethod_5(Class2605[] namedObjects, string byName)
	{
		int num = 0;
		Class2605 @class;
		while (true)
		{
			if (num < namedObjects.Length)
			{
				@class = namedObjects[num];
				if (@class.Name == byName)
				{
					break;
				}
				num++;
				continue;
			}
			return null;
		}
		return @class.Object;
	}

	private static IPPImage smethod_6(string relid, Class1341 deserializationContext)
	{
		Class1348 relationshipsOfCurrentPartEntry = deserializationContext.RelationshipsOfCurrentPartEntry;
		if (relid != null)
		{
			return deserializationContext.method_1(relationshipsOfCurrentPartEntry[relid].TargetPart);
		}
		return null;
	}

	private static IPPImage smethod_7(IBaseSlide slide, Class2322 vmlShapeElem, float width, float height, ref bool isSendToBack)
	{
		IPPImage result = null;
		GraphicsPath[] array = smethod_8(vmlShapeElem, width, height);
		if (array.Length > 0)
		{
			string strokecolor = vmlShapeElem.Strokecolor;
			ColorFormat colorFormat = new ColorFormat(null, Color.Transparent);
			if (strokecolor != null && strokecolor.Length > 0)
			{
				Class1149 @class = new Class1149(strokecolor);
				@class.method_0(colorFormat);
			}
			float width2 = new Class1149(vmlShapeElem.Strokeweight).method_12(1f);
			Image image = new Bitmap((int)width + 2, (int)height + 2);
			Graphics graphics = Graphics.FromImage(image);
			using (SolidBrush brush = new SolidBrush(Color.Transparent))
			{
				graphics.FillRectangle(brush, 0f, 0f, width + 2f, height + 2f);
			}
			graphics.Transform = new Matrix(1f, 0f, 0f, 1f, 1f, 1f);
			Pen pen = new Pen(Color.FromArgb(255, colorFormat.Color), width2);
			for (int i = 0; i < array.Length; i++)
			{
				graphics.DrawPath(pen, array[i]);
			}
			pen.Dispose();
			graphics.Dispose();
			result = slide.Presentation.Images.AddImage(image);
			isSendToBack = true;
		}
		return result;
	}

	private static GraphicsPath[] smethod_8(Class2322 vmlShapeElem, float pixWidth, float pixHeight)
	{
		string path = vmlShapeElem.Path;
		if (path != null && path.Length > 0)
		{
			long num = 0L;
			long num2 = 0L;
			string coordorigin = vmlShapeElem.Coordorigin;
			if (coordorigin != null && coordorigin.Length > 0)
			{
				string[] array = coordorigin.Replace(" ", "").Split(',');
				num = long.Parse(array[0]);
				num2 = long.Parse(array[1]);
			}
			long coordSize = 1000L;
			long coordSize2 = 1000L;
			string coordsize = vmlShapeElem.Coordsize;
			if (coordsize != null && coordsize.Length > 0)
			{
				string[] array2 = coordsize.Replace(" ", "").Split(',');
				coordSize = long.Parse(array2[0]);
				coordSize2 = long.Parse(array2[1]);
			}
			path = path.ToLower();
			int index = 0;
			string text = smethod_10(path, ref index);
			string[] array3 = smethod_11(path, ref index);
			float num3 = 0f;
			float num4 = 0f;
			GraphicsPath graphicsPath = null;
			ArrayList arrayList = new ArrayList();
			while (text.Length > 0)
			{
				int num5 = 0;
				switch (text)
				{
				case "m":
					graphicsPath = new GraphicsPath();
					num3 = float.Parse(array3[num5++]);
					num4 = float.Parse(array3[num5++]);
					break;
				case "c":
					while (num5 < array3.Length)
					{
						float x9 = smethod_9(num3, num, coordSize, pixWidth);
						float y9 = smethod_9(num4, num2, coordSize2, pixHeight);
						float x10 = smethod_9(float.Parse(array3[num5++]), num, coordSize, pixWidth);
						float y10 = smethod_9(float.Parse(array3[num5++]), num2, coordSize2, pixHeight);
						float x11 = smethod_9(float.Parse(array3[num5++]), num, coordSize, pixWidth);
						float y11 = smethod_9(float.Parse(array3[num5++]), num2, coordSize2, pixHeight);
						num3 = float.Parse(array3[num5++]);
						num4 = float.Parse(array3[num5++]);
						float x12 = smethod_9(num3, num, coordSize, pixWidth);
						float y12 = smethod_9(num4, num2, coordSize2, pixHeight);
						graphicsPath.AddBezier(x9, y9, x10, y10, x11, y11, x12, y12);
					}
					break;
				case "v":
					while (num5 < array3.Length)
					{
						float x5 = smethod_9(num3, num, coordSize, pixWidth);
						float y5 = smethod_9(num4, num2, coordSize2, pixHeight);
						float x6 = smethod_9(float.Parse(array3[num5++]) + num3, num, coordSize, pixWidth);
						float y6 = smethod_9(float.Parse(array3[num5++]) + num4, num2, coordSize2, pixHeight);
						float x7 = smethod_9(float.Parse(array3[num5++]) + num3, num, coordSize, pixWidth);
						float y7 = smethod_9(float.Parse(array3[num5++]) + num4, num2, coordSize2, pixHeight);
						float num8 = num3 + float.Parse(array3[num5++]);
						float num9 = num4 + float.Parse(array3[num5++]);
						float x8 = smethod_9(num8, num, coordSize, pixWidth);
						float y8 = smethod_9(num9, num2, coordSize2, pixHeight);
						graphicsPath.AddBezier(x5, y5, x6, y6, x7, y7, x8, y8);
						num3 = num8;
						num4 = num9;
					}
					break;
				case "l":
					while (num5 < array3.Length)
					{
						float x3 = smethod_9(num3, num, coordSize, pixWidth);
						float y3 = smethod_9(num4, num2, coordSize2, pixHeight);
						num3 = float.Parse(array3[num5++]);
						num4 = float.Parse(array3[num5++]);
						float x4 = smethod_9(num3, num, coordSize, pixWidth);
						float y4 = smethod_9(num4, num2, coordSize2, pixHeight);
						graphicsPath.AddLine(x3, y3, x4, y4);
					}
					break;
				case "r":
					while (num5 < array3.Length)
					{
						float x = smethod_9(num3, num, coordSize, pixWidth);
						float y = smethod_9(num4, num2, coordSize2, pixHeight);
						float num6 = num3 + float.Parse(array3[num5++]);
						float num7 = num4 + float.Parse(array3[num5++]);
						float x2 = smethod_9(num6, num, coordSize, pixWidth);
						float y2 = smethod_9(num7, num2, coordSize2, pixHeight);
						graphicsPath.AddLine(x, y, x2, y2);
						num3 = num6;
						num4 = num7;
					}
					break;
				case "e":
					arrayList.Add(graphicsPath);
					graphicsPath = null;
					break;
				}
				text = smethod_10(path, ref index);
				array3 = smethod_11(path, ref index);
			}
			GraphicsPath[] array4 = new GraphicsPath[arrayList.Count];
			for (int i = 0; i < arrayList.Count; i++)
			{
				array4[i] = (GraphicsPath)arrayList[i];
			}
			return array4;
		}
		return new GraphicsPath[0];
	}

	private static float smethod_9(float coordinate, float coordOrigin, long coordSize, float pixSize)
	{
		return (coordinate - coordOrigin) * pixSize / (float)coordSize;
	}

	private static string smethod_10(string pathStr, ref int index)
	{
		if (index >= 0 && index < pathStr.Length)
		{
			while (pathStr[index] == ' ' && index < pathStr.Length)
			{
				index++;
			}
			while (pathStr[index] == ',' && index < pathStr.Length)
			{
				index++;
			}
			while (pathStr[index] == ' ' && index < pathStr.Length)
			{
				index++;
			}
			if (index >= pathStr.Length)
			{
				return string.Empty;
			}
			int num = index;
			char c = pathStr[index];
			if (c != 'n' && c != 'a' && c != 'q' && c != 'w')
			{
				index++;
				return c.ToString();
			}
			index++;
			return pathStr.Substring(num, index - num);
		}
		return string.Empty;
	}

	private static string[] smethod_11(string pathStr, ref int index)
	{
		if (index >= 0 && index < pathStr.Length)
		{
			while (pathStr[index] == ' ' && index < pathStr.Length)
			{
				index++;
			}
			if (index >= pathStr.Length)
			{
				return null;
			}
			int num = index;
			while (pathStr[index] == ',' && index < pathStr.Length)
			{
				index++;
			}
			while (pathStr[index] == ' ' && index < pathStr.Length)
			{
				index++;
			}
			char c = pathStr[index];
			while ((c >= '0' && c <= '9') || c == '-' || c == ',' || c == ' ')
			{
				index++;
				if (index >= pathStr.Length)
				{
					break;
				}
				c = pathStr[index];
			}
			string text = pathStr.Substring(num, index - num).Replace(" ", "");
			string[] array = text.Split(',');
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].Length == 0)
				{
					array[i] = "0";
				}
			}
			return array;
		}
		return null;
	}

	private static bool smethod_12(Enum371 trueFalse)
	{
		if (trueFalse != Enum371.const_1 && trueFalse != Enum371.const_3)
		{
			return false;
		}
		return true;
	}

	private static void smethod_13(IFillFormat fillFormat, ILineFormat lineFormat, Class2322 vmlShapeElementData, Class1341 deserializationContext)
	{
		Class2326 @class = (Class2326)smethod_5(vmlShapeElementData.ShapeElementsList, "fill");
		Class2333 class2 = (Class2333)smethod_5(vmlShapeElementData.ShapeElementsList, "stroke");
		string text = vmlShapeElementData.Fillcolor;
		string text2 = null;
		string text3 = null;
		float num = 1f;
		float num2 = 1f;
		bool flag = smethod_12(vmlShapeElementData.Filled);
		if (@class != null)
		{
			text = ((@class.Color != null) ? @class.Color : text);
			flag = ((@class.On != 0) ? smethod_12(@class.On) : flag);
			num = new Class1149((@class.Opacity != null) ? @class.Opacity : "1").method_4();
			if (flag)
			{
				switch (@class.Type)
				{
				case Enum364.const_0:
				case Enum364.const_1:
					fillFormat.FillType = FillType.Solid;
					break;
				case Enum364.const_2:
					fillFormat.FillType = FillType.Gradient;
					fillFormat.GradientFormat.GradientShape = GradientShape.Linear;
					fillFormat.GradientFormat.LinearGradientAngle = new Class1149((@class.Angle != null) ? @class.Angle : "0").method_4();
					fillFormat.GradientFormat.LinearGradientScaled = NullableBool.True;
					num2 = new Class1149((@class.O_Opacity2 != null) ? @class.O_Opacity2 : "1").method_4();
					text3 = @class.Color2;
					text2 = @class.Colors;
					break;
				case Enum364.const_3:
				{
					fillFormat.FillType = FillType.Gradient;
					fillFormat.GradientFormat.GradientShape = GradientShape.Rectangle;
					num2 = new Class1149((@class.O_Opacity2 != null) ? @class.O_Opacity2 : "1").method_4();
					text3 = @class.Color2;
					text2 = @class.Colors;
					Class1149 class3 = new Class1149((@class.Focusposition != null) ? @class.Focusposition : "0.5,0.5");
					float num3 = class3.method_4();
					float num4 = 0f;
					if (float.IsNaN(num3))
					{
						num3 = 0f;
					}
					class3.method_8();
					if (class3.CharsLeftCount > 0)
					{
						class3.method_7();
						num4 = class3.method_4();
					}
					if (float.IsNaN(num4))
					{
						num4 = 0f;
					}
					((GradientFormat)fillFormat.GradientFormat).method_6(num3, num4, 0f, 0f);
					break;
				}
				case Enum364.const_4:
					fillFormat.FillType = FillType.Picture;
					fillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;
					fillFormat.PictureFillFormat.Picture.Image = smethod_6(@class.O_Relid, deserializationContext);
					break;
				case Enum364.const_5:
					fillFormat.FillType = FillType.Pattern;
					num2 = new Class1149((@class.O_Opacity2 != null) ? @class.O_Opacity2 : "1").method_4();
					text3 = @class.Color2;
					break;
				case Enum364.const_6:
					fillFormat.FillType = FillType.Picture;
					fillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
					fillFormat.PictureFillFormat.Picture.Image = smethod_6(@class.O_Relid, deserializationContext);
					break;
				}
			}
		}
		else if (flag)
		{
			fillFormat.FillType = FillType.Solid;
		}
		if (!flag)
		{
			fillFormat.FillType = FillType.NoFill;
		}
		bool flag2 = smethod_12(vmlShapeElementData.Stroked);
		string text4 = ((vmlShapeElementData.Strokecolor != null) ? vmlShapeElementData.Strokecolor : "");
		string text5 = null;
		float num5 = 1f;
		string text6 = ((vmlShapeElementData.Strokeweight != null) ? vmlShapeElementData.Strokeweight : "");
		if (class2 != null)
		{
			flag2 = ((class2.On != 0) ? smethod_12(class2.On) : flag2);
			text6 = ((class2.Weight != null) ? class2.Weight : text6);
			text4 = ((class2.Color != null) ? class2.Color : text4);
			if (flag2)
			{
				num5 = new Class1149((class2.Opacity != null) ? class2.Opacity : "1").method_4();
				text5 = class2.Color2;
				lineFormat.FillFormat.FillType = FillType.Solid;
				lineFormat.Width = new Class1149(text6).method_10();
				lineFormat.Style = ((class2.Linestyle != LineStyle.NotDefined) ? class2.Linestyle : LineStyle.Single);
				lineFormat.JoinStyle = ((class2.Joinstyle != LineJoinStyle.NotDefined) ? class2.Joinstyle : LineJoinStyle.Round);
				if (lineFormat.JoinStyle == LineJoinStyle.Miter)
				{
					lineFormat.MiterLimit = new Class1149((class2.Miterlimit != null) ? class2.Miterlimit : "8").method_4();
				}
				string text7 = ((class2.Dashstyle != null) ? class2.Dashstyle : "solid");
				text7 = text7.ToLower(CultureInfo.InvariantCulture);
				Class1149 class4 = new Class1149(text7);
				class4.method_8();
				if (class4.CurrentChar >= '0' && class4.CurrentChar <= '9')
				{
					List<float> list = new List<float>();
					float item;
					while (!float.IsNaN(item = class4.method_4()))
					{
						list.Add(item);
					}
					lineFormat.DashStyle = LineDashStyle.Custom;
					lineFormat.CustomDashPattern = list.ToArray();
				}
				else
				{
					lineFormat.DashStyle = (LineDashStyle)class1151_0[text7];
				}
				lineFormat.CapStyle = ((class2.Endcap != LineCapStyle.NotDefined) ? class2.Endcap : LineCapStyle.Flat);
			}
		}
		IColorFormat[] array = new IColorFormat[4];
		byte b = 0;
		switch (fillFormat.FillType)
		{
		case FillType.Solid:
			array[0] = fillFormat.SolidFillColor;
			array[1] = fillFormat.PatternFormat.BackColor;
			break;
		case FillType.Gradient:
			fillFormat.GradientFormat.GradientStops.Add(0f, PresetColor.Black);
			fillFormat.GradientFormat.GradientStops.Add(1f, PresetColor.White);
			array[0] = fillFormat.GradientFormat.GradientStops[0].Color;
			array[1] = fillFormat.GradientFormat.GradientStops[1].Color;
			break;
		case FillType.Pattern:
			array[0] = fillFormat.PatternFormat.ForeColor;
			array[1] = fillFormat.PatternFormat.BackColor;
			break;
		}
		if (lineFormat.FillFormat.FillType == FillType.Solid)
		{
			array[2] = lineFormat.FillFormat.SolidFillColor;
			array[3] = lineFormat.FillFormat.PatternFormat.BackColor;
		}
		string[] array2 = new string[4] { text, text3, text4, text5 };
		byte b2;
		do
		{
			b2 = b;
			for (int i = 0; i < array.Length; i++)
			{
				if ((b & (1 << i)) != 0)
				{
					continue;
				}
				bool flag3 = true;
				if (array2[i] != null && array2[i] != "")
				{
					for (int j = 0; j < array.Length; j++)
					{
						if ((b & (1 << j)) == 0 && array2[i].IndexOf(string_1[j]) >= 0)
						{
							flag3 = false;
							break;
						}
					}
					if (flag3)
					{
						if (array[i] != null)
						{
							new Class1149(array2[i]).method_1(array[i], array[0], array[1], array[2], array[3]);
						}
						b = (byte)(b | (byte)(1 << i));
					}
				}
				else
				{
					b = (byte)(b | (byte)(1 << i));
				}
			}
		}
		while (b2 != b);
		for (int k = 0; k < array.Length; k++)
		{
			if ((b & (1 << k)) == 0)
			{
				new Class1149(array2[k]).method_0(array[k]);
			}
		}
		if (num < 1f)
		{
			array[0].ColorTransform.Add(ColorTransformOperation.SetAlpha, num);
		}
		if (num2 < 1f)
		{
			array[1].ColorTransform.Add(ColorTransformOperation.SetAlpha, num2);
		}
		if (num5 < 1f)
		{
			array[2].ColorTransform.Add(ColorTransformOperation.SetAlpha, num5);
		}
		if (fillFormat.FillType != FillType.Gradient || text2 == null || !(text2 != ""))
		{
			return;
		}
		fillFormat.GradientFormat.GradientStops.Clear();
		Class1149 class5 = new Class1149(text2);
		class5.method_8();
		while (class5.CharsLeftCount > 0)
		{
			float num6 = class5.method_4();
			if (!float.IsNaN(num6))
			{
				fillFormat.GradientFormat.GradientStops.Add(num6, PresetColor.NotDefined);
				class5.method_1(fillFormat.GradientFormat.GradientStops[fillFormat.GradientFormat.GradientStops.Count - 1].Color, array[0], array[1], array[2], array[3]);
				class5.method_8();
				if (class5.CharsLeftCount > 0)
				{
					class5.method_7();
				}
				class5.method_8();
				continue;
			}
			break;
		}
	}

	internal void method_6(Class1031 slideSerializationContext)
	{
		method_3();
		slideSerializationContext.VmlDrawingEntry = base.Part;
		base.XmlPartWriter.WriteStartElement(null, "xml", null);
		base.XmlPartWriter.WriteAttributeString("xmlns", "v", null, "urn:schemas-microsoft-com:vml");
		base.XmlPartWriter.WriteAttributeString("xmlns", "o", null, "urn:schemas-microsoft-com:office:office");
		base.XmlPartWriter.WriteAttributeString("xmlns", "xs", null, "http://www.w3.org/2001/XMLSchema");
		base.XmlPartWriter.WriteAttributeString("xmlns", "r", null, "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
		base.XmlPartWriter.WriteAttributeString("xmlns", "wvml", null, "urn:schemas-microsoft-com:office:word");
		base.XmlPartWriter.WriteAttributeString("xmlns", "x", null, "urn:schemas-microsoft-com:office:excel");
		base.XmlPartWriter.WriteAttributeString("xmlns", "ppt", null, "urn:schemas-microsoft-com:office:powerpoint");
		string type = method_10(base.XmlPartWriter);
		foreach (KeyValuePair<ISlideComponent, int> vmlObject in slideSerializationContext.VmlObjects)
		{
			ISlideComponent key = vmlObject.Key;
			_ = vmlObject.Value;
			if (key is OleObjectFrame)
			{
				method_7((OleObjectFrame)key, type, base.XmlPartWriter, slideSerializationContext);
				continue;
			}
			if (key is Control)
			{
				method_9((Control)key, type, base.XmlPartWriter, slideSerializationContext);
				continue;
			}
			throw new ArgumentException();
		}
		base.XmlPartWriter.WriteEndElement();
		method_4();
	}

	public string method_7(IOleObjectFrame oleObjectFrame, string type, XmlWriter xmlPartWriter, Class1031 slideSerializationContext)
	{
		Class1342 vmlDrawingEntry = slideSerializationContext.VmlDrawingEntry;
		IShapeFrame frame = oleObjectFrame.Frame;
		Class1346 serializationContext = slideSerializationContext.SerializationContext;
		Class2322 @class = new Class2322();
		string result = (@class.Id = $"_x0000_s{slideSerializationContext.VmlObjects[oleObjectFrame]:D4}");
		@class.Type = "#" + type;
		StringBuilder stringBuilder = new StringBuilder("position:absolute");
		if (!float.IsNaN(frame.X))
		{
			stringBuilder.AppendFormat(";left:{0}pt", XmlConvert.ToString(frame.X));
		}
		if (!float.IsNaN(frame.Y))
		{
			stringBuilder.AppendFormat(";top:{0}pt", XmlConvert.ToString(frame.Y));
		}
		if (!float.IsNaN(frame.Width))
		{
			stringBuilder.AppendFormat(";width:{0}pt", XmlConvert.ToString(frame.Width));
		}
		if (!float.IsNaN(frame.Height))
		{
			stringBuilder.AppendFormat(";height:{0}pt", XmlConvert.ToString(frame.Height));
		}
		if (!float.IsNaN(frame.Rotation) && frame.Rotation != 0f)
		{
			stringBuilder.AppendFormat(";rotation:{0}", XmlConvert.ToString(frame.Rotation));
		}
		if (frame.FlipH == NullableBool.True || frame.FlipV == NullableBool.True)
		{
			stringBuilder.Append(";flip:");
			if (frame.FlipH == NullableBool.True)
			{
				stringBuilder.Append(" x");
			}
			if (frame.FlipV == NullableBool.True)
			{
				stringBuilder.Append(" y");
			}
		}
		@class.Style = stringBuilder.ToString();
		method_12(oleObjectFrame.Slide, @class, vmlDrawingEntry, oleObjectFrame.LineFormat, oleObjectFrame.FillFormat, serializationContext);
		Class2330 class2 = (Class2330)@class.delegate2773_0("imagedata").Object;
		Class1347 class3 = vmlDrawingEntry.Relationships.method_4(serializationContext.method_1(method_8(oleObjectFrame, serializationContext)));
		class2.O_Relid = class3.Id;
		method_15(@class, oleObjectFrame.ShapeLock);
		Class2217 recolorInfo = ((OleObjectFrame)oleObjectFrame).PPTXUnsupportedProps.RecolorInfo;
		if (recolorInfo != null && recolorInfo.RecolorinfoentryList.Length > 0)
		{
			Class2217 class4 = (Class2217)@class.delegate2773_0("recolorinfo").Object;
			if (recolorInfo.Recolorstate == Enum353.const_1 || recolorInfo.Recolorstate == Enum353.const_3)
			{
				class4.Recolorstate = Enum353.const_1;
			}
			class4.Numcolors = (uint)recolorInfo.RecolorinfoentryList.Length;
			Class2218[] recolorinfoentryList = recolorInfo.RecolorinfoentryList;
			foreach (Class2218 class5 in recolorinfoentryList)
			{
				Class2218 class6 = class4.delegate2390_0();
				class6.Tocolor = class5.Tocolor;
				class6.Fromcolor = class5.Fromcolor;
			}
		}
		@class.vmethod_4(null, xmlPartWriter, "shape");
		return result;
	}

	private IPPImage method_8(IOleObjectFrame oleObjectFrame, Class1346 serializationContext)
	{
		if (oleObjectFrame.SubstitutePictureFormat.Picture.Image == null)
		{
			return ((ImageCollection)serializationContext.Presentation.Images).OleImage;
		}
		return oleObjectFrame.SubstitutePictureFormat.Picture.Image;
	}

	public void method_9(IControl control, string type, XmlWriter xmlPartWriter, Class1031 slideSerializationContext)
	{
		_ = ((Control)control).PPTXUnsupportedProps;
		Class1346 serializationContext = slideSerializationContext.SerializationContext;
		Class1342 vmlDrawingEntry = slideSerializationContext.VmlDrawingEntry;
		Class2322 @class = new Class2322();
		string o_Spid = string.Format("_x0000_s{0}", slideSerializationContext.VmlObjects[control].ToString("D4"));
		@class.Id = control.Name;
		@class.O_Spid = o_Spid;
		@class.Type = "#" + type;
		StringBuilder stringBuilder = new StringBuilder("position:absolute");
		if (!float.IsNaN(control.Frame.X))
		{
			stringBuilder.AppendFormat(";left:{0}pt", XmlConvert.ToString(control.Frame.X));
		}
		if (!float.IsNaN(control.Frame.Y))
		{
			stringBuilder.AppendFormat(";top:{0}pt", XmlConvert.ToString(control.Frame.Y));
		}
		if (!float.IsNaN(control.Frame.Width))
		{
			stringBuilder.AppendFormat(";width:{0}pt", XmlConvert.ToString(control.Frame.Width));
		}
		if (!float.IsNaN(control.Frame.Height))
		{
			stringBuilder.AppendFormat(";height:{0}pt", XmlConvert.ToString(control.Frame.Height));
		}
		if (!float.IsNaN(control.Frame.Rotation) && control.Frame.Rotation != 0f)
		{
			stringBuilder.AppendFormat(";rotation:{0}", XmlConvert.ToString(control.Frame.Rotation));
		}
		if (control.Frame.FlipH == NullableBool.True || control.Frame.FlipV == NullableBool.True)
		{
			stringBuilder.Append(";flip:");
			if (control.Frame.FlipH == NullableBool.True)
			{
				stringBuilder.Append("x");
				if (control.Frame.FlipV == NullableBool.True)
				{
					stringBuilder.Append(" y");
				}
			}
			else
			{
				stringBuilder.Append("y");
			}
		}
		@class.Style = stringBuilder.ToString();
		Class2330 class2 = (Class2330)@class.delegate2773_0("imagedata").Object;
		if (control.SubstitutePictureFormat.Picture.Image != null)
		{
			Class1347 class3 = vmlDrawingEntry.Relationships.method_4(serializationContext.method_2(control.SubstitutePictureFormat.Picture.Image));
			class2.O_Relid = class3.Id;
		}
		@class.vmethod_4(null, xmlPartWriter, "shape");
	}

	internal string method_10(XmlWriter xmlPartWriter)
	{
		Class2324 @class = new Class2324();
		string text = "_x0000_t" + 75;
		@class.Coordsize = "21600,21600";
		@class.Id = text;
		@class.O_Spt = 75f;
		@class.O_Preferrelative = Enum352.const_1;
		@class.Path = "m@4@5l@4@11@9@11@9@5xe";
		@class.Filled = Enum371.const_2;
		@class.Stroked = Enum371.const_2;
		Class2333 class2 = (Class2333)@class.delegate2773_0("stroke").Object;
		class2.Joinstyle = LineJoinStyle.Miter;
		Class2327 class3 = (Class2327)@class.delegate2773_0("formulas").Object;
		class3.delegate2722_0().Eqn = "if lineDrawn pixelLineWidth 0";
		class3.delegate2722_0().Eqn = "sum @0 1 0";
		class3.delegate2722_0().Eqn = "sum 0 0 @1";
		class3.delegate2722_0().Eqn = "prod @2 1 2";
		class3.delegate2722_0().Eqn = "prod @3 21600 pixelWidth";
		class3.delegate2722_0().Eqn = "prod @3 21600 pixelHeight";
		class3.delegate2722_0().Eqn = "sum @0 0 1";
		class3.delegate2722_0().Eqn = "prod @6 1 2";
		class3.delegate2722_0().Eqn = "prod @7 21600 pixelWidth";
		class3.delegate2722_0().Eqn = "sum @8 21600 0";
		class3.delegate2722_0().Eqn = "prod @7 21600 pixelHeight";
		class3.delegate2722_0().Eqn = "sum @10 21600 0";
		Class2331 class4 = (Class2331)@class.delegate2773_0("path").Object;
		class4.O_Extrusionok = Enum352.const_2;
		class4.Gradientshapeok = Enum371.const_1;
		class4.O_Connecttype = Enum342.const_2;
		Class2206 class5 = (Class2206)@class.delegate2773_0("lock").Object;
		class5.V_Ext = Enum362.const_2;
		class5.Aspectratio = Enum352.const_1;
		@class.vmethod_4(null, xmlPartWriter, "shapetype");
		return text;
	}

	public Color method_11(IColorFormat color, Color styleColor)
	{
		if (color.ColorType == ColorType.Scheme && color.SchemeColor == SchemeColor.StyleColor)
		{
			color.R = Color.Black.R;
			color.G = Color.Black.G;
			color.B = Color.Black.B;
			Color color2 = color.Color;
			color.ColorType = ColorType.Scheme;
			color.SchemeColor = SchemeColor.StyleColor;
			return color2;
		}
		return color.Color;
	}

	public void method_12(IBaseSlide slide, Class2322 vmlShapeElementData, Class1342 vmlDrawingEntry, ILineFormat lineFormat, IFillFormat fillFormat, Class1346 serializationContext)
	{
		switch (fillFormat.FillType)
		{
		default:
			vmlShapeElementData.Filled = Enum371.const_2;
			break;
		case FillType.Solid:
			if (method_11(fillFormat.SolidFillColor, Color.White).A < byte.MaxValue)
			{
				Class2326 class3 = (Class2326)vmlShapeElementData.delegate2773_0("fill").Object;
				class3.On = Enum371.const_1;
				class3.Type = Enum364.const_1;
				method_13(class3, fillFormat.SolidFillColor, slide);
			}
			else
			{
				vmlShapeElementData.Filled = Enum371.const_1;
				vmlShapeElementData.Fillcolor = fillFormat.SolidFillColor.ToString(ColorStringFormat.Vml);
			}
			break;
		case FillType.Gradient:
		{
			Class2326 class2 = (Class2326)vmlShapeElementData.delegate2773_0("fill").Object;
			class2.On = Enum371.const_1;
			IGradientFormat gradientFormat = fillFormat.GradientFormat;
			if (gradientFormat.GradientShape != 0 && gradientFormat.GradientShape != GradientShape.NotDefined)
			{
				class2.Type = Enum364.const_3;
				class2.Focusposition = $"{XmlConvert.ToString(((GradientFormat)gradientFormat).FillToRectangleX)},{XmlConvert.ToString(((GradientFormat)gradientFormat).FillToRectangleY)}";
				class2.Focussize = $"{XmlConvert.ToString(((GradientFormat)gradientFormat).FillToRectangleWidth)},{XmlConvert.ToString(((GradientFormat)gradientFormat).FillToRectangleHeight)}";
			}
			else
			{
				class2.Type = Enum364.const_2;
				class2.Rotate = ((fillFormat.RotateWithShape == NullableBool.True) ? Enum371.const_1 : Enum371.const_2);
				class2.Angle = XmlConvert.ToString(gradientFormat.LinearGradientAngle);
			}
			if (gradientFormat.GradientStops.Count > 0)
			{
				if (gradientFormat.GradientStops.Count <= 2)
				{
					if (gradientFormat.GradientStops[0].Position == 0f && gradientFormat.GradientStops[gradientFormat.GradientStops.Count - 1].Position == 1f)
					{
						class2.Method = Enum363.const_5;
					}
				}
				else
				{
					StringBuilder stringBuilder = new StringBuilder();
					if (gradientFormat.GradientStops.Count > 0)
					{
						stringBuilder.Append(XmlConvert.ToString(gradientFormat.GradientStops[0].Position));
						stringBuilder.Append(' ');
						stringBuilder.Append(gradientFormat.GradientStops[0].Color.ToString(ColorStringFormat.Vml));
					}
					for (int i = 1; i < gradientFormat.GradientStops.Count; i++)
					{
						stringBuilder.Append("; ");
						stringBuilder.Append(XmlConvert.ToString(gradientFormat.GradientStops[i].Position));
						stringBuilder.Append(' ');
						stringBuilder.Append(gradientFormat.GradientStops[i].Color.ToString(ColorStringFormat.Vml));
					}
					class2.Colors = stringBuilder.ToString();
				}
				method_13(class2, gradientFormat.GradientStops[0].Color, slide);
				method_14(class2, gradientFormat.GradientStops[gradientFormat.GradientStops.Count - 1].Color, slide);
			}
			class2.Focus = "100%";
			break;
		}
		case FillType.Pattern:
		{
			Class2326 class4 = (Class2326)vmlShapeElementData.delegate2773_0("fill").Object;
			class4.On = Enum371.const_1;
			class4.Type = Enum364.const_5;
			Bitmap tileImage = fillFormat.PatternFormat.GetTileImage(Color.White, Color.Black);
			Class1342 targetPart = serializationContext.method_4(tileImage);
			string id2 = vmlDrawingEntry.Relationships.method_4(targetPart).Id;
			class4.O_Relid = id2;
			method_13(class4, fillFormat.PatternFormat.ForeColor, slide);
			method_14(class4, fillFormat.PatternFormat.BackColor, slide);
			class4.Rotate = ((fillFormat.RotateWithShape == NullableBool.True) ? Enum371.const_1 : Enum371.const_2);
			break;
		}
		case FillType.Picture:
		{
			Class2326 @class = (Class2326)vmlShapeElementData.delegate2773_0("fill").Object;
			@class.On = Enum371.const_1;
			@class.Type = ((fillFormat.PictureFillFormat.PictureFillMode == PictureFillMode.Tile) ? Enum364.const_4 : Enum364.const_6);
			string id = vmlDrawingEntry.Relationships.method_4(serializationContext.method_2(fillFormat.PictureFillFormat.Picture.Image)).Id;
			@class.O_Relid = id;
			break;
		}
		}
		if (lineFormat.FillFormat.FillType != 0 && lineFormat.FillFormat.FillType != FillType.NotDefined)
		{
			if (!double.IsNaN(lineFormat.Width))
			{
				vmlShapeElementData.Strokeweight = $"{XmlConvert.ToString(lineFormat.Width)}pt";
			}
			vmlShapeElementData.Stroked = Enum371.const_1;
			vmlShapeElementData.Strokecolor = lineFormat.FillFormat.SolidFillColor.ToString(ColorStringFormat.Vml);
		}
		else
		{
			vmlShapeElementData.Stroked = Enum371.const_2;
		}
	}

	public void method_13(Class2326 fillElementData, IColorFormat color, IBaseSlide slide)
	{
		fillElementData.Color = color.ToString(ColorStringFormat.Vml);
		foreach (ColorOperation item in ((ColorOperationCollection)color.ColorTransform).list_0)
		{
			ColorTransformOperation operationType = item.OperationType;
			if (operationType == ColorTransformOperation.SetAlpha)
			{
				int num = (int)(item.Parameter * 65536f);
				fillElementData.Opacity = num + "f";
			}
		}
	}

	public void method_14(Class2326 fillElementData, IColorFormat color, IBaseSlide slide)
	{
		fillElementData.Color2 = color.ToString(ColorStringFormat.Vml);
		foreach (ColorOperation item in ((ColorOperationCollection)color.ColorTransform).list_0)
		{
			ColorTransformOperation operationType = item.OperationType;
			if (operationType == ColorTransformOperation.SetAlpha)
			{
				int num = (int)(item.Parameter * 65536f);
				fillElementData.O_Opacity2 = num + "f";
			}
		}
	}

	public void method_15(Class2322 vmlShapeElementData, IGraphicalObjectLock shapeLock)
	{
		Class2206 @class = (Class2206)vmlShapeElementData.delegate2773_0("lock").Object;
		@class.V_Ext = Enum362.const_2;
		@class.Aspectratio = (shapeLock.AspectRatioLocked ? Enum352.const_1 : Enum352.const_2);
		@class.Position = (shapeLock.PositionLocked ? Enum352.const_1 : Enum352.const_2);
		@class.Selection = (shapeLock.SelectLocked ? Enum352.const_1 : Enum352.const_2);
		@class.Grouping = (shapeLock.GroupingLocked ? Enum352.const_1 : Enum352.const_2);
	}
}
