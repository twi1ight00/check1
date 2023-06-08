namespace ns135;

internal class Class4623
{
	private static Class4623 class4623_0;

	private double double_0;

	private double double_1;

	private double double_2;

	private double double_3;

	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	private bool bool_3;

	private bool bool_4;

	private double double_4;

	private double double_5;

	public static Class4623 Instance => class4623_0;

	public double DrawingPrecision_Lines
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

	public double DrawingFlatness_Curves
	{
		get
		{
			return double_5;
		}
		set
		{
			double_5 = value;
		}
	}

	public double RasterizationGridPrecision
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

	public double HintOwningPrecision
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

	public double HintOwningPrecision2
	{
		get
		{
			return double_2;
		}
		set
		{
			double_2 = value;
		}
	}

	public double EqualityPrecision
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

	public bool UseHinting
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

	public bool DetectSymmetricBreaks
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

	public bool HintWidthOptimization
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

	public bool Filling
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

	public bool InvertCurvesDirection
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

	static Class4623()
	{
		class4623_0 = new Class4623();
	}

	private Class4623()
	{
		bool_0 = true;
		bool_1 = true;
		double_0 = 0.01;
		double_1 = 10.0;
		double_2 = 2.0;
		double_3 = 5.0;
		bool_2 = true;
		bool_3 = true;
		bool_4 = false;
		double_4 = 1.0;
		double_5 = 100.0;
	}
}
