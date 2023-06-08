using System;
using System.Drawing;
using System.Text;
using ns24;

namespace Aspose.Slides;

public class ColorFormat : IFillParamSource, IColorFormat
{
	private ColorType colorType_0;

	internal int int_0;

	internal float float_0;

	internal float float_1;

	internal float float_2;

	private ColorOperationCollection colorOperationCollection_0 = new ColorOperationCollection();

	private ISlideComponent islideComponent_0;

	private Class329 class329_0 = new Class329();

	private uint uint_0;

	private static readonly FloatColor[] floatColor_0 = new FloatColor[30]
	{
		new FloatColor(SystemColors.ScrollBar),
		new FloatColor(SystemColors.Desktop),
		new FloatColor(SystemColors.ActiveCaption),
		new FloatColor(SystemColors.InactiveCaption),
		new FloatColor(SystemColors.Menu),
		new FloatColor(SystemColors.Window),
		new FloatColor(SystemColors.WindowFrame),
		new FloatColor(SystemColors.MenuText),
		new FloatColor(SystemColors.WindowText),
		new FloatColor(SystemColors.ActiveCaptionText),
		new FloatColor(SystemColors.ActiveBorder),
		new FloatColor(SystemColors.InactiveBorder),
		new FloatColor(SystemColors.AppWorkspace),
		new FloatColor(SystemColors.Highlight),
		new FloatColor(SystemColors.HighlightText),
		new FloatColor(SystemColors.Control),
		new FloatColor(SystemColors.ControlDark),
		new FloatColor(SystemColors.GrayText),
		new FloatColor(SystemColors.ControlText),
		new FloatColor(SystemColors.InactiveCaptionText),
		new FloatColor(SystemColors.ControlLight),
		new FloatColor(SystemColors.ControlDark),
		new FloatColor(SystemColors.ControlLight),
		new FloatColor(SystemColors.InfoText),
		new FloatColor(SystemColors.Info),
		new FloatColor(SystemColors.HotTrack),
		new FloatColor(SystemColors.ActiveCaption),
		new FloatColor(SystemColors.InactiveCaption),
		new FloatColor(SystemColors.Highlight),
		new FloatColor(SystemColors.Menu)
	};

	private static readonly FloatColor[] floatColor_1 = new FloatColor[140]
	{
		new FloatColor(Color.AliceBlue),
		new FloatColor(Color.AntiqueWhite),
		new FloatColor(Color.Aqua),
		new FloatColor(Color.Aquamarine),
		new FloatColor(Color.Azure),
		new FloatColor(Color.Beige),
		new FloatColor(Color.Bisque),
		new FloatColor(Color.Black),
		new FloatColor(Color.BlanchedAlmond),
		new FloatColor(Color.Blue),
		new FloatColor(Color.BlueViolet),
		new FloatColor(Color.Brown),
		new FloatColor(Color.BurlyWood),
		new FloatColor(Color.CadetBlue),
		new FloatColor(Color.Chartreuse),
		new FloatColor(Color.Chocolate),
		new FloatColor(Color.Coral),
		new FloatColor(Color.CornflowerBlue),
		new FloatColor(Color.Cornsilk),
		new FloatColor(Color.Crimson),
		new FloatColor(Color.Cyan),
		new FloatColor(Color.DarkBlue),
		new FloatColor(Color.DarkCyan),
		new FloatColor(Color.DarkGoldenrod),
		new FloatColor(Color.DarkGray),
		new FloatColor(Color.DarkGreen),
		new FloatColor(Color.DarkKhaki),
		new FloatColor(Color.DarkMagenta),
		new FloatColor(Color.DarkOliveGreen),
		new FloatColor(Color.DarkOrange),
		new FloatColor(Color.DarkOrchid),
		new FloatColor(Color.DarkRed),
		new FloatColor(Color.DarkSalmon),
		new FloatColor(Color.DarkSeaGreen),
		new FloatColor(Color.DarkSlateBlue),
		new FloatColor(Color.DarkSlateGray),
		new FloatColor(Color.DarkTurquoise),
		new FloatColor(Color.DarkViolet),
		new FloatColor(Color.DeepPink),
		new FloatColor(Color.DeepSkyBlue),
		new FloatColor(Color.DimGray),
		new FloatColor(Color.DodgerBlue),
		new FloatColor(Color.Firebrick),
		new FloatColor(Color.FloralWhite),
		new FloatColor(Color.ForestGreen),
		new FloatColor(Color.Fuchsia),
		new FloatColor(Color.Gainsboro),
		new FloatColor(Color.GhostWhite),
		new FloatColor(Color.Gold),
		new FloatColor(Color.Goldenrod),
		new FloatColor(Color.Gray),
		new FloatColor(Color.Green),
		new FloatColor(Color.GreenYellow),
		new FloatColor(Color.Honeydew),
		new FloatColor(Color.HotPink),
		new FloatColor(Color.IndianRed),
		new FloatColor(Color.Indigo),
		new FloatColor(Color.Ivory),
		new FloatColor(Color.Khaki),
		new FloatColor(Color.Lavender),
		new FloatColor(Color.LavenderBlush),
		new FloatColor(Color.LawnGreen),
		new FloatColor(Color.LemonChiffon),
		new FloatColor(Color.LightBlue),
		new FloatColor(Color.LightCoral),
		new FloatColor(Color.LightCyan),
		new FloatColor(Color.LightGoldenrodYellow),
		new FloatColor(Color.LightGray),
		new FloatColor(Color.LightGreen),
		new FloatColor(Color.LightPink),
		new FloatColor(Color.LightSalmon),
		new FloatColor(Color.LightSeaGreen),
		new FloatColor(Color.LightSkyBlue),
		new FloatColor(Color.LightSlateGray),
		new FloatColor(Color.LightSteelBlue),
		new FloatColor(Color.LightYellow),
		new FloatColor(Color.Lime),
		new FloatColor(Color.LimeGreen),
		new FloatColor(Color.Linen),
		new FloatColor(Color.Magenta),
		new FloatColor(Color.Maroon),
		new FloatColor(Color.MediumAquamarine),
		new FloatColor(Color.MediumBlue),
		new FloatColor(Color.MediumOrchid),
		new FloatColor(Color.MediumPurple),
		new FloatColor(Color.MediumSeaGreen),
		new FloatColor(Color.MediumSlateBlue),
		new FloatColor(Color.MediumSpringGreen),
		new FloatColor(Color.MediumTurquoise),
		new FloatColor(Color.MediumVioletRed),
		new FloatColor(Color.MidnightBlue),
		new FloatColor(Color.MintCream),
		new FloatColor(Color.MistyRose),
		new FloatColor(Color.Moccasin),
		new FloatColor(Color.NavajoWhite),
		new FloatColor(Color.Navy),
		new FloatColor(Color.OldLace),
		new FloatColor(Color.Olive),
		new FloatColor(Color.OliveDrab),
		new FloatColor(Color.Orange),
		new FloatColor(Color.OrangeRed),
		new FloatColor(Color.Orchid),
		new FloatColor(Color.PaleGoldenrod),
		new FloatColor(Color.PaleGreen),
		new FloatColor(Color.PaleTurquoise),
		new FloatColor(Color.PaleVioletRed),
		new FloatColor(Color.PapayaWhip),
		new FloatColor(Color.PeachPuff),
		new FloatColor(Color.Peru),
		new FloatColor(Color.Pink),
		new FloatColor(Color.Plum),
		new FloatColor(Color.PowderBlue),
		new FloatColor(Color.Purple),
		new FloatColor(Color.Red),
		new FloatColor(Color.RosyBrown),
		new FloatColor(Color.RoyalBlue),
		new FloatColor(Color.SaddleBrown),
		new FloatColor(Color.Salmon),
		new FloatColor(Color.SandyBrown),
		new FloatColor(Color.SeaGreen),
		new FloatColor(Color.SeaShell),
		new FloatColor(Color.Sienna),
		new FloatColor(Color.Silver),
		new FloatColor(Color.SkyBlue),
		new FloatColor(Color.SlateBlue),
		new FloatColor(Color.SlateGray),
		new FloatColor(Color.Snow),
		new FloatColor(Color.SpringGreen),
		new FloatColor(Color.SteelBlue),
		new FloatColor(Color.Tan),
		new FloatColor(Color.Teal),
		new FloatColor(Color.Thistle),
		new FloatColor(Color.Tomato),
		new FloatColor(Color.Turquoise),
		new FloatColor(Color.Violet),
		new FloatColor(Color.Wheat),
		new FloatColor(Color.White),
		new FloatColor(Color.WhiteSmoke),
		new FloatColor(Color.Yellow),
		new FloatColor(Color.YellowGreen)
	};

	internal Class329 PPTXUnsupportedProps => class329_0;

	internal FloatColor RawFloatColor => method_2((islideComponent_0 != null) ? islideComponent_0.Slide : null, null);

	internal Color RawColor
	{
		get
		{
			FloatColor rawFloatColor = RawFloatColor;
			return Color.FromArgb((int)Math.Round(FloatColor.smethod_3(rawFloatColor.float_1 * 255f, 0f, 255f)), (int)Math.Round(FloatColor.smethod_3(rawFloatColor.float_2 * 255f, 0f, 255f)), (int)Math.Round(FloatColor.smethod_3(rawFloatColor.float_3 * 255f, 0f, 255f)));
		}
	}

	internal FloatColor FColor
	{
		get
		{
			FloatColor rawFloatColor = RawFloatColor;
			colorOperationCollection_0.method_0(rawFloatColor);
			return rawFloatColor;
		}
	}

	public Color Color
	{
		get
		{
			FloatColor rawFloatColor = RawFloatColor;
			colorOperationCollection_0.method_0(rawFloatColor);
			return rawFloatColor.Color;
		}
		set
		{
			if (value.IsEmpty)
			{
				float num = float.NaN;
				float_2 = float.NaN;
				float num2 = float.NaN;
				float_1 = num;
				float_0 = num2;
				ColorTransform.Add(ColorTransformOperation.SetAlpha, 0f);
			}
			else
			{
				colorType_0 = ColorType.RGB;
				float_0 = (int)value.R;
				float_1 = (int)value.G;
				float_2 = (int)value.B;
				ColorTransform.Clear();
				if (value.A != byte.MaxValue)
				{
					ColorTransform.Add(ColorTransformOperation.SetAlpha, (float)(int)value.A / 255f);
				}
			}
			method_12();
		}
	}

	public ColorType ColorType
	{
		get
		{
			return colorType_0;
		}
		set
		{
			if (colorType_0 != value)
			{
				switch (value)
				{
				case ColorType.RGB:
				{
					FloatColor fColor3 = FColor;
					float_0 = (float)Math.Round(fColor3.float_1 * 255f);
					float_1 = (float)Math.Round(fColor3.float_2 * 255f);
					float_2 = (float)Math.Round(fColor3.float_3 * 255f);
					break;
				}
				case ColorType.RGBPercentage:
				{
					FloatColor fColor2 = FColor;
					float_0 = fColor2.float_1;
					float_1 = fColor2.float_2;
					float_2 = fColor2.float_3;
					break;
				}
				case ColorType.HSL:
				{
					FloatColor fColor = FColor;
					smethod_4(fColor.float_1, fColor.float_2, fColor.float_3, out float_0, out float_1, out float_2);
					break;
				}
				case ColorType.Scheme:
				case ColorType.System:
				case ColorType.Preset:
					int_0 = 0;
					PPTXUnsupportedProps.LastColor = default(Color);
					break;
				}
				colorType_0 = value;
			}
			method_12();
		}
	}

	public PresetColor PresetColor
	{
		get
		{
			if (colorType_0 != ColorType.Preset)
			{
				return PresetColor.NotDefined;
			}
			return (PresetColor)int_0;
		}
		set
		{
			if (value == PresetColor.NotDefined)
			{
				if (colorType_0 == ColorType.Preset)
				{
					ColorType = ColorType.RGB;
				}
				else
				{
					Color = Color.Black;
				}
				return;
			}
			if (colorType_0 != ColorType.Preset)
			{
				ColorType = ColorType.Preset;
			}
			int_0 = (int)value;
			method_12();
		}
	}

	public SystemColor SystemColor
	{
		get
		{
			if (colorType_0 != ColorType.System)
			{
				return SystemColor.NotDefined;
			}
			return (SystemColor)int_0;
		}
		set
		{
			if (value == SystemColor.NotDefined && colorType_0 == ColorType.System)
			{
				ColorType = ColorType.RGB;
				return;
			}
			if (colorType_0 != ColorType.System)
			{
				ColorType = ColorType.System;
			}
			int_0 = (int)value;
			method_12();
		}
	}

	public SchemeColor SchemeColor
	{
		get
		{
			if (colorType_0 != ColorType.Scheme)
			{
				return SchemeColor.NotDefined;
			}
			return (SchemeColor)int_0;
		}
		set
		{
			if (value == SchemeColor.NotDefined && colorType_0 == ColorType.Scheme)
			{
				ColorType = ColorType.RGB;
				return;
			}
			if (colorType_0 != ColorType.Scheme)
			{
				ColorType = ColorType.Scheme;
			}
			int_0 = (int)value;
			method_12();
		}
	}

	public byte R
	{
		get
		{
			if (colorType_0 == ColorType.RGB)
			{
				return (byte)float_0;
			}
			return RawColor.R;
		}
		set
		{
			if (colorType_0 != 0)
			{
				ColorType = ColorType.RGB;
			}
			float_0 = FloatColor.smethod_3((int)value, 0f, 255f);
			method_12();
		}
	}

	public byte G
	{
		get
		{
			if (colorType_0 == ColorType.RGB)
			{
				return (byte)float_1;
			}
			return RawColor.G;
		}
		set
		{
			if (colorType_0 != 0)
			{
				ColorType = ColorType.RGB;
			}
			float_1 = FloatColor.smethod_3((int)value, 0f, 255f);
			method_12();
		}
	}

	public byte B
	{
		get
		{
			if (colorType_0 == ColorType.RGB)
			{
				return (byte)float_2;
			}
			return RawColor.B;
		}
		set
		{
			if (colorType_0 != 0)
			{
				ColorType = ColorType.RGB;
			}
			float_2 = FloatColor.smethod_3((int)value, 0f, 255f);
			method_12();
		}
	}

	public float FloatR
	{
		get
		{
			if (colorType_0 == ColorType.RGBPercentage)
			{
				return float_0;
			}
			return RawFloatColor.float_1;
		}
		set
		{
			if (colorType_0 != ColorType.RGBPercentage)
			{
				ColorType = ColorType.RGBPercentage;
			}
			float_0 = FloatColor.smethod_3(value, 0f, 1f);
			method_12();
		}
	}

	public float FloatG
	{
		get
		{
			if (colorType_0 == ColorType.RGBPercentage)
			{
				return float_1;
			}
			return RawFloatColor.float_2;
		}
		set
		{
			if (colorType_0 != ColorType.RGBPercentage)
			{
				ColorType = ColorType.RGBPercentage;
			}
			float_1 = FloatColor.smethod_3(value, 0f, 1f);
			method_12();
		}
	}

	public float FloatB
	{
		get
		{
			if (colorType_0 == ColorType.RGBPercentage)
			{
				return float_2;
			}
			return RawFloatColor.float_3;
		}
		set
		{
			if (colorType_0 != ColorType.RGBPercentage)
			{
				ColorType = ColorType.RGBPercentage;
			}
			float_2 = FloatColor.smethod_3(value, 0f, 1f);
			method_12();
		}
	}

	public float Hue
	{
		get
		{
			if (colorType_0 == ColorType.HSL)
			{
				return float_0;
			}
			FloatColor rawFloatColor = RawFloatColor;
			return smethod_0(rawFloatColor.float_1, rawFloatColor.float_2, rawFloatColor.float_3);
		}
		set
		{
			if (colorType_0 != ColorType.HSL)
			{
				ColorType = ColorType.HSL;
			}
			value %= 360f;
			if (value < 0f)
			{
				value += 360f;
			}
			float_0 = value;
			method_12();
		}
	}

	public float Saturation
	{
		get
		{
			if (colorType_0 == ColorType.HSL)
			{
				return float_1;
			}
			FloatColor rawFloatColor = RawFloatColor;
			return smethod_1(rawFloatColor.float_1, rawFloatColor.float_2, rawFloatColor.float_3);
		}
		set
		{
			if (colorType_0 != ColorType.HSL)
			{
				ColorType = ColorType.HSL;
			}
			float_1 = FloatColor.smethod_3(value, 0f, 1f);
			method_12();
		}
	}

	public float Luminance
	{
		get
		{
			if (colorType_0 == ColorType.HSL)
			{
				return float_2;
			}
			FloatColor rawFloatColor = RawFloatColor;
			return smethod_2(rawFloatColor.float_1, rawFloatColor.float_2, rawFloatColor.float_3);
		}
		set
		{
			if (colorType_0 != ColorType.HSL)
			{
				ColorType = ColorType.HSL;
			}
			float_2 = FloatColor.smethod_3(value, 0f, 1f);
			method_12();
		}
	}

	public IColorOperationCollection ColorTransform => colorOperationCollection_0;

	internal uint Version => uint_0 + colorOperationCollection_0.Version;

	internal ISlideComponent Parent
	{
		get
		{
			return islideComponent_0;
		}
		set
		{
			islideComponent_0 = value;
			method_12();
		}
	}

	IFillParamSource IColorFormat.AsIFillParamSource => this;

	internal ColorFormat(ISlideComponent parent)
	{
		islideComponent_0 = parent;
		ColorType = ColorType.NotDefined;
	}

	internal ColorFormat(ISlideComponent parent, PresetColor preset)
		: this(parent)
	{
		PresetColor = preset;
	}

	internal ColorFormat(ISlideComponent parent, SchemeColor schemeColor)
		: this(parent)
	{
		SchemeColor = schemeColor;
	}

	internal ColorFormat(ISlideComponent parent, Color color)
		: this(parent)
	{
		Color = color;
	}

	internal ColorFormat(ISlideComponent parent, ColorFormat color)
		: this(parent)
	{
		float_0 = color.float_0;
		float_1 = color.float_1;
		float_2 = color.float_2;
		colorType_0 = color.colorType_0;
		int_0 = color.int_0;
		PPTXUnsupportedProps.LastColor = color.PPTXUnsupportedProps.LastColor;
		colorOperationCollection_0 = (ColorOperationCollection)color.colorOperationCollection_0.Clone();
	}

	public void CopyFrom(IColorFormat color)
	{
		method_0(color);
	}

	internal void method_0(IColorFormat color)
	{
		ColorFormat colorFormat = (ColorFormat)color;
		float_0 = colorFormat.float_0;
		float_1 = colorFormat.float_1;
		float_2 = colorFormat.float_2;
		colorType_0 = colorFormat.colorType_0;
		int_0 = colorFormat.int_0;
		PPTXUnsupportedProps.LastColor = colorFormat.PPTXUnsupportedProps.LastColor;
		colorOperationCollection_0 = (ColorOperationCollection)colorFormat.colorOperationCollection_0.Clone();
		method_12();
	}

	internal void method_1(Color color)
	{
		Color = color;
		method_12();
	}

	internal void Clear()
	{
		colorType_0 = ColorType.NotDefined;
		float num = 0f;
		float_2 = 0f;
		float num2 = 0f;
		float_1 = num;
		float_0 = num2;
		colorOperationCollection_0.Clear();
		method_12();
	}

	internal FloatColor method_2(IBaseSlide colorMappingSlide, FloatColor styleColor)
	{
		switch (colorType_0)
		{
		default:
			return new FloatColor(float.NaN, float.NaN, float.NaN);
		case ColorType.RGB:
			return new FloatColor(float_0 / 255f, float_1 / 255f, float_2 / 255f);
		case ColorType.RGBPercentage:
			return new FloatColor(float_0, float_1, float_2);
		case ColorType.HSL:
			return smethod_3(float_0, float_1, float_2);
		case ColorType.Scheme:
		{
			SchemeColor schemeColor = SchemeColor;
			if (schemeColor == SchemeColor.StyleColor && styleColor != null)
			{
				return new FloatColor(styleColor);
			}
			if (colorMappingSlide == null)
			{
				return new FloatColor(0f, 0f, 0f);
			}
			return ((BaseSlide)colorMappingSlide).method_2(SchemeColor).FColor;
		}
		case ColorType.System:
			return new FloatColor(floatColor_0[int_0 & 0x7F]);
		case ColorType.Preset:
			return new FloatColor(floatColor_1[int_0]);
		}
	}

	internal FloatColor method_3(IBaseSlide colorMappingSlide)
	{
		FloatColor floatColor = method_2(colorMappingSlide, null);
		colorOperationCollection_0.method_0(floatColor);
		return floatColor;
	}

	internal FloatColor method_4(IBaseSlide colorMappingSlide, FloatColor styleColor)
	{
		FloatColor floatColor = method_2(colorMappingSlide, styleColor);
		colorOperationCollection_0.method_0(floatColor);
		return floatColor;
	}

	internal Color method_5(IBaseSlide slide, FloatColor styleColor)
	{
		FloatColor floatColor = method_2(slide, styleColor);
		colorOperationCollection_0.method_0(floatColor);
		return floatColor.Color;
	}

	internal void method_6(ColorType colorType)
	{
		colorType_0 = colorType;
		method_12();
	}

	internal void method_7(float _data0)
	{
		float_0 = _data0;
		method_12();
	}

	internal void method_8(float _data1)
	{
		float_1 = _data1;
		method_12();
	}

	internal void method_9(float _data2)
	{
		float_2 = _data2;
		method_12();
	}

	internal void method_10(SystemColor systemColor, Color lastColor)
	{
		if (systemColor == SystemColor.NotDefined && colorType_0 == ColorType.System)
		{
			ColorType = ColorType.RGB;
			return;
		}
		if (colorType_0 != ColorType.System)
		{
			ColorType = ColorType.System;
		}
		int_0 = (int)systemColor;
		PPTXUnsupportedProps.LastColor = lastColor;
		method_12();
	}

	private static float smethod_0(float r, float g, float b)
	{
		float num = r;
		float num2 = r;
		if (g < num)
		{
			num = g;
		}
		if (g > num2)
		{
			num2 = g;
		}
		if (b < num)
		{
			num = b;
		}
		if (b > num2)
		{
			num2 = b;
		}
		if (num == num2)
		{
			return 0f;
		}
		if (num2 == r)
		{
			if (g < b)
			{
				return 60f * (g - b) / (num2 - num) + 360f;
			}
			return 60f * (g - b) / (num2 - num);
		}
		if (num2 == g)
		{
			return 60f * (b - r) / (num2 - num) + 360f;
		}
		return 60f * (r - g) / (num2 - num) + 360f;
	}

	private static float smethod_1(float r, float g, float b)
	{
		float num = r;
		float num2 = r;
		if (g < num)
		{
			num = g;
		}
		if (g > num2)
		{
			num2 = g;
		}
		if (b < num)
		{
			num = b;
		}
		if (b > num2)
		{
			num2 = b;
		}
		if (num == num2)
		{
			return 0f;
		}
		float num3 = num + num2;
		if (num2 != num && num3 != 0f)
		{
			if (num3 > 1f)
			{
				return (num2 - num) / (2f - num3);
			}
			return (num2 - num) / num3;
		}
		return 0f;
	}

	private static float smethod_2(float r, float g, float b)
	{
		float num = r;
		float num2 = r;
		if (g < num)
		{
			num = g;
		}
		if (g > num2)
		{
			num2 = g;
		}
		if (b < num)
		{
			num = b;
		}
		if (b > num2)
		{
			num2 = b;
		}
		return (num + num2) / 2f;
	}

	internal static FloatColor smethod_3(float hue, float saturation, float luminance)
	{
		return FloatColor.smethod_0(hue, saturation, luminance);
	}

	internal static void smethod_4(float r, float g, float b, out float hue, out float saturation, out float luminance)
	{
		float num = r;
		float num2 = r;
		if (g < num)
		{
			num = g;
		}
		if (g > num2)
		{
			num2 = g;
		}
		if (b < num)
		{
			num = b;
		}
		if (b > num2)
		{
			num2 = b;
		}
		if (num == num2)
		{
			hue = 0f;
		}
		else if (num2 == r)
		{
			if (g < b)
			{
				hue = 60f * (g - b) / (num2 - num) + 360f;
			}
			else
			{
				hue = 60f * (g - b) / (num2 - num);
			}
		}
		else if (num2 == g)
		{
			hue = 60f * (b - r) / (num2 - num) + 120f;
		}
		else
		{
			hue = 60f * (r - g) / (num2 - num) + 240f;
		}
		hue %= 360f;
		if (hue < 0f)
		{
			hue += 360f;
		}
		luminance = FloatColor.smethod_3((num + num2) / 2f, 0f, 1f);
		if (num2 != num && luminance != 0f)
		{
			if (luminance > 0.5f)
			{
				saturation = (num2 - num) / (1f - luminance) / 2f;
			}
			else
			{
				saturation = (num2 - num) / luminance / 2f;
			}
		}
		else
		{
			saturation = 0f;
		}
	}

	public override bool Equals(object obj)
	{
		if (!(obj is ColorFormat colorFormat))
		{
			return base.Equals(obj);
		}
		if (colorType_0 != colorFormat.colorType_0)
		{
			return false;
		}
		switch (colorType_0)
		{
		case ColorType.RGB:
		case ColorType.RGBPercentage:
		case ColorType.HSL:
			if (float_0 != colorFormat.float_0 || float_1 != colorFormat.float_1 || float_2 != colorFormat.float_2)
			{
				return false;
			}
			goto default;
		case ColorType.Scheme:
		case ColorType.System:
		case ColorType.Preset:
			if (int_0 != colorFormat.int_0 || PPTXUnsupportedProps.LastColor != colorFormat.PPTXUnsupportedProps.LastColor)
			{
				break;
			}
			goto default;
		default:
		{
			IColorOperationCollection colorTransform = ColorTransform;
			IColorOperationCollection colorTransform2 = colorFormat.ColorTransform;
			if (colorTransform.Count != colorTransform2.Count)
			{
				return false;
			}
			int num = 0;
			while (true)
			{
				if (num < ColorTransform.Count)
				{
					if (!colorTransform[num].Equals(colorTransform2[num]))
					{
						break;
					}
					num++;
					continue;
				}
				return true;
			}
			return false;
		}
		}
		return false;
	}

	public override int GetHashCode()
	{
		return 23455;
	}

	public string ToString(ColorStringFormat format)
	{
		if (format != 0)
		{
			throw new IndexOutOfRangeException();
		}
		return method_11();
	}

	public override string ToString()
	{
		return colorType_0 switch
		{
			ColorType.RGB => $"RGB color: {R}, {G}, {B}", 
			ColorType.RGBPercentage => $"RGB percentage: {FloatR}, {FloatG}, {FloatB}", 
			ColorType.HSL => $"HSL color: {Hue}, {Saturation}, {Luminance}", 
			ColorType.Scheme => $"Scheme color: {SchemeColor}", 
			ColorType.System => $"System color: {SystemColor}", 
			ColorType.Preset => $"Preset color: {PresetColor}", 
			_ => "Undefined color", 
		};
	}

	private string method_11()
	{
		StringBuilder stringBuilder = new StringBuilder();
		ColorFormat colorFormat = this;
		string text = null;
		int num = -1;
		if (colorFormat.ColorType == ColorType.Scheme)
		{
			num = (int)colorFormat.SchemeColor;
			if (colorFormat.Parent != null)
			{
				BaseSlide baseSlide = (BaseSlide)colorFormat.Parent.Slide;
				colorFormat = ((baseSlide == null) ? new ColorFormat(null, Color.Black) : baseSlide.method_2(colorFormat.SchemeColor));
			}
			else
			{
				colorFormat = new ColorFormat(null, Color.Black);
			}
		}
		if (colorFormat.ColorType == ColorType.Preset)
		{
			switch (colorFormat.PresetColor)
			{
			case PresetColor.Black:
				text = "black";
				break;
			case PresetColor.Blue:
				text = "blue";
				break;
			case PresetColor.Aqua:
				text = "aqua";
				break;
			case PresetColor.Lime:
				text = "lime";
				break;
			case PresetColor.Gray:
				text = "gray";
				break;
			case PresetColor.Green:
				text = "green";
				break;
			case PresetColor.Fuchsia:
				text = "fuchsia";
				break;
			case PresetColor.Purple:
				text = "purple";
				break;
			case PresetColor.Red:
				text = "red";
				break;
			case PresetColor.Navy:
				text = "navy";
				break;
			case PresetColor.Olive:
				text = "olive";
				break;
			case PresetColor.Maroon:
				text = "maroon";
				break;
			case PresetColor.White:
				text = "white";
				break;
			case PresetColor.Yellow:
				text = "yellow";
				break;
			case PresetColor.Teal:
				text = "teal";
				break;
			case PresetColor.Silver:
				text = "silver";
				break;
			}
		}
		if (text != null || num >= 0)
		{
			bool flag = false;
			for (int i = 0; i < ColorTransform.Count; i++)
			{
				if (!((ColorOperation)ColorTransform[i]).IsAlphaOperation)
				{
					flag = true;
					break;
				}
			}
			if (!flag && colorFormat != this)
			{
				for (int j = 0; j < colorFormat.ColorTransform.Count; j++)
				{
					if (!((ColorOperation)colorFormat.ColorTransform[j]).IsAlphaOperation)
					{
						flag = true;
						break;
					}
				}
			}
			if (flag)
			{
				text = null;
				num = -1;
			}
		}
		Color color = method_5(Parent.Slide, FloatColor.floatColor_0);
		if (text != null)
		{
			stringBuilder.Append(text);
		}
		else
		{
			stringBuilder.AppendFormat("#{0:x2}{1:x2}{2:x2}", color.R, color.G, color.B);
		}
		if (num >= 0)
		{
			stringBuilder.AppendFormat(" [{0}]", num);
		}
		return stringBuilder.ToString();
	}

	private void method_12()
	{
		uint_0++;
	}
}
