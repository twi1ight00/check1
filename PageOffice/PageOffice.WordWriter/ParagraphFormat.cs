using System.Xml;

namespace PageOffice.WordWriter;

public class ParagraphFormat
{
	private XmlDocument _0002;

	private XmlNode _0003;

	private WdLineSpacing _0005;

	private float _0008;

	private WdParagraphAlignment _0006;

	public WdLineSpacing LineSpacingRule
	{
		set
		{
			_0005 = value;
			XmlAttribute xmlAttribute = _0003.Attributes[_0005_2000._0002(1402787869)];
			if (xmlAttribute == null)
			{
				xmlAttribute = _0002.CreateAttribute(_0005_2000._0002(1402787869));
				_0003.Attributes.Append(xmlAttribute);
			}
			XmlAttribute xmlAttribute2 = xmlAttribute;
			int num = (int)_0005;
			xmlAttribute2.InnerText = num.ToString();
		}
	}

	public float FirstLineIndent
	{
		set
		{
			_0008 = value;
			XmlAttribute xmlAttribute = _0003.Attributes[_0005_2000._0002(1402787955)];
			if (xmlAttribute == null)
			{
				xmlAttribute = _0002.CreateAttribute(_0005_2000._0002(1402787955));
				_0003.Attributes.Append(xmlAttribute);
			}
			xmlAttribute.InnerText = _0008.ToString();
		}
	}

	public WdParagraphAlignment Alignment
	{
		set
		{
			_0006 = value;
			XmlAttribute xmlAttribute = _0003.Attributes[_0005_2000._0002(1402787945)];
			if (xmlAttribute == null)
			{
				xmlAttribute = _0002.CreateAttribute(_0005_2000._0002(1402787945));
				_0003.Attributes.Append(xmlAttribute);
			}
			XmlAttribute xmlAttribute2 = xmlAttribute;
			int num = (int)_0006;
			xmlAttribute2.InnerText = num.ToString();
		}
	}

	internal ParagraphFormat(XmlDocument _0002, XmlNode _0003)
	{
		this._0002 = _0002;
		_0005 = WdLineSpacing.wdLineSpaceSingle;
		_0008 = 0f;
		_0006 = WdParagraphAlignment.wdAlignParagraphLeft;
		this._0003 = this._0002.CreateElement(_0005_2000._0002(1402787879));
		_0003.AppendChild(this._0003);
	}
}
