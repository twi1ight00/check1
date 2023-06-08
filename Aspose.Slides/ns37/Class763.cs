using System.Drawing;
using Aspose.Slides.Charts;
using ns36;

namespace ns37;

internal class Class763 : Interface23
{
	private Class755 class755_0;

	private Class762 class762_0;

	private double double_0;

	private bool bool_0;

	private bool bool_1;

	private double double_1;

	private double double_2;

	private bool bool_2;

	private string string_0;

	private int int_0;

	private int int_1;

	private TrendlineType trendlineType_0;

	private Class750 class750_0;

	private double[] double_3;

	private double double_4;

	private bool bool_3;

	private int int_2;

	private bool bool_4;

	internal PointF pointF_0 = PointF.Empty;

	internal Class762 TrendlinesInternal => class762_0;

	public Interface22 Trendlines => class762_0;

	internal Class755 BorderInternal => class755_0;

	public Interface18 Border => class755_0;

	public double Backward
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

	public bool DisplayEquation
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

	public bool DisplayRSquared
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

	public double Forward
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

	public double Intercept
	{
		get
		{
			return double_2;
		}
		set
		{
			double_2 = value;
			bool_3 = true;
		}
	}

	internal bool IsInterceptSet => bool_3;

	public bool IsNameAuto
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

	public string Name
	{
		get
		{
			if (IsNameAuto)
			{
				Class759 aSeriesInternal = class762_0.ASeriesInternal;
				return Type switch
				{
					TrendlineType.Exponential => "Expon.(" + aSeriesInternal.Name + ")", 
					TrendlineType.Linear => "Linear(" + aSeriesInternal.Name + ")", 
					TrendlineType.Logarithmic => "Log.(" + aSeriesInternal.Name + ")", 
					TrendlineType.MovingAverage => int_1 + " per. Mov. Avg.(" + aSeriesInternal.Name + ")", 
					TrendlineType.Polynomial => "Poly.(" + aSeriesInternal.Name + ")", 
					TrendlineType.Power => "Power(" + aSeriesInternal.Name + ")", 
					_ => "", 
				};
			}
			return string_0;
		}
		set
		{
			string_0 = value;
			IsNameAuto = false;
		}
	}

	public int Order
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

	public int Period
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

	public TrendlineType Type
	{
		get
		{
			return trendlineType_0;
		}
		set
		{
			trendlineType_0 = value;
		}
	}

	internal Class750 DataLabelsInternal => class750_0;

	public Interface13 DataLabels => class750_0;

	internal double[] EquationParam
	{
		get
		{
			return double_3;
		}
		set
		{
			double_3 = value;
		}
	}

	internal double RSquaredParam
	{
		get
		{
			return double_4;
		}
		set
		{
			double_4 = value;
		}
	}

	public int ID
	{
		get
		{
			return int_2;
		}
		set
		{
			int_2 = value;
		}
	}

	internal bool IsLegendDeleted
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

	internal Class763(Class740 chart, Class762 trendlines)
	{
		class755_0 = new Class755(chart, Enum145.const_19);
		class762_0 = trendlines;
		double_0 = 0.0;
		bool_0 = false;
		bool_1 = false;
		double_1 = 0.0;
		double_2 = 0.0;
		bool_2 = false;
		string_0 = "";
		int_0 = 2;
		int_1 = 2;
		trendlineType_0 = TrendlineType.Exponential;
		class750_0 = new Class750(chart, this, Enum140.const_16);
	}
}
