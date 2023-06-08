using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using Aspose.Words;
using Aspose.Words.Tables;
using Richfit.Garnet.Module.ImportingAndExporting.Application.DTO;
using Richfit.Garnet.Module.Workflow.Application.DTO;
using Richfit.Garnet.Module.Workflow.Application.Enums;

namespace Richfit.Garnet.Module.ImportingAndExporting.Application.Services.Export;

public class WordService : IExport
{
	private HttpContext context;

	private bool isPdf;

	public WordService(HttpContext context)
	{
		this.context = context;
		isPdf = false;
	}

	private Document ExportWord(ExportDTO parameter)
	{
		if (!parameter.HistoryDirection.HasValue)
		{
			parameter.HistoryDirection = 0;
		}
		string filePath = context.Server.MapPath(parameter.TemplatePath);
		Document doc = new Document(filePath);
		if (parameter.Label != null && parameter.Label.Data.Any())
		{
			string[] keys = new string[parameter.Label.Data.Count];
			string[] values = new string[parameter.Label.Data.Count];
			string root = context.Server.MapPath("/upload/signature");
			for (int i = 0; i < parameter.Label.Data.Count; i++)
			{
				LabelDataDTO labelData = parameter.Label.Data[i];
				keys[i] = labelData.Key;
				if (labelData.DataType == DataType.Image)
				{
					values[i] = string.Format("{0}\\{1}.png", root, labelData.Value ?? "blank");
					if (!File.Exists(values[i]))
					{
						values[i] = $"{root}\\blank.png";
					}
				}
				else
				{
					values[i] = labelData.Value;
				}
			}
			doc.MailMerge.Execute(keys, values);
		}
		if (parameter.List != null && parameter.List.Any())
		{
			DataSet ds = new DataSet();
			string root = context.Server.MapPath("/upload/signature");
			foreach (ExportConfig exportConfig in parameter.List)
			{
				if (exportConfig.Sheet.ToUpper().IndexOf("AUTO") > -1)
				{
					ExportTableAuto(exportConfig, doc);
					continue;
				}
				DataTable dt = new DataTable();
				dt.TableName = exportConfig.Sheet;
				dt.Merge(exportConfig.DataTable);
				if (exportConfig.RemoveFirstRow == 1)
				{
					dt.Rows.RemoveAt(0);
				}
				if (ds.Tables.Contains(dt.TableName))
				{
					ds.Tables[dt.TableName].Merge(dt);
				}
				else
				{
					ds.Tables.Add(dt);
				}
			}
			doc.MailMerge.ExecuteWithRegions((DataSet)(object)ds);
		}
		if (parameter.History != null && parameter.History.Count > 0)
		{
			int? historyDirection = parameter.HistoryDirection;
			if (historyDirection.GetValueOrDefault() == 0 && historyDirection.HasValue)
			{
				ExportHistoryV(parameter, doc);
			}
			else
			{
				ExportHistoryH(parameter, doc);
			}
		}
		return doc;
	}

	private void SetColor(DocumentBuilder builder, BorderType borderType, Color color)
	{
		Border border = builder.CellFormat.Borders[borderType];
		border.Color = (Color)color;
	}

	private void ExportTableAuto(ExportConfig parameter, Document doc)
	{
		DocumentBuilder builder = new DocumentBuilder(doc);
		builder.MoveToBookmark(parameter.Sheet);
		builder.Write("\r\n");
		if (parameter.IsHtml)
		{
			builder.InsertHtml(parameter.Html);
			return;
		}
		Table table = builder.StartTable();
		Aspose.Words.Font font = builder.Font;
		builder.ParagraphFormat.LineSpacing = parameter.LineSpacing;
		font.Bold = true;
		font.Size = parameter.SIZE;
		foreach (ColInfo item in parameter.Config)
		{
			Cell cell = builder.InsertCell();
			builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
			builder.Write(item.Value);
		}
		builder.EndRow();
		font.Bold = false;
		builder.ParagraphFormat.Alignment = ParagraphAlignment.Left;
		foreach (DataRow rows in parameter.DataTable.Rows)
		{
			foreach (ColInfo item in parameter.Config)
			{
				builder.InsertCell();
				builder.Write(rows[item.Name].ToString());
			}
			builder.EndRow();
		}
		builder.EndTable();
	}

	private void ExportHistoryH(ExportDTO parameter, Document doc)
	{
		DocumentBuilder builder = new DocumentBuilder(doc);
		builder.MoveToBookmark("History");
		int i = 0;
		foreach (WF_WORKITEMDTO item in parameter.History)
		{
			builder.InsertCell();
			builder.CellFormat.Borders.LineStyle = LineStyle.None;
			if (i != 0)
			{
				builder.CellFormat.Borders[BorderType.Left].LineStyle = LineStyle.Single;
				builder.CellFormat.Borders[BorderType.Left].Color = (Color)Color.Black;
			}
			i++;
			builder.StartTable();
			builder.InsertCell();
			builder.CellFormat.Borders.LineStyle = LineStyle.None;
			Aspose.Words.Font font = builder.Font;
			font.Bold = true;
			font.Size = 12.0;
			builder.Write(item.WORKITEM_NAME);
			builder.EndRow();
			font.Size = 10.0;
			font.Bold = false;
			if (item.WF_WORKITEM_HANDLER.Count > 0)
			{
				int flag = 0;
				foreach (WF_WORKITEM_HANDLERDTO handler in item.WF_WORKITEM_HANDLER)
				{
					builder.InsertCell();
					builder.Write(handler.HANDLE_USER_NAME);
					builder.EndRow();
					builder.InsertCell();
					builder.Write(handler.HANDLE_TIME.Value.ToString("yyyy-MM-dd HH:mm"));
					builder.EndRow();
				}
			}
			builder.EndTable();
		}
	}

	private void ExportHistoryV(ExportDTO parameter, Document doc)
	{
		DocumentBuilder builder = new DocumentBuilder(doc);
		builder.MoveToDocumentEnd();
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add("NO", "序号");
		dictionary.Add("WORKITEM_NAME", "处理事项");
		dictionary.Add("HANDLE_USER_NAME", "审批人");
		dictionary.Add("HANDLE_SUGGESTION", "意见");
		dictionary.Add("HANDLE_RESULT", "审批操作");
		dictionary.Add("HANDLE_TIME", "处理时间");
		Dictionary<string, string> configs = dictionary;
		int index = 0;
		Table table = builder.StartTable();
		Aspose.Words.Font font = builder.Font;
		font.Bold = true;
		foreach (KeyValuePair<string, string> config in configs)
		{
			builder.InsertCell();
			builder.Write(config.Value);
		}
		builder.EndRow();
		font.Bold = false;
		foreach (WF_WORKITEMDTO item in parameter.History)
		{
			bool isMerge = item.WF_WORKITEM_HANDLER.Count > 1;
			if (item.WF_WORKITEM_HANDLER[0].HANDLE_USER_NAME == null)
			{
				continue;
			}
			builder.InsertCell();
			if (isMerge)
			{
				builder.CellFormat.VerticalMerge = CellMerge.First;
			}
			int num = ++index;
			builder.Write(num.ToString());
			builder.InsertCell();
			if (isMerge)
			{
				builder.CellFormat.VerticalMerge = CellMerge.First;
			}
			builder.Write(item.WORKITEM_NAME);
			if (isMerge)
			{
				builder.CellFormat.VerticalMerge = CellMerge.First;
			}
			if (item.WF_WORKITEM_HANDLER.Count <= 0)
			{
				continue;
			}
			int flag = 0;
			foreach (WF_WORKITEM_HANDLERDTO handler in item.WF_WORKITEM_HANDLER)
			{
				if (flag != 0)
				{
					builder.InsertCell();
					builder.CellFormat.Borders.LineStyle = LineStyle.Single;
					builder.CellFormat.Borders.Color = (Color)Color.Black;
					builder.CellFormat.VerticalMerge = CellMerge.Previous;
					builder.InsertCell();
					builder.CellFormat.Borders.LineStyle = LineStyle.Single;
					builder.CellFormat.Borders.Color = (Color)Color.Black;
					builder.CellFormat.VerticalMerge = CellMerge.Previous;
				}
				flag++;
				builder.InsertCell();
				builder.CellFormat.VerticalMerge = CellMerge.None;
				builder.Write(handler.HANDLE_USER_NAME);
				builder.InsertCell();
				builder.CellFormat.VerticalMerge = CellMerge.None;
				builder.Write(string.IsNullOrEmpty(handler.HANDLE_SUGGESTION) ? "" : handler.HANDLE_SUGGESTION);
				builder.InsertCell();
				builder.CellFormat.VerticalMerge = CellMerge.None;
				builder.Write(GetHandlerResult(handler.HANDLE_RESULT));
				builder.InsertCell();
				builder.CellFormat.VerticalMerge = CellMerge.None;
				builder.Write(handler.HANDLE_TIME.Value.ToString("yyyy-MM-dd HH:mm"));
				builder.EndRow();
			}
		}
		builder.EndTable();
		table.AutoFit(AutoFitBehavior.AutoFitToWindow);
	}

	private string GetHandlerResult(decimal? handleResult)
	{
		HANDLE_RESULT result = (HANDLE_RESULT)Convert.ToInt32(handleResult);
		Type t = result.GetType();
		object[] objAttrs = t.GetField(result.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), inherit: true);
		if (objAttrs != null && objAttrs.Length > 0)
		{
			DescriptionAttribute descAttr = objAttrs[0] as DescriptionAttribute;
			return descAttr.Description;
		}
		return "";
	}

	public string Export(ExportDTO parameter, bool isPdf)
	{
		this.isPdf = isPdf;
		return Export(parameter);
	}

	public string Export(ExportDTO parameter)
	{
		ReaderWriterLock rwLock = new ReaderWriterLock();
		rwLock.AcquireReaderLock(-1);
		try
		{
			FileInfo fi = new FileInfo(context.Server.MapPath(parameter.TemplatePath));
			string floder = string.Format("{0}/{1}", fi.DirectoryName, "Temp");
			if (!Directory.Exists(floder))
			{
				Directory.CreateDirectory(floder);
			}
			floder = $"{floder}/{Guid.NewGuid().ToString()}";
			Directory.CreateDirectory(floder);
			string path = $"{floder}/{(string.IsNullOrEmpty(parameter.FileName) ? fi.Name : parameter.FileName)}";
			if (isPdf)
			{
				path = path.Substring(0, path.Length - fi.Extension.Length);
				path += ".pdf";
			}
			ExportWord(parameter).Save(path);
			string root = context.Server.MapPath("/");
			return path.Replace(root, "/").Replace("\\", "/");
		}
		catch (Exception ex)
		{
			throw ex;
		}
		finally
		{
			rwLock.ReleaseReaderLock();
		}
	}
}
