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

[Designer(typeof(HtmlSignCtrlDesigner))]
[ToolboxBitmap(typeof(HtmlSignCtrl), "HtmlSignCtrl.ico")]
[DefaultProperty("Caption")]
[ToolboxData("<{0}:HtmlSignCtrl runat=server></{0}:HtmlSignCtrl>")]
[DefaultEvent("Load")]
public sealed class HtmlSignCtrl : Control
{
	private string m__0002;

	private bool _0003;

	private string _0005;

	private string _0008;

	private string _0006;

	private string _000E;

	private string _000F;

	private XmlDocument _0002_2000;

	private string _0003_2000;

	private string _0005_2000;

	private string _0008_2000;

	private EventHandler _0006_2000;

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

	[Browsable(false)]
	public string ServerPage
	{
		get
		{
			return this.m__0002;
		}
		set
		{
			this.m__0002 = value;
			if (!(this.m__0002 != string.Empty))
			{
				return;
			}
			string text = this.m__0002.ToLower();
			if (text.StartsWith(global::_0005_2000._0002(1402771699)) || text.StartsWith(global::_0005_2000._0002(1402771681)))
			{
				if (text.StartsWith(global::_0005_2000._0002(1402771699)))
				{
					text = this.m__0002.Substring(7);
				}
				else if (text.StartsWith(global::_0005_2000._0002(1402771681)))
				{
					text = this.m__0002.Substring(8);
				}
				if (text.IndexOf('/') > -1)
				{
					text = text.Substring(text.IndexOf('/'));
				}
			}
			if (text == string.Empty)
			{
				throw new Exception(ID + global::_0005_2000._0002(1402771694) + this.m__0002 + global::_0005_2000._0002(1402771652));
			}
			HttpServerUtility server = HttpContext.Current.Server;
			try
			{
				_0006 = text;
				text = server.MapPath(text);
			}
			catch
			{
				throw new Exception(ID + global::_0005_2000._0002(1402771694) + this.m__0002 + global::_0005_2000._0002(1402771652));
			}
			File.Exists(text);
			_0008 = text;
			_000F = _0008.Substring(0, _0008.LastIndexOf('\\'));
			HttpRequest request = HttpContext.Current.Request;
			_0008 = _0008.Substring(0, _0008.LastIndexOf('\\')) + global::_0005_2000._0002(1402771495);
			if (!File.Exists(_0008))
			{
				throw new Exception(global::_0005_2000._0002(1402771480) + _0008 + global::_0005_2000._0002(1402771465));
			}
			_0005_2000 = _0002(_0008);
			_0006 = _0006.Substring(0, _0006.LastIndexOf('/')) + global::_0005_2000._0002(1402772373);
			if (_0006[0] == '/')
			{
				string text2 = request.ApplicationPath;
				if (text2[0] == '/')
				{
					text2 = string.Empty;
				}
				_0006 = request.Url.AbsoluteUri.Substring(0, request.Url.AbsoluteUri.IndexOf('/', 8)) + text2 + _0006;
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
				_0006 = text3.Substring(0, num2 + 1) + _0006;
			}
			if (request.Url.Authority != request.ServerVariables[global::_0005_2000._0002(1402772358)])
			{
				_0006 = _0006.Replace(request.Url.Authority, request.ServerVariables[global::_0005_2000._0002(1402772358)]);
			}
			_000E = _0006.Substring(0, _0006.LastIndexOf('/') + 1) + global::_0005_2000._0002(1402772470);
			_0006 = _0006 + global::_0005_2000._0002(1402772456) + _0002(_0008);
		}
	}

	[Browsable(false)]
	public string ZoomSealServer
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

	[Category("Document")]
	[Description("在此事件里为 HtmlSignCtrl 控件编写初始化及加载当前网页手写签章的代码。")]
	public new event EventHandler Load
	{
		add
		{
			EventHandler eventHandler = _0006_2000;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref _0006_2000, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		remove
		{
			EventHandler eventHandler = _0006_2000;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref _0006_2000, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public HtmlSignCtrl()
	{
		_0003 = false;
		_0005 = string.Empty;
		_0006 = string.Empty;
		_000E = string.Empty;
		_0008 = string.Empty;
		_000F = string.Empty;
		_0003_2000 = string.Empty;
		_0005_2000 = string.Empty;
		_0002_2000 = new XmlDocument();
		StringBuilder stringBuilder = new StringBuilder(global::_0005_2000._0002(1402773238));
		stringBuilder.Append(global::_0005_2000._0002(1402779097));
		stringBuilder.Append(global::_0005_2000._0002(1402779084));
		_0002_2000.LoadXml(stringBuilder.ToString());
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public override void DataBind()
	{
		base.DataBind();
	}

	private void _0002(XmlDocument _0002)
	{
		_ = HttpContext.Current.Request;
		XmlNode documentElement = _0002.DocumentElement;
		if (this.m__0002 != string.Empty)
		{
			XmlNode xmlNode = _0002.CreateElement(global::_0005_2000._0002(1402772424));
			xmlNode.InnerText = this.m__0002;
			documentElement.AppendChild(xmlNode);
		}
		if (_0003_2000 != string.Empty)
		{
			XmlNode xmlNode2 = _0002.CreateElement(global::_0005_2000._0002(1402771995));
			xmlNode2.InnerText = _0003_2000;
			documentElement.AppendChild(xmlNode2);
		}
		if (_0005_2000 != string.Empty)
		{
			XmlNode xmlNode3 = _0002.CreateElement(global::_0005_2000._0002(1402772007));
			xmlNode3.InnerText = _0005_2000;
			documentElement.AppendChild(xmlNode3);
		}
		string innerXml = _0002.InnerXml;
		if (innerXml != string.Empty)
		{
			_0005 = _0005 + global::_0005_2000._0002(1402778914) + global::_0003_2000._0002(innerXml) + global::_0005_2000._0002(1402778967);
			_0005 = _0005 + global::_0005_2000._0002(1402778946) + _0008_2000 + global::_0005_2000._0002(1402771936);
		}
	}

	public void LoadToPage(string ZSSignature, HtmlSignMode SignMode, string UserName)
	{
		if (ZSSignature == null)
		{
			ZSSignature = string.Empty;
		}
		if (UserName == null || UserName == string.Empty)
		{
			throw new Exception(global::_0005_2000._0002(1402778763));
		}
		if (this.m__0002 == string.Empty)
		{
			throw new Exception(ID + global::_0005_2000._0002(1402774698) + ID + global::_0005_2000._0002(1402774761));
		}
		if (!_0003)
		{
			XmlNode documentElement = _0002_2000.DocumentElement;
			XmlNode xmlNode = _0002_2000.CreateElement(global::_0005_2000._0002(1402778842));
			_0008_2000 = ZSSignature;
			XmlAttribute xmlAttribute = _0002_2000.CreateAttribute(global::_0005_2000._0002(1402778829));
			switch (SignMode)
			{
			case HtmlSignMode.Signer:
				xmlAttribute.InnerText = global::_0005_2000._0002(1402770019);
				break;
			case HtmlSignMode.Admin:
				xmlAttribute.InnerText = global::_0005_2000._0002(1402770027);
				break;
			}
			xmlNode.Attributes.Append(xmlAttribute);
			xmlAttribute = _0002_2000.CreateAttribute(global::_0005_2000._0002(1402775114));
			xmlAttribute.InnerText = global::_0003_2000._0002(UserName);
			xmlNode.Attributes.Append(xmlAttribute);
			documentElement.AppendChild(xmlNode);
			_0003 = true;
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
		if (_0006_2000 != null)
		{
			_0006_2000(this, e);
		}
		if (this.m__0002 == string.Empty)
		{
			throw new Exception(ID + global::_0005_2000._0002(1402774698) + ID + global::_0005_2000._0002(1402774761));
		}
		if (HttpContext.Current.Request.Url.ToString().EndsWith(global::_0005_2000._0002(1402775047)))
		{
			throw new Exception(global::_0005_2000._0002(1402778682));
		}
	}

	protected override void Render(HtmlTextWriter output)
	{
		output.Write(GetHtmlCode(ID));
	}

	public string GetHtmlCode(string ctrlId)
	{
		string empty = string.Empty;
		_0002(_0002_2000);
		empty = empty + _0005 + global::_0005_2000._0002(1402774304);
		if (HttpContext.Current.Request.UserAgent.IndexOf(global::_0005_2000._0002(1402774178)) > 0 || HttpContext.Current.Request.UserAgent.IndexOf(global::_0005_2000._0002(1402774191)) > 0)
		{
			empty = empty + global::_0005_2000._0002(1402774173) + ctrlId + global::_0005_2000._0002(1402778691);
			empty = empty + global::_0005_2000._0002(1402776577) + global::_0003_2000._0002 + global::_0005_2000._0002(1402776699) + _0005_2000 + global::_0005_2000._0002(1402769736);
			empty += global::_0005_2000._0002(1402776687);
			empty = empty + global::_0005_2000._0002(1402779643) + ctrlId + global::_0005_2000._0002(1402779392) + _000E + global::_0005_2000._0002(1402779349) + ctrlId + global::_0005_2000._0002(1402779197);
			if (HttpContext.Current.Request.UserAgent.IndexOf(global::_0005_2000._0002(1402774178)) > 0 && HttpContext.Current.Request.UserAgent.IndexOf(global::_0005_2000._0002(1402779167)) < 0)
			{
				return empty + global::_0005_2000._0002(1402779150);
			}
			return empty + global::_0005_2000._0002(1402778096);
		}
		return empty + global::_0005_2000._0002(1402777980);
	}
}
