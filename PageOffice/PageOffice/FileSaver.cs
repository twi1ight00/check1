using System;
using System.IO;
using System.Web;
using System.Web.SessionState;
using System.Xml;

namespace PageOffice;

public sealed class FileSaver
{
	private HttpSessionState _0002;

	private HttpServerUtility _0003;

	private HttpRequest _0005;

	private HttpResponse _0008;

	private string _0006;

	private string _000E;

	private string _000F;

	private string _0002_2000;

	private int _0003_2000;

	private string _0005_2000;

	private byte[] _0008_2000;

	private string _0006_2000;

	private XmlDocument _000E_2000;

	private string _000F_2000;

	public string FileName => _0006;

	public string FileExtName => _000E;

	public string LocalFileName => _000F;

	public string LocalFileExtName => _0002_2000;

	public int FileSize => _0003_2000;

	public byte[] FileBytes => _0008_2000;

	public string DocumentText => _0006_2000;

	public string CustomSaveResult
	{
		set
		{
			_000F_2000 = value.Replace(global::_0005_2000._0002(1402771015), global::_0005_2000._0002(1402771023)).Replace(global::_0005_2000._0002(1402769848), global::_0005_2000._0002(1402769824));
		}
	}

	public FileSaver()
	{
		_0002 = HttpContext.Current.Session;
		_0003 = HttpContext.Current.Server;
		_0005 = HttpContext.Current.Request;
		_0008 = HttpContext.Current.Response;
		_0006 = string.Empty;
		_000E = string.Empty;
		_000F = string.Empty;
		_0002_2000 = string.Empty;
		_0003_2000 = 0;
		_0006_2000 = string.Empty;
		_000F_2000 = string.Empty;
		XmlDocument xmlDocument = new XmlDocument();
		if (_0005.InputStream.Length == 0)
		{
			throw new Exception(global::_0005_2000._0002(1402771445));
		}
		xmlDocument.Load(_0005.InputStream);
		XmlNode xmlNode = xmlDocument.SelectSingleNode(global::_0005_2000._0002(1402771170));
		if (xmlNode == null)
		{
			xmlNode = xmlDocument.SelectSingleNode(global::_0005_2000._0002(1402771314));
			if (xmlNode != null)
			{
				throw new Exception(global::_0005_2000._0002(1402776460));
			}
			xmlNode = xmlDocument.SelectSingleNode(global::_0005_2000._0002(1402771230));
			if (xmlNode != null)
			{
				throw new Exception(global::_0005_2000._0002(1402776341));
			}
			throw new Exception(global::_0005_2000._0002(1402776244));
		}
		XmlNode namedItem = xmlNode.Attributes.GetNamedItem(global::_0005_2000._0002(1402775293));
		if (namedItem != null)
		{
			_0006 = _0003.UrlDecode(namedItem.Value);
			_000E = global::_0003_2000._000F(_0006);
			_000E = _000E.ToLower();
		}
		namedItem = xmlNode.Attributes.GetNamedItem(global::_0005_2000._0002(1402776215));
		if (namedItem != null)
		{
			_000F = global::_0003_2000._000E(namedItem.Value);
			_0002_2000 = global::_0003_2000._000F(_000F);
			_0002_2000 = _0002_2000.ToLower();
		}
		_0005_2000 = xmlNode.Attributes.GetNamedItem(global::_0005_2000._0002(1402776203)).Value;
		_0003_2000 = int.Parse(xmlNode.Attributes.GetNamedItem(global::_0005_2000._0002(1402776314)).Value);
		_0008_2000 = Convert.FromBase64String(xmlNode.InnerText);
		XmlNode xmlNode2 = xmlDocument.SelectSingleNode(global::_0005_2000._0002(1402776299));
		if (xmlNode2 != null)
		{
			_0006_2000 = global::_0003_2000._000E(xmlNode2.InnerText);
		}
		XmlNode xmlNode3 = xmlDocument.SelectSingleNode(global::_0005_2000._0002(1402769547));
		if (xmlNode3 != null)
		{
			_000E_2000 = new XmlDocument();
			_000E_2000.LoadXml(global::_0005_2000._0002(1402776286) + xmlNode3.InnerXml + global::_0005_2000._0002(1402776089));
		}
	}

	public void SaveToFile(string SaveAsFileName)
	{
		string empty = string.Empty;
		if (SaveAsFileName == null || SaveAsFileName == string.Empty)
		{
			throw new Exception(global::_0005_2000._0002(1402776077));
		}
		empty = SaveAsFileName;
		if (!_0005_2000.Equals(string.Empty))
		{
			string text = empty.Substring(0, empty.LastIndexOf('\\') + 1);
			string path = text + _0005_2000;
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
			_0005_2000 += global::_0005_2000._0002(1402775274);
			empty = text + _0005_2000 + _0006;
		}
		FileStream fileStream = new FileStream(empty, FileMode.Create);
		fileStream.Write(_0008_2000, 0, _0008_2000.Length);
		fileStream.Close();
	}

	public void Close()
	{
		_0008.Write(global::_0005_2000._0002(1402769710));
		if (_000F_2000.Length > 0)
		{
			_0008.Write(global::_0005_2000._0002(1402769791) + _000F_2000 + global::_0005_2000._0002(1402769736));
		}
	}

	public void ShowPage(int Width, int Height)
	{
		_0008.Write(global::_0005_2000._0002(1402769586) + Width + global::_0005_2000._0002(1402769539) + Height + global::_0005_2000._0002(1402769736));
	}

	public string GetFormField(string Name)
	{
		string result = string.Empty;
		if (_000E_2000 != null)
		{
			XmlNodeList xmlNodeList = _000E_2000.SelectNodes(global::_0005_2000._0002(1402779050));
			bool flag = false;
			for (int i = 0; i < xmlNodeList.Count; i++)
			{
				XmlNode xmlNode = xmlNodeList.Item(i);
				if (global::_0003_2000._0006(Name.ToUpper()) == xmlNode.Attributes[global::_0005_2000._0002(1402767411)].InnerText)
				{
					result = global::_0003_2000._000E(xmlNode.InnerText);
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				throw new Exception(global::_0005_2000._0002(1402779015) + Name + global::_0005_2000._0002(1402779124));
			}
			return result;
		}
		throw new Exception(global::_0005_2000._0002(1402779015) + Name + global::_0005_2000._0002(1402779124));
	}
}
