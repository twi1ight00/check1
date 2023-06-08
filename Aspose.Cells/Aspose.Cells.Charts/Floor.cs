using Aspose.Cells.Drawing;
using ns21;

namespace Aspose.Cells.Charts;

/// <summary>
///       Encapsulates the object that represents the floor of a 3-D chart.
///       </summary>
/// <example>
///   <code>
///
///       [C#]
///
///       //Instantiate the License class
///       Aspose.Cells.License license = new Aspose.Cells.License();
///
///       //Pass only the name of the license file embedded in the assembly
///       license.SetLicense("Aspose.Cells.lic");
///
///       //Instantiate the workbook object
///       Workbook workbook = new Workbook();
///
///       //Get cells collection
///       Cells cells = workbook.Worksheets[0].Cells;
///
///       //Put values in cells
///       cells["A1"].PutValue(1);
///
///       cells["A2"].PutValue(2);
///
///       cells["A3"].PutValue(3);
///
///       //get charts colletion
///       Charts charts = workbook.Worksheets[0].Charts;
///
///       //add a new chart 
///       int index = charts.Add(ChartType.Column3DStacked, 5, 0, 15, 5);
///
///       //get the newly added chart
///       Chart chart = charts[index];
///
///       //set charts nseries
///       chart.NSeries.Add("A1:A3", true);
///
///       //Show data labels
///       chart.NSeries[0].DataLabels.IsValueShown = true;
///
///       //Get chart's floor
///       Floor floor = chart.Floor;
///
///       //set floor's border as red
///       floor.Border.Color = System.Drawing.Color.Red;
///
///       //set fill format
///       floor.FillFormat.SetPresetColorGradient(GradientPresetType.CalmWater, GradientStyleType.DiagonalDown, 2); 
///
///       //save the file
///       workbook.Save(@"d:\dest.xls");
///
///       [VB.NET]
///
///       'Instantiate the License class
///       Dim license As New Aspose.Cells.License()
///
///       'Pass only the name of the license file embedded in the assembly
///       license.SetLicense("Aspose.Cells.lic")
///
///       'Instantiate the workbook object
///       Dim workbook As New Workbook()
///
///       'Get cells collection
///       Dim cells As Cells = workbook.Worksheets(0).Cells
///
///       'Put values in cells
///       cells("A1").PutValue(1)
///
///       cells("A2").PutValue(2)
///
///       cells("A3").PutValue(3)
///
///       'get charts colletion
///       Dim charts As Charts = workbook.Worksheets(0).Charts
///
///       'add a new chart 
///       Dim index As Integer = charts.Add(ChartType.Column3DStacked, 5, 0, 15, 5)
///
///       'get the newly added chart
///       Dim chart As Chart = charts(index)
///
///       'set charts nseries
///       chart.NSeries.Add("A1:A3", True)
///
///       'Show data labels
///       chart.NSeries(0).DataLabels.IsValueShown = True
///
///       'Get chart's floor
///       Dim floor As Floor = chart.Floor
///
///       'set floor's border as red
///       floor.Border.Color = System.Drawing.Color.Red
///
///       'set fill format
///       floor.FillFormat.SetPresetColorGradient(GradientPresetType.CalmWater, GradientStyleType.DiagonalDown, 2)
///
///       'save the file
///       workbook.Save("d:\dest.xls")
///
///       </code>
/// </example>
public class Floor : Area
{
	private Chart chart_1;

	internal Line line_0;

	protected ShapePropertyCollection m_SpPr;

	/// <summary>
	///       Gets or sets the border <see cref="T:Aspose.Cells.Drawing.Line" />.
	///       </summary>
	public Line Border
	{
		get
		{
			return line_0;
		}
		set
		{
			line_0 = value;
		}
	}

	internal ShapePropertyCollection ShapeProperties
	{
		get
		{
			if (m_SpPr == null)
			{
				m_SpPr = new ShapePropertyCollection(chart_1, this, Enum178.const_10);
			}
			return m_SpPr;
		}
	}

	internal Floor(Chart chart_2)
		: base(chart_2, chart_2)
	{
		chart_1 = chart_2;
		line_0 = new Line(chart_2, this);
	}

	internal void Copy(Walls walls_0)
	{
		Copy((Area)walls_0);
		line_0.Copy(walls_0.line_0);
		if (walls_0.m_SpPr != null)
		{
			m_SpPr = new ShapePropertyCollection(chart_1, this, Enum178.const_10);
			m_SpPr.Copy(walls_0.m_SpPr);
		}
	}
}
