using Aspose.Words.Fonts;
using x6c95d9cf46ff5f25;
using xbe73d5820f7f4ae3;

namespace xfce5b6a304778b89;

internal class x64964b51e54adaea
{
	private x64964b51e54adaea()
	{
	}

	internal static void x06b0e25aa6ad68a9(xf871da68decec406 xe134235b3526fa75)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		while (xca994afbcb9073a.x152cbadbfa8061b1("font-face-decls"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = xca994afbcb9073a.xa66385d80d4d296f) != null && xa66385d80d4d296f == "font-face")
			{
				x92ace3b29b6935e1(xe134235b3526fa75);
			}
			else
			{
				xca994afbcb9073a.IgnoreElement();
			}
		}
	}

	private static void x92ace3b29b6935e1(xf871da68decec406 xe134235b3526fa75)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		string text = null;
		string text2 = null;
		string xbcea506a33cf = null;
		string xbcea506a33cf2 = null;
		string text3 = null;
		while (xca994afbcb9073a.x1ac1960adc8c4c39())
		{
			switch (xca994afbcb9073a.xa66385d80d4d296f)
			{
			case "font-family":
			{
				string[] array = xca994afbcb9073a.xd2f68ee6f47e9dfb.Replace("'", "").Split(',');
				if (array.Length > 0)
				{
					text = array[0].Trim(' ');
				}
				break;
			}
			case "name":
				text2 = xca994afbcb9073a.xd2f68ee6f47e9dfb;
				break;
			case "font-family-generic":
				xbcea506a33cf = xca994afbcb9073a.xd2f68ee6f47e9dfb;
				break;
			case "font-pitch":
				xbcea506a33cf2 = xca994afbcb9073a.xd2f68ee6f47e9dfb;
				break;
			case "font-charset":
				text3 = xca994afbcb9073a.xd2f68ee6f47e9dfb;
				break;
			}
		}
		if (text2 != null)
		{
			if (!xe134235b3526fa75.xa2bae26554bf2a93.ContainsKey(text2))
			{
				xe134235b3526fa75.xa2bae26554bf2a93.Add(text2, text);
			}
			if (!x0d299f323d241756.x5959bccb67bbf051(text))
			{
				text = text2;
			}
			FontInfo fontInfo = new FontInfo(text);
			if (x0d299f323d241756.x5959bccb67bbf051(xbcea506a33cf))
			{
				fontInfo.Family = x0eb9a864413f34de.x8207f0bf3d84695a(xbcea506a33cf);
			}
			if (x0d299f323d241756.x5959bccb67bbf051(xbcea506a33cf2))
			{
				fontInfo.Pitch = x0eb9a864413f34de.x5c6ebf2ef685c760(xbcea506a33cf2);
			}
			if (text3 == "x-symbol")
			{
				fontInfo.Charset = 2;
			}
			xe134235b3526fa75.x2c8c6741422a1298.FontInfos.xd5da23b762ce52a2(fontInfo);
		}
	}
}
