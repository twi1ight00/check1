using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Web;
using Aspose.Cells;
using Microsoft.JScript;
using Richfit.Garnet.Common.AOP.Handler;
using Richfit.Garnet.Module.ImportingAndExporting.Application.DTO;

namespace Richfit.Garnet.Module.ImportingAndExporting.Application.Services.Import;

public class ImportService
{
	private ImportDTO importDto;

	private IImportService importService;

	private Workbook wb;

	private Worksheet sheet;

	private bool validateResult;

	private int time;

	private ImportResult importResult;

	public ImportService(ImportDTO importDto)
	{
		this.importDto = importDto;
		Type t = Type.GetType(importDto.Code);
		importService = (IImportService)Activator.CreateInstance(t);
		validateResult = true;
		time = 0;
		importResult = new ImportResult
		{
			Result = true
		};
	}

	public ImportResult Import(string filePath)
	{
		try
		{
			FileInfo fi = new FileInfo(filePath);
			string dir = fi.DirectoryName + "/" + Guid.NewGuid().ToString() + "/";
			Directory.CreateDirectory(dir);
			string newStr = dir + GlobalObject.unescape(importDto.FileName).Replace("/", "\\");
			fi.MoveTo(Path.Combine(newStr));
			sheet = Unprotect(newStr, importDto.WorkSheet, "");
			DataTable dt = GetExcelData(sheet);
			IList result = ValidateData(dt);
			importResult.List = result;
			importResult.Path = newStr;
			if (validateResult)
			{
				return importService.Save(result, ref importResult);
			}
			wb.Save(newStr);
			importResult.Path = "/" + newStr.Replace(HttpContext.Current.Server.MapPath("/"), "").Replace("\\", "/");
			importResult.Result = false;
			return importResult;
		}
		catch (Exception ex)
		{
			time++;
			if (time < 3)
			{
				Thread.Sleep(1000);
				return Import(filePath);
			}
			throw new CustomCodeException(ex.Message);
		}
	}

	private IList ValidateData(DataTable dt)
	{
		Type t = importService.GetDTOTpe();
		Type genericType = typeof(List<>);
		Type[] templateTypeSet = new Type[1] { t };
		Type implementType = genericType.MakeGenericType(templateTypeSet);
		IList result = (IList)Activator.CreateInstance(implementType);
		if (dt.Rows.Count > 0)
		{
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				result.Add(Activator.CreateInstance(t));
			}
			for (int i = 0; i < dt.Columns.Count; i++)
			{
				string colName = dt.Columns[i].ColumnName;
				PropertyInfo pi = t.GetProperty(colName);
				if (!(pi != null))
				{
					continue;
				}
				IEnumerable<ImportConfig> query = importDto.ImportConfigs.Where((ImportConfig a) => a.DbName == colName);
				ImportConfig config;
				if (query != null && query.Count() > 0)
				{
					config = query.ToList()[0];
				}
				else
				{
					ImportConfig importConfig = new ImportConfig();
					importConfig.DbName = colName;
					importConfig.DataType = DataType.String;
					importConfig.Name = colName;
					importConfig.Validate = 0;
					config = importConfig;
				}
				string dataType = t.GetProperty(colName).PropertyType.FullName.ToLower();
				if (dataType.IndexOf("datetime") > -1)
				{
					config.DataType = DataType.Datetime;
				}
				else if (dataType.IndexOf("decimal") > -1)
				{
					if (config.DataType != DataType.Int)
					{
						config.DataType = DataType.Decimal;
					}
				}
				else
				{
					config.DataType = DataType.String;
				}
				int flag = -1;
				foreach (DataRow dr in dt.Rows)
				{
					try
					{
						string value = dr[colName].ToString();
						flag++;
						try
						{
							if (config.Validate == 0)
							{
								switch (config.DataType)
								{
								case DataType.String:
									pi.SetValue(result[flag], value, null);
									break;
								case DataType.Datetime:
								{
									if (DateTime.TryParse(value, out var dateTime))
									{
										pi.SetValue(result[flag], dateTime, null);
										RecordMessage(flag: true, flag, i, "");
									}
									else
									{
										RecordMessage(flag: false, flag, i, "无法转换为日期类型");
									}
									break;
								}
								case DataType.Decimal:
								{
									if (decimal.TryParse(value, out var dec))
									{
										pi.SetValue(result[flag], dec, null);
										RecordMessage(flag: true, flag, i, "");
									}
									else
									{
										RecordMessage(flag: false, flag, i, "无法转换为数字类型");
									}
									break;
								}
								case DataType.Int:
									break;
								}
							}
							else
							{
								ValidateInfo validateInfo = new ValidateInfo();
								validateInfo.Message = "";
								validateInfo.Result = true;
								ValidateInfo validate = validateInfo;
								object o = importService.Validate(dr, colName, value, ref validate);
								if (validate.Result)
								{
									pi.SetValue(result[flag], o, null);
								}
								else
								{
									RecordMessage(flag: false, flag, i, validate.Message);
								}
							}
						}
						catch (Exception ex)
						{
							RecordMessage(flag: false, flag, i, ex.Message);
						}
					}
					catch (Exception)
					{
						throw;
					}
				}
			}
		}
		return result;
	}

	private DataTable GetExcelData(Worksheet sheet)
	{
		DataSet data = new DataSet();
		DataSet ds = new DataSet();
		try
		{
			object oFirstColName = "序号";
			DataTable dtResult = new DataTable();
			int maxColumnIndex = getExcelSheetUsedMaxColumnIndex(sheet);
			int maxRowIndex = getExcelSheetUsedMaxRowIndex(sheet, maxColumnIndex);
			DataTable dt = (DataTable)(object)sheet.Cells.ExportDataTable(importDto.StartRow, importDto.StartCol, maxRowIndex + 1 - importDto.StartRow, maxColumnIndex + 1 - importDto.StartCol, exportColumnName: false);
			DataRow dr = dt.Rows[0];
			int i;
			for (i = 0; i < dt.Columns.Count; i++)
			{
				IEnumerable<ImportConfig> query = importDto.ImportConfigs.Where((ImportConfig a) => a.Name == dr[i].ToString());
				if (query != null && query.Any())
				{
					dt.Columns[i].ColumnName = query.ToList()[0].DbName;
				}
			}
			dt.Rows.Remove(dr);
			return dt;
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	private int getExcelSheetUsedMaxRowIndex(Worksheet sheet, int maxColumnIndex)
	{
		int rowIndex = importDto.StartRow + 1;
		int columnIndex = importDto.StartCol;
		bool flag = false;
		while (true)
		{
			bool flag2 = true;
			flag = true;
			for (; columnIndex <= maxColumnIndex; columnIndex++)
			{
				if (sheet.Cells[rowIndex, columnIndex].StringValue.Trim().Length > 0)
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				break;
			}
			rowIndex++;
		}
		return --rowIndex;
	}

	private int getExcelSheetUsedMaxColumnIndex(Worksheet sheet)
	{
		int columnIndex = importDto.StartCol;
		while (sheet.Cells[importDto.StartRow, columnIndex++].StringValue.Trim().Length > 0)
		{
		}
		return (columnIndex > 0) ? (columnIndex - 2) : 0;
	}

	public Worksheet Unprotect(string path, string sheetname, string sPassword)
	{
		LoadFormat type = LoadFormat.Excel97To2003;
		if (path.ToLower().Contains("xlsx"))
		{
			type = LoadFormat.Xlsx;
		}
		wb = new Workbook(path, new LoadOptions(type));
		Worksheet sheet = wb.Worksheets[sheetname];
		if (sheet == null)
		{
			sheet = wb.Worksheets[0];
		}
		try
		{
			wb.Unprotect(sPassword);
			sheet.Unprotect(sPassword);
		}
		catch (Exception)
		{
		}
		return sheet;
	}

	private void RecordMessage(bool flag, int rowNum, int colNum, string erroeMessage)
	{
		if (flag)
		{
			UnSetErrorMsg(sheet, importDto.StartRow + rowNum + 1, importDto.StartCol + colNum);
			return;
		}
		validateResult = false;
		SetErrorMsg(sheet, importDto.StartRow + rowNum + 1, importDto.StartCol + colNum, erroeMessage);
	}

	private void UnSetErrorMsg(Worksheet sheet, int rownum, int colnum)
	{
		Comment comment = sheet.Comments[rownum, colnum];
		for (int i = ((CollectionBase)(object)sheet.Comments).Count; i > 0; i--)
		{
			if (comment == sheet.Comments[i - 1])
			{
				((CollectionBase)(object)sheet.Comments).RemoveAt(i - 1);
			}
		}
		Style style = new Style();
		style.Pattern = BackgroundType.None;
		sheet.Cells[rownum, colnum].SetStyle(style);
	}

	private void SetErrorMsg(Worksheet sheet, int rownum, int colnum, string tsMsg)
	{
		Style style = new Style();
		style.Pattern = BackgroundType.Solid;
		style.ForegroundColor = (Color)Color.Yellow;
		style.BackgroundColor = (Color)Color.Yellow;
		sheet.Cells[rownum, colnum].SetStyle(style);
		Comment comment = sheet.Comments[rownum, colnum];
		if (comment == null)
		{
			int commentIndex = sheet.Comments.Add(rownum, byte.Parse(colnum.ToString()));
			comment = sheet.Comments[commentIndex];
		}
		comment.Note = tsMsg;
		comment.Font.IsBold = false;
		comment.Font.Size = 11;
	}
}
