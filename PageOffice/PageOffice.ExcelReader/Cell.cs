using System;
using System.Xml;
using PageOffice.Utilities;

namespace PageOffice.ExcelReader;

public class Cell
{
	private XmlNode _0002;

	private string _0003;

	private string _0005;

	internal string _0008;

	public string Value => _0003;

	public string Text => _0005;

	public string SubmitName => _0008;

	internal Cell(Sheet _0002, XmlNode _0003, string _0005)
	{
		_0008 = _0005;
		this._0002 = _0003;
		this._0003 = string.Empty;
		this._0005 = string.Empty;
		string innerText = this._0002.Attributes[_0005_2000._0002(1402767411)].InnerText;
		if (_0002._000E == null)
		{
			return;
		}
		ExcelRect excelRect = new ExcelRect(innerText + _0005_2000._0002(1402767420) + innerText);
		if (excelRect.top >= _0002._000E.top && excelRect.left >= _0002._000E.left && excelRect.top <= _0002._000E.bottom && excelRect.left <= _0002._000E.right)
		{
			int num = excelRect.top - _0002._000E.top;
			int num2 = excelRect.left - _0002._000E.left;
			if (_0002._000F[num] == string.Empty)
			{
				this._0003 = string.Empty;
				this._0005 = string.Empty;
				return;
			}
			string[] array = _0002._000F[num].Split('\t');
			this._0003 = array[num2];
			string[] array2 = _0002._0002_2000[num].Split('\t');
			this._0005 = array2[num2];
		}
	}

	internal Cell(Sheet _0002, string _0003)
	{
		_0008 = string.Empty;
		this._0003 = string.Empty;
		_0005 = string.Empty;
		if (_0002._000E != null)
		{
			ExcelRect excelRect = new ExcelRect(_0003 + _0005_2000._0002(1402767420) + _0003);
			if (excelRect.top < _0002._000E.top || excelRect.left < _0002._000E.left || excelRect.top > _0002._000E.bottom || excelRect.left > _0002._000E.right)
			{
				throw new Exception(_0005_2000._0002(1402767396));
			}
			int num = excelRect.top - _0002._000E.top;
			int num2 = excelRect.left - _0002._000E.left;
			if (_0002._000F[num] == string.Empty)
			{
				this._0003 = string.Empty;
				_0005 = string.Empty;
				return;
			}
			string[] array = _0002._000F[num].Split('\t');
			this._0003 = array[num2];
			string[] array2 = _0002._0002_2000[num].Split('\t');
			_0005 = array2[num2];
		}
	}
}
