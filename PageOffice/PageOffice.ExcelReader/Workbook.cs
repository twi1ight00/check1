using System;
using System.Collections;
using System.Web;
using System.Xml;

namespace PageOffice.ExcelReader;

public sealed class Workbook
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

	public ArrayList Sheets
	{
		get
		{
			if (_0008.Count < _000E)
			{
				_0008.Clear();
				XmlNodeList xmlNodeList = _0005.DocumentElement.SelectNodes(_0005_2000._0002(1402771035));
				if (xmlNodeList != null)
				{
					for (int i = 0; i < xmlNodeList.Count; i++)
					{
						Sheet value = new Sheet(xmlNodeList[i], xmlNodeList[i].Attributes[_0005_2000._0002(1402767411)].InnerText);
						_0008.Add(value);
					}
				}
			}
			return _0008;
		}
	}

	public Workbook()
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
		XmlNode xmlNode = xmlDocument.SelectSingleNode(_0005_2000._0002(1402771230));
		if (xmlNode == null)
		{
			xmlNode = xmlDocument.SelectSingleNode(_0005_2000._0002(1402771314));
			if (xmlNode != null)
			{
				throw new Exception(_0005_2000._0002(1402771303));
			}
			xmlNode = xmlDocument.SelectSingleNode(_0005_2000._0002(1402771170));
			if (xmlNode != null)
			{
				throw new Exception(_0005_2000._0002(1402771152));
			}
			throw new Exception(_0005_2000._0002(1402771063));
		}
		string innerText = xmlNode.InnerText;
		innerText = _0003_2000._0003(innerText);
		_0005 = new XmlDocument();
		_0005.LoadXml(innerText);
		_000E = _0005.DocumentElement.SelectNodes(_0005_2000._0002(1402771035)).Count;
		_0008 = new ArrayList();
	}

	public Sheet OpenSheet(string SheetName)
	{
		if (SheetName == null || SheetName.Length < 1)
		{
			throw new Exception(_0005_2000._0002(1402769837));
		}
		string text = _0003_2000._0006(SheetName);
		if (_0008.Count > 0)
		{
			for (int num = _0008.Count - 1; num >= 0; num--)
			{
				Sheet sheet = (Sheet)_0008[num];
				if (sheet._0003_2000 == text)
				{
					return sheet;
				}
			}
		}
		bool flag = false;
		XmlNode xmlNode = null;
		XmlNode documentElement = _0005.DocumentElement;
		for (int i = 0; i < documentElement.ChildNodes.Count; i++)
		{
			xmlNode = documentElement.ChildNodes[i];
			if (xmlNode.Name == _0005_2000._0002(1402771035) && xmlNode.Attributes[_0005_2000._0002(1402767411)].InnerText == text)
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			Sheet sheet2 = new Sheet(xmlNode, text);
			_0008.Add(sheet2);
			return sheet2;
		}
		throw new Exception(_0005_2000._0002(1402769908) + SheetName + _0005_2000._0002(1402769895));
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
