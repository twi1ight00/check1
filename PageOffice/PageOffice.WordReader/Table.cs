using System;
using System.Collections;
using System.Xml;

namespace PageOffice.WordReader;

public class Table
{
	private XmlNode _0002;

	private int _0003;

	private int _0005;

	private int _0008;

	private ArrayList _0006;

	public int Index => _0003;

	public int ColumnsCount => _0005;

	public int RowsCount => _0008;

	public ArrayList Cells
	{
		get
		{
			if (_0006 == null)
			{
				_0006 = new ArrayList();
				XmlNodeList xmlNodeList = _0002.SelectNodes(_0005_2000._0002(1402767469));
				if (xmlNodeList != null)
				{
					for (int i = 0; i < xmlNodeList.Count; i++)
					{
						Cell value = new Cell(xmlNodeList[i]);
						_0006.Add(value);
					}
				}
			}
			return _0006;
		}
	}

	internal Table(XmlNode _0002)
	{
		_0003 = 1;
		_0006 = null;
		this._0002 = _0002;
		_0003 = int.Parse(this._0002.Attributes[_0005_2000._0002(1402789197)].InnerText);
		_0008 = int.Parse(_0002.Attributes[_0005_2000._0002(1402770635)].InnerText);
		_0005 = int.Parse(_0002.Attributes[_0005_2000._0002(1402789078)].InnerText);
	}

	public Cell OpenCellRC(int Row, int Col)
	{
		if (Row < 1 || Col < 1)
		{
			throw new Exception(_0005_2000._0002(1402789062) + Row + _0005_2000._0002(1402788916) + Col + _0005_2000._0002(1402788911));
		}
		bool flag = false;
		int num = 0;
		for (num = 0; num < Cells.Count; num++)
		{
			Cell cell = (Cell)_0006[num];
			if (cell.RowIndex == Row && cell.ColumnIndex == Col)
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			return (Cell)_0006[num];
		}
		throw new Exception(_0005_2000._0002(1402789062) + Row + _0005_2000._0002(1402788916) + Col + _0005_2000._0002(1402788911));
	}
}
