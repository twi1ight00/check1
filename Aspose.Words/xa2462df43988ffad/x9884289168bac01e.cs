using System.Text.RegularExpressions;
using Aspose.Words;
using Aspose.Words.Fields;
using x6c95d9cf46ff5f25;

namespace xa2462df43988ffad;

internal class x9884289168bac01e
{
	private const int x551b1b39a9a0387f = 1;

	private const int xda59d16a77e4892e = 2;

	private const int x4efefb3026ab7aab = 3;

	private const int x4e7dbc12acaf53b1 = 4;

	private const int x3eb7ea2f63d7cf18 = 1;

	private const int xff7510e7eaf62bc4 = 2;

	private const int xf4bceb36959a9099 = 3;

	private const int x1daccfe35651dbdb = 5;

	private readonly xdb0bf9f81de4b38c x9b287b671d592594;

	private readonly x560f0e9efcf5b9b1 x6962cbeae4129aa3;

	private readonly x3f151365c926402f x26fe7a226df36e74;

	private static readonly Regex x1ccc142457b2f8d4 = new Regex("(" + ControlChar.PageBreak + ")|(" + ControlChar.ColumnBreak + ")|(" + ControlChar.ParagraphBreak + ")|([^" + ControlChar.PageBreak + ControlChar.ColumnBreak + ControlChar.ParagraphBreak + "]*)", RegexOptions.Compiled | RegexOptions.Singleline);

	private static readonly Regex x7c8d2cd59f76fbcb = new Regex("(" + ControlChar.Tab + ")|(" + ControlChar.LineBreak + ")|((" + ControlChar.x3e1feffd8ca6feb2 + "){1,})|([^" + ControlChar.Tab + ControlChar.x3e1feffd8ca6feb2 + ControlChar.LineBreak + "]*)", RegexOptions.Compiled | RegexOptions.Singleline);

	internal x9884289168bac01e(xdb0bf9f81de4b38c writer)
	{
		x9b287b671d592594 = writer;
		x6962cbeae4129aa3 = new x560f0e9efcf5b9b1(x9b287b671d592594);
		x26fe7a226df36e74 = new x3f151365c926402f(x9b287b671d592594);
	}

	internal void x6210059f049f0d48(Inline x31545d7c306a55e4)
	{
		if (!x9b287b671d592594.x52320ec9c1034d1f)
		{
			bool flag = x3f151365c926402f.x1b00a9cefdb5b344(x31545d7c306a55e4.ParentParagraph);
			if (!flag)
			{
				xffb053d2a78c4e1b();
			}
			string xff8c5091e045feee = x11aaa715ad8238ea(x31545d7c306a55e4.GetText());
			xb4d4c4e99a699d79(xff8c5091e045feee);
			if (!flag)
			{
				x81ddb41fb70cbf68();
			}
			x9b287b671d592594.xc907f222971a2a50 = false;
		}
	}

	internal void xffb053d2a78c4e1b()
	{
		x9c77c7e782b62883 xe1410f585439c7d = x9b287b671d592594.xe1410f585439c7d4;
		xe1410f585439c7d.x5a3f5d78674f78e4("text:span");
		xe1410f585439c7d.x53e7651cce580e9f("text:style-name", x6962cbeae4129aa3.xfb973fa049c32c2d());
	}

	internal void x81ddb41fb70cbf68()
	{
		x9b287b671d592594.xe1410f585439c7d4.xf3cbeec41f083290("text:span");
	}

	internal VisitorAction xdc0a84c0e3e375cb(Inline x31545d7c306a55e4)
	{
		string text = x31545d7c306a55e4.GetText();
		if (text == ControlChar.x52a843d47a26d1df || text == ControlChar.xf4a399b5bb9c2b9e)
		{
			return VisitorAction.Continue;
		}
		Paragraph parentParagraph = x31545d7c306a55e4.ParentParagraph;
		if (!parentParagraph.xc8d1bb1390d5266d && x9b287b671d592594.x68e1404b914783c1)
		{
			return VisitorAction.Continue;
		}
		bool flag = text.IndexOf(ControlChar.PageBreak) != -1 || text.IndexOf(ControlChar.ColumnBreak) != -1 || text.IndexOf(ControlChar.ParagraphBreak) != -1;
		if (x470c3167f40ccc1c(text, flag))
		{
			return VisitorAction.Continue;
		}
		switch (x9b287b671d592594.x05ee8ce4d7312eb5)
		{
		case x14bf6f47128e4438.x213a21086ebb469c:
		case x14bf6f47128e4438.x05a725d9893e5a35:
			if ((!x9b287b671d592594.x52320ec9c1034d1f || flag) && !x3f151365c926402f.x1b00a9cefdb5b344(parentParagraph))
			{
				if (flag)
				{
					x91a3bdd9f330a6f1(x31545d7c306a55e4);
				}
				else
				{
					x6962cbeae4129aa3.xaedce5725e456ac5(x31545d7c306a55e4);
				}
			}
			break;
		case x14bf6f47128e4438.x04e4ed301f6f3a72:
		case x14bf6f47128e4438.x62af77d3c3af0871:
			if (flag)
			{
				xe20f295529e1d2ce(x31545d7c306a55e4);
			}
			else
			{
				x6210059f049f0d48(x31545d7c306a55e4);
			}
			break;
		}
		return VisitorAction.Continue;
	}

	private void x91a3bdd9f330a6f1(Inline x31545d7c306a55e4)
	{
		Paragraph parentParagraph = x31545d7c306a55e4.ParentParagraph;
		MatchCollection matchCollection = x1ccc142457b2f8d4.Matches(x31545d7c306a55e4.GetText());
		foreach (Match item in matchCollection)
		{
			if ((x0d299f323d241756.x5959bccb67bbf051(item.Groups[2].Value) || x0d299f323d241756.x5959bccb67bbf051(item.Groups[1].Value) || x0d299f323d241756.x5959bccb67bbf051(item.Groups[3].Value)) && !x8227bbb95436664e(x31545d7c306a55e4, item.Index))
			{
				if (x0d299f323d241756.x5959bccb67bbf051(item.Groups[2].Value))
				{
					x6962cbeae4129aa3.xaedce5725e456ac5(parentParagraph, x9509445ad0c3e86a: false, xabdcf516a31c311c: true);
				}
				if (x0d299f323d241756.x5959bccb67bbf051(item.Groups[1].Value))
				{
					x6962cbeae4129aa3.xaedce5725e456ac5(parentParagraph, x9509445ad0c3e86a: true, xabdcf516a31c311c: false);
				}
				if (x0d299f323d241756.x5959bccb67bbf051(item.Groups[3].Value))
				{
					x6962cbeae4129aa3.xaedce5725e456ac5(parentParagraph, x9509445ad0c3e86a: false, xabdcf516a31c311c: false);
				}
			}
			if (x0d299f323d241756.x5959bccb67bbf051(item.Groups[4].Value) && !x9b287b671d592594.x52320ec9c1034d1f)
			{
				x6962cbeae4129aa3.xaedce5725e456ac5(x31545d7c306a55e4);
			}
		}
	}

	private void xe20f295529e1d2ce(Inline x31545d7c306a55e4)
	{
		Paragraph parentParagraph = x31545d7c306a55e4.ParentParagraph;
		Section section = (Section)parentParagraph.ParentSection.Clone(isCloneChildren: true);
		Paragraph paragraph = (Paragraph)parentParagraph.Clone(isCloneChildren: true);
		section.Body.Paragraphs.Add(paragraph);
		MatchCollection matchCollection = x1ccc142457b2f8d4.Matches(x31545d7c306a55e4.GetText());
		foreach (Match item in matchCollection)
		{
			string value = item.Groups[4].Value;
			if ((x0d299f323d241756.x5959bccb67bbf051(item.Groups[2].Value) || x0d299f323d241756.x5959bccb67bbf051(item.Groups[1].Value) || x0d299f323d241756.x5959bccb67bbf051(item.Groups[3].Value)) && !x8227bbb95436664e(x31545d7c306a55e4, item.Index))
			{
				x26fe7a226df36e74.x2bba81f7e198efaa(parentParagraph);
			}
			if (x0d299f323d241756.x5959bccb67bbf051(value))
			{
				Run run = (Run)x31545d7c306a55e4.Clone(isCloneChildren: true);
				paragraph.Runs.Add(run);
				run.Text = value;
				x6210059f049f0d48(run);
			}
		}
	}

	private bool x8227bbb95436664e(Inline x31545d7c306a55e4, int x57ccbbf74140093f)
	{
		if ((x57ccbbf74140093f != 0 || !x31545d7c306a55e4.x65c77554c620f590) && !(x9b287b671d592594.x1f3ed48ef81a3a47 is FieldStart) && !(x31545d7c306a55e4.NextSibling is FieldEnd))
		{
			if (x57ccbbf74140093f == x31545d7c306a55e4.GetText().Length - 1)
			{
				return x31545d7c306a55e4.NextSibling == null;
			}
			return false;
		}
		return true;
	}

	private void xb4d4c4e99a699d79(string xff8c5091e045feee)
	{
		x9c77c7e782b62883 xe1410f585439c7d = x9b287b671d592594.xe1410f585439c7d4;
		MatchCollection matchCollection = x7c8d2cd59f76fbcb.Matches(xff8c5091e045feee);
		foreach (Match item in matchCollection)
		{
			string value = item.Groups[5].Value;
			if (x0d299f323d241756.x5959bccb67bbf051(value))
			{
				xe1410f585439c7d.x3d1be38abe5723e3(value);
			}
			string value2 = item.Groups[3].Value;
			if (x0d299f323d241756.x5959bccb67bbf051(value2))
			{
				x0b1e883e8d145124(value2.Length);
			}
			if (x0d299f323d241756.x5959bccb67bbf051(item.Groups[1].Value))
			{
				xe72b72a917296a39();
			}
			if (x0d299f323d241756.x5959bccb67bbf051(item.Groups[2].Value))
			{
				xe1410f585439c7d.xd52401bdf5aacef6("<text:line-break/>");
			}
		}
	}

	private void xe72b72a917296a39()
	{
		x9b287b671d592594.xe1410f585439c7d4.xd52401bdf5aacef6("<text:tab/>");
	}

	private void x0b1e883e8d145124(int xc0575bc407b3c539)
	{
		if (xc0575bc407b3c539 > 0)
		{
			if (xc0575bc407b3c539 == 1)
			{
				x9b287b671d592594.xe1410f585439c7d4.xd52401bdf5aacef6("<text:s/>");
			}
			else
			{
				x9b287b671d592594.xe1410f585439c7d4.xd52401bdf5aacef6($"<text:s text:c=\"{xc0575bc407b3c539}\"/>");
			}
		}
	}

	private void x7104923e61fc4094()
	{
		x9b287b671d592594.xe1410f585439c7d4.xd52401bdf5aacef6(" <text:s/>");
	}

	internal static string x11aaa715ad8238ea(string xb41faee6912a2313)
	{
		if (xb41faee6912a2313 != null)
		{
			xb41faee6912a2313 = xb41faee6912a2313.Replace('\u001e', '‑');
			xb41faee6912a2313 = xb41faee6912a2313.Replace('\u001f', '\u00ad');
		}
		return xb41faee6912a2313;
	}

	private bool x470c3167f40ccc1c(string xb41faee6912a2313, bool x69ec2114638bfff5)
	{
		if (!x0d299f323d241756.x5959bccb67bbf051(x9b287b671d592594.xe1410f585439c7d4.x80134a53bcbb9665(xb41faee6912a2313)) && !x69ec2114638bfff5 && xb41faee6912a2313.IndexOf(ControlChar.LineBreak) == -1)
		{
			return xb41faee6912a2313.IndexOf(ControlChar.Tab) == -1;
		}
		return false;
	}
}
