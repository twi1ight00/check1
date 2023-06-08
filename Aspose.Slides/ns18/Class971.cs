using System;
using System.Globalization;
using Aspose.Slides;
using ns16;
using ns24;
using ns33;
using ns56;

namespace ns18;

internal class Class971
{
	public static void smethod_0(IParagraphFormat paragraphFormat, Class1963 paragraphPropsElementData, Class1341 deserializationContext)
	{
		if (paragraphPropsElementData == null)
		{
			return;
		}
		Class345 pPTXUnsupportedProps = ((ParagraphFormat)paragraphFormat).PPTXUnsupportedProps;
		pPTXUnsupportedProps.Depth = (short)paragraphPropsElementData.Lvl;
		paragraphFormat.SpaceWithin = smethod_1(paragraphPropsElementData.LnSpc);
		paragraphFormat.SpaceBefore = smethod_1(paragraphPropsElementData.SpcBef);
		paragraphFormat.SpaceAfter = smethod_1(paragraphPropsElementData.SpcAft);
		Class2605 textBulletColor = paragraphPropsElementData.TextBulletColor;
		paragraphFormat.Bullet.IsBulletHardColor = NullableBool.NotDefined;
		if (textBulletColor != null)
		{
			switch (textBulletColor.Name)
			{
			case "buClr":
			{
				Class1814 colorElementData = (Class1814)textBulletColor.Object;
				paragraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
				Class930.smethod_0(paragraphFormat.Bullet.Color, colorElementData);
				break;
			}
			case "buClrTx":
				paragraphFormat.Bullet.IsBulletHardColor = NullableBool.False;
				break;
			default:
				throw new Exception("Unknown element \"" + textBulletColor.Name + "\"");
			}
		}
		Class2605 textBulletTypeface = paragraphPropsElementData.TextBulletTypeface;
		paragraphFormat.Bullet.IsBulletHardFont = NullableBool.NotDefined;
		if (textBulletTypeface != null)
		{
			switch (textBulletTypeface.Name)
			{
			case "buFont":
			{
				Class1956 textFontElementData = (Class1956)textBulletTypeface.Object;
				paragraphFormat.Bullet.IsBulletHardFont = NullableBool.True;
				pPTXUnsupportedProps.delegate14_0();
				Class950.smethod_0(paragraphFormat.Bullet.Font, textFontElementData);
				break;
			}
			case "buFontTx":
				paragraphFormat.Bullet.IsBulletHardFont = NullableBool.False;
				break;
			default:
				throw new Exception("Unknown element \"" + textBulletTypeface.Name + "\"");
			}
		}
		Class2605 textBulletSize = paragraphPropsElementData.TextBulletSize;
		if (textBulletSize != null)
		{
			switch (textBulletSize.Name)
			{
			case "buSzPts":
			{
				Class1951 class2 = (Class1951)textBulletSize.Object;
				paragraphFormat.Bullet.Height = (float.IsNaN(class2.Val) ? (-10f) : (0f - class2.Val));
				break;
			}
			case "buSzPct":
			{
				Class1950 @class = (Class1950)textBulletSize.Object;
				paragraphFormat.Bullet.Height = (float.IsNaN(@class.Val) ? 100f : @class.Val);
				break;
			}
			case "buSzTx":
				paragraphFormat.Bullet.Height = 100f;
				break;
			default:
				throw new Exception("Unknown element \"" + textBulletSize.Name + "\"");
			}
		}
		Class2605 textBullet = paragraphPropsElementData.TextBullet;
		paragraphFormat.Bullet.Type = BulletType.NotDefined;
		if (textBullet != null)
		{
			switch (textBullet.Name)
			{
			case "buBlip":
			{
				Class1945 class5 = (Class1945)textBullet.Object;
				paragraphFormat.Bullet.Type = BulletType.Picture;
				Class977.smethod_0(((BulletFormat)paragraphFormat.Bullet).Picture, class5.Blip, deserializationContext);
				break;
			}
			case "buChar":
			{
				Class1954 class4 = (Class1954)textBullet.Object;
				paragraphFormat.Bullet.Type = BulletType.Symbol;
				paragraphFormat.Bullet.Char = class4.Char[0];
				break;
			}
			case "buAutoNum":
			{
				Class1944 class3 = (Class1944)textBullet.Object;
				paragraphFormat.Bullet.Type = BulletType.Numbered;
				paragraphFormat.Bullet.NumberedBulletStyle = class3.Type;
				paragraphFormat.Bullet.NumberedBulletStartWith = (short)class3.StartAt;
				break;
			}
			case "buNone":
				paragraphFormat.Bullet.Type = BulletType.None;
				break;
			default:
				throw new Exception("Unknown element \"" + textBullet.Name + "\"");
			}
		}
		if (paragraphPropsElementData.TabLst != null)
		{
			Class1968[] tabList = paragraphPropsElementData.TabLst.TabList;
			foreach (Class1968 class6 in tabList)
			{
				paragraphFormat.Tabs.Add(double.IsNaN(class6.Pos) ? 0.0 : class6.Pos, class6.Algn);
			}
		}
		Class979.smethod_0(paragraphFormat.DefaultPortionFormat, paragraphPropsElementData.DefRPr, deserializationContext);
		switch (paragraphPropsElementData.Algn)
		{
		case Enum313.const_0:
			paragraphFormat.Alignment = TextAlignment.NotDefined;
			break;
		default:
			paragraphFormat.Alignment = TextAlignment.Left;
			break;
		case Enum313.const_2:
			paragraphFormat.Alignment = TextAlignment.Center;
			break;
		case Enum313.const_3:
			paragraphFormat.Alignment = TextAlignment.Right;
			break;
		case Enum313.const_4:
			paragraphFormat.Alignment = TextAlignment.Justify;
			break;
		}
		paragraphFormat.MarginLeft = (float)paragraphPropsElementData.MarL;
		paragraphFormat.MarginRight = (float)paragraphPropsElementData.MarR;
		paragraphFormat.Indent = (float)paragraphPropsElementData.Indent;
		paragraphFormat.DefaultTabSize = (float)paragraphPropsElementData.DefTabSz;
		paragraphFormat.FontAlignment = paragraphPropsElementData.FontAlgn;
		paragraphFormat.RightToLeft = paragraphPropsElementData.Rtl;
		paragraphFormat.EastAsianLineBreak = paragraphPropsElementData.EaLnBrk;
		paragraphFormat.LatinLineBreak = paragraphPropsElementData.LatinLnBrk;
		paragraphFormat.HangingPunctuation = paragraphPropsElementData.HangingPunct;
	}

	private static float smethod_1(Class1965 textSpacingElementData)
	{
		if (textSpacingElementData != null && textSpacingElementData.TextSpacing != null)
		{
			Class2605 textSpacing = textSpacingElementData.TextSpacing;
			switch (textSpacing.Name)
			{
			case "spcPts":
			{
				Class1967 class2 = (Class1967)textSpacing.Object;
				if (!float.IsNaN(class2.Val))
				{
					return 0f - class2.Val;
				}
				return -12f;
			}
			case "spcPct":
			{
				Class1966 @class = (Class1966)textSpacing.Object;
				if (!float.IsNaN(@class.Val))
				{
					return @class.Val;
				}
				return 100f;
			}
			default:
				throw new Exception("Unknown element \"" + textSpacing.Name + "\"");
			}
		}
		return float.NaN;
	}

	public static void smethod_2(IParagraphFormat paragraphFormat, Class1963.Delegate1756 addPPr, Class1346 serializationContext)
	{
		Class345 pPTXUnsupportedProps = ((ParagraphFormat)paragraphFormat).PPTXUnsupportedProps;
		if (!smethod_3(paragraphFormat, pPTXUnsupportedProps))
		{
			if (pPTXUnsupportedProps.SaveAsEmptyElement)
			{
				addPPr().delegate1726_0();
			}
			return;
		}
		Class1963 @class = addPPr();
		smethod_8(@class.delegate1762_0, paragraphFormat.SpaceWithin);
		smethod_8(@class.delegate1762_1, paragraphFormat.SpaceBefore);
		smethod_8(@class.delegate1762_2, paragraphFormat.SpaceAfter);
		BulletFormat bulletFormat = (BulletFormat)paragraphFormat.Bullet;
		smethod_4(bulletFormat, @class);
		smethod_5(bulletFormat, @class);
		smethod_6(bulletFormat, @class);
		if (bulletFormat.HasChar && bulletFormat.Type == BulletType.NotDefined)
		{
			Class1954 class2 = (Class1954)@class.delegate2773_0("buChar").Object;
			class2.Char = bulletFormat.Char.ToString(CultureInfo.InvariantCulture);
		}
		smethod_7(bulletFormat, paragraphFormat, @class, serializationContext);
		if (paragraphFormat.Tabs.Count > 0)
		{
			Class1969 class3 = @class.delegate1774_0();
			for (int i = 0; i < paragraphFormat.Tabs.Count; i++)
			{
				Class1968 class4 = class3.delegate1771_0();
				class4.Pos = paragraphFormat.Tabs[i].Position;
				class4.Algn = paragraphFormat.Tabs[i].Alignment;
			}
		}
		Class979.smethod_1(paragraphFormat.DefaultPortionFormat, @class.delegate1726_0, serializationContext);
		@class.Lvl = Class1165.smethod_4(pPTXUnsupportedProps.Depth, -1, 8);
		@class.MarL = Class1165.smethod_5(paragraphFormat.MarginLeft, 0f, 4032f);
		@class.MarR = Class1165.smethod_5(paragraphFormat.MarginRight, 0f, 4032f);
		@class.Indent = Class1165.smethod_5(paragraphFormat.Indent, -4032f, 4032f);
		switch (paragraphFormat.Alignment)
		{
		case TextAlignment.Left:
			@class.Algn = Enum313.const_1;
			break;
		case TextAlignment.Center:
			@class.Algn = Enum313.const_2;
			break;
		case TextAlignment.Right:
			@class.Algn = Enum313.const_3;
			break;
		case TextAlignment.Justify:
			@class.Algn = Enum313.const_4;
			break;
		}
		@class.DefTabSz = Class1165.smethod_5(paragraphFormat.DefaultTabSize, 0f, 4032f);
		@class.FontAlgn = paragraphFormat.FontAlignment;
		@class.Rtl = paragraphFormat.RightToLeft;
		@class.EaLnBrk = paragraphFormat.EastAsianLineBreak;
		@class.LatinLnBrk = paragraphFormat.LatinLineBreak;
		@class.HangingPunct = paragraphFormat.HangingPunctuation;
	}

	private static bool smethod_3(IParagraphFormat paragraphFormat, Class345 unsupportedProps)
	{
		if (paragraphFormat.Bullet.Type == BulletType.NotDefined && paragraphFormat.Bullet.IsBulletHardColor == NullableBool.NotDefined && paragraphFormat.Bullet.Color.ColorType == ColorType.NotDefined && ((BulletFormat)paragraphFormat.Bullet).PPTXUnsupportedProps.BulletChar == -1 && paragraphFormat.Bullet.IsBulletHardFont == NullableBool.NotDefined && paragraphFormat.Bullet.Font == null && float.IsNaN(paragraphFormat.Bullet.Height) && paragraphFormat.Bullet.NumberedBulletStartWith == -1 && paragraphFormat.FontAlignment == FontAlignment.Default && paragraphFormat.Alignment == TextAlignment.NotDefined && unsupportedProps.Depth == -1 && double.IsNaN(paragraphFormat.MarginLeft) && double.IsNaN(paragraphFormat.MarginRight) && double.IsNaN(paragraphFormat.Indent) && double.IsNaN(paragraphFormat.DefaultTabSize) && float.IsNaN(paragraphFormat.SpaceAfter) && float.IsNaN(paragraphFormat.SpaceBefore) && float.IsNaN(paragraphFormat.SpaceWithin) && paragraphFormat.EastAsianLineBreak == NullableBool.NotDefined && paragraphFormat.HangingPunctuation == NullableBool.NotDefined && paragraphFormat.LatinLineBreak == NullableBool.NotDefined && paragraphFormat.RightToLeft == NullableBool.NotDefined && paragraphFormat.Tabs.Count == 0)
		{
			return !paragraphFormat.DefaultPortionFormat.Equals(Class979.portionFormat_0);
		}
		return true;
	}

	private static void smethod_4(BulletFormat bulletFormat, Class1963 paragraphPropsElementData)
	{
		if (bulletFormat.IsBulletHardColor == NullableBool.True)
		{
			if (bulletFormat.Color.ColorType != ColorType.NotDefined)
			{
				Class1814 colorElementData = (Class1814)paragraphPropsElementData.delegate2773_1("buClr").Object;
				Class930.smethod_3(bulletFormat.Color, colorElementData);
			}
		}
		else if (bulletFormat.IsBulletHardColor == NullableBool.False)
		{
			paragraphPropsElementData.delegate2773_1("buClrTx");
		}
	}

	private static void smethod_5(BulletFormat bulletFormat, Class1963 paragraphPropsElementData)
	{
		if (float.IsNaN(bulletFormat.Height))
		{
			return;
		}
		if (bulletFormat.Height >= 0f && bulletFormat.Height != 100f)
		{
			Class1950 @class = (Class1950)paragraphPropsElementData.delegate2773_2("buSzPct").Object;
			if (bulletFormat.Height > 0f)
			{
				@class.Val = Class1165.smethod_5(bulletFormat.Height, 25f, 400f);
			}
		}
		else if (bulletFormat.Height < 0f)
		{
			Class1951 class2 = (Class1951)paragraphPropsElementData.delegate2773_2("buSzPts").Object;
			class2.Val = Class1165.smethod_5(0f - bulletFormat.Height, 1f, 1000f);
		}
		else
		{
			paragraphPropsElementData.delegate2773_2("buSzTx");
		}
	}

	private static void smethod_6(BulletFormat bulletFormat, Class1963 paragraphPropsElementData)
	{
		if (bulletFormat.IsBulletHardFont == NullableBool.True)
		{
			Class1956 textFontElementData = (Class1956)paragraphPropsElementData.delegate2773_3("buFont").Object;
			Class950.smethod_4(bulletFormat.Font, textFontElementData);
		}
		else if (bulletFormat.IsBulletHardFont == NullableBool.False)
		{
			paragraphPropsElementData.delegate2773_3("buFontTx");
		}
	}

	private static void smethod_7(BulletFormat bulletFormat, IParagraphFormat paragraphFormat, Class1963 paragraphPropsElementData, Class1346 serializationContext)
	{
		switch (bulletFormat.Type)
		{
		case BulletType.None:
			paragraphPropsElementData.delegate2773_0("buNone");
			break;
		case BulletType.Symbol:
		{
			Class1954 class3 = (Class1954)paragraphPropsElementData.delegate2773_0("buChar").Object;
			class3.Char = ((!bulletFormat.HasChar) ? "•" : bulletFormat.Char.ToString(CultureInfo.InvariantCulture));
			break;
		}
		case BulletType.Numbered:
		{
			Class1944 class2 = (Class1944)paragraphPropsElementData.delegate2773_0("buAutoNum").Object;
			class2.Type = paragraphFormat.Bullet.NumberedBulletStyle;
			class2.StartAt = paragraphFormat.Bullet.NumberedBulletStartWith;
			break;
		}
		case BulletType.Picture:
		{
			Class1945 @class = (Class1945)paragraphPropsElementData.delegate2773_0("buBlip").Object;
			if (((BulletFormat)paragraphFormat.Bullet).Picture != null)
			{
				Class977.smethod_2(((BulletFormat)paragraphFormat.Bullet).Picture, @class.Blip, serializationContext);
			}
			break;
		}
		}
	}

	private static void smethod_8(Class1965.Delegate1762 addSpace, float value)
	{
		if (!float.IsNaN(value))
		{
			Class1965 @class = addSpace();
			if (value < 0f)
			{
				Class1967 class2 = (Class1967)@class.delegate2773_0("spcPts").Object;
				class2.Val = 0f - value;
			}
			else
			{
				Class1966 class3 = (Class1966)@class.delegate2773_0("spcPct").Object;
				class3.Val = value;
			}
		}
	}
}
