using System;
using System.Collections;
using System.Drawing;
using System.Text;
using System.Xml;
using PageOffice.Utilities;

namespace PageOffice.ExcelWriter;

public class Table
{
	private XmlDocument _0002;

	private XmlNode _0003;

	private bool _0005;

	private ArrayList _0008;

	private StringBuilder _0006;

	private StringBuilder _000E;

	private int _000F;

	private StringBuilder _0002_2000;

	private int _0003_2000;

	private int _0005_2000;

	private _000F _0008_2000;

	private bool _0006_2000;

	private ExcelRect _000E_2000;

	private Border _000F_2000;

	private int _0002_2001;

	private int _0003_2001;

	private double _0005_2001;

	private double _0008_2001;

	private bool _0006_2001;

	private ArrayList _000E_2001;

	private Font _000F_2001;

	private XlHAlign _0002_2002;

	private XlVAlign _0003_2002;

	private string _0005_2002;

	internal string _0008_2002;

	internal string _0006_2002;

	internal string _000E_2002;

	public string RangeAddress => _0008_2002;

	public IDataFieldCollection DataFields
	{
		get
		{
			if (_0006_2000)
			{
				throw new Exception(global::_0005_2000._0002(1402770515));
			}
			return _0008_2000;
		}
	}

	public Border Border
	{
		get
		{
			if (_000F_2000 == null)
			{
				_000F_2000 = new Border(_0002, _0003);
			}
			return _000F_2000;
		}
	}

	public Color BackColor
	{
		set
		{
			_0002_2001 = ColorTranslator.ToOle(value);
			XmlAttribute xmlAttribute = _0003.Attributes[global::_0005_2000._0002(1402770347)];
			if (xmlAttribute == null)
			{
				xmlAttribute = _0002.CreateAttribute(global::_0005_2000._0002(1402770347));
				_0003.Attributes.Append(xmlAttribute);
			}
			xmlAttribute.InnerText = _0002_2001.ToString();
		}
	}

	public Color ForeColor
	{
		set
		{
			_0003_2001 = ColorTranslator.ToOle(value);
			XmlAttribute xmlAttribute = _0003.Attributes[global::_0005_2000._0002(1402770331)];
			if (xmlAttribute == null)
			{
				xmlAttribute = _0002.CreateAttribute(global::_0005_2000._0002(1402770331));
				_0003.Attributes.Append(xmlAttribute);
			}
			xmlAttribute.InnerText = _0003_2001.ToString();
		}
	}

	public double RowHeight
	{
		set
		{
			_0005_2001 = value;
			if (_0005_2001 > 0.0)
			{
				XmlAttribute xmlAttribute = _0003.Attributes[global::_0005_2000._0002(1402772616)];
				if (xmlAttribute == null)
				{
					xmlAttribute = _0002.CreateAttribute(global::_0005_2000._0002(1402772616));
					_0003.Attributes.Append(xmlAttribute);
				}
				xmlAttribute.InnerText = _0005_2001.ToString();
			}
		}
	}

	public double ColumnWidth
	{
		set
		{
			_0008_2001 = value;
			if (_0008_2001 > 0.0)
			{
				XmlAttribute xmlAttribute = _0003.Attributes[global::_0005_2000._0002(1402772728)];
				if (xmlAttribute == null)
				{
					xmlAttribute = _0002.CreateAttribute(global::_0005_2000._0002(1402772728));
					_0003.Attributes.Append(xmlAttribute);
				}
				xmlAttribute.InnerText = _0008_2001.ToString();
			}
		}
	}

	public bool ReadOnly
	{
		get
		{
			return _0006_2001;
		}
		set
		{
			_0006_2001 = value;
			XmlAttribute xmlAttribute = _0003.Attributes[global::_0005_2000._0002(1402770315)];
			if (xmlAttribute == null)
			{
				xmlAttribute = _0002.CreateAttribute(global::_0005_2000._0002(1402770315));
				_0003.Attributes.Append(xmlAttribute);
			}
			xmlAttribute.InnerText = _0006_2001.ToString();
		}
	}

	public string SubmitName
	{
		get
		{
			return _0006_2002;
		}
		set
		{
			string text = value;
			if (text != string.Empty)
			{
				if (ExcelRect.LooklikeRangeAddress(text))
				{
					throw new Exception(global::_0005_2000._0002(1402772714));
				}
				if (_000E_2001.Count > 0)
				{
					for (int num = _000E_2001.Count - 1; num >= 0; num--)
					{
						Table table = (Table)_000E_2001[num];
						if (table._0008_2002 != RangeAddress)
						{
							if (table._0006_2002 == text)
							{
								throw new Exception(global::_0005_2000._0002(1402770237) + table._0006_2002 + global::_0005_2000._0002(1402772499));
							}
						}
						else
						{
							if (table._0006_2002 == text)
							{
								text = string.Empty;
								break;
							}
							if (table._0006_2002 != string.Empty)
							{
								throw new Exception(global::_0005_2000._0002(1402772554) + RangeAddress + global::_0005_2000._0002(1402773413) + table._0006_2002 + global::_0005_2000._0002(1402773390));
							}
						}
					}
				}
			}
			if (text != string.Empty)
			{
				XmlAttribute xmlAttribute = _0003.Attributes[global::_0005_2000._0002(1402768264)];
				if (xmlAttribute == null)
				{
					xmlAttribute = _0002.CreateAttribute(global::_0005_2000._0002(1402768264));
					_0003.Attributes.Append(xmlAttribute);
				}
				_0006_2002 = text;
				xmlAttribute.InnerText = global::_0003_2000._0006(text);
			}
		}
	}

	public Font Font
	{
		get
		{
			if (_000F_2001 == null)
			{
				_000F_2001 = new Font(_0002, _0003);
			}
			return _000F_2001;
		}
	}

	public XlHAlign HorizontalAlignment
	{
		set
		{
			_0002_2002 = value;
			XmlAttribute xmlAttribute = _0003.Attributes[global::_0005_2000._0002(1402770143)];
			if (xmlAttribute == null)
			{
				xmlAttribute = _0002.CreateAttribute(global::_0005_2000._0002(1402770143));
				_0003.Attributes.Append(xmlAttribute);
			}
			XmlAttribute xmlAttribute2 = xmlAttribute;
			int num = (int)_0002_2002;
			xmlAttribute2.InnerText = num.ToString();
		}
	}

	public XlVAlign VerticalAlignment
	{
		set
		{
			_0003_2002 = value;
			XmlAttribute xmlAttribute = _0003.Attributes[global::_0005_2000._0002(1402770122)];
			if (xmlAttribute == null)
			{
				xmlAttribute = _0002.CreateAttribute(global::_0005_2000._0002(1402770122));
				_0003.Attributes.Append(xmlAttribute);
			}
			XmlAttribute xmlAttribute2 = xmlAttribute;
			int num = (int)_0003_2002;
			xmlAttribute2.InnerText = num.ToString();
		}
	}

	public string NumberFormatLocal
	{
		set
		{
			_0005_2002 = value;
			XmlAttribute xmlAttribute = _0003.Attributes[global::_0005_2000._0002(1402769977)];
			if (xmlAttribute == null)
			{
				xmlAttribute = _0002.CreateAttribute(global::_0005_2000._0002(1402769977));
				_0003.Attributes.Append(xmlAttribute);
			}
			xmlAttribute.InnerText = global::_0003_2000._0006(_0005_2002);
		}
	}

	internal Table(XmlDocument _0002, XmlNode _0003, string _0005, bool _0008, ArrayList _0006)
	{
		_000E_2001 = _0006;
		this._0002 = _0002;
		this._0008 = new ArrayList(2000);
		this._0006 = new StringBuilder();
		_000E = new StringBuilder();
		_000F = 0;
		_0002_2000 = new StringBuilder();
		_0003_2000 = 0;
		_0005_2000 = 0;
		_0008_2002 = _0005;
		_000E_2002 = string.Empty;
		_0006_2002 = string.Empty;
		this._0005 = _0008;
		_000F_2000 = null;
		_0002_2001 = 0;
		_0003_2001 = 0;
		_0005_2001 = 0.0;
		_0008_2001 = 0.0;
		_0006_2001 = false;
		_000F_2001 = null;
		_0002_2002 = (XlHAlign)0;
		_0003_2002 = (XlVAlign)0;
		_0005_2002 = string.Empty;
		_000E_2000 = new ExcelRect(_0005);
		int num = _000E_2000.right - _000E_2000.left + 1;
		this._0003 = this._0002.CreateElement(global::_0005_2000._0002(1402767446));
		_0003.AppendChild(this._0003);
		XmlAttribute xmlAttribute = this._0002.CreateAttribute(global::_0005_2000._0002(1402768309));
		xmlAttribute.InnerText = _0005;
		this._0003.Attributes.Append(xmlAttribute);
		this._0003.InnerText = string.Empty;
		_0008_2000 = new _000F();
		for (int i = 0; i < num; i++)
		{
			_0008_2000._0002(new DataField());
		}
		_0008_2000.KeyValue = string.Empty;
		_0006_2000 = false;
	}

	internal Table(XmlDocument _0002, XmlNode _0003, string _0005, bool _0008, ArrayList _0006, string _000E)
	{
		_000E_2001 = _0006;
		this._0002 = _0002;
		this._0008 = new ArrayList(2000);
		this._0006 = new StringBuilder();
		this._000E = new StringBuilder();
		_000F = 0;
		_0002_2000 = new StringBuilder();
		_0003_2000 = 0;
		_0005_2000 = 0;
		_0008_2002 = _0005;
		_000E_2002 = _000E;
		_0006_2002 = string.Empty;
		this._0005 = _0008;
		_000F_2000 = null;
		_0002_2001 = 0;
		_0003_2001 = 0;
		_0005_2001 = 0.0;
		_0008_2001 = 0.0;
		_0006_2001 = false;
		_000F_2001 = null;
		_0002_2002 = (XlHAlign)0;
		_0003_2002 = (XlVAlign)0;
		_0005_2002 = string.Empty;
		_000E_2000 = new ExcelRect(_0005);
		int num = _000E_2000.right - _000E_2000.left + 1;
		this._0003 = this._0002.CreateElement(global::_0005_2000._0002(1402767446));
		_0003.AppendChild(this._0003);
		XmlAttribute xmlAttribute = this._0002.CreateAttribute(global::_0005_2000._0002(1402768309));
		xmlAttribute.InnerText = _0005;
		this._0003.Attributes.Append(xmlAttribute);
		xmlAttribute = this._0002.CreateAttribute(global::_0005_2000._0002(1402769507));
		xmlAttribute.InnerText = global::_0003_2000._0006(_000E);
		this._0003.Attributes.Append(xmlAttribute);
		this._0003.InnerText = string.Empty;
		_0008_2000 = new _000F();
		for (int i = 0; i < num; i++)
		{
			_0008_2000._0002(new DataField());
		}
		_0008_2000.KeyValue = string.Empty;
		_0006_2000 = false;
	}

	public void NextRow()
	{
		if (_0006_2000)
		{
			throw new Exception(global::_0005_2000._0002(1402770515));
		}
		if (!_0005 && _0005_2000 >= _000E_2000.bottom - _000E_2000.top + 1)
		{
			return;
		}
		for (int i = 0; i < _0008_2000.Count; i++)
		{
			DataField dataField = _0008_2000[i];
			_0008.Add(dataField._0005);
			if (dataField._0008 > -1)
			{
				_0002_2000.Append(_000E_2000.top + _0005_2000 + global::_0005_2000._0002(1402773301) + (_000E_2000.left + i) + global::_0005_2000._0002(1402773301) + dataField._0008 + global::_0005_2000._0002(1402773301));
				_0003_2000++;
			}
			if (dataField._0006 > -1)
			{
				_000E.Append(_000E_2000.top + _0005_2000 + global::_0005_2000._0002(1402773301) + (_000E_2000.left + i) + global::_0005_2000._0002(1402773301) + dataField._0006 + global::_0005_2000._0002(1402773301));
				_000F++;
			}
			dataField._0002();
		}
		if (_0005_2000 == 0 && _0008_2000._0002() != string.Empty)
		{
			_0006.Append(_0008_2000._0002().Replace('\t', ' '));
		}
		else if (_0006.Length > 0)
		{
			_0006.Append('\t');
			_0006.Append(_0008_2000._0002().Replace('\t', ' '));
		}
		_0008_2000.KeyValue = string.Empty;
		_0005_2000++;
	}

	public void Close()
	{
		if (_0006_2000)
		{
			throw new Exception(global::_0005_2000._0002(1402770515));
		}
		bool flag = true;
		for (int i = 0; i < _0008_2000.Count; i++)
		{
			DataField dataField = _0008_2000[i];
			if (!dataField._000F)
			{
				flag = false;
				break;
			}
		}
		if (!flag)
		{
			NextRow();
		}
		XmlAttribute xmlAttribute = _0002.CreateAttribute(global::_0005_2000._0002(1402770635));
		xmlAttribute.InnerText = _0005_2000.ToString();
		_0003.Attributes.Append(xmlAttribute);
		if (_0005_2000 > 0)
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			ArrayList arrayList = new ArrayList();
			ArrayList arrayList2 = new ArrayList();
			ArrayList arrayList3 = new ArrayList();
			for (int j = 0; j < _0008_2000.Count; j++)
			{
				if (!_0008_2000[j]._000E)
				{
					continue;
				}
				if (j >= 1 && !_0008_2000[j - 1]._000E)
				{
					num3 = j - 1;
					if (num3 >= num2)
					{
						num++;
						arrayList.Add(num2);
						arrayList2.Add(num3);
						StringBuilder value = new StringBuilder();
						arrayList3.Add(value);
					}
				}
				num2 = j + 1;
			}
			if (num2 < _0008_2000.Count)
			{
				num++;
				arrayList.Add(num2);
				arrayList2.Add(_0008_2000.Count - 1);
				StringBuilder value2 = new StringBuilder();
				arrayList3.Add(value2);
			}
			XmlNode xmlNode = null;
			if (num > 0)
			{
				int count = _0008_2000.Count;
				for (int k = 0; k < _0005_2000; k++)
				{
					for (int l = 0; l < num; l++)
					{
						StringBuilder stringBuilder = (StringBuilder)arrayList3[l];
						for (int m = (int)arrayList[l]; m <= (int)arrayList2[l]; m++)
						{
							if (m > (int)arrayList[l])
							{
								stringBuilder.Append('\t');
							}
							stringBuilder.Append(_0008[count * k + m]);
						}
						stringBuilder.Append(global::_0005_2000._0002(1402768257));
					}
				}
				for (int n = 0; n < num; n++)
				{
					xmlNode = _0002.CreateElement(global::_0005_2000._0002(1402767426));
					_0003.AppendChild(xmlNode);
					xmlNode.InnerText = global::_0003_2000._0006(((StringBuilder)arrayList3[n]).ToString());
					xmlAttribute = _0002.CreateAttribute(global::_0005_2000._0002(1402773309));
					xmlNode.Attributes.Append(xmlAttribute);
					xmlAttribute.InnerText = arrayList[n].ToString();
					xmlAttribute = _0002.CreateAttribute(global::_0005_2000._0002(1402773289));
					xmlNode.Attributes.Append(xmlAttribute);
					xmlAttribute.InnerText = arrayList2[n].ToString();
				}
			}
			arrayList3.Clear();
			if (_0006_2002.Length > 0 && _0006.Length > 0)
			{
				xmlNode = _0002.CreateElement(global::_0005_2000._0002(1402770491));
				_0003.AppendChild(xmlNode);
				xmlNode.InnerText = _0006.ToString();
			}
			if (_0003_2000 > 0)
			{
				xmlNode = _0002.CreateElement(global::_0005_2000._0002(1402773267));
				_0003.AppendChild(xmlNode);
				xmlNode.InnerText = _0002_2000.ToString();
			}
			if (_000F > 0)
			{
				xmlNode = _0002.CreateElement(global::_0005_2000._0002(1402773255));
				_0003.AppendChild(xmlNode);
				xmlNode.InnerText = _000E.ToString();
			}
		}
		_0006_2000 = true;
		_0008_2000.Clear();
		_0008.Clear();
	}

	public void Merge()
	{
		Merge(Across: false);
	}

	public void Merge(bool Across)
	{
		if (_0006_2000)
		{
			throw new Exception(global::_0005_2000._0002(1402770515));
		}
		if (_0005_2000 > 0)
		{
			throw new Exception(global::_0005_2000._0002(1402773371));
		}
		XmlAttribute xmlAttribute = _0003.Attributes[global::_0005_2000._0002(1402773130)];
		if (xmlAttribute == null)
		{
			xmlAttribute = _0002.CreateAttribute(global::_0005_2000._0002(1402773130));
			_0003.Attributes.Append(xmlAttribute);
		}
		xmlAttribute.InnerText = Across.ToString();
	}
}
