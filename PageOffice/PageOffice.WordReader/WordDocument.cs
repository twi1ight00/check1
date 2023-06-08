using System;
using System.Collections;
using System.Web;
using System.Xml;

namespace PageOffice.WordReader;

public sealed class WordDocument
{
	private HttpRequest _0002;

	private HttpResponse _0003;

	private XmlDocument _0005;

	private ArrayList _0008;

	private string _0006;

	private int _000E;

	public string CustomSaveResult
	{
		set
		{
			_0006 = value.Replace(_0005_2000._0002(1402771015), _0005_2000._0002(1402771023)).Replace(_0005_2000._0002(1402769848), _0005_2000._0002(1402769824));
		}
	}

	public ArrayList DataRegions
	{
		get
		{
			if (_0008.Count < _000E)
			{
				_0008.Clear();
				XmlNodeList xmlNodeList = _0005.DocumentElement.SelectNodes(_0005_2000._0002(1402789694));
				if (xmlNodeList != null)
				{
					for (int i = 0; i < xmlNodeList.Count; i++)
					{
						DataRegion value = new DataRegion(xmlNodeList[i], xmlNodeList[i].Attributes[_0005_2000._0002(1402767411)].InnerText);
						_0008.Add(value);
					}
				}
			}
			return _0008;
		}
	}

	public WordDocument()
	{
		_0002 = HttpContext.Current.Request;
		_0003 = HttpContext.Current.Response;
		_0006 = string.Empty;
		XmlDocument xmlDocument = new XmlDocument();
		if (_0002.InputStream.Length == 0)
		{
			throw new Exception(_0005_2000._0002(1402771445));
		}
		xmlDocument.Load(_0002.InputStream);
		XmlNode xmlNode = xmlDocument.SelectSingleNode(_0005_2000._0002(1402771314));
		if (xmlNode == null)
		{
			xmlNode = xmlDocument.SelectSingleNode(_0005_2000._0002(1402771230));
			if (xmlNode != null)
			{
				throw new Exception(_0005_2000._0002(1402788872));
			}
			xmlNode = xmlDocument.SelectSingleNode(_0005_2000._0002(1402771170));
			if (xmlNode != null)
			{
				throw new Exception(_0005_2000._0002(1402789761));
			}
			throw new Exception(_0005_2000._0002(1402771063));
		}
		string innerText = xmlNode.InnerText;
		innerText = _0003_2000._0003(innerText);
		_0005 = new XmlDocument();
		_0005.LoadXml(innerText);
		_000E = _0005.DocumentElement.SelectNodes(_0005_2000._0002(1402789694)).Count;
		_0008 = new ArrayList();
	}

	public DataRegion OpenDataRegion(string DataRegionName)
	{
		if (DataRegionName == null || DataRegionName.Length < 1)
		{
			throw new Exception(_0005_2000._0002(1402789649));
		}
		if (!DataRegionName.StartsWith(_0005_2000._0002(1402789730)))
		{
			DataRegionName = _0005_2000._0002(1402789730) + DataRegionName;
		}
		if (_0008.Count > 0)
		{
			for (int num = _0008.Count - 1; num >= 0; num--)
			{
				DataRegion dataRegion = (DataRegion)_0008[num];
				if (_0003_2000._000E(dataRegion._0006).ToLower() == DataRegionName.ToLower())
				{
					return dataRegion;
				}
			}
		}
		bool flag = false;
		XmlNode xmlNode = null;
		XmlNode documentElement = _0005.DocumentElement;
		for (int i = 0; i < documentElement.ChildNodes.Count; i++)
		{
			xmlNode = documentElement.ChildNodes[i];
			if (xmlNode.Name == _0005_2000._0002(1402789694) && _0003_2000._000E(xmlNode.Attributes[_0005_2000._0002(1402767411)].InnerText).ToLower() == DataRegionName.ToLower())
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			DataRegion dataRegion2 = new DataRegion(xmlNode, _0003_2000._0006(DataRegionName));
			_0008.Add(dataRegion2);
			return dataRegion2;
		}
		throw new Exception(_0005_2000._0002(1402789740) + DataRegionName + _0005_2000._0002(1402789703));
	}

	public void Close()
	{
		_0003.Write(_0005_2000._0002(1402769710));
		if (_0006.Length > 0)
		{
			_0003.Write(_0005_2000._0002(1402769791) + _0006 + _0005_2000._0002(1402769736));
		}
	}

	public void ShowPage(int Width, int Height)
	{
		_0003.Write(_0005_2000._0002(1402769586) + Width + _0005_2000._0002(1402769539) + Height + _0005_2000._0002(1402769736));
	}

	public string GetFormField(string Name)
	{
		string result = string.Empty;
		XmlNode xmlNode = _0005.SelectSingleNode(_0005_2000._0002(1402769547));
		if (xmlNode != null)
		{
			XmlNodeList xmlNodeList = xmlNode.SelectNodes(_0005_2000._0002(1402769660));
			bool flag = false;
			for (int i = 0; i < xmlNodeList.Count; i++)
			{
				XmlNode xmlNode2 = xmlNodeList.Item(i);
				if (_0003_2000._0006(Name.ToUpper()) == xmlNode2.Attributes[_0005_2000._0002(1402767411)].InnerText)
				{
					result = _0003_2000._000E(xmlNode2.InnerText);
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				throw new Exception(_0005_2000._0002(1402769644) + Name + _0005_2000._0002(1402769631));
			}
			return result;
		}
		throw new Exception(_0005_2000._0002(1402769644) + Name + _0005_2000._0002(1402769631));
	}
}
