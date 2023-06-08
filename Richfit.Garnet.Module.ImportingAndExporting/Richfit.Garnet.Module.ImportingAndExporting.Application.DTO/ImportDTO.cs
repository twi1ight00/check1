using System.Collections.Generic;

namespace Richfit.Garnet.Module.ImportingAndExporting.Application.DTO;

public class ImportDTO
{
	private string workSheet;

	private string code;

	private int startRow;

	private int startCol;

	private List<ImportConfig> importConfigs;

	public string WorkSheet
	{
		get
		{
			return workSheet;
		}
		set
		{
			workSheet = value;
		}
	}

	public string Code
	{
		get
		{
			return code;
		}
		set
		{
			code = value;
		}
	}

	public int StartRow
	{
		get
		{
			return startRow;
		}
		set
		{
			startRow = value;
		}
	}

	public int StartCol
	{
		get
		{
			return startCol;
		}
		set
		{
			startCol = value;
		}
	}

	public List<ImportConfig> ImportConfigs
	{
		get
		{
			return importConfigs;
		}
		set
		{
			importConfigs = value;
		}
	}

	public string FilePath { get; set; }

	public string FileName { get; set; }
}
