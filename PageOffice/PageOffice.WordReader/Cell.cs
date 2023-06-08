using System;
using System.Collections;
using System.Xml;

namespace PageOffice.WordReader;

public class Cell
{
	private XmlNode _0002;

	private int _0003;

	private int _0005;

	private string _0008;

	private ArrayList _0006;

	public int RowIndex => _0003;

	public int ColumnIndex => _0005;

	public string Value => _0003_2000._000E(_0008);

	public ArrayList Shapes
	{
		get
		{
			if (_0006 == null)
			{
				_0006 = new ArrayList();
				XmlNode xmlNode = _0002.SelectSingleNode(_0005_2000._0002(1402789159));
				if (xmlNode != null)
				{
					for (int i = 0; i < xmlNode.ChildNodes.Count; i++)
					{
						Shape value = new Shape(xmlNode.ChildNodes[i]);
						_0006.Add(value);
					}
				}
			}
			return _0006;
		}
	}

	internal Cell(XmlNode _0002)
	{
		_0003 = 1;
		_0005 = 1;
		_0006 = null;
		this._0002 = _0002;
		_0003 = int.Parse(this._0002.Attributes[_0005_2000._0002(1402789327)].InnerText);
		_0005 = int.Parse(this._0002.Attributes[_0005_2000._0002(1402789175)].InnerText);
		_0008 = this._0002.Attributes[_0005_2000._0002(1402789183)].InnerText;
	}

	public Shape OpenShape(int Index)
	{
		if (Index > Shapes.Count || Index < 1)
		{
			throw new Exception(_0005_2000._0002(1402789138) + Index + _0005_2000._0002(1402789122));
		}
		return (Shape)_0006[Index - 1];
	}
}
