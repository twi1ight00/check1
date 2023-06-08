using System;
using System.Drawing;
using System.IO;
using System.Text;
using ns221;
using ns271;

namespace ns237;

internal abstract class Class6527 : Class6511
{
	private FontStyle fontStyle_0;

	protected Class6730 class6730_0;

	private Enum873 enum873_0;

	protected string string_1;

	protected bool bool_0;

	public bool IsSimulateItalic
	{
		get
		{
			if ((fontStyle_0 & FontStyle.Italic) != 0)
			{
				return (class6730_0.Style & FontStyle.Italic) == 0;
			}
			return false;
		}
	}

	public bool IsSimulateBold
	{
		get
		{
			if ((fontStyle_0 & FontStyle.Bold) != 0)
			{
				return (class6730_0.Style & FontStyle.Bold) == 0;
			}
			return false;
		}
	}

	public string BaseFontName => string_1;

	public int Descent => -method_1(class6730_0.Descent);

	public int Ascent => method_1(class6730_0.Ascent);

	public int CapHeight => method_1(class6730_0.CapHeight);

	public int Flags
	{
		get
		{
			int num = 0;
			num = 32;
			num = 0x20 | (((class6730_0.Style & FontStyle.Italic) != 0) ? 64 : 0);
			return num | (((class6730_0.Style & FontStyle.Bold) != 0) ? 262144 : 0);
		}
	}

	public RectangleF BBox => new RectangleF(method_1(class6730_0.XMin), method_1(class6730_0.YMin), method_1(class6730_0.XMax - class6730_0.XMin), method_1(class6730_0.YMax - class6730_0.YMin));

	public float ItalicAngle => class6730_0.ItalicAngle;

	internal override Enum892 ResourceType => Enum892.const_1;

	internal Enum873 FontType => enum873_0;

	internal bool IsFullEmbedding
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	protected Class6527(Class6672 context, FontStyle requestedStyle, Class6730 font, Enum873 fontType)
		: base(context)
	{
		fontStyle_0 = requestedStyle;
		class6730_0 = font;
		enum873_0 = fontType;
		string_1 = vmethod_3();
	}

	[Attribute7(true)]
	public virtual void vmethod_2(Stream dstStream)
	{
	}

	public static Class6527 smethod_0(Class6672 context, FontStyle requestedStyle, Class6730 font, Enum873 fontType, Enum872 fontEmbeddingRule)
	{
		switch (fontType)
		{
		default:
			throw new InvalidOperationException("Unexpected font type.");
		case Enum873.const_0:
		case Enum873.const_1:
		case Enum873.const_2:
			return new Class6530(context, requestedStyle, font, fontType, fontEmbeddingRule);
		case Enum873.const_3:
			return new Class6529(context, requestedStyle, font, fontType);
		}
	}

	protected int method_1(int value)
	{
		return value * 1000 / class6730_0.EmHeight;
	}

	protected string method_2()
	{
		string text = class6730_0.PostscriptName;
		if (text == null)
		{
			text = class6730_0.FullFontName.Replace(" ", "#20");
		}
		return text;
	}

	protected virtual string vmethod_3()
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (!IsFullEmbedding)
		{
			stringBuilder.Append(string_0);
			stringBuilder.Append("+");
		}
		stringBuilder.Append(method_2());
		if (IsSimulateBold && IsSimulateItalic)
		{
			stringBuilder.Append(",BoldItalic");
		}
		else if (IsSimulateBold)
		{
			stringBuilder.Append(",Bold");
		}
		else if (IsSimulateItalic)
		{
			stringBuilder.Append(",Italic");
		}
		return stringBuilder.Replace(" ", string.Empty).ToString();
	}
}
