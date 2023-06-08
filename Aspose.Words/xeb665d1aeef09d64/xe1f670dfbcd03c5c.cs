using System;
using System.Collections;
using System.Drawing;
using Aspose;
using x66dd9eaee57cfba4;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace xeb665d1aeef09d64;

internal class xe1f670dfbcd03c5c
{
	private readonly object x8f5ba7dd7ce36e75 = new object();

	private readonly xd345c73dd1b16b74 xc7ce48807daf7866;

	private readonly IDictionary x0b47be63656ec559 = xd51c34d05311eee3.xdb04a310bbb29cff();

	private static readonly IDictionary x828a121ebaa5ee8a;

	internal xe1f670dfbcd03c5c(x25998da3963930e9[] availableFontsData)
	{
		xc7ce48807daf7866 = x4c94e46bee37bf2d(availableFontsData);
	}

	internal xe1f670dfbcd03c5c(x8989ff189b375934[] availableFontEntries)
	{
		xc7ce48807daf7866 = new xd345c73dd1b16b74(isCaseSensitive: false);
		foreach (x8989ff189b375934 x8989ff189b375935 in availableFontEntries)
		{
			xc7ce48807daf7866[x8989ff189b375935.x0155217fb8bbda6a] = x8989ff189b375935;
		}
	}

	[JavaThrows(false)]
	private static xd345c73dd1b16b74 x4c94e46bee37bf2d(x25998da3963930e9[] xffe132185f45c5fd)
	{
		xd345c73dd1b16b74 xd345c73dd1b16b = new xd345c73dd1b16b74(isCaseSensitive: false);
		x6412d0c71c34c05c x6412d0c71c34c05c = new x6412d0c71c34c05c();
		foreach (x25998da3963930e9 x0db5e88527e18b in xffe132185f45c5fd)
		{
			try
			{
				x8989ff189b375934[] array = x6412d0c71c34c05c.x0c269939c278bc2d(x0db5e88527e18b);
				if (array == null)
				{
					continue;
				}
				x8989ff189b375934[] array2 = array;
				foreach (x8989ff189b375934 x8989ff189b375935 in array2)
				{
					x8989ff189b375934 x8989ff189b375936 = (x8989ff189b375934)xd345c73dd1b16b[x8989ff189b375935.x0155217fb8bbda6a];
					if (x8989ff189b375936 == null || x8989ff189b375935.xbdb46eca7415042d)
					{
						xd345c73dd1b16b[x8989ff189b375935.x0155217fb8bbda6a] = x8989ff189b375935;
					}
				}
			}
			catch (Exception)
			{
			}
		}
		return xd345c73dd1b16b;
	}

	public x6b1a899052c71a60 xdc2247c8d4648ae8(string xa79a9f649c74f4a4, FontStyle x44ecfea61c937b8e)
	{
		x6b1a899052c71a60 x6b1a899052c71a = x19f412ec97ef7f49(xa79a9f649c74f4a4, x44ecfea61c937b8e);
		if (x6b1a899052c71a != null)
		{
			return x6b1a899052c71a;
		}
		if (x828a121ebaa5ee8a.Contains(xa79a9f649c74f4a4))
		{
			x6b1a899052c71a = x19f412ec97ef7f49((string)x828a121ebaa5ee8a[xa79a9f649c74f4a4], x44ecfea61c937b8e);
		}
		if (x6b1a899052c71a != null)
		{
			return x6b1a899052c71a;
		}
		string text = null;
		switch (xa79a9f649c74f4a4)
		{
		case "Khmer":
			text = "Khmer UI";
			break;
		case "Lao":
			text = "Lao UI";
			break;
		case "Meiryo":
			text = "Meiryo UI";
			break;
		case "Segoe":
			text = "Segoe UI";
			break;
		default:
		{
			int num = xa79a9f649c74f4a4.LastIndexOf(' ');
			if (num >= 0)
			{
				text = xa79a9f649c74f4a4.Substring(0, num);
			}
			break;
		}
		}
		if (x0d299f323d241756.x5959bccb67bbf051(text))
		{
			x6b1a899052c71a = x19f412ec97ef7f49(text, x44ecfea61c937b8e);
		}
		return x6b1a899052c71a;
	}

	public x6b1a899052c71a60 xd3f8e541b341f67a()
	{
		foreach (x8989ff189b375934 value in xc7ce48807daf7866.GetValueList())
		{
			x6b1a899052c71a60 x6b1a899052c71a = x19f412ec97ef7f49(value.x6054c4379c01a50d, FontStyle.Regular);
			if (x6b1a899052c71a != null)
			{
				return x6b1a899052c71a;
			}
		}
		return null;
	}

	[JavaThrows(false)]
	private x6b1a899052c71a60 x19f412ec97ef7f49(string xa79a9f649c74f4a4, FontStyle x44ecfea61c937b8e)
	{
		x377d898eb7908753 x377d898eb = (x377d898eb7908753)x0b47be63656ec559[xa79a9f649c74f4a4];
		if (x377d898eb == null)
		{
			lock (x8f5ba7dd7ce36e75)
			{
				x377d898eb = (x377d898eb7908753)x0b47be63656ec559[xa79a9f649c74f4a4];
				if (x377d898eb == null)
				{
					try
					{
						x377d898eb = x7c720c8bae578197(xa79a9f649c74f4a4);
						x0b47be63656ec559[xa79a9f649c74f4a4] = x377d898eb;
					}
					catch (Exception)
					{
						return null;
					}
				}
			}
		}
		return x377d898eb.xdc2247c8d4648ae8(x44ecfea61c937b8e, xa456a0d7ead141be: false);
	}

	private x377d898eb7908753 x7c720c8bae578197(string xa79a9f649c74f4a4)
	{
		x377d898eb7908753 x377d898eb = new x377d898eb7908753(xa79a9f649c74f4a4);
		foreach (x8989ff189b375934 value in xc7ce48807daf7866.GetValueList())
		{
			if (x27cd5f9641d9eb15.x90637a473b1ceaaa(xa79a9f649c74f4a4, value.x6054c4379c01a50d))
			{
				x6412d0c71c34c05c x6412d0c71c34c05c = new x6412d0c71c34c05c();
				x6b1a899052c71a60 x26094932cf7a = x6412d0c71c34c05c.x06b0e25aa6ad68a9(value.x6b73aa01aa019d3a, value.x0155217fb8bbda6a);
				x377d898eb.xd6b6ed77479ef68c(x26094932cf7a);
			}
		}
		return x377d898eb;
	}

	static xe1f670dfbcd03c5c()
	{
		x828a121ebaa5ee8a = xd51c34d05311eee3.xdb04a310bbb29cff();
		x828a121ebaa5ee8a.Add("Arabic Transparent", "Arial");
		x828a121ebaa5ee8a.Add("Arial Baltic", "Arial");
		x828a121ebaa5ee8a.Add("Arial CE", "Arial");
		x828a121ebaa5ee8a.Add("Arial Cyr", "Arial");
		x828a121ebaa5ee8a.Add("Arial Greek", "Arial");
		x828a121ebaa5ee8a.Add("Arial TUR", "Arial");
		x828a121ebaa5ee8a.Add("Courier New Baltic", "Courier New");
		x828a121ebaa5ee8a.Add("Courier New CE", "Courier New");
		x828a121ebaa5ee8a.Add("Courier New Cyr", "Courier New");
		x828a121ebaa5ee8a.Add("Courier New Greek", "Courier New");
		x828a121ebaa5ee8a.Add("Courier New TUR", "Courier New");
		x828a121ebaa5ee8a.Add("Courier", "Courier New");
		x828a121ebaa5ee8a.Add("David Transparent", "David");
		x828a121ebaa5ee8a.Add("FangSong_GB2312", "FangSong");
		x828a121ebaa5ee8a.Add("Fixed Miriam Transparent", "Miriam Fixed");
		x828a121ebaa5ee8a.Add("Helvetica", "Arial");
		x828a121ebaa5ee8a.Add("KaiTi_GB2312", "KaiTi");
		x828a121ebaa5ee8a.Add("Miriam Transparent", "Miriam");
		x828a121ebaa5ee8a.Add("MS Shell Dlg", "Microsoft Sans Serif");
		x828a121ebaa5ee8a.Add("MS Shell Dlg 2", "Tahoma");
		x828a121ebaa5ee8a.Add("Rod Transparent", "Rod");
		x828a121ebaa5ee8a.Add("Tahoma Armenian", "Tahoma");
		x828a121ebaa5ee8a.Add("Times", "Times New Roman");
		x828a121ebaa5ee8a.Add("Times New Roman Baltic", "Times New Roman");
		x828a121ebaa5ee8a.Add("Times New Roman CE", "Times New Roman");
		x828a121ebaa5ee8a.Add("Times New Roman Cyr", "Times New Roman");
		x828a121ebaa5ee8a.Add("Times New Roman Greek", "Times New Roman");
		x828a121ebaa5ee8a.Add("Times New Roman TUR", "Times New Roman");
	}
}
