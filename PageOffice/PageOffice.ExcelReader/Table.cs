using System;
using System.Xml;
using PageOffice.Utilities;

namespace PageOffice.ExcelReader;

public class Table
{
	private XmlNode m__0002;

	private string[] _0003;

	private int _0005;

	private _000E _0008;

	private bool _0006;

	private ExcelRect _000E;

	private bool _000F;

	private int _0002_2000;

	private Sheet _0003_2000;

	internal string _0005_2000;

	public string SubmitName => _0005_2000;

	public int RowCount => _0005;

	public bool EOF => _000F;

	public IDataFieldCollection DataFields
	{
		get
		{
			if (_0006)
			{
				throw new Exception(global::_0005_2000._0002(1402770515));
			}
			return _0008;
		}
	}

	internal Table(Sheet _0002, XmlNode _0003, string _0005)
	{
		_0003_2000 = _0002;
		this.m__0002 = _0003;
		this._0003 = null;
		_000F = false;
		_0005_2000 = _0005;
		_0002_2000 = 0;
		_000E = new ExcelRect(_0003.Attributes[global::_0005_2000._0002(1402768309)].InnerText);
		int num = _000E.right - _000E.left + 1;
		this._0005 = int.Parse(_0003.Attributes[global::_0005_2000._0002(1402770635)].InnerText);
		XmlNode xmlNode = _0003.SelectSingleNode(global::_0005_2000._0002(1402770491));
		if (xmlNode != null)
		{
			this._0003 = xmlNode.InnerText.Split('\t');
		}
		_0008 = new _000E();
		for (int i = 0; i < num; i++)
		{
			_0008._0002(new DataField());
		}
		_0008._0002(string.Empty);
		_0008._0002(_0002: true);
		_0006 = false;
		if (this._0005 > 0)
		{
			this._0002(0);
		}
		else
		{
			_000F = true;
		}
	}

	internal Table(Sheet _0002, string _0003)
	{
		_0003_2000 = _0002;
		this.m__0002 = null;
		this._0003 = null;
		_000F = false;
		_0005_2000 = string.Empty;
		_0002_2000 = 0;
		if (_0002._000E != null)
		{
			ExcelRect excelRect = new ExcelRect(_0003);
			if (excelRect.top < _0002._000E.top || excelRect.left < _0002._000E.left || excelRect.top > _0002._000E.bottom || excelRect.left > _0002._000E.right)
			{
				throw new Exception(global::_0005_2000._0002(1402770472));
			}
		}
		_000E = new ExcelRect(_0003);
		int num = _000E.right - _000E.left + 1;
		_0005 = _000E.bottom - _000E.top + 1;
		_0008 = new _000E();
		for (int i = 0; i < num; i++)
		{
			_0008._0002(new DataField());
		}
		_0008._0002(string.Empty);
		_0008._0002(_0002: true);
		_0006 = false;
		if (_0005 > 0)
		{
			this._0002(0);
		}
		else
		{
			_000F = true;
		}
	}

	private void _0002(int _0002)
	{
		_0002_2000 = _0002;
		int num = _000E.top - _0003_2000._000E.top + _0002_2000;
		int num2 = _000E.left - _0003_2000._000E.left;
		if (_0003_2000._0002_2000[num] == string.Empty)
		{
			for (int i = 0; i < _0008.Count; i++)
			{
				DataField dataField = _0008[i];
				dataField._0002 = string.Empty;
				dataField._0003 = string.Empty;
			}
			_0008._0002(_0002: true);
		}
		else
		{
			bool flag = true;
			string[] array = _0003_2000._000F[num].Split('\t');
			string[] array2 = _0003_2000._0002_2000[num].Split('\t');
			for (int j = 0; j < _0008.Count; j++)
			{
				DataField dataField2 = _0008[j];
				dataField2._0002 = array[num2 + j];
				dataField2._0003 = array2[num2 + j];
				if (dataField2.Text != string.Empty)
				{
					flag = false;
				}
			}
			if (flag)
			{
				_0008._0002(_0002: true);
			}
			else
			{
				_0008._0002(_0002: false);
			}
		}
		if (_0003 != null && _0002 < _0003.Length)
		{
			_0008._0002(_0003[_0002]);
		}
		else
		{
			_0008._0002(string.Empty);
		}
	}

	public void NextRow()
	{
		if (_0006)
		{
			throw new Exception(global::_0005_2000._0002(1402770515));
		}
		_0002_2000++;
		if (_0002_2000 >= _0005)
		{
			_000F = true;
			for (int i = 0; i < _0008.Count; i++)
			{
				DataField dataField = _0008[i];
				dataField._0002();
			}
			_0008._0002(string.Empty);
			_0008._0002(_0002: true);
		}
		else
		{
			_0002(_0002_2000);
		}
	}

	public void GotoRow(int RowIndex)
	{
		if (_0006)
		{
			throw new Exception(global::_0005_2000._0002(1402770515));
		}
		if (RowIndex >= _0005 || RowIndex < 0)
		{
			throw new Exception(global::_0005_2000._0002(1402770502) + RowIndex + global::_0005_2000._0002(1402771384));
		}
		_000F = false;
		_0002(RowIndex);
	}

	public void Close()
	{
		if (_0006)
		{
			throw new Exception(global::_0005_2000._0002(1402770515));
		}
		_0006 = true;
		_000F = true;
		_0008.Clear();
	}
}
