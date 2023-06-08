using System.Collections.Generic;
using System.Data;

namespace Richfit.Garnet.Module.ImportingAndExporting.Application.DTO;

public class ExportConfig
{
	private bool printTitle;

	public int RemoveFirstRow { get; set; }

	public bool PrintTitle
	{
		get
		{
			return printTitle;
		}
		set
		{
			printTitle = value;
		}
	}

	public bool IsInsert { get; set; }

	public bool IsHtml { get; set; }

	public string Html { get; set; }

	public string TitleStyle { get; set; }

	public string ContentStyle { get; set; }

	public string GroupBy { get; set; }

	public string SearchParm { get; set; }

	public string ActionCode { get; set; }

	public string Sheet { get; set; }

	public int StartRow { get; set; }

	public int StartCol { get; set; }

	public List<ColInfo> Config { get; set; }

	public List<List<ColInfo>> Data { get; set; }

	public DataTable DataTable { get; set; }

	public double SIZE { get; set; }

	public double LineSpacing { get; set; }

	public ExportConfig()
	{
		SIZE = 12.0;
		LineSpacing = 8.0;
		RemoveFirstRow = 0;
		printTitle = true;
	}
}
