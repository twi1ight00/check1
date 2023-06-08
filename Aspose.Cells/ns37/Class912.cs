using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using Aspose.Cells;
using Aspose.Cells.Charts;
using Aspose.Cells.Drawing;
using Aspose.Cells.Rendering;
using ns16;
using ns19;
using ns2;
using ns21;
using ns35;
using ns5;
using ns6;

namespace ns37;

internal class Class912
{
	internal static RectangleF Calculate(Shape shape_0)
	{
		if (shape_0.MsoDrawingType == MsoDrawingType.Chart)
		{
			Chart chart = ((ChartShape)shape_0).method_69();
			return new RectangleF(chart.ChartObject.Left, chart.ChartObject.Top, chart.ChartObject.Width, chart.ChartObject.Height);
		}
		Class913 @class = new Class913(smethod_22(shape_0.MsoDrawingType));
		smethod_3(shape_0, @class);
		@class.method_29();
		return @class.method_26();
	}

	internal static PointF smethod_0(Stream stream_0, ImageOrPrintOptions imageOrPrintOptions_0, Shape shape_0)
	{
		if (shape_0.MsoDrawingType == MsoDrawingType.Chart)
		{
			Chart chart = ((ChartShape)shape_0).method_69();
			chart.ToImage(stream_0, imageOrPrintOptions_0);
			return new PointF(0f, 0f);
		}
		if (shape_0.string_1 != null && shape_0.string_1 != "")
		{
			Shape shape = Class1615.smethod_0(shape_0);
			if (shape != null)
			{
				shape_0 = shape;
			}
		}
		Class913 @class = new Class913(smethod_22(shape_0.MsoDrawingType));
		smethod_3(shape_0, @class);
		if (!@class.method_30())
		{
			return PointF.Empty;
		}
		ImageFormat imageFormat = imageOrPrintOptions_0.ImageFormat;
		Interface42 @interface = smethod_1(shape_0, @class, stream_0, imageFormat, imageOrPrintOptions_0);
		if (@interface != null)
		{
			@interface.imethod_2();
			return new PointF(@class.X, @class.Y);
		}
		return PointF.Empty;
	}

	internal static void ToImage(Stream stream_0, ImageFormat imageFormat_0, Shape shape_0)
	{
		if (shape_0.MsoDrawingType == MsoDrawingType.Chart)
		{
			Chart chart = ((ChartShape)shape_0).method_69();
			chart.ToImage(stream_0, imageFormat_0);
			return;
		}
		if (shape_0.string_1 != null && shape_0.string_1 != "")
		{
			Shape shape = Class1615.smethod_0(shape_0);
			if (shape != null)
			{
				shape_0 = shape;
			}
		}
		Class913 @class = new Class913(smethod_22(shape_0.MsoDrawingType));
		smethod_3(shape_0, @class);
		if (!@class.bool_4)
		{
			@class.X = 0f;
			@class.Y = 0f;
		}
		if (@class.method_30())
		{
			ImageOrPrintOptions imageOrPrintOptions = new ImageOrPrintOptions();
			imageOrPrintOptions.ImageFormat = imageFormat_0;
			smethod_1(shape_0, @class, stream_0, imageFormat_0, imageOrPrintOptions)?.imethod_2();
		}
	}

	internal static void ToImage(string string_0, ImageOrPrintOptions imageOrPrintOptions_0, Shape shape_0)
	{
		if (shape_0.MsoDrawingType == MsoDrawingType.Chart)
		{
			Chart chart = ((ChartShape)shape_0).method_69();
			chart.ToImage(string_0, imageOrPrintOptions_0);
			return;
		}
		if (shape_0.string_1 != null && shape_0.string_1 != "")
		{
			Shape shape = Class1615.smethod_0(shape_0);
			if (shape != null)
			{
				shape_0 = shape;
			}
		}
		Class913 @class = new Class913(smethod_22(shape_0.MsoDrawingType));
		smethod_3(shape_0, @class);
		if (!@class.bool_4)
		{
			@class.X = 0f;
			@class.Y = 0f;
		}
		if (!@class.method_30())
		{
			return;
		}
		ImageFormat bmp = ImageFormat.Bmp;
		bmp = Class872.smethod_0(Path.GetExtension(string_0), bmp);
		using FileStream stream_ = new FileStream(string_0, FileMode.Create);
		smethod_1(shape_0, @class, stream_, bmp, imageOrPrintOptions_0)?.imethod_2();
	}

	internal static void ToImage(Stream stream_0, ImageOrPrintOptions imageOrPrintOptions_0, Shape shape_0)
	{
		if (shape_0.MsoDrawingType == MsoDrawingType.Chart)
		{
			Chart chart = ((ChartShape)shape_0).method_69();
			chart.ToImage(stream_0, imageOrPrintOptions_0);
			return;
		}
		if (shape_0.string_1 != null && shape_0.string_1 != "")
		{
			Shape shape = Class1615.smethod_0(shape_0);
			if (shape != null)
			{
				shape_0 = shape;
			}
		}
		Class913 @class = new Class913(smethod_22(shape_0.MsoDrawingType));
		smethod_3(shape_0, @class);
		if (!@class.bool_4)
		{
			@class.X = 0f;
			@class.Y = 0f;
		}
		if (@class.method_30())
		{
			ImageFormat imageFormat = imageOrPrintOptions_0.ImageFormat;
			smethod_1(shape_0, @class, stream_0, imageFormat, imageOrPrintOptions_0)?.imethod_2();
		}
	}

	internal static Bitmap ToImage(ImageOrPrintOptions imageOrPrintOptions_0, Shape shape_0)
	{
		if (shape_0.MsoDrawingType == MsoDrawingType.Chart)
		{
			Chart chart = ((ChartShape)shape_0).method_69();
			return chart.ToImage(imageOrPrintOptions_0);
		}
		if (shape_0.string_1 != null && shape_0.string_1 != "")
		{
			Shape shape = Class1615.smethod_0(shape_0);
			if (shape != null)
			{
				shape_0 = shape;
			}
		}
		Class913 @class = new Class913(smethod_22(shape_0.MsoDrawingType));
		smethod_3(shape_0, @class);
		if (!@class.bool_4)
		{
			@class.X = 0f;
			@class.Y = 0f;
		}
		if (!@class.method_30())
		{
			return null;
		}
		ImageFormat bmp = ImageFormat.Bmp;
		return smethod_1(shape_0, @class, null, bmp, imageOrPrintOptions_0)?.imethod_3();
	}

	private static Interface42 smethod_1(Shape shape_0, Class913 class913_0, Stream stream_0, ImageFormat imageFormat_0, ImageOrPrintOptions imageOrPrintOptions_0)
	{
		int int_ = Class1036.int_0;
		return Class1036.smethod_0(int_, (int)Math.Ceiling(class913_0.method_25().Width), (int)Math.Ceiling(class913_0.method_25().Height), imageFormat_0, imageOrPrintOptions_0, stream_0, class913_0);
	}

	internal static float[] smethod_2(Shape shape_0)
	{
		float num = 0f;
		float num2 = 0f;
		while (shape_0.method_33())
		{
			Shape shape = (Shape)shape_0.method_13();
			num += (float)(shape.Width * shape_0.method_27().method_7().Left) / 4000f;
			num2 += (float)(shape.Height * shape_0.method_27().method_7().Top) / 4000f;
			shape_0 = shape;
		}
		return new float[2] { num, num2 };
	}

	internal static void smethod_3(Shape shape_0, Class913 class913_0)
	{
		MsoTextFrame textFrame = shape_0.TextFrame;
		Class312 @class = new Class312();
		if (!shape_0.TextFrame.IsAutoMargin)
		{
			@class.LeftMargin = textFrame.LeftMarginPt * (double)(shape_0.method_25().method_75() / 72);
			@class.TopMargin = textFrame.TopMarginPt * (double)(shape_0.method_25().method_76() / 72);
			@class.RightMargin = textFrame.RightMarginPt * (double)(shape_0.method_25().method_76() / 72);
			@class.BottomMargin = textFrame.BottomMarginPt * (double)(shape_0.method_25().method_76() / 72);
		}
		else
		{
			@class.LeftMargin = textFrame.LeftMarginPt * (double)(shape_0.method_25().method_75() / 72);
			@class.TopMargin = textFrame.TopMarginPt * (double)(shape_0.method_25().method_76() / 72);
			@class.RightMargin = textFrame.RightMarginPt * (double)(shape_0.method_25().method_76() / 72);
			@class.BottomMargin = textFrame.BottomMarginPt * (double)(shape_0.method_25().method_76() / 72);
		}
		class913_0.method_5(@class);
		if (class913_0.Type == Enum121.const_0 || shape_0.IsHidden)
		{
			return;
		}
		int[] array = shape_0.method_67(shape_0.Rotation);
		if (!smethod_8(shape_0))
		{
			return;
		}
		if (!shape_0.method_33())
		{
			class913_0.X = shape_0.Left;
			class913_0.Y = shape_0.Top;
		}
		else
		{
			_ = (Shape)shape_0.method_13();
			float[] array2 = smethod_2(shape_0);
			class913_0.X = array2[0];
			class913_0.Y = array2[1];
		}
		if (!shape_0.method_33())
		{
			if (shape_0.AutoShapeType != AutoShapeType.Line && shape_0.AutoShapeType != AutoShapeType.StraightConnector)
			{
				class913_0.Width = array[2];
				class913_0.Height = array[3];
			}
			else
			{
				class913_0.Width = shape_0.Width;
				class913_0.Height = shape_0.Height;
			}
		}
		else
		{
			class913_0.Width = shape_0.Width;
			class913_0.Height = shape_0.Height;
		}
		class913_0.bool_6 = shape_0.method_30();
		class913_0.AutoShapeType = shape_0.AutoShapeType;
		class913_0.method_1(shape_0.method_25().Workbook);
		class913_0.method_2(shape_0.method_26());
		class913_0.method_0(shape_0.bool_0);
		switch (shape_0.MsoDrawingType)
		{
		case MsoDrawingType.Group:
		{
			GroupShape groupShape = (GroupShape)shape_0;
			ArrayList arrayList = new ArrayList();
			Shape[] groupedShapes = groupShape.GetGroupedShapes();
			foreach (Shape shape in groupedShapes)
			{
				if (arrayList.Count == 0)
				{
					arrayList.Add(shape);
					continue;
				}
				bool flag = false;
				for (int k = 0; k < arrayList.Count; k++)
				{
					Shape shape2 = (Shape)arrayList[k];
					if (shape2.ZOrderPosition > shape.ZOrderPosition)
					{
						arrayList.Insert(k, shape);
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					arrayList.Add(shape);
				}
			}
			for (int l = 0; l < arrayList.Count; l++)
			{
				Shape shape3 = (Shape)arrayList[l];
				Class913 class2 = new Class913(smethod_22(shape3.MsoDrawingType));
				class2.class913_0 = class913_0;
				class2.bool_4 = true;
				if (shape3.MsoDrawingType == MsoDrawingType.Chart)
				{
					class2.bool_5 = true;
					class2.chart_0 = ((ChartShape)arrayList[l]).method_69();
				}
				smethod_3(shape3, class2);
				class913_0.arrayList_1.Add(class2);
			}
			break;
		}
		case MsoDrawingType.Line:
		{
			LineShape lineShape_ = (LineShape)shape_0;
			smethod_16(lineShape_, class913_0);
			smethod_20(shape_0, class913_0);
			break;
		}
		case MsoDrawingType.Rectangle:
		{
			RectangleShape rectangleShape = (RectangleShape)shape_0;
			smethod_19(rectangleShape.method_63(), class913_0);
			smethod_34(shape_0, class913_0);
			break;
		}
		case MsoDrawingType.Oval:
		{
			Oval oval = (Oval)shape_0;
			smethod_19(oval.method_63(), class913_0);
			break;
		}
		case MsoDrawingType.Arc:
			class913_0.shape_0 = shape_0;
			smethod_20(shape_0, class913_0);
			smethod_18((ArcShape)shape_0, class913_0);
			smethod_19(shape_0.method_63(), class913_0);
			smethod_7(shape_0, class913_0);
			smethod_34(shape_0, class913_0);
			break;
		case MsoDrawingType.TextBox:
		{
			TextBox textBox = (TextBox)shape_0;
			smethod_19(textBox.method_63(), class913_0);
			smethod_34(shape_0, class913_0);
			break;
		}
		case MsoDrawingType.Button:
		{
			Button button = (Button)shape_0;
			smethod_19(button.method_63(), class913_0);
			break;
		}
		case MsoDrawingType.CheckBox:
		{
			CheckBox checkBox = (CheckBox)shape_0;
			smethod_19(checkBox.method_63(), class913_0);
			class913_0.method_15(smethod_28(checkBox.CheckedValue));
			break;
		}
		case MsoDrawingType.RadioButton:
		{
			RadioButton radioButton = (RadioButton)shape_0;
			smethod_19(radioButton.method_63(), class913_0);
			if (radioButton.IsChecked)
			{
				class913_0.method_15(Enum120.const_1);
			}
			else
			{
				class913_0.method_15(Enum120.const_0);
			}
			break;
		}
		case MsoDrawingType.Label:
		{
			Label label = (Label)shape_0;
			smethod_19(label.method_63(), class913_0);
			break;
		}
		case MsoDrawingType.ListBox:
		{
			ListBox listBox = (ListBox)shape_0;
			if (listBox.InputRange != null && listBox.InputRange != "")
			{
				for (int m = listBox.CellArea.StartRow; m <= listBox.CellArea.EndRow; m++)
				{
					string stringValue2 = listBox.method_26().Cells.GetCell(m, listBox.CellArea.StartColumn, bool_2: false).StringValue;
					class913_0.method_16().Add(stringValue2);
				}
				if (listBox.method_72() != null)
				{
					class913_0.method_19(listBox.method_72());
				}
			}
			break;
		}
		case MsoDrawingType.GroupBox:
		{
			GroupBox groupBox = (GroupBox)shape_0;
			smethod_19(groupBox.method_63(), class913_0);
			break;
		}
		case MsoDrawingType.ComboBox:
		{
			ComboBox comboBox = (ComboBox)shape_0;
			if (comboBox.InputRange != null && comboBox.InputRange != "")
			{
				for (int i = comboBox.CellArea.StartRow; i <= comboBox.CellArea.EndRow; i++)
				{
					string stringValue = comboBox.method_26().Cells.GetCell(i, comboBox.CellArea.StartColumn, bool_2: false).StringValue;
					class913_0.method_16().Add(stringValue);
				}
				if (comboBox.SelectedValue != null)
				{
					class913_0.method_20(comboBox.SelectedValue);
				}
			}
			break;
		}
		case MsoDrawingType.Picture:
		case MsoDrawingType.OleObject:
			class913_0.shape_0 = shape_0;
			break;
		case MsoDrawingType.Comment:
		{
			CommentShape commentShape = (CommentShape)shape_0;
			smethod_19(commentShape.method_69().method_2(), class913_0);
			break;
		}
		case MsoDrawingType.Unknown:
			class913_0.shape_0 = shape_0;
			smethod_20(shape_0, class913_0);
			smethod_19(shape_0.method_63(), class913_0);
			smethod_7(shape_0, class913_0);
			smethod_34(shape_0, class913_0);
			break;
		case MsoDrawingType.CellsDrawing:
			class913_0.shape_0 = shape_0;
			smethod_20(shape_0, class913_0);
			smethod_17((CellsDrawing)shape_0, class913_0);
			smethod_7(shape_0, class913_0);
			smethod_19(shape_0.method_63(), class913_0);
			smethod_34(shape_0, class913_0);
			smethod_5(shape_0, class913_0);
			break;
		}
		smethod_10(shape_0, class913_0);
		smethod_15(shape_0, class913_0);
		smethod_4(shape_0, class913_0);
	}

	private static void smethod_4(Shape shape_0, Class913 class913_0)
	{
		class913_0.method_24(shape_0.method_27().method_9().method_11());
		class913_0.method_22(shape_0.method_27().method_9().method_9());
	}

	private static void smethod_5(Shape shape_0, Class913 class913_0)
	{
		ArrayList pathList = shape_0.PathsInfo.PathList;
		Class903 @class = new Class903();
		ArrayList arrayList = null;
		ArrayList arrayList2 = new ArrayList();
		if (pathList.Count == 0)
		{
			return;
		}
		foreach (GeomPathInfo item in pathList)
		{
			if (!item.bool_1)
			{
				continue;
			}
			ArrayList arrayList3 = new ArrayList();
			if (arrayList3.Count > 0)
			{
				arrayList3.Clear();
			}
			Class902 class2 = new Class902();
			Class907 class3 = null;
			arrayList = item.PathSegementList;
			foreach (MsoPathInfo item2 in arrayList)
			{
				class3 = new Class907();
				class3.Type = smethod_6(item2.Type);
				class3.method_0(item2.PointList);
				arrayList3.Add(class3);
			}
			class2.method_0(arrayList3);
			class2.Width = item.long_1;
			class2.Height = item.long_0;
			arrayList2.Add(class2);
		}
		@class.method_1(arrayList2);
		class913_0.method_4(@class);
	}

	private static Enum119 smethod_6(MsoPathType msoPathType_0)
	{
		return msoPathType_0 switch
		{
			MsoPathType.MsopathLineTo => Enum119.const_0, 
			MsoPathType.MsopathCurveTo => Enum119.const_1, 
			MsoPathType.MsopathMoveTo => Enum119.const_2, 
			MsoPathType.MsopathClose => Enum119.const_3, 
			MsoPathType.MsopathEnd => Enum119.const_4, 
			MsoPathType.MsopathArcTo => Enum119.const_5, 
			_ => Enum119.const_6, 
		};
	}

	private static void smethod_7(Shape shape_0, Class913 class913_0)
	{
		if (shape_0.method_10() == null)
		{
			return;
		}
		Class1245 @class = shape_0.method_10();
		if (@class.method_0() == null)
		{
			return;
		}
		foreach (Class1244 item in @class.method_0())
		{
			string text = item.string_1.ToLower();
			if (!text.StartsWith("val"))
			{
				continue;
			}
			string text2 = text.Substring(4).Trim();
			if (Class1677.smethod_19(text2))
			{
				if (class913_0.class901_0 == null)
				{
					class913_0.class901_0 = new Class901();
				}
				class913_0.class901_0.arrayList_0.Add(int.Parse(text2));
			}
		}
	}

	private static bool smethod_8(Shape shape_0)
	{
		switch (shape_0.AutoShapeType)
		{
		default:
			if (shape_0.Width <= 0 || shape_0.Height <= 0)
			{
				return false;
			}
			goto IL_005d;
		case AutoShapeType.NotPrimitive:
		case AutoShapeType.Line:
		case AutoShapeType.StraightConnector:
		case AutoShapeType.ElbowConnector:
			{
				if (shape_0.Width == 0 && shape_0.Height == 0)
				{
					return false;
				}
				if (shape_0.Width < 0 || shape_0.Height < 0)
				{
					break;
				}
				goto IL_005d;
			}
			IL_005d:
			return true;
		}
		return false;
	}

	private static Color smethod_9(double double_0, Color color_0)
	{
		return Color.FromArgb((int)((1.0 - double_0) * 255.0), color_0);
	}

	private static void smethod_10(Shape shape_0, Class913 class913_0)
	{
		FillFormat fill = shape_0.Fill;
		Class899 fillFormat = class913_0.Fill.FillFormat;
		class913_0.Fill.method_4(fillFormat);
		switch (shape_0.Fill.Type)
		{
		case FillType.Automatic:
			class913_0.Fill.method_1(bool_1: false);
			if (shape_0.Style == null)
			{
				class913_0.Fill.method_1(bool_1: true);
				class913_0.Fill.method_4(null);
				break;
			}
			if (shape_0.Style.class1111_2 != null && Convert.ToInt32(shape_0.Style.class1111_2.string_0) != 0)
			{
				class913_0.Fill.method_3(smethod_9(0.0, shape_0.Style.class1111_2.internalColor_0.method_6(shape_0.method_25().Workbook)));
			}
			class913_0.Fill.method_4(null);
			break;
		case FillType.None:
			class913_0.Fill.method_1(bool_1: true);
			break;
		case FillType.Solid:
			class913_0.Fill.method_1(bool_1: false);
			class913_0.Fill.method_3(smethod_9(fill.SolidFill.Transparency, fill.SolidFill.Color));
			class913_0.Fill.method_4(null);
			break;
		case FillType.Gradient:
			class913_0.Fill.method_1(bool_1: false);
			smethod_13(shape_0, fillFormat.method_0());
			break;
		case FillType.Texture:
			class913_0.Fill.method_1(bool_1: false);
			smethod_14(shape_0.Fill, fillFormat.TextureFill);
			if (fill.TextureFill.ImageData != null)
			{
				byte[] imageData = fill.TextureFill.ImageData;
				MemoryStream stream = new MemoryStream(imageData);
				Image image_ = Image.FromStream(stream);
				GraphicsPath graphicsPath = new GraphicsPath();
				graphicsPath.AddRectangle(class913_0.method_8());
				fillFormat.method_1(image_, graphicsPath);
			}
			break;
		case FillType.Pattern:
			class913_0.Fill.method_1(bool_1: true);
			break;
		}
	}

	internal static Enum16 smethod_11(GradientFillType gradientFillType_0)
	{
		return gradientFillType_0 switch
		{
			GradientFillType.Linear => Enum16.const_0, 
			GradientFillType.Radial => Enum16.const_2, 
			GradientFillType.Path => Enum16.const_3, 
			_ => Enum16.const_1, 
		};
	}

	internal static Enum15 smethod_12(GradientDirectionType gradientDirectionType_0)
	{
		return gradientDirectionType_0 switch
		{
			GradientDirectionType.FromUpperLeftCorner => Enum15.const_0, 
			GradientDirectionType.FromUpperRightCorner => Enum15.const_1, 
			GradientDirectionType.FromLowerLeftCorner => Enum15.const_2, 
			GradientDirectionType.FromLowerRightCorner => Enum15.const_3, 
			GradientDirectionType.FromCenter => Enum15.const_4, 
			_ => Enum15.const_5, 
		};
	}

	private static void smethod_13(Shape shape_0, Class309 class309_0)
	{
		if (shape_0.Fill.GradientFill != null)
		{
			Workbook workbook = shape_0.method_25().Workbook;
			GradientFill gradientFill = shape_0.Fill.GradientFill;
			class309_0.Angle = gradientFill.Angle;
			class309_0.method_0(smethod_11(gradientFill.FillType));
			class309_0.method_1(smethod_12(gradientFill.DirectionType));
			for (int i = 0; i < gradientFill.GradientStops.Count; i++)
			{
				GradientStop gradientStop = gradientFill.GradientStops[i];
				int num = gradientStop.internalColor_0.method_7(workbook);
				int red = num & 0xFF;
				int green = (num & 0xFF00) >> 8;
				int blue = (num & 0xFF0000) >> 16;
				Color.FromArgb(gradientStop.method_2() * 255 / 100, red, green, blue);
				red = gradientStop.CellsColor.Color.R;
				green = gradientStop.CellsColor.Color.G;
				blue = gradientStop.CellsColor.Color.B;
				Color color_ = Color.FromArgb(gradientStop.method_2() * 255 / 100, red, green, blue);
				class309_0.GradientStops.Add(color_, (float)gradientStop.Position);
			}
		}
	}

	private static void smethod_14(FillFormat fillFormat_0, Class313 class313_0)
	{
		TextureFill textureFill = fillFormat_0.TextureFill;
		if (textureFill != null)
		{
			class313_0.method_0(textureFill.method_3());
			if (textureFill.method_3())
			{
				class313_0.OffsetX = textureFill.TilePicOption.OffsetX;
				class313_0.OffsetY = textureFill.TilePicOption.OffsetY;
				class313_0.ScaleX = textureFill.TilePicOption.ScaleX;
				class313_0.ScaleY = textureFill.TilePicOption.ScaleY;
				class313_0.method_1(smethod_29(textureFill.TilePicOption.AlignmentType));
				class313_0.MirrorType = smethod_30(textureFill.TilePicOption.MirrorType);
			}
			else
			{
				class313_0.method_2(smethod_31(textureFill.PicFormatOption.Type));
				class313_0.method_3(textureFill.PicFormatOption.Left);
				class313_0.method_4(textureFill.PicFormatOption.Right);
				class313_0.method_5(textureFill.PicFormatOption.Top);
				class313_0.method_6(textureFill.PicFormatOption.Bottom);
				class313_0.method_8(textureFill.PicFormatOption.Scale);
			}
		}
	}

	private static void smethod_15(Shape shape_0, Class913 class913_0)
	{
		class913_0.Line.method_1(!shape_0.LineFormat.IsVisible);
		if (shape_0.LineFormat.IsVisible)
		{
			MsoLineFormat lineFormat = shape_0.LineFormat;
			class913_0.Line.DashStyle = smethod_23(lineFormat.DashStyle);
			class913_0.Line.Style = smethod_24(lineFormat.Style);
			class913_0.Line.Weight = (int)(lineFormat.Weight * (double)shape_0.method_25().method_76() / 72.0 + 0.5);
			if (class913_0.Line.Weight < 1f)
			{
				class913_0.Line.Weight = 1f;
			}
			_ = lineFormat.Weight;
			class913_0.Line.ForeColor = smethod_9(lineFormat.Transparency, lineFormat.ForeColor);
		}
	}

	private static void smethod_16(LineShape lineShape_0, Class913 class913_0)
	{
		class913_0.Line.method_3(smethod_25(lineShape_0.BeginArrowheadStyle));
		class913_0.Line.method_7(smethod_26(lineShape_0.BeginArrowheadLength));
		class913_0.Line.method_5(smethod_27(lineShape_0.BeginArrowheadWidth));
		class913_0.Line.method_9(smethod_25(lineShape_0.EndArrowheadStyle));
		class913_0.Line.method_13(smethod_26(lineShape_0.EndArrowheadLength));
		class913_0.Line.method_11(smethod_27(lineShape_0.EndArrowheadWidth));
	}

	private static void smethod_17(CellsDrawing cellsDrawing_0, Class913 class913_0)
	{
		class913_0.Line.method_3(smethod_25(cellsDrawing_0.LineFormat.BeginArrowheadStyle));
		class913_0.Line.method_7(smethod_26(cellsDrawing_0.LineFormat.BeginArrowheadLength));
		class913_0.Line.method_5(smethod_27(cellsDrawing_0.LineFormat.BeginArrowheadWidth));
		class913_0.Line.method_9(smethod_25(cellsDrawing_0.LineFormat.EndArrowheadStyle));
		class913_0.Line.method_13(smethod_26(cellsDrawing_0.LineFormat.EndArrowheadLength));
		class913_0.Line.method_11(smethod_27(cellsDrawing_0.LineFormat.EndArrowheadWidth));
	}

	private static void smethod_18(ArcShape arcShape_0, Class913 class913_0)
	{
		class913_0.Line.method_3(smethod_25(arcShape_0.LineFormat.BeginArrowheadStyle));
		class913_0.Line.method_7(smethod_26(arcShape_0.LineFormat.BeginArrowheadLength));
		class913_0.Line.method_5(smethod_27(arcShape_0.LineFormat.BeginArrowheadWidth));
		class913_0.Line.method_9(smethod_25(arcShape_0.LineFormat.EndArrowheadStyle));
		class913_0.Line.method_13(smethod_26(arcShape_0.LineFormat.EndArrowheadLength));
		class913_0.Line.method_11(smethod_27(arcShape_0.LineFormat.EndArrowheadWidth));
	}

	private static void smethod_19(Class1737 class1737_0, Class913 class913_0)
	{
		if (class1737_0.Text == null || class1737_0.Text == "")
		{
			return;
		}
		class913_0.Text = class1737_0.Text;
		if (class1737_0.method_5() != null)
		{
			class913_0.Font = smethod_21(class1737_0.Font);
			class913_0.FontColor = Color.FromArgb(255, class1737_0.Font.Color);
		}
		class913_0.TextHorizontalAlignment = smethod_32(class1737_0.TextHorizontalAlignment);
		class913_0.TextVerticalAlignment = smethod_32(class1737_0.TextVerticalAlignment);
		class913_0.method_10(smethod_33(class1737_0.TextOrientationType));
		class913_0.method_12(class1737_0.method_0());
		if (!class1737_0.method_14())
		{
			return;
		}
		ArrayList characters = class1737_0.GetCharacters();
		if (characters.Count == 1)
		{
			FontSetting fontSetting = (FontSetting)characters[0];
			class1737_0.Text.Substring(fontSetting.StartIndex, fontSetting.Length);
			Aspose.Cells.Font font = ((fontSetting.method_2() == null) ? class1737_0.Font : fontSetting.Font);
			class913_0.Font = smethod_21(font);
			class913_0.FontColor = Color.FromArgb(255, font.Color);
			return;
		}
		for (int i = 0; i < characters.Count; i++)
		{
			FontSetting fontSetting2 = (FontSetting)characters[i];
			string string_ = class1737_0.Text.Substring(fontSetting2.StartIndex, fontSetting2.Length);
			Aspose.Cells.Font font2 = ((fontSetting2.method_2() == null) ? class1737_0.Font : fontSetting2.Font);
			System.Drawing.Font font_ = smethod_21(font2);
			class913_0.FontColor = Color.FromArgb(255, font2.Color);
			Class909 value = new Class909(string_, font_, Color.FromArgb(255, font2.Color), Enum125.const_2);
			class913_0.method_13().Add(value);
		}
	}

	private static void smethod_20(Shape shape_0, Class913 class913_0)
	{
		AutoShapeType autoShapeType = shape_0.AutoShapeType;
		if (autoShapeType != AutoShapeType.Line && autoShapeType != AutoShapeType.StraightConnector)
		{
			if (!shape_0.method_27().method_9().method_9() && !shape_0.method_27().method_9().method_11())
			{
				class913_0.int_3 = 1;
			}
			else if (shape_0.method_27().method_9().method_9() && shape_0.method_27().method_9().method_11())
			{
				class913_0.int_3 = 3;
			}
			else if (shape_0.method_27().method_9().method_9() && !shape_0.method_27().method_9().method_11())
			{
				class913_0.int_3 = 2;
			}
			else
			{
				class913_0.int_3 = 4;
			}
		}
		else if (shape_0.RotationAngle == 0.0 && !shape_0.method_27().method_9().method_9() && !shape_0.method_27().method_9().method_11())
		{
			class913_0.int_3 = 1;
		}
		else if (shape_0.RotationAngle == 0.0 && shape_0.method_27().method_9().method_9() && !shape_0.method_27().method_9().method_11())
		{
			class913_0.int_3 = 2;
		}
		else if (shape_0.RotationAngle == 180.0 && shape_0.method_27().method_9().method_9() && !shape_0.method_27().method_9().method_11())
		{
			class913_0.int_3 = 4;
		}
		else if (shape_0.RotationAngle == 180.0 && !shape_0.method_27().method_9().method_9() && !shape_0.method_27().method_9().method_11())
		{
			class913_0.int_3 = 3;
		}
		else if (shape_0.RotationAngle == 270.0 && !shape_0.method_27().method_9().method_9() && shape_0.method_27().method_9().method_11())
		{
			class913_0.int_3 = 1;
		}
		else if (shape_0.RotationAngle == 90.0 && shape_0.method_27().method_9().method_9() && shape_0.method_27().method_9().method_11())
		{
			class913_0.int_3 = 2;
		}
		else if (shape_0.RotationAngle == 90.0 && !shape_0.method_27().method_9().method_9() && !shape_0.method_27().method_9().method_11())
		{
			class913_0.int_3 = 4;
		}
		else if (shape_0.RotationAngle == 270.0 && shape_0.method_27().method_9().method_9() && !shape_0.method_27().method_9().method_11())
		{
			class913_0.int_3 = 3;
		}
		else if (shape_0.RotationAngle == 0.0 && !shape_0.method_27().method_9().method_9() && shape_0.method_27().method_9().method_11())
		{
			class913_0.int_3 = 4;
		}
		else if (shape_0.RotationAngle == 0.0 && shape_0.method_27().method_9().method_9() && shape_0.method_27().method_9().method_11())
		{
			class913_0.int_3 = 3;
		}
	}

	internal static System.Drawing.Font smethod_21(Aspose.Cells.Font font_0)
	{
		FontStyle fontStyle = FontStyle.Regular;
		if (font_0.IsBold)
		{
			fontStyle |= FontStyle.Bold;
		}
		if (font_0.IsItalic)
		{
			fontStyle |= FontStyle.Italic;
		}
		if (font_0.IsStrikeout)
		{
			fontStyle |= FontStyle.Strikeout;
		}
		if (font_0.Underline != 0)
		{
			fontStyle |= FontStyle.Underline;
		}
		double doubleSize = font_0.DoubleSize;
		return new System.Drawing.Font(font_0.Name, (float)doubleSize, fontStyle);
	}

	internal static Enum121 smethod_22(MsoDrawingType msoDrawingType_0)
	{
		return msoDrawingType_0 switch
		{
			MsoDrawingType.Group => Enum121.const_1, 
			MsoDrawingType.Line => Enum121.const_2, 
			MsoDrawingType.Rectangle => Enum121.const_3, 
			MsoDrawingType.Oval => Enum121.const_4, 
			MsoDrawingType.Chart => Enum121.const_6, 
			MsoDrawingType.TextBox => Enum121.const_7, 
			MsoDrawingType.Button => Enum121.const_8, 
			MsoDrawingType.Picture => Enum121.const_9, 
			MsoDrawingType.CheckBox => Enum121.const_11, 
			MsoDrawingType.RadioButton => Enum121.const_12, 
			MsoDrawingType.Label => Enum121.const_13, 
			MsoDrawingType.ListBox => Enum121.const_17, 
			MsoDrawingType.GroupBox => Enum121.const_18, 
			MsoDrawingType.ComboBox => Enum121.const_19, 
			MsoDrawingType.OleObject => Enum121.const_21, 
			MsoDrawingType.Comment => Enum121.const_20, 
			MsoDrawingType.Unknown => Enum121.const_23, 
			MsoDrawingType.CellsDrawing => Enum121.const_22, 
			_ => Enum121.const_22, 
		};
	}

	private static Enum116 smethod_23(MsoLineDashStyle msoLineDashStyle_0)
	{
		return msoLineDashStyle_0 switch
		{
			MsoLineDashStyle.Dash => Enum116.const_0, 
			MsoLineDashStyle.DashDot => Enum116.const_1, 
			MsoLineDashStyle.DashDotDot => Enum116.const_4, 
			MsoLineDashStyle.DashLongDash => Enum116.const_2, 
			MsoLineDashStyle.DashLongDashDot => Enum116.const_3, 
			MsoLineDashStyle.RoundDot => Enum116.const_5, 
			MsoLineDashStyle.Solid => Enum116.const_6, 
			MsoLineDashStyle.SquareDot => Enum116.const_7, 
			_ => Enum116.const_6, 
		};
	}

	private static Enum118 smethod_24(MsoLineStyle msoLineStyle_0)
	{
		return msoLineStyle_0 switch
		{
			MsoLineStyle.Single => Enum118.const_0, 
			MsoLineStyle.ThickBetweenThin => Enum118.const_1, 
			MsoLineStyle.ThinThick => Enum118.const_2, 
			MsoLineStyle.ThickThin => Enum118.const_3, 
			MsoLineStyle.ThinThin => Enum118.const_4, 
			_ => Enum118.const_0, 
		};
	}

	private static Enum114 smethod_25(MsoArrowheadStyle msoArrowheadStyle_0)
	{
		return msoArrowheadStyle_0 switch
		{
			MsoArrowheadStyle.Arrow => Enum114.const_1, 
			MsoArrowheadStyle.ArrowStealth => Enum114.const_2, 
			MsoArrowheadStyle.ArrowDiamond => Enum114.const_3, 
			MsoArrowheadStyle.ArrowOval => Enum114.const_4, 
			MsoArrowheadStyle.ArrowOpen => Enum114.const_5, 
			_ => Enum114.const_0, 
		};
	}

	private static Enum113 smethod_26(MsoArrowheadLength msoArrowheadLength_0)
	{
		return msoArrowheadLength_0 switch
		{
			MsoArrowheadLength.Short => Enum113.const_0, 
			MsoArrowheadLength.Medium => Enum113.const_1, 
			MsoArrowheadLength.Long => Enum113.const_2, 
			_ => Enum113.const_0, 
		};
	}

	private static Enum115 smethod_27(MsoArrowheadWidth msoArrowheadWidth_0)
	{
		return msoArrowheadWidth_0 switch
		{
			MsoArrowheadWidth.Narrow => Enum115.const_0, 
			MsoArrowheadWidth.Medium => Enum115.const_1, 
			MsoArrowheadWidth.Wide => Enum115.const_2, 
			_ => Enum115.const_0, 
		};
	}

	private static Enum120 smethod_28(CheckValueType checkValueType_0)
	{
		return checkValueType_0 switch
		{
			CheckValueType.UnChecked => Enum120.const_0, 
			CheckValueType.Checked => Enum120.const_1, 
			CheckValueType.Mixed => Enum120.const_2, 
			_ => Enum120.const_0, 
		};
	}

	private static Enum13 smethod_29(RectangleAlignmentType rectangleAlignmentType_0)
	{
		return rectangleAlignmentType_0 switch
		{
			RectangleAlignmentType.Bottom => Enum13.const_0, 
			RectangleAlignmentType.BottomLeft => Enum13.const_0, 
			RectangleAlignmentType.BottomRight => Enum13.const_0, 
			RectangleAlignmentType.Center => Enum13.const_2, 
			RectangleAlignmentType.Left => Enum13.const_4, 
			RectangleAlignmentType.Right => Enum13.const_5, 
			RectangleAlignmentType.Top => Enum13.const_6, 
			RectangleAlignmentType.TopRight => Enum13.const_8, 
			_ => Enum13.const_7, 
		};
	}

	private static Enum14 smethod_30(MirrorType mirrorType_0)
	{
		return mirrorType_0 switch
		{
			MirrorType.Horizonal => Enum14.const_1, 
			MirrorType.Vertical => Enum14.const_2, 
			MirrorType.Both => Enum14.const_3, 
			_ => Enum14.const_0, 
		};
	}

	private static Enum12 smethod_31(FillPictureType fillPictureType_0)
	{
		return fillPictureType_0 switch
		{
			FillPictureType.Stack => Enum12.const_1, 
			FillPictureType.StackAndScale => Enum12.const_2, 
			_ => Enum12.const_0, 
		};
	}

	internal static Enum104 smethod_32(TextAlignmentType textAlignmentType_0)
	{
		return textAlignmentType_0 switch
		{
			TextAlignmentType.Bottom => Enum104.const_0, 
			TextAlignmentType.Center => Enum104.const_1, 
			TextAlignmentType.CenterAcross => Enum104.const_2, 
			TextAlignmentType.Distributed => Enum104.const_3, 
			TextAlignmentType.Fill => Enum104.const_4, 
			TextAlignmentType.General => Enum104.const_5, 
			TextAlignmentType.Justify => Enum104.const_6, 
			TextAlignmentType.Left => Enum104.const_7, 
			TextAlignmentType.Right => Enum104.const_8, 
			TextAlignmentType.Top => Enum104.const_9, 
			_ => Enum104.const_1, 
		};
	}

	internal static Enum107 smethod_33(TextOrientationType textOrientationType_0)
	{
		return textOrientationType_0 switch
		{
			TextOrientationType.ClockWise => Enum107.const_0, 
			TextOrientationType.CounterClockWise => Enum107.const_1, 
			TextOrientationType.NoRotation => Enum107.const_2, 
			TextOrientationType.TopToBottom => Enum107.const_3, 
			_ => Enum107.const_2, 
		};
	}

	private static void smethod_34(Shape shape_0, Class913 class913_0)
	{
		class913_0.Rotation = (int)shape_0.RotationAngle;
	}
}
