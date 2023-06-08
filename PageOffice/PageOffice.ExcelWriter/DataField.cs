using System.Drawing;

namespace PageOffice.ExcelWriter;

public class DataField
{
	private string m__0002;

	private string _0003;

	internal string _0005;

	internal int _0008;

	internal int _0006;

	internal bool _000E;

	internal bool _000F;

	public string Value
	{
		set
		{
			_000E = false;
			_000F = false;
			this.m__0002 = value;
			if (this.m__0002.Length > 0)
			{
				_0005 = this.m__0002;
				if (_0005[0] == '=')
				{
					_0005 = _0005_2000._0002(1402765371) + _0005;
				}
				if (_0005.IndexOf('\t') > -1)
				{
					_0005 = _0005.Replace('\t', ' ');
				}
				else if (_0005.IndexOf('\r') > -1 || _0005.IndexOf('\n') > -1)
				{
					_0005 = _0005_2000._0002(1402769937) + _0005 + _0005_2000._0002(1402769937);
				}
			}
			else
			{
				_0005 = string.Empty;
			}
		}
	}

	public string Formula
	{
		set
		{
			_000E = false;
			_000F = false;
			_0003 = value;
			if (_0003.Length > 0)
			{
				_0005 = _0003;
				if (_0005[0] != '=')
				{
					_0005 = _0005_2000._0002(1402769483) + _0005;
				}
				if (_0005.IndexOf('\t') > -1)
				{
					_0005 = _0005.Replace('\t', ' ');
				}
				else if (_0005.IndexOf('\r') > -1 || _0005.IndexOf('\n') > -1)
				{
					_0005 = _0005_2000._0002(1402769945) + _0005 + _0005_2000._0002(1402769937);
				}
			}
			else
			{
				_0005 = string.Empty;
			}
		}
	}

	public Color BackColor
	{
		set
		{
			_0008 = ColorTranslator.ToOle(value);
		}
	}

	public Color ForeColor
	{
		set
		{
			_0006 = ColorTranslator.ToOle(value);
		}
	}

	internal DataField()
	{
		_0002();
		_000E = true;
	}

	internal void _0002()
	{
		this.m__0002 = string.Empty;
		_0003 = string.Empty;
		_0005 = string.Empty;
		_0008 = -1;
		_0006 = -1;
		_000F = true;
	}
}
