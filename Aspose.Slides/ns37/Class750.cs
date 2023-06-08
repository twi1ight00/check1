using System;
using System.Drawing;
using Aspose.Slides.Charts;
using ns36;

namespace ns37;

internal class Class750 : Interface13
{
	private Class746 class746_0;

	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5;

	private LegendDataLabelPosition legendDataLabelPosition_0;

	private Enum153 enum153_0;

	private int int_0;

	private Enum157 enum157_0;

	private Enum157 enum157_1;

	private bool bool_6;

	private string string_0 = "";

	private bool bool_7;

	private string string_1;

	private Class778 class778_0;

	internal RectangleF rectangleF_0;

	internal RectangleF rectangleF_1;

	internal PointF pointF_0 = PointF.Empty;

	internal PointF pointF_1 = PointF.Empty;

	internal PointF pointF_2 = PointF.Empty;

	internal double double_0;

	internal bool bool_8;

	internal Class746 ChartFrameInternal => class746_0;

	public Interface10 ChartFrame => class746_0;

	internal bool IsVisible
	{
		get
		{
			if (Text != null && Text.Length > 0)
			{
				return true;
			}
			if (!IsBubbleSizeShown && !IsCategoryNameShown && !IsPercentageShown && !IsSeriesNameShown && !IsValueShown)
			{
				return false;
			}
			return true;
		}
	}

	public bool IsCategoryNameShown
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	public bool IsLegendKeyShown
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	public bool IsPercentageShown
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
		}
	}

	public bool IsValueShown
	{
		get
		{
			return bool_4;
		}
		set
		{
			bool_4 = value;
		}
	}

	public bool IsSeriesNameShown
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

	public bool IsBubbleSizeShown
	{
		get
		{
			return bool_5;
		}
		set
		{
			bool_5 = value;
		}
	}

	public LegendDataLabelPosition LabelPosition
	{
		get
		{
			return legendDataLabelPosition_0;
		}
		set
		{
			legendDataLabelPosition_0 = value;
		}
	}

	public Enum153 Separator
	{
		get
		{
			return enum153_0;
		}
		set
		{
			enum153_0 = value;
		}
	}

	public int Rotation
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

	public Enum157 TextHorizontalAlignment
	{
		get
		{
			return enum157_0;
		}
		set
		{
			enum157_0 = value;
		}
	}

	public Enum157 TextVerticalAlignment
	{
		get
		{
			return enum157_1;
		}
		set
		{
			enum157_1 = value;
		}
	}

	public string Format
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

	public bool LinkedSource
	{
		get
		{
			return bool_6;
		}
		set
		{
			bool_6 = value;
		}
	}

	public bool IsCulture
	{
		get
		{
			return bool_7;
		}
		set
		{
			bool_7 = value;
		}
	}

	public string Text
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

	internal bool IsShown
	{
		get
		{
			if (Text != null && Text != "")
			{
				return true;
			}
			if (IsSeriesNameShown)
			{
				return true;
			}
			if (IsCategoryNameShown)
			{
				return true;
			}
			if (IsValueShown)
			{
				return true;
			}
			Class759 @class = null;
			if (class746_0.Parent is Class759)
			{
				@class = (Class759)class746_0.Parent;
			}
			else if (class746_0.Parent is Class748)
			{
				@class = ((Class748)class746_0.Parent).ChartPoints.ASeries;
			}
			if (@class != null && @class.IsPieSeries && IsPercentageShown)
			{
				return true;
			}
			if (@class != null && @class.IsBubbleSeries && IsBubbleSizeShown)
			{
				return true;
			}
			return false;
		}
	}

	public Interface29 RichCharactersList => class778_0;

	internal bool IsPositionToLeft
	{
		get
		{
			if (double_0 > -4.71238898038469 && double_0 < -Math.PI / 2.0)
			{
				return true;
			}
			return false;
		}
	}

	internal bool IsPositionToBottom
	{
		get
		{
			double num = 0.008697830681563268;
			if ((double_0 < num && double_0 > -Math.PI) || double_0 < Math.PI * -2.0 + num)
			{
				return true;
			}
			return false;
		}
	}

	internal int MoveType
	{
		get
		{
			if (!IsPositionToLeft && !IsPositionToBottom)
			{
				return 1;
			}
			if (!IsPositionToLeft && IsPositionToBottom)
			{
				return 2;
			}
			if (IsPositionToLeft && IsPositionToBottom)
			{
				return 3;
			}
			return 4;
		}
	}

	internal Class750(Class740 chart, object parent, Enum140 areaParentType)
	{
		class746_0 = new Class746(chart, parent, areaParentType, Enum145.const_14);
		bool_0 = false;
		bool_1 = false;
		bool_2 = false;
		bool_3 = false;
		bool_4 = false;
		bool_5 = false;
		legendDataLabelPosition_0 = LegendDataLabelPosition.BestFit;
		enum153_0 = Enum153.const_0;
		int_0 = 0;
		enum157_0 = Enum157.const_1;
		enum157_1 = Enum157.const_1;
		string_1 = null;
		bool_6 = true;
		class778_0 = new Class778();
	}
}
