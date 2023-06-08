using System.Drawing;
using System.Xml;

namespace PageOffice.WordWriter;

public class Shading
{
	private XmlDocument _0002;

	private XmlNode _0003;

	private int _0005;

	public Color BackgroundPatternColor
	{
		set
		{
			_0005 = ColorTranslator.ToOle(value);
			XmlAttribute xmlAttribute = _0003.Attributes[_0005_2000._0002(1402788790)];
			if (xmlAttribute == null)
			{
				xmlAttribute = _0002.CreateAttribute(_0005_2000._0002(1402788790));
				_0003.Attributes.Append(xmlAttribute);
			}
			xmlAttribute.InnerText = _0005.ToString();
		}
	}

	internal Shading(XmlDocument _0002, XmlNode _0003)
	{
		this._0002 = _0002;
		_0005 = 0;
		this._0003 = this._0002.CreateElement(_0005_2000._0002(1402787912));
		_0003.AppendChild(this._0003);
	}
}
