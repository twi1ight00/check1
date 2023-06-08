using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using Aspose.Cells;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Base.Application.DTO;
using Richfit.Garnet.Module.Base.Application.Services;
using Richfit.Garnet.Module.BusinessCommon.Application.DTO;

namespace Richfit.Garnet.Module.Exporting.Aspose.Excel;

public class CommonExportcsService : ServiceBase, ICommonExportcsService
{
	/// <summary>
	/// 通用导出EXCEL方法
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="dataGridColumn">列表头</param>
	/// <param name="resultDto">导出的数据</param>
	/// <param name="excelName">excel名字</param>
	/// <param name="strFrontTranslates">前端翻译，格式为项和项之间分号分隔，项里面逗号分隔，如IS_MERGE,0,否;IS_MERGE,1,是</param>
	/// <param name="strSqlTranslate">Sql翻译,格式为项和项之间分号分隔，项里面逗号分隔,如ORG_ID,ORG_NAME;CARD_TYPE,CARD_TYPE_NAME</param>
	/// <returns>Stream流</returns>
	public Stream ExportCommonExcel<T>(string dataGridColumn, List<T> resultDto, string excelName, string strFrontTranslates = "", string strSqlTranslate = "") where T : DTOBase
	{
		IList<CommonExportExcelDTO> gridDto = new List<CommonExportExcelDTO>();
		IList<ExportExcelFrontTranslateDTO> frongTranslateDtoList = new List<ExportExcelFrontTranslateDTO>();
		Dictionary<string, string> dicIdName = new Dictionary<string, string>();
		string[] arrIdNames = strSqlTranslate.Split(';');
		string[] arrFrontTranslate = strFrontTranslates.Split(';');
		string[] array = arrFrontTranslate;
		foreach (string strFrontTranslate in array)
		{
			ExportExcelFrontTranslateDTO frontDto = new ExportExcelFrontTranslateDTO();
			if (!string.IsNullOrEmpty(strFrontTranslate))
			{
				frontDto.FIELD_NAME = strFrontTranslate.Split(',')[0];
				frontDto.ITEM_VALUE = strFrontTranslate.Split(',')[1];
				frontDto.ITEM_NAME = strFrontTranslate.Split(',')[2];
			}
			frongTranslateDtoList.Add(frontDto);
		}
		array = arrIdNames;
		foreach (string strdicIdName in array)
		{
			if (!string.IsNullOrEmpty(strdicIdName))
			{
				dicIdName.Add(strdicIdName.Split(',')[0], strdicIdName.Split(',')[1]);
			}
		}
		if (!string.IsNullOrWhiteSpace(dataGridColumn))
		{
			gridDto = dataGridColumn.JsonDeserializeToList<CommonExportExcelDTO>(new JsonConverter[0]);
		}
		MemoryStream returnStream = null;
		Workbook book = new Workbook();
		Worksheet sheet = book.Worksheets[0];
		sheet.Name = excelName;
		Cells cells = sheet.Cells;
		if (resultDto.Count() > 0)
		{
			DataTable dtResult = new DataTable();
			PropertyInfo[] oProps = null;
			T val = resultDto[0];
			oProps = val.GetType().GetProperties();
			for (int pCount = 0; pCount < oProps.Count(); pCount++)
			{
				Type colType = oProps[pCount].PropertyType;
				if (colType.IsGenericType && colType.GetGenericTypeDefinition() == typeof(Nullable<>))
				{
					colType = colType.GetGenericArguments()[0];
				}
				dtResult.Columns.Add(oProps[pCount].Name, colType);
			}
			foreach (T TDTO in resultDto)
			{
				DataRow dr = dtResult.NewRow();
				PropertyInfo[] array2 = oProps;
				foreach (PropertyInfo pi in array2)
				{
					dr[pi.Name] = ((pi.GetValue(TDTO, null) == null) ? DBNull.Value : pi.GetValue(TDTO, null));
				}
				dtResult.Rows.Add(dr);
			}
			int iC = 0;
			string strReplaceClumn = string.Empty;
			foreach (CommonExportExcelDTO dtoGrid in gridDto)
			{
				string tempValue = "";
				strReplaceClumn = ((!dicIdName.TryGetValue(dtoGrid.DATAINDEX, out tempValue)) ? dtoGrid.DATAINDEX : tempValue);
				dtResult.Columns[strReplaceClumn].SetOrdinal(iC);
				iC++;
			}
			for (int colCount = iC; colCount < oProps.Count(); colCount++)
			{
				dtResult.Columns.RemoveAt(iC);
			}
			sheet.AutoFitRows();
			cells.Merge(0, 0, 1, gridDto.Count() + 1);
			sheet.Cells.SetRowHeight(0, 30.0);
			cells[0, 0].PutValue(excelName);
			sheet.Cells[1, 0].PutValue("序号");
			int yCol = 1;
			foreach (CommonExportExcelDTO dtoGrid in gridDto)
			{
				sheet.Cells.SetRowHeight(1, 25.0);
				sheet.Cells.SetColumnWidth(yCol, dtoGrid.TEXT.Length * 2 + 7);
				sheet.Cells[1, yCol].PutValue(dtoGrid.TEXT);
				yCol++;
			}
			int startRowIndex = 2;
			foreach (DataRow row in dtResult.Rows)
			{
				sheet.Cells[startRowIndex, 0].PutValue(startRowIndex - 1);
				Style style = new Style();
				int iCol;
				for (iCol = 0; iCol <= dtResult.Columns.Count - 1; iCol++)
				{
					ExportExcelFrontTranslateDTO frontTranslateDto = frongTranslateDtoList.SingleOrDefault((ExportExcelFrontTranslateDTO x) => x.FIELD_NAME == dtResult.Columns[iCol].ColumnName && x.ITEM_VALUE == row[iCol].ToString());
					if (frontTranslateDto != null)
					{
						sheet.Cells[startRowIndex, iCol + 1].PutValue(frontTranslateDto.ITEM_NAME);
					}
					else
					{
						sheet.Cells[startRowIndex, iCol + 1].PutValue(row[iCol]);
					}
					style = sheet.Cells[startRowIndex, iCol + 1].GetStyle();
					switch (dtResult.Columns[iCol].DataType.ToString())
					{
					case "System.String":
						style.HorizontalAlignment = TextAlignmentType.Left;
						break;
					case "System.DateTime":
						style.HorizontalAlignment = TextAlignmentType.Center;
						style.Number = 14;
						break;
					case "System.Boolean":
						style.HorizontalAlignment = TextAlignmentType.Left;
						break;
					case "System.Decimal":
						if (frongTranslateDtoList.Where((ExportExcelFrontTranslateDTO x) => x.FIELD_NAME == dtResult.Columns[iCol].ColumnName).Count() > 0)
						{
							style.HorizontalAlignment = TextAlignmentType.Center;
							break;
						}
						style.HorizontalAlignment = TextAlignmentType.Right;
						style.Number = 40;
						break;
					case "System.Int16":
					case "System.Int32":
					case "System.Int64":
					case "System.Byte":
						style.HorizontalAlignment = TextAlignmentType.Center;
						style.Number = 1;
						break;
					case "System.DBNull":
						style.HorizontalAlignment = TextAlignmentType.Left;
						break;
					default:
						style.HorizontalAlignment = TextAlignmentType.Left;
						break;
					}
					sheet.Cells[startRowIndex, iCol + 1].SetStyle(style);
				}
				startRowIndex++;
			}
			Style styleSheetTitle = null;
			int sindex = book.Styles.Add();
			styleSheetTitle = book.Styles[sindex];
			styleSheetTitle.Name = "SheetTitle";
			styleSheetTitle.Font.Size = 20;
			styleSheetTitle.Font.IsBold = true;
			styleSheetTitle.Font.Name = "宋体";
			styleSheetTitle.HorizontalAlignment = TextAlignmentType.Center;
			styleSheetTitle.VerticalAlignment = TextAlignmentType.Center;
			cells[0, 0].SetStyle(styleSheetTitle);
			Style styleFirstLine = null;
			int oIndex = book.Styles.Add();
			styleFirstLine = book.Styles[oIndex];
			styleFirstLine.Name = "SheetFirst";
			styleFirstLine.Font.Size = 14;
			styleFirstLine.Font.IsBold = false;
			styleFirstLine.Font.Name = "宋体";
			styleFirstLine.HorizontalAlignment = TextAlignmentType.Center;
			styleFirstLine.VerticalAlignment = TextAlignmentType.Center;
			styleFirstLine.Pattern = BackgroundType.Solid;
			styleFirstLine.ForegroundColor = (Color)Color.LightGray;
			Range rangeFirst = sheet.Cells.CreateRange(1, 0, 1, gridDto.Count() + 1);
			rangeFirst.SetStyle(styleFirstLine);
			Style GridStyle = book.Styles[book.Styles.Add()];
			GridStyle.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin;
			GridStyle.Borders[BorderType.TopBorder].Color = (Color)Color.Black;
			GridStyle.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin;
			GridStyle.Borders[BorderType.BottomBorder].Color = (Color)Color.Black;
			GridStyle.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
			GridStyle.Borders[BorderType.LeftBorder].Color = (Color)Color.Black;
			GridStyle.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;
			GridStyle.Borders[BorderType.RightBorder].Color = (Color)Color.Black;
			Range range = sheet.Cells.CreateRange(0, 0, resultDto.Count + 2, gridDto.Count() + 1);
			StyleFlag borderStyle = new StyleFlag();
			borderStyle.Borders = true;
			range.ApplyStyle(GridStyle, borderStyle);
		}
		return (Stream)(object)book.SaveToStream();
	}
}
