using System;
using System.Globalization;
using Aspose.Slides.Charts;
using Aspose.Slides.Warnings;
using ns21;
using ns34;
using ns56;

namespace ns20;

internal class Class251
{
	public static void smethod_0(ChartDataCell cell, Class1394 cellElementData, Class1340 deserializationContext)
	{
		if (cellElementData == null)
		{
			return;
		}
		cell.enum262_0 = cellElementData.T;
		cell.class736_0 = cell.method_9(cell.chartDataWorksheet_0.ParentWorkbook.class737_0[(int)cellElementData.S]);
		if (cell.class736_0.NumFmtId >= 164 && cell.class736_0.ApplyNumberFormat != 0)
		{
			Class804 @class = cell.method_8(cell.class736_0.NumFmtId);
			if (@class != null)
			{
				cell.string_1 = @class.FormatCode;
			}
		}
		if (cell.enum262_0 == Enum262.const_3)
		{
			try
			{
				cell.object_0 = cell.chartDataWorksheet_0.ParentWorkbook.class808_0[Convert.ToInt32(cellElementData.V)];
			}
			catch (NotImplementedException)
			{
				cell.object_0 = null;
				deserializationContext.method_0("SharedString " + cellElementData.V + " has unknown type and is not loaded", WarningType.DataLoss);
			}
		}
		else if (cellElementData.V == null)
		{
			cell.object_0 = cellElementData.V;
		}
		else
		{
			string v = cellElementData.V;
			if (double.TryParse(v, NumberStyles.Any, CultureInfo.InvariantCulture, out var result))
			{
				cell.object_0 = result;
			}
			else
			{
				cell.object_0 = cellElementData.V;
			}
		}
		cell.string_0 = cellElementData.R;
		cell.method_5();
		cell.bool_0 = true;
	}

	public static void smethod_1(ChartDataCell cell, Class1394 cellElementData, Class1345 serializationContext)
	{
		cellElementData.R = cell.string_0;
		cellElementData.T = cell.enum262_0;
		if (cell.string_1.Trim() != "")
		{
			Class804 @class = ChartDataCell.smethod_1(cell.string_1, cell.chartDataWorksheet_0.ParentWorkbook);
			cell.class736_0.NumFmtId = @class.NumFormatID;
		}
		cellElementData.S = (uint)ChartDataCell.smethod_0(cell);
		if (cell.enum262_0 == Enum262.const_3)
		{
			Class808 class808_ = cell.chartDataWorksheet_0.ParentWorkbook.class808_0;
			int num = -1;
			for (int i = 0; i < class808_.Count; i++)
			{
				try
				{
					if (class808_[i] == (string)cell.object_0)
					{
						num = i;
						break;
					}
				}
				catch (Exception)
				{
					serializationContext.method_0("SharedString " + cellElementData.V + " has unknown type and is not read", WarningType.DataLoss);
				}
			}
			if (num == -1)
			{
				num = class808_.Add((string)cell.object_0);
				class808_.uint_1++;
			}
			cellElementData.V = Convert.ToString(num, CultureInfo.InvariantCulture);
			class808_.uint_0++;
		}
		else if (cell.object_0 == null)
		{
			cellElementData.V = null;
		}
		else
		{
			cellElementData.V = Convert.ToString(cell.object_0, CultureInfo.InvariantCulture);
		}
	}
}
