using System;
using System.Collections;
using System.Xml;

namespace PageOffice.WordWriter;

public class DataTag
{
	private XmlDocument _0002;

	private XmlNode _0003;

	private string _0005;

	private ArrayList _0008;

	private Font _0006;

	private ParagraphFormat _000E;

	private Shading _000F;

	internal string _0002_2000;

	public string Name => _0003_2000._000E(_0002_2000);

	public string Value
	{
		set
		{
			if (_0008.Count > 0)
			{
				throw new Exception(_0005_2000._0002(1402788019));
			}
			if (value == string.Empty)
			{
				_0005 = _0005_2000._0002(1402769493);
			}
			else
			{
				_0005 = value;
			}
			_0005 = _0003_2000._0006(_0005);
			XmlAttribute xmlAttribute = _0003.Attributes[_0005_2000._0002(1402769503)];
			if (xmlAttribute == null)
			{
				xmlAttribute = _0002.CreateAttribute(_0005_2000._0002(1402769503));
				_0003.Attributes.Append(xmlAttribute);
			}
			xmlAttribute.InnerText = _0005;
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

	internal DataTag(XmlDocument _0002, string _0003)
	{
		this._0002 = _0002;
		_0002_2000 = _0003;
		_0005 = string.Empty;
		_0008 = new ArrayList();
		_0006 = null;
		_000E = null;
		_000F = null;
		this._0003 = this._0002.CreateElement(_0005_2000._0002(1402788165));
		XmlNode documentElement = this._0002.DocumentElement;
		documentElement.AppendChild(this._0003);
		XmlAttribute xmlAttribute = this._0002.CreateAttribute(_0005_2000._0002(1402767411));
		xmlAttribute.InnerText = _0003;
		this._0003.Attributes.Append(xmlAttribute);
	}
}
