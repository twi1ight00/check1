using System.Text.RegularExpressions;
using System.Xml;
using Aspose.Slides.Charts;
using ns21;
using ns34;
using ns53;
using ns56;

namespace ns20;

internal class Class1218 : Class1216
{
	internal void method_5(ChartDataWorksheet worksheet)
	{
		method_0();
		while (base.XmlPartReader.Read())
		{
			if (base.XmlPartReader.NodeType == XmlNodeType.Element && base.XmlPartReader.LocalName == "table")
			{
				Class1710 @class = new Class1710(base.XmlPartReader);
				Class1097 class2 = new Class1097(worksheet);
				class2.string_0 = @class.Ref;
				Class800 tablePartXLSXUnsupportedProps = class2.TablePartXLSXUnsupportedProps;
				tablePartXLSXUnsupportedProps.AutoFilter = @class.AutoFilter;
				tablePartXLSXUnsupportedProps.Comment = @class.Comment;
				tablePartXLSXUnsupportedProps.ConnectionId = @class.ConnectionId;
				tablePartXLSXUnsupportedProps.DataCellStyle = @class.DataCellStyle;
				tablePartXLSXUnsupportedProps.DataDxfId = @class.DataDxfId;
				tablePartXLSXUnsupportedProps.DisplayName = @class.DisplayName;
				tablePartXLSXUnsupportedProps.HeaderRowBorderDxfId = @class.HeaderRowBorderDxfId;
				tablePartXLSXUnsupportedProps.HeaderRowCellStyle = @class.HeaderRowCellStyle;
				tablePartXLSXUnsupportedProps.HeaderRowCount = @class.HeaderRowCount;
				tablePartXLSXUnsupportedProps.HeaderRowDxfId = @class.HeaderRowDxfId;
				tablePartXLSXUnsupportedProps.Id = @class.Id;
				tablePartXLSXUnsupportedProps.InsertRow = @class.InsertRow;
				tablePartXLSXUnsupportedProps.InsertRowShift = @class.InsertRowShift;
				tablePartXLSXUnsupportedProps.Name = @class.Name;
				tablePartXLSXUnsupportedProps.Published = @class.Published;
				tablePartXLSXUnsupportedProps.SortState = @class.SortState;
				tablePartXLSXUnsupportedProps.TableBorderDxfId = @class.TableBorderDxfId;
				tablePartXLSXUnsupportedProps.TableColumns = @class.TableColumns;
				tablePartXLSXUnsupportedProps.TableStyleInfo = @class.TableStyleInfo;
				tablePartXLSXUnsupportedProps.TableType = @class.TableType;
				tablePartXLSXUnsupportedProps.TotalsRowBorderDxfId = @class.TotalsRowBorderDxfId;
				tablePartXLSXUnsupportedProps.TotalsRowCellStyle = @class.TotalsRowCellStyle;
				tablePartXLSXUnsupportedProps.TotalsRowCount = @class.TotalsRowCount;
				tablePartXLSXUnsupportedProps.TotalsRowDxfId = @class.TotalsRowDxfId;
				tablePartXLSXUnsupportedProps.TotalsRowShown = @class.TotalsRowShown;
				tablePartXLSXUnsupportedProps.ExtLst = @class.ExtLst;
				worksheet.class809_0.Add(class2);
			}
		}
		method_2();
	}

	internal void method_6(Class1097 table)
	{
		method_3();
		Class1710 @class = new Class1710();
		Class800 tablePartXLSXUnsupportedProps = table.TablePartXLSXUnsupportedProps;
		if (table.uint_0 != null)
		{
			table.string_0 = table.chartDataWorksheet_0.Cells[(int)table.uint_0[1], (int)table.uint_0[0]].Name + ":" + table.chartDataWorksheet_0.Cells[(int)table.uint_0[3], (int)table.uint_0[2]].Name;
			Class1712 tableColumns = @class.TableColumns;
			uint num = 1u;
			for (uint num2 = table.uint_0[0]; num2 <= table.uint_0[2]; num2++)
			{
				ChartDataCell chartDataCell = table.chartDataWorksheet_0.Cells[(int)table.uint_0[1], (int)num2];
				if (chartDataCell.StringValue.Trim() == "")
				{
					chartDataCell.method_2(" ");
				}
				chartDataCell.method_2(Regex.Replace(chartDataCell.StringValue, "[\n\r\t]", " "));
				Class1711 class2 = tableColumns.delegate1012_0();
				class2.Name = chartDataCell.StringValue;
				class2.Id = num++;
			}
			tableColumns.Count = num - 1;
		}
		else
		{
			@class.TableColumns.Count = tablePartXLSXUnsupportedProps.TableColumns.Count;
			Class1711[] tableColumnList = tablePartXLSXUnsupportedProps.TableColumns.TableColumnList;
			foreach (Class1711 elementData in tableColumnList)
			{
				@class.TableColumns.delegate1013_0(elementData);
			}
		}
		@class.Ref = table.string_0 ?? "";
		@class.delegate77_0(tablePartXLSXUnsupportedProps.AutoFilter);
		@class.Comment = tablePartXLSXUnsupportedProps.Comment;
		@class.ConnectionId = tablePartXLSXUnsupportedProps.ConnectionId;
		@class.DataCellStyle = tablePartXLSXUnsupportedProps.DataCellStyle;
		@class.DataDxfId = tablePartXLSXUnsupportedProps.DataDxfId;
		@class.DisplayName = tablePartXLSXUnsupportedProps.DisplayName;
		@class.HeaderRowBorderDxfId = tablePartXLSXUnsupportedProps.HeaderRowBorderDxfId;
		@class.HeaderRowCellStyle = tablePartXLSXUnsupportedProps.HeaderRowCellStyle;
		@class.HeaderRowCount = tablePartXLSXUnsupportedProps.HeaderRowCount;
		@class.HeaderRowDxfId = tablePartXLSXUnsupportedProps.HeaderRowDxfId;
		@class.Id = tablePartXLSXUnsupportedProps.Id;
		@class.InsertRow = tablePartXLSXUnsupportedProps.InsertRow;
		@class.InsertRowShift = tablePartXLSXUnsupportedProps.InsertRowShift;
		@class.Name = tablePartXLSXUnsupportedProps.Name;
		@class.Published = tablePartXLSXUnsupportedProps.Published;
		@class.delegate999_0(tablePartXLSXUnsupportedProps.SortState);
		@class.TableBorderDxfId = tablePartXLSXUnsupportedProps.TableBorderDxfId;
		@class.delegate1041_0(tablePartXLSXUnsupportedProps.TableStyleInfo);
		@class.TableType = tablePartXLSXUnsupportedProps.TableType;
		@class.TotalsRowBorderDxfId = tablePartXLSXUnsupportedProps.TotalsRowBorderDxfId;
		@class.TotalsRowCellStyle = tablePartXLSXUnsupportedProps.TotalsRowCellStyle;
		@class.TotalsRowCount = tablePartXLSXUnsupportedProps.TotalsRowCount;
		@class.TotalsRowDxfId = tablePartXLSXUnsupportedProps.TotalsRowDxfId;
		@class.TotalsRowShown = tablePartXLSXUnsupportedProps.TotalsRowShown;
		@class.delegate387_0(tablePartXLSXUnsupportedProps.ExtLst);
		@class.vmethod_4(null, base.XmlPartWriter, "table");
		method_4();
	}

	public Class1218(Class1342 part, Class1340 deserializationContext)
		: base(part, deserializationContext)
	{
	}

	public Class1218(Class1342 part, Class1345 serializationContext)
		: base(part, serializationContext)
	{
	}
}
