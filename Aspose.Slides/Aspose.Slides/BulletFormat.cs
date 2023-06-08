using ns22;
using ns24;
using ns33;

namespace Aspose.Slides;

public sealed class BulletFormat : IBulletFormat
{
	private Class303 class303_0 = new Class303();

	private Class259 class259_0 = new Class259();

	private ParagraphFormat paragraphFormat_0;

	internal BulletType bulletType_0;

	internal NullableBool nullableBool_0;

	internal NullableBool nullableBool_1;

	internal IFontData ifontData_0;

	internal float float_0;

	internal ColorFormat colorFormat_0;

	internal short short_0;

	internal NumberedBulletStyle numberedBulletStyle_0 = NumberedBulletStyle.NotDefined;

	private Picture picture_0;

	private uint uint_0;

	public BulletType Type
	{
		get
		{
			return bulletType_0;
		}
		set
		{
			if (bulletType_0 != value)
			{
				bulletType_0 = value;
				paragraphFormat_0.method_7();
				method_6();
			}
		}
	}

	public char Char
	{
		get
		{
			return (char)PPTXUnsupportedProps.BulletChar;
		}
		set
		{
			if (PPTXUnsupportedProps.BulletChar != (short)value)
			{
				PPTXUnsupportedProps.BulletChar = (short)value;
				paragraphFormat_0.method_7();
				method_6();
			}
		}
	}

	public IFontData Font
	{
		get
		{
			return ifontData_0;
		}
		set
		{
			ifontData_0 = value;
			paragraphFormat_0.method_7();
			method_6();
		}
	}

	public float Height
	{
		get
		{
			return float_0;
		}
		set
		{
			if (float_0 != value)
			{
				float_0 = value;
				paragraphFormat_0.method_7();
				method_6();
			}
		}
	}

	public IColorFormat Color => colorFormat_0;

	public short NumberedBulletStartWith
	{
		get
		{
			return short_0;
		}
		set
		{
			if (short_0 != value)
			{
				short_0 = value;
				paragraphFormat_0.method_7();
				method_6();
			}
		}
	}

	public NumberedBulletStyle NumberedBulletStyle
	{
		get
		{
			return numberedBulletStyle_0;
		}
		set
		{
			if (numberedBulletStyle_0 != value)
			{
				numberedBulletStyle_0 = value;
				paragraphFormat_0.method_7();
				method_6();
			}
		}
	}

	public NullableBool IsBulletHardColor
	{
		get
		{
			return nullableBool_1;
		}
		set
		{
			if (nullableBool_1 != value)
			{
				nullableBool_1 = value;
				paragraphFormat_0.method_7();
				method_6();
			}
		}
	}

	public NullableBool IsBulletHardFont
	{
		get
		{
			return nullableBool_0;
		}
		set
		{
			if (nullableBool_0 != value)
			{
				nullableBool_0 = value;
				paragraphFormat_0.method_7();
				method_6();
			}
		}
	}

	internal Class303 PPTXUnsupportedProps => class303_0;

	internal Class259 PPTUnsupportedProps => class259_0;

	internal Picture Picture
	{
		get
		{
			return picture_0;
		}
		set
		{
			if (value == null && picture_0 != null)
			{
				uint_0 += picture_0.Version;
			}
			picture_0 = value;
			method_6();
		}
	}

	internal bool HasBullet
	{
		get
		{
			if (Type != 0 && Type != BulletType.NotDefined)
			{
				return true;
			}
			return false;
		}
	}

	internal bool HasChar => PPTXUnsupportedProps.BulletChar != -1;

	internal uint Version => uint_0 + colorFormat_0.Version + picture_0.Version;

	internal BulletFormat(ParagraphFormat parentParagraphFormat)
	{
		paragraphFormat_0 = parentParagraphFormat;
		nullableBool_0 = NullableBool.NotDefined;
		nullableBool_1 = NullableBool.NotDefined;
		float_0 = float.NaN;
		colorFormat_0 = new ColorFormat(parentParagraphFormat.Slide);
		bulletType_0 = BulletType.NotDefined;
		short_0 = -1;
	}

	internal void method_0()
	{
		if (Font == null)
		{
			Font = new FontData();
		}
	}

	internal void method_1(BulletFormat source)
	{
		nullableBool_1 = source.nullableBool_1;
		nullableBool_0 = source.nullableBool_0;
		PPTXUnsupportedProps.BulletChar = source.PPTXUnsupportedProps.BulletChar;
		colorFormat_0.method_0(source.colorFormat_0);
		ifontData_0 = source.ifontData_0;
		float_0 = source.float_0;
		picture_0 = new Picture(paragraphFormat_0.Slide, source.Picture);
		bulletType_0 = source.bulletType_0;
		short_0 = source.short_0;
		numberedBulletStyle_0 = source.numberedBulletStyle_0;
		method_6();
	}

	internal bool method_2(BulletFormat bullet)
	{
		if (bulletType_0 == bullet.bulletType_0 && nullableBool_0 == bullet.nullableBool_0 && nullableBool_1 == bullet.nullableBool_1 && PPTXUnsupportedProps.BulletChar == bullet.PPTXUnsupportedProps.BulletChar && ((ifontData_0 != null && ifontData_0.Equals(bullet.ifontData_0)) || (ifontData_0 == null && bullet.ifontData_0 == null)) && Class1165.smethod_0(float_0, bullet.float_0) && ((colorFormat_0 != null && colorFormat_0.Equals(bullet.colorFormat_0)) || (colorFormat_0 == null && bullet.colorFormat_0 == null)) && short_0 == bullet.short_0 && numberedBulletStyle_0 == bullet.numberedBulletStyle_0)
		{
			return true;
		}
		return false;
	}

	internal void method_3(BulletFormat props)
	{
		if (bulletType_0 != BulletType.NotDefined)
		{
			props.bulletType_0 = bulletType_0;
		}
		if (nullableBool_0 != NullableBool.NotDefined)
		{
			props.nullableBool_0 = nullableBool_0;
		}
		if (nullableBool_1 != NullableBool.NotDefined)
		{
			props.nullableBool_1 = nullableBool_1;
		}
		if (PPTXUnsupportedProps.BulletChar != -1)
		{
			props.PPTXUnsupportedProps.BulletChar = PPTXUnsupportedProps.BulletChar;
		}
		if (ifontData_0 != null)
		{
			props.ifontData_0 = ifontData_0;
		}
		if (!float.IsNaN(float_0))
		{
			props.float_0 = float_0;
		}
		if (colorFormat_0.ColorType != ColorType.NotDefined)
		{
			props.colorFormat_0.method_0(colorFormat_0);
		}
		if (short_0 != -1)
		{
			props.short_0 = short_0;
		}
		if (numberedBulletStyle_0 != NumberedBulletStyle.NotDefined)
		{
			props.numberedBulletStyle_0 = numberedBulletStyle_0;
		}
		if (picture_0.Image != null)
		{
			props.picture_0.method_0(picture_0);
		}
	}

	internal void method_4(BulletFormat props)
	{
		if (bulletType_0 == BulletType.NotDefined)
		{
			bulletType_0 = props.bulletType_0;
		}
		if (nullableBool_0 == NullableBool.NotDefined)
		{
			nullableBool_0 = props.nullableBool_0;
		}
		if (nullableBool_1 == NullableBool.NotDefined)
		{
			nullableBool_1 = props.nullableBool_1;
		}
		if (PPTXUnsupportedProps.BulletChar == -1)
		{
			PPTXUnsupportedProps.BulletChar = props.PPTXUnsupportedProps.BulletChar;
		}
		if (ifontData_0 == null)
		{
			ifontData_0 = props.ifontData_0;
		}
		if (float.IsNaN(float_0))
		{
			float_0 = props.float_0;
		}
		if (colorFormat_0.ColorType == ColorType.NotDefined)
		{
			colorFormat_0.method_0(props.colorFormat_0);
		}
		if (short_0 == -1)
		{
			short_0 = props.short_0;
		}
		if (numberedBulletStyle_0 == NumberedBulletStyle.NotDefined)
		{
			numberedBulletStyle_0 = props.numberedBulletStyle_0;
		}
		if (Picture.Image == null)
		{
			Picture.method_0(props.Picture);
		}
	}

	internal void method_5(BulletFormat overriding, BulletFormat overriden)
	{
		if (bulletType_0 == BulletType.NotDefined)
		{
			if (overriding.bulletType_0 != BulletType.NotDefined)
			{
				bulletType_0 = overriding.bulletType_0;
			}
			else if (overriden.bulletType_0 != BulletType.NotDefined)
			{
				bulletType_0 = BulletType.None;
			}
		}
		if (nullableBool_0 == NullableBool.NotDefined)
		{
			if (overriding.nullableBool_0 != NullableBool.NotDefined)
			{
				nullableBool_0 = overriding.nullableBool_0;
			}
			else if (overriden.nullableBool_0 != NullableBool.NotDefined)
			{
				nullableBool_0 = NullableBool.False;
			}
		}
		if (nullableBool_1 == NullableBool.NotDefined)
		{
			if (overriding.nullableBool_1 != NullableBool.NotDefined)
			{
				nullableBool_1 = overriding.nullableBool_1;
			}
			else if (overriden.nullableBool_1 != NullableBool.NotDefined)
			{
				nullableBool_1 = NullableBool.False;
			}
		}
		if (PPTXUnsupportedProps.BulletChar == -1)
		{
			if (overriding.PPTXUnsupportedProps.BulletChar != -1)
			{
				PPTXUnsupportedProps.BulletChar = overriding.PPTXUnsupportedProps.BulletChar;
			}
			else if (overriden.PPTXUnsupportedProps.BulletChar != -1)
			{
				PPTXUnsupportedProps.BulletChar = 8224;
			}
		}
		if (ifontData_0 == null)
		{
			if (overriding.ifontData_0 != null)
			{
				ifontData_0 = overriding.ifontData_0;
			}
			else if (overriden.ifontData_0 != null)
			{
				ifontData_0 = FontData.fontData_0;
			}
		}
		if (float.IsNaN(float_0))
		{
			if (!float.IsNaN(overriding.float_0))
			{
				float_0 = overriding.float_0;
			}
			else if (!float.IsNaN(overriden.float_0))
			{
				float_0 = 100f;
			}
		}
		if (colorFormat_0.ColorType == ColorType.NotDefined)
		{
			if (overriding.colorFormat_0.ColorType != ColorType.NotDefined)
			{
				colorFormat_0.method_0(overriding.colorFormat_0);
			}
			else if (overriden.colorFormat_0.ColorType != ColorType.NotDefined)
			{
				colorFormat_0.PresetColor = PresetColor.Black;
			}
		}
		if (short_0 == -1)
		{
			if (overriding.short_0 != -1)
			{
				short_0 = overriding.short_0;
			}
			else if (overriden.short_0 != -1)
			{
				short_0 = 1;
			}
		}
		if (Picture.Image == null)
		{
			if (overriding.Picture.Image != null)
			{
				Picture.method_0(overriding.Picture);
			}
			else if (overriden.Picture.Image != null)
			{
				picture_0 = null;
			}
		}
	}

	private void method_6()
	{
		uint_0++;
	}
}
