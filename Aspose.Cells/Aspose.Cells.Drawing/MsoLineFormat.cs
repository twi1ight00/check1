using System.Drawing;
using System.Runtime.CompilerServices;
using ns16;
using ns22;
using ns52;

namespace Aspose.Cells.Drawing;

/// <summary>
///       Represents line and arrowhead formatting.
///       </summary>
public class MsoLineFormat
{
	private Shape shape_0;

	/// <summary>
	///       Indicates whether the object is visible.
	///       </summary>
	public bool IsVisible
	{
		get
		{
			bool bool_ = true;
			if (shape_0 != null)
			{
				MsoDrawingType msoDrawingType = shape_0.MsoDrawingType;
				if (msoDrawingType == MsoDrawingType.Picture || msoDrawingType == MsoDrawingType.OleObject)
				{
					bool_ = false;
				}
			}
			return method_0().method_5(511, 3, bool_);
		}
		set
		{
			method_0().method_6(511, 3, value);
		}
	}

	/// <summary>
	///       Returns a Style object that represents the style of the specified range.
	///       </summary>
	public MsoLineStyle Style
	{
		get
		{
			return method_0().method_4(461, 0) switch
			{
				0 => MsoLineStyle.Single, 
				1 => MsoLineStyle.ThinThin, 
				2 => MsoLineStyle.ThickThin, 
				3 => MsoLineStyle.ThinThick, 
				4 => MsoLineStyle.ThickBetweenThin, 
				_ => MsoLineStyle.Single, 
			};
		}
		set
		{
			shape_0.method_62(Enum169.const_32);
			int num = 0;
			switch (value)
			{
			case MsoLineStyle.Single:
				num = 0;
				break;
			case MsoLineStyle.ThickBetweenThin:
				num = 4;
				break;
			case MsoLineStyle.ThinThick:
				num = 3;
				break;
			case MsoLineStyle.ThickThin:
				num = 2;
				break;
			case MsoLineStyle.ThinThin:
				num = 1;
				break;
			}
			if (num == 0)
			{
				method_0().Remove(461);
			}
			else
			{
				method_0().method_1(461, Enum183.const_0, num);
			}
		}
	}

	/// <summary>
	///       Gets and sets the border line fore color.
	///       </summary>
	public Color ForeColor
	{
		get
		{
			Color color = method_0().GetColor(448, Color.Black);
			if (Class1178.smethod_0(color))
			{
				return Color.Black;
			}
			return color;
		}
		set
		{
			shape_0.method_62(Enum169.const_35);
			method_0().method_1(448, Enum183.const_1, value);
			IsVisible = true;
		}
	}

	/// <summary>
	///       Gets and sets the border line back color.
	///       </summary>
	public Color BackColor
	{
		get
		{
			return method_0().GetColor(450, Color.White);
		}
		set
		{
			method_0().method_1(450, Enum183.const_1, value);
		}
	}

	/// <summary>
	///       Gets or sets the dash style for the specified line.
	///       </summary>
	public MsoLineDashStyle DashStyle
	{
		get
		{
			int num = 0;
			switch (method_0().method_4(462, 0))
			{
			case 0:
				return MsoLineDashStyle.Solid;
			case 2:
			{
				int num2 = method_0().method_4(471, 0);
				if (num2 == 1)
				{
					return MsoLineDashStyle.RoundDot;
				}
				return MsoLineDashStyle.SquareDot;
			}
			default:
				return MsoLineDashStyle.Dash;
			case 6:
				return MsoLineDashStyle.Dash;
			case 7:
				return MsoLineDashStyle.DashLongDash;
			case 8:
				return MsoLineDashStyle.DashDot;
			case 9:
				return MsoLineDashStyle.DashLongDashDot;
			case 10:
				return MsoLineDashStyle.DashDotDot;
			}
		}
		set
		{
			shape_0.method_62(Enum169.const_39);
			int num = 0;
			method_0().Remove(471);
			switch (value)
			{
			case MsoLineDashStyle.Dash:
				num = 6;
				break;
			case MsoLineDashStyle.DashDot:
				num = 8;
				break;
			case MsoLineDashStyle.DashDotDot:
				num = 10;
				break;
			case MsoLineDashStyle.DashLongDash:
				num = 7;
				break;
			case MsoLineDashStyle.DashLongDashDot:
				num = 9;
				break;
			case MsoLineDashStyle.RoundDot:
				method_0().method_1(471, Enum183.const_0, 1);
				num = 2;
				break;
			case MsoLineDashStyle.Solid:
				num = 0;
				break;
			case MsoLineDashStyle.SquareDot:
				num = 2;
				break;
			}
			if (num == 0)
			{
				method_0().Remove(462);
			}
			else
			{
				method_0().method_1(462, Enum183.const_0, num);
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
			return 1.0 - method_2();
		}
		set
		{
			shape_0.method_62(Enum169.const_35);
			method_3(1.0 - value);
		}
	}

	/// <summary>
	///       Returns or sets the weight of the line ,in units of pt.
	///       </summary>
	public double Weight
	{
		get
		{
			int int_ = 9525;
			if (shape_0.method_25().Workbook.method_24() && shape_0.Style != null)
			{
				int_ = shape_0.Style.method_0(shape_0);
			}
			return (float)method_0().method_4(459, int_) / 12700f;
		}
		set
		{
			shape_0.method_62(Enum169.const_30);
			method_0().method_1(459, Enum183.const_0, (int)(value * 12700.0 + 0.5));
		}
	}

	internal BackgroundType Pattern
	{
		set
		{
		}
	}

	internal MsoArrowheadStyle BeginArrowheadStyle
	{
		get
		{
			return (MsoArrowheadStyle)method_0().method_4(464, 0);
		}
		set
		{
			method_0().method_1(464, Enum183.const_0, (int)value);
		}
	}

	internal MsoArrowheadWidth BeginArrowheadWidth
	{
		get
		{
			return (MsoArrowheadWidth)method_0().method_4(466, 0);
		}
		set
		{
			method_0().method_1(466, Enum183.const_0, (int)value);
		}
	}

	internal MsoArrowheadLength BeginArrowheadLength
	{
		get
		{
			return (MsoArrowheadLength)method_0().method_4(467, 0);
		}
		set
		{
			method_0().method_1(467, Enum183.const_0, (int)value);
		}
	}

	internal MsoArrowheadStyle EndArrowheadStyle
	{
		get
		{
			return (MsoArrowheadStyle)method_0().method_4(465, 0);
		}
		set
		{
			method_0().method_1(465, Enum183.const_0, (int)value);
		}
	}

	internal MsoArrowheadWidth EndArrowheadWidth
	{
		get
		{
			return (MsoArrowheadWidth)method_0().method_4(468, 0);
		}
		set
		{
			method_0().method_1(468, Enum183.const_0, (int)value);
		}
	}

	internal MsoArrowheadLength EndArrowheadLength
	{
		get
		{
			return (MsoArrowheadLength)method_0().method_4(469, 0);
		}
		set
		{
			method_0().method_1(469, Enum183.const_0, (int)value);
		}
	}

	internal MsoLineFormat(Shape shape_1)
	{
		shape_0 = shape_1;
	}

	[SpecialName]
	internal Class1711 method_0()
	{
		return shape_0.method_27().method_2();
	}

	[SpecialName]
	internal bool method_1()
	{
		return method_0().method_10(448);
	}

	[SpecialName]
	internal double method_2()
	{
		return method_0().method_7(449, 1f);
	}

	[SpecialName]
	internal void method_3(double double_0)
	{
		method_0().method_8(449, (float)double_0);
	}

	internal bool Contains(Enum182 enum182_0)
	{
		return method_0().Contains((ushort)enum182_0);
	}
}
