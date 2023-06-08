using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Import;
using ns277;
using ns284;
using ns290;
using ns33;

namespace ns31;

internal class Class6760 : Class6759
{
	private class Class507 : Interface332
	{
		private SizeF sizeF_0;

		private TextFrame textFrame_0;

		private bool bool_0;

		public Class507(TextFrame textFrame, float width, float height)
		{
			textFrame_0 = textFrame;
			sizeF_0 = new SizeF(width, height);
			bool_0 = true;
		}

		public void imethod_0(Class6844 container, bool boxType, ref Hashtable pageSet)
		{
			bool flag = container.Style.Display == Enum952.const_1;
			bool_0 |= flag;
		}

		public void imethod_1(Class6844 container, bool boxType, ref Hashtable pageSet)
		{
			bool flag = container.Style.Display == Enum952.const_1;
			bool_0 |= flag;
		}

		public void imethod_2(Class6844 box, bool boxType, ref Hashtable pageSet)
		{
			if (box is Class6855 wordBox)
			{
				if (bool_0)
				{
					textFrame_0.Paragraphs.Add(CreateParagraph(wordBox, box, sizeF_0.Width, sizeF_0.Height));
					bool_0 = false;
				}
				textFrame_0.Paragraphs[textFrame_0.Paragraphs.Count - 1].Portions.Add(CreatePortion(wordBox));
			}
		}
	}

	private class Class508
	{
		public Class6844 class6844_0;

		public PointF pointF_0;

		public Class508(Class6844 box, PointF point)
		{
			class6844_0 = box;
			pointF_0 = point;
		}
	}

	private readonly Presentation presentation_0;

	private readonly List<Slide> list_0 = new List<Slide>();

	private int int_0;

	private Slide slide_0;

	private readonly LayoutSlide layoutSlide_0;

	private readonly IDictionary<Class6844, IAutoShape> idictionary_0 = new Dictionary<Class6844, IAutoShape>();

	private static readonly Class1155 class1155_0 = new Class1155(Enum957.const_0, TextAlignment.Left, Enum957.const_1, TextAlignment.Center, Enum957.const_2, TextAlignment.Center, Enum957.const_4, TextAlignment.Right, Enum957.const_3, TextAlignment.Justify, Enum957.const_5, TextAlignment.Justify);

	private readonly List<Class508> list_1 = new List<Class508>();

	private Class6844 class6844_0;

	private readonly Dictionary<Class6844, PointF> dictionary_0 = new Dictionary<Class6844, PointF>();

	private PointF pointF_0;

	private float float_0;

	private readonly IHtmlExternalResolver ihtmlExternalResolver_0;

	private readonly string string_0;

	internal Class6760(Presentation pres, int index, PointF origin, IHtmlExternalResolver resolver, string baseUri)
	{
		pointF_0 = origin;
		presentation_0 = pres;
		int_0 = index;
		ihtmlExternalResolver_0 = resolver;
		string_0 = baseUri;
		foreach (LayoutSlide layoutSlide in presentation_0.Masters[0].LayoutSlides)
		{
			if (layoutSlide.LayoutType == SlideLayoutType.Blank)
			{
				layoutSlide_0 = layoutSlide;
				break;
			}
		}
		if (layoutSlide_0 == null)
		{
			layoutSlide_0 = (LayoutSlide)presentation_0.Masters[0].LayoutSlides[0];
		}
	}

	public override void vmethod_0(Class6844 box, PointF boxLocation, bool boxType, ref Hashtable pageSet)
	{
		dictionary_0.Add(box, boxLocation);
		if (box.Style.Display != Enum952.const_5 && box.Style.Display != Enum952.const_6)
		{
			if (box.Style.Display == Enum952.const_13)
			{
				list_1.Add(new Class508(box, boxLocation));
			}
			if (slide_0.Shapes.Count == 0 && box.Tag != null && box.Tag.ToLower() == "body")
			{
				method_1(slide_0.Background.FillFormat, box.Style);
				if (slide_0.Background.FillFormat.FillType != FillType.NotDefined)
				{
					slide_0.Background.Type = BackgroundType.OwnBackground;
				}
			}
			else if (box.Style.Display != Enum952.const_13 && box.Style.Display != Enum952.const_5 && (box.Style.BorderStyleLeft != 0 || box.Style.BorderStyleTop != 0 || box.Style.BorderStyleRight != 0 || box.Style.BorderStyleBottom != 0 || smethod_5(box)))
			{
				method_0(box, setBackgroundAndBorders: true);
			}
		}
		else
		{
			method_2(box);
		}
	}

	private static bool smethod_5(Class6844 box)
	{
		if (box.Parent == null)
		{
			if (box.Style.BackgroundColor.IsEmpty)
			{
				return !string.IsNullOrEmpty(box.Style.BackgroundImage);
			}
			return true;
		}
		if (box.Parent.Style.BackgroundColor != box.Style.BackgroundColor && !box.Style.BackgroundColor.IsEmpty)
		{
			return true;
		}
		if (box.Parent.Style.BackgroundImage != box.Style.BackgroundImage)
		{
			return !string.IsNullOrEmpty(box.Style.BackgroundImage);
		}
		return false;
	}

	public override void vmethod_2(string imageFileName, float x, float y, float width, float height, bool boxType, ref Hashtable pageSet)
	{
		string absoluteUri = ihtmlExternalResolver_0.ResolveUri(string_0, imageFileName);
		Stream entity = ihtmlExternalResolver_0.GetEntity(absoluteUri);
		if (entity != null)
		{
			IPPImage image = presentation_0.Images.AddImage(entity);
			slide_0.Shapes.AddPictureFrame(ShapeType.Rectangle, x, y, width, height, image);
		}
	}

	public override void vmethod_1(Class6855 box, PointF pos, Interface356 link, bool boxType, ref Hashtable pageSet)
	{
		Class6844 @class = box;
		while (@class != null)
		{
			switch (@class.Style.Display)
			{
			default:
				@class = @class.Parent;
				break;
			case Enum952.const_1:
			case Enum952.const_2:
			case Enum952.const_5:
			case Enum952.const_8:
			case Enum952.const_9:
			case Enum952.const_10:
			case Enum952.const_12:
			case Enum952.const_14:
			{
				IAutoShape autoShape;
				if (!idictionary_0.ContainsKey(@class))
				{
					autoShape = method_0(@class, setBackgroundAndBorders: false);
					autoShape.AddTextFrame("");
					autoShape.TextFrame.Paragraphs.Clear();
					autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Top;
					idictionary_0[@class] = autoShape;
				}
				else
				{
					autoShape = idictionary_0[@class];
				}
				ITextFrame textFrame = autoShape.TextFrame;
				float num = pos.Y + box.float_0;
				if (textFrame.Paragraphs.Count == 0 || Math.Abs(float_0 - num) > 10f)
				{
					textFrame.Paragraphs.Add(CreateParagraph(box, @class, @class.Size.Width, @class.Size.Height));
				}
				float_0 = num;
				IPortionCollection portions = textFrame.Paragraphs[textFrame.Paragraphs.Count - 1].Portions;
				portions.Add(CreatePortion(box));
				slide_0.Shapes.Reorder(slide_0.Shapes.Count - 1, autoShape);
				@class = null;
				break;
			}
			case Enum952.const_13:
			case Enum952.const_15:
				return;
			}
		}
	}

	private IAutoShape method_0(Class6844 box, bool setBackgroundAndBorders)
	{
		PointF pointF = dictionary_0[box];
		RectangleF rectangleF = new RectangleF(box.Location.X + pointF.X + pointF_0.X, box.Location.Y + pointF.Y + pointF_0.Y, box.Size.Width, box.Size.Height);
		IAutoShape autoShape = slide_0.Shapes.AddAutoShape(ShapeType.Rectangle, rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height);
		autoShape.ShapeStyle.FillStyleIndex = 0;
		autoShape.ShapeStyle.LineStyleIndex = 0;
		autoShape.ShapeStyle.EffectStyleIndex = 0u;
		if (setBackgroundAndBorders)
		{
			Interface329 style = box.Style;
			method_1(autoShape.FillFormat, style);
			float num = smethod_7(style.BorderWidthLeft, null, box.Size.Width);
			float num2 = smethod_7(style.BorderWidthTop, null, box.Size.Height);
			float num3 = smethod_7(style.BorderWidthRight, null, box.Size.Width);
			float num4 = smethod_7(style.BorderWidthBottom, null, box.Size.Height);
			if (style.BorderStyleLeft == style.BorderStyleTop && style.BorderStyleTop == style.BorderStyleRight && style.BorderStyleRight == style.BorderStyleBottom && (style.BorderStyleLeft == Enum951.const_0 || (style.BorderColorLeft == style.BorderColorTop && style.BorderColorTop == style.BorderColorRight && style.BorderColorRight == style.BorderColorBottom && num == num2 && num2 == num3 && num3 == num4)))
			{
				smethod_6(autoShape.LineFormat, style.BorderStyleLeft, style.BorderColorLeft, num);
			}
			else
			{
				if (style.BorderStyleLeft != 0)
				{
					IAutoShape autoShape2 = slide_0.Shapes.AddAutoShape(ShapeType.Line, rectangleF.X, rectangleF.Y, 0f, rectangleF.Height);
					smethod_6(autoShape2.LineFormat, style.BorderStyleLeft, style.BorderColorLeft, num);
				}
				if (style.BorderStyleTop != 0)
				{
					IAutoShape autoShape3 = slide_0.Shapes.AddAutoShape(ShapeType.Line, rectangleF.X, rectangleF.Y, rectangleF.Width, 0f);
					smethod_6(autoShape3.LineFormat, style.BorderStyleTop, style.BorderColorTop, num2);
				}
				if (style.BorderStyleRight != 0)
				{
					IAutoShape autoShape4 = slide_0.Shapes.AddAutoShape(ShapeType.Line, rectangleF.X + rectangleF.Width, rectangleF.Y, 0f, rectangleF.Height);
					smethod_6(autoShape4.LineFormat, style.BorderStyleRight, style.BorderColorRight, num3);
				}
				if (style.BorderStyleTop != 0)
				{
					IAutoShape autoShape5 = slide_0.Shapes.AddAutoShape(ShapeType.Line, rectangleF.X, rectangleF.Y + rectangleF.Height, rectangleF.Width, 0f);
					smethod_6(autoShape5.LineFormat, style.BorderStyleBottom, style.BorderColorBottom, num4);
				}
			}
		}
		return autoShape;
	}

	private void method_1(IFillFormat fillFormat, Interface329 boxStyle)
	{
		bool flag = false;
		if (boxStyle.BackgroundImage != null && ihtmlExternalResolver_0 != null)
		{
			try
			{
				string absoluteUri = ihtmlExternalResolver_0.ResolveUri(string_0, boxStyle.BackgroundImage);
				using Stream stream = ihtmlExternalResolver_0.GetEntity(absoluteUri);
				if (stream != null)
				{
					IPPImage image = presentation_0.Images.AddImage(stream);
					fillFormat.FillType = FillType.Picture;
					fillFormat.PictureFillFormat.Picture.Image = image;
					fillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;
					flag = true;
				}
			}
			catch (Exception ex)
			{
				Class1165.smethod_28(ex);
			}
		}
		if (!flag && !boxStyle.BackgroundColor.IsEmpty)
		{
			fillFormat.FillType = FillType.Solid;
			fillFormat.SolidFillColor.Color = boxStyle.BackgroundColor;
		}
	}

	private static void smethod_6(ILineFormat lineFormat, Enum951 borderStyle, Color borderColor, float width)
	{
		switch (borderStyle)
		{
		case Enum951.const_0:
			lineFormat.FillFormat.FillType = FillType.NoFill;
			return;
		case Enum951.const_1:
			lineFormat.DashStyle = LineDashStyle.Dot;
			break;
		case Enum951.const_2:
			lineFormat.DashStyle = LineDashStyle.Dash;
			break;
		case Enum951.const_4:
			lineFormat.Style = LineStyle.ThinThin;
			break;
		}
		lineFormat.FillFormat.FillType = FillType.Solid;
		lineFormat.FillFormat.SolidFillColor.Color = borderColor;
		lineFormat.Width = width;
	}

	private static Paragraph CreateParagraph(Class6855 wordBox, Class6844 block, float fullWidth, float fullHeight)
	{
		Paragraph paragraph = new Paragraph();
		paragraph.ParagraphFormat.Alignment = (TextAlignment)class1155_0[block.Style.TextAlign];
		paragraph.ParagraphFormat.MarginLeft = smethod_7(block.Style.MarginLeft, wordBox, fullWidth);
		paragraph.ParagraphFormat.MarginRight = smethod_7(block.Style.MarginLeft, wordBox, fullWidth);
		paragraph.ParagraphFormat.Indent = smethod_7(block.Style.TextIndent, wordBox, fullWidth);
		paragraph.ParagraphFormat.RightToLeft = ((block.Style.Direction == Enum936.const_1) ? NullableBool.True : NullableBool.NotDefined);
		return paragraph;
	}

	private static Portion CreatePortion(Class6855 wordBox)
	{
		Portion portion = new Portion(wordBox.WordDecoded);
		portion.PortionFormat.LatinFont = new FontData(wordBox.Style.FontFamilyName);
		portion.PortionFormat.FontHeight = wordBox.Style.FontSize;
		FontStyle fontStyle = wordBox.Style.FontStyle;
		portion.PortionFormat.FontBold = (((fontStyle & FontStyle.Bold) == FontStyle.Bold) ? NullableBool.True : NullableBool.NotDefined);
		portion.PortionFormat.FontItalic = (((fontStyle & FontStyle.Italic) == FontStyle.Italic) ? NullableBool.True : NullableBool.NotDefined);
		portion.PortionFormat.FontUnderline = (((fontStyle & FontStyle.Underline) == FontStyle.Underline) ? TextUnderlineType.Single : TextUnderlineType.NotDefined);
		portion.PortionFormat.StrikethroughType = (((fontStyle & FontStyle.Strikeout) == FontStyle.Strikeout) ? TextStrikethroughType.Single : TextStrikethroughType.NotDefined);
		portion.PortionFormat.FillFormat.FillType = FillType.Solid;
		IColorFormat solidFillColor = portion.PortionFormat.FillFormat.SolidFillColor;
		Color color3;
		if (!wordBox.Style.Color.IsEmpty)
		{
			Color color2 = (portion.PortionFormat.FillFormat.SolidFillColor.Color = wordBox.Style.Color);
			color3 = color2;
		}
		else
		{
			color3 = Color.Black;
		}
		solidFillColor.Color = color3;
		if (wordBox.Link != null)
		{
			portion.PortionFormat.HyperlinkClick = new Hyperlink(wordBox.Link.Href);
		}
		return portion;
	}

	private static float smethod_7(Class6959 value, Class6855 box, float fullLength)
	{
		return value.Unit switch
		{
			Enum955.const_1 => box.Style.FontSize * value.Value, 
			Enum955.const_2 => box.Style.FontSize * value.Value / 2f, 
			Enum955.const_3 => value.Value / 100f * fullLength, 
			Enum955.const_5 => value.Value * 72f, 
			Enum955.const_6 => value.Value / 2.54f * 72f, 
			Enum955.const_7 => value.Value / 25.4f * 72f, 
			Enum955.const_8 => value.Value * 12f, 
			_ => value.Value, 
		};
	}

	public override object vmethod_4()
	{
		return list_0.ToArray();
	}

	public override void vmethod_3()
	{
		presentation_0.Slides.InsertEmptySlide(int_0, layoutSlide_0);
		slide_0 = (Slide)presentation_0.Slides[int_0++];
		if (slide_0.Shapes.Count > 0)
		{
			slide_0.Shapes.Clear();
		}
		list_0.Add(slide_0);
		method_2(null);
	}

	internal void method_2(Class6844 tableBox)
	{
		if (class6844_0 != null)
		{
			SortedList<float, Class6760> sortedList = new SortedList<float, Class6760>();
			SortedList<float, Class6760> sortedList2 = new SortedList<float, Class6760>();
			SortedList<float, Class6760> sortedList3 = new SortedList<float, Class6760>();
			SortedList<float, Class6760> sortedList4 = new SortedList<float, Class6760>();
			foreach (Class508 item in list_1)
			{
				float num = item.class6844_0.Location.X + item.pointF_0.X;
				float key = num + item.class6844_0.BorderBound.Size.Width;
				float num2 = item.class6844_0.Location.Y + item.pointF_0.Y;
				float key2 = num2 + item.class6844_0.BorderBound.Size.Height;
				sortedList[num2] = this;
				sortedList2[key2] = this;
				sortedList3[num] = this;
				sortedList4[key] = this;
			}
			if (sortedList3.Count > 0 && sortedList.Count > 0)
			{
				double[] array = new double[sortedList3.Count];
				double[] array2 = new double[sortedList.Count];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = sortedList4.Keys[i] - sortedList3.Keys[i];
				}
				for (int j = 0; j < array2.Length; j++)
				{
					array2[j] = sortedList2.Keys[j] - sortedList.Keys[j];
				}
				PointF pointF = dictionary_0[class6844_0];
				ITable table = slide_0.Shapes.AddTable(class6844_0.Location.X + pointF.X + pointF_0.X, class6844_0.Location.Y + pointF.Y + pointF_0.Y, array, array2);
				table.StylePreset = TableStylePreset.None;
				foreach (Class508 item2 in list_1)
				{
					float num3 = item2.class6844_0.Location.X + item2.pointF_0.X;
					float key3 = num3 + item2.class6844_0.BorderBound.Size.Width;
					float num4 = item2.class6844_0.Location.Y + item2.pointF_0.Y;
					float key4 = num4 + item2.class6844_0.BorderBound.Size.Height;
					int num5 = sortedList3.IndexOfKey(num3);
					int num6 = sortedList4.IndexOfKey(key3);
					int num7 = sortedList.IndexOfKey(num4);
					int num8 = sortedList2.IndexOfKey(key4);
					if (num6 - num5 > 0 || num8 - num7 > 0)
					{
						table.MergeCells(table[num5, num7], table[num6, num8], allowSplitting: false);
					}
					ICell cell = table[num5, num7];
					method_3((TextFrame)cell.TextFrame, item2.class6844_0, item2.class6844_0.Size.Width, item2.class6844_0.Size.Height);
				}
			}
		}
		list_1.Clear();
		class6844_0 = tableBox;
	}

	private void method_3(TextFrame textFrame, Class6844 box, float fullWidth, float fullHeight)
	{
		Class507 visitor = new Class507(textFrame, fullWidth, fullHeight);
		textFrame.Paragraphs.Clear();
		Hashtable pageSet = null;
		box.vmethod_0(visitor, boxType: false, ref pageSet);
	}
}
