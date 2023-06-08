using System.Xml;
using Aspose.Slides;

namespace ns28;

internal class Class438 : Class369
{
	internal static readonly string[] string_0 = new string[3] { "styles", "automatic-styles", "master-styles" };

	private string string_1 = "urn:oasis:names:tc:opendocument:xmlns:style:1.0";

	private string string_2 = "urn:oasis:names:tc:opendocument:xmlns:text:1.0";

	public Class438(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}

	internal Class437 method_36(string styleName)
	{
		Class437 @class = (Class437)method_35("style", string_1);
		@class.Name = styleName;
		return @class;
	}

	internal Class406 method_37(Class476 odpPackage, Paragraph paras, int listLevel)
	{
		Class406 @class = (Class406)method_35("list-style", string_2);
		@class.Name = "L" + odpPackage.int_0++;
		switch (paras.ParagraphFormat.Bullet.Type)
		{
		case BulletType.Symbol:
		{
			Class404 class5 = (Class404)@class.method_35("list-level-style-bullet", string_2);
			class5.Level = listLevel;
			class5.BulletCharacter = paras.ParagraphFormat.Bullet.Char;
			Class403 class3 = (Class403)class5.method_35("list-level-properties", string_1);
			if (!double.IsNaN(paras.ParagraphFormat.Indent) && !double.IsNaN(paras.ParagraphFormat.MarginLeft))
			{
				class3.SpaceBefore = paras.ParagraphFormat.Indent + paras.ParagraphFormat.MarginLeft;
			}
			if (!double.IsNaN(paras.ParagraphFormat.Indent))
			{
				class3.MinLabelWidth = paras.ParagraphFormat.Indent * -1f;
			}
			Class457 class4 = (Class457)class5.method_35("text-properties", string_1);
			class4.FontSizePercent = paras.ParagraphFormat.Bullet.Height;
			if (paras.ParagraphFormat.Bullet.IsBulletHardFont == NullableBool.True)
			{
				class4.FontFamily = ((paras.ParagraphFormat.Bullet.Font.FontName[0] != '+') ? ("'" + paras.ParagraphFormat.Bullet.Font.FontName + "'") : ("'" + paras.ParagraphFormat.Bullet.Font.GetFontName(paras.paragraphCollection_0.Slide.CreateThemeEffective()) + "'"));
			}
			if (paras.ParagraphFormat.Bullet.IsBulletHardColor == NullableBool.True)
			{
				class4.TextColor = paras.ParagraphFormat.Bullet.Color.Color;
			}
			break;
		}
		case BulletType.Numbered:
		{
			Class405 class2 = (Class405)@class.method_35("list-level-style-number", string_2);
			class2.Level = listLevel;
			switch (paras.ParagraphFormat.Bullet.NumberedBulletStyle)
			{
			case NumberedBulletStyle.BulletAlphaLCPeriod:
				class2.NumSuffix = ".";
				class2.NumFormat = "a";
				break;
			case NumberedBulletStyle.BulletAlphaUCPeriod:
				class2.NumSuffix = ".";
				class2.NumFormat = "A";
				break;
			case NumberedBulletStyle.BulletArabicParenRight:
				class2.NumSuffix = ")";
				class2.NumFormat = "1";
				break;
			case NumberedBulletStyle.BulletRomanLCParenBoth:
				class2.NumPrefix = "(";
				class2.NumSuffix = ")";
				class2.NumFormat = "i";
				break;
			case NumberedBulletStyle.BulletRomanLCParenRight:
				class2.NumSuffix = ")";
				class2.NumFormat = "i";
				break;
			case NumberedBulletStyle.BulletRomanLCPeriod:
				class2.NumSuffix = ".";
				class2.NumFormat = "i";
				break;
			case NumberedBulletStyle.BulletRomanUCPeriod:
				class2.NumSuffix = ".";
				class2.NumFormat = "I";
				break;
			case NumberedBulletStyle.BulletAlphaLCParenBoth:
				class2.NumPrefix = "(";
				class2.NumSuffix = ")";
				class2.NumFormat = "a";
				break;
			case NumberedBulletStyle.BulletAlphaLCParenRight:
				class2.NumSuffix = ")";
				class2.NumFormat = "a";
				break;
			case NumberedBulletStyle.BulletAlphaUCParenBoth:
				class2.NumPrefix = "(";
				class2.NumSuffix = ")";
				class2.NumFormat = "A";
				break;
			case NumberedBulletStyle.BulletAlphaUCParenRight:
				class2.NumSuffix = ")";
				class2.NumFormat = "A";
				break;
			case NumberedBulletStyle.BulletArabicParenBoth:
				class2.NumPrefix = "(";
				class2.NumSuffix = ")";
				class2.NumFormat = "1";
				break;
			case NumberedBulletStyle.BulletRomanUCParenBoth:
				class2.NumPrefix = "(";
				class2.NumSuffix = ")";
				class2.NumFormat = "I";
				break;
			case NumberedBulletStyle.BulletRomanUCParenRight:
				class2.NumSuffix = ")";
				class2.NumFormat = "I";
				break;
			default:
				class2.NumSuffix = ".";
				class2.NumFormat = "1";
				break;
			case NumberedBulletStyle.BulletArabicDBPlain:
				class2.NumFormat = "1";
				break;
			case NumberedBulletStyle.BulletArabicPeriod:
			case NumberedBulletStyle.BulletArabicDBPeriod:
				class2.NumSuffix = ".";
				class2.NumFormat = "1";
				break;
			}
			Class403 class3 = (Class403)class2.method_35("list-level-properties", string_1);
			if (!double.IsNaN(paras.ParagraphFormat.Indent) && !double.IsNaN(paras.ParagraphFormat.MarginLeft))
			{
				class3.SpaceBefore = paras.ParagraphFormat.Indent + paras.ParagraphFormat.MarginLeft;
			}
			if (!double.IsNaN(paras.ParagraphFormat.Indent))
			{
				class3.MinLabelWidth = paras.ParagraphFormat.Indent * -1f;
			}
			Class457 class4 = (Class457)class2.method_35("text-properties", string_1);
			class4.FontSizePercent = paras.ParagraphFormat.Bullet.Height;
			if (paras.ParagraphFormat.Bullet.IsBulletHardFont == NullableBool.True && paras.ParagraphFormat.Bullet.Font.FontName.Length > 0)
			{
				class4.FontFamily = ((paras.ParagraphFormat.Bullet.Font.FontName[0] != '+') ? ("'" + paras.ParagraphFormat.Bullet.Font.FontName + "'") : ("'" + paras.ParagraphFormat.Bullet.Font.GetFontName(paras.paragraphCollection_0.Slide.CreateThemeEffective()) + "'"));
			}
			class4.FontSizePercent = paras.ParagraphFormat.Bullet.Height;
			break;
		}
		}
		return @class;
	}
}
