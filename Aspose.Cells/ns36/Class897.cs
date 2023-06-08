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
using ns19;
using ns2;
using ns21;
using ns35;
using ns5;
using ns52;

namespace ns36;

internal class Class897
{
	internal static RectangleF Calculate(Shape shape_0)
	{
		if (shape_0.MsoDrawingType == MsoDrawingType.Chart)
		{
			Chart chart = ((ChartShape)shape_0).method_69();
			return new RectangleF(chart.ChartObject.Left, chart.ChartObject.Top, chart.ChartObject.Width, chart.ChartObject.Height);
		}
		Class898 @class = new Class898(smethod_21(shape_0.MsoDrawingType));
		smethod_3(shape_0, @class);
		@class.method_25();
		return @class.method_27();
	}

	internal static PointF smethod_0(Stream stream_0, ImageOrPrintOptions imageOrPrintOptions_0, Shape shape_0)
	{
		if (shape_0.MsoDrawingType == MsoDrawingType.Chart)
		{
			Chart chart = ((ChartShape)shape_0).method_69();
			chart.ToImage(stream_0, imageOrPrintOptions_0);
			return new PointF(0f, 0f);
		}
		Class898 @class = new Class898(smethod_21(shape_0.MsoDrawingType));
		smethod_3(shape_0, @class);
		if (!@class.bool_3)
		{
			@class.X = 0f;
			@class.Y = 0f;
		}
		if (!@class.method_26())
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
		Class898 @class = new Class898(smethod_21(shape_0.MsoDrawingType));
		smethod_3(shape_0, @class);
		if (!@class.bool_3)
		{
			@class.X = 0f;
			@class.Y = 0f;
		}
		if (@class.method_26())
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
		Class898 @class = new Class898(smethod_21(shape_0.MsoDrawingType));
		smethod_3(shape_0, @class);
		if (!@class.bool_3)
		{
			@class.X = 0f;
			@class.Y = 0f;
		}
		if (!@class.method_26())
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
		Class898 @class = new Class898(smethod_21(shape_0.MsoDrawingType));
		smethod_3(shape_0, @class);
		if (!@class.bool_3)
		{
			@class.X = 0f;
			@class.Y = 0f;
		}
		if (@class.method_26())
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
		Class898 @class = new Class898(smethod_21(shape_0.MsoDrawingType));
		smethod_3(shape_0, @class);
		if (!@class.bool_3)
		{
			@class.X = 0f;
			@class.Y = 0f;
		}
		if (!@class.method_26())
		{
			return null;
		}
		ImageFormat bmp = ImageFormat.Bmp;
		return smethod_1(shape_0, @class, null, bmp, imageOrPrintOptions_0)?.imethod_3();
	}

	private static Interface42 smethod_1(Shape shape_0, Class898 class898_0, Stream stream_0, ImageFormat imageFormat_0, ImageOrPrintOptions imageOrPrintOptions_0)
	{
		int int_ = Class1036.int_0;
		return Class1036.smethod_0(int_, (int)Math.Ceiling(class898_0.method_22().Width), (int)Math.Ceiling(class898_0.method_22().Height), imageFormat_0, imageOrPrintOptions_0, stream_0, class898_0);
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

	internal static void smethod_3(Shape shape_0, Class898 class898_0)
	{
		MsoTextFrame textFrame = shape_0.TextFrame;
		Class158 @class = new Class158();
		if (!shape_0.TextFrame.IsAutoMargin)
		{
			@class.LeftMargin = textFrame.LeftMarginPt * (double)(shape_0.method_25().method_75() / 72);
			@class.TopMargin = textFrame.TopMarginPt * (double)(shape_0.method_25().method_76() / 72);
			@class.RightMargin = textFrame.RightMarginPt * (double)(shape_0.method_25().method_76() / 72);
			@class.BottomMargin = textFrame.BottomMarginPt * (double)(shape_0.method_25().method_76() / 72);
		}
		else
		{
			@class.LeftMargin = 0.0;
			@class.TopMargin = 0.0;
			@class.RightMargin = 0.0;
			@class.BottomMargin = 0.0;
		}
		class898_0.method_6(@class);
		if (class898_0.Type == Enum103.const_0 || !smethod_5(shape_0) || shape_0.IsHidden)
		{
			return;
		}
		int[] array = shape_0.method_67(shape_0.Rotation);
		if (!shape_0.method_33())
		{
			class898_0.X = shape_0.Left;
			class898_0.Y = shape_0.Top;
		}
		else
		{
			_ = (Shape)shape_0.method_13();
			float[] array2 = smethod_2(shape_0);
			class898_0.X = array2[0];
			class898_0.Y = array2[1];
		}
		if (shape_0.Type != AutoShapeType.Line && shape_0.Type != AutoShapeType.StraightConnector && shape_0.Type != 0)
		{
			class898_0.Width = array[2];
			class898_0.Height = array[3];
		}
		else
		{
			class898_0.Width = shape_0.Width;
			class898_0.Height = shape_0.Height;
		}
		class898_0.bool_5 = shape_0.method_30();
		class898_0.AutoShapeType = shape_0.AutoShapeType;
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
				Class898 class2 = new Class898(smethod_21(shape3.MsoDrawingType));
				class2.class898_0 = class898_0;
				class2.bool_3 = true;
				if (shape3.MsoDrawingType == MsoDrawingType.Chart)
				{
					class2.bool_4 = true;
					class2.chart_0 = ((ChartShape)arrayList[l]).method_69();
				}
				smethod_3(shape3, class2);
				class898_0.arrayList_1.Add(class2);
			}
			break;
		}
		case MsoDrawingType.Line:
		{
			LineShape lineShape_ = (LineShape)shape_0;
			smethod_16(lineShape_, class898_0);
			smethod_18(shape_0, class898_0);
			break;
		}
		case MsoDrawingType.Rectangle:
		{
			RectangleShape rectangleShape = (RectangleShape)shape_0;
			smethod_17(rectangleShape.method_63(), class898_0);
			smethod_34(shape_0, class898_0);
			break;
		}
		case MsoDrawingType.Oval:
		{
			Oval oval = (Oval)shape_0;
			smethod_17(oval.method_63(), class898_0);
			break;
		}
		case MsoDrawingType.Arc:
			class898_0.shape_0 = shape_0;
			smethod_18(shape_0, class898_0);
			smethod_17(shape_0.method_63(), class898_0);
			smethod_33(shape_0, class898_0);
			smethod_34(shape_0, class898_0);
			break;
		case MsoDrawingType.TextBox:
		{
			TextBox textBox = (TextBox)shape_0;
			smethod_17(textBox.method_63(), class898_0);
			break;
		}
		case MsoDrawingType.Button:
		{
			Button button = (Button)shape_0;
			smethod_17(button.method_63(), class898_0);
			break;
		}
		case MsoDrawingType.Polygon:
			class898_0.shape_0 = shape_0;
			smethod_18(shape_0, class898_0);
			smethod_32((Class1347)shape_0, class898_0);
			smethod_33(shape_0, class898_0);
			smethod_17(shape_0.method_63(), class898_0);
			smethod_34(shape_0, class898_0);
			smethod_35(shape_0, class898_0);
			smethod_38(shape_0, class898_0);
			break;
		case MsoDrawingType.CheckBox:
		{
			CheckBox checkBox = (CheckBox)shape_0;
			smethod_17(checkBox.method_63(), class898_0);
			class898_0.method_12(smethod_27(checkBox.CheckedValue));
			break;
		}
		case MsoDrawingType.RadioButton:
		{
			RadioButton radioButton = (RadioButton)shape_0;
			smethod_17(radioButton.method_63(), class898_0);
			if (radioButton.IsChecked)
			{
				class898_0.method_12(Enum101.const_1);
			}
			else
			{
				class898_0.method_12(Enum101.const_0);
			}
			break;
		}
		case MsoDrawingType.Label:
		{
			Label label = (Label)shape_0;
			smethod_17(label.method_63(), class898_0);
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
					class898_0.method_13().Add(stringValue2);
				}
				if (listBox.method_72() != null)
				{
					class898_0.method_16(listBox.method_72());
				}
			}
			break;
		}
		case MsoDrawingType.GroupBox:
		{
			GroupBox groupBox = (GroupBox)shape_0;
			smethod_17(groupBox.method_63(), class898_0);
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
					class898_0.method_13().Add(stringValue);
				}
				if (comboBox.SelectedValue != null)
				{
					class898_0.method_17(comboBox.SelectedValue);
				}
			}
			break;
		}
		case MsoDrawingType.Picture:
		case MsoDrawingType.OleObject:
			class898_0.shape_0 = shape_0;
			break;
		case MsoDrawingType.Comment:
		{
			CommentShape commentShape = (CommentShape)shape_0;
			smethod_17(commentShape.method_69().method_2(), class898_0);
			break;
		}
		case MsoDrawingType.CellsDrawing:
			class898_0.shape_0 = shape_0;
			smethod_18(shape_0, class898_0);
			smethod_31((CellsDrawing)shape_0, class898_0);
			smethod_33(shape_0, class898_0);
			smethod_17(shape_0.method_63(), class898_0);
			smethod_34(shape_0, class898_0);
			smethod_35(shape_0, class898_0);
			smethod_38(shape_0, class898_0);
			smethod_39(shape_0, class898_0);
			break;
		}
		smethod_7(shape_0, class898_0);
		smethod_15(shape_0, class898_0);
		smethod_4(shape_0, class898_0);
	}

	private static void smethod_4(Shape shape_0, Class898 class898_0)
	{
		class898_0.method_21(shape_0.method_27().method_9().method_11());
		class898_0.method_19(shape_0.method_27().method_9().method_9());
	}

	private static bool smethod_5(Shape shape_0)
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

	private static Color smethod_6(double double_0, Color color_0)
	{
		return Color.FromArgb((int)((1.0 - double_0) * 255.0), color_0);
	}

	private static void smethod_7(Shape shape_0, Class898 class898_0)
	{
		if (!shape_0.FillFormat.IsVisible)
		{
			return;
		}
		FillFormat fill = shape_0.Fill;
		Class883 fillFormat = class898_0.Fill.FillFormat;
		class898_0.Fill.method_4(fillFormat);
		switch (fill.Type)
		{
		case FillType.Automatic:
			class898_0.Fill.method_1(bool_1: false);
			class898_0.Fill.method_3(smethod_6(0.0, Color.White));
			class898_0.Fill.method_4(null);
			break;
		case FillType.None:
			class898_0.Fill.method_1(bool_1: true);
			break;
		case FillType.Solid:
			class898_0.Fill.method_1(bool_1: false);
			class898_0.Fill.method_3(smethod_6(fill.SolidFill.Transparency, fill.SolidFill.Color));
			class898_0.Fill.method_4(null);
			break;
		case FillType.Gradient:
			class898_0.Fill.method_1(bool_1: false);
			smethod_12(shape_0, fillFormat.method_0());
			break;
		case FillType.Texture:
			class898_0.Fill.method_1(bool_1: false);
			smethod_8(fill, fillFormat.TextureFill);
			if (fill.TextureFill.ImageData != null)
			{
				byte[] imageData = fill.TextureFill.ImageData;
				MemoryStream stream = new MemoryStream(imageData);
				Image image_ = Image.FromStream(stream);
				fillFormat.method_6(image_, class898_0.method_7());
			}
			break;
		case FillType.Pattern:
			class898_0.Fill.method_1(bool_1: false);
			fillFormat.method_2(smethod_20(shape_0.FillFormat.ForeColor), smethod_20(shape_0.FillFormat.BackColor), smethod_28(fill.Pattern));
			break;
		}
	}

	private static void smethod_8(FillFormat fillFormat_0, Class159 class159_0)
	{
		TextureFill textureFill = fillFormat_0.TextureFill;
		if (textureFill != null)
		{
			class159_0.method_0(textureFill.method_3());
			if (textureFill.method_3())
			{
				class159_0.OffsetX = textureFill.TilePicOption.OffsetX;
				class159_0.OffsetY = textureFill.TilePicOption.OffsetY;
				class159_0.ScaleX = textureFill.TilePicOption.ScaleX;
				class159_0.ScaleY = textureFill.TilePicOption.ScaleY;
				class159_0.method_1(smethod_11(textureFill.TilePicOption.AlignmentType));
				class159_0.MirrorType = smethod_10(textureFill.TilePicOption.MirrorType);
			}
			else
			{
				class159_0.method_2(smethod_9(textureFill.PicFormatOption.Type));
				class159_0.method_3(textureFill.PicFormatOption.Left);
				class159_0.method_4(textureFill.PicFormatOption.Right);
				class159_0.method_5(textureFill.PicFormatOption.Top);
				class159_0.method_6(textureFill.PicFormatOption.Bottom);
				class159_0.method_8(textureFill.PicFormatOption.Scale);
			}
		}
	}

	private static Enum9 smethod_9(FillPictureType fillPictureType_0)
	{
		return fillPictureType_0 switch
		{
			FillPictureType.Stack => Enum9.const_1, 
			FillPictureType.StackAndScale => Enum9.const_2, 
			_ => Enum9.const_0, 
		};
	}

	private static Enum11 smethod_10(MirrorType mirrorType_0)
	{
		return mirrorType_0 switch
		{
			MirrorType.Horizonal => Enum11.const_1, 
			MirrorType.Vertical => Enum11.const_2, 
			MirrorType.Both => Enum11.const_3, 
			_ => Enum11.const_0, 
		};
	}

	private static Enum10 smethod_11(RectangleAlignmentType rectangleAlignmentType_0)
	{
		return rectangleAlignmentType_0 switch
		{
			RectangleAlignmentType.Bottom => Enum10.const_0, 
			RectangleAlignmentType.BottomLeft => Enum10.const_0, 
			RectangleAlignmentType.BottomRight => Enum10.const_0, 
			RectangleAlignmentType.Center => Enum10.const_2, 
			RectangleAlignmentType.Left => Enum10.const_4, 
			RectangleAlignmentType.Right => Enum10.const_5, 
			RectangleAlignmentType.Top => Enum10.const_6, 
			RectangleAlignmentType.TopRight => Enum10.const_8, 
			_ => Enum10.const_7, 
		};
	}

	private static void smethod_12(Shape shape_0, Class154 class154_0)
	{
		if (shape_0.Fill.GradientFill != null)
		{
			Workbook workbook = shape_0.method_25().Workbook;
			GradientFill gradientFill = shape_0.Fill.GradientFill;
			class154_0.Angle = gradientFill.Angle;
			class154_0.method_0(smethod_13(gradientFill.FillType));
			class154_0.method_1(smethod_14(gradientFill.DirectionType));
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
				class154_0.GradientStops.Add(color_, (float)gradientStop.Position);
			}
		}
	}

	internal static Enum8 smethod_13(GradientFillType gradientFillType_0)
	{
		return gradientFillType_0 switch
		{
			GradientFillType.Linear => Enum8.const_0, 
			GradientFillType.Radial => Enum8.const_2, 
			GradientFillType.Path => Enum8.const_3, 
			_ => Enum8.const_1, 
		};
	}

	internal static Enum7 smethod_14(GradientDirectionType gradientDirectionType_0)
	{
		return gradientDirectionType_0 switch
		{
			GradientDirectionType.FromUpperLeftCorner => Enum7.const_0, 
			GradientDirectionType.FromUpperRightCorner => Enum7.const_1, 
			GradientDirectionType.FromLowerLeftCorner => Enum7.const_2, 
			GradientDirectionType.FromLowerRightCorner => Enum7.const_3, 
			GradientDirectionType.FromCenter => Enum7.const_4, 
			_ => Enum7.const_5, 
		};
	}

	private static void smethod_15(Shape shape_0, Class898 class898_0)
	{
		class898_0.Line.method_1(!shape_0.LineFormat.IsVisible);
		if (shape_0.LineFormat.IsVisible)
		{
			MsoLineFormat lineFormat = shape_0.LineFormat;
			class898_0.Line.DashStyle = smethod_22(lineFormat.DashStyle);
			class898_0.Line.Style = smethod_23(lineFormat.Style);
			class898_0.Line.Weight = (int)(lineFormat.Weight * (double)shape_0.method_25().method_76() / 72.0 + 0.5);
			if (class898_0.Line.Weight < 1f)
			{
				class898_0.Line.Weight = 1f;
			}
			_ = lineFormat.Weight;
			class898_0.Line.ForeColor = smethod_6(lineFormat.Transparency, lineFormat.ForeColor);
		}
	}

	private static void smethod_16(LineShape lineShape_0, Class898 class898_0)
	{
		class898_0.Line.method_3(smethod_24(lineShape_0.BeginArrowheadStyle));
		class898_0.Line.method_7(smethod_25(lineShape_0.BeginArrowheadLength));
		class898_0.Line.method_5(smethod_26(lineShape_0.BeginArrowheadWidth));
		class898_0.Line.method_9(smethod_24(lineShape_0.EndArrowheadStyle));
		class898_0.Line.method_13(smethod_25(lineShape_0.EndArrowheadLength));
		class898_0.Line.method_11(smethod_26(lineShape_0.EndArrowheadWidth));
	}

	private static void smethod_17(Class1737 class1737_0, Class898 class898_0)
	{
		if (class1737_0.Text == null || class1737_0.Text == "")
		{
			return;
		}
		class898_0.Text = class1737_0.Text;
		if (class1737_0.method_5() != null)
		{
			class898_0.Font = smethod_19(class1737_0.Font);
			class898_0.FontColor = Color.FromArgb(255, class1737_0.Font.Color);
		}
		class898_0.TextHorizontalAlignment = smethod_29(class1737_0.TextHorizontalAlignment);
		class898_0.TextVerticalAlignment = smethod_29(class1737_0.TextVerticalAlignment);
		class898_0.method_9(smethod_30(class1737_0.TextOrientationType));
		if (!class1737_0.method_14())
		{
			return;
		}
		ArrayList characters = class1737_0.GetCharacters();
		if (characters.Count == 1)
		{
			FontSetting fontSetting = (FontSetting)characters[0];
			class1737_0.Text.Substring(fontSetting.StartIndex, fontSetting.Length);
			class898_0.Font = smethod_19(fontSetting.Font);
			return;
		}
		for (int i = 0; i < characters.Count; i++)
		{
			FontSetting fontSetting2 = (FontSetting)characters[i];
			string string_ = class1737_0.Text.Substring(fontSetting2.StartIndex, fontSetting2.Length);
			System.Drawing.Font font_ = smethod_19(fontSetting2.Font);
			class898_0.FontColor = Color.FromArgb(255, fontSetting2.Font.Color);
			Class892 value = new Class892(string_, font_, Color.FromArgb(255, fontSetting2.Font.Color), Enum111.const_2);
			class898_0.method_10().Add(value);
		}
	}

	private static void smethod_18(Shape shape_0, Class898 class898_0)
	{
		if (!shape_0.method_27().method_9().method_9() && !shape_0.method_27().method_9().method_11())
		{
			class898_0.int_2 = 1;
		}
		else if (shape_0.method_27().method_9().method_9() && shape_0.method_27().method_9().method_11())
		{
			class898_0.int_2 = 3;
		}
		else if (shape_0.method_27().method_9().method_9() && !shape_0.method_27().method_9().method_11())
		{
			class898_0.int_2 = 2;
		}
		else
		{
			class898_0.int_2 = 4;
		}
	}

	internal static System.Drawing.Font smethod_19(Aspose.Cells.Font font_0)
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

	private static Color smethod_20(Color color_0)
	{
		if (color_0.A == 0)
		{
			return Color.FromArgb(255, color_0);
		}
		return color_0;
	}

	internal static Enum103 smethod_21(MsoDrawingType msoDrawingType_0)
	{
		switch (msoDrawingType_0)
		{
		case MsoDrawingType.Group:
			return Enum103.const_1;
		case MsoDrawingType.Line:
			return Enum103.const_2;
		case MsoDrawingType.Rectangle:
			return Enum103.const_3;
		case MsoDrawingType.Oval:
			return Enum103.const_4;
		case MsoDrawingType.Chart:
			return Enum103.const_6;
		case MsoDrawingType.TextBox:
			return Enum103.const_7;
		case MsoDrawingType.Button:
			return Enum103.const_8;
		case MsoDrawingType.Picture:
			return Enum103.const_9;
		case MsoDrawingType.Polygon:
			return Enum103.const_10;
		case MsoDrawingType.CheckBox:
			return Enum103.const_11;
		case MsoDrawingType.RadioButton:
			return Enum103.const_12;
		case MsoDrawingType.Label:
			return Enum103.const_13;
		case MsoDrawingType.ListBox:
			return Enum103.const_17;
		case MsoDrawingType.GroupBox:
			return Enum103.const_18;
		case MsoDrawingType.ComboBox:
			return Enum103.const_19;
		case MsoDrawingType.OleObject:
			return Enum103.const_21;
		case MsoDrawingType.Comment:
			return Enum103.const_20;
		default:
			return Enum103.const_0;
		case MsoDrawingType.Unknown:
			return Enum103.const_23;
		case MsoDrawingType.Arc:
		case MsoDrawingType.CellsDrawing:
			return Enum103.const_22;
		}
	}

	private static Enum97 smethod_22(MsoLineDashStyle msoLineDashStyle_0)
	{
		return msoLineDashStyle_0 switch
		{
			MsoLineDashStyle.Dash => Enum97.const_0, 
			MsoLineDashStyle.DashDot => Enum97.const_1, 
			MsoLineDashStyle.DashDotDot => Enum97.const_4, 
			MsoLineDashStyle.DashLongDash => Enum97.const_2, 
			MsoLineDashStyle.DashLongDashDot => Enum97.const_3, 
			MsoLineDashStyle.RoundDot => Enum97.const_5, 
			MsoLineDashStyle.Solid => Enum97.const_6, 
			MsoLineDashStyle.SquareDot => Enum97.const_7, 
			_ => Enum97.const_6, 
		};
	}

	private static Enum99 smethod_23(MsoLineStyle msoLineStyle_0)
	{
		return msoLineStyle_0 switch
		{
			MsoLineStyle.Single => Enum99.const_0, 
			MsoLineStyle.ThickBetweenThin => Enum99.const_1, 
			MsoLineStyle.ThinThick => Enum99.const_2, 
			MsoLineStyle.ThickThin => Enum99.const_3, 
			MsoLineStyle.ThinThin => Enum99.const_4, 
			_ => Enum99.const_0, 
		};
	}

	private static Enum95 smethod_24(MsoArrowheadStyle msoArrowheadStyle_0)
	{
		return msoArrowheadStyle_0 switch
		{
			MsoArrowheadStyle.Arrow => Enum95.const_1, 
			MsoArrowheadStyle.ArrowStealth => Enum95.const_2, 
			MsoArrowheadStyle.ArrowDiamond => Enum95.const_3, 
			MsoArrowheadStyle.ArrowOval => Enum95.const_4, 
			MsoArrowheadStyle.ArrowOpen => Enum95.const_5, 
			_ => Enum95.const_0, 
		};
	}

	private static Enum94 smethod_25(MsoArrowheadLength msoArrowheadLength_0)
	{
		return msoArrowheadLength_0 switch
		{
			MsoArrowheadLength.Short => Enum94.const_0, 
			MsoArrowheadLength.Medium => Enum94.const_1, 
			MsoArrowheadLength.Long => Enum94.const_2, 
			_ => Enum94.const_0, 
		};
	}

	private static Enum96 smethod_26(MsoArrowheadWidth msoArrowheadWidth_0)
	{
		return msoArrowheadWidth_0 switch
		{
			MsoArrowheadWidth.Narrow => Enum96.const_0, 
			MsoArrowheadWidth.Medium => Enum96.const_1, 
			MsoArrowheadWidth.Wide => Enum96.const_2, 
			_ => Enum96.const_0, 
		};
	}

	private static Enum101 smethod_27(CheckValueType checkValueType_0)
	{
		return checkValueType_0 switch
		{
			CheckValueType.UnChecked => Enum101.const_0, 
			CheckValueType.Checked => Enum101.const_1, 
			CheckValueType.Mixed => Enum101.const_2, 
			_ => Enum101.const_0, 
		};
	}

	private static HatchStyle smethod_28(FillPattern fillPattern_0)
	{
		return fillPattern_0 switch
		{
			FillPattern.Gray5 => HatchStyle.Percent05, 
			FillPattern.Gray10 => HatchStyle.Percent10, 
			FillPattern.Gray20 => HatchStyle.Percent20, 
			FillPattern.Gray30 => HatchStyle.Percent30, 
			FillPattern.Gray40 => HatchStyle.Percent40, 
			FillPattern.Gray50 => HatchStyle.Percent50, 
			FillPattern.Gray60 => HatchStyle.Percent60, 
			FillPattern.Gray70 => HatchStyle.Percent70, 
			FillPattern.Gray75 => HatchStyle.Percent75, 
			FillPattern.Gray80 => HatchStyle.Percent80, 
			FillPattern.Gray90 => HatchStyle.Percent90, 
			FillPattern.Gray25 => HatchStyle.Percent25, 
			FillPattern.LightDownwardDiagonal => HatchStyle.LightDownwardDiagonal, 
			FillPattern.LightUpwardDiagonal => HatchStyle.LightUpwardDiagonal, 
			FillPattern.DarkDownwardDiagonal => HatchStyle.DarkDownwardDiagonal, 
			FillPattern.DarkUpwardDiagonal => HatchStyle.DarkUpwardDiagonal, 
			FillPattern.WideDownwardDiagonal => HatchStyle.WideDownwardDiagonal, 
			FillPattern.WideUpwardDiagonal => HatchStyle.WideUpwardDiagonal, 
			FillPattern.LightVertical => HatchStyle.LightVertical, 
			FillPattern.LightHorizontal => HatchStyle.LightHorizontal, 
			FillPattern.NarrowVertical => HatchStyle.NarrowVertical, 
			FillPattern.NarrowHorizontal => HatchStyle.NarrowHorizontal, 
			FillPattern.DarkVertical => HatchStyle.DarkVertical, 
			FillPattern.DarkHorizontal => HatchStyle.DarkHorizontal, 
			FillPattern.DashedDownwardDiagonal => HatchStyle.DashedDownwardDiagonal, 
			FillPattern.DashedUpwardDiagonal => HatchStyle.DashedUpwardDiagonal, 
			FillPattern.DashedVertical => HatchStyle.DashedVertical, 
			FillPattern.DashedHorizontal => HatchStyle.DashedHorizontal, 
			FillPattern.SmallConfetti => HatchStyle.SmallConfetti, 
			FillPattern.LargeConfetti => HatchStyle.LargeConfetti, 
			FillPattern.ZigZag => HatchStyle.ZigZag, 
			FillPattern.Wave => HatchStyle.Wave, 
			FillPattern.DiagonalBrick => HatchStyle.DiagonalBrick, 
			FillPattern.HorizontalBrick => HatchStyle.HorizontalBrick, 
			FillPattern.Weave => HatchStyle.Weave, 
			FillPattern.Plaid => HatchStyle.Plaid, 
			FillPattern.Divot => HatchStyle.Divot, 
			FillPattern.DottedGrid => HatchStyle.DottedGrid, 
			FillPattern.DottedDiamond => HatchStyle.DottedDiamond, 
			FillPattern.Shingle => HatchStyle.Shingle, 
			FillPattern.Trellis => HatchStyle.Trellis, 
			FillPattern.Sphere => HatchStyle.Sphere, 
			FillPattern.SmallGrid => HatchStyle.SmallGrid, 
			FillPattern.LargeGrid => HatchStyle.Cross, 
			FillPattern.SmallCheckerBoard => HatchStyle.SmallCheckerBoard, 
			FillPattern.LargeCheckerBoard => HatchStyle.LargeCheckerBoard, 
			FillPattern.OutlinedDiamond => HatchStyle.OutlinedDiamond, 
			FillPattern.SolidDiamond => HatchStyle.SolidDiamond, 
			_ => HatchStyle.Cross, 
		};
	}

	internal static Enum104 smethod_29(TextAlignmentType textAlignmentType_0)
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

	internal static Enum107 smethod_30(TextOrientationType textOrientationType_0)
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

	private static void smethod_31(CellsDrawing cellsDrawing_0, Class898 class898_0)
	{
		class898_0.Line.method_3(smethod_24(cellsDrawing_0.LineFormat.BeginArrowheadStyle));
		class898_0.Line.method_7(smethod_25(cellsDrawing_0.LineFormat.BeginArrowheadLength));
		class898_0.Line.method_5(smethod_26(cellsDrawing_0.LineFormat.BeginArrowheadWidth));
		class898_0.Line.method_9(smethod_24(cellsDrawing_0.LineFormat.EndArrowheadStyle));
		class898_0.Line.method_13(smethod_25(cellsDrawing_0.LineFormat.EndArrowheadLength));
		class898_0.Line.method_11(smethod_26(cellsDrawing_0.LineFormat.EndArrowheadWidth));
	}

	private static void smethod_32(Class1347 class1347_0, Class898 class898_0)
	{
		class898_0.Line.method_3(smethod_24(class1347_0.LineFormat.BeginArrowheadStyle));
		class898_0.Line.method_7(smethod_25(class1347_0.LineFormat.BeginArrowheadLength));
		class898_0.Line.method_5(smethod_26(class1347_0.LineFormat.BeginArrowheadWidth));
		class898_0.Line.method_9(smethod_24(class1347_0.LineFormat.EndArrowheadStyle));
		class898_0.Line.method_13(smethod_25(class1347_0.LineFormat.EndArrowheadLength));
		class898_0.Line.method_11(smethod_26(class1347_0.LineFormat.EndArrowheadWidth));
	}

	private static void smethod_33(Shape shape_0, Class898 class898_0)
	{
		class898_0.class885_0 = new Class885();
		Class1245 @class = shape_0.method_9();
		foreach (Enum182 value2 in Enum.GetValues(typeof(Enum182)))
		{
			if (@class.method_4(value2) && value2 >= Enum182.const_7 && value2 <= Enum182.const_16)
			{
				int value = @class.method_3(value2);
				Class882 class2 = new Class882();
				class2.method_1((int)value2);
				class2.Value = value;
				class898_0.class885_0.arrayList_0.Add(class2);
			}
		}
	}

	private static void smethod_34(Shape shape_0, Class898 class898_0)
	{
		class898_0.Rotation = (int)shape_0.RotationAngle;
	}

	private static void smethod_35(Shape shape_0, Class898 class898_0)
	{
		TextEffectFormat textEffect = shape_0.TextEffect;
		Class896 @class = new Class896();
		@class.Text = textEffect.Text;
		@class.FontName = textEffect.FontName;
		@class.FontSize = textEffect.FontSize;
		@class.FontItalic = textEffect.FontItalic;
		@class.FontBold = textEffect.FontBold;
		@class.RotatedChars = textEffect.RotatedChars;
		@class.method_0(smethod_36(textEffect.method_3()));
		@class.PresetShape = smethod_37(textEffect.PresetShape);
		class898_0.method_1(@class);
	}

	private static Enum106 smethod_36(Enum233 enum233_0)
	{
		return enum233_0 switch
		{
			Enum233.const_0 => Enum106.const_0, 
			Enum233.const_1 => Enum106.const_1, 
			Enum233.const_2 => Enum106.const_2, 
			Enum233.const_3 => Enum106.const_3, 
			Enum233.const_4 => Enum106.const_4, 
			Enum233.const_5 => Enum106.const_5, 
			Enum233.const_6 => Enum106.const_6, 
			_ => Enum106.const_1, 
		};
	}

	private static Enum102 smethod_37(MsoPresetTextEffectShape msoPresetTextEffectShape_0)
	{
		return msoPresetTextEffectShape_0 switch
		{
			MsoPresetTextEffectShape.Mixed => Enum102.const_40, 
			MsoPresetTextEffectShape.PlainText => Enum102.const_0, 
			MsoPresetTextEffectShape.Stop => Enum102.const_1, 
			MsoPresetTextEffectShape.TriangleUp => Enum102.const_2, 
			MsoPresetTextEffectShape.TriangleDown => Enum102.const_3, 
			MsoPresetTextEffectShape.ChevronUp => Enum102.const_4, 
			MsoPresetTextEffectShape.ChevronDown => Enum102.const_5, 
			MsoPresetTextEffectShape.RingInside => Enum102.const_6, 
			MsoPresetTextEffectShape.RingOutside => Enum102.const_7, 
			MsoPresetTextEffectShape.ArchUpCurve => Enum102.const_8, 
			MsoPresetTextEffectShape.ArchDownCurve => Enum102.const_9, 
			MsoPresetTextEffectShape.CircleCurve => Enum102.const_10, 
			MsoPresetTextEffectShape.ButtonCurve => Enum102.const_11, 
			MsoPresetTextEffectShape.ArchUpPour => Enum102.const_12, 
			MsoPresetTextEffectShape.ArchDownPour => Enum102.const_13, 
			MsoPresetTextEffectShape.CirclePour => Enum102.const_14, 
			MsoPresetTextEffectShape.ButtonPour => Enum102.const_15, 
			MsoPresetTextEffectShape.CurveUp => Enum102.const_16, 
			MsoPresetTextEffectShape.CurveDown => Enum102.const_17, 
			MsoPresetTextEffectShape.CascadeUp => Enum102.const_38, 
			MsoPresetTextEffectShape.CascadeDown => Enum102.const_39, 
			MsoPresetTextEffectShape.Wave1 => Enum102.const_20, 
			MsoPresetTextEffectShape.Wave2 => Enum102.const_21, 
			MsoPresetTextEffectShape.DoubleWave1 => Enum102.const_22, 
			MsoPresetTextEffectShape.DoubleWave2 => Enum102.const_23, 
			MsoPresetTextEffectShape.Inflate => Enum102.const_24, 
			MsoPresetTextEffectShape.Deflate => Enum102.const_25, 
			MsoPresetTextEffectShape.InflateBottom => Enum102.const_26, 
			MsoPresetTextEffectShape.DeflateBottom => Enum102.const_27, 
			MsoPresetTextEffectShape.InflateTop => Enum102.const_28, 
			MsoPresetTextEffectShape.DeflateTop => Enum102.const_29, 
			MsoPresetTextEffectShape.DeflateInflate => Enum102.const_30, 
			MsoPresetTextEffectShape.DeflateInflateDeflate => Enum102.const_31, 
			MsoPresetTextEffectShape.FadeRight => Enum102.const_32, 
			MsoPresetTextEffectShape.FadeLeft => Enum102.const_33, 
			MsoPresetTextEffectShape.FadeUp => Enum102.const_34, 
			MsoPresetTextEffectShape.FadeDown => Enum102.const_35, 
			MsoPresetTextEffectShape.SlantUp => Enum102.const_36, 
			MsoPresetTextEffectShape.SlantDown => Enum102.const_37, 
			MsoPresetTextEffectShape.CanUp => Enum102.const_18, 
			MsoPresetTextEffectShape.CanDown => Enum102.const_19, 
			_ => Enum102.const_9, 
		};
	}

	private static void smethod_38(Shape shape_0, Class898 class898_0)
	{
		ArrayList pathList = shape_0.PathsInfo.PathList;
		Class887 @class = new Class887();
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
			Class886 class2 = new Class886();
			Class890 class3 = null;
			arrayList = item.PathSegementList;
			foreach (MsoPathInfo item2 in arrayList)
			{
				class3 = new Class890();
				class3.Type = smethod_40(item2.Type);
				class3.method_0(item2.PointList);
				arrayList3.Add(class3);
			}
			class2.method_0(arrayList3);
			class2.Width = item.long_1;
			class2.Height = item.long_0;
			arrayList2.Add(class2);
		}
		@class.method_1(arrayList2);
		class898_0.method_5(@class);
	}

	private static void smethod_39(Shape shape_0, Class898 class898_0)
	{
		Class931 @class = shape_0.method_35();
		Class894 class2 = new Class894();
		class2.method_0(smethod_41(@class.method_1()));
		class2.method_1(@class.method_2());
		class2.ForeColor = @class.ForeColor;
		class2.method_20(@class.method_16());
		class2.method_21(@class.method_17());
		class2.method_5(@class.method_4());
		class2.method_7(@class.method_5());
		class2.method_17(@class.method_14());
		class2.method_18(@class.method_15());
		class2.method_3(@class.method_3());
		class2.method_14(@class.method_12());
		class2.method_15(@class.method_13());
		class2.method_10(@class.method_8());
		class2.method_12(@class.method_10());
		class2.method_11(@class.method_9());
		class2.method_13(@class.method_11());
		class2.method_8(@class.method_6());
		class2.method_9(@class.method_7());
		class2.WeightPt = @class.WeightPt;
		class898_0.method_3(class2);
	}

	private static Enum100 smethod_40(MsoPathType msoPathType_0)
	{
		return msoPathType_0 switch
		{
			MsoPathType.MsopathLineTo => Enum100.const_0, 
			MsoPathType.MsopathCurveTo => Enum100.const_1, 
			MsoPathType.MsopathMoveTo => Enum100.const_2, 
			MsoPathType.MsopathClose => Enum100.const_3, 
			MsoPathType.MsopathEnd => Enum100.const_4, 
			_ => Enum100.const_5, 
		};
	}

	private static Enum112 smethod_41(Enum130 enum130_0)
	{
		return enum130_0 switch
		{
			Enum130.const_0 => Enum112.const_0, 
			Enum130.const_1 => Enum112.const_1, 
			Enum130.const_2 => Enum112.const_2, 
			Enum130.const_3 => Enum112.const_3, 
			Enum130.const_4 => Enum112.const_4, 
			Enum130.const_5 => Enum112.const_5, 
			_ => Enum112.const_1, 
		};
	}
}
