using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Xml;
using PageOffice.Design;
using PageOffice.ExcelWriter;
using PageOffice.WordWriter;

namespace PageOffice;

[Designer(typeof(FileMakerCtrlDesigner))]
[DefaultEvent("Load")]
[ToolboxData("<{0}:FileMakerCtrl runat=server></{0}:FileMakerCtrl>")]
[DefaultProperty("FileTitle")]
[ToolboxBitmap(typeof(FileMakerCtrl), "FileMakerCtrl.ico")]
public sealed class FileMakerCtrl : Control
{
	private string m__0002;

	private short m__0003;

	private string _0005;

	private string _0008;

	private string _0006;

	private string _000E;

	private bool _000F;

	private string _0002_2000;

	private int _0003_2000;

	private bool _0005_2000;

	private string _0008_2000;

	private string _0006_2000;

	private string _000E_2000;

	private string _000F_2000;

	private string _0002_2001;

	private string _0003_2001;

	private string _0005_2001;

	private bool _0008_2001;

	private string _0006_2001;

	private string _000E_2001;

	private XmlDocument _000F_2001;

	private OfficeVendorType _0002_2002;

	private string _0003_2002;

	private EventHandler _0005_2002;

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public override string SkinID
	{
		get
		{
			return base.SkinID;
		}
		set
		{
			base.SkinID = value;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public override bool EnableViewState
	{
		get
		{
			return base.EnableViewState;
		}
		set
		{
			base.EnableViewState = value;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public override bool EnableTheming
	{
		get
		{
			return base.EnableTheming;
		}
		set
		{
			base.EnableTheming = value;
		}
	}

	[Category("Accessibility")]
	[Browsable(true)]
	[Description("The keyboard shortcut of the control.")]
	public string AccessKey
	{
		get
		{
			return this.m__0002;
		}
		set
		{
			this.m__0002 = value;
		}
	}

	[Description("The TabIndex of the control.")]
	[Category("Accessibility")]
	[Browsable(true)]
	public short TabIndex
	{
		get
		{
			return this.m__0003;
		}
		set
		{
			this.m__0003 = value;
		}
	}

	[Browsable(false)]
	public string FileTitle
	{
		get
		{
			return _0005;
		}
		set
		{
			_0005 = value;
		}
	}

	[Browsable(false)]
	public string ServerPage
	{
		get
		{
			return _0008;
		}
		set
		{
			_0008 = value;
			if (!(_0008 != string.Empty))
			{
				return;
			}
			string text = _0008.ToLower();
			if (text.StartsWith(global::_0005_2000._0002(1402771699)) || text.StartsWith(global::_0005_2000._0002(1402771681)))
			{
				if (text.StartsWith(global::_0005_2000._0002(1402771699)))
				{
					text = _0008.Substring(7);
				}
				else if (text.StartsWith(global::_0005_2000._0002(1402771681)))
				{
					text = _0008.Substring(8);
				}
				if (text.IndexOf('/') > -1)
				{
					text = text.Substring(text.IndexOf('/'));
				}
			}
			if (text == string.Empty)
			{
				throw new Exception(ID + global::_0005_2000._0002(1402771694) + _0008 + global::_0005_2000._0002(1402771652));
			}
			HttpServerUtility server = HttpContext.Current.Server;
			try
			{
				_000F_2000 = text;
				text = server.MapPath(text);
			}
			catch
			{
				throw new Exception(ID + global::_0005_2000._0002(1402771694) + _0008 + global::_0005_2000._0002(1402771652));
			}
			File.Exists(text);
			_000E_2000 = text;
			_0003_2001 = _000E_2000.Substring(0, _000E_2000.LastIndexOf('\\'));
			HttpRequest request = HttpContext.Current.Request;
			_000E_2000 = _000E_2000.Substring(0, _000E_2000.LastIndexOf('\\')) + global::_0005_2000._0002(1402771495);
			if (!File.Exists(_000E_2000))
			{
				throw new Exception(global::_0005_2000._0002(1402771480) + _000E_2000 + global::_0005_2000._0002(1402771465));
			}
			_0005_2001 = _0002(_000E_2000);
			if (_0005_2001.EndsWith(global::_0005_2000._0002(1402772392)))
			{
				_0005_2001 = _0005_2001.Substring(0, _0005_2001.Length - 4);
				_0008_2001 = true;
			}
			_000F_2000 = _000F_2000.Substring(0, _000F_2000.LastIndexOf('/')) + global::_0005_2000._0002(1402772373);
			if (_000F_2000[0] == '/')
			{
				string text2 = request.ApplicationPath;
				if (text2[0] == '/')
				{
					text2 = string.Empty;
				}
				_000F_2000 = request.Url.AbsoluteUri.Substring(0, request.Url.AbsoluteUri.IndexOf('/', 8)) + text2 + _000F_2000;
			}
			else
			{
				string text3 = request.Url.AbsoluteUri;
				int num = text3.LastIndexOf('?');
				if (num > 0)
				{
					text3 = text3.Substring(0, num);
				}
				int num2 = text3.LastIndexOf('/');
				_000F_2000 = text3.Substring(0, num2 + 1) + _000F_2000;
			}
			if (request.Url.Authority != request.ServerVariables[global::_0005_2000._0002(1402772358)])
			{
				_000F_2000 = _000F_2000.Replace(request.Url.Authority, request.ServerVariables[global::_0005_2000._0002(1402772358)]);
			}
			_0002_2001 = _000F_2000.Substring(0, _000F_2000.LastIndexOf('/') + 1) + global::_0005_2000._0002(1402772470);
			_000F_2000 = _000F_2000 + global::_0005_2000._0002(1402772456) + _0002(_000E_2000);
		}
	}

	[Browsable(false)]
	public string SaveFilePage
	{
		get
		{
			return _0006;
		}
		set
		{
			_0006 = value;
		}
	}

	[Browsable(false)]
	public string HTTPBasic_UserName
	{
		get
		{
			return _0008_2000;
		}
		set
		{
			_0008_2000 = value;
		}
	}

	[Browsable(false)]
	public string HTTPBasic_Password
	{
		get
		{
			return _0006_2000;
		}
		set
		{
			_0006_2000 = value;
		}
	}

	[Browsable(false)]
	public string JsFunction_AfterDocumentOpened
	{
		get
		{
			return _0006_2001;
		}
		set
		{
			_0006_2001 = value;
		}
	}

	[Browsable(false)]
	public string JsFunction_OnProgressComplete
	{
		get
		{
			return _000E_2001;
		}
		set
		{
			_000E_2001 = value;
		}
	}

	[Browsable(false)]
	public OfficeVendorType OfficeVendor
	{
		get
		{
			return _0002_2002;
		}
		set
		{
			_0002_2002 = value;
		}
	}

	[Browsable(false)]
	public string ZoomSealServer
	{
		get
		{
			return _0003_2002;
		}
		set
		{
			_0003_2002 = value;
		}
	}

	[Category("Document")]
	[Description("在此事件里为 FileMakerCtrl 控件编写初始化及打开文档的代码。")]
	public new event EventHandler Load
	{
		add
		{
			EventHandler eventHandler = _0005_2002;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref _0005_2002, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		remove
		{
			EventHandler eventHandler = _0005_2002;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref _0005_2002, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public FileMakerCtrl()
	{
		this.m__0002 = string.Empty;
		this.m__0003 = 0;
		_0005 = string.Empty;
		_0008 = string.Empty;
		_0006 = string.Empty;
		_000E = string.Empty;
		_000F = false;
		_0002_2000 = string.Empty;
		_0003_2000 = 0;
		_0005_2000 = false;
		_0008_2000 = string.Empty;
		_0006_2000 = string.Empty;
		_000F_2000 = string.Empty;
		_0002_2001 = string.Empty;
		_000E_2000 = string.Empty;
		_0003_2001 = string.Empty;
		_0005_2001 = string.Empty;
		_0008_2001 = false;
		_0006_2001 = string.Empty;
		_000E_2001 = string.Empty;
		_0002_2002 = OfficeVendorType.MSOffice;
		_0003_2002 = string.Empty;
		_000F_2001 = new XmlDocument();
		StringBuilder stringBuilder = new StringBuilder(global::_0005_2000._0002(1402773238));
		stringBuilder.Append(global::_0005_2000._0002(1402771620));
		stringBuilder.Append(global::_0005_2000._0002(1402771610));
		_000F_2001.LoadXml(stringBuilder.ToString());
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override void DataBind()
	{
		base.DataBind();
	}

	private void _0002(XmlDocument _0002)
	{
		HttpRequest request = HttpContext.Current.Request;
		XmlNode documentElement = _0002.DocumentElement;
		if (_0005 != string.Empty)
		{
			XmlNode xmlNode = _0002.CreateElement(global::_0005_2000._0002(1402772440));
			xmlNode.InnerText = global::_0003_2000._0006(_0005);
			documentElement.AppendChild(xmlNode);
		}
		if (_0008 != string.Empty)
		{
			XmlNode xmlNode2 = _0002.CreateElement(global::_0005_2000._0002(1402772424));
			xmlNode2.InnerText = _0008;
			documentElement.AppendChild(xmlNode2);
		}
		if (_0006 != string.Empty)
		{
			XmlNode xmlNode3 = _0002.CreateElement(global::_0005_2000._0002(1402772283));
			xmlNode3.InnerText = _0006;
			documentElement.AppendChild(xmlNode3);
		}
		if (_000E != string.Empty)
		{
			XmlNode xmlNode4 = _0002.CreateElement(global::_0005_2000._0002(1402772268));
			xmlNode4.InnerText = _000E;
			documentElement.AppendChild(xmlNode4);
		}
		string text = string.Empty;
		for (int i = 0; i < request.Cookies.Count; i++)
		{
			text = text + request.Cookies[i].Name + global::_0005_2000._0002(1402769483);
			text = text + request.Cookies[i].Value + global::_0005_2000._0002(1402772225);
		}
		if (text != string.Empty)
		{
			text = global::_0005_2000._0002(1402772233) + global::_0003_2000._0006(text);
			XmlNode xmlNode5 = _0002.CreateElement(global::_0005_2000._0002(1402772340));
			xmlNode5.InnerText = text;
			documentElement.AppendChild(xmlNode5);
		}
		if (_0003_2000 > 0)
		{
			XmlNode xmlNode6 = _0002.CreateElement(global::_0005_2000._0002(1402772330));
			xmlNode6.InnerText = _0003_2000.ToString();
			documentElement.AppendChild(xmlNode6);
		}
		if (_0005_2000)
		{
			XmlNode xmlNode7 = _0002.CreateElement(global::_0005_2000._0002(1402772288));
			xmlNode7.InnerText = global::_0005_2000._0002(1402770027);
			documentElement.AppendChild(xmlNode7);
		}
		if (_0008_2000 != string.Empty)
		{
			XmlNode xmlNode8 = _0002.CreateElement(global::_0005_2000._0002(1402772153));
			xmlNode8.InnerText = global::_0003_2000._0006(_0008_2000);
			documentElement.AppendChild(xmlNode8);
		}
		if (_0006_2000 != string.Empty)
		{
			XmlNode xmlNode9 = _0002.CreateElement(global::_0005_2000._0002(1402772112));
			xmlNode9.InnerText = _0006_2000;
			documentElement.AppendChild(xmlNode9);
		}
		if (_0006_2001 != string.Empty)
		{
			XmlNode xmlNode10 = _0002.CreateElement(global::_0005_2000._0002(1402772107));
			xmlNode10.InnerText = _0006_2001;
			documentElement.AppendChild(xmlNode10);
		}
		if (_000E_2001 != string.Empty)
		{
			XmlNode xmlNode11 = _0002.CreateElement(global::_0005_2000._0002(1402772206));
			xmlNode11.InnerText = _000E_2001;
			documentElement.AppendChild(xmlNode11);
		}
		if (_0002_2002 != 0)
		{
			XmlNode xmlNode12 = _0002.CreateElement(global::_0005_2000._0002(1402772018));
			int num = (int)_0002_2002;
			xmlNode12.InnerText = num.ToString();
			documentElement.AppendChild(xmlNode12);
		}
		if (_0005_2001 != string.Empty)
		{
			XmlNode xmlNode13 = _0002.CreateElement(global::_0005_2000._0002(1402772007));
			xmlNode13.InnerText = _0005_2001;
			documentElement.AppendChild(xmlNode13);
		}
		if (_0003_2002 != string.Empty)
		{
			XmlNode xmlNode14 = _0002.CreateElement(global::_0005_2000._0002(1402771995));
			xmlNode14.InnerText = _0003_2002;
			documentElement.AppendChild(xmlNode14);
		}
		XmlNode xmlNode15 = _0002.CreateElement(global::_0005_2000._0002(1402771982));
		xmlNode15.InnerText = global::_0005_2000._0002(1402770027);
		documentElement.AppendChild(xmlNode15);
		string innerXml = _0002.InnerXml;
		if (innerXml != string.Empty)
		{
			_0002_2000 = _0002_2000 + global::_0005_2000._0002(1402772094) + global::_0003_2000._0002(innerXml) + global::_0005_2000._0002(1402771936);
		}
	}

	public void SetWriter(object WriterObj)
	{
		if (WriterObj.GetType().FullName == global::_0005_2000._0002(1402774931))
		{
			_0002_2000 = ((Workbook)WriterObj)._0002();
			return;
		}
		if (WriterObj.GetType().FullName == global::_0005_2000._0002(1402775033))
		{
			_0002_2000 = ((WordDocument)WriterObj)._0002();
			return;
		}
		throw new Exception(global::_0005_2000._0002(1402774976) + WriterObj.GetType().FullName + global::_0005_2000._0002(1402774827));
	}

	private void _0002(string _0002, DocumentOpenType _0003, _0006 _0005, string _0008)
	{
		if (_0002 == null || _0002 == string.Empty)
		{
			throw new Exception(global::_0005_2000._0002(1402774810));
		}
		if (_0008 == null || _0008 == string.Empty)
		{
			throw new Exception(global::_0005_2000._0002(1402774867));
		}
		if (this._0008 == string.Empty)
		{
			throw new Exception(ID + global::_0005_2000._0002(1402774698) + ID + global::_0005_2000._0002(1402774761));
		}
		int num = _0002.IndexOf(global::_0005_2000._0002(1402774604));
		bool flag = true;
		if (num > -1)
		{
			flag = false;
			if (!File.Exists(_0002))
			{
				throw new Exception(global::_0005_2000._0002(1402775479) + _0002 + global::_0005_2000._0002(1402775470));
			}
			string text = global::_0003_2000._000F(_0002);
			text = text.ToLower();
			if (!text.Equals(global::_0005_2000._0002(1402775427)) && !text.Equals(global::_0005_2000._0002(1402775436)) && !text.Equals(global::_0005_2000._0002(1402775544)) && !text.Equals(global::_0005_2000._0002(1402775525)) && !text.Equals(global::_0005_2000._0002(1402775534)) && !text.Equals(global::_0005_2000._0002(1402775515)) && !text.Equals(global::_0005_2000._0002(1402775495)) && !text.Equals(global::_0005_2000._0002(1402775345)) && !text.Equals(global::_0005_2000._0002(1402775354)) && !text.Equals(global::_0005_2000._0002(1402775334)))
			{
				throw new Exception(global::_0005_2000._0002(1402775315) + _0002 + global::_0005_2000._0002(1402775412));
			}
		}
		else
		{
			flag = true;
		}
		OpenModeType openModeType = OpenModeType.docNormalEdit;
		if (_0002.ToLower().EndsWith(global::_0005_2000._0002(1402775427)) || _0002.ToLower().EndsWith(global::_0005_2000._0002(1402775436)) || _0002.ToLower().EndsWith(global::_0005_2000._0002(1402775544)) || _0002.ToLower().EndsWith(global::_0005_2000._0002(1402775525)))
		{
			if (_0003 != 0)
			{
				throw new Exception(global::_0005_2000._0002(1402775383) + _0002 + global::_0005_2000._0002(1402775228));
			}
			openModeType = OpenModeType.docNormalEdit;
		}
		else if (_0002.ToLower().EndsWith(global::_0005_2000._0002(1402775534)) || _0002.ToLower().EndsWith(global::_0005_2000._0002(1402775515)) || _0002.ToLower().EndsWith(global::_0005_2000._0002(1402775495)))
		{
			if (_0003 != DocumentOpenType.Excel)
			{
				throw new Exception(global::_0005_2000._0002(1402775383) + _0002 + global::_0005_2000._0002(1402775228));
			}
			openModeType = OpenModeType.xlsNormalEdit;
		}
		else if (_0002.ToLower().EndsWith(global::_0005_2000._0002(1402775345)) || _0002.ToLower().EndsWith(global::_0005_2000._0002(1402775354)))
		{
			if (_0003 != DocumentOpenType.PowerPoint)
			{
				throw new Exception(global::_0005_2000._0002(1402775383) + _0002 + global::_0005_2000._0002(1402775228));
			}
			openModeType = OpenModeType.pptNormalEdit;
		}
		else
		{
			switch (_0003)
			{
			case DocumentOpenType.Word:
				openModeType = OpenModeType.docNormalEdit;
				break;
			case DocumentOpenType.Excel:
				openModeType = OpenModeType.xlsNormalEdit;
				break;
			case DocumentOpenType.PowerPoint:
				openModeType = OpenModeType.pptNormalEdit;
				break;
			}
		}
		if (!_000F)
		{
			string text2 = global::_0005_2000._0002(1402775197);
			XmlNode documentElement = _000F_2001.DocumentElement;
			XmlNode xmlNode = _000F_2001.CreateElement(global::_0005_2000._0002(1402775183));
			XmlAttribute xmlAttribute = _000F_2001.CreateAttribute(global::_0005_2000._0002(1402775293));
			if (flag)
			{
				xmlAttribute.InnerText = _0002;
			}
			else
			{
				string text3 = _0002.Substring(_0002.LastIndexOf(global::_0005_2000._0002(1402775274)) + 1);
				string text4 = global::_0003_2000._0002(global::_0005_2000._0002(1402775250) + _0002 + global::_0005_2000._0002(1402775262) + text3);
				text4 = text4.Replace(global::_0005_2000._0002(1402775060), global::_0005_2000._0002(1402775068)).Replace(global::_0005_2000._0002(1402775047), global::_0005_2000._0002(1402775055)).Replace(global::_0005_2000._0002(1402769483), global::_0005_2000._0002(1402775158));
				xmlAttribute.InnerText = this._0008 + global::_0005_2000._0002(1402775137) + text4;
			}
			xmlNode.Attributes.Append(xmlAttribute);
			xmlAttribute = _000F_2001.CreateAttribute(global::_0005_2000._0002(1402775133));
			xmlAttribute.InnerText = openModeType.ToString();
			xmlNode.Attributes.Append(xmlAttribute);
			xmlAttribute = _000F_2001.CreateAttribute(global::_0005_2000._0002(1402775114));
			xmlAttribute.InnerText = global::_0003_2000._0006(text2);
			xmlNode.Attributes.Append(xmlAttribute);
			xmlAttribute = _000F_2001.CreateAttribute(global::_0005_2000._0002(1402773947));
			xmlAttribute.InnerText = HttpContext.Current.Server.UrlEncode(_0008);
			xmlNode.Attributes.Append(xmlAttribute);
			xmlAttribute = _000F_2001.CreateAttribute(global::_0005_2000._0002(1402773932));
			xmlAttribute.InnerText = _0005.ToString();
			xmlNode.Attributes.Append(xmlAttribute);
			documentElement.AppendChild(xmlNode);
			_000F = true;
		}
	}

	private void _0002(DocumentVersion _0002, _0006 _0003, string _0005)
	{
		if (_0005 == null || _0005 == string.Empty)
		{
			throw new Exception(global::_0005_2000._0002(1402774867));
		}
		if (_0008 == string.Empty)
		{
			throw new Exception(ID + global::_0005_2000._0002(1402774698) + ID + global::_0005_2000._0002(1402774761));
		}
		if (!_000F)
		{
			string text = global::_0005_2000._0002(1402775197);
			XmlNode documentElement = _000F_2001.DocumentElement;
			XmlNode xmlNode = _000F_2001.CreateElement(global::_0005_2000._0002(1402775183));
			string text2 = global::_0005_2000._0002(1402773917);
			OpenModeType openModeType = OpenModeType.docNormalEdit;
			string text3 = global::_0005_2000._0002(1402773903);
			string text4 = global::_0005_2000._0002(1402773985);
			switch (_0002)
			{
			case DocumentVersion.Word2003:
				openModeType = OpenModeType.docNormalEdit;
				text2 = global::_0005_2000._0002(1402773917);
				text3 = global::_0005_2000._0002(1402773903);
				text4 = global::_0005_2000._0002(1402773985);
				break;
			case DocumentVersion.Excel2003:
				openModeType = OpenModeType.xlsNormalEdit;
				text2 = global::_0005_2000._0002(1402773976);
				text3 = global::_0005_2000._0002(1402773962);
				text4 = global::_0005_2000._0002(1402773823);
				break;
			case DocumentVersion.PowerPoint2003:
				openModeType = OpenModeType.pptNormalEdit;
				text2 = global::_0005_2000._0002(1402773785);
				text3 = global::_0005_2000._0002(1402773771);
				text4 = global::_0005_2000._0002(1402773882);
				break;
			case DocumentVersion.Word2007:
				openModeType = OpenModeType.docNormalEdit;
				text2 = global::_0005_2000._0002(1402773850);
				text3 = global::_0005_2000._0002(1402773839);
				text4 = global::_0005_2000._0002(1402773985);
				break;
			case DocumentVersion.Excel2007:
				openModeType = OpenModeType.xlsNormalEdit;
				text2 = global::_0005_2000._0002(1402773664);
				text3 = global::_0005_2000._0002(1402773653);
				text4 = global::_0005_2000._0002(1402773823);
				break;
			case DocumentVersion.PowerPoint2007:
				openModeType = OpenModeType.pptNormalEdit;
				text2 = global::_0005_2000._0002(1402773641);
				text3 = global::_0005_2000._0002(1402773771);
				text4 = global::_0005_2000._0002(1402773882);
				break;
			}
			if (!File.Exists(_0003_2001 + global::_0005_2000._0002(1402773754) + text2))
			{
				throw new Exception(global::_0005_2000._0002(1402771480) + _0003_2001 + global::_0005_2000._0002(1402773754) + text2 + global::_0005_2000._0002(1402775470));
			}
			XmlAttribute xmlAttribute = _000F_2001.CreateAttribute(global::_0005_2000._0002(1402775293));
			string text5 = global::_0003_2000._0002(global::_0005_2000._0002(1402775250) + text2 + global::_0005_2000._0002(1402773741) + text4 + global::_0005_2000._0002(1402773697) + text3);
			text5 = text5.Replace(global::_0005_2000._0002(1402775060), global::_0005_2000._0002(1402775068)).Replace(global::_0005_2000._0002(1402775047), global::_0005_2000._0002(1402775055)).Replace(global::_0005_2000._0002(1402769483), global::_0005_2000._0002(1402775158));
			xmlAttribute.InnerText = _0008 + global::_0005_2000._0002(1402773552) + text5;
			xmlNode.Attributes.Append(xmlAttribute);
			xmlAttribute = _000F_2001.CreateAttribute(global::_0005_2000._0002(1402775133));
			xmlAttribute.InnerText = openModeType.ToString();
			xmlNode.Attributes.Append(xmlAttribute);
			xmlAttribute = _000F_2001.CreateAttribute(global::_0005_2000._0002(1402775114));
			xmlAttribute.InnerText = global::_0003_2000._0006(text);
			xmlNode.Attributes.Append(xmlAttribute);
			xmlAttribute = _000F_2001.CreateAttribute(global::_0005_2000._0002(1402773947));
			xmlAttribute.InnerText = HttpContext.Current.Server.UrlEncode(_0005);
			xmlNode.Attributes.Append(xmlAttribute);
			xmlAttribute = _000F_2001.CreateAttribute(global::_0005_2000._0002(1402773932));
			xmlAttribute.InnerText = _0003.ToString();
			xmlNode.Attributes.Append(xmlAttribute);
			documentElement.AppendChild(xmlNode);
			_000F = true;
		}
	}

	public void FillDocument(string DocumentURL, DocumentOpenType DocumentType)
	{
		string text = DocumentURL;
		int num = text.LastIndexOf(global::_0005_2000._0002(1402775047));
		if (num > -1)
		{
			text = text.Substring(num + 1);
		}
		num = text.LastIndexOf(global::_0005_2000._0002(1402775274));
		if (num > -1)
		{
			text = text.Substring(num + 1);
		}
		_0002(DocumentURL, DocumentType, global::_0006.Office, text);
	}

	public void FillDocumentAs(string DocumentURL, DocumentOpenType DocumentType, string DestFileName)
	{
		_0002(DocumentURL, DocumentType, global::_0006.Office, DestFileName);
	}

	public void FillDocumentAsPDF(string DocumentURL, DocumentOpenType DocumentType, string DestFileName)
	{
		_0002(DocumentURL, DocumentType, global::_0006.PDF, DestFileName);
	}

	public void CreateDocumentAs(DocumentVersion DocVersion, string DestFileName)
	{
		_0002(DocVersion, global::_0006.Office, DestFileName);
	}

	public void CreateDocumentAsPDF(DocumentOpenType DocumentType, string DestFileName)
	{
		switch (DocumentType)
		{
		case DocumentOpenType.Word:
			_0002(DocumentVersion.Word2003, global::_0006.PDF, DestFileName);
			break;
		case DocumentOpenType.Excel:
			_0002(DocumentVersion.Excel2003, global::_0006.PDF, DestFileName);
			break;
		case DocumentOpenType.PowerPoint:
			throw new Exception(global::_0005_2000._0002(1402773551));
		}
	}

	private string _0002(string _0002)
	{
		byte[] array = new byte[30]
		{
			86, 0, 101, 0, 114, 0, 115, 0, 105, 0,
			111, 0, 110, 0, 58, 0, 32, 0, 66, 0,
			117, 0, 105, 0, 108, 0, 100, 0, 32, 0
		};
		byte[] array2 = new byte[4] { 161, 32, 128, 30 };
		string text = string.Empty;
		FileStream fileStream = new FileStream(_0002, FileMode.Open, FileAccess.Read);
		int num = (int)fileStream.Length;
		fileStream.Seek(num - 6000, SeekOrigin.Begin);
		bool flag = false;
		int num2 = 6000;
		byte[] array3 = new byte[num2];
		num2 = fileStream.Read(array3, 0, num2 - 10);
		for (int i = 0; i < num2; i++)
		{
			int num3 = 0;
			while (array3[i] == array[num3])
			{
				num3++;
				i++;
				if (num3 != 29)
				{
					continue;
				}
				string text2 = string.Empty;
				for (; array3[i] != array2[0]; i++)
				{
					if (array3[i] != 32 && array3[i] != 0)
					{
						text2 += (char)array3[i];
					}
				}
				text = text2;
				flag = true;
				break;
			}
			if (flag)
			{
				break;
			}
		}
		fileStream.Close();
		return text.Replace('.', ',');
	}

	protected override void OnLoad(EventArgs e)
	{
		base.OnDataBinding(e);
		if (_0005_2002 != null)
		{
			_0005_2002(this, e);
		}
		if (_0008 == string.Empty)
		{
			throw new Exception(ID + global::_0005_2000._0002(1402774698) + ID + global::_0005_2000._0002(1402774761));
		}
		if (HttpContext.Current.Request.Url.ToString().EndsWith(global::_0005_2000._0002(1402775047)))
		{
			throw new Exception(global::_0005_2000._0002(1402773628));
		}
	}

	private bool _0002(string _0002)
	{
		bool result = false;
		if (_0002.ToLower().IndexOf(global::_0005_2000._0002(1402774407)) > 0)
		{
			string text = _0002.Substring(_0002.ToLower().IndexOf(global::_0005_2000._0002(1402774514)) + 7);
			text = text.Substring(0, text.IndexOf('.'));
			if (int.Parse(text) >= 42)
			{
				result = true;
			}
		}
		return result;
	}

	private bool _0003(string _0002)
	{
		bool result = false;
		if (_0002.ToLower().IndexOf(global::_0005_2000._0002(1402774496)) > 0)
		{
			string text = _0002.Substring(_0002.ToLower().IndexOf(global::_0005_2000._0002(1402774510)) + 8);
			text = text.Substring(0, text.IndexOf('.'));
			if (int.Parse(text) >= 52)
			{
				result = true;
			}
		}
		return result;
	}

	protected override void Render(HtmlTextWriter output)
	{
		output.Write(GetHtmlCode(ID));
	}

	public string GetHtmlCode(string ctrlId)
	{
		string empty = string.Empty;
		string text = string.Empty;
		if (AccessKey != string.Empty)
		{
			text = text + global::_0005_2000._0002(1402774495) + AccessKey + global::_0005_2000._0002(1402769945);
		}
		if (TabIndex != 0)
		{
			text = text + global::_0005_2000._0002(1402774321) + TabIndex + global::_0005_2000._0002(1402769945);
		}
		_0002(_000F_2001);
		empty = empty + _0002_2000 + global::_0005_2000._0002(1402774304);
		if (_0008_2001)
		{
			throw new Exception(global::_0005_2000._0002(1402774317));
		}
		if (HttpContext.Current.Request.UserAgent.IndexOf(global::_0005_2000._0002(1402774178)) > 0 || HttpContext.Current.Request.UserAgent.IndexOf(global::_0005_2000._0002(1402774191)) > 0)
		{
			empty = empty + global::_0005_2000._0002(1402774173) + ctrlId + global::_0005_2000._0002(1402774158) + text + global::_0005_2000._0002(1402769848);
			empty = empty + global::_0005_2000._0002(1402774054) + _0002_2001 + global::_0005_2000._0002(1402776971);
			empty = empty + global::_0005_2000._0002(1402776577) + global::_0003_2000._0002 + global::_0005_2000._0002(1402776699) + _0005_2001 + global::_0005_2000._0002(1402769736);
			empty += global::_0005_2000._0002(1402776687);
		}
		else
		{
			bool flag = true;
			string userAgent = HttpContext.Current.Request.UserAgent;
			if (_0002(userAgent))
			{
				if (userAgent.ToLower().IndexOf(global::_0005_2000._0002(1402776641)) > 0)
				{
					flag = false;
					empty += global::_0005_2000._0002(1402776653);
				}
				else if (userAgent.Substring(userAgent.ToLower().IndexOf(global::_0005_2000._0002(1402777458))).IndexOf(global::_0005_2000._0002(1402765371)) < 0)
				{
					flag = false;
					empty += global::_0005_2000._0002(1402777440);
				}
			}
			if (_0003(userAgent))
			{
				flag = false;
				empty += global::_0005_2000._0002(1402777107);
			}
			if (flag)
			{
				empty = empty + global::_0005_2000._0002(1402774173) + ctrlId + global::_0005_2000._0002(1402776030);
				empty = empty + global::_0005_2000._0002(1402774054) + _0002_2001 + global::_0005_2000._0002(1402775896);
				empty = empty + global::_0005_2000._0002(1402776577) + global::_0003_2000._0002 + global::_0005_2000._0002(1402776699) + _0005_2001 + global::_0005_2000._0002(1402769736);
				empty += global::_0005_2000._0002(1402776687);
			}
		}
		return empty;
	}
}
