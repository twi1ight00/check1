using System.Drawing;
using System.Runtime.CompilerServices;
using Aspose.Cells.Drawing;
using ns7;

namespace Aspose.Cells.Charts;

public class PlotArea : ChartFrame
{
	internal int int_12;

	internal int int_13;

	internal int int_14;

	internal int int_15;

	internal byte[] byte_1;

	private bool bool_5;

	private string string_0;

	public override int X
	{
		get
		{
			return method_23();
		}
		set
		{
			method_22(value);
			method_31(bool_5: false);
			m_IsAutoXPos = false;
			base.IsInnerMode = false;
		}
	}

	public override int Y
	{
		get
		{
			return method_25();
		}
		set
		{
			method_24(value);
			method_31(bool_5: false);
			m_IsAutoYPos = false;
			base.IsInnerMode = false;
		}
	}

	public override int Height
	{
		get
		{
			return method_26();
		}
		set
		{
			method_27(value);
			method_31(bool_5: false);
			m_isAutoSize = false;
			base.IsInnerMode = false;
		}
	}

	public override int Width
	{
		get
		{
			return method_29();
		}
		set
		{
			method_28(value);
			method_31(bool_5: false);
			m_isAutoSize = false;
			base.IsInnerMode = false;
		}
	}

	public int InnerX
	{
		get
		{
			return int_12;
		}
		set
		{
			int_12 = value;
			method_31(bool_5: false);
			m_IsAutoXPos = false;
			base.IsInnerMode = true;
		}
	}

	public int InnerY
	{
		get
		{
			return int_13;
		}
		set
		{
			int_13 = value;
			method_31(bool_5: false);
			m_IsAutoYPos = false;
			base.IsInnerMode = true;
		}
	}

	public int InnerHeight
	{
		get
		{
			return int_15;
		}
		set
		{
			int_15 = value;
			method_31(bool_5: false);
			m_isAutoSize = false;
			base.IsInnerMode = true;
		}
	}

	public int InnerWidth
	{
		get
		{
			return int_14;
		}
		set
		{
			int_14 = value;
			method_31(bool_5: false);
			m_isAutoSize = false;
			base.IsInnerMode = true;
		}
	}

	internal void method_39()
	{
		if (ChartCollection.smethod_3(base.Chart.Type))
		{
			base.Border.IsVisible = false;
			base.Area.Formatting = FormattingType.None;
		}
		else
		{
			base.Border.Color = Color.FromArgb(128, 128, 128);
			base.Border.Weight = WeightType.SingleLine;
			base.Area.ForegroundColor = Color.FromArgb(192, 192, 192);
		}
	}

	internal PlotArea(Chart chart_1)
		: base(chart_1)
	{
		method_8(Enum18.const_1);
	}

	internal void method_40(int int_16, int int_17, int int_18, int int_19)
	{
		int_12 = int_16;
		int_13 = int_17;
		int_14 = int_18;
		int_15 = int_19;
	}

	[SpecialName]
	internal bool method_41()
	{
		return bool_5;
	}

	[SpecialName]
	internal void method_42(bool bool_6)
	{
		bool_5 = bool_6;
	}

	[SpecialName]
	internal string method_43()
	{
		return string_0;
	}

	[SpecialName]
	internal void method_44(string string_1)
	{
		string_0 = string_1;
	}

	internal void Copy(PlotArea plotArea_0)
	{
		Copy((ChartFrame)plotArea_0);
		int_12 = plotArea_0.InnerX;
		int_13 = plotArea_0.InnerY;
		int_14 = plotArea_0.InnerWidth;
		int_15 = plotArea_0.InnerHeight;
	}
}
