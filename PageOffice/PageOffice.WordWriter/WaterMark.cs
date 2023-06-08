using System;
using System.IO;
using System.Xml;

namespace PageOffice.WordWriter;

public class WaterMark
{
	private XmlDocument _0002;

	private XmlNode _0003;

	private string _0005;

	public string Text
	{
		set
		{
			_0005 = value;
			XmlAttribute xmlAttribute = _0003.Attributes[_0005_2000._0002(1402788499)];
			if (xmlAttribute == null)
			{
				xmlAttribute = _0002.CreateAttribute(_0005_2000._0002(1402788499));
				_0003.Attributes.Append(xmlAttribute);
			}
			xmlAttribute.InnerText = _0003_2000._0006(_0005);
		}
	}

	internal WaterMark(XmlDocument _0002)
	{
		this._0002 = _0002;
		_0005 = string.Empty;
		_0003 = this._0002.CreateElement(_0005_2000._0002(1402788515));
		XmlNode documentElement = this._0002.DocumentElement;
		documentElement.AppendChild(_0003);
	}

	public void SetImage(string strFileURL)
	{
		string text = strFileURL;
		if (!text.Equals(string.Empty))
		{
			int num = text.IndexOf(_0005_2000._0002(1402774604));
			if (num > -1)
			{
				if (!File.Exists(text))
				{
					throw new Exception(_0005_2000._0002(1402775479) + text + _0005_2000._0002(1402775470));
				}
				strFileURL = text.Substring(text.LastIndexOf(_0005_2000._0002(1402775274)) + 1);
				string text2 = _0003_2000._0002(_0005_2000._0002(1402775250) + text + _0005_2000._0002(1402775262) + strFileURL);
				text2 = text2.Replace(_0005_2000._0002(1402775060), _0005_2000._0002(1402775068)).Replace(_0005_2000._0002(1402775047), _0005_2000._0002(1402775055)).Replace(_0005_2000._0002(1402769483), _0005_2000._0002(1402775158));
				text = _0005_2000._0002(1402789510) + text2;
			}
		}
		XmlAttribute xmlAttribute = _0003.Attributes[_0005_2000._0002(1402788508)];
		if (xmlAttribute == null)
		{
			xmlAttribute = _0002.CreateAttribute(_0005_2000._0002(1402788508));
			_0003.Attributes.Append(xmlAttribute);
		}
		xmlAttribute.InnerText = _0003_2000._0006(text);
	}
}
