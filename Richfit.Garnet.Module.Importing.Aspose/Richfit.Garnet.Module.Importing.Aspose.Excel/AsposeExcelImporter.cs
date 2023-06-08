using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using Aspose.Cells;
using Richfit.Garnet.Common.Configuration;
using Richfit.Garnet.Common.Dynamic;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Importing.Aspose.Properties;

namespace Richfit.Garnet.Module.Importing.Aspose.Excel;

/// <summary>
/// 基于Aspose组件的Excel导入器
/// </summary>
public class AsposeExcelImporter : AsposeImporter
{
	/// <summary>
	/// 获取配置视图
	/// </summary>
	protected AsposeExcelImporterConfigurationView ConfigurationView => base.View as AsposeExcelImporterConfigurationView;

	/// <summary>
	/// 获取导入选项
	/// </summary>
	public AsposeExcelImportOptions Options => ConfigurationView.IsNull() ? new AsposeExcelImportOptions() : ConfigurationView.GetOptions();

	/// <summary>
	/// 获取导入模版数组
	/// </summary>
	public AsposeExcelImportTemplate[] Templates => ConfigurationView.IsNull() ? new AsposeExcelImportTemplate[0] : ConfigurationView.GetTemplates();

	/// <summary>
	/// 初始化指定名称的导入器
	/// </summary>
	/// <param name="name">导入器名称</param>
	public AsposeExcelImporter(string name)
		: base(name)
	{
	}

	/// <summary>
	/// 使用指定配置初始化导入器
	/// </summary>
	/// <param name="view">导入器配置源</param>
	public AsposeExcelImporter(AsposeExcelImporterConfigurationView view)
		: base(view)
	{
	}

	/// <summary>
	/// 加载导入器配置
	/// </summary>
	/// <param name="view">配置视图</param>
	protected override void LoadConfiguration(IConfigurationView view)
	{
	}

	/// <summary>
	/// 清理导入器
	/// </summary>
	/// <param name="disposing"></param>
	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
		}
		base.Dispose(disposing);
	}

	/// <summary>
	///  解析Excel数据文件，返回生成的对象
	/// </summary>
	/// <param name="template">导入的Excel文件流</param>
	/// <param name="templateName">导入的模版名称</param>
	/// <param name="options">导入选项</param>
	/// <param name="error">如果导入中出现错误，则返回标记后的Excel文件；未发生错误返回null</param>
	/// <returns>结果数据文件</returns>
	public List<IDataObject> ImportFromTemplate(Stream template, string templateName, AsposeExcelImportOptions options, out Stream error)
	{
		template.GuardNotNull("template");
		options = (options.IsNull() ? Options : options.MergeOptions(Options));
		options.ImportTemplateNames = templateName.IfNull(string.Empty);
		return ImportFromTemplate(template, options, out error).Values.FirstOrDefault().IfNull(new List<IDataObject>());
	}

	/// <summary>
	/// 解析Excel数据文件，返回生成的对象
	/// </summary>
	/// <param name="template">导入的Excel文件流</param>
	/// <param name="options">导入选项</param>
	/// <param name="error">如果导入中出现错误，则返回标记后的Excel文件；未发生错误返回null</param>
	/// <returns>结果数据文件</returns>
	public Dictionary<string, List<IDataObject>> ImportFromTemplate(Stream template, AsposeExcelImportOptions options, out Stream error)
	{
		template.GuardNotNull("template");
		options = (options.IsNull() ? Options : options.MergeOptions(Options));
		error = null;
		Workbook book = new Workbook((Stream)(object)template, new LoadOptions(options.GetLoadFormat()));
		template.Position = 0L;
		List<AsposeExcelImportTemplate> importTemplates = new List<AsposeExcelImportTemplate>();
		string[] importTemplateNames = options.GetTemplateNames();
		int templateIndex = 0;
		AsposeExcelImportTemplate[] templates = Templates;
		foreach (AsposeExcelImportTemplate importTemplate in templates)
		{
			if (!options.ImportTemplateNames.IsNull() && !importTemplateNames.Any((string x) => x.EqualOrdinal(importTemplate.Name)))
			{
				continue;
			}
			if (importTemplate.Title.IsNullOrEmpty())
			{
				if (templateIndex < ((CollectionBase)(object)book.Worksheets).Count)
				{
					AsposeExcelImportTemplate currentTemplate = importTemplate.Copy();
					currentTemplate.Sheet = book.Worksheets[templateIndex];
					importTemplates.Add(parseTemplate(book.Worksheets[templateIndex], currentTemplate));
				}
				continue;
			}
			Worksheet sheet = book.Worksheets[importTemplate.Title];
			if (sheet.IsNotNull())
			{
				AsposeExcelImportTemplate currentTemplate = importTemplate.Copy();
				currentTemplate.Sheet = sheet;
				importTemplates.Add(parseTemplate(sheet, currentTemplate));
			}
		}
		if (importTemplates.Count == 0)
		{
			throw new InvalidOperationException(Literals.M_E_Importing_NoTemplate);
		}
		Dictionary<string, List<IDataObject>> dataCache = new Dictionary<string, List<IDataObject>>();
		List<Tuple<AsposeExcelImportTemplate, int>> errorCache = new List<Tuple<AsposeExcelImportTemplate, int>>();
		bool hasError = false;
		foreach (AsposeExcelImportTemplate importTemplate2 in importTemplates)
		{
			ClearErrorMark(importTemplate2);
			ClearErrorComment(importTemplate2);
			if (options.SheetResolve.IsNotNull())
			{
				importTemplate2.SheetResolveContext.Reset();
				importTemplate2.SheetResolveContext.Template = importTemplate2;
				try
				{
					options.SheetResolve(importTemplate2.SheetResolveContext);
				}
				catch (Exception ex2)
				{
					throw new SheetResolveException(importTemplate2.SheetResolveContext, ex2);
				}
				if (importTemplate2.SheetResolveContext.Resolved)
				{
					hasError = importTemplate2.SheetResolveContext.Error;
					importTemplate2.SheetResolveContext.Reset();
					break;
				}
				hasError = importTemplate2.SheetResolveContext.Error;
				importTemplate2.SheetResolveContext.Reset();
			}
			List<IDataObject> dataList = new List<IDataObject>();
			dataCache.Add(importTemplate2.Name, dataList);
			hasError |= LoadTemplateData(importTemplate2, options, dataList, errorCache);
		}
		if (hasError)
		{
			errorCache.Sort((Tuple<AsposeExcelImportTemplate, int> x, Tuple<AsposeExcelImportTemplate, int> y) => x.Item2.CompareTo(y.Item2));
			if (options.ReturnAllDataOnError.Equals(false))
			{
				errorCache.Reverse();
				Worksheet sheet = null;
				foreach (Tuple<AsposeExcelImportTemplate, int> x2 in errorCache)
				{
					if (sheet.IsNull() || !sheet.Name.EqualOrdinal(x2.Item1.Sheet.Name))
					{
						sheet = book.Worksheets[x2.Item1.Sheet.Name];
					}
					sheet.Cells.DeleteRow(x2.Item2);
				}
			}
			if (options.ReturnAllDataOnError.Equals(true) && options.SortErrorData.Equals(true))
			{
				Worksheet sheet = null;
				foreach (Tuple<AsposeExcelImportTemplate, int> x2 in errorCache)
				{
					try
					{
						if (sheet.IsNull() || !sheet.Name.EqualOrdinal(x2.Item1.Sheet.Name))
						{
							sheet = book.Worksheets[x2.Item1.Sheet.Name];
						}
						sheet.Cells.InsertRow(x2.Item1.FirstDataIndex);
						sheet.Cells.CopyRow(sheet.Cells, x2.Item2 + 1, x2.Item1.FirstDataIndex);
						sheet.Cells.DeleteRow(x2.Item2 + 1);
					}
					catch (Exception ex2)
					{
						throw ex2;
					}
				}
			}
			error = new MemoryStream();
			book.Save((Stream)(object)error, options.GetSaveFormat());
			error.Position = 0L;
		}
		else
		{
			error = null;
		}
		return dataCache;
	}

	/// <summary>
	/// 分析模版位置
	/// </summary>
	/// <param name="sheet"></param>
	/// <param name="template"></param>
	/// <returns></returns>
	private AsposeExcelImportTemplate parseTemplate(Worksheet sheet, AsposeExcelImportTemplate template)
	{
		template.FirstRowIndex = (template.StartRow.HasValue ? (template.StartRow.Value - 1) : sheet.Cells.MinRow);
		template.FirstDataIndex = (template.DataRow.HasValue ? (template.DataRow.Value - 1) : (template.FirstRowIndex + 1));
		template.LastRowIndex = (template.EndRow.HasValue ? (template.EndRow.Value - 1) : sheet.Cells.MaxDataRow);
		template.FirstColumnIndex = (template.StartColumn.IsNullOrEmpty() ? sheet.Cells.MinColumn : CellsHelper.ColumnNameToIndex(template.StartColumn));
		template.LastColumnIndex = (template.EndColumn.IsNullOrEmpty() ? sheet.Cells.MaxDataColumn : CellsHelper.ColumnNameToIndex(template.EndColumn));
		if (template.Mode == ImportMode.Table)
		{
			for (int columnIndex = template.FirstColumnIndex; columnIndex <= template.LastColumnIndex; columnIndex++)
			{
				Cell titleCell = sheet.Cells[template.FirstRowIndex, columnIndex];
				if (titleCell.IsMerged)
				{
					titleCell = titleCell.GetMergedRange()[0, 0];
				}
				string title = titleCell.StringValue.Trim().Replace("\r", string.Empty).Replace("\n", string.Empty);
				if (title.Length > 0)
				{
					if (template.ColumnMap.ContainsKey(title))
					{
						throw new InvalidOperationException(Literals.M_E_ImportData_ColumnDuplicate.FormatValue(sheet.Name, title));
					}
					template.ColumnMap.Add(title, CellsHelper.ColumnIndexToName(columnIndex));
				}
			}
		}
		else
		{
			if (template.Mode != ImportMode.Block)
			{
				throw new NotSupportedException();
			}
			foreach (AsposeExcelImportTemplateItem item in template.Items.Values)
			{
				if (template.ColumnMap.ContainsKey(item.Title))
				{
					throw new InvalidOperationException(Literals.M_E_ImportData_ColumnDuplicate.FormatValue(sheet.Name, item.Title));
				}
				if (item.ResolveRef.IsNotNull())
				{
					template.ColumnMap.Add(item.Title, item.ResolveRef);
				}
			}
		}
		return template;
	}

	/// <summary>
	/// 加载导出数据
	/// </summary>
	/// <param name="template"></param>
	/// <param name="options"></param>
	/// <param name="dataList"></param>
	/// <param name="errorCache"></param>
	/// <returns></returns>
	private bool LoadTemplateData(AsposeExcelImportTemplate template, AsposeExcelImportOptions options, List<IDataObject> dataList, List<Tuple<AsposeExcelImportTemplate, int>> errorCache)
	{
		Worksheet sheet = template.Sheet;
		Dictionary<string, string> dataRow = new Dictionary<string, string>();
		foreach (KeyValuePair<string, string> item2 in template.ColumnMap)
		{
			dataRow.Add(item2.Key, string.Empty);
		}
		if (!template.KeyItem.IsNullOrEmpty() && !dataRow.ContainsKey(template.Items[template.KeyItem].Title))
		{
			throw new ConfigurationErrorsException(Literals.M_E_Template_PropertyError.FormatValue(template.Name, "keyItem"));
		}
		IDataObject templateData = null;
		bool templateError = false;
		bool rowError = false;
		for (int rowIndex = template.FirstDataIndex; rowIndex <= template.LastRowIndex; rowIndex++)
		{
			templateData = null;
			rowError = false;
			if (template.Mode == ImportMode.Table)
			{
				foreach (KeyValuePair<string, string> kvp in template.ColumnMap)
				{
					dataRow[kvp.Key] = GetCellStringValue(sheet.Cells[kvp.Value + (rowIndex + 1)]);
				}
			}
			else if (template.Mode == ImportMode.Block)
			{
				foreach (KeyValuePair<string, string> kvp in template.ColumnMap)
				{
					dataRow[kvp.Key] = GetCellStringValue(sheet.Cells[kvp.Value]);
				}
			}
			if (dataRow.Values.All((string x) => x.IsNullOrEmpty()))
			{
				break;
			}
			if (!template.KeyItem.IsNullOrEmpty() && dataRow[template.Items[template.KeyItem].Title].IsNullOrEmpty())
			{
				continue;
			}
			if (options.RecordResolve.IsNotNull())
			{
				template.RecordResolveContext.Reset();
				template.RecordResolveContext.Template = template;
				template.RecordResolveContext.RowIndex = rowIndex;
				template.RecordResolveContext.RawValues = dataRow;
				try
				{
					options.RecordResolve(template.RecordResolveContext);
				}
				catch (Exception ex2)
				{
					throw new RecordResolveException(template.RecordResolveContext, ex2);
				}
				if (template.RecordResolveContext.Resolved)
				{
					if (template.RecordResolveContext.Error)
					{
						if (template.Mode == ImportMode.Table)
						{
							SetErrorMark(sheet, template.Sheet.Cells.CreateRange(rowIndex, template.FirstColumnIndex, 1, template.LastColumnIndex - template.FirstColumnIndex + 1), Literals.M_E_Importing_RecordResolveError.FormatValue(sheet.Name, rowIndex + 1, template.RecordResolveContext.ErrorMessage));
						}
						else if (template.Mode == ImportMode.Block)
						{
							SetErrorMark(sheet, template.Sheet.Cells.CreateRange(template.FirstDataIndex, template.FirstColumnIndex, template.LastRowIndex - template.FirstDataIndex + 1, template.LastColumnIndex - template.FirstColumnIndex + 1), Literals.M_E_Importing_RecordResolveError.FormatValue(sheet.Name, rowIndex + 1, template.RecordResolveContext.ErrorMessage));
						}
						errorCache.Add(Tuple.Create(template, rowIndex));
						rowError = true;
						templateData = null;
					}
					else
					{
						templateData = template.RecordResolveContext.ResultRecord;
					}
					if (!rowError)
					{
						dataList.Add(templateData);
					}
					template.RecordResolveContext.Reset();
					continue;
				}
				template.RecordResolveContext.Reset();
			}
			templateData = template.Type.CreateInstance<IDataObject>();
			foreach (AsposeExcelImportTemplateItem item in template.Items.Values)
			{
				if (LoadTemplateItemData(item, template, options, dataRow, sheet, rowIndex, dataList, errorCache, out var itemData))
				{
					templateData.SetValue(item.Name, itemData);
				}
				else
				{
					rowError = true;
				}
			}
			if (!rowError && options.RecordValidate.IsNotNull())
			{
				template.RecordValidateContext.Reset();
				template.RecordValidateContext.Template = template;
				template.RecordValidateContext.Records = dataList;
				template.RecordValidateContext.Record = templateData;
				template.RecordValidateContext.RowIndex = rowIndex;
				try
				{
					options.RecordValidate(template.RecordValidateContext);
				}
				catch (Exception ex2)
				{
					throw new RecordValidateException(template.RecordValidateContext, ex2);
				}
				if (template.RecordValidateContext.Error)
				{
					if (template.Mode == ImportMode.Table)
					{
						SetErrorMark(template.Sheet, template.Sheet.Cells.CreateRange(rowIndex, template.FirstColumnIndex, 1, template.LastColumnIndex - template.FirstColumnIndex + 1), Literals.M_E_Importing_RecordValidateError.FormatValue(sheet.Name, rowIndex + 1, template.RecordValidateContext.ErrorMessage));
					}
					else if (template.Mode == ImportMode.Block)
					{
						SetErrorMark(template.Sheet, template.Sheet.Cells.CreateRange(template.FirstDataIndex, template.FirstColumnIndex, template.LastRowIndex - template.FirstDataIndex + 1, template.LastColumnIndex - template.FirstColumnIndex + 1), Literals.M_E_Importing_RecordValidateError.FormatValue(sheet.Name, rowIndex + 1, template.RecordValidateContext.ErrorMessage));
					}
					errorCache.Add(Tuple.Create(template, rowIndex));
					rowError = true;
				}
				template.RecordValidateContext.Reset();
			}
			if (rowError)
			{
				templateError = true;
			}
			else
			{
				dataList.Add(templateData);
			}
			if (template.Mode == ImportMode.Block)
			{
				break;
			}
		}
		return templateError;
	}

	/// <summary>
	/// 加载导入项目数据
	/// </summary>
	/// <param name="item"></param>
	/// <param name="template"></param>
	/// <param name="options"></param>
	/// <param name="dataRow"></param>
	/// <param name="sheet"></param>
	/// <param name="rowIndex"></param>
	/// <param name="records"></param>
	/// <param name="errorCache"></param>
	/// <param name="data"></param>
	/// <returns></returns>
	private bool LoadTemplateItemData(AsposeExcelImportTemplateItem item, AsposeExcelImportTemplate template, AsposeExcelImportOptions options, Dictionary<string, string> dataRow, Worksheet sheet, int rowIndex, IList<IDataObject> records, List<Tuple<AsposeExcelImportTemplate, int>> errorCache, out object data)
	{
		data = null;
		if (item.IsSublist)
		{
			data = item.Type.CreateDefault();
			return true;
		}
		Dictionary<string, string> raw = new Dictionary<string, string>();
		string rawData = null;
		int columnIndex = -1;
		if (item.Ignore)
		{
			data = item.Type.CreateDefault();
			return true;
		}
		if (!item.ResolveKey.IsNullOrEmpty())
		{
			string[] keys = item.ResolveKey.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
			string[] array = keys;
			foreach (string key in array)
			{
				if (!template.Items.ContainsKey(key))
				{
					throw new ConfigurationErrorsException(Literals.M_E_TemplateItem_PropertyError.FormatValue(item.Name, item.ResolveKey));
				}
				string keyTitle = template.Items[key].Title;
				if (dataRow.ContainsKey(keyTitle))
				{
					rawData = dataRow[keyTitle];
					columnIndex = CellsHelper.ColumnNameToIndex(template.ColumnMap[keyTitle]);
					if (!raw.ContainsKey(key))
					{
						raw.Add(key, rawData);
					}
					continue;
				}
				throw new ConfigurationErrorsException(Literals.M_E_TemplateItem_PropertyError.FormatValue(item.Name, item.ResolveKey));
			}
		}
		else if (!item.ResolveRef.IsNullOrEmpty())
		{
			Cell cell = sheet.Cells[item.ResolveRef];
			rawData = GetCellStringValue(cell);
			raw.Add(item.Name, rawData);
			rowIndex = cell.Row;
			columnIndex = cell.Column;
		}
		else if (dataRow.ContainsKey(item.Title))
		{
			rawData = dataRow[item.Title];
			columnIndex = CellsHelper.ColumnNameToIndex(template.ColumnMap[item.Title]);
		}
		if (rawData.IsNull() && item.AutoValue != 0)
		{
			switch (item.AutoValue)
			{
			case AutoValueType.Default:
				data = item.Type.CreateDefault();
				break;
			case AutoValueType.Guid:
				data = Guid.NewGuid();
				break;
			case AutoValueType.Count:
				data = rowIndex - template.FirstDataIndex + 1;
				break;
			case AutoValueType.Now:
				data = DateTime.Now;
				break;
			default:
				data = item.Type.CreateDefault();
				break;
			}
		}
		else if (!item.ResolveKey.IsNullOrEmpty() && options.ValueResolve.IsNotNull())
		{
			template.ValueResolveContext.Reset();
			template.ValueResolveContext.Template = template;
			template.ValueResolveContext.RowIndex = rowIndex;
			template.ValueResolveContext.Item = item;
			template.ValueResolveContext.RawValue = rawData;
			foreach (KeyValuePair<string, string> kvp in raw)
			{
				template.ValueResolveContext.RawValues.Add(kvp.Key, kvp.Value);
			}
			try
			{
				options.ValueResolve(template.ValueResolveContext);
			}
			catch (Exception ex2)
			{
				throw new ValueResolveException(template.ValueResolveContext, ex2);
			}
			if (template.ValueResolveContext.Error)
			{
				SetErrorMark(sheet, rowIndex, columnIndex, template.ValueResolveContext.ErrorMessage);
				data = item.Type.CreateInstance();
				errorCache.Add(Tuple.Create(template, rowIndex));
				return false;
			}
			data = template.ValueResolveContext.Result;
			template.ValueResolveContext.Reset();
		}
		else
		{
			if (item.Pattern.IsNotNull() && !item.Pattern.IsMatch(rawData))
			{
				if (!string.IsNullOrEmpty(item.ErrorMessage))
				{
					SetErrorMark(sheet, rowIndex, columnIndex, item.ErrorMessage);
				}
				else
				{
					SetErrorMark(sheet, rowIndex, columnIndex, Literals.M_E_Importing_ValueValidatePatternUnmatch.FormatValue(item.Title, rawData, item.Pattern));
				}
				data = item.Type.CreateInstance();
				errorCache.Add(Tuple.Create(template, rowIndex));
				return false;
			}
			try
			{
				if (item.Type.IsNullable() && rawData.IsNullOrEmpty())
				{
					data = null;
				}
				else
				{
					data = rawData.ConvertTo(item.Type);
				}
			}
			catch
			{
				if (!string.IsNullOrEmpty(item.ErrorMessage))
				{
					SetErrorMark(sheet, rowIndex, columnIndex, item.ErrorMessage);
				}
				else
				{
					SetErrorMark(sheet, rowIndex, columnIndex, Literals.M_E_Importing_ValueConvertError.FormatValue(item.Title, rawData, item.Type.Name));
				}
				data = item.Type.CreateInstance();
				errorCache.Add(Tuple.Create(template, rowIndex));
				return false;
			}
		}
		if (options.ValueValidate.IsNotNull())
		{
			template.ValueValidateContext.Reset();
			template.ValueValidateContext.Template = template;
			template.ValueValidateContext.Records = records;
			template.ValueValidateContext.Item = item;
			template.ValueValidateContext.RowIndex = rowIndex;
			template.ValueValidateContext.Value = data;
			try
			{
				options.ValueValidate(template.ValueValidateContext);
			}
			catch (Exception ex2)
			{
				throw new ValueValidateException(template.ValueValidateContext, ex2);
			}
			if (template.ValueValidateContext.Error)
			{
				SetErrorMark(sheet, rowIndex, columnIndex, template.ValueValidateContext.ErrorMessage);
				template.ValueValidateContext.Reset();
				data = item.Type.CreateDefault();
				errorCache.Add(Tuple.Create(template, rowIndex));
				return false;
			}
			data = template.ValueValidateContext.Value;
		}
		return true;
	}

	/// <summary>
	/// 清除错误标记
	/// </summary>
	/// <param name="template"></param>
	private void ClearErrorMark(AsposeExcelImportTemplate template)
	{
		if (template.FirstDataIndex > template.LastRowIndex)
		{
			return;
		}
		Range range = template.Sheet.Cells.CreateRange(template.FirstDataIndex, template.FirstColumnIndex, template.LastRowIndex - template.FirstDataIndex + 1, template.LastColumnIndex - template.FirstColumnIndex + 1);
		foreach (Cell cell in range)
		{
			Style cellStyle = cell.GetStyle();
			if (cellStyle.IsNotNull())
			{
				cellStyle.ForegroundColor = (Color)Color.Empty;
				cell.SetStyle(cellStyle);
			}
		}
	}

	/// <summary>
	/// 向数据表格添加错误提示信息
	/// </summary>
	/// <param name="sheet"></param>
	/// <param name="rowIndex"></param>
	/// <param name="columnIndex"></param>
	/// <param name="message"></param>
	internal static void SetErrorMark(Worksheet sheet, int rowIndex, int columnIndex, string message)
	{
		if (message.IsNullOrEmpty())
		{
			return;
		}
		Cell cell = sheet.Cells[rowIndex, columnIndex];
		Range mergedRange = cell.GetMergedRange();
		if (mergedRange.IsNotNull())
		{
			SetErrorMark(sheet, mergedRange, message);
			return;
		}
		Style cellStyle = cell.GetStyle();
		if (cellStyle.IsNull())
		{
			cellStyle = sheet.Workbook.CreateStyle();
		}
		cellStyle.ForegroundColor = (Color)Color.Yellow;
		cellStyle.Pattern = BackgroundType.Solid;
		cell.SetStyle(cellStyle);
		Comment comment = sheet.Comments[sheet.Comments.Add(cell.Row, cell.Column)];
		comment.Note = message;
		comment.AutoSize = true;
	}

	/// <summary>
	/// 向数据表格添加错误提示信息
	/// </summary>
	/// <param name="sheet"></param>
	/// <param name="range"></param>
	/// <param name="message"></param>
	internal static void SetErrorMark(Worksheet sheet, Range range, string message)
	{
		if (message.IsNullOrEmpty())
		{
			return;
		}
		foreach (Cell cell in range)
		{
			Style cellStyle = cell.GetStyle();
			if (cellStyle.IsNull())
			{
				cellStyle = sheet.Workbook.CreateStyle();
			}
			cellStyle.ForegroundColor = (Color)Color.Yellow;
			cellStyle.Pattern = BackgroundType.Solid;
			cell.SetStyle(cellStyle);
		}
		Comment comment = sheet.Comments[sheet.Comments.Add(range.FirstRow, range.FirstColumn)];
		comment.Note = message;
		comment.AutoSize = true;
	}

	/// <summary>
	/// 清除错误注释
	/// </summary>
	/// <param name="template"></param>
	private void ClearErrorComment(AsposeExcelImportTemplate template)
	{
		Comment[] array = (from c in ((IEnumerable)template.Sheet.Comments).OfType<Comment>()
			where c.Row >= template.FirstDataIndex && c.Column >= template.FirstColumnIndex
			select c).ToArray();
		foreach (Comment c2 in array)
		{
			template.Sheet.Comments.RemoveAt(CellsHelper.CellIndexToName(c2.Row, c2.Column));
		}
	}

	/// <summary>
	/// 获取单元格的字符串值
	/// </summary>
	/// <param name="cell"></param>
	/// <returns></returns>
	private string GetCellStringValue(Cell cell)
	{
		return cell.Type switch
		{
			CellValueType.IsBool => cell.BoolValue.ToString(), 
			CellValueType.IsDateTime => ((DateTime)cell.DateTimeValue).ToString(), 
			CellValueType.IsError => cell.StringValue, 
			CellValueType.IsNull => string.Empty, 
			CellValueType.IsNumeric => cell.DoubleValue.ToString(), 
			CellValueType.IsString => cell.StringValue, 
			CellValueType.IsUnknown => cell.StringValue, 
			_ => string.Empty, 
		};
	}
}
