using System;
using System.Collections;
using System.Drawing;
using System.Runtime.CompilerServices;
using ns21;
using ns52;

namespace Aspose.Cells.Drawing;

/// <summary>
///       Encapsulates the object that represents fill formatting for a shape.
///       </summary>
/// <example>
///   <code>
///
///       [C#]
///
///       //Filling the area of the 2nd NSeries with a gradient
///       chart.NSeries[1].Area.FillFormat.SetOneColorGradient(Color.Lime, 1, GradientStyleType.Horizontal, 1);
///
///       [Visual Basic]
///
///       'Filling the area of the 2nd NSeries with a gradient
///       chart.NSeries(1).Area.FillFormat.SetOneColorGradient(Color.Lime, 1, GradientStyleType.Horizontal, 1)
///       </code>
/// </example>
public class FillFormat
{
	private object object_0;

	internal Workbook workbook_0;

	private object object_1;

	private FillType fillType_0;

	internal bool bool_0;

	public FillType Type
	{
		get
		{
			return fillType_0;
		}
		set
		{
			fillType_0 = value;
			switch (value)
			{
			case FillType.Automatic:
				object_0 = null;
				break;
			case FillType.None:
				object_0 = null;
				break;
			case FillType.Solid:
				if (object_0 == null || !(object_0 is SolidFill))
				{
					object_0 = new SolidFill(object_1, workbook_0);
				}
				method_2();
				break;
			case FillType.Gradient:
				if (object_0 == null || !(object_0 is GradientFill))
				{
					object_0 = new GradientFill(object_1, workbook_0);
				}
				method_2();
				break;
			case FillType.Texture:
				if (object_0 == null || !(object_0 is TextureFill))
				{
					object_0 = new TextureFill(object_1, workbook_0);
				}
				method_2();
				break;
			case FillType.Pattern:
				if (object_0 == null || !(object_0 is PatternFill))
				{
					object_0 = new PatternFill(object_1, workbook_0);
				}
				method_2();
				break;
			}
		}
	}

	/// <summary>
	///       Gets the fill format type.
	///       </summary>
	[Obsolete("Use FillFormat.Type property instead.")]
	public FormatSetType SetType
	{
		get
		{
			return Type switch
			{
				FillType.None => FormatSetType.None, 
				FillType.Gradient => FormatSetType.IsGradientSet, 
				FillType.Texture => FormatSetType.IsTextureSet, 
				FillType.Pattern => FormatSetType.IsPatternSet, 
				_ => FormatSetType.None, 
			};
		}
		set
		{
			switch (value)
			{
			case FormatSetType.None:
				Type = FillType.None;
				break;
			case FormatSetType.IsGradientSet:
				Type = FillType.Gradient;
				break;
			case FormatSetType.IsTextureSet:
				Type = FillType.Texture;
				break;
			case FormatSetType.IsPatternSet:
				Type = FillType.Pattern;
				break;
			}
		}
	}

	/// <summary>
	///       Gets <see cref="P:Aspose.Cells.Drawing.FillFormat.GradientFill" /> object.
	///       </summary>
	public GradientFill GradientFill
	{
		get
		{
			if (Type == FillType.Gradient)
			{
				if (object_0 == null || !(object_0 is GradientFill))
				{
					object_0 = new GradientFill(object_1, workbook_0);
					return (GradientFill)object_0;
				}
				if (object_0 != null && object_0 is GradientFill)
				{
					return (GradientFill)object_0;
				}
			}
			return null;
		}
	}

	public TextureFill TextureFill
	{
		get
		{
			if (Type == FillType.Texture)
			{
				if (object_0 == null || !(object_0 is TextureFill))
				{
					object_0 = new TextureFill(object_1, workbook_0);
					return (TextureFill)object_0;
				}
				if (object_0 != null && object_0 is TextureFill)
				{
					return (TextureFill)object_0;
				}
			}
			return null;
		}
	}

	public SolidFill SolidFill
	{
		get
		{
			if (Type == FillType.Solid)
			{
				if (object_0 == null || !(object_0 is SolidFill))
				{
					object_0 = new SolidFill(object_1, workbook_0);
					return (SolidFill)object_0;
				}
				if (object_0 != null && object_0 is SolidFill)
				{
					return (SolidFill)object_0;
				}
			}
			return null;
		}
	}

	public PatternFill PatternFill
	{
		get
		{
			if (Type == FillType.Pattern)
			{
				if (object_0 == null || !(object_0 is PatternFill))
				{
					object_0 = new PatternFill(object_1, workbook_0);
					return (PatternFill)object_0;
				}
				if (object_0 != null && object_0 is PatternFill)
				{
					return (PatternFill)object_0;
				}
			}
			return null;
		}
	}

	/// <summary>
	///       Returns the gradient color type for the specified fill.
	///       </summary>
	public GradientColorType GradientColorType
	{
		get
		{
			if (Type != FillType.Gradient)
			{
				throw new CellsException(ExceptionType.InvalidOperator, "Gradient option is not set.");
			}
			return GradientFill.GradientColorType;
		}
	}

	/// <summary>
	///       Returns the gradient style for the specified fill. 
	///       </summary>
	public GradientStyleType GradientStyle
	{
		get
		{
			if (Type != FillType.Gradient)
			{
				throw new CellsException(ExceptionType.InvalidOperator, "Gradient option is not set.");
			}
			return GradientFill.GradientStyle;
		}
	}

	/// <summary>
	///       Returns the gradient color 1 for the the specified fill.
	///       </summary>
	public Color GradientColor1
	{
		get
		{
			if (Type != FillType.Gradient)
			{
				throw new CellsException(ExceptionType.InvalidOperator, "Gradient option is not set.");
			}
			if (GradientFill.GradientColorType == GradientColorType.None)
			{
				throw new CellsException(ExceptionType.InvalidOperator, "The gradient color 1 is not set.");
			}
			return GradientFill.GradientColor1;
		}
	}

	/// <summary>
	///       Returns the gradient color 2 for the the specified fill.
	///       </summary>
	/// <remarks>Only when the graident color type is GradientColorType.TwoColors, this property is meaningful.</remarks>
	public Color GradientColor2
	{
		get
		{
			if (Type != FillType.Gradient)
			{
				throw new CellsException(ExceptionType.InvalidOperator, "Gradient option is not set.");
			}
			switch (GradientFill.GradientColorType)
			{
			case GradientColorType.None:
			case GradientColorType.OneColor:
				throw new CellsException(ExceptionType.InvalidOperator, "The gradient color 2 is not set.");
			default:
				return GradientFill.GradientColor2;
			}
		}
	}

	/// <summary>
	///       Returns the gradient degree for the the specified fill.
	///       </summary>
	/// <remarks>Can only be a value from 0.0 (dark) through 1.0 (light).</remarks>
	public double GradientDegree
	{
		get
		{
			if (Type != FillType.Gradient)
			{
				throw new CellsException(ExceptionType.InvalidOperator, "Gradient option is not set.");
			}
			GradientColorType gradientColorType = GradientFill.GradientColorType;
			if (gradientColorType != GradientColorType.OneColor)
			{
				return 0.0;
			}
			return GradientFill.GradientDegree;
		}
	}

	/// <summary>
	///       Returns the gradient variant for the the specified fill.
	///       </summary>
	/// <remarks>Can only be a value from 1 through 4, corresponding to one of the four variants on the Gradient tab in the Fill Effects dialog box. If style is GradientStyle.FromCenter, the Variant argument can only be 1 or 2.</remarks>
	public int GradientVariant
	{
		get
		{
			if (Type != FillType.Gradient)
			{
				throw new CellsException(ExceptionType.InvalidOperator, "Gradient option is not set.");
			}
			return GradientFill.method_7();
		}
	}

	/// <summary>
	///       Returns the gradient preset color for the the specified fill.
	///       </summary>
	public GradientPresetType PresetColor
	{
		get
		{
			if (Type != FillType.Gradient)
			{
				throw new CellsException(ExceptionType.InvalidOperator, "Gradient option is not set.");
			}
			return GradientFill.PresetColor;
		}
	}

	/// <summary>
	///       Represents the texture type for the specified fill.
	///       </summary>
	public TextureType Texture
	{
		get
		{
			if (Type != FillType.Texture)
			{
				return TextureType.Unknown;
			}
			return TextureFill.Type;
		}
		set
		{
			if (value != TextureType.Unknown)
			{
				Type = FillType.Texture;
				TextureFill.Type = value;
				method_2();
			}
		}
	}

	/// <summary>
	///       Represents an area's display pattern.
	///       </summary>
	public FillPattern Pattern
	{
		get
		{
			if (Type != FillType.Pattern)
			{
				return FillPattern.Unknown;
			}
			return PatternFill.Pattern;
		}
		set
		{
			if (value != FillPattern.Unknown)
			{
				Type = FillType.Pattern;
				PatternFill.Pattern = value;
				method_2();
			}
		}
	}

	/// <summary>
	///       Gets and sets the picture format type.
	///       </summary>
	public FillPictureType PictureFormatType
	{
		get
		{
			if (Type == FillType.Texture && TextureFill.PicFormatOption != null)
			{
				return TextureFill.PicFormatOption.Type;
			}
			return FillPictureType.Stretch;
		}
		set
		{
			if (Type == FillType.Texture)
			{
				if (TextureFill.PicFormatOption == null)
				{
					TextureFill.PicFormatOption = new PicFormatOption();
				}
				TextureFill.PicFormatOption.Type = value;
			}
		}
	}

	/// <summary>
	///       Gets and sets the picture format scale.
	///       </summary>
	public double Scale
	{
		get
		{
			if (Type == FillType.Texture && TextureFill.PicFormatOption != null)
			{
				return TextureFill.PicFormatOption.Scale;
			}
			return 100.0;
		}
		set
		{
			if (Type == FillType.Texture)
			{
				if (TextureFill.PicFormatOption == null)
				{
					TextureFill.PicFormatOption = new PicFormatOption();
				}
				TextureFill.PicFormatOption.Scale = value;
			}
		}
	}

	/// <summary>
	///       Gets and sets the picture image data.
	///       </summary>
	/// <remarks>If the fill format is not custom texture format,return null.</remarks>
	public byte[] ImageData
	{
		get
		{
			if (Type == FillType.Texture)
			{
				return TextureFill.ImageData;
			}
			return null;
		}
		set
		{
			Type = FillType.Texture;
			TextureFill.ImageData = value;
			method_2();
		}
	}

	[SpecialName]
	internal Area method_0()
	{
		if (object_1 != null && object_1 is Area)
		{
			return (Area)object_1;
		}
		return null;
	}

	[SpecialName]
	internal object method_1()
	{
		return object_1;
	}

	internal FillFormat(object object_2, Workbook workbook_1)
	{
		object_1 = object_2;
		workbook_0 = workbook_1;
	}

	internal FillFormat(MsoFillFormatHelper msoFillFormatHelper_0, object object_2, Workbook workbook_1, bool bool_1)
	{
		object_1 = object_2;
		workbook_0 = workbook_1;
		method_3(msoFillFormatHelper_0, bool_1);
	}

	internal void method_2()
	{
		if (object_1 != null && object_1 is Area)
		{
			((Area)object_1).method_2();
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
		method_2();
		Type = FillType.Gradient;
		GradientFill.SetOneColorGradient(color, degree, style, variant);
	}

	/// <summary>
	///       Sets the specified fill to a two-color gradient.
	///       </summary>
	/// <param name="color1">One gradient color.</param>
	/// <param name="color2">Two gradient color.</param>
	/// <param name="style">Gradient shading style.</param>
	/// <param name="variant">The gradient variant. Can be a value from 1 through 4, corresponding to one of the four variants on the Gradient tab in the Fill Effects dialog box. If style is GradientStyle.FromCenter, the Variant argument can only be 1 or 2.</param>
	public void SetTwoColorGradient(Color color1, Color color2, GradientStyleType style, int variant)
	{
		method_2();
		Type = FillType.Gradient;
		GradientFill.SetTwoColorGradient(color1, color2, style, variant);
	}

	/// <summary>
	///       Sets the specified fill to a preset-color gradient.
	///       </summary>
	/// <param name="presetColor">Preset color type</param>
	/// <param name="style">Gradient shading style.</param>
	/// <param name="variant">The gradient variant. Can be a value from 1 through 4, corresponding to one of the four variants on the Gradient tab in the Fill Effects dialog box. If style is GradientStyle.FromCenter, the Variant argument can only be 1 or 2.</param>
	public void SetPresetColorGradient(GradientPresetType presetColor, GradientStyleType style, int variant)
	{
		if (presetColor != GradientPresetType.Unknown)
		{
			method_2();
			Type = FillType.Gradient;
			GradientFill.SetPresetColorGradient(presetColor, style, variant);
		}
	}

	internal void Copy(FillFormat fillFormat_0)
	{
		Type = fillFormat_0.fillType_0;
		switch (fillType_0)
		{
		default:
			object_0 = null;
			break;
		case FillType.Solid:
			SolidFill.Copy(fillFormat_0.SolidFill);
			break;
		case FillType.Gradient:
			GradientFill.Copy(fillFormat_0.GradientFill);
			break;
		case FillType.Texture:
			TextureFill.Copy(fillFormat_0.TextureFill);
			break;
		case FillType.Pattern:
			PatternFill.Copy(fillFormat_0.PatternFill);
			break;
		}
	}

	internal void method_3(MsoFillFormatHelper msoFillFormatHelper_0, bool bool_1)
	{
		if ((msoFillFormatHelper_0.workbook_0.method_24() && !bool_1) || msoFillFormatHelper_0 == null)
		{
			return;
		}
		GradientStyleType gradientStyleType = GradientStyleType.Unknown;
		int num = (int)msoFillFormatHelper_0.Angle;
		switch (msoFillFormatHelper_0.FillType)
		{
		default:
			return;
		case Enum176.const_10:
			if (!msoFillFormatHelper_0.IsVisible)
			{
				Type = FillType.None;
			}
			else if (msoFillFormatHelper_0.method_7())
			{
				Type = FillType.Solid;
				SolidFill.Color = msoFillFormatHelper_0.ForeColor;
				SolidFill.BackgroundColor = msoFillFormatHelper_0.BackColor;
				SolidFill.Transparency = msoFillFormatHelper_0.Transparency;
			}
			else
			{
				Type = FillType.Automatic;
				bool_0 = true;
			}
			return;
		case Enum176.const_0:
			if (!msoFillFormatHelper_0.IsVisible)
			{
				Type = FillType.None;
				return;
			}
			Type = FillType.Solid;
			SolidFill.Color = msoFillFormatHelper_0.ForeColor;
			SolidFill.BackgroundColor = msoFillFormatHelper_0.BackColor;
			SolidFill.Transparency = msoFillFormatHelper_0.Transparency;
			return;
		case Enum176.const_1:
			Pattern = msoFillFormatHelper_0.Pattern;
			PatternFill.ForegroundColor = msoFillFormatHelper_0.ForeColor;
			PatternFill.BackgroundColor = msoFillFormatHelper_0.BackColor;
			return;
		case Enum176.const_2:
			_ = msoFillFormatHelper_0.Texture;
			Type = FillType.Texture;
			TextureFill.method_1(msoFillFormatHelper_0.method_18());
			TextureFill.Transparency = msoFillFormatHelper_0.Transparency;
			TextureFill.TilePicOption = new TilePicOption();
			return;
		case Enum176.const_3:
			Type = FillType.Texture;
			TextureFill.method_1(msoFillFormatHelper_0.method_18());
			TextureFill.Transparency = msoFillFormatHelper_0.Transparency;
			return;
		case Enum176.const_5:
			gradientStyleType = GradientStyleType.FromCorner;
			break;
		case Enum176.const_6:
			gradientStyleType = GradientStyleType.FromCenter;
			break;
		case Enum176.const_4:
		case Enum176.const_7:
			switch (num)
			{
			default:
				return;
			case -135:
			case 45:
				gradientStyleType = GradientStyleType.DiagonalUp;
				break;
			case -90:
			case 90:
			case 270:
				gradientStyleType = GradientStyleType.Vertical;
				break;
			case 0:
			case 180:
				gradientStyleType = GradientStyleType.Horizontal;
				break;
			case -45:
			case 135:
				gradientStyleType = GradientStyleType.DiagonalDown;
				break;
			}
			break;
		}
		Type = FillType.Gradient;
		float num2 = msoFillFormatHelper_0.method_8();
		int num3 = 0;
		if (num2 == 1f)
		{
			num3 = 1;
			if (gradientStyleType == GradientStyleType.FromCorner)
			{
				if (msoFillFormatHelper_0.method_10() != 0.5 || msoFillFormatHelper_0.method_12() != 0.5 || msoFillFormatHelper_0.method_14() != 0.5 || msoFillFormatHelper_0.method_16() != 0.5)
				{
					num3 = ((msoFillFormatHelper_0.method_10() == 0.0) ? ((msoFillFormatHelper_0.method_12() == 0.0) ? 1 : 3) : ((msoFillFormatHelper_0.method_12() != 0.0) ? 4 : 2));
				}
				else
				{
					gradientStyleType = GradientStyleType.FromCenter;
					if (msoFillFormatHelper_0.method_23() && msoFillFormatHelper_0.PresetType == GradientPresetType.Unknown)
					{
						num3 = 2;
					}
				}
			}
		}
		else if (num2 == 0f)
		{
			num3 = 2;
		}
		else if (num2 == 0.5f)
		{
			if ((gradientStyleType == GradientStyleType.Vertical || gradientStyleType == GradientStyleType.DiagonalDown || gradientStyleType == GradientStyleType.DiagonalUp) && num < 0)
			{
				num3 = 4;
				if (msoFillFormatHelper_0.method_23() && msoFillFormatHelper_0.PresetType == GradientPresetType.Unknown)
				{
					num3 = 3;
				}
			}
			else
			{
				num3 = 3;
			}
		}
		else if (num2 == -0.5f)
		{
			if ((gradientStyleType == GradientStyleType.Vertical || gradientStyleType == GradientStyleType.DiagonalDown || gradientStyleType == GradientStyleType.DiagonalUp) && num < 0)
			{
				num3 = 3;
				if (msoFillFormatHelper_0.method_23() && msoFillFormatHelper_0.PresetType == GradientPresetType.Unknown)
				{
					num3 = 4;
				}
			}
			else
			{
				num3 = 4;
			}
		}
		Color foreColor = msoFillFormatHelper_0.ForeColor;
		Color empty = Color.Empty;
		if (msoFillFormatHelper_0.method_24() != Enum175.const_4 && (msoFillFormatHelper_0.method_24() != Enum175.const_5 || (msoFillFormatHelper_0.method_4() & 0x100000F0) != 268435696))
		{
			if (msoFillFormatHelper_0.method_23())
			{
				GradientPresetType presetType = msoFillFormatHelper_0.PresetType;
				if (presetType != GradientPresetType.Unknown)
				{
					SetPresetColorGradient(presetType, gradientStyleType, num3);
				}
				else
				{
					GradientFill.SetPresetColorGradient(msoFillFormatHelper_0.method_21(), gradientStyleType, num3);
				}
			}
			else
			{
				empty = msoFillFormatHelper_0.BackColor;
				SetTwoColorGradient(foreColor, empty, gradientStyleType, num3);
			}
		}
		else
		{
			double num4 = 0.5;
			int num5 = msoFillFormatHelper_0.method_4();
			num4 = (((num5 & 0x100) == 0) ? (1.0 - (double)((num5 & 0xFF0000) >> 16) / 512.0) : ((double)((num5 & 0xFF0000) >> 16) / 512.0));
			SetOneColorGradient(foreColor, num4, gradientStyleType, num3);
		}
	}

	internal MsoFillFormatHelper method_4(ArrayList arrayList_0)
	{
		if (arrayList_0 == null && arrayList_0.Count == 0)
		{
			return null;
		}
		Class1711 @class = new Class1711(this);
		MsoFillFormatHelper result = new MsoFillFormatHelper(null, @class, workbook_0);
		smethod_0(arrayList_0, @class);
		return result;
	}

	internal static void smethod_0(ArrayList arrayList_0, Class1711 class1711_0)
	{
		byte[] value = (byte[])arrayList_0[0];
		int num = 0;
		BitConverter.ToUInt16(value, 0 + 2);
		int num2 = BitConverter.ToInt16(value, 0) >> 4;
		num = 0 + 8;
		int int_ = 8 + num2 * 6;
		int int_2 = 0;
		ushort num3 = 0;
		int num4 = 0;
		for (int i = 0; i < num2; i++)
		{
			num3 = BitConverter.ToUInt16(value, num);
			num4 = BitConverter.ToInt32(value, num + 2);
			if ((num3 & 0x8000u) != 0)
			{
				if (num4 == 0)
				{
					num += 6;
					continue;
				}
				byte[] byte_ = new byte[num4];
				int[] array = smethod_1(byte_, int_, arrayList_0, int_2);
				int_ = array[0];
				int_2 = array[1];
				class1711_0.method_1(num3, Enum183.const_4, byte_);
			}
			else
			{
				class1711_0.method_1(num3, Enum183.const_0, num4);
			}
			num += 6;
		}
	}

	internal static int[] smethod_1(byte[] byte_0, int int_0, ArrayList arrayList_0, int int_1)
	{
		int num = 0;
		int num2 = 0;
		while (int_1 < arrayList_0.Count)
		{
			byte[] array = (byte[])arrayList_0[int_1];
			num2 = array.Length - int_0;
			if (byte_0.Length - num > array.Length - int_0)
			{
				Array.Copy(array, int_0, byte_0, num, num2);
				int_0 = 0;
				num += num2;
				int_1++;
				continue;
			}
			num2 = byte_0.Length - num;
			Array.Copy(array, int_0, byte_0, num, num2);
			int_0 += num2;
			break;
		}
		return new int[2] { int_0, int_1 };
	}
}
