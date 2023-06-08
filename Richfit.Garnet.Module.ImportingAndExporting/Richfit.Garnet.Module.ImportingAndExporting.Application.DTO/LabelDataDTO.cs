namespace Richfit.Garnet.Module.ImportingAndExporting.Application.DTO;

public class LabelDataDTO
{
	public string Style { get; set; }

	public int Colspan { get; set; }

	public DataType DataType { get; set; }

	public string Key { get; set; }

	public string Pos { get; set; }

	public string Value { get; set; }

	public int Width { get; set; }

	public int Height { get; set; }

	public LabelDataDTO()
	{
		Colspan = 1;
	}
}
