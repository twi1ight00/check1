using System.Drawing;
using ns33;

namespace Aspose.Slides;

public class BulletFormatEffectiveData : IBulletFormatEffectiveData, IEffectiveData
{
	private ParagraphFormatEffectiveData paragraphFormatEffectiveData_0;

	internal BulletType bulletType_0;

	internal NullableBool nullableBool_0;

	internal NullableBool nullableBool_1;

	internal short short_0;

	internal FontData fontData_0;

	internal float float_0;

	internal Color color_0;

	internal short short_1;

	internal NumberedBulletStyle numberedBulletStyle_0;

	internal Picture picture_0;

	public BulletType Type => bulletType_0;

	public char Char => (char)short_0;

	public IFontData Font => fontData_0;

	public float Height => float_0;

	public short NumberedBulletStartWith => short_1;

	public NumberedBulletStyle NumberedBulletStyle => numberedBulletStyle_0;

	public Color Color => color_0;

	internal Picture BulletPicture => picture_0;

	internal bool IsBulletHardColor => nullableBool_1 == NullableBool.True;

	internal bool IsBulletHardFont => nullableBool_0 == NullableBool.True;

	internal BulletFormatEffectiveData(ParagraphFormatEffectiveData parentParagraphFormatEffectiveData, ParagraphFormat source, BaseSlide slide, FloatColor styleColor)
	{
		paragraphFormatEffectiveData_0 = parentParagraphFormatEffectiveData;
		method_0(parentParagraphFormatEffectiveData, source, slide, styleColor);
	}

	internal void method_0(ParagraphFormatEffectiveData parentParagraphFormatEffectiveData, ParagraphFormat source, BaseSlide slide, FloatColor styleColor)
	{
		bulletType_0 = source.bulletFormat_0.bulletType_0;
		nullableBool_0 = source.bulletFormat_0.nullableBool_0;
		nullableBool_1 = source.bulletFormat_0.nullableBool_1;
		short_0 = source.bulletFormat_0.PPTXUnsupportedProps.BulletChar;
		fontData_0 = ((source.bulletFormat_0.ifontData_0 != null) ? ((FontData)source.bulletFormat_0.ifontData_0).method_1(slide.CreateThemeEffective()) : null);
		float_0 = source.bulletFormat_0.float_0;
		color_0 = source.bulletFormat_0.colorFormat_0.method_5(slide, styleColor);
		short_1 = source.bulletFormat_0.short_0;
		numberedBulletStyle_0 = source.bulletFormat_0.numberedBulletStyle_0;
		picture_0 = new Picture(paragraphFormatEffectiveData_0, source.bulletFormat_0.Picture);
	}

	internal void method_1(ParagraphFormat paragraphFormat, BaseSlide slide, FloatColor styleColor)
	{
		if (paragraphFormat.bulletFormat_0.bulletType_0 != BulletType.NotDefined)
		{
			bulletType_0 = paragraphFormat.bulletFormat_0.bulletType_0;
		}
		if (paragraphFormat.bulletFormat_0.nullableBool_0 != NullableBool.NotDefined)
		{
			nullableBool_0 = paragraphFormat.bulletFormat_0.nullableBool_0;
		}
		if (paragraphFormat.bulletFormat_0.nullableBool_1 != NullableBool.NotDefined)
		{
			nullableBool_1 = paragraphFormat.bulletFormat_0.nullableBool_1;
		}
		if (paragraphFormat.bulletFormat_0.PPTXUnsupportedProps.BulletChar != -1)
		{
			short_0 = paragraphFormat.bulletFormat_0.PPTXUnsupportedProps.BulletChar;
		}
		if (paragraphFormat.bulletFormat_0.ifontData_0 != null)
		{
			fontData_0 = ((FontData)paragraphFormat.bulletFormat_0.ifontData_0).method_1(slide.CreateThemeEffective());
		}
		if (!float.IsNaN(paragraphFormat.bulletFormat_0.float_0))
		{
			float_0 = paragraphFormat.bulletFormat_0.float_0;
		}
		if (paragraphFormat.bulletFormat_0.colorFormat_0.ColorType != ColorType.NotDefined)
		{
			color_0 = paragraphFormat.bulletFormat_0.colorFormat_0.method_5(slide, styleColor);
		}
		if (paragraphFormat.bulletFormat_0.short_0 != -1)
		{
			short_1 = paragraphFormat.bulletFormat_0.short_0;
		}
		if (paragraphFormat.bulletFormat_0.numberedBulletStyle_0 != NumberedBulletStyle.NotDefined)
		{
			numberedBulletStyle_0 = paragraphFormat.bulletFormat_0.numberedBulletStyle_0;
		}
		if (paragraphFormat.bulletFormat_0.Picture.Image != null)
		{
			picture_0.method_0(paragraphFormat.bulletFormat_0.Picture);
		}
	}

	internal bool method_2(BulletFormatEffectiveData bulletFormatEffective)
	{
		if (bulletType_0 == bulletFormatEffective.bulletType_0 && nullableBool_0 == bulletFormatEffective.nullableBool_0 && nullableBool_1 == bulletFormatEffective.nullableBool_1 && short_0 == bulletFormatEffective.short_0 && fontData_0 == bulletFormatEffective.fontData_0 && Class1165.smethod_0(float_0, bulletFormatEffective.float_0) && color_0 == bulletFormatEffective.color_0 && short_1 == bulletFormatEffective.short_1 && numberedBulletStyle_0 == bulletFormatEffective.numberedBulletStyle_0)
		{
			return true;
		}
		return false;
	}
}
