using System;
using System.Collections;
using System.Xml;
using PageOffice.Utilities;

namespace PageOffice.ExcelWriter;

public class Sheet
{
	private XmlDocument m__0002;

	private ArrayList _0003;

	private ArrayList _0005;

	private XmlNode _0008;

	private bool _0006;

	private bool _000E;

	private bool _000F;

	internal string _0002_2000;

	public string Name => _0003_2000._000E(_0002_2000);

	public bool ReadOnly
	{
		set
		{
			_0006 = value;
			XmlAttribute xmlAttribute = _0008.Attributes[_0005_2000._0002(1402770315)];
			if (xmlAttribute == null)
			{
				xmlAttribute = this.m__0002.CreateAttribute(_0005_2000._0002(1402770315));
				_0008.Attributes.Append(xmlAttribute);
			}
			xmlAttribute.InnerText = _0006.ToString();
		}
	}

	public bool AutoFit
	{
		set
		{
			_000E = value;
			XmlAttribute xmlAttribute = _0008.Attributes[_0005_2000._0002(1402770014)];
			if (xmlAttribute == null)
			{
				xmlAttribute = this.m__0002.CreateAttribute(_0005_2000._0002(1402770014));
				_0008.Attributes.Append(xmlAttribute);
			}
			xmlAttribute.InnerText = _000E.ToString();
		}
	}

	public bool AllowAdjustRC
	{
		set
		{
			_000F = value;
			XmlAttribute xmlAttribute = _0008.Attributes[_0005_2000._0002(1402769996)];
			if (xmlAttribute == null)
			{
				xmlAttribute = this.m__0002.CreateAttribute(_0005_2000._0002(1402769996));
				_0008.Attributes.Append(xmlAttribute);
			}
			xmlAttribute.InnerText = _000F.ToString();
		}
	}

	internal Sheet(XmlDocument _0002, string _0003)
	{
		this.m__0002 = _0002;
		_0002_2000 = _0003;
		_0006 = true;
		_000E = false;
		_000F = false;
		_0008 = this.m__0002.CreateElement(_0005_2000._0002(1402771035));
		XmlNode documentElement = this.m__0002.DocumentElement;
		documentElement.AppendChild(_0008);
		XmlAttribute xmlAttribute = this.m__0002.CreateAttribute(_0005_2000._0002(1402767411));
		xmlAttribute.InnerText = _0003;
		_0008.Attributes.Append(xmlAttribute);
		this._0003 = new ArrayList();
		_0005 = new ArrayList();
	}

	internal void _0002(SheetInsertType _0002, string _0003)
	{
		XmlAttribute xmlAttribute = this.m__0002.CreateAttribute(_0005_2000._0002(1402772896));
		xmlAttribute.InnerText = _0005_2000._0002(1402772881);
		_0008.Attributes.Append(xmlAttribute);
		xmlAttribute = this.m__0002.CreateAttribute(_0005_2000._0002(1402772890));
		xmlAttribute.InnerText = _0002.ToString();
		_0008.Attributes.Append(xmlAttribute);
		xmlAttribute = this.m__0002.CreateAttribute(_0005_2000._0002(1402772877));
		xmlAttribute.InnerText = _0003_2000._0006(_0003);
		_0008.Attributes.Append(xmlAttribute);
	}

	private Cell _0002(string _0002)
	{
		_0002 = _0002.ToUpper();
		Cell cell = new Cell(this.m__0002, _0008, _0002, _0003);
		_0003.Add(cell);
		return cell;
	}

	public Cell OpenCell(string CellAddress)
	{
		if (!ExcelRect.CellAddressIsValid(CellAddress))
		{
			throw new Exception(_0005_2000._0002(1402768126));
		}
		return _0002(CellAddress);
	}

	public Cell OpenCellRC(int Row, int Col)
	{
		if (Col < 1 || Row < 1 || Col > 676 || Row > 65536)
		{
			throw new Exception(_0005_2000._0002(1402772965) + Row + _0005_2000._0002(1402772956) + Col + _0005_2000._0002(1402772789));
		}
		string empty = string.Empty;
		empty = ((Col <= 26) ? ((char)(65 + (Col - 1) % 26)).ToString() : (((char)(65 + (Col - 1) / 26 - 1)).ToString() + (char)(65 + (Col - 1) % 26)));
		empty += Row;
		return _0002(empty);
	}

	public Cell OpenCellByDefinedName(string DefinedName)
	{
		if (DefinedName.IndexOf(_0005_2000._0002(1402772758)) > -1 || DefinedName.IndexOf(_0005_2000._0002(1402772766)) > -1 || DefinedName.IndexOf(_0005_2000._0002(1402767420)) > -1)
		{
			throw new Exception(_0005_2000._0002(1402772742));
		}
		DefinedName = DefinedName.ToLower();
		Cell cell = new Cell(this.m__0002, _0008, _0003, DefinedName);
		_0003.Add(cell);
		return cell;
	}

	private Table _0002(string _0002, bool _0003)
	{
		ExcelRect excelRect = new ExcelRect(_0002);
		if (!excelRect.IsValid())
		{
			throw new Exception(_0005_2000._0002(1402770752));
		}
		_0002 = _0002.ToUpper();
		Table table = new Table(this.m__0002, _0008, _0002, _0003, _0005);
		_0005.Add(table);
		return table;
	}

	public Table OpenTable(string RangeAddress)
	{
		return _0002(RangeAddress, _0003: true);
	}

	public Table OpenTable(string RangeAddress, bool AutoIncrease)
	{
		return _0002(RangeAddress, AutoIncrease);
	}

	private Table _0002(string _0002, int _0003, int _0005, bool _0008)
	{
		string rangeAddress = _0005_2000._0002(1402772827);
		ExcelRect excelRect = new ExcelRect(rangeAddress);
		excelRect.bottom = _0003;
		excelRect.right = _0005;
		if (!excelRect.IsValid())
		{
			throw new Exception(_0005_2000._0002(1402772807));
		}
		Table table = new Table(this.m__0002, this._0008, excelRect.GetRangeAddress(), _0008, this._0005, _0002);
		this._0005.Add(table);
		return table;
	}

	public Table OpenTableByDefinedName(string DefinedName, int RowCount, int ColCount)
	{
		if (DefinedName.IndexOf(_0005_2000._0002(1402772758)) > -1 || DefinedName.IndexOf(_0005_2000._0002(1402772766)) > -1 || DefinedName.IndexOf(_0005_2000._0002(1402767420)) > -1)
		{
			throw new Exception(_0005_2000._0002(1402772742));
		}
		DefinedName = DefinedName.ToLower();
		return _0002(DefinedName, RowCount, ColCount, _0008: true);
	}

	public Table OpenTableByDefinedName(string DefinedName, int RowCount, int ColCount, bool AutoIncrease)
	{
		if (DefinedName.IndexOf(_0005_2000._0002(1402772758)) > -1 || DefinedName.IndexOf(_0005_2000._0002(1402772766)) > -1 || DefinedName.IndexOf(_0005_2000._0002(1402767420)) > -1)
		{
			throw new Exception(_0005_2000._0002(1402772742));
		}
		DefinedName = DefinedName.ToLower();
		return _0002(DefinedName, RowCount, ColCount, _0008: true);
	}
}
