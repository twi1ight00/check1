using System.Xml;

namespace PageOffice.ExcelWriter;

public class Font
{
	private XmlDocument _0002;

	private XmlNode _0003;

	private string _0005;

	private float _0008;

	private bool _0006;

	private bool _000E;

	public string Name
	{
		set
		{
			_0005 = value;
			XmlAttribute xmlAttribute = _0003.Attributes[_0005_2000._0002(1402767411)];
			if (xmlAttribute == null)
			{
				xmlAttribute = _0002.CreateAttribute(_0005_2000._0002(1402767411));
				_0003.Attributes.Append(xmlAttribute);
			}
			xmlAttribute.InnerText = _0003_2000._0006(_0005);
		}
	}

	public float Size
	{
		set
		{
			_0008 = value;
			XmlAttribute xmlAttribute = _0003.Attributes[_0005_2000._0002(1402769933)];
			if (xmlAttribute == null)
			{
				xmlAttribute = _0002.CreateAttribute(_0005_2000._0002(1402769933));
				_0003.Attributes.Append(xmlAttribute);
			}
			xmlAttribute.InnerText = _0008.ToString();
		}
	}

	public bool Bold
	{
		set
		{
			_0006 = value;
			XmlAttribute xmlAttribute = _0003.Attributes[_0005_2000._0002(1402770038)];
			if (xmlAttribute == null)
			{
				xmlAttribute = _0002.CreateAttribute(_0005_2000._0002(1402770038));
				_0003.Attributes.Append(xmlAttribute);
			}
			xmlAttribute.InnerText = (_0006 ? _0005_2000._0002(1402770027) : _0005_2000._0002(1402770019));
		}
	}

	public bool Italic
	{
		set
		{
			_000E = value;
			XmlAttribute xmlAttribute = _0003.Attributes[_0005_2000._0002(1402770003)];
			if (xmlAttribute == null)
			{
				xmlAttribute = _0002.CreateAttribute(_0005_2000._0002(1402770003));
				_0003.Attributes.Append(xmlAttribute);
			}
			xmlAttribute.InnerText = (_000E ? _0005_2000._0002(1402770027) : _0005_2000._0002(1402770019));
		}
	}

	internal Font(XmlDocument _0002, XmlNode _0003)
	{
		this._0002 = _0002;
		_0005 = string.Empty;
		_0008 = 0f;
		_0006 = false;
		_000E = false;
		this._0003 = this._0002.CreateElement(_0005_2000._0002(1402769920));
		_0003.AppendChild(this._0003);
	}
}
