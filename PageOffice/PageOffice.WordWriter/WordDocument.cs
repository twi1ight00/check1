using System;
using System.Collections;
using System.Text;
using System.Xml;

namespace PageOffice.WordWriter;

public sealed class WordDocument
{
	private XmlDocument m__0002;

	private ArrayList _0003;

	private ArrayList _0005;

	private bool _0008;

	private bool _0006;

	private bool _000E;

	private bool _000F;

	private WaterMark _0002_2000;

	private Template _0003_2000;

	private bool _0005_2000;

	public bool DisableWindowDoubleClick
	{
		set
		{
			XmlNode documentElement = this.m__0002.DocumentElement;
			XmlAttribute xmlAttribute = this.m__0002.CreateAttribute(global::_0005_2000._0002(1402788561));
			if (value)
			{
				xmlAttribute.InnerText = global::_0005_2000._0002(1402772881);
			}
			else
			{
				xmlAttribute.InnerText = global::_0005_2000._0002(1402773002);
			}
			documentElement.Attributes.Append(xmlAttribute);
			_0008 = value;
		}
	}

	public bool DisableWindowRightClick
	{
		set
		{
			XmlNode documentElement = this.m__0002.DocumentElement;
			XmlAttribute xmlAttribute = this.m__0002.CreateAttribute(global::_0005_2000._0002(1402788558));
			if (value)
			{
				xmlAttribute.InnerText = global::_0005_2000._0002(1402772881);
			}
			else
			{
				xmlAttribute.InnerText = global::_0005_2000._0002(1402773002);
			}
			documentElement.Attributes.Append(xmlAttribute);
			_0006 = value;
		}
	}

	public bool DisableWindowSelection
	{
		set
		{
			XmlNode documentElement = this.m__0002.DocumentElement;
			XmlAttribute xmlAttribute = this.m__0002.CreateAttribute(global::_0005_2000._0002(1402788396));
			if (value)
			{
				xmlAttribute.InnerText = global::_0005_2000._0002(1402772881);
			}
			else
			{
				xmlAttribute.InnerText = global::_0005_2000._0002(1402773002);
			}
			documentElement.Attributes.Append(xmlAttribute);
			_000E = value;
		}
	}

	public bool EnableAllDataRegionsEditing
	{
		set
		{
			XmlNode documentElement = this.m__0002.DocumentElement;
			XmlAttribute xmlAttribute = this.m__0002.CreateAttribute(global::_0005_2000._0002(1402788363));
			if (value)
			{
				xmlAttribute.InnerText = global::_0005_2000._0002(1402772881);
			}
			else
			{
				xmlAttribute.InnerText = global::_0005_2000._0002(1402773002);
			}
			documentElement.Attributes.Append(xmlAttribute);
			_000F = value;
		}
	}

	public WaterMark WaterMark
	{
		get
		{
			if (_0002_2000 == null)
			{
				_0002_2000 = new WaterMark(this.m__0002);
			}
			return _0002_2000;
		}
	}

	public Template Template
	{
		get
		{
			if (_0003_2000 == null)
			{
				_0003_2000 = new Template(this.m__0002);
			}
			return _0003_2000;
		}
	}

	public bool SaveEditedDROnly
	{
		set
		{
			XmlNode documentElement = this.m__0002.DocumentElement;
			XmlAttribute xmlAttribute = this.m__0002.CreateAttribute(global::_0005_2000._0002(1402788461));
			if (value)
			{
				xmlAttribute.InnerText = global::_0005_2000._0002(1402772881);
			}
			else
			{
				xmlAttribute.InnerText = global::_0005_2000._0002(1402773002);
			}
			documentElement.Attributes.Append(xmlAttribute);
			_0005_2000 = value;
		}
	}

	public WordDocument()
	{
		_0008 = false;
		_0006 = false;
		_000E = false;
		_000F = false;
		_0002_2000 = null;
		_0003_2000 = null;
		_0005_2000 = false;
		this.m__0002 = new XmlDocument();
		StringBuilder stringBuilder = new StringBuilder(global::_0005_2000._0002(1402773238));
		stringBuilder.Append(global::_0005_2000._0002(1402788488));
		stringBuilder.Append(global::_0005_2000._0002(1402788605));
		this.m__0002.LoadXml(stringBuilder.ToString());
		_0003 = new ArrayList();
		_0005 = new ArrayList();
	}

	internal string _0002()
	{
		string text = this.m__0002.InnerXml;
		if (text != string.Empty)
		{
			text = global::_0005_2000._0002(1402788418) + global::_0003_2000._0002(text) + global::_0005_2000._0002(1402771936);
		}
		return text;
	}

	public DataRegion OpenDataRegion(string DataRegionName)
	{
		if (DataRegionName == null || DataRegionName.Length < 1)
		{
			throw new Exception(global::_0005_2000._0002(1402789649));
		}
		if (DataRegionName.ToUpper().IndexOf(global::_0005_2000._0002(1402791413)) > -1)
		{
			throw new Exception(global::_0005_2000._0002(1402791392));
		}
		if (DataRegionName.ToUpper().IndexOf(global::_0005_2000._0002(1402791175)) > -1)
		{
			throw new Exception(global::_0005_2000._0002(1402791283));
		}
		if (!DataRegionName.StartsWith(global::_0005_2000._0002(1402789730)))
		{
			DataRegionName = global::_0005_2000._0002(1402789730) + DataRegionName;
		}
		string text = global::_0003_2000._0006(DataRegionName);
		if (_0003.Count > 0)
		{
			for (int num = _0003.Count - 1; num >= 0; num--)
			{
				DataRegion dataRegion = (DataRegion)_0003[num];
				if (dataRegion._0005_2000 == text)
				{
					return dataRegion;
				}
			}
		}
		DataRegion dataRegion2 = new DataRegion(this.m__0002, text);
		_0003.Add(dataRegion2);
		return dataRegion2;
	}

	public DataRegion CreateDataRegion(string NewDataRegionName, DataRegionInsertType InsertType, string RelativeDataRegionName)
	{
		if (NewDataRegionName == null || NewDataRegionName.Length < 1)
		{
			throw new Exception(global::_0005_2000._0002(1402791058));
		}
		if (RelativeDataRegionName == null || RelativeDataRegionName.Length < 1)
		{
			throw new Exception(global::_0005_2000._0002(1402791149));
		}
		if (NewDataRegionName.ToUpper().IndexOf(global::_0005_2000._0002(1402791413)) > -1)
		{
			throw new Exception(global::_0005_2000._0002(1402790958) + NewDataRegionName + global::_0005_2000._0002(1402790999));
		}
		if (NewDataRegionName.ToUpper().IndexOf(global::_0005_2000._0002(1402791175)) > -1)
		{
			throw new Exception(global::_0005_2000._0002(1402790984) + NewDataRegionName + global::_0005_2000._0002(1402790999));
		}
		if (!NewDataRegionName.StartsWith(global::_0005_2000._0002(1402789730)))
		{
			NewDataRegionName = global::_0005_2000._0002(1402789730) + NewDataRegionName;
		}
		if (!RelativeDataRegionName.StartsWith(global::_0005_2000._0002(1402789730)))
		{
			RelativeDataRegionName = global::_0005_2000._0002(1402789730) + RelativeDataRegionName;
		}
		string text = global::_0003_2000._0006(NewDataRegionName);
		if (_0003.Count > 0)
		{
			for (int num = _0003.Count - 1; num >= 0; num--)
			{
				DataRegion dataRegion = (DataRegion)_0003[num];
				if (dataRegion._0005_2000 == text)
				{
					throw new Exception(global::_0005_2000._0002(1402791823) + NewDataRegionName + global::_0005_2000._0002(1402791908));
				}
			}
		}
		string text2 = global::_0003_2000._0006(RelativeDataRegionName);
		DataRegion dataRegion2 = new DataRegion(this.m__0002, text);
		dataRegion2._0002(InsertType, text2);
		_0003.Add(dataRegion2);
		return dataRegion2;
	}

	public DataTag OpenDataTag(string DataTagName)
	{
		if (DataTagName == null || DataTagName.Length < 1)
		{
			throw new Exception(global::_0005_2000._0002(1402791735));
		}
		string text = global::_0003_2000._0006(DataTagName);
		if (_0005.Count > 0)
		{
			for (int num = _0005.Count - 1; num >= 0; num--)
			{
				DataTag dataTag = (DataTag)_0005[num];
				if (dataTag._0002_2000 == text)
				{
					return dataTag;
				}
			}
		}
		DataTag dataTag2 = new DataTag(this.m__0002, text);
		_0005.Add(dataTag2);
		return dataTag2;
	}

	public void InsertPageBreak()
	{
		XmlNode xmlNode = this.m__0002.CreateElement(global::_0005_2000._0002(1402789694));
		XmlNode documentElement = this.m__0002.DocumentElement;
		documentElement.AppendChild(xmlNode);
		XmlAttribute xmlAttribute = this.m__0002.CreateAttribute(global::_0005_2000._0002(1402767411));
		xmlAttribute.InnerText = global::_0003_2000._0006(global::_0005_2000._0002(1402791706));
		xmlNode.Attributes.Append(xmlAttribute);
	}
}
