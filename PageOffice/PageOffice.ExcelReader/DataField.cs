namespace PageOffice.ExcelReader;

public class DataField
{
	internal string _0002;

	internal string _0003;

	public string Value => this._0002;

	public string Text => _0003;

	internal DataField()
	{
		_0002();
	}

	internal void _0002()
	{
		this._0002 = string.Empty;
		_0003 = string.Empty;
	}
}
