using System.Xml;

namespace PageOffice.WordWriter;

public class Column
{
	private XmlDocument _0002;

	private XmlNode _0003;

	private int _0005;

	public int Index => _0005;

	internal Column(XmlDocument _0002, XmlNode _0003, int _0005)
	{
		this._0002 = _0002;
		this._0005 = _0005;
		this._0003 = this._0002.CreateElement(_0005_2000._0002(1402789418));
		_0003.AppendChild(this._0003);
		XmlAttribute xmlAttribute = this._0002.CreateAttribute(_0005_2000._0002(1402789197));
		xmlAttribute.InnerText = _0005.ToString();
		this._0003.Attributes.Append(xmlAttribute);
	}

	public void SetWidth(float ColumnWidth, WdRulerStyle RulerStyle)
	{
		XmlAttribute xmlAttribute = _0002.CreateAttribute(_0005_2000._0002(1402772728));
		xmlAttribute.InnerText = ColumnWidth.ToString();
		_0003.Attributes.Append(xmlAttribute);
		xmlAttribute = _0002.CreateAttribute(_0005_2000._0002(1402789401));
		XmlAttribute xmlAttribute2 = xmlAttribute;
		int num = (int)RulerStyle;
		xmlAttribute2.InnerText = num.ToString();
		_0003.Attributes.Append(xmlAttribute);
	}

	public void SetWidth(float ColumnWidth)
	{
		XmlAttribute xmlAttribute = _0002.CreateAttribute(_0005_2000._0002(1402772728));
		xmlAttribute.InnerText = ColumnWidth.ToString();
		_0003.Attributes.Append(xmlAttribute);
		xmlAttribute = _0002.CreateAttribute(_0005_2000._0002(1402789401));
		xmlAttribute.InnerText = 0.ToString();
		_0003.Attributes.Append(xmlAttribute);
	}
}
