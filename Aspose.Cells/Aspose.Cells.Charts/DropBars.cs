using Aspose.Cells.Drawing;
using ns21;

namespace Aspose.Cells.Charts;

/// <summary>
///       Represents the up/down bars in a chart. 
///       </summary>
public class DropBars
{
	private Area area_0;

	private Line line_0;

	private Chart chart_0;

	private ShapePropertyCollection shapePropertyCollection_0;

	/// <summary>
	///       Gets the border <see cref="T:Aspose.Cells.Drawing.Line" />.
	///       </summary>
	public Line Border
	{
		get
		{
			if (line_0 == null)
			{
				line_0 = new Line(chart_0, this);
			}
			return line_0;
		}
	}

	/// <summary>
	///       Gets the <see cref="P:Aspose.Cells.Charts.DropBars.Area" />.
	///       </summary>
	public Area Area
	{
		get
		{
			if (area_0 == null)
			{
				area_0 = new Area(chart_0, this);
			}
			return area_0;
		}
	}

	internal ShapePropertyCollection ShapeProperties
	{
		get
		{
			if (shapePropertyCollection_0 == null)
			{
				shapePropertyCollection_0 = new ShapePropertyCollection(chart_0, this, Enum178.const_9);
			}
			return shapePropertyCollection_0;
		}
	}

	internal DropBars(Chart chart_1)
	{
		chart_0 = chart_1;
	}

	internal Line method_0()
	{
		return line_0;
	}

	internal Area method_1()
	{
		return area_0;
	}

	internal void Copy(DropBars dropBars_0)
	{
		if (dropBars_0.area_0 != null)
		{
			area_0.Copy(dropBars_0.area_0);
		}
		if (dropBars_0.line_0 != null)
		{
			line_0.Copy(dropBars_0.line_0);
		}
		if (dropBars_0.shapePropertyCollection_0 != null)
		{
			shapePropertyCollection_0 = new ShapePropertyCollection(chart_0, this, Enum178.const_9);
			shapePropertyCollection_0.Copy(dropBars_0.shapePropertyCollection_0);
		}
	}
}
