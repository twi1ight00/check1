using System.Collections;
using System.Xml;

namespace PageOffice.WordWriter;

public class Table
{
	private XmlDocument m__0002;

	private ArrayList _0003;

	private ArrayList _0005;

	private ArrayList _0008;

	private XmlNode _0006;

	private int _000E;

	private WdPreferredWidthType _000F;

	private float _0002_2000;

	private Border _0003_2000;

	public int Index => _000E;

	public Border Border
	{
		get
		{
			if (_0003_2000 == null)
			{
				_0003_2000 = new Border(this.m__0002, _0006);
			}
			return _0003_2000;
		}
	}

	public WdPreferredWidthType PreferredWidthType
	{
		set
		{
			_000F = value;
			XmlAttribute xmlAttribute = _0006.Attributes[_0005_2000._0002(1402788757)];
			if (xmlAttribute == null)
			{
				xmlAttribute = this.m__0002.CreateAttribute(_0005_2000._0002(1402788757));
				_0006.Attributes.Append(xmlAttribute);
			}
			XmlAttribute xmlAttribute2 = xmlAttribute;
			int num = (int)_000F;
			xmlAttribute2.InnerText = num.ToString();
		}
	}

	public float PreferredWidth
	{
		set
		{
			_0002_2000 = value;
			XmlAttribute xmlAttribute = _0006.Attributes[_0005_2000._0002(1402788748)];
			if (xmlAttribute == null)
			{
				xmlAttribute = this.m__0002.CreateAttribute(_0005_2000._0002(1402788748));
				_0006.Attributes.Append(xmlAttribute);
			}
			xmlAttribute.InnerText = _0002_2000.ToString();
		}
	}

	internal Table(XmlDocument _0002, XmlNode _0003, int _0005)
	{
		this.m__0002 = _0002;
		_000E = _0005;
		_000F = WdPreferredWidthType.wdPreferredWidthAuto;
		_0002_2000 = 0f;
		_0003_2000 = null;
		_0006 = this.m__0002.CreateElement(_0005_2000._0002(1402767446));
		_0003.AppendChild(_0006);
		XmlAttribute xmlAttribute = this.m__0002.CreateAttribute(_0005_2000._0002(1402789197));
		xmlAttribute.InnerText = _0005.ToString();
		_0006.Attributes.Append(xmlAttribute);
		this._0003 = new ArrayList();
		this._0005 = new ArrayList();
		_0008 = new ArrayList();
	}

	internal void _0002(int _0002, int _0003, WdAutoFitBehavior _0005)
	{
		XmlAttribute xmlAttribute = this.m__0002.CreateAttribute(_0005_2000._0002(1402788835));
		xmlAttribute.InnerText = _0002.ToString();
		_0006.Attributes.Append(xmlAttribute);
		xmlAttribute = this.m__0002.CreateAttribute(_0005_2000._0002(1402788817));
		xmlAttribute.InnerText = _0003.ToString();
		_0006.Attributes.Append(xmlAttribute);
		xmlAttribute = this.m__0002.CreateAttribute(_0005_2000._0002(1402788800));
		XmlAttribute xmlAttribute2 = xmlAttribute;
		int num = (int)_0005;
		xmlAttribute2.InnerText = num.ToString();
		_0006.Attributes.Append(xmlAttribute);
	}

	public Cell OpenCellRC(int Row, int Col)
	{
		if (_0003.Count > 0)
		{
			for (int num = _0003.Count - 1; num >= 0; num--)
			{
				Cell cell = (Cell)_0003[num];
				if (cell._0005_2000 == Row && cell._0008_2000 == Col)
				{
					return cell;
				}
			}
		}
		Cell cell2 = new Cell(this.m__0002, _0006, Row, Col);
		_0003.Add(cell2);
		return cell2;
	}

	public void InsertRowAfter(Cell cell)
	{
		XmlNode xmlNode = this.m__0002.CreateElement(_0005_2000._0002(1402788662));
		XmlAttribute xmlAttribute = this.m__0002.CreateAttribute(_0005_2000._0002(1402789522));
		xmlAttribute.InnerText = cell._0005_2000.ToString();
		xmlNode.Attributes.Append(xmlAttribute);
		xmlAttribute = this.m__0002.CreateAttribute(_0005_2000._0002(1402789532));
		xmlAttribute.InnerText = cell._0008_2000.ToString();
		xmlNode.Attributes.Append(xmlAttribute);
		_0006.AppendChild(xmlNode);
	}

	public Column OpenColumn(int Index)
	{
		if (_0005.Count > 0)
		{
			for (int num = _0005.Count - 1; num >= 0; num--)
			{
				Column column = (Column)_0005[num];
				if (column.Index == Index)
				{
					return column;
				}
			}
		}
		Column column2 = new Column(this.m__0002, _0006, Index);
		_0005.Add(column2);
		return column2;
	}

	public Row OpenRow(int Index)
	{
		if (_0008.Count > 0)
		{
			for (int num = _0008.Count - 1; num >= 0; num--)
			{
				Row row = (Row)_0008[num];
				if (row.Index == Index)
				{
					return row;
				}
			}
		}
		Row row2 = new Row(this.m__0002, _0006, Index);
		_0008.Add(row2);
		return row2;
	}

	public void SetRowsHeight(float RowHeight, WdRowHeightRule HeightRule)
	{
		XmlAttribute xmlAttribute = this.m__0002.CreateAttribute(_0005_2000._0002(1402788653));
		xmlAttribute.InnerText = RowHeight.ToString();
		_0006.Attributes.Append(xmlAttribute);
		xmlAttribute = this.m__0002.CreateAttribute(_0005_2000._0002(1402787929));
		XmlAttribute xmlAttribute2 = xmlAttribute;
		int num = (int)HeightRule;
		xmlAttribute2.InnerText = num.ToString();
		_0006.Attributes.Append(xmlAttribute);
	}

	public void SetRowsHeight(float RowHeight)
	{
		XmlAttribute xmlAttribute = this.m__0002.CreateAttribute(_0005_2000._0002(1402788653));
		xmlAttribute.InnerText = RowHeight.ToString();
		_0006.Attributes.Append(xmlAttribute);
		xmlAttribute = this.m__0002.CreateAttribute(_0005_2000._0002(1402787929));
		xmlAttribute.InnerText = 0.ToString();
		_0006.Attributes.Append(xmlAttribute);
	}

	public void RemoveRowAt(Cell cell)
	{
		XmlNode xmlNode = this.m__0002.CreateElement(_0005_2000._0002(1402788636));
		XmlAttribute xmlAttribute = this.m__0002.CreateAttribute(_0005_2000._0002(1402789522));
		xmlAttribute.InnerText = cell._0005_2000.ToString();
		xmlNode.Attributes.Append(xmlAttribute);
		xmlAttribute = this.m__0002.CreateAttribute(_0005_2000._0002(1402789532));
		xmlAttribute.InnerText = cell._0008_2000.ToString();
		xmlNode.Attributes.Append(xmlAttribute);
		_0006.AppendChild(xmlNode);
	}
}
