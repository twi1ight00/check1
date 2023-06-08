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
using PageOffice.Ribbon;
using PageOffice.WordWriter;
using PageOfficeExt;

namespace PageOffice;

[ToolboxBitmap(typeof(PageOfficeCtrl), "PageOfficeCtrl.ico")]
[Designer(typeof(PageOfficeCtrlDesigner))]
[DefaultProperty("Caption")]
[ToolboxData("<{0}:PageOfficeCtrl runat=server></{0}:PageOfficeCtrl>")]
[DefaultEvent("Load")]
public sealed class PageOfficeCtrl : Control
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

	private bool _000F_2000;

	private bool _0002_2001;

	private string _0003_2001;

	private string _0005_2001;

	private string _0008_2001;

	private string _0006_2001;

	private string _000E_2001;

	private bool _000F_2001;

	private string _0002_2002;

	private int _0003_2002;

	private bool _0005_2002;

	private string _0008_2002;

	private string _0006_2002;

	private int _000E_2002;

	private string _000F_2002;

	private string _0002_2003;

	private string _0003_2003;

	private string _0005_2003;

	private string _0008_2003;

	private string _0006_2003;

	private string _000E_2003;

	private string _000F_2003;

	private string _0002_2004;

	private string _0003_2004;

	private string _0005_2004;

	private string _0008_2004;

	private XmlDocument _0006_2004;

	private XmlDocument _000E_2004;

	private string _000F_2004;

	private XmlDocument _0002_2005;

	private OfficeVendorType _0003_2005;

	private string _0005_2005;

	private bool _0008_2005;

	private string _0006_2005;

	private bool _000E_2005;

	private Toolbar _000F_2005;

	private EventHandler _0002_2006;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
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

	[Browsable(true)]
	[Category("Accessibility")]
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

	[Browsable(true)]
	[Category("Appearance")]
	[Description("控件的边框样式。")]
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

	[Browsable(true)]
	[Category("Appearance")]
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

	[Description("控件的界面主题。")]
	[Browsable(true)]
	[Category("Appearance")]
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

	[Category("Appearance")]
	[Description("设置 PageOfficeCtrl 控件是否显示标题栏。")]
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

	[Description("标题栏颜色。")]
	[Category("Appearance")]
	[Browsable(true)]
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

	[Description("标题栏的文字颜色。")]
	[Browsable(true)]
	[Category("Appearance")]
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
	[Description("设置 PageOfficeCtrl 控件是否显示菜单栏。")]
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

	[Browsable(true)]
	[Description("菜单栏的文字颜色。")]
	[Category("Appearance")]
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

	[Description("设置 PageOfficeCtrl 控件是否显示自定义工具栏。")]
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

	[Category("Appearance")]
	[Browsable(true)]
	[Description("设置 PageOfficeCtrl 控件是否显示Office工具栏。")]
	public bool OfficeToolbars
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

	[Browsable(true)]
	[Description("设置 PageOfficeCtrl 控件标题栏文字。")]
	[Category("Appearance")]
	public string Caption
	{
		get
		{
			return _0003_2001;
		}
		set
		{
			_0003_2001 = value;
		}
	}

	[Browsable(false)]
	public bool AllowCopy
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
	public bool DisableCopyOnly
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
	public string FileTitle
	{
		get
		{
			return _0005_2001;
		}
		set
		{
			_0005_2001 = value;
		}
	}

	[Browsable(false)]
	public string ServerPage
	{
		get
		{
			return _0008_2001;
		}
		set
		{
			_0008_2001 = value;
			if (!(_0008_2001 != string.Empty))
			{
				return;
			}
			string text = _0008_2001.ToLower();
			if (text.StartsWith(global::_0005_2000._0002(1402771699)) || text.StartsWith(global::_0005_2000._0002(1402771681)))
			{
				if (text.StartsWith(global::_0005_2000._0002(1402771699)))
				{
					text = _0008_2001.Substring(7);
				}
				else if (text.StartsWith(global::_0005_2000._0002(1402771681)))
				{
					text = _0008_2001.Substring(8);
				}
				if (text.IndexOf('/') > -1)
				{
					text = text.Substring(text.IndexOf('/'));
				}
			}
			if (text == string.Empty)
			{
				throw new Exception(ID + global::_0005_2000._0002(1402771694) + _0008_2001 + global::_0005_2000._0002(1402771652));
			}
			HttpServerUtility server = HttpContext.Current.Server;
			try
			{
				_0002_2003 = text;
				text = server.MapPath(text);
			}
			catch
			{
				throw new Exception(ID + global::_0005_2000._0002(1402771694) + _0008_2001 + global::_0005_2000._0002(1402771652));
			}
			File.Exists(text);
			_000F_2002 = text;
			_0005_2003 = _000F_2002.Substring(0, _000F_2002.LastIndexOf('\\'));
			HttpRequest request = HttpContext.Current.Request;
			_000F_2002 = _000F_2002.Substring(0, _000F_2002.LastIndexOf('\\')) + global::_0005_2000._0002(1402771495);
			if (!File.Exists(_000F_2002))
			{
				throw new Exception(global::_0005_2000._0002(1402771480) + _000F_2002 + global::_0005_2000._0002(1402771465));
			}
			_0008_2003 = _0002(_000F_2002);
			_0002_2003 = _0002_2003.Substring(0, _0002_2003.LastIndexOf('/')) + global::_0005_2000._0002(1402772373);
			if (_0002_2003[0] == '/')
			{
				string text2 = request.ApplicationPath;
				if (text2[0] == '/')
				{
					text2 = string.Empty;
				}
				_0002_2003 = request.Url.AbsoluteUri.Substring(0, request.Url.AbsoluteUri.IndexOf('/', 8)) + text2 + _0002_2003;
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
				_0002_2003 = text3.Substring(0, num2 + 1) + _0002_2003;
			}
			if (request.Url.Authority != request.ServerVariables[global::_0005_2000._0002(1402772358)])
			{
				_0002_2003 = _0002_2003.Replace(request.Url.Authority, request.ServerVariables[global::_0005_2000._0002(1402772358)]);
			}
			_0003_2003 = _0002_2003.Substring(0, _0002_2003.LastIndexOf('/') + 1) + global::_0005_2000._0002(1402772470);
			_0002_2003 = _0002_2003 + global::_0005_2000._0002(1402772456) + _0002(_000F_2002);
		}
	}

	[Browsable(false)]
	public string SaveFilePage
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
	public string SaveDataPage
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
	public int SaveFileMaxSize
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

	[Browsable(false)]
	public bool CompressDocument
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

	[Browsable(false)]
	public string HTTPBasic_UserName
	{
		get
		{
			return _0008_2002;
		}
		set
		{
			_0008_2002 = value;
		}
	}

	[Browsable(false)]
	public string HTTPBasic_Password
	{
		get
		{
			return _0006_2002;
		}
		set
		{
			_0006_2002 = value;
		}
	}

	[Browsable(false)]
	public int TimeSlice
	{
		get
		{
			return _000E_2002;
		}
		set
		{
			_000E_2002 = value;
		}
	}

	[Browsable(false)]
	public string JsFunction_AfterDocumentOpened
	{
		get
		{
			return _0006_2003;
		}
		set
		{
			_0006_2003 = value;
		}
	}

	[Browsable(false)]
	public string JsFunction_AfterDocumentClosed
	{
		get
		{
			return _000E_2003;
		}
		set
		{
			_000E_2003 = value;
		}
	}

	[Browsable(false)]
	public string JsFunction_AfterDocumentSaved
	{
		get
		{
			return _000F_2003;
		}
		set
		{
			_000F_2003 = value;
		}
	}

	[Browsable(false)]
	public string JsFunction_BeforeDocumentClosed
	{
		get
		{
			return _0002_2004;
		}
		set
		{
			_0002_2004 = value;
		}
	}

	[Browsable(false)]
	public string JsFunction_BeforeDocumentSaved
	{
		get
		{
			return _0003_2004;
		}
		set
		{
			_0003_2004 = value;
		}
	}

	[Browsable(false)]
	public string JsFunction_OnWordDataRegionClick
	{
		get
		{
			return _0005_2004;
		}
		set
		{
			_0005_2004 = value;
		}
	}

	[Browsable(false)]
	public string JsFunction_OnExcelCellClick
	{
		get
		{
			return _0008_2004;
		}
		set
		{
			_0008_2004 = value;
		}
	}

	[Browsable(false)]
	public string CustomMenuCaption
	{
		get
		{
			return _000F_2004;
		}
		set
		{
			_000F_2004 = value;
		}
	}

	[Browsable(false)]
	public OfficeVendorType OfficeVendor
	{
		get
		{
			return _0003_2005;
		}
		set
		{
			_0003_2005 = value;
		}
	}

	[Browsable(false)]
	public string ProtectPassword
	{
		set
		{
			_0005_2005 = value;
		}
	}

	public new bool Visible
	{
		get
		{
			return _0008_2005;
		}
		set
		{
			_0008_2005 = value;
		}
	}

	[Browsable(false)]
	public string ZoomSealServer
	{
		get
		{
			return _0006_2005;
		}
		set
		{
			_0006_2005 = value;
		}
	}

	[Browsable(false)]
	public bool EnableUserProtection
	{
		get
		{
			return _000E_2005;
		}
		set
		{
			_000E_2005 = value;
		}
	}

	public Toolbar RibbonBar
	{
		get
		{
			if (_000F_2005 == null)
			{
				_000F_2005 = new Toolbar();
			}
			return _000F_2005;
		}
	}

	[Category("Document")]
	[Description("在此事件里为 PageOfficeCtrl 控件编写初始化及打开文档的代码。")]
	public new event EventHandler Load
	{
		add
		{
			EventHandler eventHandler = _0002_2006;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref _0002_2006, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		remove
		{
			EventHandler eventHandler = _0002_2006;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref _0002_2006, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public PageOfficeCtrl()
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
		_000F_2000 = true;
		_0002_2001 = false;
		_0003_2001 = string.Empty;
		_0005_2001 = string.Empty;
		_0008_2001 = string.Empty;
		_0006_2001 = string.Empty;
		_000E_2001 = string.Empty;
		_000F_2001 = false;
		_0002_2002 = string.Empty;
		_0003_2002 = 0;
		_0005_2002 = false;
		_0008_2002 = string.Empty;
		_0006_2002 = string.Empty;
		_000E_2002 = 0;
		_0002_2003 = string.Empty;
		_0003_2003 = string.Empty;
		_000F_2002 = string.Empty;
		_0005_2003 = string.Empty;
		_0008_2003 = string.Empty;
		_0006_2003 = string.Empty;
		_000E_2003 = string.Empty;
		_000F_2003 = string.Empty;
		_0002_2004 = string.Empty;
		_0003_2004 = string.Empty;
		_0005_2004 = string.Empty;
		_0008_2004 = string.Empty;
		_0006_2004 = null;
		_000E_2004 = null;
		_000F_2004 = string.Empty;
		_0003_2005 = OfficeVendorType.MSOffice;
		_0005_2005 = string.Empty;
		_0008_2005 = true;
		_0006_2005 = string.Empty;
		_000E_2005 = false;
		_000F_2005 = null;
		_0002_2005 = new XmlDocument();
		StringBuilder stringBuilder = new StringBuilder(global::_0005_2000._0002(1402773238));
		stringBuilder.Append(global::_0005_2000._0002(1402777659));
		stringBuilder.Append(global::_0005_2000._0002(1402777616));
		_0002_2005.LoadXml(stringBuilder.ToString());
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
			XmlNode xmlNode11 = _0002.CreateElement(global::_0005_2000._0002(1402766866));
			xmlNode11.InnerText = global::_0005_2000._0002(1402770019);
			documentElement.AppendChild(xmlNode11);
		}
		if (!_000F_2000)
		{
			XmlNode xmlNode12 = _0002.CreateElement(global::_0005_2000._0002(1402778506));
			xmlNode12.InnerText = global::_0005_2000._0002(1402770019);
			documentElement.AppendChild(xmlNode12);
		}
		if (_0002_2001)
		{
			XmlNode xmlNode13 = _0002.CreateElement(global::_0005_2000._0002(1402778618));
			xmlNode13.InnerText = global::_0005_2000._0002(1402770027);
			documentElement.AppendChild(xmlNode13);
		}
		if (_0003_2001 != string.Empty)
		{
			XmlNode xmlNode14 = _0002.CreateElement(global::_0005_2000._0002(1402766857));
			xmlNode14.InnerText = global::_0003_2000._0006(_0003_2001);
			documentElement.AppendChild(xmlNode14);
		}
		if (_0005_2001 != string.Empty)
		{
			XmlNode xmlNode15 = _0002.CreateElement(global::_0005_2000._0002(1402772440));
			xmlNode15.InnerText = global::_0003_2000._0006(_0005_2001);
			documentElement.AppendChild(xmlNode15);
		}
		if (_0008_2001 != string.Empty)
		{
			XmlNode xmlNode16 = _0002.CreateElement(global::_0005_2000._0002(1402772424));
			xmlNode16.InnerText = _0008_2001;
			documentElement.AppendChild(xmlNode16);
		}
		if (_0006_2001 != string.Empty)
		{
			XmlNode xmlNode17 = _0002.CreateElement(global::_0005_2000._0002(1402772283));
			xmlNode17.InnerText = _0006_2001;
			documentElement.AppendChild(xmlNode17);
		}
		if (_000E_2001 != string.Empty)
		{
			XmlNode xmlNode18 = _0002.CreateElement(global::_0005_2000._0002(1402772268));
			xmlNode18.InnerText = _000E_2001;
			documentElement.AppendChild(xmlNode18);
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
			XmlNode xmlNode19 = _0002.CreateElement(global::_0005_2000._0002(1402772340));
			xmlNode19.InnerText = text;
			documentElement.AppendChild(xmlNode19);
		}
		if (_0003_2002 > 0)
		{
			XmlNode xmlNode20 = _0002.CreateElement(global::_0005_2000._0002(1402772330));
			xmlNode20.InnerText = _0003_2002.ToString();
			documentElement.AppendChild(xmlNode20);
		}
		if (_0005_2002)
		{
			XmlNode xmlNode21 = _0002.CreateElement(global::_0005_2000._0002(1402772288));
			xmlNode21.InnerText = global::_0005_2000._0002(1402770027);
			documentElement.AppendChild(xmlNode21);
		}
		if (_0008_2002 != string.Empty)
		{
			XmlNode xmlNode22 = _0002.CreateElement(global::_0005_2000._0002(1402772153));
			xmlNode22.InnerText = global::_0003_2000._0006(_0008_2002);
			documentElement.AppendChild(xmlNode22);
		}
		if (_0006_2002 != string.Empty)
		{
			XmlNode xmlNode23 = _0002.CreateElement(global::_0005_2000._0002(1402772112));
			xmlNode23.InnerText = _0006_2002;
			documentElement.AppendChild(xmlNode23);
		}
		if (_000E_2002 > 0)
		{
			XmlNode xmlNode24 = _0002.CreateElement(global::_0005_2000._0002(1402778576));
			xmlNode24.InnerText = _000E_2002.ToString();
			documentElement.AppendChild(xmlNode24);
		}
		if (_0006_2003 != string.Empty)
		{
			XmlNode xmlNode25 = _0002.CreateElement(global::_0005_2000._0002(1402772107));
			xmlNode25.InnerText = _0006_2003;
			documentElement.AppendChild(xmlNode25);
		}
		if (_000E_2003 != string.Empty)
		{
			XmlNode xmlNode26 = _0002.CreateElement(global::_0005_2000._0002(1402778560));
			xmlNode26.InnerText = _000E_2003;
			documentElement.AppendChild(xmlNode26);
		}
		if (_000F_2003 != string.Empty)
		{
			XmlNode xmlNode27 = _0002.CreateElement(global::_0005_2000._0002(1402778407));
			xmlNode27.InnerText = _000F_2003;
			documentElement.AppendChild(xmlNode27);
		}
		if (_0002_2004 != string.Empty)
		{
			XmlNode xmlNode28 = _0002.CreateElement(global::_0005_2000._0002(1402778379));
			xmlNode28.InnerText = _0002_2004;
			documentElement.AppendChild(xmlNode28);
		}
		if (_0003_2004 != string.Empty)
		{
			XmlNode xmlNode29 = _0002.CreateElement(global::_0005_2000._0002(1402778449));
			xmlNode29.InnerText = _0003_2004;
			documentElement.AppendChild(xmlNode29);
		}
		if (_0005_2004 != string.Empty)
		{
			XmlNode xmlNode30 = _0002.CreateElement(global::_0005_2000._0002(1402778292));
			xmlNode30.InnerText = _0005_2004;
			documentElement.AppendChild(xmlNode30);
		}
		if (_0008_2004 != string.Empty)
		{
			XmlNode xmlNode31 = _0002.CreateElement(global::_0005_2000._0002(1402778269));
			xmlNode31.InnerText = _0008_2004;
			documentElement.AppendChild(xmlNode31);
		}
		if (_0006_2004 != null)
		{
			XmlNode xmlNode32 = _0002.CreateElement(global::_0005_2000._0002(1402778367));
			xmlNode32.InnerXml = _0006_2004.DocumentElement.InnerXml;
			documentElement.AppendChild(xmlNode32);
		}
		if (_000E_2004 != null)
		{
			XmlNode xmlNode33 = _0002.CreateElement(global::_0005_2000._0002(1402778325));
			xmlNode33.InnerXml = _000E_2004.DocumentElement.InnerXml;
			documentElement.AppendChild(xmlNode33);
		}
		if (_000F_2004 != string.Empty)
		{
			XmlNode xmlNode34 = _0002.CreateElement(global::_0005_2000._0002(1402778317));
			xmlNode34.InnerText = global::_0003_2000._0006(_000F_2004);
			documentElement.AppendChild(xmlNode34);
		}
		if (_0003_2005 != 0)
		{
			XmlNode xmlNode35 = _0002.CreateElement(global::_0005_2000._0002(1402772018));
			int num2 = (int)_0003_2005;
			xmlNode35.InnerText = num2.ToString();
			documentElement.AppendChild(xmlNode35);
		}
		if (_0005_2005 != string.Empty)
		{
			XmlNode xmlNode36 = _0002.CreateElement(global::_0005_2000._0002(1402778149));
			xmlNode36.InnerText = _0005_2005;
			documentElement.AppendChild(xmlNode36);
		}
		XmlNode xmlNode37 = _0002.CreateElement(global::_0005_2000._0002(1402778139));
		xmlNode37.InnerText = global::_0003_2000._0006(HttpContext.Current.CurrentHandler.ToString());
		documentElement.AppendChild(xmlNode37);
		if (_0008_2003 != string.Empty)
		{
			XmlNode xmlNode38 = _0002.CreateElement(global::_0005_2000._0002(1402772007));
			xmlNode38.InnerText = _0008_2003;
			documentElement.AppendChild(xmlNode38);
		}
		if (_0006_2005 != string.Empty)
		{
			XmlNode xmlNode39 = _0002.CreateElement(global::_0005_2000._0002(1402771995));
			xmlNode39.InnerText = _0006_2005;
			documentElement.AppendChild(xmlNode39);
		}
		if (_000E_2005)
		{
			XmlNode xmlNode40 = _0002.CreateElement(global::_0005_2000._0002(1402778226));
			xmlNode40.InnerText = global::_0005_2000._0002(1402770027);
			documentElement.AppendChild(xmlNode40);
		}
		if (_000F_2005 != null)
		{
			XmlNode xmlNode41 = _0002.CreateElement(global::_0005_2000._0002(1402778223));
			xmlNode41.InnerText = _000F_2005._0002();
			documentElement.AppendChild(xmlNode41);
		}
		string innerXml = _0002.InnerXml;
		if (innerXml != string.Empty)
		{
			_0002_2002 = _0002_2002 + global::_0005_2000._0002(1402772094) + global::_0003_2000._0002(innerXml) + global::_0005_2000._0002(1402771936);
		}
	}

	public void AddCustomMenuItem(string Caption, string JsFunction, bool Enabled)
	{
		XmlNode xmlNode = null;
		if (_0006_2004 == null)
		{
			_0006_2004 = new XmlDocument();
			xmlNode = _0006_2004.CreateElement(global::_0005_2000._0002(1402778367));
			_0006_2004.AppendChild(xmlNode);
		}
		XmlNode documentElement = _0006_2004.DocumentElement;
		xmlNode = _0006_2004.CreateElement(global::_0005_2000._0002(1402778181));
		XmlAttribute xmlAttribute = _0006_2004.CreateAttribute(global::_0005_2000._0002(1402766857));
		xmlAttribute.InnerText = global::_0003_2000._0006(Caption);
		xmlNode.Attributes.Append(xmlAttribute);
		xmlAttribute = _0006_2004.CreateAttribute(global::_0005_2000._0002(1402781106));
		xmlAttribute.InnerText = JsFunction;
		xmlNode.Attributes.Append(xmlAttribute);
		xmlAttribute = _0006_2004.CreateAttribute(global::_0005_2000._0002(1402781093));
		xmlAttribute.InnerText = (Enabled ? global::_0005_2000._0002(1402770027) : global::_0005_2000._0002(1402770019));
		xmlNode.Attributes.Append(xmlAttribute);
		documentElement.AppendChild(xmlNode);
	}

	public void AddCustomToolButton(string Caption, string JsFunction, int IconIndex)
	{
		XmlNode xmlNode = null;
		if (_000E_2004 == null)
		{
			_000E_2004 = new XmlDocument();
			xmlNode = _000E_2004.CreateElement(global::_0005_2000._0002(1402778325));
			_000E_2004.AppendChild(xmlNode);
		}
		XmlNode documentElement = _000E_2004.DocumentElement;
		xmlNode = _000E_2004.CreateElement(global::_0005_2000._0002(1402781075));
		XmlAttribute xmlAttribute = _000E_2004.CreateAttribute(global::_0005_2000._0002(1402766857));
		xmlAttribute.InnerText = global::_0003_2000._0006(Caption);
		xmlNode.Attributes.Append(xmlAttribute);
		xmlAttribute = _000E_2004.CreateAttribute(global::_0005_2000._0002(1402781106));
		xmlAttribute.InnerText = JsFunction;
		xmlNode.Attributes.Append(xmlAttribute);
		xmlAttribute = _000E_2004.CreateAttribute(global::_0005_2000._0002(1402781058));
		xmlAttribute.InnerText = IconIndex.ToString();
		xmlNode.Attributes.Append(xmlAttribute);
		documentElement.AppendChild(xmlNode);
	}

	public void SetWriter(object WriterObj)
	{
		if (WriterObj.GetType().FullName == global::_0005_2000._0002(1402774931))
		{
			_0002_2002 = ((Workbook)WriterObj)._0002();
			return;
		}
		if (WriterObj.GetType().FullName == global::_0005_2000._0002(1402775033))
		{
			_0002_2002 = ((WordDocument)WriterObj)._0002();
			return;
		}
		throw new Exception(global::_0005_2000._0002(1402774976) + WriterObj.GetType().FullName + global::_0005_2000._0002(1402774827));
	}

	public void SetWriterEx(object WriterObj)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		if (WriterObj.GetType().FullName == global::_0005_2000._0002(1402781170))
		{
			_0002_2002 = ((POCtrlExt)WriterObj).GetData(global::_0005_2000._0002(1402781136) + 20643);
			_0002_2002 = global::_0005_2000._0002(1402781121) + global::_0003_2000._0002(_0002_2002) + global::_0005_2000._0002(1402771936);
			return;
		}
		throw new Exception(global::_0005_2000._0002(1402781040) + WriterObj.GetType().FullName + global::_0005_2000._0002(1402774827));
	}

	public void WebOpen(string DocumentURL, OpenModeType OpenMode, string UserName)
	{
		if (DocumentURL == null || DocumentURL == string.Empty)
		{
			throw new Exception(global::_0005_2000._0002(1402774810));
		}
		if (_0008_2001 == string.Empty)
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
			if (!text.Equals(global::_0005_2000._0002(1402775427)) && !text.Equals(global::_0005_2000._0002(1402775436)) && !text.Equals(global::_0005_2000._0002(1402775544)) && !text.Equals(global::_0005_2000._0002(1402775525)) && !text.Equals(global::_0005_2000._0002(1402775534)) && !text.Equals(global::_0005_2000._0002(1402775515)) && !text.Equals(global::_0005_2000._0002(1402775495)) && !text.Equals(global::_0005_2000._0002(1402775345)) && !text.Equals(global::_0005_2000._0002(1402775354)) && !text.Equals(global::_0005_2000._0002(1402775334)) && !text.Equals(global::_0005_2000._0002(1402781023)) && !text.Equals(global::_0005_2000._0002(1402781000)))
			{
				throw new Exception(global::_0005_2000._0002(1402775315) + DocumentURL + global::_0005_2000._0002(1402775412));
			}
		}
		else
		{
			flag = true;
		}
		if (DocumentURL.ToLower().EndsWith(global::_0005_2000._0002(1402775427)) || DocumentURL.ToLower().EndsWith(global::_0005_2000._0002(1402775436)) || DocumentURL.ToLower().EndsWith(global::_0005_2000._0002(1402775544)) || DocumentURL.ToLower().EndsWith(global::_0005_2000._0002(1402775525)))
		{
			if (OpenMode != OpenModeType.docAdmin && OpenMode != 0 && OpenMode != OpenModeType.docNormalEdit && OpenMode != OpenModeType.docReadOnly && OpenMode != OpenModeType.docSubmitForm && OpenMode != OpenModeType.docHandwritingOnly)
			{
				throw new Exception(global::_0005_2000._0002(1402775383) + DocumentURL + global::_0005_2000._0002(1402775228));
			}
		}
		else if (DocumentURL.ToLower().EndsWith(global::_0005_2000._0002(1402775534)) || DocumentURL.ToLower().EndsWith(global::_0005_2000._0002(1402775515)) || DocumentURL.ToLower().EndsWith(global::_0005_2000._0002(1402775495)))
		{
			if (OpenMode != OpenModeType.xlsNormalEdit && OpenMode != OpenModeType.xlsReadOnly && OpenMode != OpenModeType.xlsSubmitForm)
			{
				throw new Exception(global::_0005_2000._0002(1402775383) + DocumentURL + global::_0005_2000._0002(1402775228));
			}
		}
		else if (DocumentURL.ToLower().EndsWith(global::_0005_2000._0002(1402775345)) || DocumentURL.ToLower().EndsWith(global::_0005_2000._0002(1402775354)))
		{
			if (OpenMode != OpenModeType.pptNormalEdit && OpenMode != OpenModeType.pptReadOnly)
			{
				throw new Exception(global::_0005_2000._0002(1402775383) + DocumentURL + global::_0005_2000._0002(1402775228));
			}
		}
		else if (DocumentURL.ToLower().EndsWith(global::_0005_2000._0002(1402781023)))
		{
			if (OpenMode != OpenModeType.vsdNormalEdit)
			{
				throw new Exception(global::_0005_2000._0002(1402775383) + DocumentURL + global::_0005_2000._0002(1402775228));
			}
		}
		else if (DocumentURL.ToLower().EndsWith(global::_0005_2000._0002(1402781000)) && OpenMode != OpenModeType.mppNormalEdit)
		{
			throw new Exception(global::_0005_2000._0002(1402775383) + DocumentURL + global::_0005_2000._0002(1402775228));
		}
		if (!_000F_2001)
		{
			XmlNode documentElement = _0002_2005.DocumentElement;
			XmlNode xmlNode = _0002_2005.CreateElement(global::_0005_2000._0002(1402775183));
			XmlAttribute xmlAttribute = _0002_2005.CreateAttribute(global::_0005_2000._0002(1402775293));
			if (flag)
			{
				xmlAttribute.InnerText = DocumentURL;
			}
			else
			{
				string text2 = DocumentURL.Substring(DocumentURL.LastIndexOf(global::_0005_2000._0002(1402775274)) + 1);
				string text3 = global::_0003_2000._0002(global::_0005_2000._0002(1402775250) + DocumentURL + global::_0005_2000._0002(1402775262) + text2);
				text3 = text3.Replace(global::_0005_2000._0002(1402775060), global::_0005_2000._0002(1402775068)).Replace(global::_0005_2000._0002(1402775047), global::_0005_2000._0002(1402775055)).Replace(global::_0005_2000._0002(1402769483), global::_0005_2000._0002(1402775158));
				xmlAttribute.InnerText = _0008_2001 + global::_0005_2000._0002(1402775137) + text3;
			}
			xmlNode.Attributes.Append(xmlAttribute);
			xmlAttribute = _0002_2005.CreateAttribute(global::_0005_2000._0002(1402775133));
			xmlAttribute.InnerText = OpenMode.ToString();
			xmlNode.Attributes.Append(xmlAttribute);
			xmlAttribute = _0002_2005.CreateAttribute(global::_0005_2000._0002(1402775114));
			xmlAttribute.InnerText = global::_0003_2000._0006(UserName);
			xmlNode.Attributes.Append(xmlAttribute);
			documentElement.AppendChild(xmlNode);
			_000F_2001 = true;
		}
	}

	public void WebCreateNew(string UserName, DocumentVersion DocVersion)
	{
		if (_0008_2001 == string.Empty)
		{
			throw new Exception(ID + global::_0005_2000._0002(1402774698) + ID + global::_0005_2000._0002(1402774761));
		}
		if (!_000F_2001)
		{
			XmlNode documentElement = _0002_2005.DocumentElement;
			XmlNode xmlNode = _0002_2005.CreateElement(global::_0005_2000._0002(1402775183));
			string text = global::_0005_2000._0002(1402773917);
			OpenModeType openModeType = OpenModeType.docNormalEdit;
			string text2 = global::_0005_2000._0002(1402773903);
			string text3 = global::_0005_2000._0002(1402773985);
			switch (DocVersion)
			{
			case DocumentVersion.Word2003:
				openModeType = OpenModeType.docNormalEdit;
				text = global::_0005_2000._0002(1402773917);
				text2 = global::_0005_2000._0002(1402773903);
				text3 = global::_0005_2000._0002(1402773985);
				break;
			case DocumentVersion.Excel2003:
				openModeType = OpenModeType.xlsNormalEdit;
				text = global::_0005_2000._0002(1402773976);
				text2 = global::_0005_2000._0002(1402773962);
				text3 = global::_0005_2000._0002(1402773823);
				break;
			case DocumentVersion.PowerPoint2003:
				openModeType = OpenModeType.pptNormalEdit;
				text = global::_0005_2000._0002(1402773785);
				text2 = global::_0005_2000._0002(1402773771);
				text3 = global::_0005_2000._0002(1402773882);
				break;
			case DocumentVersion.Word2007:
				openModeType = OpenModeType.docNormalEdit;
				text = global::_0005_2000._0002(1402773850);
				text2 = global::_0005_2000._0002(1402773839);
				text3 = global::_0005_2000._0002(1402773985);
				break;
			case DocumentVersion.Excel2007:
				openModeType = OpenModeType.xlsNormalEdit;
				text = global::_0005_2000._0002(1402773664);
				text2 = global::_0005_2000._0002(1402773653);
				text3 = global::_0005_2000._0002(1402773823);
				break;
			case DocumentVersion.PowerPoint2007:
				openModeType = OpenModeType.pptNormalEdit;
				text = global::_0005_2000._0002(1402773641);
				text2 = global::_0005_2000._0002(1402780853);
				text3 = global::_0005_2000._0002(1402773882);
				break;
			}
			if (!File.Exists(_0005_2003 + global::_0005_2000._0002(1402773754) + text))
			{
				throw new Exception(global::_0005_2000._0002(1402771480) + _0005_2003 + global::_0005_2000._0002(1402773754) + text + global::_0005_2000._0002(1402775470));
			}
			XmlAttribute xmlAttribute = _0002_2005.CreateAttribute(global::_0005_2000._0002(1402775293));
			string text4 = global::_0003_2000._0002(global::_0005_2000._0002(1402775250) + text + global::_0005_2000._0002(1402773741) + text3 + global::_0005_2000._0002(1402773697) + text2);
			text4 = text4.Replace(global::_0005_2000._0002(1402775060), global::_0005_2000._0002(1402775068)).Replace(global::_0005_2000._0002(1402775047), global::_0005_2000._0002(1402775055)).Replace(global::_0005_2000._0002(1402769483), global::_0005_2000._0002(1402775158));
			xmlAttribute.InnerText = _0008_2001 + global::_0005_2000._0002(1402773552) + text4;
			xmlNode.Attributes.Append(xmlAttribute);
			xmlAttribute = _0002_2005.CreateAttribute(global::_0005_2000._0002(1402775133));
			xmlAttribute.InnerText = openModeType.ToString();
			xmlNode.Attributes.Append(xmlAttribute);
			xmlAttribute = _0002_2005.CreateAttribute(global::_0005_2000._0002(1402775114));
			xmlAttribute.InnerText = global::_0003_2000._0006(UserName);
			xmlNode.Attributes.Append(xmlAttribute);
			documentElement.AppendChild(xmlNode);
			_000F_2001 = true;
		}
	}

	public void WordCompare(string DocumentURL, string DocumentURL2, OpenModeType OpenMode, string UserName)
	{
		if (DocumentURL == null || DocumentURL == string.Empty)
		{
			throw new Exception(global::_0005_2000._0002(1402774810));
		}
		if (DocumentURL2 == null || DocumentURL2 == string.Empty)
		{
			throw new Exception(global::_0005_2000._0002(1402780839));
		}
		if (OpenMode != OpenModeType.docAdmin && OpenMode != OpenModeType.docReadOnly)
		{
			throw new Exception(global::_0005_2000._0002(1402780926));
		}
		if (_0008_2001 == string.Empty)
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
			if (!text.Equals(global::_0005_2000._0002(1402775427)) && !text.Equals(global::_0005_2000._0002(1402775436)))
			{
				throw new Exception(global::_0005_2000._0002(1402775315) + DocumentURL + global::_0005_2000._0002(1402780769));
			}
		}
		else
		{
			flag = true;
		}
		num = DocumentURL2.IndexOf(global::_0005_2000._0002(1402774604));
		bool flag2 = true;
		if (num > -1)
		{
			flag2 = false;
			if (!File.Exists(DocumentURL2))
			{
				throw new Exception(global::_0005_2000._0002(1402775479) + DocumentURL2 + global::_0005_2000._0002(1402775470));
			}
			string text2 = global::_0003_2000._000F(DocumentURL2);
			text2 = text2.ToLower();
			if (!text2.Equals(global::_0005_2000._0002(1402775427)) && !text2.Equals(global::_0005_2000._0002(1402775436)))
			{
				throw new Exception(global::_0005_2000._0002(1402775315) + DocumentURL2 + global::_0005_2000._0002(1402780769));
			}
		}
		else
		{
			flag2 = true;
		}
		if (!_000F_2001)
		{
			XmlNode documentElement = _0002_2005.DocumentElement;
			XmlNode xmlNode = _0002_2005.CreateElement(global::_0005_2000._0002(1402780744));
			XmlAttribute xmlAttribute = _0002_2005.CreateAttribute(global::_0005_2000._0002(1402775293));
			if (flag)
			{
				xmlAttribute.InnerText = DocumentURL;
			}
			else
			{
				string text3 = DocumentURL.Substring(DocumentURL.LastIndexOf(global::_0005_2000._0002(1402775274)) + 1);
				string text4 = global::_0003_2000._0002(global::_0005_2000._0002(1402775250) + DocumentURL + global::_0005_2000._0002(1402775262) + text3);
				text4 = text4.Replace(global::_0005_2000._0002(1402775060), global::_0005_2000._0002(1402775068)).Replace(global::_0005_2000._0002(1402775047), global::_0005_2000._0002(1402775055)).Replace(global::_0005_2000._0002(1402769483), global::_0005_2000._0002(1402775158));
				xmlAttribute.InnerText = _0008_2001 + global::_0005_2000._0002(1402775137) + text4;
			}
			xmlNode.Attributes.Append(xmlAttribute);
			xmlAttribute = _0002_2005.CreateAttribute(global::_0005_2000._0002(1402781626));
			if (flag2)
			{
				xmlAttribute.InnerText = DocumentURL2;
			}
			else
			{
				string text5 = DocumentURL2.Substring(DocumentURL2.LastIndexOf(global::_0005_2000._0002(1402775274)) + 1);
				string text6 = global::_0003_2000._0002(global::_0005_2000._0002(1402775250) + DocumentURL2 + global::_0005_2000._0002(1402775262) + text5);
				text6 = text6.Replace(global::_0005_2000._0002(1402775060), global::_0005_2000._0002(1402775068)).Replace(global::_0005_2000._0002(1402775047), global::_0005_2000._0002(1402775055)).Replace(global::_0005_2000._0002(1402769483), global::_0005_2000._0002(1402775158));
				xmlAttribute.InnerText = _0008_2001 + global::_0005_2000._0002(1402775137) + text6;
			}
			xmlNode.Attributes.Append(xmlAttribute);
			xmlAttribute = _0002_2005.CreateAttribute(global::_0005_2000._0002(1402775133));
			xmlAttribute.InnerText = OpenMode.ToString();
			xmlNode.Attributes.Append(xmlAttribute);
			xmlAttribute = _0002_2005.CreateAttribute(global::_0005_2000._0002(1402775114));
			xmlAttribute.InnerText = global::_0003_2000._0006(UserName);
			xmlNode.Attributes.Append(xmlAttribute);
			documentElement.AppendChild(xmlNode);
			_000F_2001 = true;
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
		if (_0002_2006 != null)
		{
			_0002_2006(this, e);
		}
		if (_0008_2001 == string.Empty)
		{
			throw new Exception(ID + global::_0005_2000._0002(1402774698) + ID + global::_0005_2000._0002(1402774761));
		}
		if (HttpContext.Current.Request.Url.ToString().EndsWith(global::_0005_2000._0002(1402775047)))
		{
			throw new Exception(global::_0005_2000._0002(1402781610));
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
		_0002(_0002_2005);
		empty = empty + _0002_2002 + global::_0005_2000._0002(1402774304);
		string empty2 = string.Empty;
		empty2 = ((!_0008_2005) ? global::_0005_2000._0002(1402781462) : global::_0005_2000._0002(1402781495));
		if (HttpContext.Current.Request.UserAgent.IndexOf(global::_0005_2000._0002(1402774178)) > 0 || HttpContext.Current.Request.UserAgent.IndexOf(global::_0005_2000._0002(1402774191)) > 0)
		{
			empty = empty + global::_0005_2000._0002(1402774173) + ctrlId + global::_0005_2000._0002(1402769945) + empty2 + global::_0005_2000._0002(1402781555) + text + global::_0005_2000._0002(1402769848);
			empty = empty + global::_0005_2000._0002(1402774054) + _0003_2003 + global::_0005_2000._0002(1402776971);
			empty = empty + global::_0005_2000._0002(1402776577) + global::_0003_2000._0002 + global::_0005_2000._0002(1402776699) + _0008_2003 + global::_0005_2000._0002(1402769736);
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
				empty = empty + global::_0005_2000._0002(1402774173) + ctrlId + global::_0005_2000._0002(1402781350) + empty2 + global::_0005_2000._0002(1402781383);
				empty = empty + global::_0005_2000._0002(1402774054) + _0003_2003 + global::_0005_2000._0002(1402775896);
				empty = empty + global::_0005_2000._0002(1402776577) + global::_0003_2000._0002 + global::_0005_2000._0002(1402776699) + _0008_2003 + global::_0005_2000._0002(1402769736);
				empty += global::_0005_2000._0002(1402781518);
			}
		}
		return empty;
	}
}
