using System.Drawing;

namespace Aspose.Cells.Charts;

/// <summary>
///       Encapsulates the object that represents the walls of a 3-D chart.
///       </summary>
public class Walls : Floor
{
	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private int int_4;

	public int CenterX
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

	public int CenterY
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

	public int Width
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

	public int Depth
	{
		get
		{
			return int_3;
		}
		set
		{
			int_3 = value;
		}
	}

	public int Height
	{
		get
		{
			return int_4;
		}
		set
		{
			int_4 = value;
		}
	}

	internal Walls(Chart chart_2)
		: base(chart_2)
	{
		if (chart_2.method_12())
		{
			if (!ChartCollection.smethod_3(chart_2.Type))
			{
				base.ForegroundColor = Color.FromArgb(192, 192, 192);
			}
		}
		else
		{
			base.Formatting = FormattingType.Automatic;
		}
	}
}
