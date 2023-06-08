using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Web;
using Aspose.Cells;
using Aspose.Cells.Drawing;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Base.HandlerProcess.Models;
using Richfit.Garnet.Module.Base.Infrastructure.ExternalAccess;
using Richfit.Garnet.Module.Base.Infrastructure.Session;
using Richfit.Garnet.Module.ImportingAndExporting.Application.DTO;

namespace Richfit.Garnet.Module.ImportingAndExporting.Application.Services.Export;

public class ExcelService : IExport
{
	private Workbook etbook;

	private Worksheet etsheet;

	private HttpContext context;

	private bool isPdf;

	public ExcelService(HttpContext context)
	{
		this.context = context;
		isPdf = false;
	}

	private void ClearSheet()
	{
		etbook.Worksheets.Clear();
	}

	private void ExportExcel(ExportDTO parameter)
	{
		string filePath = context.Server.MapPath(parameter.TemplatePath);
		bool isHaveTemplate;
		if (isHaveTemplate = File.Exists(filePath))
		{
			etbook = new Workbook(filePath);
			isHaveTemplate = true;
		}
		else
		{
			etbook = new Workbook();
		}
		if (parameter.List != null && parameter.List.Count > 0)
		{
			parameter.List = parameter.List.OrderByDescending((ExportConfig a) => a.StartRow).ToList();
			foreach (ExportConfig exportConfig in parameter.List)
			{
				if (string.IsNullOrEmpty(exportConfig.Sheet))
				{
					exportConfig.Sheet = "Sheet1";
				}
				AddSheet(exportConfig.Sheet);
				if (parameter.IsHtml)
				{
					ExportDataByData(exportConfig, ref etsheet);
				}
				else
				{
					ExportDataByHandler(exportConfig, ref etsheet, isHaveTemplate);
				}
			}
		}
		if (parameter.Label != null && parameter.Label.Data != null && parameter.Label.Data.Count > 0)
		{
			ExportLabel(parameter.Label);
		}
	}

	public string Export(ExportDTO parameter, bool isPdf)
	{
		this.isPdf = isPdf;
		return Export(parameter);
	}

	public string Export(ExportDTO parameter)
	{
		FileInfo fi = new FileInfo(context.Server.MapPath(parameter.TemplatePath));
		ExportExcel(parameter);
		string floder = string.Format("{0}/{1}", fi.DirectoryName, "Temp");
		if (!Directory.Exists(floder))
		{
			Directory.CreateDirectory(floder);
		}
		floder = $"{floder}/{Guid.NewGuid().ToString()}";
		Directory.CreateDirectory(floder);
		string path = $"{floder}/{fi.Name}";
		if (isPdf)
		{
			path = path.Substring(0, path.Length - fi.Extension.Length);
			path += ".pdf";
		}
		etbook.Save(path);
		string root = context.Server.MapPath("/");
		return path.Replace(root, "/").Replace("\\", "/");
	}

	private void NAR(object o)
	{
		try
		{
			Marshal.ReleaseComObject(o);
		}
		catch
		{
		}
		finally
		{
			o = null;
			GC.Collect();
		}
	}

	private void WPSImporting(ResponseData handlerResult)
	{
	}

	public static int ToIndex(string columnName)
	{
		if (!Regex.IsMatch(columnName.ToUpper(), "[A-Z]+"))
		{
			throw new Exception("invalid parameter");
		}
		int index = 0;
		char[] chars = columnName.ToUpper().ToCharArray();
		for (int i = 0; i < chars.Length; i++)
		{
			index += (chars[i] - 65 + 1) * (int)Math.Pow(26.0, chars.Length - i - 1);
		}
		return index - 1;
	}

	private void ExportLabel(LabelInfo label)
	{
		AddSheet(label.Sheet);
		PictureCollection pictures = etsheet.Pictures;
		foreach (LabelDataDTO dto in label.Data)
		{
			string[] xy = dto.Pos.Split(',');
			int rowIndex = Convert.ToInt32(xy[1]) - 1;
			int colIndex = ToIndex(xy[0]);
			Style cellStyle = null;
			if (!string.IsNullOrEmpty(dto.Style))
			{
				string[] style = dto.Style.Split(',');
				cellStyle = etsheet.Cells.GetCellStyle(Convert.ToInt32(style[1]) - 1, ToIndex(style[0]));
			}
			if (dto.Colspan > 1)
			{
				Range rangeLecture = etsheet.Cells.CreateRange(rowIndex, colIndex, 1, dto.Colspan);
				rangeLecture.Merge();
				if (cellStyle != null)
				{
					rangeLecture.SetStyle(cellStyle);
				}
			}
			else if (cellStyle != null)
			{
				etsheet.Cells[Convert.ToInt32(xy[1]) - 1, ToIndex(xy[0])].SetStyle(cellStyle);
			}
			if (dto.DataType == DataType.Image)
			{
				string signaturePath = string.Format("{0}\\{1}.png", context.Server.MapPath("/upload/signature"), dto.Value);
				setImage(pictures, signaturePath, Convert.ToInt32(xy[1]) - 1, ToIndex(xy[0]), dto.Key, dto.Width, dto.Height);
			}
			else
			{
				etsheet.Cells[Convert.ToInt32(xy[1]) - 1, ToIndex(xy[0])].PutValue(dto.Value);
			}
		}
	}

	private void AddSheet(string sheetName)
	{
		bool flag = true;
		foreach (Worksheet item in (CollectionBase)(object)etbook.Worksheets)
		{
			if (item.Name == sheetName)
			{
				flag = false;
				break;
			}
		}
		if (flag)
		{
			etsheet = etbook.Worksheets.Add(sheetName);
		}
		else
		{
			etsheet = etbook.Worksheets[sheetName];
		}
	}

	private void ExportDataByHandler(ExportConfig exportConfig, ref Worksheet etsheet, bool isHaveTemplate)
	{
		int colIndex = exportConfig.StartCol - 1;
		int rowIndex = exportConfig.StartRow - 1;
		DataTable table = new DataTable("Product");
		IList<ColInfo> config = new List<ColInfo>();
		if (isHaveTemplate)
		{
			string strData;
			do
			{
				strData = etsheet.Cells[rowIndex, colIndex].StringValue;
				foreach (ColInfo colInfo in exportConfig.Config)
				{
					if (colInfo.Name == strData)
					{
						DataColumn dataColumn = new DataColumn();
						dataColumn.ColumnName = colInfo.Value;
						DataColumn dc = dataColumn;
						table.Columns.Add(dc);
						colInfo.ColNum = colIndex;
						config.Add(colInfo);
						break;
					}
				}
				colIndex++;
			}
			while (strData != null && strData != "");
		}
		else
		{
			foreach (ColInfo colInfo in exportConfig.Config)
			{
				DataColumn dataColumn2 = new DataColumn();
				dataColumn2.ColumnName = colInfo.Value;
				DataColumn dc = dataColumn2;
				table.Columns.Add(dc);
				colInfo.ColNum = colIndex;
				etsheet.Cells[rowIndex, colInfo.ColNum].PutValue(colInfo.Name);
				config.Add(colInfo);
				colIndex++;
			}
		}
		bool isPage = false;
		string parm = exportConfig.SearchParm;
		try
		{
			if (!string.IsNullOrEmpty(parm))
			{
				Dictionary<string, string> dictionary2 = parm.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
				if (dictionary2.ContainsKey("PageSize"))
				{
					dictionary2["PageSize"] = "65535";
					isPage = true;
				}
				parm = dictionary2.JsonSerialize();
			}
		}
		catch (Exception)
		{
			throw;
		}
		ResponseData result = AccessManager.ServiceAccess("Workflow", exportConfig.ActionCode, parm, SessionContext.UserInfo.Token);
		DataTable tableData = null;
		if (isPage)
		{
			QueryResult dictionary = result.Data.JsonDeserialize<QueryResult>(new JsonConverter[0]);
			tableData = dictionary.List;
		}
		else
		{
			tableData = (DataTable)result.Data.JsonDeserialize(table.GetType());
		}
		rowIndex++;
		colIndex = exportConfig.StartCol - 1;
		if (string.IsNullOrEmpty(exportConfig.GroupBy))
		{
			int rowNum = 0;
			{
				foreach (DataRow obj in tableData.Rows)
				{
					rowNum++;
					foreach (ColInfo colInfo in config)
					{
						SetData(colInfo, obj, rowIndex, colIndex++, rowNum);
					}
					rowIndex++;
					colIndex = exportConfig.StartCol - 1;
				}
				return;
			}
		}
		var query = from t in tableData.AsEnumerable()
			group t by new
			{
				t1 = t.Field<string>(exportConfig.GroupBy)
			} into m
			select (m);
		foreach (var item in query)
		{
			DataRow row0 = item.First();
			if (row0[exportConfig.GroupBy] != null)
			{
				AddSheet(row0[exportConfig.GroupBy].ToString());
			}
			else
			{
				AddSheet("Sheet1");
			}
			colIndex = exportConfig.StartCol - 1;
			rowIndex = exportConfig.StartRow - 1;
			foreach (ColInfo colInfo in config)
			{
				etsheet.Cells[rowIndex, colIndex].PutValue(colInfo.Name);
				colIndex++;
			}
			rowIndex++;
			int rowNum = 0;
			colIndex = exportConfig.StartCol - 1;
			foreach (DataRow dataRow in item)
			{
				rowNum++;
				foreach (ColInfo colInfo in config)
				{
					SetData(colInfo, dataRow, rowIndex, colIndex++, rowNum);
				}
				rowIndex++;
				colIndex = exportConfig.StartCol - 1;
			}
		}
	}

	private void SetData(ColInfo colInfo, DataRow obj, int rowIndex, int colIndex, int rowNum)
	{
		if (colInfo.Name == "SN.")
		{
			etsheet.Cells[rowIndex, colIndex].PutValue(rowNum);
			return;
		}
		if (colInfo.Name == "序号")
		{
			etsheet.Cells[rowIndex, colIndex].PutValue(rowNum);
			return;
		}
		object oValue = obj[colInfo.Value];
		if (colInfo.DataType == DataType.Int || colInfo.DataType == DataType.Decimal)
		{
			Style st = etsheet.Cells[rowIndex, colInfo.ColNum].GetStyle();
			st.Number = 2;
			st.Custom = ((colInfo.Format == "" || colInfo.Format == null) ? "0.0#####" : colInfo.Format);
			etsheet.Cells[rowIndex, colInfo.ColNum].SetStyle(st);
			etsheet.Cells[rowIndex, colInfo.ColNum].PutValue(obj[colInfo.Value]);
		}
		else if (colInfo.DataType == DataType.Datetime && colInfo.Format != null)
		{
			string value = ((obj[colInfo.Value] == DBNull.Value) ? "" : obj[colInfo.Value].ToString());
			DateTime.TryParse(value, out var dt);
			Style stDate = etsheet.Cells[rowIndex, colInfo.ColNum].GetStyle();
			stDate.Number = 14;
			stDate.Custom = ((colInfo.Format == "") ? "yyyy/mm/dd" : colInfo.Format);
			etsheet.Cells[rowIndex, colInfo.ColNum].SetStyle(stDate);
			if (value != "")
			{
				etsheet.Cells[rowIndex, colInfo.ColNum].PutValue((DateTime)dt);
			}
			else
			{
				etsheet.Cells[rowIndex, colInfo.ColNum].PutValue("");
			}
		}
		else
		{
			object o = obj[colInfo.Value];
			string value = ((o == null) ? "" : o.ToString());
			etsheet.Cells[rowIndex, colInfo.ColNum].PutValue(value);
		}
	}

	private bool Intersect(int[] region, int[] current)
	{
		return current[0] >= region[0] && current[0] <= region[2] && current[1] >= region[1] && current[1] <= region[3];
	}

	private void setImage(PictureCollection pictures, string path, int rowIndex, int colIndex, string name = "", int width = 150, int height = 50)
	{
		if (!File.Exists(path))
		{
			GenerateImage(path, name);
		}
		Image img = new Bitmap(Image.FromFile(path), width, height);
		MemoryStream ms = new MemoryStream();
		img.Save(ms, ImageFormat.Bmp);
		Cell cell = etsheet.Cells[rowIndex, colIndex];
		int flag = pictures.Add(rowIndex, colIndex, (Stream)(object)ms);
		Picture picture = pictures[flag];
		picture.Placement = PlacementType.Move;
		picture.Left = 7;
		picture.Top = 7;
	}

	private void GenerateImage(string path, string name)
	{
		Bitmap bmp = new Bitmap(215, 66);
		Graphics g = Graphics.FromImage(bmp);
		System.Drawing.Font font = new System.Drawing.Font(new FontFamily("华文行楷"), 40f);
		SizeF size = g.MeasureString(name, font);
		g.FillRectangle(Brushes.White, new Rectangle
		{
			X = 0,
			Y = 0,
			Height = 66,
			Width = 215
		});
		g.DrawString(name, font, Brushes.Black, new PointF
		{
			X = (215f - size.Width) / 2f,
			Y = (66f - size.Height) / 2f
		});
		bmp.Save(path);
	}

	private void ExportDataByData(ExportConfig exportConfig, ref Worksheet etsheet)
	{
		int colIndex = exportConfig.StartCol - 1;
		int rowIndex = exportConfig.StartRow - 1;
		int rowNum = exportConfig.Config[0].RowNum;
		if (exportConfig.IsInsert && exportConfig.Data != null && exportConfig.Data.Count > 1)
		{
			Range templateRange = etsheet.Cells.CreateRange(exportConfig.StartRow + 1, colIndex, 1, 256);
			for (int i = 0; i < exportConfig.Data.Count - 1; i++)
			{
				etsheet.Cells.InsertRows(exportConfig.StartRow, 1);
				Range newRange = etsheet.Cells.CreateRange(exportConfig.StartRow + 1, colIndex, 1, 256);
				newRange.Copy(templateRange);
			}
		}
		PictureCollection pictures = etsheet.Pictures;
		IList<int[]> ranges = new List<int[]>();
		if (exportConfig.PrintTitle)
		{
			Style cellStyle = null;
			if (!string.IsNullOrEmpty(exportConfig.TitleStyle))
			{
				string[] style = exportConfig.TitleStyle.Split(',');
				cellStyle = etsheet.Cells.GetCellStyle(Convert.ToInt32(style[1]) - 1, ToIndex(style[0]));
			}
			foreach (ColInfo colInfo in exportConfig.Config)
			{
				if (colInfo.RowNum > rowNum)
				{
					rowNum = colInfo.RowNum;
					colIndex = exportConfig.StartCol - 1;
					rowIndex++;
				}
				Style cellStyleCol = null;
				if (!string.IsNullOrEmpty(colInfo.Style))
				{
					string[] style = exportConfig.TitleStyle.Split(',');
					cellStyleCol = etsheet.Cells.GetCellStyle(Convert.ToInt32(style[1]) - 1, ToIndex(style[0]));
				}
				Style myStyle = ((cellStyleCol == null) ? cellStyle : cellStyleCol);
				foreach (int[] range in ranges)
				{
					if (Intersect(range, new int[2] { rowIndex, colIndex }))
					{
						colIndex++;
					}
				}
				if (colInfo.RowSpan > 0 || colInfo.ColSpan > 0)
				{
					colInfo.ColNum = colIndex;
					Range rangeLecture = etsheet.Cells.CreateRange(rowIndex, colIndex, colInfo.RowSpan + 1, colInfo.ColSpan + 1);
					rangeLecture.Merge();
					ranges.Add(new int[4]
					{
						rowIndex,
						colIndex,
						rowIndex + colInfo.RowSpan,
						colIndex + colInfo.ColSpan
					});
					switch (colInfo.DataType)
					{
					case DataType.String:
						rangeLecture.PutValue(colInfo.Name, isConverted: false, setStyle: false);
						break;
					case DataType.Image:
					{
						string path = context.Server.MapPath(colInfo.Value);
						setImage(pictures, context.Server.MapPath(colInfo.Value), rowIndex, colIndex);
						break;
					}
					}
					if (myStyle != null)
					{
						rangeLecture.SetStyle(myStyle);
					}
					colIndex += colInfo.ColSpan;
					continue;
				}
				colInfo.ColNum = colIndex;
				switch (colInfo.DataType)
				{
				case DataType.String:
					etsheet.Cells[rowIndex, colInfo.ColNum].PutValue(colInfo.Name);
					if (myStyle != null)
					{
						etsheet.Cells[rowIndex, colInfo.ColNum].SetStyle(myStyle);
					}
					break;
				case DataType.Image:
				{
					string path = context.Server.MapPath(colInfo.Value);
					setImage(pictures, context.Server.MapPath(colInfo.Value), rowIndex, colIndex);
					break;
				}
				}
				colIndex++;
			}
			rowIndex++;
			colIndex = exportConfig.StartCol - 1;
		}
		ranges = new List<int[]>();
		Style myStyle2 = null;
		if (!string.IsNullOrEmpty(exportConfig.ContentStyle))
		{
			string[] pos = exportConfig.ContentStyle.Split(',');
			myStyle2 = etsheet.Cells.GetCellStyle(Convert.ToInt32(pos[1]) - 1, ToIndex(pos[0]));
		}
		foreach (List<ColInfo> item in exportConfig.Data)
		{
			foreach (ColInfo colInfo in item)
			{
				Style colStyle = null;
				if (!string.IsNullOrEmpty(colInfo.Style))
				{
					string[] pos2 = colInfo.Style.Split(',');
					colStyle = etsheet.Cells.GetCellStyle(Convert.ToInt32(pos2[1]) - 1, ToIndex(pos2[0]));
				}
				else
				{
					colStyle = myStyle2;
				}
				_ = colInfo.DataType;
				bool flag = 0 == 0;
				foreach (int[] range in ranges)
				{
					if (Intersect(range, new int[2] { rowIndex, colIndex }))
					{
						colIndex++;
					}
				}
				if (colInfo.RowSpan > 0 || colInfo.ColSpan > 0)
				{
					colInfo.ColNum = colIndex;
					Range rangeLecture = etsheet.Cells.CreateRange(rowIndex, colIndex, colInfo.RowSpan + 1, colInfo.ColSpan + 1);
					rangeLecture.Merge();
					ranges.Add(new int[4]
					{
						rowIndex,
						colIndex,
						rowIndex + colInfo.RowSpan,
						colIndex + colInfo.ColSpan
					});
					if (colStyle != null)
					{
						rangeLecture.SetStyle(colStyle);
					}
					switch (colInfo.DataType)
					{
					case DataType.String:
						rangeLecture.PutValue(colInfo.Value, isConverted: false, setStyle: false);
						break;
					case DataType.Image:
					{
						string path = context.Server.MapPath(colInfo.Value);
						setImage(pictures, context.Server.MapPath(colInfo.Value), rowIndex, colIndex);
						break;
					}
					}
					colIndex += colInfo.ColSpan;
				}
				else
				{
					colInfo.ColNum = colIndex;
					if (colStyle != null)
					{
						etsheet.Cells[rowIndex, colInfo.ColNum].SetStyle(colStyle);
					}
					switch (colInfo.DataType)
					{
					case DataType.String:
						etsheet.Cells[rowIndex, colInfo.ColNum].PutValue(colInfo.Value);
						break;
					case DataType.Image:
						setImage(pictures, context.Server.MapPath(colInfo.Value), rowIndex, colIndex);
						break;
					}
					colIndex++;
				}
			}
			rowIndex++;
			colIndex = exportConfig.StartCol - 1;
		}
	}

	private string SaveFile(string basePath, Workbook etbook)
	{
		FileInfo fi = new FileInfo(context.Server.MapPath(basePath));
		string floder = string.Format("{0}/{1}", fi.DirectoryName, "Temp");
		if (!Directory.Exists(floder))
		{
			Directory.CreateDirectory(floder);
		}
		floder = $"{floder}/{Guid.NewGuid().ToString()}";
		Directory.CreateDirectory(floder);
		string path = $"{floder}/{fi.Name}";
		etbook.Save(path);
		return "/Template/Export" + path.Replace(fi.DirectoryName, "");
	}
}
