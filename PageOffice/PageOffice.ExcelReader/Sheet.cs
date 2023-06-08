using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.Xml;
using PageOffice.Utilities;

namespace PageOffice.ExcelReader;

public class Sheet
{
	private ArrayList m__0002;

	private ArrayList m__0003;

	private XmlNode _0005;

	private int _0008;

	private int _0006;

	internal ExcelRect _000E;

	internal string[] _000F;

	internal string[] _0002_2000;

	internal string _0003_2000;

	public string Name => global::_0003_2000._000E(_0003_2000);

	public ArrayList Cells
	{
		get
		{
			if (this.m__0002.Count < _0008)
			{
				this.m__0002.Clear();
				XmlNodeList xmlNodeList = _0005.SelectNodes(_0005_2000._0002(1402767469));
				if (xmlNodeList != null)
				{
					for (int i = 0; i < xmlNodeList.Count; i++)
					{
						Cell value = new Cell(this, xmlNodeList[i], global::_0003_2000._000E(xmlNodeList[i].Attributes[_0005_2000._0002(1402768264)].InnerText));
						this.m__0002.Add(value);
					}
				}
			}
			return this.m__0002;
		}
	}

	public ArrayList Tables
	{
		get
		{
			if (this.m__0003.Count < _0006)
			{
				this.m__0003.Clear();
				XmlNodeList xmlNodeList = _0005.SelectNodes(_0005_2000._0002(1402767446));
				if (xmlNodeList != null)
				{
					for (int i = 0; i < xmlNodeList.Count; i++)
					{
						Table value = new Table(this, xmlNodeList[i], global::_0003_2000._000E(xmlNodeList[i].Attributes[_0005_2000._0002(1402768264)].InnerText));
						this.m__0003.Add(value);
					}
				}
			}
			return this.m__0003;
		}
	}

	internal Sheet(XmlNode _0002, string _0003)
	{
		_0003_2000 = _0003;
		_0005 = _0002;
		_0008 = _0005.SelectNodes(_0005_2000._0002(1402767469)).Count;
		_0006 = _0005.SelectNodes(_0005_2000._0002(1402767446)).Count;
		this.m__0002 = new ArrayList();
		this.m__0003 = new ArrayList();
		_000E = null;
		XmlNode xmlNode = _0002.SelectSingleNode(_0005_2000._0002(1402767426));
		if (xmlNode != null)
		{
			_000E = new ExcelRect(xmlNode.Attributes[_0005_2000._0002(1402768309)].InnerText);
			string input = global::_0003_2000._000E(xmlNode.Attributes[_0005_2000._0002(1402768294)].InnerText);
			string input2 = global::_0003_2000._000E(xmlNode.Attributes[_0005_2000._0002(1402768277)].InnerText);
			_000F = Regex.Split(input, _0005_2000._0002(1402768257));
			_0002_2000 = Regex.Split(input2, _0005_2000._0002(1402768257));
		}
	}

	public Cell OpenCell(string Name)
	{
		if (ExcelRect.LooklikeCellAddress(Name))
		{
			return _0003(Name);
		}
		return _0002(Name);
	}

	public Cell OpenCellByDefinedName(string DefinedName)
	{
		string text = DefinedName.ToLower();
		if (this.m__0002.Count > 0)
		{
			for (int num = this.m__0002.Count - 1; num >= 0; num--)
			{
				Cell cell = (Cell)this.m__0002[num];
				if (cell._0008 == text)
				{
					return cell;
				}
			}
		}
		bool flag = false;
		XmlNode xmlNode = null;
		string text2 = global::_0003_2000._0006(text);
		for (int i = 0; i < _0005.ChildNodes.Count; i++)
		{
			xmlNode = _0005.ChildNodes[i];
			if (xmlNode.Name == _0005_2000._0002(1402767469) && xmlNode.Attributes[_0005_2000._0002(1402768264)].InnerText == text2)
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			Cell cell2 = new Cell(this, xmlNode, text);
			this.m__0002.Add(cell2);
			return cell2;
		}
		throw new Exception(_0005_2000._0002(1402768379) + text + _0005_2000._0002(1402768337));
	}

	private Cell _0002(string _0002)
	{
		if (this.m__0002.Count > 0)
		{
			for (int num = this.m__0002.Count - 1; num >= 0; num--)
			{
				Cell cell = (Cell)this.m__0002[num];
				if (cell._0008 == _0002)
				{
					return cell;
				}
			}
		}
		bool flag = false;
		XmlNode xmlNode = null;
		string text = global::_0003_2000._0006(_0002);
		for (int i = 0; i < _0005.ChildNodes.Count; i++)
		{
			xmlNode = _0005.ChildNodes[i];
			if (xmlNode.Name == _0005_2000._0002(1402767469) && xmlNode.Attributes[_0005_2000._0002(1402768264)].InnerText == text)
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			Cell cell2 = new Cell(this, xmlNode, _0002);
			this.m__0002.Add(cell2);
			return cell2;
		}
		throw new Exception(_0005_2000._0002(1402768236) + _0002 + _0005_2000._0002(1402768195));
	}

	private Cell _0003(string _0002)
	{
		if (!ExcelRect.CellAddressIsValid(_0002))
		{
			throw new Exception(_0005_2000._0002(1402768126));
		}
		return new Cell(this, _0002);
	}

	public Table OpenTable(string Name)
	{
		if (ExcelRect.LooklikeRangeAddress(Name))
		{
			return _0003(Name);
		}
		return _0002(Name);
	}

	public Table OpenTableByDefinedName(string DefinedName)
	{
		string text = DefinedName.ToLower();
		if (this.m__0003.Count > 0)
		{
			for (int num = this.m__0003.Count - 1; num >= 0; num--)
			{
				Table table = (Table)this.m__0003[num];
				if (table._0005_2000 == text)
				{
					return table;
				}
			}
		}
		bool flag = false;
		XmlNode xmlNode = null;
		string text2 = global::_0003_2000._0006(text);
		for (int i = 0; i < _0005.ChildNodes.Count; i++)
		{
			xmlNode = _0005.ChildNodes[i];
			if (xmlNode.Name == _0005_2000._0002(1402767446) && xmlNode.Attributes[_0005_2000._0002(1402768264)].InnerText == text2)
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			Table table2 = new Table(this, xmlNode, text);
			this.m__0003.Add(table2);
			return table2;
		}
		throw new Exception(_0005_2000._0002(1402767999) + text + _0005_2000._0002(1402767956));
	}

	private Table _0002(string _0002)
	{
		if (this.m__0003.Count > 0)
		{
			for (int num = this.m__0003.Count - 1; num >= 0; num--)
			{
				Table table = (Table)this.m__0003[num];
				if (table._0005_2000 == _0002)
				{
					return table;
				}
			}
		}
		bool flag = false;
		XmlNode xmlNode = null;
		string text = global::_0003_2000._0006(_0002);
		for (int i = 0; i < _0005.ChildNodes.Count; i++)
		{
			xmlNode = _0005.ChildNodes[i];
			if (xmlNode.Name == _0005_2000._0002(1402767446) && xmlNode.Attributes[_0005_2000._0002(1402768264)].InnerText == text)
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			Table table2 = new Table(this, xmlNode, _0002);
			this.m__0003.Add(table2);
			return table2;
		}
		throw new Exception(_0005_2000._0002(1402770911) + _0002 + _0005_2000._0002(1402770741));
	}

	private Table _0003(string _0002)
	{
		ExcelRect excelRect = new ExcelRect(_0002);
		if (!excelRect.IsValid())
		{
			throw new Exception(_0005_2000._0002(1402770752));
		}
		_0002 = _0002.ToUpper();
		return new Table(this, _0002);
	}
}
