using System;
using System.Xml;

namespace PageOffice.WordWriter;

public class Template
{
	private XmlDocument _0002;

	private XmlNode _0003;

	internal Template(XmlDocument _0002)
	{
		this._0002 = _0002;
		_0003 = this._0002.CreateElement(_0005_2000._0002(1402788622));
		XmlNode documentElement = this._0002.DocumentElement;
		documentElement.AppendChild(_0003);
	}

	public void DefineDataRegion(string Name, string Caption)
	{
		string innerText = _0003_2000._0006(Name);
		string innerText2 = _0003_2000._0006(Caption);
		XmlNode xmlNode = _0002.CreateElement(_0005_2000._0002(1402788735));
		_0003.AppendChild(xmlNode);
		XmlAttribute xmlAttribute = _0002.CreateAttribute(_0005_2000._0002(1402767411));
		xmlAttribute.InnerText = innerText;
		xmlNode.Attributes.Append(xmlAttribute);
		xmlAttribute = _0002.CreateAttribute(_0005_2000._0002(1402766857));
		xmlAttribute.InnerText = innerText2;
		xmlNode.Attributes.Append(xmlAttribute);
	}

	public void DefineDataTag(string Name)
	{
		if (Name != null && Name.IndexOf(';') < 0)
		{
			string innerText = _0003_2000._0006(Name);
			XmlNode xmlNode = _0002.CreateElement(_0005_2000._0002(1402788692));
			_0003.AppendChild(xmlNode);
			XmlAttribute xmlAttribute = _0002.CreateAttribute(_0005_2000._0002(1402767411));
			xmlAttribute.InnerText = innerText;
			xmlNode.Attributes.Append(xmlAttribute);
			return;
		}
		throw new Exception(_0005_2000._0002(1402788680));
	}
}
