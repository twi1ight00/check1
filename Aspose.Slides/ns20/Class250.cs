using Aspose.Slides.Charts;
using ns21;
using ns34;
using ns56;

namespace ns20;

internal class Class250
{
	public static void smethod_0(Class738 cells, Class1747 worksheetElementData, Class1340 deserializationContext)
	{
		if (worksheetElementData == null)
		{
			return;
		}
		Class1688 sheetData = worksheetElementData.SheetData;
		Class1671[] rowList = sheetData.RowList;
		foreach (Class1671 @class in rowList)
		{
			Class1394[] cList = @class.CList;
			foreach (Class1394 cellElementData in cList)
			{
				ChartDataCell chartDataCell = new ChartDataCell(cells.chartDataWorksheet_0);
				Class251.smethod_0(chartDataCell, cellElementData, deserializationContext);
				cells.Add(chartDataCell);
				chartDataCell.IsHidden = @class.Hidden;
				Class1423[] colsList = worksheetElementData.ColsList;
				foreach (Class1423 class2 in colsList)
				{
					Class1415[] colList = class2.ColList;
					foreach (Class1415 class3 in colList)
					{
						if (chartDataCell.Column + 1 >= class3.Min && chartDataCell.Column + 1 <= class3.Max && class3.Hidden)
						{
							chartDataCell.IsHidden = true;
						}
					}
				}
			}
		}
	}

	public static void smethod_1(Class738 cells, Class1747 worksheetElementData)
	{
	}
}
