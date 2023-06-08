namespace Richfit.Garnet.Module.ImportingAndExporting.Application.DTO;

public class ImportConfig
{
	private string name;

	private string dbName;

	private int validate;

	private DataType dataType;

	public string Name
	{
		get
		{
			return name;
		}
		set
		{
			name = value;
		}
	}

	public string DbName
	{
		get
		{
			return dbName;
		}
		set
		{
			dbName = value;
		}
	}

	public int Validate
	{
		get
		{
			return validate;
		}
		set
		{
			validate = value;
		}
	}

	public DataType DataType
	{
		get
		{
			return dataType;
		}
		set
		{
			dataType = value;
		}
	}
}
