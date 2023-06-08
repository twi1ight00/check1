using System.Xml;

namespace PageOffice.Ribbon;

public class Toolbar
{
	private string m__0002;

	private XmlDocument _0003;

	internal Toolbar()
	{
		this.m__0002 = _0005_2000._0002(1402785961);
		_0003 = new XmlDocument();
		_0003.LoadXml(this.m__0002);
	}

	internal string _0002()
	{
		string text = _0005_2000._0002(1402786612) + _0003.InnerXml + _0005_2000._0002(1402786652);
		return _0003_2000._0006(text);
	}

	public void SetSharedVisible(string ControlName, bool Visible)
	{
		XmlNode xmlNode = _0003.SelectSingleNode(_0005_2000._0002(1402786638));
		foreach (XmlNode childNode in xmlNode.ChildNodes)
		{
			if (childNode.Attributes[_0005_2000._0002(1402786471)].InnerText == ControlName)
			{
				childNode.Attributes[_0005_2000._0002(1402786451)].InnerText = Visible.ToString().ToLower();
				break;
			}
		}
	}

	public void SetTabVisible(string TabName, bool Visible)
	{
		XmlNode xmlNode = _0003.SelectSingleNode(_0005_2000._0002(1402786433));
		foreach (XmlNode childNode in xmlNode.ChildNodes)
		{
			if (childNode.Attributes[_0005_2000._0002(1402786471)].InnerText == TabName)
			{
				childNode.Attributes[_0005_2000._0002(1402786451)].InnerText = Visible.ToString().ToLower();
				break;
			}
		}
	}

	public void SetGroupVisible(string GroupName, bool Visible)
	{
		XmlNodeList xmlNodeList = _0003.SelectNodes(_0005_2000._0002(1402786444));
		foreach (XmlNode item in xmlNodeList)
		{
			if (item.Attributes[_0005_2000._0002(1402786471)].InnerText == GroupName)
			{
				item.Attributes[_0005_2000._0002(1402786451)].InnerText = Visible.ToString().ToLower();
				break;
			}
		}
	}
}
