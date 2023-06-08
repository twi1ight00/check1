using System;
using System.Collections;
using System.Text;
using System.Xml;

namespace PageOffice.ExcelWriter;

public sealed class Workbook
{
	private XmlDocument m__0002;

	private ArrayList _0003;

	private bool _0005;

	private bool _0008;

	private bool _0006;

	public bool DisableSheetDoubleClick
	{
		set
		{
			XmlNode documentElement = this.m__0002.DocumentElement;
			XmlAttribute xmlAttribute = this.m__0002.CreateAttribute(_0005_2000._0002(1402773036));
			if (value)
			{
				xmlAttribute.InnerText = _0005_2000._0002(1402772881);
			}
			else
			{
				xmlAttribute.InnerText = _0005_2000._0002(1402773002);
			}
			documentElement.Attributes.Append(xmlAttribute);
			_0005 = value;
		}
	}

	public bool DisableSheetRightClick
	{
		set
		{
			XmlNode documentElement = this.m__0002.DocumentElement;
			XmlAttribute xmlAttribute = this.m__0002.CreateAttribute(_0005_2000._0002(1402773110));
			if (value)
			{
				xmlAttribute.InnerText = _0005_2000._0002(1402772881);
			}
			else
			{
				xmlAttribute.InnerText = _0005_2000._0002(1402773002);
			}
			documentElement.Attributes.Append(xmlAttribute);
			_0008 = value;
		}
	}

	public bool DisableSheetSelection
	{
		set
		{
			XmlNode documentElement = this.m__0002.DocumentElement;
			XmlAttribute xmlAttribute = this.m__0002.CreateAttribute(_0005_2000._0002(1402773077));
			if (value)
			{
				xmlAttribute.InnerText = _0005_2000._0002(1402772881);
			}
			else
			{
				xmlAttribute.InnerText = _0005_2000._0002(1402773002);
			}
			documentElement.Attributes.Append(xmlAttribute);
			_0006 = value;
		}
	}

	public Workbook()
	{
		_0005 = false;
		_0008 = false;
		_0006 = false;
		this.m__0002 = new XmlDocument();
		StringBuilder stringBuilder = new StringBuilder(_0005_2000._0002(1402773238));
		stringBuilder.Append(_0005_2000._0002(1402773189));
		stringBuilder.Append(_0005_2000._0002(1402773049));
		this.m__0002.LoadXml(stringBuilder.ToString());
		_0003 = new ArrayList();
	}

	internal string _0002()
	{
		string text = this.m__0002.InnerXml;
		if (text != string.Empty)
		{
			text = _0005_2000._0002(1402771889) + _0003_2000._0002(text) + _0005_2000._0002(1402771936);
		}
		return text;
	}

	public Sheet OpenSheet(string SheetName)
	{
		if (SheetName == null || SheetName.Length < 1)
		{
			throw new Exception(_0005_2000._0002(1402769837));
		}
		string text = _0003_2000._0006(SheetName);
		if (_0003.Count > 0)
		{
			for (int num = _0003.Count - 1; num >= 0; num--)
			{
				Sheet sheet = (Sheet)_0003[num];
				if (sheet._0002_2000 == text)
				{
					return sheet;
				}
			}
		}
		Sheet sheet2 = new Sheet(this.m__0002, text);
		_0003.Add(sheet2);
		return sheet2;
	}

	public Sheet CreateSheet(string NewSheetName, SheetInsertType InsertType, string RelativeSheetName)
	{
		if (NewSheetName == null || NewSheetName.Length < 1)
		{
			throw new Exception(_0005_2000._0002(1402771949));
		}
		if (RelativeSheetName == null || RelativeSheetName.Length < 1)
		{
			throw new Exception(_0005_2000._0002(1402771770));
		}
		if (NewSheetName == RelativeSheetName)
		{
			throw new Exception(_0005_2000._0002(1402771829));
		}
		string text = _0003_2000._0006(NewSheetName);
		if (_0003.Count > 0)
		{
			for (int num = _0003.Count - 1; num >= 0; num--)
			{
				Sheet sheet = (Sheet)_0003[num];
				if (sheet._0002_2000 == text)
				{
					return sheet;
				}
			}
		}
		Sheet sheet2 = new Sheet(this.m__0002, text);
		sheet2._0002(InsertType, RelativeSheetName);
		_0003.Add(sheet2);
		return sheet2;
	}
}
