using System;
using System.Drawing;

namespace ns28;

internal class Class470
{
	internal static readonly Class467 class467_0 = new Class467("none", "solid", "bitmap", "gradient", "hatch");

	internal static readonly Class467 class467_1 = new Class467("top-left", "top", "top-right", "left", "center", "right", "bottom-left", "bottom", "bottom-right");

	internal static readonly Class467 class467_2 = new Class467("no-repeat", "repeat", "stretch");

	internal static readonly Class467 class467_3 = new Class467("nonzero", "evenodd");

	protected Enum36 enum36_0;

	protected Color color_0;

	protected Color color_1;

	protected string string_0;

	protected string string_1;

	protected string string_2;

	protected string string_3;

	protected string string_4;

	protected bool bool_0;

	protected double double_0;

	protected double double_1;

	protected Enum37 enum37_0;

	protected int int_0;

	protected int int_1;

	protected int int_2;

	protected Enum38 enum38_0;

	protected Enum39 enum39_0;

	protected Class369 class369_0;

	internal static readonly string string_5 = "urn:oasis:names:tc:opendocument:xmlns:drawing:1.0";

	internal static readonly string string_6 = "urn:oasis:names:tc:opendocument:xmlns:svg-compatible:1.0";

	internal Enum36 FillStyle
	{
		get
		{
			return enum36_0;
		}
		set
		{
			enum36_0 = value;
		}
	}

	internal Color FillColor
	{
		get
		{
			return color_0;
		}
		set
		{
			color_0 = value;
		}
	}

	internal Color SecondaryFillColor => color_1;

	internal Enum38 FillImageRenderingStyle
	{
		get
		{
			return enum38_0;
		}
		set
		{
			enum38_0 = value;
		}
	}

	internal string FillImageName
	{
		get
		{
			return string_2;
		}
		set
		{
			string_2 = value;
		}
	}

	internal double FillImageTileWidth
	{
		get
		{
			return double_1;
		}
		set
		{
			double_1 = value;
		}
	}

	internal double FillImageTileHeight
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
		}
	}

	internal string GradientName
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	internal int GradientStepCount => int_2;

	internal string HatchName
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

	internal Enum37 FillImageTileRefPoint
	{
		get
		{
			return enum37_0;
		}
		set
		{
			enum37_0 = value;
		}
	}

	internal int FillImageTileOffsetX
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	internal int FillImageTileOffsetY
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	public Class470()
	{
		enum36_0 = Enum36.const_5;
	}

	public Class470(Class369 source)
	{
		if (source != null)
		{
			method_0(source);
		}
	}

	internal void method_0(Class369 source)
	{
		if (source != null)
		{
			class369_0 = source;
			if (source.LocalName == "graphic-properties")
			{
				enum36_0 = (Enum36)source.method_9(class467_0, "fill", string_5, 1);
			}
			else
			{
				enum36_0 = (Enum36)source.method_9(class467_0, "fill", string_5, 0);
			}
			color_0 = source.method_16("fill-color", string_5, source.method_18("#99ccff"));
			string_0 = source.GetAttribute("fill-gradient-name", string_5);
			string_1 = source.GetAttribute("fill-hatch-name", string_5);
			bool_0 = source.method_3("fill-hatch-solid", string_5, defaultValue: false);
			double_0 = source.method_7("fill-image-height", string_5, 0.0);
			double_1 = source.method_7("fill-image-width", string_5, 0.0);
			string_2 = source.GetAttribute("fill-image-name", string_5);
			enum37_0 = (Enum37)source.method_9(class467_1, "fill-image-ref-point", string_5, 0);
			int_0 = source.method_11("fill-image-ref-point-x", string_5, 0);
			int_1 = source.method_11("fill-image-ref-point-y", string_5, 0);
			int_2 = source.method_13("gradient-step-count", string_5, 1);
			string_3 = source.GetAttribute("opacity-name", string_5);
			int num = source.method_11("opacity", string_5, 100);
			color_1 = source.method_16("secondary-fill-color", string_5, ColorTranslator.FromWin32(0));
			if (num < 100)
			{
				byte alpha = (byte)Math.Round((float)num / 100f * 255f);
				color_0 = Color.FromArgb(alpha, color_0);
				color_1 = Color.FromArgb(alpha, color_0);
			}
			enum38_0 = (Enum38)source.method_9(class467_2, "repeat", source.NamespaceURI, 1);
			string_4 = source.GetAttribute("tile-repeat-offset", string_5);
			enum39_0 = (Enum39)source.method_9(class467_3, "fill-rule", string_6, 0);
		}
	}

	internal void Write(Class369 target)
	{
		if (enum36_0 != Enum36.const_5 && (enum36_0 != 0 || target.LocalName != "drawing-page-properties"))
		{
			target.method_10(class467_0, "fill", string_5, (int)enum36_0);
		}
		if (color_0 != Color.Empty)
		{
			target.method_17("fill-color", string_5, color_0);
			if (color_0.A < byte.MaxValue)
			{
				target.SetAttribute("opacity", string_5, $"{(int)Math.Round((float)(color_0.A * 100) / 255f)}%");
			}
		}
		if (string_0 != null)
		{
			target.SetAttribute("fill-gradient-name", string_5, string_0);
		}
		if (string_3 != null)
		{
			target.SetAttribute("opacity-name", string_5, string_3);
		}
		if (color_1 != Color.Empty)
		{
			target.method_17("secondary-fill-color", string_5, color_1);
		}
		if (enum36_0 == Enum36.const_4)
		{
			if (string_1 != null)
			{
				target.SetAttribute("fill-hatch-name", string_5, string_1);
			}
			target.method_4("fill-hatch-solid", string_5, bool_0);
		}
		if (enum36_0 != Enum36.const_2)
		{
			return;
		}
		if (string_2 != null)
		{
			target.SetAttribute("fill-image-name", string_5, string_2);
		}
		if (enum38_0 == Enum38.const_1)
		{
			if (!double.IsNaN(double_1) && double_1 != 0.0)
			{
				target.method_8("fill-image-width", string_5, double_1);
			}
			if (!double.IsNaN(double_0) && double_0 != 0.0)
			{
				target.method_8("fill-image-height", string_5, double_0);
			}
			target.method_10(class467_1, "fill-image-ref-point", string_5, (int)enum37_0);
			if (int_0 != 0)
			{
				target.method_12("fill-image-ref-point-x", string_5, int_0);
			}
			if (int_1 != 0)
			{
				target.method_12("fill-image-ref-point-y", string_5, int_1);
			}
		}
		target.method_10(class467_1, "fill-image-ref-point", string_5, (int)enum37_0);
		target.method_10(class467_2, "repeat", target.NamespaceURI, (int)enum38_0);
		target.SetAttribute("tile-repeat-offset", string_5, string_4);
		target.method_10(class467_3, "fill-rule", string_6, (int)enum39_0);
	}
}
