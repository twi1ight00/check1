using System;
using System.Collections;
using System.Xml;

namespace PageOffice.WordReader;

public class DataRegion
{
	private XmlNode _0002;

	private string _0003;

	private ArrayList _0005;

	private ArrayList _0008;

	internal string _0006;

	public string Name
	{
		get
		{
			string text = _0003_2000._000E(_0006);
			return text.Remove(0, 3);
		}
	}

	public string Value => _0003_2000._000E(_0003);

	public byte[] FileBytes => Convert.FromBase64String(_0002.InnerText);

	public ArrayList Tables
	{
		get
		{
			if (_0005 == null)
			{
				_0005 = new ArrayList();
				XmlNode xmlNode = _0002.SelectSingleNode(_0005_2000._0002(1402789223));
				if (xmlNode != null)
				{
					for (int i = 0; i < xmlNode.ChildNodes.Count; i++)
					{
						Table value = new Table(xmlNode.ChildNodes[i]);
						_0005.Add(value);
					}
				}
			}
			return _0005;
		}
	}

	public ArrayList Shapes
	{
		get
		{
			if (_0008 == null)
			{
				_0008 = new ArrayList();
				XmlNode xmlNode = _0002.SelectSingleNode(_0005_2000._0002(1402789159));
				if (xmlNode != null)
				{
					for (int i = 0; i < xmlNode.ChildNodes.Count; i++)
					{
						Shape value = new Shape(xmlNode.ChildNodes[i]);
						_0008.Add(value);
					}
				}
			}
			return _0008;
		}
	}

	internal DataRegion(XmlNode _0002, string _0003)
	{
		_0006 = _0003;
		this._0003 = string.Empty;
		_0005 = null;
		_0008 = null;
		this._0002 = _0002;
		if (this._0002.Attributes[_0005_2000._0002(1402769503)] != null)
		{
			this._0003 = this._0002.Attributes[_0005_2000._0002(1402769503)].InnerText;
		}
	}

	public Table OpenTable(int Index)
	{
		if (Index > Tables.Count || Index < 1)
		{
			throw new Exception(_0005_2000._0002(1402789138) + Index + _0005_2000._0002(1402789202));
		}
		return (Table)_0005[Index - 1];
	}

	public Shape OpenShape(int Index)
	{
		if (Index > Shapes.Count || Index < 1)
		{
			throw new Exception(_0005_2000._0002(1402789138) + Index + _0005_2000._0002(1402789122));
		}
		return (Shape)_0008[Index - 1];
	}
}
