using System.Drawing;
using System.Runtime.CompilerServices;
using ns2;
using ns21;
using ns52;

namespace Aspose.Cells.Drawing;

/// <summary>
///       Represents the gradient fill.
///       </summary>
public class GradientFill
{
	private Class924 class924_0;

	internal object object_0;

	private Class926 class926_0;

	internal bool bool_0;

	private GradientStopCollection gradientStopCollection_0;

	private GradientPresetType gradientPresetType_0;

	private object object_1;

	internal Workbook workbook_0;

	/// <summary>
	///       Represents the gradient stops.
	///       </summary>
	public GradientStopCollection GradientStops => gradientStopCollection_0;

	/// <summary>
	///       Gets the gradient fill type.
	///       </summary>
	public GradientFillType FillType
	{
		get
		{
			if (object_0 == null)
			{
				return GradientFillType.Linear;
			}
			if (object_0 is Class926)
			{
				Class926 @class = (Class926)object_0;
				switch (@class.enum128_0)
				{
				case Enum128.const_0:
					return GradientFillType.Radial;
				case Enum128.const_1:
					return GradientFillType.Rectangle;
				case Enum128.const_2:
					return GradientFillType.Path;
				}
			}
			return GradientFillType.Linear;
		}
	}

	public GradientDirectionType DirectionType
	{
		get
		{
			if (object_0 == null)
			{
				return GradientDirectionType.Unknown;
			}
			if (object_0 is Class926)
			{
				int num = 100000;
				Class926 @class = (Class926)object_0;
				switch (@class.enum128_0)
				{
				case Enum128.const_0:
				case Enum128.const_1:
					if (@class.int_1 == num && @class.int_0 == num)
					{
						return GradientDirectionType.FromLowerRightCorner;
					}
					if (@class.int_1 == num && @class.int_3 == num)
					{
						return GradientDirectionType.FromLowerLeftCorner;
					}
					if (@class.int_0 == num / 2 && @class.int_3 == num / 2 && @class.int_1 == num / 2 && @class.int_2 == num / 2)
					{
						return GradientDirectionType.FromCenter;
					}
					if (@class.int_2 == num && @class.int_0 == num)
					{
						return GradientDirectionType.FromUpperRightCorner;
					}
					if (@class.int_2 == num && @class.int_3 == num)
					{
						return GradientDirectionType.FromUpperLeftCorner;
					}
					break;
				case Enum128.const_2:
					return GradientDirectionType.Unknown;
				}
			}
			return GradientDirectionType.Unknown;
		}
	}

	/// <summary>
	///       The angle of linear fill.
	///       </summary>
	public int Angle
	{
		get
		{
			if (object_0 != null && object_0 is Class925)
			{
				return ((Class925)object_0).int_0 / Class1391.int_0;
			}
			return 0;
		}
		set
		{
			if (object_0 != null && object_0 is Class925)
			{
				((Class925)object_0).int_0 = value * Class1391.int_0;
			}
		}
	}

	internal Color GradientColor1
	{
		get
		{
			if (gradientStopCollection_0 != null && gradientStopCollection_0.Count != 0)
			{
				method_8(workbook_0);
				if (class924_0.gradientStyleType_0 != GradientStyleType.FromCorner)
				{
					switch (class924_0.int_0)
					{
					default:
						return Color.Empty;
					case 1:
					case 3:
						return gradientStopCollection_0[0].internalColor_0.method_6(workbook_0);
					case 2:
					case 4:
						return gradientStopCollection_0[1].internalColor_0.method_6(workbook_0);
					}
				}
				return gradientStopCollection_0[0].internalColor_0.method_6(workbook_0);
			}
			return Color.Empty;
		}
	}

	internal Color GradientColor2
	{
		get
		{
			if (gradientStopCollection_0 != null && gradientStopCollection_0.Count != 0)
			{
				method_8(workbook_0);
				if (class924_0.gradientStyleType_0 != GradientStyleType.FromCorner)
				{
					switch (class924_0.int_0)
					{
					default:
						return Color.Empty;
					case 1:
					case 3:
						return gradientStopCollection_0[1].internalColor_0.method_6(workbook_0);
					case 2:
					case 4:
						return gradientStopCollection_0[0].internalColor_0.method_6(workbook_0);
					}
				}
				return gradientStopCollection_0[1].internalColor_0.method_6(workbook_0);
			}
			return Color.Empty;
		}
	}

	internal double GradientDegree
	{
		get
		{
			if (class924_0 != null)
			{
				return class924_0.double_0;
			}
			return 0.0;
		}
	}

	internal GradientColorType GradientColorType
	{
		get
		{
			method_8(workbook_0);
			return class924_0.gradientColorType_0;
		}
	}

	internal GradientPresetType PresetColor => gradientPresetType_0;

	internal GradientStyleType GradientStyle
	{
		get
		{
			method_8(workbook_0);
			return class924_0.gradientStyleType_0;
		}
	}

	internal GradientFill(object object_2, Workbook workbook_1)
	{
		object_1 = object_2;
		workbook_0 = workbook_1;
		gradientStopCollection_0 = new GradientStopCollection(this);
		gradientPresetType_0 = GradientPresetType.Unknown;
		bool_0 = true;
	}

	internal void Copy(GradientFill gradientFill_0)
	{
		gradientPresetType_0 = gradientFill_0.gradientPresetType_0;
		bool_0 = gradientFill_0.bool_0;
		if (gradientFill_0.object_0 != null)
		{
			if (gradientFill_0.object_0 is Class925)
			{
				object_0 = new Class925();
				((Class925)object_0).Copy((Class925)gradientFill_0.object_0);
			}
			else
			{
				object_0 = new Class926();
				((Class926)object_0).Copy((Class926)gradientFill_0.object_0);
			}
		}
		else
		{
			object_0 = null;
		}
		if (gradientFill_0.class924_0 != null)
		{
			class924_0 = new Class924();
			class924_0.gradientColorType_0 = gradientFill_0.class924_0.gradientColorType_0;
			class924_0.double_0 = gradientFill_0.class924_0.double_0;
			class924_0.gradientStyleType_0 = gradientFill_0.class924_0.gradientStyleType_0;
			class924_0.int_0 = gradientFill_0.class924_0.int_0;
		}
		else
		{
			class924_0 = null;
		}
		if (gradientFill_0.class926_0 != null)
		{
			class926_0 = new Class926();
			class926_0.Copy(gradientFill_0.class926_0);
		}
		else
		{
			class926_0 = null;
		}
		if (gradientFill_0.gradientStopCollection_0 != null)
		{
			gradientStopCollection_0 = new GradientStopCollection(this);
			gradientStopCollection_0.Copy(gradientFill_0.gradientStopCollection_0);
		}
		else
		{
			gradientStopCollection_0 = null;
		}
	}

	[SpecialName]
	internal bool method_0()
	{
		if (object_0 == null)
		{
			return true;
		}
		return object_0 is Class925;
	}

	[SpecialName]
	internal Class925 method_1()
	{
		if (object_0 != null && object_0 is Class925)
		{
			return (Class925)object_0;
		}
		return null;
	}

	[SpecialName]
	internal Class926 method_2()
	{
		if (object_0 != null && object_0 is Class926)
		{
			return (Class926)object_0;
		}
		return null;
	}

	[SpecialName]
	internal Class926 method_3()
	{
		if (class926_0 == null)
		{
			class926_0 = new Class926();
		}
		return class926_0;
	}

	internal Class926 method_4()
	{
		return class926_0;
	}

	/// <summary>
	///       Set the gradient fill type and direction.
	///       </summary>
	/// <param name="type">Gradient fill type.</param>
	/// <param name="angle">The angle. Only applies for GradientFillType.Linear. </param>
	/// <param name="direction">The direction type. Only applies for GradientFillType.Radial,
	///       GradientFillType.Rectangle,GradientFillType.Path.</param>
	public void SetGradient(GradientFillType type, double angle, GradientDirectionType direction)
	{
		class924_0 = null;
		switch (type)
		{
		case GradientFillType.Linear:
		{
			Class925 class7 = new Class925();
			class7.int_0 = (int)(angle * (double)Class1391.int_0);
			object_0 = class7;
			break;
		}
		case GradientFillType.Radial:
		case GradientFillType.Rectangle:
		{
			Class926 class2 = (Class926)(object_0 = new Class926());
			if (type == GradientFillType.Rectangle)
			{
				class2.enum128_0 = Enum128.const_1;
			}
			else
			{
				class2.enum128_0 = Enum128.const_0;
			}
			switch (direction)
			{
			case GradientDirectionType.FromUpperLeftCorner:
			{
				class2.int_1 = 50000;
				class2.int_0 = 50000;
				class926_0 = new Class926();
				Class926 class6 = class926_0;
				class926_0.int_2 = -100000;
				class6.int_3 = -100000;
				break;
			}
			case GradientDirectionType.FromUpperRightCorner:
			{
				class2.int_3 = 50000;
				class2.int_1 = 50000;
				class926_0 = new Class926();
				Class926 class5 = class926_0;
				class926_0.int_2 = -100000;
				class5.int_0 = -100000;
				break;
			}
			case GradientDirectionType.FromLowerLeftCorner:
			{
				class2.int_2 = 50000;
				class2.int_0 = 50000;
				class926_0 = new Class926();
				Class926 class4 = class926_0;
				class926_0.int_3 = -100000;
				class4.int_1 = -100000;
				break;
			}
			case GradientDirectionType.FromLowerRightCorner:
			{
				class2.int_2 = 50000;
				class2.int_3 = 50000;
				class926_0 = new Class926();
				Class926 class3 = class926_0;
				class926_0.int_1 = -100000;
				class3.int_0 = -100000;
				break;
			}
			case GradientDirectionType.FromCenter:
				class2.int_1 = 50000;
				class2.int_2 = 50000;
				class2.int_3 = 50000;
				class2.int_0 = 50000;
				break;
			}
			break;
		}
		case GradientFillType.Path:
		{
			Class926 @class = (Class926)(object_0 = new Class926());
			@class.enum128_0 = Enum128.const_2;
			@class.int_2 = 50000;
			@class.int_1 = 50000;
			@class.int_3 = 50000;
			@class.int_0 = 50000;
			break;
		}
		}
	}

	internal void SetStyle(Style style_0, Workbook workbook_1)
	{
		method_8(workbook_1);
		InternalColor internalColor_;
		InternalColor internalColor_2;
		if (class924_0.gradientStyleType_0 != GradientStyleType.FromCorner)
		{
			switch (class924_0.int_0)
			{
			default:
				internalColor_ = new InternalColor(bool_0: false);
				internalColor_2 = new InternalColor(bool_0: false);
				break;
			case 1:
			case 3:
				internalColor_ = gradientStopCollection_0[0].internalColor_0;
				internalColor_2 = gradientStopCollection_0[1].internalColor_0;
				break;
			case 2:
			case 4:
				internalColor_ = gradientStopCollection_0[1].internalColor_0;
				internalColor_2 = gradientStopCollection_0[0].internalColor_0;
				break;
			}
		}
		else
		{
			internalColor_ = gradientStopCollection_0[0].internalColor_0;
			internalColor_2 = gradientStopCollection_0[1].internalColor_0;
		}
		style_0.SetTwoColorGradient(internalColor_, internalColor_2, class924_0.gradientStyleType_0, class924_0.int_0);
	}

	internal void SetPresetColorGradient(GradientPresetType gradientPresetType_1, GradientStyleType gradientStyleType_0, int int_0)
	{
		gradientPresetType_0 = gradientPresetType_1;
		class924_0 = new Class924();
		class924_0.gradientColorType_0 = GradientColorType.PresetColors;
		class924_0.gradientStyleType_0 = gradientStyleType_0;
		class924_0.int_0 = int_0;
		switch (gradientStyleType_0)
		{
		case GradientStyleType.FromCenter:
		{
			gradientStopCollection_0 = Class1707.smethod_0(this, gradientPresetType_1, int_0 == 1, bool_1: false);
			Class926 class2 = new Class926();
			class2.enum128_0 = Enum128.const_1;
			object_0 = class2;
			class2.int_2 = 50000;
			class2.int_1 = 50000;
			class2.int_3 = 50000;
			class2.int_0 = 50000;
			break;
		}
		case GradientStyleType.FromCorner:
		{
			Class926 class3 = new Class926();
			class3.enum128_0 = Enum128.const_1;
			object_0 = class3;
			gradientStopCollection_0 = Class1707.smethod_0(this, gradientPresetType_1, bool_0: false, bool_1: false);
			switch (int_0)
			{
			case 1:
				class3.int_2 = 100000;
				class3.int_3 = 100000;
				break;
			case 2:
				class3.int_2 = 100000;
				class3.int_0 = 100000;
				break;
			case 3:
				class3.int_3 = 100000;
				class3.int_1 = 100000;
				break;
			case 4:
				class3.int_1 = 100000;
				class3.int_0 = 100000;
				break;
			}
			break;
		}
		case GradientStyleType.DiagonalDown:
		case GradientStyleType.DiagonalUp:
		case GradientStyleType.Horizontal:
		case GradientStyleType.Vertical:
		{
			Class925 @class = (Class925)(object_0 = new Class925());
			switch (gradientStyleType_0)
			{
			case GradientStyleType.DiagonalDown:
				@class.int_0 = 315 * Class1391.int_0;
				break;
			case GradientStyleType.DiagonalUp:
				@class.int_0 = 45 * Class1391.int_0;
				break;
			case GradientStyleType.Horizontal:
				@class.int_0 = 5400000;
				break;
			case GradientStyleType.Vertical:
				@class.int_0 = 0;
				break;
			}
			@class.bool_0 = true;
			switch (int_0)
			{
			case 1:
				gradientStopCollection_0 = Class1707.smethod_0(this, gradientPresetType_1, bool_0: false, bool_1: false);
				break;
			case 2:
				gradientStopCollection_0 = Class1707.smethod_0(this, gradientPresetType_1, bool_0: true, bool_1: false);
				break;
			case 3:
				gradientStopCollection_0 = Class1707.smethod_0(this, gradientPresetType_1, bool_0: false, bool_1: true);
				break;
			case 4:
				gradientStopCollection_0 = Class1707.smethod_0(this, gradientPresetType_1, bool_0: true, bool_1: true);
				break;
			}
			break;
		}
		}
	}

	internal void SetPresetColorGradient(byte[] byte_0, GradientStyleType gradientStyleType_0, int int_0)
	{
		class924_0 = new Class924();
		class924_0.gradientColorType_0 = GradientColorType.PresetColors;
		class924_0.gradientStyleType_0 = gradientStyleType_0;
		switch (gradientStyleType_0)
		{
		case GradientStyleType.FromCenter:
		{
			gradientStopCollection_0 = Class1707.smethod_1(this, byte_0, int_0 == 1, bool_1: false);
			Class926 class2 = new Class926();
			class2.enum128_0 = Enum128.const_1;
			object_0 = class2;
			class2.int_2 = 50000;
			class2.int_1 = 50000;
			class2.int_3 = 50000;
			class2.int_0 = 50000;
			break;
		}
		case GradientStyleType.FromCorner:
		{
			gradientStopCollection_0 = Class1707.smethod_1(this, byte_0, bool_0: false, bool_1: false);
			Class926 class3 = new Class926();
			class3.enum128_0 = Enum128.const_1;
			object_0 = class3;
			switch (int_0)
			{
			case 1:
				class3.int_2 = 100000;
				class3.int_3 = 100000;
				break;
			case 2:
				class3.int_2 = 100000;
				class3.int_0 = 100000;
				break;
			case 3:
				class3.int_3 = 100000;
				class3.int_1 = 100000;
				break;
			case 4:
				class3.int_1 = 100000;
				class3.int_0 = 100000;
				break;
			}
			break;
		}
		case GradientStyleType.DiagonalDown:
		case GradientStyleType.DiagonalUp:
		case GradientStyleType.Horizontal:
		case GradientStyleType.Vertical:
		{
			Class925 @class = (Class925)(object_0 = new Class925());
			switch (gradientStyleType_0)
			{
			case GradientStyleType.DiagonalDown:
				@class.int_0 = 315 * Class1391.int_0;
				break;
			case GradientStyleType.DiagonalUp:
				@class.int_0 = 45 * Class1391.int_0;
				break;
			case GradientStyleType.Horizontal:
				@class.int_0 = 5400000;
				break;
			case GradientStyleType.Vertical:
				@class.int_0 = 0;
				break;
			}
			@class.bool_0 = true;
			bool flag = false;
			switch (int_0)
			{
			case 1:
				gradientStopCollection_0 = Class1707.smethod_1(this, byte_0, bool_0: false, bool_1: false);
				flag = gradientStopCollection_0.Count == 2;
				break;
			case 2:
				gradientStopCollection_0 = Class1707.smethod_1(this, byte_0, bool_0: true, bool_1: false);
				flag = gradientStopCollection_0.Count == 2;
				break;
			case 3:
				gradientStopCollection_0 = Class1707.smethod_1(this, byte_0, bool_0: false, bool_1: true);
				flag = gradientStopCollection_0.Count == 3;
				break;
			case 4:
				gradientStopCollection_0 = Class1707.smethod_1(this, byte_0, bool_0: true, bool_1: true);
				flag = gradientStopCollection_0.Count == 3;
				break;
			}
			if (flag)
			{
				class924_0.gradientColorType_0 = GradientColorType.TwoColors;
				class924_0.int_0 = int_0;
			}
			break;
		}
		}
	}

	/// <summary>
	///       Sets the specified fill to a one-color gradient.
	///       Only applies for Excel97-2003
	///       </summary>
	/// <param name="color">One gradient color.</param>
	/// <param name="degree">The gradient degree. Can be a value from 0.0 (dark) through 1.0 (light).</param>
	/// <param name="style">Gradient shading style.</param>
	/// <param name="variant">The gradient variant. Can be a value from 1 through 4, corresponding to one of the four variants on the Gradient tab in the Fill Effects dialog box. If style is GradientStyle.FromCenter, the Variant argument can only be 1 or 2.</param>
	public void SetOneColorGradient(Color color, double degree, GradientStyleType style, int variant)
	{
		method_6(GradientColorType.OneColor, color, degree, color, style, variant);
	}

	/// <summary>
	///       Sets the specified fill to a two-color gradient.
	///       Only applies for Excel97-2003
	///       </summary>
	/// <param name="color1">One gradient color.</param>
	/// <param name="color2">Two gradient color.</param>
	/// <param name="style">Gradient shading style.</param>
	/// <param name="variant">The gradient variant. Can be a value from 1 through 4, corresponding to one of the four variants on the Gradient tab in the Fill Effects dialog box. If style is GradientStyle.FromCenter, the Variant argument can only be 1 or 2.</param>
	public void SetTwoColorGradient(Color color1, Color color2, GradientStyleType style, int variant)
	{
		method_6(GradientColorType.TwoColors, color1, 0.0, color2, style, variant);
	}

	internal void method_5(GradientColorType gradientColorType_0, InternalColor internalColor_0, double double_0, InternalColor internalColor_1, GradientStyleType gradientStyleType_0, int int_0)
	{
		class924_0 = new Class924();
		class924_0.gradientStyleType_0 = gradientStyleType_0;
		class924_0.int_0 = int_0;
		class924_0.double_0 = double_0;
		class924_0.gradientColorType_0 = gradientColorType_0;
		GradientStop gradientStop = null;
		switch (gradientStyleType_0)
		{
		case GradientStyleType.FromCenter:
		{
			if (int_0 != 1)
			{
				InternalColor internalColor = internalColor_0;
				internalColor_0 = internalColor_1;
				internalColor_1 = internalColor;
			}
			gradientStop = new GradientStop(gradientStopCollection_0);
			gradientStop.internalColor_0 = internalColor_0;
			gradientStop.Position = 0.0;
			gradientStopCollection_0.Add(gradientStop);
			gradientStop = new GradientStop(gradientStopCollection_0);
			gradientStop.internalColor_0 = internalColor_1;
			gradientStop.Position = 100.0;
			gradientStopCollection_0.Add(gradientStop);
			Class926 class2 = new Class926();
			class2.enum128_0 = Enum128.const_1;
			object_0 = class2;
			class2.int_2 = 50000;
			class2.int_1 = 50000;
			class2.int_3 = 50000;
			class2.int_0 = 50000;
			break;
		}
		case GradientStyleType.FromCorner:
		{
			gradientStop = new GradientStop(gradientStopCollection_0);
			gradientStop.internalColor_0 = internalColor_0;
			gradientStop.Position = 0.0;
			gradientStopCollection_0.Add(gradientStop);
			gradientStop = new GradientStop(gradientStopCollection_0);
			gradientStop.internalColor_0 = internalColor_1;
			gradientStop.Position = 100.0;
			gradientStopCollection_0.Add(gradientStop);
			Class926 class3 = new Class926();
			class3.enum128_0 = Enum128.const_1;
			object_0 = class3;
			switch (int_0)
			{
			case 1:
				break;
			case 2:
				class3.int_3 = 100000;
				class3.int_0 = 100000;
				break;
			case 3:
				class3.int_2 = 100000;
				class3.int_1 = 100000;
				break;
			case 4:
				class3.int_2 = 100000;
				class3.int_3 = 100000;
				class3.int_1 = 100000;
				class3.int_0 = 100000;
				break;
			}
			break;
		}
		case GradientStyleType.DiagonalDown:
		case GradientStyleType.DiagonalUp:
		case GradientStyleType.Horizontal:
		case GradientStyleType.Vertical:
		{
			Class925 @class = (Class925)(object_0 = new Class925());
			switch (gradientStyleType_0)
			{
			case GradientStyleType.DiagonalDown:
				@class.int_0 = 315 * Class1391.int_0;
				break;
			case GradientStyleType.DiagonalUp:
				@class.int_0 = 45 * Class1391.int_0;
				break;
			case GradientStyleType.Horizontal:
				@class.int_0 = 5400000;
				break;
			case GradientStyleType.Vertical:
				@class.int_0 = 0;
				break;
			}
			@class.bool_0 = true;
			switch (int_0)
			{
			case 1:
				gradientStop = new GradientStop(gradientStopCollection_0);
				gradientStop.internalColor_0 = internalColor_0;
				gradientStop.Position = 0.0;
				gradientStopCollection_0.Add(gradientStop);
				gradientStop = new GradientStop(gradientStopCollection_0);
				gradientStop.internalColor_0 = internalColor_1;
				gradientStop.Position = 100.0;
				gradientStopCollection_0.Add(gradientStop);
				break;
			case 2:
				gradientStop = new GradientStop(gradientStopCollection_0);
				gradientStop.internalColor_0 = internalColor_1;
				gradientStop.Position = 0.0;
				gradientStopCollection_0.Add(gradientStop);
				gradientStop = new GradientStop(gradientStopCollection_0);
				gradientStop.internalColor_0 = internalColor_0;
				gradientStop.Position = 100.0;
				gradientStopCollection_0.Add(gradientStop);
				break;
			case 3:
				gradientStop = new GradientStop(gradientStopCollection_0);
				gradientStop.internalColor_0 = internalColor_0;
				gradientStop.Position = 0.0;
				gradientStopCollection_0.Add(gradientStop);
				gradientStop = new GradientStop(gradientStopCollection_0);
				gradientStop.internalColor_0 = internalColor_1;
				gradientStop.Position = 50.0;
				gradientStopCollection_0.Add(gradientStop);
				gradientStop = new GradientStop(gradientStopCollection_0);
				gradientStop.internalColor_0 = internalColor_0;
				gradientStop.Position = 100.0;
				gradientStopCollection_0.Add(gradientStop);
				break;
			case 4:
				gradientStop = new GradientStop(gradientStopCollection_0);
				gradientStop.internalColor_0 = internalColor_1;
				gradientStop.Position = 0.0;
				gradientStopCollection_0.Add(gradientStop);
				gradientStop = new GradientStop(gradientStopCollection_0);
				gradientStop.internalColor_0 = internalColor_0;
				gradientStop.Position = 50.0;
				gradientStopCollection_0.Add(gradientStop);
				gradientStop = new GradientStop(gradientStopCollection_0);
				gradientStop.internalColor_0 = internalColor_1;
				gradientStop.Position = 100.0;
				gradientStopCollection_0.Add(gradientStop);
				break;
			}
			break;
		}
		}
	}

	private void method_6(GradientColorType gradientColorType_0, Color color_0, double double_0, Color color_1, GradientStyleType gradientStyleType_0, int int_0)
	{
		class924_0 = new Class924();
		class924_0.gradientStyleType_0 = gradientStyleType_0;
		class924_0.int_0 = int_0;
		class924_0.double_0 = double_0;
		class924_0.gradientColorType_0 = gradientColorType_0;
		InternalColor internalColor = new InternalColor(bool_0: true);
		InternalColor internalColor2 = new InternalColor(bool_0: true);
		internalColor.SetColor(ColorType.RGB, color_0.ToArgb());
		if (gradientColorType_0 == GradientColorType.OneColor)
		{
			internalColor2.SetColor(ColorType.RGB, smethod_0(color_0, double_0).ToArgb());
		}
		else
		{
			internalColor2.SetColor(ColorType.RGB, color_1.ToArgb());
		}
		GradientStop gradientStop = null;
		switch (gradientStyleType_0)
		{
		case GradientStyleType.FromCenter:
		{
			if (int_0 != 1)
			{
				InternalColor internalColor3 = internalColor;
				internalColor = internalColor2;
				internalColor2 = internalColor3;
			}
			gradientStop = new GradientStop(gradientStopCollection_0);
			gradientStop.internalColor_0 = internalColor;
			gradientStop.Position = 0.0;
			gradientStopCollection_0.Add(gradientStop);
			gradientStop = new GradientStop(gradientStopCollection_0);
			gradientStop.internalColor_0 = internalColor2;
			gradientStop.Position = 100.0;
			gradientStopCollection_0.Add(gradientStop);
			Class926 class2 = new Class926();
			class2.enum128_0 = Enum128.const_1;
			object_0 = class2;
			class2.int_2 = 50000;
			class2.int_1 = 50000;
			class2.int_3 = 50000;
			class2.int_0 = 50000;
			break;
		}
		case GradientStyleType.FromCorner:
		{
			gradientStop = new GradientStop(gradientStopCollection_0);
			gradientStop.internalColor_0 = internalColor;
			gradientStop.Position = 0.0;
			gradientStopCollection_0.Add(gradientStop);
			gradientStop = new GradientStop(gradientStopCollection_0);
			gradientStop.internalColor_0 = internalColor2;
			gradientStop.Position = 100.0;
			gradientStopCollection_0.Add(gradientStop);
			Class926 class3 = new Class926();
			class3.enum128_0 = Enum128.const_1;
			object_0 = class3;
			switch (int_0)
			{
			case 1:
				class3.int_2 = 100000;
				class3.int_3 = 100000;
				break;
			case 2:
				class3.int_2 = 100000;
				class3.int_0 = 100000;
				break;
			case 3:
				class3.int_3 = 100000;
				class3.int_1 = 100000;
				break;
			case 4:
				class3.int_1 = 100000;
				class3.int_0 = 100000;
				break;
			}
			break;
		}
		case GradientStyleType.DiagonalDown:
		case GradientStyleType.DiagonalUp:
		case GradientStyleType.Horizontal:
		case GradientStyleType.Vertical:
		{
			Class925 @class = (Class925)(object_0 = new Class925());
			switch (gradientStyleType_0)
			{
			case GradientStyleType.DiagonalDown:
				@class.int_0 = 315 * Class1391.int_0;
				break;
			case GradientStyleType.DiagonalUp:
				@class.int_0 = 45 * Class1391.int_0;
				break;
			case GradientStyleType.Horizontal:
				@class.int_0 = 5400000;
				break;
			case GradientStyleType.Vertical:
				@class.int_0 = 0;
				break;
			}
			@class.bool_0 = true;
			switch (int_0)
			{
			case 1:
				gradientStop = new GradientStop(gradientStopCollection_0);
				gradientStop.internalColor_0 = internalColor;
				gradientStop.Position = 0.0;
				gradientStopCollection_0.Add(gradientStop);
				gradientStop = new GradientStop(gradientStopCollection_0);
				gradientStop.internalColor_0 = internalColor2;
				gradientStop.Position = 100.0;
				gradientStopCollection_0.Add(gradientStop);
				break;
			case 2:
				gradientStop = new GradientStop(gradientStopCollection_0);
				gradientStop.internalColor_0 = internalColor2;
				gradientStop.Position = 0.0;
				gradientStopCollection_0.Add(gradientStop);
				gradientStop = new GradientStop(gradientStopCollection_0);
				gradientStop.internalColor_0 = internalColor;
				gradientStop.Position = 100.0;
				gradientStopCollection_0.Add(gradientStop);
				break;
			case 3:
				gradientStop = new GradientStop(gradientStopCollection_0);
				gradientStop.internalColor_0 = internalColor;
				gradientStop.Position = 0.0;
				gradientStopCollection_0.Add(gradientStop);
				gradientStop = new GradientStop(gradientStopCollection_0);
				gradientStop.internalColor_0 = internalColor2;
				gradientStop.Position = 50.0;
				gradientStopCollection_0.Add(gradientStop);
				gradientStop = new GradientStop(gradientStopCollection_0);
				gradientStop.internalColor_0 = internalColor;
				gradientStop.Position = 100.0;
				gradientStopCollection_0.Add(gradientStop);
				break;
			case 4:
				gradientStop = new GradientStop(gradientStopCollection_0);
				gradientStop.internalColor_0 = internalColor2;
				gradientStop.Position = 0.0;
				gradientStopCollection_0.Add(gradientStop);
				gradientStop = new GradientStop(gradientStopCollection_0);
				gradientStop.internalColor_0 = internalColor;
				gradientStop.Position = 50.0;
				gradientStopCollection_0.Add(gradientStop);
				gradientStop = new GradientStop(gradientStopCollection_0);
				gradientStop.internalColor_0 = internalColor2;
				gradientStop.Position = 100.0;
				gradientStopCollection_0.Add(gradientStop);
				break;
			}
			break;
		}
		}
	}

	[SpecialName]
	internal int method_7()
	{
		method_8(workbook_0);
		return class924_0.int_0;
	}

	private void method_8(Workbook workbook_1)
	{
		if (class924_0 != null)
		{
			return;
		}
		class924_0 = new Class924();
		if (object_0 == null)
		{
			return;
		}
		if (object_0 is Class925)
		{
			Class925 @class = (Class925)object_0;
			switch (@class.int_0)
			{
			case 2700000:
				class924_0.gradientStyleType_0 = GradientStyleType.DiagonalUp;
				break;
			case 0:
				class924_0.gradientStyleType_0 = GradientStyleType.Vertical;
				break;
			default:
				class924_0.gradientStyleType_0 = GradientStyleType.Horizontal;
				break;
			case 18900000:
				class924_0.gradientStyleType_0 = GradientStyleType.DiagonalDown;
				break;
			case 5400000:
				class924_0.gradientStyleType_0 = GradientStyleType.Horizontal;
				break;
			}
			if (gradientStopCollection_0 != null)
			{
				switch (gradientStopCollection_0.Count)
				{
				default:
					class924_0.gradientColorType_0 = GradientColorType.PresetColors;
					gradientPresetType_0 = GradientPresetType.Unknown;
					break;
				case 2:
					class924_0.int_0 = 1;
					class924_0.gradientColorType_0 = GradientColorType.TwoColors;
					break;
				case 3:
					if (gradientStopCollection_0[0].Position == 0.0 && gradientStopCollection_0[1].Position == 50.0 && gradientStopCollection_0[2].Position == 100.0 && gradientStopCollection_0[0].internalColor_0.method_7(workbook_1) == gradientStopCollection_0[2].internalColor_0.method_7(workbook_1))
					{
						class924_0.gradientColorType_0 = GradientColorType.TwoColors;
						class924_0.int_0 = 3;
					}
					else if (gradientStopCollection_0[0].Position == 50.0 && gradientStopCollection_0[1].Position == 0.0 && gradientStopCollection_0[2].Position == 100.0 && gradientStopCollection_0[1].internalColor_0.method_7(workbook_1) == gradientStopCollection_0[2].internalColor_0.method_7(workbook_1))
					{
						class924_0.gradientColorType_0 = GradientColorType.TwoColors;
						class924_0.int_0 = 4;
					}
					else
					{
						class924_0.gradientColorType_0 = GradientColorType.PresetColors;
						gradientPresetType_0 = GradientPresetType.Unknown;
					}
					break;
				case 0:
				case 1:
					break;
				}
			}
			else
			{
				class924_0.gradientColorType_0 = GradientColorType.PresetColors;
				gradientPresetType_0 = GradientPresetType.Unknown;
			}
		}
		else
		{
			if (!(object_0 is Class926))
			{
				return;
			}
			bool flag = gradientStopCollection_0 != null && gradientStopCollection_0.Count == 2;
			Class926 class2 = (Class926)object_0;
			if (class2.int_2 == 50000 && class2.int_0 == 50000 && class2.int_1 == 50000 && class2.int_2 == 50000)
			{
				class924_0.gradientStyleType_0 = GradientStyleType.FromCenter;
				class924_0.int_0 = 1;
				class924_0.gradientColorType_0 = (flag ? GradientColorType.TwoColors : GradientColorType.PresetColors);
				return;
			}
			class924_0.gradientStyleType_0 = GradientStyleType.FromCorner;
			class924_0.gradientColorType_0 = (flag ? GradientColorType.TwoColors : GradientColorType.PresetColors);
			if (class2.int_0 == 0)
			{
				if (class2.int_1 == 0)
				{
					class924_0.int_0 = 1;
				}
				else
				{
					class924_0.int_0 = 3;
				}
			}
			else if (class2.int_0 == 100000)
			{
				if (class2.int_1 == 0)
				{
					class924_0.int_0 = 2;
				}
				else
				{
					class924_0.int_0 = 4;
				}
			}
		}
	}

	internal static Color smethod_0(Color color_0, double double_0)
	{
		int r = color_0.R;
		int g = color_0.G;
		int b = color_0.B;
		if (double_0 < 0.5)
		{
			double num = double_0 * 2.0;
			color_0 = Color.FromArgb((int)((double)r * num), (int)((double)g * num), (int)((double)b * num));
		}
		else if (double_0 > 0.5)
		{
			double num2 = (double_0 - 0.5) * 2.0;
			color_0 = Color.FromArgb((int)((double)r + (double)(255 - r) * num2), (int)((double)g + (double)(255 - g) * num2), (int)((double)b + (double)(255 - b) * num2));
		}
		return color_0;
	}
}
