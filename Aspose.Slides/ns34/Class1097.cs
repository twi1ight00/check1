using System.Text.RegularExpressions;
using Aspose.Slides.Charts;
using ns42;
using ns43;

namespace ns34;

internal class Class1097
{
	internal ChartDataWorksheet chartDataWorksheet_0;

	internal Class825 class825_0;

	internal string string_0;

	internal uint[] uint_0;

	private Class800 class800_0 = new Class800();

	internal Class800 TablePartXLSXUnsupportedProps => class800_0;

	internal Class1097(ChartDataWorksheet parent, Class825 doc)
	{
		chartDataWorksheet_0 = parent;
		class825_0 = doc;
		if (doc.TableElement != null)
		{
			string_0 = class825_0.TableElement.Reference;
		}
	}

	internal Class1097(ChartDataWorksheet parent)
	{
		chartDataWorksheet_0 = parent;
	}

	internal void method_0()
	{
		if (uint_0 != null)
		{
			string_0 = chartDataWorksheet_0.Cells[(int)uint_0[1], (int)uint_0[0]].Name + ":" + chartDataWorksheet_0.Cells[(int)uint_0[3], (int)uint_0[2]].Name;
			Class810 @class = class825_0.TableElement.method_57("tableColumns", Class825.string_13);
			if (@class == null)
			{
				@class = class825_0.TableElement.method_0("tableColumns", Class825.string_13);
			}
			@class.Prefix = "";
			@class.RemoveAllAttributes();
			@class.method_6();
			int num = 1;
			for (uint num2 = uint_0[0]; num2 <= uint_0[2]; num2++)
			{
				ChartDataCell chartDataCell = chartDataWorksheet_0.Cells[(int)uint_0[1], (int)num2];
				if (chartDataCell.StringValue.Trim() == "")
				{
					chartDataCell.method_2(" ");
				}
				chartDataCell.method_2(Regex.Replace(chartDataCell.StringValue, "[\n\r\t]", " "));
				Class810 class2 = @class.method_0("tableColumn", Class825.string_13);
				class2.SetAttribute("name", chartDataCell.StringValue);
				class2.SetAttribute("id", num++.ToString());
				class2.Prefix = "";
			}
			@class.SetAttribute("count", (num - 1).ToString());
		}
		class825_0.TableElement.Reference = string_0;
	}
}
