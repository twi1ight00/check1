using System;
using System.IO;
using System.Xml;

namespace PageOffice.WordWriter;

public class Cell
{
	private XmlDocument _0002;

	private XmlNode _0003;

	private XmlNode _0005;

	private string _0008;

	private Font _0006;

	private ParagraphFormat _000E;

	private Shading _000F;

	private WdCellVerticalAlignment _0002_2000;

	private Border _0003_2000;

	internal int _0005_2000;

	internal int _0008_2000;

	public string Value
	{
		set
		{
			if (value == string.Empty)
			{
				_0008 = global::_0005_2000._0002(1402769493);
			}
			else
			{
				_0008 = value;
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
						_0008 = _0008.Replace(text, global::_0005_2000._0002(1402789510) + text3);
					}
				}
			}
			_0008 = global::_0003_2000._0006(_0008);
			XmlAttribute xmlAttribute = _0003.Attributes[global::_0005_2000._0002(1402769503)];
			if (xmlAttribute == null)
			{
				xmlAttribute = _0002.CreateAttribute(global::_0005_2000._0002(1402769503));
				_0003.Attributes.Append(xmlAttribute);
			}
			xmlAttribute.InnerText = _0008;
		}
	}

	public Font Font
	{
		get
		{
			if (_0006 == null)
			{
				_0006 = new Font(_0002, _0003);
			}
			return _0006;
		}
	}

	public ParagraphFormat ParagraphFormat
	{
		get
		{
			if (_000E == null)
			{
				_000E = new ParagraphFormat(_0002, _0003);
			}
			return _000E;
		}
	}

	public Shading Shading
	{
		get
		{
			if (_000F == null)
			{
				_000F = new Shading(_0002, _0003);
			}
			return _000F;
		}
	}

	public WdCellVerticalAlignment VerticalAlignment
	{
		set
		{
			_0002_2000 = value;
			XmlAttribute xmlAttribute = _0003.Attributes[global::_0005_2000._0002(1402789584)];
			if (xmlAttribute == null)
			{
				xmlAttribute = _0002.CreateAttribute(global::_0005_2000._0002(1402789584));
				_0003.Attributes.Append(xmlAttribute);
			}
			XmlAttribute xmlAttribute2 = xmlAttribute;
			int num = (int)_0002_2000;
			xmlAttribute2.InnerText = num.ToString();
		}
	}

	public Border Border
	{
		get
		{
			if (_0003_2000 == null)
			{
				_0003_2000 = new Border(_0002, _0003);
			}
			return _0003_2000;
		}
	}

	internal Cell(XmlDocument _0002, XmlNode _0003, int _0005, int _0008)
	{
		this._0002 = _0002;
		this._0005 = _0003;
		this._0008 = string.Empty;
		_0005_2000 = _0005;
		_0008_2000 = _0008;
		_0006 = null;
		_000E = null;
		_000F = null;
		_0002_2000 = WdCellVerticalAlignment.wdCellAlignVerticalTop;
		_0003_2000 = null;
		this._0003 = this._0002.CreateElement(global::_0005_2000._0002(1402767469));
		_0003.AppendChild(this._0003);
		this._0003.InnerText = string.Empty;
		XmlAttribute xmlAttribute = this._0002.CreateAttribute(global::_0005_2000._0002(1402789522));
		this._0003.Attributes.Append(xmlAttribute);
		xmlAttribute.InnerText = _0005.ToString();
		xmlAttribute = this._0002.CreateAttribute(global::_0005_2000._0002(1402789532));
		this._0003.Attributes.Append(xmlAttribute);
		xmlAttribute.InnerText = _0008.ToString();
	}

	public void MergeTo(int Row, int Col)
	{
		XmlNode xmlNode = _0002.CreateElement(global::_0005_2000._0002(1402767469));
		_0005.InsertBefore(xmlNode, _0003);
		XmlAttribute xmlAttribute = _0002.CreateAttribute(global::_0005_2000._0002(1402789522));
		xmlAttribute.InnerText = _0005_2000.ToString();
		xmlNode.Attributes.Append(xmlAttribute);
		xmlAttribute = _0002.CreateAttribute(global::_0005_2000._0002(1402789532));
		xmlAttribute.InnerText = _0008_2000.ToString();
		xmlNode.Attributes.Append(xmlAttribute);
		xmlAttribute = _0002.CreateAttribute(global::_0005_2000._0002(1402789576));
		xmlAttribute.InnerText = Row.ToString();
		xmlNode.Attributes.Append(xmlAttribute);
		xmlAttribute = _0002.CreateAttribute(global::_0005_2000._0002(1402789435));
		xmlAttribute.InnerText = Col.ToString();
		xmlNode.Attributes.Append(xmlAttribute);
	}
}
