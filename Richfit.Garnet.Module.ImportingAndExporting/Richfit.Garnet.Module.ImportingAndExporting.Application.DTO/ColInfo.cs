namespace Richfit.Garnet.Module.ImportingAndExporting.Application.DTO;

public class ColInfo
{
	private int rowSpan;

	private int colSpan;

	public string Style { get; set; }

	public int ColNum { get; set; }

	public string Name { get; set; }

	public string Value { get; set; }

	public DataType DataType { get; set; }

	public string Format { get; set; }

	public int ColSpan
	{
		get
		{
			if (colSpan > 0)
			{
				return colSpan - 1;
			}
			return colSpan;
		}
		set
		{
			colSpan = value;
		}
	}

	public int RowSpan
	{
		get
		{
			if (rowSpan > 0)
			{
				return rowSpan - 1;
			}
			return rowSpan;
		}
		set
		{
			rowSpan = value;
		}
	}

	public int RowNum { get; set; }

	public ColInfo()
	{
		RowNum = 0;
	}
}
