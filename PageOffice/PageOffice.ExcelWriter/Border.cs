using System.Drawing;
using System.Xml;

namespace PageOffice.ExcelWriter;

public class Border
{
	private XmlNode _0002;

	private int _0003;

	private int _0005;

	private int _0008;

	private int _0006;

	public XlBorderType BorderType
	{
		set
		{
			_0003 = (int)value;
			XmlAttribute xmlAttribute = _0002.Attributes[_0005_2000._0002(1402769455)];
			xmlAttribute.InnerText = _0003.ToString();
		}
	}

	public XlBorderLineStyle LineStyle
	{
		set
		{
			_0005 = (int)value;
			XmlAttribute xmlAttribute = _0002.Attributes[_0005_2000._0002(1402769432)];
			xmlAttribute.InnerText = _0005.ToString();
		}
	}

	public XlBorderWeight Weight
	{
		set
		{
			_0008 = (int)value;
			XmlAttribute xmlAttribute = _0002.Attributes[_0005_2000._0002(1402769416)];
			xmlAttribute.InnerText = _0008.ToString();
		}
	}

	public Color LineColor
	{
		set
		{
			_0006 = ColorTranslator.ToOle(value);
			XmlAttribute xmlAttribute = _0002.Attributes[_0005_2000._0002(1402769527)];
			xmlAttribute.InnerText = _0006.ToString();
		}
	}

	internal Border(XmlDocument _0002, XmlNode _0003)
	{
		this._0003 = 1;
		_0008 = 2;
		_0006 = -1;
		_0005 = 1;
		this._0002 = _0002.CreateElement(_0005_2000._0002(1402769440));
		_0003.AppendChild(this._0002);
		XmlAttribute xmlAttribute = _0002.CreateAttribute(_0005_2000._0002(1402769455));
		xmlAttribute.InnerText = this._0003.ToString();
		this._0002.Attributes.Append(xmlAttribute);
		xmlAttribute = _0002.CreateAttribute(_0005_2000._0002(1402769432));
		xmlAttribute.InnerText = _0005.ToString();
		this._0002.Attributes.Append(xmlAttribute);
		xmlAttribute = _0002.CreateAttribute(_0005_2000._0002(1402769416));
		xmlAttribute.InnerText = _0008.ToString();
		this._0002.Attributes.Append(xmlAttribute);
		xmlAttribute = _0002.CreateAttribute(_0005_2000._0002(1402769527));
		xmlAttribute.InnerText = _0006.ToString();
		this._0002.Attributes.Append(xmlAttribute);
	}
}
