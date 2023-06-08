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

namespace PageOffice;

[DefaultProperty("Caption")]
[Designer(typeof(PDFCtrlDesigner))]
[ToolboxData("<{0}:PDFCtrl runat=server></{0}:PDFCtrl>")]
[ToolboxBitmap(typeof(PDFCtrl), "PDFCtrl.ico")]
[DefaultEvent("Load")]
public sealed class PDFCtrl : Control
{
	private string m__0002;

	private short m__0003;

	private BorderStyleType _0005;

	private Color _0008;

	private ThemeType _0006;

	private bool _000E;

	private Color _000F;

	private Color _0002_2000;

	private bool _0003_2000;

	private Color _0005_2000;

	private Color _0008_2000;

	private bool _0006_2000;

	private bool _000E_2000;

	private string _000F_2000;

	private string _0002_2001;

	private string _0003_2001;

	private bool _0005_2001;

	private string _0008_2001;

	private string _0006_2001;

	private string _000E_2001;

	private string _000F_2001;

	private string _0002_2002;

	private bool _0003_2002;

	private string _0005_2002;

	private XmlDocument _0008_2002;

	private XmlDocument _0006_2002;

	private string _000E_2002;

	private XmlDocument _000F_2002;

	private string _0002_2003;

	private string _0003_2003;

	private string _0005_2003;

	private EventHandler _0008_2003;

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

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
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

	[Category("Accessibility")]
	[Description("The TabIndex of the control.")]
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

	[Category("Appearance")]
	[Description("控件的边框样式。")]
	[Browsable(true)]
	public BorderStyleType BorderStyle
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

	[Category("Appearance")]
	[Browsable(true)]
	[Description("边框颜色。")]
	public Color BorderColor
	{
		get
		{
			return _0008;
		}
		set
		{
			_0008 = value;
		}
	}

	[Category("Appearance")]
	[Description("控件的界面主题。")]
	[Browsable(true)]
	public ThemeType Theme
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

	[Description("设置 PDFCtrl 控件是否显示标题栏。")]
	[Category("Appearance")]
	[Browsable(true)]
	public bool Titlebar
	{
		get
		{
			return _000E;
		}
		set
		{
			_000E = value;
		}
	}

	[Category("Appearance")]
	[Browsable(true)]
	[Description("标题栏颜色。")]
	public Color TitlebarColor
	{
		get
		{
			return _000F;
		}
		set
		{
			_000F = value;
		}
	}

	[Browsable(true)]
	[Category("Appearance")]
	[Description("标题栏的文字颜色。")]
	public Color TitlebarTextColor
	{
		get
		{
			return _0002_2000;
		}
		set
		{
			_0002_2000 = value;
		}
	}

	[Category("Appearance")]
	[Description("设置 PDFCtrl 控件是否显示菜单栏。")]
	[Browsable(true)]
	public bool Menubar
	{
		get
		{
			return _0003_2000;
		}
		set
		{
			_0003_2000 = value;
		}
	}

	[Browsable(true)]
	[Description("菜单栏颜色。")]
	[Category("Appearance")]
	public Color MenubarColor
	{
		get
		{
			return _0005_2000;
		}
		set
		{
			_0005_2000 = value;
		}
	}

	[Description("菜单栏的文字颜色。")]
	[Category("Appearance")]
	[Browsable(true)]
	public Color MenubarTextColor
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

	[Description("设置 PDFCtrl 控件是否显示自定义工具栏。")]
	[Browsable(true)]
	[Category("Appearance")]
	public bool CustomToolbar
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

	[Browsable(true)]
	[Description("设置 PDFCtrl 控件标题栏文字。")]
	[Category("Appearance")]
	public string Caption
	{
		get
		{
			return _000F_2000;
		}
		set
		{
			_000F_2000 = value;
		}
	}

	[Browsable(false)]
	public bool AllowCopy
	{
		get
		{
			return _000E_2000;
		}
		set
		{
			_000E_2000 = value;
		}
	}

	[Browsable(false)]
	public string FileTitle
	{
		get
		{
			return _0002_2001;
		}
		set
		{
			_0002_2001 = value;
		}
	}

	[Browsable(false)]
	public string ServerPage
	{
		get
		{
			return _0003_2001;
		}
		set
		{
			_0003_2001 = value;
			if (!(_0003_2001 != string.Empty))
			{
				return;
			}
			string text = _0003_2001.ToLower();
			if (text.StartsWith(global::_0005_2000._0002(1402771699)) || text.StartsWith(global::_0005_2000._0002(1402771681)))
			{
				if (text.StartsWith(global::_0005_2000._0002(1402771699)))
				{
					text = _0003_2001.Substring(7);
				}
				else if (text.StartsWith(global::_0005_2000._0002(1402771681)))
				{
					text = _0003_2001.Substring(8);
				}
				if (text.IndexOf('/') > -1)
				{
					text = text.Substring(text.IndexOf('/'));
				}
			}
			if (text == string.Empty)
			{
				throw new Exception(ID + global::_0005_2000._0002(1402771694) + _0003_2001 + global::_0005_2000._0002(1402771652));
			}
			HttpServerUtility server = HttpContext.Current.Server;
			try
			{
				_0006_2001 = text;
				text = server.MapPath(text);
			}
			catch
			{
				throw new Exception(ID + global::_0005_2000._0002(1402771694) + _0003_2001 + global::_0005_2000._0002(1402771652));
			}
			File.Exists(text);
			_0008_2001 = text;
			_000F_2001 = _0008_2001.Substring(0, _0008_2001.LastIndexOf('\\'));
			HttpRequest request = HttpContext.Current.Request;
			_0008_2001 = _0008_2001.Substring(0, _0008_2001.LastIndexOf('\\')) + global::_0005_2000._0002(1402771495);
			if (!File.Exists(_0008_2001))
			{
				throw new Exception(global::_0005_2000._0002(1402771480) + _0008_2001 + global::_0005_2000._0002(1402780083));
			}
			_0002_2002 = _0002(_0008_2001);
			if (_0002_2002.EndsWith(global::_0005_2000._0002(1402772392)))
			{
				_0002_2002 = _0002_2002.Substring(0, _0002_2002.Length - 4);
				_0003_2002 = true;
			}
			_0006_2001 = _0006_2001.Substring(0, _0006_2001.LastIndexOf('/')) + global::_0005_2000._0002(1402772373);
			if (_0006_2001[0] == '/')
			{
				string text2 = request.ApplicationPath;
				if (text2[0] == '/')
				{
					text2 = string.Empty;
				}
				_0006_2001 = request.Url.AbsoluteUri.Substring(0, request.Url.AbsoluteUri.IndexOf('/', 8)) + text2 + _0006_2001;
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
				_0006_2001 = text3.Substring(0, num2 + 1) + _0006_2001;
			}
			if (request.Url.Authority != request.ServerVariables[global::_0005_2000._0002(1402772358)])
			{
				_0006_2001 = _0006_2001.Replace(request.Url.Authority, request.ServerVariables[global::_0005_2000._0002(1402772358)]);
			}
			_000E_2001 = _0006_2001.Substring(0, _0006_2001.LastIndexOf('/') + 1) + global::_0005_2000._0002(1402772470);
			_0006_2001 = _0006_2001 + global::_0005_2000._0002(1402772456) + _0002(_0008_2001);
		}
	}

	[Browsable(false)]
	public string HTTPBasic_UserName
	{
		get
		{
			return _0003_2003;
		}
		set
		{
			_0003_2003 = value;
		}
	}

	[Browsable(false)]
	public string HTTPBasic_Password
	{
		get
		{
			return _0005_2003;
		}
		set
		{
			_0005_2003 = value;
		}
	}

	[Browsable(false)]
	public string JsFunction_AfterDocumentOpened
	{
		get
		{
			return _0005_2002;
		}
		set
		{
			_0005_2002 = value;
		}
	}

	[Category("Document")]
	[Description("在此事件里为 PageOffice PDF control 控件编写初始化及打开文档的代码。")]
	public new event EventHandler Load
	{
		add
		{
			EventHandler eventHandler = _0008_2003;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref _0008_2003, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		remove
		{
			EventHandler eventHandler = _0008_2003;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref _0008_2003, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public PDFCtrl()
	{
		this.m__0002 = string.Empty;
		this.m__0003 = 0;
		_0005 = BorderStyleType.BorderFlat;
		_0008 = SystemColors.ButtonShadow;
		_0006 = ThemeType.Office2007;
		_000E = true;
		_000F = SystemColors.ActiveCaption;
		_0002_2000 = SystemColors.ActiveCaptionText;
		_0003_2000 = true;
		_0005_2000 = SystemColors.ButtonFace;
		_0008_2000 = SystemColors.WindowText;
		_0006_2000 = true;
		_000E_2000 = true;
		_000F_2000 = string.Empty;
		_0002_2001 = string.Empty;
		_0003_2001 = string.Empty;
		_0005_2001 = false;
		_0006_2001 = string.Empty;
		_000E_2001 = string.Empty;
		_0008_2001 = string.Empty;
		_000F_2001 = string.Empty;
		_0002_2002 = string.Empty;
		_0005_2002 = string.Empty;
		_0008_2002 = null;
		_0006_2002 = null;
		_000E_2002 = string.Empty;
		_0002_2003 = string.Empty;
		_0003_2003 = string.Empty;
		_0005_2003 = string.Empty;
		_0003_2002 = false;
		_000F_2002 = new XmlDocument();
		StringBuilder stringBuilder = new StringBuilder(global::_0005_2000._0002(1402773238));
		stringBuilder.Append(global::_0005_2000._0002(1402781264));
		stringBuilder.Append(global::_0005_2000._0002(1402781248));
		_000F_2002.LoadXml(stringBuilder.ToString());
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
		if (_0005 != BorderStyleType.BorderFlat)
		{
			XmlNode xmlNode = _0002.CreateElement(global::_0005_2000._0002(1402777608));
			int num = (int)_0005;
			xmlNode.InnerText = num.ToString();
			documentElement.AppendChild(xmlNode);
		}
		if (_0008 != SystemColors.ButtonShadow)
		{
			XmlNode xmlNode2 = _0002.CreateElement(global::_0005_2000._0002(1402777722));
			xmlNode2.InnerText = ColorTranslator.ToOle(_0008).ToString();
			documentElement.AppendChild(xmlNode2);
		}
		if (_0006 != ThemeType.Office2007)
		{
			string innerText = global::_0005_2000._0002(1402770027);
			switch (_0006)
			{
			case ThemeType.CustomStyle:
				innerText = global::_0005_2000._0002(1402770019);
				break;
			case ThemeType.Office2007:
				innerText = global::_0005_2000._0002(1402770027);
				break;
			case ThemeType.Office2010:
				innerText = global::_0005_2000._0002(1402777708);
				break;
			}
			XmlNode xmlNode3 = _0002.CreateElement(global::_0005_2000._0002(1402766967));
			xmlNode3.InnerText = innerText;
			documentElement.AppendChild(xmlNode3);
		}
		if (!_000E)
		{
			XmlNode xmlNode4 = _0002.CreateElement(global::_0005_2000._0002(1402767043));
			xmlNode4.InnerText = global::_0005_2000._0002(1402770019);
			documentElement.AppendChild(xmlNode4);
		}
		if (_000F != SystemColors.ActiveCaption)
		{
			XmlNode xmlNode5 = _0002.CreateElement(global::_0005_2000._0002(1402777684));
			xmlNode5.InnerText = ColorTranslator.ToOle(_000F).ToString();
			documentElement.AppendChild(xmlNode5);
		}
		if (_0002_2000 != SystemColors.ActiveCaptionText)
		{
			XmlNode xmlNode6 = _0002.CreateElement(global::_0005_2000._0002(1402777672));
			xmlNode6.InnerText = ColorTranslator.ToOle(_0002_2000).ToString();
			documentElement.AppendChild(xmlNode6);
		}
		if (!_0003_2000)
		{
			XmlNode xmlNode7 = _0002.CreateElement(global::_0005_2000._0002(1402766896));
			xmlNode7.InnerText = global::_0005_2000._0002(1402770019);
			documentElement.AppendChild(xmlNode7);
		}
		if (_0005_2000 != SystemColors.ButtonFace)
		{
			XmlNode xmlNode8 = _0002.CreateElement(global::_0005_2000._0002(1402778528));
			xmlNode8.InnerText = ColorTranslator.ToOle(_0005_2000).ToString();
			documentElement.AppendChild(xmlNode8);
		}
		if (_0008_2000 != SystemColors.WindowText)
		{
			XmlNode xmlNode9 = _0002.CreateElement(global::_0005_2000._0002(1402778517));
			xmlNode9.InnerText = ColorTranslator.ToOle(_0008_2000).ToString();
			documentElement.AppendChild(xmlNode9);
		}
		if (!_0006_2000)
		{
			XmlNode xmlNode10 = _0002.CreateElement(global::_0005_2000._0002(1402766910));
			xmlNode10.InnerText = global::_0005_2000._0002(1402770019);
			documentElement.AppendChild(xmlNode10);
		}
		if (!_000E_2000)
		{
			XmlNode xmlNode11 = _0002.CreateElement(global::_0005_2000._0002(1402778506));
			xmlNode11.InnerText = global::_0005_2000._0002(1402770019);
			documentElement.AppendChild(xmlNode11);
		}
		if (_000F_2000 != string.Empty)
		{
			XmlNode xmlNode12 = _0002.CreateElement(global::_0005_2000._0002(1402766857));
			xmlNode12.InnerText = global::_0003_2000._0006(_000F_2000);
			documentElement.AppendChild(xmlNode12);
		}
		if (_0002_2001 != string.Empty)
		{
			XmlNode xmlNode13 = _0002.CreateElement(global::_0005_2000._0002(1402772440));
			xmlNode13.InnerText = global::_0003_2000._0006(_0002_2001);
			documentElement.AppendChild(xmlNode13);
		}
		if (_0003_2001 != string.Empty)
		{
			XmlNode xmlNode14 = _0002.CreateElement(global::_0005_2000._0002(1402772424));
			xmlNode14.InnerText = _0003_2001;
			documentElement.AppendChild(xmlNode14);
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
			XmlNode xmlNode15 = _0002.CreateElement(global::_0005_2000._0002(1402772340));
			xmlNode15.InnerText = text;
			documentElement.AppendChild(xmlNode15);
		}
		if (_0003_2003 != string.Empty)
		{
			XmlNode xmlNode16 = _0002.CreateElement(global::_0005_2000._0002(1402772153));
			xmlNode16.InnerText = global::_0003_2000._0006(_0003_2003);
			documentElement.AppendChild(xmlNode16);
		}
		if (_0005_2003 != string.Empty)
		{
			XmlNode xmlNode17 = _0002.CreateElement(global::_0005_2000._0002(1402772112));
			xmlNode17.InnerText = _0005_2003;
			documentElement.AppendChild(xmlNode17);
		}
		if (_0005_2002 != string.Empty)
		{
			XmlNode xmlNode18 = _0002.CreateElement(global::_0005_2000._0002(1402772107));
			xmlNode18.InnerText = _0005_2002;
			documentElement.AppendChild(xmlNode18);
		}
		if (_0008_2002 != null)
		{
			XmlNode xmlNode19 = _0002.CreateElement(global::_0005_2000._0002(1402778367));
			xmlNode19.InnerXml = _0008_2002.DocumentElement.InnerXml;
			documentElement.AppendChild(xmlNode19);
		}
		if (_0006_2002 != null)
		{
			XmlNode xmlNode20 = _0002.CreateElement(global::_0005_2000._0002(1402778325));
			xmlNode20.InnerXml = _0006_2002.DocumentElement.InnerXml;
			documentElement.AppendChild(xmlNode20);
		}
		if (_000E_2002 != string.Empty)
		{
			XmlNode xmlNode21 = _0002.CreateElement(global::_0005_2000._0002(1402778317));
			xmlNode21.InnerText = global::_0003_2000._0006(_000E_2002);
			documentElement.AppendChild(xmlNode21);
		}
		if (_0002_2002 != string.Empty)
		{
			XmlNode xmlNode22 = _0002.CreateElement(global::_0005_2000._0002(1402772007));
			xmlNode22.InnerText = _0002_2002;
			documentElement.AppendChild(xmlNode22);
		}
		string innerXml = _0002.InnerXml;
		if (innerXml != string.Empty)
		{
			_0002_2003 = _0002_2003 + global::_0005_2000._0002(1402780122) + global::_0003_2000._0002(innerXml) + global::_0005_2000._0002(1402771936);
		}
	}

	public void AddCustomToolButton(string Caption, string JsFunction, int IconIndex)
	{
		XmlNode xmlNode = null;
		if (_0006_2002 == null)
		{
			_0006_2002 = new XmlDocument();
			xmlNode = _0006_2002.CreateElement(global::_0005_2000._0002(1402778325));
			_0006_2002.AppendChild(xmlNode);
		}
		XmlNode documentElement = _0006_2002.DocumentElement;
		xmlNode = _0006_2002.CreateElement(global::_0005_2000._0002(1402781075));
		XmlAttribute xmlAttribute = _0006_2002.CreateAttribute(global::_0005_2000._0002(1402766857));
		xmlAttribute.InnerText = global::_0003_2000._0006(Caption);
		xmlNode.Attributes.Append(xmlAttribute);
		xmlAttribute = _0006_2002.CreateAttribute(global::_0005_2000._0002(1402781106));
		xmlAttribute.InnerText = JsFunction;
		xmlNode.Attributes.Append(xmlAttribute);
		xmlAttribute = _0006_2002.CreateAttribute(global::_0005_2000._0002(1402781058));
		xmlAttribute.InnerText = IconIndex.ToString();
		xmlNode.Attributes.Append(xmlAttribute);
		documentElement.AppendChild(xmlNode);
	}

	public void WebOpen(string DocumentURL)
	{
		if (DocumentURL == null || DocumentURL == string.Empty)
		{
			throw new Exception(global::_0005_2000._0002(1402774810));
		}
		if (_0003_2001 == string.Empty)
		{
			throw new Exception(ID + global::_0005_2000._0002(1402774698) + ID + global::_0005_2000._0002(1402774761));
		}
		int num = DocumentURL.IndexOf(global::_0005_2000._0002(1402774604));
		bool flag = true;
		if (num > -1)
		{
			flag = false;
			if (!File.Exists(DocumentURL))
			{
				throw new Exception(global::_0005_2000._0002(1402775479) + DocumentURL + global::_0005_2000._0002(1402775470));
			}
			string text = global::_0003_2000._000F(DocumentURL);
			text = text.ToLower();
			if (!text.Equals(global::_0005_2000._0002(1402780017)))
			{
				throw new Exception(global::_0005_2000._0002(1402780026) + DocumentURL + global::_0005_2000._0002(1402779999));
			}
		}
		else
		{
			flag = true;
		}
		if (!_0005_2001)
		{
			XmlNode documentElement = _000F_2002.DocumentElement;
			XmlNode xmlNode = _000F_2002.CreateElement(global::_0005_2000._0002(1402775183));
			XmlAttribute xmlAttribute = _000F_2002.CreateAttribute(global::_0005_2000._0002(1402775293));
			if (flag)
			{
				xmlAttribute.InnerText = DocumentURL;
			}
			else
			{
				string text2 = DocumentURL.Substring(DocumentURL.LastIndexOf(global::_0005_2000._0002(1402775274)) + 1);
				string text3 = global::_0003_2000._0002(global::_0005_2000._0002(1402775250) + DocumentURL + global::_0005_2000._0002(1402775262) + text2);
				text3 = text3.Replace(global::_0005_2000._0002(1402775060), global::_0005_2000._0002(1402775068)).Replace(global::_0005_2000._0002(1402775047), global::_0005_2000._0002(1402775055)).Replace(global::_0005_2000._0002(1402769483), global::_0005_2000._0002(1402775158));
				xmlAttribute.InnerText = _0003_2001 + global::_0005_2000._0002(1402775137) + text3;
			}
			xmlNode.Attributes.Append(xmlAttribute);
			documentElement.AppendChild(xmlNode);
			_0005_2001 = true;
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
		if (_0008_2003 != null)
		{
			_0008_2003(this, e);
		}
		if (_0003_2001 == string.Empty)
		{
			throw new Exception(ID + global::_0005_2000._0002(1402774698) + ID + global::_0005_2000._0002(1402774761));
		}
		if (HttpContext.Current.Request.Url.ToString().EndsWith(global::_0005_2000._0002(1402775047)))
		{
			throw new Exception(global::_0005_2000._0002(1402779832));
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
		_0002(_000F_2002);
		empty = empty + _0002_2003 + global::_0005_2000._0002(1402774304);
		if (_0003_2002)
		{
			throw new Exception(global::_0005_2000._0002(1402779701));
		}
		if (HttpContext.Current.Request.UserAgent.IndexOf(global::_0005_2000._0002(1402774178)) > 0 || HttpContext.Current.Request.UserAgent.IndexOf(global::_0005_2000._0002(1402774191)) > 0)
		{
			empty = empty + global::_0005_2000._0002(1402774173) + ctrlId + global::_0005_2000._0002(1402779738) + text + global::_0005_2000._0002(1402769848);
			empty = empty + global::_0005_2000._0002(1402774054) + _000E_2001 + global::_0005_2000._0002(1402780661);
			empty = empty + global::_0005_2000._0002(1402776577) + global::_0003_2000._0002 + global::_0005_2000._0002(1402776699) + _0002_2002 + global::_0005_2000._0002(1402769736);
			empty += global::_0005_2000._0002(1402781518);
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
					empty += global::_0005_2000._0002(1402780275);
				}
				else if (userAgent.Substring(userAgent.ToLower().IndexOf(global::_0005_2000._0002(1402777458))).IndexOf(global::_0005_2000._0002(1402765371)) < 0)
				{
					flag = false;
					empty += global::_0005_2000._0002(1402783008);
				}
			}
			if (_0003(userAgent))
			{
				flag = false;
				empty += global::_0005_2000._0002(1402782939);
			}
			if (flag)
			{
				empty = empty + global::_0005_2000._0002(1402774173) + ctrlId + global::_0005_2000._0002(1402783630);
				empty = empty + global::_0005_2000._0002(1402774054) + _000E_2001 + global::_0005_2000._0002(1402783499);
				empty = empty + global::_0005_2000._0002(1402776577) + global::_0003_2000._0002 + global::_0005_2000._0002(1402776699) + _0002_2002 + global::_0005_2000._0002(1402769736);
				empty += global::_0005_2000._0002(1402781518);
			}
		}
		return empty;
	}
}
