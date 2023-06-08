using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using ns21;
using ns22;

namespace Aspose.Cells.Drawing;

/// <summary>
///       Represents fill formatting for a shape. 
///       </summary>
public class MsoFillFormat
{
	private FillFormat fillFormat_0;

	/// <summary>
	///       Gets and sets the fill fore color.
	///       </summary>
	public Color ForeColor
	{
		get
		{
			Color color = Color.White;
			if (fillFormat_0.Type == FillType.Solid)
			{
				color = fillFormat_0.SolidFill.Color;
			}
			else if (fillFormat_0.Type == FillType.Pattern)
			{
				color = fillFormat_0.PatternFill.ForegroundColor;
			}
			if (Class1178.smethod_0(color))
			{
				color = Color.White;
			}
			return color;
		}
		set
		{
			if (fillFormat_0.Type == FillType.Solid)
			{
				fillFormat_0.SolidFill.Color = value;
			}
			else if (fillFormat_0.Type == FillType.Pattern)
			{
				fillFormat_0.PatternFill.ForegroundColor = value;
			}
			else if (fillFormat_0.Type == FillType.Automatic || fillFormat_0.Type == FillType.None)
			{
				fillFormat_0.Type = FillType.Solid;
				fillFormat_0.SolidFill.Color = value;
			}
		}
	}

	/// <summary>
	///       Returns or sets the degree of transparency of the specified fill as a value from 0.0 (opaque) through 1.0 (clear).
	///       </summary>
	public double Transparency
	{
		get
		{
			return Math.Round(1.0 - method_0(), 2);
		}
		set
		{
			method_1(1.0 - value);
		}
	}

	/// <summary>
	///       Gets and sets the file back color.
	///       </summary>
	public Color BackColor
	{
		get
		{
			Color color = Color.White;
			if (fillFormat_0.Type == FillType.Pattern)
			{
				color = fillFormat_0.PatternFill.BackgroundColor;
			}
			if (Class1178.smethod_0(color))
			{
				color = Color.White;
			}
			return color;
		}
		set
		{
			if (fillFormat_0.Type == FillType.Pattern)
			{
				fillFormat_0.PatternFill.BackgroundColor = value;
			}
		}
	}

	/// <summary>
	///       Gets and sets the Texture and Picture fill data.
	///       </summary>
	public byte[] ImageData
	{
		get
		{
			FillType type = fillFormat_0.Type;
			if (type == FillType.Texture)
			{
				return fillFormat_0.TextureFill.ImageData;
			}
			return null;
		}
		set
		{
			fillFormat_0.Type = FillType.Texture;
			fillFormat_0.TextureFill.ImageData = value;
		}
	}

	/// <summary>
	///       Gets the texture fill type.
	///       </summary>
	public TextureType Texture
	{
		get
		{
			TextureType result = TextureType.Unknown;
			if (fillFormat_0.Type == FillType.Texture)
			{
				result = fillFormat_0.TextureFill.Type;
			}
			return result;
		}
	}

	/// <summary>
	///       Indicats whether there is fill. 
	///       </summary>
	public bool IsVisible
	{
		get
		{
			bool result = true;
			if (fillFormat_0.method_1() != null && fillFormat_0.method_1() is Shape)
			{
				MsoDrawingType msoDrawingType = ((Shape)fillFormat_0.method_1()).MsoDrawingType;
				if (msoDrawingType == MsoDrawingType.Picture)
				{
					result = false;
				}
			}
			switch (fillFormat_0.Type)
			{
			default:
				return result;
			case FillType.None:
				return false;
			case FillType.Solid:
			case FillType.Gradient:
			case FillType.Texture:
			case FillType.Pattern:
				return true;
			}
		}
		set
		{
			if (value)
			{
				if (fillFormat_0.Type == FillType.None)
				{
					fillFormat_0.Type = FillType.Automatic;
				}
			}
			else
			{
				fillFormat_0.Type = FillType.None;
			}
		}
	}

	internal MsoFillFormat(FillFormat fillFormat_1)
	{
		fillFormat_0 = fillFormat_1;
	}

	[SpecialName]
	internal double method_0()
	{
		double result = 1.0;
		if (fillFormat_0.Type == FillType.Solid)
		{
			result = 1.0 - fillFormat_0.SolidFill.Transparency;
		}
		else if (fillFormat_0.Type == FillType.Texture)
		{
			result = 1.0 - fillFormat_0.TextureFill.Transparency;
		}
		else if (fillFormat_0.Type == FillType.Pattern)
		{
			result = 1.0 - fillFormat_0.PatternFill.method_2();
		}
		return result;
	}

	[SpecialName]
	internal void method_1(double double_0)
	{
		if (fillFormat_0.Type == FillType.Solid)
		{
			fillFormat_0.SolidFill.Transparency = 1.0 - double_0;
		}
		else if (fillFormat_0.Type == FillType.Texture)
		{
			fillFormat_0.TextureFill.Transparency = 1.0 - double_0;
		}
		else if (fillFormat_0.Type == FillType.Pattern)
		{
			fillFormat_0.PatternFill.method_3(1.0 - double_0);
		}
	}

	[SpecialName]
	internal string method_2()
	{
		if (fillFormat_0.Type == FillType.Texture)
		{
			return fillFormat_0.TextureFill.string_0;
		}
		return "";
	}

	[SpecialName]
	internal void method_3(string string_0)
	{
		if (fillFormat_0.Type == FillType.Texture)
		{
			fillFormat_0.TextureFill.string_0 = string_0;
		}
	}

	/// <summary>
	///       Sets the specified fill to a one-color gradient.
	///       </summary>
	/// <param name="color">One gradient color.</param>
	/// <param name="degree">The gradient degree. Can be a value from 0.0 (dark) through 1.0 (light).</param>
	/// <param name="style">Gradient shading style.</param>
	/// <param name="variant">The gradient variant. Can be a value from 1 through 4, corresponding to one of the four variants on the Gradient tab in the Fill Effects dialog box. If style is GradientStyle.FromCenter, the Variant argument can only be 1 or 2.</param>
	public void SetOneColorGradient(Color color, double degree, GradientStyleType style, int variant)
	{
		fillFormat_0.Type = FillType.Gradient;
		fillFormat_0.GradientFill.SetOneColorGradient(color, degree, style, variant);
	}

	[SpecialName]
	internal Enum174 method_4()
	{
		if (fillFormat_0.Type == FillType.Texture)
		{
			return fillFormat_0.TextureFill.enum174_0;
		}
		return Enum174.const_0;
	}

	[SpecialName]
	internal void method_5(Enum174 enum174_0)
	{
		if (fillFormat_0.Type == FillType.Texture)
		{
			fillFormat_0.TextureFill.enum174_0 = enum174_0;
		}
	}
}
