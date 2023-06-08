using System;
using Aspose.Cells;
using Richfit.Garnet.Common.Extensions;

namespace Richfit.Garnet.Module.Importing.Aspose.Excel;

/// <summary>
/// 数据表解析上下文
/// </summary>
public class SheetResolveContext
{
	/// <summary>
	/// 导入模版
	/// </summary>
	public AsposeExcelImportTemplate Template { get; internal set; }

	/// <summary>
	/// 是否已经解析当前数据表
	/// </summary>
	public bool Resolved { get; set; }

	/// <summary>
	/// 解析时是否出现错误
	/// </summary>
	public bool Error { get; set; }

	/// <summary>
	/// 初始化
	/// </summary>
	public SheetResolveContext()
	{
		Reset();
	}

	/// <summary>
	/// 重置上下文状态
	/// </summary>
	public void Reset()
	{
		Template = null;
		Resolved = true;
		Error = false;
	}

	/// <summary>
	/// 获取区域文本值
	/// </summary>
	/// <param name="rangeAddress">区域地址</param>
	/// <returns>区域文本值</returns>
	public string GetRangeText(string rangeAddress)
	{
		rangeAddress.GuardNotNull();
		Worksheet sheet = Template.Sheet;
		Range range = sheet.Cells.CreateRange(rangeAddress);
		return range[0, 0].StringValue;
	}

	/// <summary>
	/// 获取区域中定义的日期值
	/// </summary>
	/// <param name="rangeAddress">区域地址</param>
	/// <returns>区域中定义的日期值</returns>
	public DateTime? GetRangeDateTime(string rangeAddress)
	{
		rangeAddress.GuardNotNull();
		Worksheet sheet = Template.Sheet;
		Range range = sheet.Cells.CreateRange(rangeAddress);
		if (double.TryParse(range[0, 0].StringValue, out var value))
		{
			if (value >= 0.0)
			{
				DateTime d = new DateTime(1900, 1, 1);
				return sheet.Workbook.Settings.Date1904 ? new DateTime(1904, 1, 1) : new DateTime(1900, 1, 1).AddDays(value - 2.0);
			}
			return null;
		}
		return null;
	}

	/// <summary>
	/// 获取单元格的文本值
	/// </summary>
	/// <param name="rowIndex">行索引</param>
	/// <param name="columnIndex">列索引</param>
	/// <returns>单元格的文本值</returns>
	public string GetCellText(int rowIndex, int columnIndex)
	{
		rowIndex.GuardGreaterThanOrEqualTo(0, "row index");
		columnIndex.GuardGreaterThanOrEqualTo(0, "column index");
		return Template.Sheet.Cells[rowIndex, columnIndex].StringValue;
	}

	/// <summary>
	/// 获取区域中定义的日期值
	/// </summary>
	/// <param name="rowIndex">行索引</param>
	/// <param name="columnIndex">列索引</param>
	/// <returns>单元格中定义的日期</returns>
	public DateTime? GetCellDateTime(int rowIndex, int columnIndex)
	{
		rowIndex.GuardGreaterThanOrEqualTo(0, "row index");
		columnIndex.GuardGreaterThanOrEqualTo(0, "column index");
		Worksheet sheet = Template.Sheet;
		if (double.TryParse(sheet.Cells[rowIndex, columnIndex].StringValue, out var value))
		{
			if (value >= 0.0)
			{
				return sheet.Workbook.Settings.Date1904 ? new DateTime(1904, 1, 1) : (new DateTime(1900, 1, 1) + TimeSpan.FromDays(value));
			}
			return null;
		}
		return null;
	}

	/// <summary>
	/// 标记区域错误
	/// </summary>
	/// <param name="rangeAddress">区域地址</param>
	/// <param name="message">错误信息</param>
	public void MarkRangeError(string rangeAddress, string message)
	{
		rangeAddress.GuardNotNull();
		Worksheet sheet = Template.Sheet;
		Range range = sheet.Cells.CreateRange(rangeAddress);
		AsposeExcelImporter.SetErrorMark(sheet, range, message.IfNull(string.Empty));
		Error = true;
	}

	/// <summary>
	/// 标记单元格错误
	/// </summary>
	/// <param name="rowIndex">行索引</param>
	/// <param name="columnIndex">列索引</param>
	/// <param name="message">错误信息</param>
	public void MarkCellError(int rowIndex, int columnIndex, string message)
	{
		rowIndex.GuardGreaterThanOrEqualTo(0, "row index");
		columnIndex.GuardGreaterThanOrEqualTo(0, "column index");
		AsposeExcelImporter.SetErrorMark(Template.Sheet, rowIndex, columnIndex, message.IfNull(string.Empty));
		Error = true;
	}
}
