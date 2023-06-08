using System;
using System.Collections;
using System.Drawing;
using System.Xml;
using PageOffice.Utilities;

namespace PageOffice.ExcelWriter;

public class Cell
{
	private XmlDocument _0002;

	private XmlNode _0003;

	private string _0005;

	private string _0008;

	private Border _0006;

	private int _000E;

	private int _000F;

	private bool _0002_2000;

	private ArrayList _0003_2000;

	private Font _0005_2000;

	private XlHAlign _0008_2000;

	private XlVAlign _0006_2000;

	private string _000E_2000;

	internal string _000F_2000;

	internal string _0002_2001;

	internal string _0003_2001;

	public string Value
	{
		set
		{
			string text = value;
			if (text.Length > 0)
			{
				if (text[0] == '=')
				{
					text = global::_0005_2000._0002(1402765371) + text;
				}
			}
			else
			{
				text = global::_0005_2000._0002(1402769493);
			}
			XmlAttribute xmlAttribute = _0003.Attributes[global::_0005_2000._0002(1402769503)];
			if (xmlAttribute == null)
			{
				xmlAttribute = _0002.CreateAttribute(global::_0005_2000._0002(1402769503));
				_0003.Attributes.Append(xmlAttribute);
			}
			_0005 = global::_0003_2000._0006(text);
			xmlAttribute.InnerText = _0005;
		}
	}

	public string Formula
	{
		set
		{
			string text = value;
			if (text.Length > 0)
			{
				if (text[0] != '=')
				{
					text = global::_0005_2000._0002(1402769483) + text;
				}
				if (text.IndexOf(global::_0005_2000._0002(1402770355)) > -1 || text.IndexOf(global::_0005_2000._0002(1402770363)) > -1 || text.IndexOf(global::_0005_2000._0002(1402770339)) > -1)
				{
					text = global::_0005_2000._0002(1402765371) + text;
				}
			}
			XmlAttribute xmlAttribute = _0003.Attributes[global::_0005_2000._0002(1402769503)];
			if (xmlAttribute == null)
			{
				xmlAttribute = _0002.CreateAttribute(global::_0005_2000._0002(1402769503));
				_0003.Attributes.Append(xmlAttribute);
			}
			_0008 = global::_0003_2000._0006(text);
			xmlAttribute.InnerText = _0008;
		}
	}

	public Border Border
	{
		get
		{
			if (_0006 == null)
			{
				_0006 = new Border(_0002, _0003);
			}
			return _0006;
		}
	}

	public Color BackColor
	{
		set
		{
			_000E = ColorTranslator.ToOle(value);
			XmlAttribute xmlAttribute = _0003.Attributes[global::_0005_2000._0002(1402770347)];
			if (xmlAttribute == null)
			{
				xmlAttribute = _0002.CreateAttribute(global::_0005_2000._0002(1402770347));
				_0003.Attributes.Append(xmlAttribute);
			}
			xmlAttribute.InnerText = _000E.ToString();
		}
	}

	public Color ForeColor
	{
		set
		{
			_000F = ColorTranslator.ToOle(value);
			XmlAttribute xmlAttribute = _0003.Attributes[global::_0005_2000._0002(1402770331)];
			if (xmlAttribute == null)
			{
				xmlAttribute = _0002.CreateAttribute(global::_0005_2000._0002(1402770331));
				_0003.Attributes.Append(xmlAttribute);
			}
			xmlAttribute.InnerText = _000F.ToString();
		}
	}

	public bool ReadOnly
	{
		get
		{
			return _0002_2000;
		}
		set
		{
			_0002_2000 = value;
			XmlAttribute xmlAttribute = _0003.Attributes[global::_0005_2000._0002(1402770315)];
			if (xmlAttribute == null)
			{
				xmlAttribute = _0002.CreateAttribute(global::_0005_2000._0002(1402770315));
				_0003.Attributes.Append(xmlAttribute);
			}
			xmlAttribute.InnerText = _0002_2000.ToString();
		}
	}

	public string SubmitName
	{
		get
		{
			return _0003_2001;
		}
		set
		{
			string text = value;
			if (text != string.Empty)
			{
				if (ExcelRect.LooklikeCellAddress(text))
				{
					throw new Exception(global::_0005_2000._0002(1402770424));
				}
				if (_0003_2000.Count > 0)
				{
					for (int num = _0003_2000.Count - 1; num >= 0; num--)
					{
						Cell cell = (Cell)_0003_2000[num];
						if (cell._000F_2000 != _000F_2000)
						{
							if (cell._0003_2001 == text)
							{
								throw new Exception(global::_0005_2000._0002(1402770237) + cell._0003_2001 + global::_0005_2000._0002(1402770180));
							}
						}
						else
						{
							if (cell._0003_2001 == text)
							{
								text = string.Empty;
								break;
							}
							if (cell._0003_2001 != string.Empty)
							{
								throw new Exception(global::_0005_2000._0002(1402770255) + cell._0003_2001 + global::_0005_2000._0002(1402770050));
							}
						}
					}
				}
			}
			if (text != string.Empty)
			{
				XmlAttribute xmlAttribute = _0003.Attributes[global::_0005_2000._0002(1402768264)];
				if (xmlAttribute == null)
				{
					xmlAttribute = _0002.CreateAttribute(global::_0005_2000._0002(1402768264));
					_0003.Attributes.Append(xmlAttribute);
				}
				_0003_2001 = text;
				xmlAttribute.InnerText = global::_0003_2000._0006(text);
			}
		}
	}

	public Font Font
	{
		get
		{
			if (_0005_2000 == null)
			{
				_0005_2000 = new Font(_0002, _0003);
			}
			return _0005_2000;
		}
	}

	public XlHAlign HorizontalAlignment
	{
		set
		{
			_0008_2000 = value;
			XmlAttribute xmlAttribute = _0003.Attributes[global::_0005_2000._0002(1402770143)];
			if (xmlAttribute == null)
			{
				xmlAttribute = _0002.CreateAttribute(global::_0005_2000._0002(1402770143));
				_0003.Attributes.Append(xmlAttribute);
			}
			XmlAttribute xmlAttribute2 = xmlAttribute;
			int num = (int)_0008_2000;
			xmlAttribute2.InnerText = num.ToString();
		}
	}

	public XlVAlign VerticalAlignment
	{
		set
		{
			_0006_2000 = value;
			XmlAttribute xmlAttribute = _0003.Attributes[global::_0005_2000._0002(1402770122)];
			if (xmlAttribute == null)
			{
				xmlAttribute = _0002.CreateAttribute(global::_0005_2000._0002(1402770122));
				_0003.Attributes.Append(xmlAttribute);
			}
			XmlAttribute xmlAttribute2 = xmlAttribute;
			int num = (int)_0006_2000;
			xmlAttribute2.InnerText = num.ToString();
		}
	}

	public string NumberFormatLocal
	{
		set
		{
			_000E_2000 = value;
			XmlAttribute xmlAttribute = _0003.Attributes[global::_0005_2000._0002(1402769977)];
			if (xmlAttribute == null)
			{
				xmlAttribute = _0002.CreateAttribute(global::_0005_2000._0002(1402769977));
				_0003.Attributes.Append(xmlAttribute);
			}
			xmlAttribute.InnerText = global::_0003_2000._0006(_000E_2000);
		}
	}

	internal Cell(XmlDocument _0002, XmlNode _0003, string _0005, ArrayList _0008)
	{
		_0003_2000 = _0008;
		this._0002 = _0002;
		_000F_2000 = _0005;
		_0002_2001 = string.Empty;
		_0003_2001 = string.Empty;
		this._0005 = string.Empty;
		this._0008 = string.Empty;
		_0006 = null;
		_000E = 0;
		_000F = 0;
		_0002_2000 = false;
		_0005_2000 = null;
		_0008_2000 = (XlHAlign)0;
		_0006_2000 = (XlVAlign)0;
		_000E_2000 = string.Empty;
		this._0003 = this._0002.CreateElement(global::_0005_2000._0002(1402767469));
		_0003.AppendChild(this._0003);
		XmlAttribute xmlAttribute = this._0002.CreateAttribute(global::_0005_2000._0002(1402767411));
		xmlAttribute.InnerText = _0005;
		this._0003.Attributes.Append(xmlAttribute);
		this._0003.InnerText = string.Empty;
	}

	internal Cell(XmlDocument _0002, XmlNode _0003, ArrayList _0005, string _0008)
	{
		_0003_2000 = _0005;
		this._0002 = _0002;
		_000F_2000 = string.Empty;
		_0002_2001 = _0008;
		_0003_2001 = string.Empty;
		this._0005 = string.Empty;
		this._0008 = string.Empty;
		_0006 = null;
		_000E = 0;
		_000F = 0;
		_0002_2000 = false;
		_0005_2000 = null;
		_0008_2000 = (XlHAlign)0;
		_0006_2000 = (XlVAlign)0;
		_000E_2000 = string.Empty;
		this._0003 = this._0002.CreateElement(global::_0005_2000._0002(1402767469));
		_0003.AppendChild(this._0003);
		XmlAttribute xmlAttribute = this._0002.CreateAttribute(global::_0005_2000._0002(1402769507));
		xmlAttribute.InnerText = global::_0003_2000._0006(_0008);
		this._0003.Attributes.Append(xmlAttribute);
		this._0003.InnerText = string.Empty;
	}
}
