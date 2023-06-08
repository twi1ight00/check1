using System.Collections;
using System.Text;
using System.Text.RegularExpressions;
using Aspose.Words;
using Aspose.Words.Settings;
using x6c95d9cf46ff5f25;
using xe86f37adaccef1c3;

namespace xfbd1009a0cbb9842;

internal class xde99a4913041ec62 : x190443e12b0b496b
{
	private const int xd3d99a7fa9fa8b12 = 1;

	private const int x1fc7c508ff252a73 = 2;

	private const int xbabe847d99783ecd = 3;

	private readonly x64b01a877c5fd558 x54c413cc80cb99d5;

	private readonly xa11a4c48b53f49a6 xb94636afa262d297;

	private static readonly Regex xd3dad1c6d3ab446c = new Regex("<<([^_]*)_(\\w+)_([^_]*)>>", RegexOptions.IgnoreCase | RegexOptions.Compiled);

	internal xde99a4913041ec62(x64b01a877c5fd558 field, xa11a4c48b53f49a6 dataSource)
	{
		x54c413cc80cb99d5 = field;
		xb94636afa262d297 = dataSource;
	}

	internal string x04968c2c1f991c0e()
	{
		x37d9454027bef4e2();
		StringBuilder stringBuilder = new StringBuilder();
		string x0179a04e11cec04d = x54c413cc80cb99d5.x0179a04e11cec04d;
		MatchCollection matchCollection = xd3dad1c6d3ab446c.Matches(x0179a04e11cec04d);
		int num = 0;
		int num2 = 0;
		while (num < matchCollection.Count && num2 < x0179a04e11cec04d.Length)
		{
			Match match = matchCollection[num];
			if (num2 < match.Index)
			{
				stringBuilder.Append(x0179a04e11cec04d[num2]);
				num2++;
				continue;
			}
			x714b8c1b8d1b556b x37f3a555926e71c = new x714b8c1b8d1b556b(match.Groups[2].Value, match.Groups[1].Value, match.Groups[3].Value);
			string value = x54c413cc80cb99d5.x193434603289be03(this, x37f3a555926e71c);
			stringBuilder.Append(value);
			num2 += match.Length;
			num++;
		}
		return stringBuilder.ToString();
	}

	internal string x0a554e652b768c5d()
	{
		x37d9454027bef4e2();
		ArrayList arrayList = new ArrayList();
		MatchCollection matchCollection = xd3dad1c6d3ab446c.Matches(x54c413cc80cb99d5.x0179a04e11cec04d);
		foreach (Match item in matchCollection)
		{
			string text = xcb69f8cc19c48144(item);
			if (x0d299f323d241756.x5959bccb67bbf051(text))
			{
				arrayList.Add(text.Trim());
			}
		}
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < arrayList.Count; i++)
		{
			stringBuilder.Append(arrayList[i]);
			if (i < arrayList.Count - 1)
			{
				stringBuilder.Append(" ");
			}
		}
		return stringBuilder.ToString();
	}

	private void x37d9454027bef4e2()
	{
		Document document = x54c413cc80cb99d5.x0e887c4fa8f397a5();
		MailMergeSettings mailMergeSettings = document.MailMergeSettings;
		if (!mailMergeSettings.x7149c962c02931b3)
		{
			mailMergeSettings.Odso.FieldMapDatas.xb37a1dde21a93661();
		}
	}

	private string xcb69f8cc19c48144(Match x1b25e8c7ff13d736)
	{
		x714b8c1b8d1b556b x37f3a555926e71c = new x714b8c1b8d1b556b(x1b25e8c7ff13d736.Groups[2].Value, x1b25e8c7ff13d736.Groups[1].Value, x1b25e8c7ff13d736.Groups[3].Value);
		return x54c413cc80cb99d5.x193434603289be03(this, x37f3a555926e71c);
	}

	private string x7ce5e1549f1ffa98(string x66ac3558868cc255)
	{
		Document document = x54c413cc80cb99d5.x0e887c4fa8f397a5();
		foreach (OdsoFieldMapData fieldMapData in document.MailMergeSettings.Odso.FieldMapDatas)
		{
			if (x0d299f323d241756.x90637a473b1ceaaa(fieldMapData.MappedName, x66ac3558868cc255))
			{
				return fieldMapData.Name;
			}
		}
		return x66ac3558868cc255;
	}

	private string x65a7f033bc7b6bd7(string xa2352ce4aff408ae)
	{
		string text = (string)x54c413cc80cb99d5.x874958d584af49b9[xa2352ce4aff408ae];
		if (text != null)
		{
			string x66ac3558868cc = x7ce5e1549f1ffa98(text);
			if (xb94636afa262d297.x3f88a25febd23896(x66ac3558868cc, out var x5fc53c4ffd3eb8c))
			{
				return x5fc53c4ffd3eb8c.ToString();
			}
			return string.Empty;
		}
		return string.Empty;
	}

	string x190443e12b0b496b.x193434603289be03(string xa2352ce4aff408ae)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x65a7f033bc7b6bd7
		return this.x65a7f033bc7b6bd7(xa2352ce4aff408ae);
	}
}
