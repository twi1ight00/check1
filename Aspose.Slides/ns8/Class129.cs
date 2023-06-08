using System;
using System.Drawing;
using Aspose.Slides;
using ns56;

namespace ns8;

internal class Class129 : Class120
{
	internal struct Struct53
	{
		public bool bool_0;

		public bool bool_1;

		public bool InvalidateAny
		{
			get
			{
				if (!bool_0)
				{
					return bool_1;
				}
				return true;
			}
		}

		public void method_0(Struct53 info)
		{
			if (info.bool_0)
			{
				bool_0 = true;
			}
			if (info.bool_1)
			{
				bool_1 = true;
			}
		}
	}

	internal struct Struct52
	{
		private double double_0;

		private double double_1;

		public double Primary => double_1;

		public double Secondary => double_0;

		public Struct52(double primary, double secondary)
		{
			double_1 = primary;
			double_0 = secondary;
		}
	}

	private const double double_0 = 0.56;

	private const double double_1 = 0.78;

	private const char char_0 = '•';

	private const double double_2 = 0.45;

	private const int int_0 = 38;

	public override bool HideLastTransition => true;

	private Class112 TextParameter => (Class112)base.Parameter;

	public override bool vmethod_6(Enum305 type)
	{
		if (type != Enum305.const_23 && type != Enum305.const_28 && type != Enum305.const_34 && type != Enum305.const_6 && type != Enum305.const_20)
		{
			return type == Enum305.const_26;
		}
		return true;
	}

	protected override void vmethod_1()
	{
		foreach (Class837 point in base.Points)
		{
			point.ShapeContainer.AutoTextRotation = TextParameter.AutoTextRotation;
			AutoShape autoShapeInternal = point.ShapeContainer.Shape.AutoShapeInternal;
			if (autoShapeInternal == null || point.ConnectedWith.Count <= 0)
			{
				continue;
			}
			autoShapeInternal.TextFrameInternal = new TextFrame(autoShapeInternal);
			int num = smethod_12(point.ConnectedWith);
			TextFrameFormat textFrameFormat_ = autoShapeInternal.TextFrameInternal.textFrameFormat_0;
			foreach (Class836 item in point.ConnectedWith)
			{
				bool flag = TextParameter.StartBulletLevel <= item.Level - num + 1;
				bool flag2 = item.Parent != null && !point.ConnectedWith.Contains(item.Parent);
				foreach (Paragraph paragraph2 in item.DataPoint.TextBody.Paragraphs)
				{
					Paragraph paragraph = new Paragraph(paragraph2);
					autoShapeInternal.TextFrame.Paragraphs.Add(paragraph);
					paragraph.ParagraphFormat.SpaceAfter = (float)(flag2 ? TextParameter.LineSpaceAfterParentParagraphs : TextParameter.LineSpaceAfterChildrenParagraphs);
					paragraph.ParagraphFormat.SpaceBefore = 0f;
					paragraph.ParagraphFormat.SpaceWithin = (float)(flag2 ? TextParameter.LineSpacingParent : TextParameter.LineSpacingChildren);
					if (flag)
					{
						paragraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
						paragraph.ParagraphFormat.Bullet.Char = '•';
					}
					if (paragraph.ParagraphFormat.Alignment == TextAlignment.NotDefined)
					{
						paragraph.ParagraphFormat.Alignment = smethod_10((point.ConnectedWith.Count != 1 || flag) ? TextParameter.ShapeTextLeftToRightAlignment : TextParameter.ParentLeftToRightAlignment);
					}
				}
			}
			textFrameFormat_.PPTXUnsupportedProps.FirstLastParagraphSpacing = NullableBool.False;
			bool flag3 = false;
			foreach (Class836 item2 in point.ConnectedWith)
			{
				if (item2.Parent != null && point.ConnectedWith.Contains(item2.Parent))
				{
					flag3 = true;
					break;
				}
			}
			if (flag3)
			{
				textFrameFormat_.AnchoringType = smethod_11(TextParameter.VerticalAnchorWithChildren);
				textFrameFormat_.CenterText = (TextParameter.IsTextCentredWithChildren ? NullableBool.True : NullableBool.False);
			}
			else
			{
				textFrameFormat_.AnchoringType = smethod_11(TextParameter.VerticalAnchor);
				textFrameFormat_.CenterText = (TextParameter.IsTextCentred ? NullableBool.True : NullableBool.False);
			}
			textFrameFormat_.ColumnSpacing = 0.1f;
			((ITextFrameFormat)textFrameFormat_).WrapText = NullableBool.True;
			((ITextFrameFormat)textFrameFormat_).AutofitType = TextAutofitType.None;
			textFrameFormat_.TextVerticalType = (TextParameter.IsTextVertical ? TextVerticalType.Vertical : TextVerticalType.Horizontal);
		}
	}

	public override bool vmethod_2(Class837 point)
	{
		point.ShapeContainer.Width = point.method_30(Enum305.const_62);
		point.ShapeContainer.Height = point.method_30(Enum305.const_16);
		double primaryFontMin = point.method_34(Enum305.const_23);
		double secondaryFontMin = point.method_34(Enum305.const_28);
		Struct53 @struct = method_8(point, primaryFontMin, secondaryFontMin);
		bool result = !@struct.InvalidateAny;
		while (@struct.InvalidateAny)
		{
			Struct52 struct2 = smethod_13(point);
			if (@struct.bool_0 && struct2.Primary > 1.0)
			{
				point.method_28(Enum305.const_23, Class102.smethod_9(struct2.Primary - 1.0));
				point.method_24((struct2.Primary - 1.0) / struct2.Primary, Enum305.const_34, Enum305.const_6);
				point.method_26();
			}
			else if (@struct.bool_1 && struct2.Secondary > 1.0)
			{
				point.method_28(Enum305.const_28, Class102.smethod_9(struct2.Secondary - 1.0));
				point.method_24((struct2.Secondary - 1.0) / struct2.Secondary, Enum305.const_34, Enum305.const_6);
				point.method_26();
			}
			@struct = method_8(point, primaryFontMin, secondaryFontMin);
		}
		return result;
	}

	public Struct53 method_8(Class837 point, double primaryFontMin, double secondaryFontMin)
	{
		vmethod_7(point);
		Struct53 result = default(Struct53);
		if (point.ShapeContainer.Width != 0.0 && point.ShapeContainer.Height != 0.0)
		{
			AutoShape autoShapeInternal = point.ShapeContainer.Shape.AutoShapeInternal;
			if (autoShapeInternal != null && point.ConnectedWith.Count > 0)
			{
				Struct52 @struct = smethod_13(point);
				int num = smethod_12(point.ConnectedWith);
				IParagraphCollection paragraphs = autoShapeInternal.TextFrameInternal.Paragraphs;
				int num2 = 0;
				bool flag = false;
				foreach (Class836 item in point.ConnectedWith)
				{
					bool flag2 = TextParameter.StartBulletLevel <= item.Level - num + 1;
					int num3 = method_9(point.ConnectedWith, num);
					for (int i = 0; i < item.DataPoint.TextBody.Paragraphs.Count; i++)
					{
						if (num2 >= paragraphs.Count)
						{
							break;
						}
						IParagraph paragraph = item.DataPoint.TextBody.Paragraphs[i];
						IParagraph paragraph2 = paragraphs[num2];
						double num4 = @struct.Primary;
						for (int j = 0; j < paragraph2.Portions.Count; j++)
						{
							IPortion portion = paragraph.Portions[j];
							IPortion portion2 = paragraph2.Portions[j];
							num4 = portion.PortionFormat.FontHeight;
							if (double.IsNaN(num4))
							{
								num4 = (flag2 ? @struct.Secondary : @struct.Primary);
							}
							else
							{
								flag = true;
							}
							portion2.PortionFormat.FontHeight = (float)num4;
						}
						if (flag2)
						{
							double num5 = Math.Max(5.0, num4);
							paragraph2.ParagraphFormat.MarginLeft = (float)((double)Math.Max(1, item.Level - num3 + 1) * num5 * 0.45);
							paragraph2.ParagraphFormat.Indent = 0f - (float)(num5 * 0.45);
						}
						num2++;
					}
				}
				ITextFrameFormat textFrameFormat = autoShapeInternal.TextFrame.TextFrameFormat;
				textFrameFormat.MarginTop = smethod_14(point, Enum305.const_34, @struct.Primary);
				textFrameFormat.MarginBottom = smethod_14(point, Enum305.const_6, @struct.Primary);
				textFrameFormat.MarginLeft = smethod_14(point, Enum305.const_20, @struct.Primary);
				textFrameFormat.MarginRight = smethod_14(point, Enum305.const_26, @struct.Primary);
				autoShapeInternal.method_29();
				if (point.ShapeContainer.HasText)
				{
					SizeF wantedSize = autoShapeInternal.TextFrameInternal.WantedSize;
					double num6 = wantedSize.Height;
					double num7 = wantedSize.Width;
					if (num6 != 0.0 && num7 != 0.0)
					{
						num6 += textFrameFormat.MarginTop + textFrameFormat.MarginBottom;
						num7 += textFrameFormat.MarginLeft + textFrameFormat.MarginRight;
						double textBoxHeight = point.ShapeContainer.TextBoxHeight;
						double width = point.ShapeContainer.Width;
						if (!flag && (Class120.smethod_4(textBoxHeight / num6) || Class120.smethod_4(width / num7) || autoShapeInternal.TextFrameInternal.class532_0.ContainsSplittedWords))
						{
							if (!double.IsNaN(primaryFontMin) && Class102.smethod_10(primaryFontMin) < @struct.Primary)
							{
								result.bool_0 = true;
							}
							else if (!double.IsNaN(secondaryFontMin) && Class102.smethod_10(secondaryFontMin) < @struct.Secondary)
							{
								result.bool_1 = true;
							}
						}
						double num8 = point.method_34(Enum305.const_16);
						num6 = point.ShapeContainer.Height * (num6 / textBoxHeight);
						if (!flag)
						{
							num6 = Math.Min(num6, point.TextMaxHeight);
						}
						if (!double.IsNaN(num8) && num8 >= textBoxHeight && (flag || point.method_32(Enum305.const_16) < num6))
						{
							point.method_27(Enum305.const_16, num6);
							vmethod_7(point);
							point.ShapeContainer.Width = point.method_30(Enum305.const_62);
							point.ShapeContainer.Height = point.method_30(Enum305.const_16);
						}
					}
				}
			}
		}
		return result;
	}

	private int method_9(Class838 collection, int primaryMinLevel)
	{
		int num = int.MaxValue;
		foreach (Class836 item in collection)
		{
			if (TextParameter.StartBulletLevel <= item.Level - primaryMinLevel + 1 && num > item.Level)
			{
				num = item.Level;
			}
		}
		if (num != int.MaxValue)
		{
			return num;
		}
		return 0;
	}

	private static TextAlignment smethod_10(Enum120 alignment)
	{
		return alignment switch
		{
			Enum120.const_1 => TextAlignment.Left, 
			Enum120.const_2 => TextAlignment.Center, 
			Enum120.const_3 => TextAlignment.Right, 
			_ => TextAlignment.NotDefined, 
		};
	}

	private static TextAnchorType smethod_11(Enum121 alignment)
	{
		return alignment switch
		{
			Enum121.const_1 => TextAnchorType.Top, 
			Enum121.const_2 => TextAnchorType.Center, 
			Enum121.const_3 => TextAnchorType.Bottom, 
			_ => TextAnchorType.NotDefined, 
		};
	}

	private static int smethod_12(Class838 collection)
	{
		if (collection.Count == 0)
		{
			return 0;
		}
		int num = int.MaxValue;
		foreach (Class836 item in collection)
		{
			if (num > item.Level)
			{
				num = item.Level;
			}
		}
		return num;
	}

	public static Struct52 smethod_13(Class837 point)
	{
		double num = smethod_15(Enum305.const_23, point);
		if (num == 0.0 && !point.method_23(Enum305.const_23))
		{
			num = Class102.smethod_9(38.0);
			point.method_27(Enum305.const_23, num);
		}
		double secondary = (point.method_23(Enum305.const_28) ? smethod_15(Enum305.const_28, point) : Math.Round(num * 0.78));
		return new Struct52(num, secondary);
	}

	private static double smethod_14(Class837 point, Enum305 type, double primarySize)
	{
		double num = primarySize * 0.56;
		return point.method_23(type) ? smethod_15(type, point) : num;
	}

	private static double smethod_15(Enum305 type, Class837 point)
	{
		return Math.Round(Class102.smethod_10(point.method_32(type)));
	}
}
