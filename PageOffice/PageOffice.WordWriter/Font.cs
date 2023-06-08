using System.Drawing;
using System.Xml;

namespace PageOffice.WordWriter;

public class Font
{
	private XmlDocument _0002;

	private XmlNode _0003;

	private string _0005;

	private string _0008;

	private int _0006;

	private float _000E;

	private bool _000F;

	private bool _0002_2000;

	private WdUnderline _0003_2000;

	private bool _0005_2000;

	private bool _0008_2000;

	public string Name
	{
		set
		{
			_0005 = value;
			XmlAttribute xmlAttribute = _0003.Attributes[global::_0005_2000._0002(1402767411)];
			if (xmlAttribute == null)
			{
				xmlAttribute = _0002.CreateAttribute(global::_0005_2000._0002(1402767411));
				_0003.Attributes.Append(xmlAttribute);
			}
			xmlAttribute.InnerText = global::_0003_2000._0006(_0005);
		}
	}

	public string NameAscii
	{
		set
		{
			_0008 = value;
			XmlAttribute xmlAttribute = _0003.Attributes[global::_0005_2000._0002(1402788068)];
			if (xmlAttribute == null)
			{
				xmlAttribute = _0002.CreateAttribute(global::_0005_2000._0002(1402788068));
				_0003.Attributes.Append(xmlAttribute);
			}
			xmlAttribute.InnerText = _0008;
		}
	}

	public Color Color
	{
		set
		{
			_0006 = ColorTranslator.ToOle(value);
			XmlAttribute xmlAttribute = _0003.Attributes[global::_0005_2000._0002(1402769527)];
			if (xmlAttribute == null)
			{
				xmlAttribute = _0002.CreateAttribute(global::_0005_2000._0002(1402769527));
				_0003.Attributes.Append(xmlAttribute);
			}
			xmlAttribute.InnerText = _0006.ToString();
		}
	}

	public float Size
	{
		set
		{
			_000E = value;
			XmlAttribute xmlAttribute = _0003.Attributes[global::_0005_2000._0002(1402769933)];
			if (xmlAttribute == null)
			{
				xmlAttribute = _0002.CreateAttribute(global::_0005_2000._0002(1402769933));
				_0003.Attributes.Append(xmlAttribute);
			}
			xmlAttribute.InnerText = _000E.ToString();
		}
	}

	public bool Bold
	{
		set
		{
			_000F = value;
			XmlAttribute xmlAttribute = _0003.Attributes[global::_0005_2000._0002(1402770038)];
			if (xmlAttribute == null)
			{
				xmlAttribute = _0002.CreateAttribute(global::_0005_2000._0002(1402770038));
				_0003.Attributes.Append(xmlAttribute);
			}
			xmlAttribute.InnerText = (_000F ? global::_0005_2000._0002(1402770027) : global::_0005_2000._0002(1402770019));
		}
	}

	public bool Italic
	{
		set
		{
			_0002_2000 = value;
			XmlAttribute xmlAttribute = _0003.Attributes[global::_0005_2000._0002(1402770003)];
			if (xmlAttribute == null)
			{
				xmlAttribute = _0002.CreateAttribute(global::_0005_2000._0002(1402770003));
				_0003.Attributes.Append(xmlAttribute);
			}
			xmlAttribute.InnerText = (_0002_2000 ? global::_0005_2000._0002(1402770027) : global::_0005_2000._0002(1402770019));
		}
	}

	public WdUnderline Underline
	{
		set
		{
			_0003_2000 = value;
			XmlAttribute xmlAttribute = _0003.Attributes[global::_0005_2000._0002(1402788052)];
			if (xmlAttribute == null)
			{
				xmlAttribute = _0002.CreateAttribute(global::_0005_2000._0002(1402788052));
				_0003.Attributes.Append(xmlAttribute);
			}
			XmlAttribute xmlAttribute2 = xmlAttribute;
			int num = (int)_0003_2000;
			xmlAttribute2.InnerText = num.ToString();
		}
	}

	public bool StrikeThrough
	{
		set
		{
			_0005_2000 = value;
			XmlAttribute xmlAttribute = _0003.Attributes[global::_0005_2000._0002(1402788036)];
			if (xmlAttribute == null)
			{
				xmlAttribute = _0002.CreateAttribute(global::_0005_2000._0002(1402788036));
				_0003.Attributes.Append(xmlAttribute);
			}
			xmlAttribute.InnerText = (_0005_2000 ? global::_0005_2000._0002(1402770027) : global::_0005_2000._0002(1402770019));
		}
	}

	public bool Shadow
	{
		set
		{
			_0008_2000 = value;
			XmlAttribute xmlAttribute = _0003.Attributes[global::_0005_2000._0002(1402787896)];
			if (xmlAttribute == null)
			{
				xmlAttribute = _0002.CreateAttribute(global::_0005_2000._0002(1402787896));
				_0003.Attributes.Append(xmlAttribute);
			}
			xmlAttribute.InnerText = (_0008_2000 ? global::_0005_2000._0002(1402770027) : global::_0005_2000._0002(1402770019));
		}
	}

	internal Font(XmlDocument _0002, XmlNode _0003)
	{
		this._0002 = _0002;
		_0005 = string.Empty;
		_0008 = string.Empty;
		_0006 = 0;
		_000E = 0f;
		_000F = false;
		_0002_2000 = false;
		_0003_2000 = WdUnderline.wdUnderlineSingle;
		_0005_2000 = false;
		_0008_2000 = false;
		this._0003 = this._0002.CreateElement(global::_0005_2000._0002(1402769920));
		_0003.AppendChild(this._0003);
	}
}
