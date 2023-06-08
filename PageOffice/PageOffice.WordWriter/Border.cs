using System.Drawing;
using System.Xml;

namespace PageOffice.WordWriter;

public class Border
{
	private XmlNode _0002;

	private int _0003;

	private int _0005;

	private int _0008;

	private int _0006;

	public WdBorderType BorderType
	{
		set
		{
			_0003 = (int)value;
			XmlAttribute xmlAttribute = _0002.Attributes[_0005_2000._0002(1402769455)];
			xmlAttribute.InnerText = _0003.ToString();
		}
	}

	public WdLineStyle LineStyle
	{
		set
		{
			_0005 = (int)value;
			XmlAttribute xmlAttribute = _0002.Attributes[_0005_2000._0002(1402769432)];
			xmlAttribute.InnerText = _0005.ToString();
		}
	}

	public WdLineWidth LineWidth
	{
		set
		{
			_0008 = (int)value;
			XmlAttribute xmlAttribute = _0002.Attributes[_0005_2000._0002(1402789538)];
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
		_0008 = 3;
		_0005 = 1;
		this._0002 = _0002.CreateElement(_0005_2000._0002(1402769440));
		_0003.AppendChild(this._0002);
		XmlAttribute xmlAttribute = _0002.CreateAttribute(_0005_2000._0002(1402769455));
		xmlAttribute.InnerText = this._0003.ToString();
		this._0002.Attributes.Append(xmlAttribute);
		xmlAttribute = _0002.CreateAttribute(_0005_2000._0002(1402769432));
		xmlAttribute.InnerText = _0005.ToString();
		this._0002.Attributes.Append(xmlAttribute);
		xmlAttribute = _0002.CreateAttribute(_0005_2000._0002(1402789538));
		xmlAttribute.InnerText = _0008.ToString();
		this._0002.Attributes.Append(xmlAttribute);
		xmlAttribute = _0002.CreateAttribute(_0005_2000._0002(1402769527));
		xmlAttribute.InnerText = _0006.ToString();
		this._0002.Attributes.Append(xmlAttribute);
	}
}
