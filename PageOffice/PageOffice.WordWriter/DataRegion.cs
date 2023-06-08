using System;
using System.Collections;
using System.IO;
using System.Xml;

namespace PageOffice.WordWriter;

public class DataRegion
{
	private XmlDocument m__0002;

	private XmlNode _0003;

	private string _0005;

	private bool _0008;

	private bool _0006;

	private ArrayList _000E;

	private Font _000F;

	private ParagraphFormat _0002_2000;

	private Shading _0003_2000;

	internal string _0005_2000;

	public string Name
	{
		get
		{
			string text = global::_0003_2000._000E(_0005_2000);
			return text.Remove(0, 3);
		}
	}

	public string Value
	{
		set
		{
			if (_000E.Count > 0)
			{
				throw new Exception(global::_0005_2000._0002(1402789384));
			}
			if (value == string.Empty)
			{
				_0005 = global::_0005_2000._0002(1402769493);
			}
			else
			{
				_0005 = value;
				string text = global::_0003_2000._000E_2000(value);
				if (!text.Equals(string.Empty))
				{
					int num = text.IndexOf(global::_0005_2000._0002(1402774604));
					if (num > -1)
					{
						if (!File.Exists(text))
						{
							throw new Exception(global::_0005_2000._0002(1402775479) + text + global::_0005_2000._0002(1402775470));
						}
						string text2 = text.Substring(text.LastIndexOf(global::_0005_2000._0002(1402775274)) + 1);
						string text3 = global::_0003_2000._0002(global::_0005_2000._0002(1402775250) + text + global::_0005_2000._0002(1402775262) + text2);
						text3 = text3.Replace(global::_0005_2000._0002(1402775060), global::_0005_2000._0002(1402775068)).Replace(global::_0005_2000._0002(1402775047), global::_0005_2000._0002(1402775055)).Replace(global::_0005_2000._0002(1402769483), global::_0005_2000._0002(1402775158));
						_0005 = _0005.Replace(text, global::_0005_2000._0002(1402789510) + text3);
					}
				}
			}
			XmlAttribute xmlAttribute = _0003.Attributes[global::_0005_2000._0002(1402769503)];
			if (xmlAttribute == null)
			{
				xmlAttribute = this.m__0002.CreateAttribute(global::_0005_2000._0002(1402769503));
				_0003.Attributes.Append(xmlAttribute);
			}
			xmlAttribute.InnerText = global::_0003_2000._0006(_0005);
		}
	}

	public bool Editing
	{
		get
		{
			return _0008;
		}
		set
		{
			_0008 = value;
			XmlAttribute xmlAttribute = _0003.Attributes[global::_0005_2000._0002(1402788259)];
			if (xmlAttribute == null)
			{
				xmlAttribute = this.m__0002.CreateAttribute(global::_0005_2000._0002(1402788259));
				_0003.Attributes.Append(xmlAttribute);
			}
			if (_0008)
			{
				xmlAttribute.InnerText = global::_0005_2000._0002(1402772881);
			}
			else
			{
				xmlAttribute.InnerText = global::_0005_2000._0002(1402773002);
			}
		}
	}

	public bool SubmitAsFile
	{
		get
		{
			return _0006;
		}
		set
		{
			_0006 = value;
			XmlAttribute xmlAttribute = _0003.Attributes[global::_0005_2000._0002(1402788241)];
			if (xmlAttribute == null)
			{
				xmlAttribute = this.m__0002.CreateAttribute(global::_0005_2000._0002(1402788241));
				_0003.Attributes.Append(xmlAttribute);
			}
			if (_0006)
			{
				xmlAttribute.InnerText = global::_0005_2000._0002(1402772881);
			}
			else
			{
				xmlAttribute.InnerText = global::_0005_2000._0002(1402773002);
			}
		}
	}

	public Font Font
	{
		get
		{
			if (_000F == null)
			{
				_000F = new Font(this.m__0002, _0003);
			}
			return _000F;
		}
	}

	public ParagraphFormat ParagraphFormat
	{
		get
		{
			if (_0002_2000 == null)
			{
				_0002_2000 = new ParagraphFormat(this.m__0002, _0003);
			}
			return _0002_2000;
		}
	}

	public Shading Shading
	{
		get
		{
			if (_0003_2000 == null)
			{
				_0003_2000 = new Shading(this.m__0002, _0003);
			}
			return _0003_2000;
		}
	}

	internal DataRegion(XmlDocument _0002, string _0003)
	{
		this.m__0002 = _0002;
		_0005_2000 = _0003;
		_0005 = string.Empty;
		_0008 = false;
		_0006 = false;
		_000E = new ArrayList();
		_000F = null;
		_0002_2000 = null;
		_0003_2000 = null;
		this._0003 = this.m__0002.CreateElement(global::_0005_2000._0002(1402789694));
		XmlNode documentElement = this.m__0002.DocumentElement;
		documentElement.AppendChild(this._0003);
		XmlAttribute xmlAttribute = this.m__0002.CreateAttribute(global::_0005_2000._0002(1402767411));
		xmlAttribute.InnerText = _0003;
		this._0003.Attributes.Append(xmlAttribute);
	}

	internal void _0002(DataRegionInsertType _0002, string _0003)
	{
		XmlAttribute xmlAttribute = this.m__0002.CreateAttribute(global::_0005_2000._0002(1402772890));
		xmlAttribute.InnerText = _0002.ToString();
		this._0003.Attributes.Append(xmlAttribute);
		xmlAttribute = this.m__0002.CreateAttribute(global::_0005_2000._0002(1402788226));
		xmlAttribute.InnerText = _0003;
		this._0003.Attributes.Append(xmlAttribute);
	}

	public Table OpenTable(int Index)
	{
		if (_0005 != string.Empty && (!_0005.StartsWith(global::_0005_2000._0002(1402789367), StringComparison.OrdinalIgnoreCase) || !_0005.EndsWith(global::_0005_2000._0002(1402789346), StringComparison.OrdinalIgnoreCase)))
		{
			throw new Exception(global::_0005_2000._0002(1402788321));
		}
		if (_000E.Count > 0)
		{
			for (int num = _000E.Count - 1; num >= 0; num--)
			{
				Table table = (Table)_000E[num];
				if (table.Index == Index)
				{
					return table;
				}
			}
		}
		Table table2 = new Table(this.m__0002, _0003, Index);
		_000E.Add(table2);
		return table2;
	}

	public Table CreateTable(int NumRows, int NumColumns, WdAutoFitBehavior AutoFitBehavior)
	{
		Table table = new Table(this.m__0002, _0003, -1);
		table._0002(NumRows, NumColumns, AutoFitBehavior);
		_000E.Add(table);
		return table;
	}

	public void SelectStart()
	{
		XmlAttribute xmlAttribute = _0003.Attributes[global::_0005_2000._0002(1402788192)];
		if (xmlAttribute == null)
		{
			xmlAttribute = this.m__0002.CreateAttribute(global::_0005_2000._0002(1402788192));
			_0003.Attributes.Append(xmlAttribute);
		}
		xmlAttribute.InnerText = global::_0005_2000._0002(1402788207);
	}

	public void SelectEnd()
	{
		XmlAttribute xmlAttribute = _0003.Attributes[global::_0005_2000._0002(1402788192)];
		if (xmlAttribute == null)
		{
			xmlAttribute = this.m__0002.CreateAttribute(global::_0005_2000._0002(1402788192));
			_0003.Attributes.Append(xmlAttribute);
		}
		xmlAttribute.InnerText = global::_0005_2000._0002(1402788187);
	}
}
