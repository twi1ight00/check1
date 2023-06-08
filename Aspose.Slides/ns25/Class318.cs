using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using ns16;
using ns24;
using ns56;

namespace ns25;

internal class Class318 : Class278
{
	private ChartSeriesGroup chartSeriesGroup_0;

	private IChartLinesFormat ichartLinesFormat_0;

	private IChartLinesFormat ichartLinesFormat_1;

	private IChartLinesFormat ichartLinesFormat_2;

	private byte byte_0 = 10;

	private ushort ushort_0 = 75;

	private double double_0 = 2.0;

	private Enum270 enum270_0;

	private Class884 class884_0;

	private bool bool_0;

	private Enum266 enum266_0;

	private int int_0 = 100;

	private Class1458 class1458_0;

	private Class1885 class1885_0;

	public IChartLinesFormat HiLowLinesFormat
	{
		get
		{
			if (ichartLinesFormat_1 == null)
			{
				ichartLinesFormat_1 = new ChartLinesFormat();
			}
			return ichartLinesFormat_1;
		}
	}

	public bool HasHiLowLines
	{
		get
		{
			if (ichartLinesFormat_1 != null)
			{
				return ichartLinesFormat_1.Line.FillFormat.FillType != FillType.NoFill;
			}
			return false;
		}
	}

	public IChartLinesFormat DropLinesFormat
	{
		get
		{
			if (ichartLinesFormat_0 == null)
			{
				ichartLinesFormat_0 = new ChartLinesFormat();
			}
			return ichartLinesFormat_0;
		}
	}

	public bool HasDropLines
	{
		get
		{
			if (ichartLinesFormat_0 != null)
			{
				return ichartLinesFormat_0.Line.FillFormat.FillType != FillType.NoFill;
			}
			return false;
		}
	}

	public IChartLinesFormat SeriesLinesFormat
	{
		get
		{
			if (ichartLinesFormat_2 == null)
			{
				ichartLinesFormat_2 = new ChartLinesFormat();
			}
			return ichartLinesFormat_2;
		}
	}

	public bool HasSeriesLines
	{
		get
		{
			if (ichartLinesFormat_2 != null)
			{
				return ichartLinesFormat_2.Line.FillFormat.FillType != FillType.NoFill;
			}
			return false;
		}
		set
		{
			if (ichartLinesFormat_2 == null)
			{
				if (value)
				{
					ichartLinesFormat_2 = new ChartLinesFormat();
					ichartLinesFormat_2.Line.FillFormat.FillType = FillType.NotDefined;
				}
			}
			else
			{
				ichartLinesFormat_2.Line.FillFormat.FillType = (value ? FillType.NotDefined : FillType.NoFill);
			}
		}
	}

	public byte DoughnutHoleSize
	{
		get
		{
			return byte_0;
		}
		set
		{
			if (value < 10 || value > 90)
			{
				throw new ArgumentOutOfRangeException("DoughnutHoleSize can be from 10 to 90 persents.");
			}
			byte_0 = value;
		}
	}

	public ushort SecondPieSize
	{
		get
		{
			return ushort_0;
		}
		set
		{
			if (value < 5 || value > 200)
			{
				throw new ArgumentOutOfRangeException("SecondPieSize can be from 5 to 200.");
			}
			ushort_0 = value;
		}
	}

	public bool ShowNegativeBubbles
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

	public Enum266 BubbleSizeRepresentation
	{
		get
		{
			return enum266_0;
		}
		set
		{
			enum266_0 = value;
		}
	}

	public double OfPieSplitPosition
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

	public Enum270 OfPieSplitType
	{
		get
		{
			return enum270_0;
		}
		set
		{
			enum270_0 = value;
		}
	}

	public Class884 OfPieCustomSplitPoints => class884_0;

	public int BubbleSizeScale
	{
		get
		{
			return int_0;
		}
		set
		{
			if (value < 0 || value > 300)
			{
				throw new ArgumentOutOfRangeException("BubbleSizeScale can be from 0 to 300.");
			}
			int_0 = value;
		}
	}

	public Class1458 SurfaceBandFormats
	{
		get
		{
			return class1458_0;
		}
		set
		{
			class1458_0 = value;
		}
	}

	public Class1885 ExtensionList
	{
		get
		{
			return class1885_0;
		}
		set
		{
			class1885_0 = value;
		}
	}

	public Class318(ChartSeriesGroup parent)
	{
		chartSeriesGroup_0 = parent;
		class884_0 = new Class884(parent);
	}
}
