using System;
using Aspose.Words;
using Aspose.Words.Fields;
using Aspose.Words.Lists;
using x28925c9b27b37a46;
using x5794c252ba25e723;

namespace xfbd1009a0cbb9842;

internal class x7eda97d1ce06039c : x40276702cac1d5f7
{
	internal const int x75b19c258b5c40c6 = -1;

	private const int x4be27d95308f67e1 = 1;

	private const int x6d6e2e2f23fd77f6 = -1;

	private readonly x1552b3704ef89039 x54c413cc80cb99d5;

	private readonly Paragraph x233446e8759c5129;

	private readonly int xaabccab0c06d038b;

	private readonly Node x7f7e88211ff27fbd;

	private readonly Node x28375f53451c4ec8;

	public int x504f3d4040b356d7 => xaabccab0c06d038b;

	public bool x5c35225eba240e1a => false;

	private Document x2c8c6741422a1298 => x233446e8759c5129.x357c90b33d6bb8e6();

	internal x7eda97d1ce06039c(x1552b3704ef89039 field, Paragraph paragraph, x5f0e8a959fb1463f entryInfo)
	{
		x54c413cc80cb99d5 = field;
		x233446e8759c5129 = paragraph;
		xaabccab0c06d038b = entryInfo.x504f3d4040b356d7;
		x28375f53451c4ec8 = ((entryInfo.xe98eb74983649df0 != null) ? entryInfo.xe98eb74983649df0 : paragraph.xfe93db1ba6e25886);
		x7f7e88211ff27fbd = ((entryInfo.x1f63ab34d720cabb != null) ? entryInfo.x1f63ab34d720cabb : paragraph.xc0f45b01af564b77);
	}

	public Bookmark x7db09d025a6abf05(string xd17ec8f278d25c87)
	{
		Node node = x473276fb10bb95d9();
		if (node == null)
		{
			return null;
		}
		Node node2 = xf78cd118b22b26e2();
		if (node2 == null)
		{
			return null;
		}
		BookmarkStart bookmarkStart = new BookmarkStart(x2c8c6741422a1298, xd17ec8f278d25c87);
		node.ParentNode.InsertBefore(bookmarkStart, node);
		BookmarkEnd newChild = new BookmarkEnd(x2c8c6741422a1298, xd17ec8f278d25c87);
		node2.ParentNode.InsertAfter(newChild, node2);
		return new Bookmark(bookmarkStart);
	}

	private Node x473276fb10bb95d9()
	{
		return x97eb0f368524bc64(1);
	}

	private Node xf78cd118b22b26e2()
	{
		return x97eb0f368524bc64(-1);
	}

	private Node x97eb0f368524bc64(int x5a231e160d743567)
	{
		return x5a231e160d743567 switch
		{
			1 => x97eb0f368524bc64(x5a231e160d743567, x28375f53451c4ec8, x7f7e88211ff27fbd), 
			-1 => x97eb0f368524bc64(x5a231e160d743567, x7f7e88211ff27fbd, x28375f53451c4ec8), 
			_ => null, 
		};
	}

	private Node x97eb0f368524bc64(int x5a231e160d743567, Node x7fb5b4b571b9393e, Node xed4f1959cf48c9ab)
	{
		bool flag = false;
		Node node = x7fb5b4b571b9393e;
		int num = 0;
		while (node != null && !flag)
		{
			switch (node.NodeType)
			{
			case NodeType.FieldStart:
				num++;
				break;
			case NodeType.FieldSeparator:
				num--;
				break;
			case NodeType.FieldEnd:
				if (!((FieldEnd)node).HasSeparator)
				{
					num--;
				}
				break;
			case NodeType.Run:
			{
				if (num > 0)
				{
					break;
				}
				Run run = (Run)node;
				if (!run.x1a2af56d5e4e537b)
				{
					int num2 = x26b6d7f6cf1f912a(run.Text, x5a231e160d743567);
					if (num2 != -1)
					{
						x61ab77fa63340051(run, x5a231e160d743567, num2);
						return run;
					}
				}
				break;
			}
			}
			flag = node == xed4f1959cf48c9ab;
			node = ((x5a231e160d743567 == 1) ? node.xa6890a1cb2b8896e : node.x90463af0c741fac1);
		}
		return null;
	}

	private static void x61ab77fa63340051(Run xb0e5d73738e62f9e, int x5a231e160d743567, int xc3c42857230bd292)
	{
		if (x5a231e160d743567 == 1)
		{
			xb0e5d73738e62f9e.x4a406570a6226227(xc3c42857230bd292);
		}
		else
		{
			xb0e5d73738e62f9e.xd0d7979207229aff(xc3c42857230bd292 + 1);
		}
	}

	internal static int x26b6d7f6cf1f912a(string xb41faee6912a2313)
	{
		return x26b6d7f6cf1f912a(xb41faee6912a2313, 1);
	}

	private static int x26b6d7f6cf1f912a(string xb41faee6912a2313, int x5a231e160d743567)
	{
		int i;
		int num;
		switch (x5a231e160d743567)
		{
		case 1:
			i = 0;
			num = xb41faee6912a2313.Length;
			break;
		case -1:
			i = xb41faee6912a2313.Length - 1;
			num = -1;
			break;
		default:
			throw new ArgumentException("step");
		}
		bool flag = false;
		for (; i != num; i += x5a231e160d743567)
		{
			flag = xb4de748fc0df79ab(xb41faee6912a2313[i]);
			if (flag)
			{
				break;
			}
		}
		if (!flag)
		{
			return -1;
		}
		return i;
	}

	private static bool xb4de748fc0df79ab(char x3c4da2980d043c95)
	{
		if (!char.IsWhiteSpace(x3c4da2980d043c95) && x3c4da2980d043c95 != '\f')
		{
			return x3c4da2980d043c95 != '\u000e';
		}
		return false;
	}

	public void xff2bb2b3436f4d08(DocumentBuilder xd07ce4b74c5774a7)
	{
		if (x233446e8759c5129.IsListItem)
		{
			Run run = new Run(x2c8c6741422a1298, x233446e8759c5129.ListLabel.LabelString, (xeedad81aaed42a76)x233446e8759c5129.ListFormat.ListLevel.xeedad81aaed42a76.x8b61531c8ea35b85());
			Paragraph paragraph = new Paragraph(x2c8c6741422a1298);
			paragraph.ParagraphFormat.Style = x233446e8759c5129.xfcffbd79482d97c7;
			paragraph.AppendChild(run);
			x7e263f21a73a027a x5f36ad26e64b91c = new x7e263f21a73a027a(run, run);
			x0a28863c804404d7.x775521112ede5e6f(x5f36ad26e64b91c, xd07ce4b74c5774a7.CurrentNode, x54c413cc80cb99d5.xa835b299e2f442a9(this));
			switch (x233446e8759c5129.ListFormat.ListLevel.TrailingCharacter)
			{
			case ListTrailingCharacter.Tab:
			{
				double x13d4cb8d1bd = xd6b5c3a7b932cb2d(xd07ce4b74c5774a7);
				x1552b3704ef89039.xca94f9a608ff4a9f(xd07ce4b74c5774a7, x13d4cb8d1bd, TabAlignment.Left, TabLeader.None);
				x64e76dd21d067621(xd07ce4b74c5774a7, ControlChar.Tab);
				break;
			}
			case ListTrailingCharacter.Space:
				x64e76dd21d067621(xd07ce4b74c5774a7, " ");
				break;
			default:
				throw new ArgumentOutOfRangeException();
			case ListTrailingCharacter.Nothing:
				break;
			}
		}
	}

	private void x64e76dd21d067621(DocumentBuilder xd07ce4b74c5774a7, string x12f11d52c2c4d003)
	{
		x1552b3704ef89039.x1b24870b1de870e4(x2c8c6741422a1298, xd07ce4b74c5774a7);
		xd07ce4b74c5774a7.Write(x12f11d52c2c4d003);
	}

	private double xd6b5c3a7b932cb2d(DocumentBuilder xd07ce4b74c5774a7)
	{
		Run run = (Run)xd07ce4b74c5774a7.CurrentNode.PreviousSibling;
		Font font = run.Font;
		xe39d06eee35dd23d xe39d06eee35dd23d = x2c8c6741422a1298.FontInfos.x26ee10d60756aeab.x491f5a7224612753(font.Name, (float)font.Size, font.xfa47517dba72fd20);
		double num = (double)xe39d06eee35dd23d.xee2b4ba51feab3ca(run.Text) + 11.0;
		ParagraphFormat paragraphFormat = x8a5ed74f030bb90a(x504f3d4040b356d7);
		double firstLineIndent = paragraphFormat.FirstLineIndent;
		double leftIndent = paragraphFormat.LeftIndent;
		double x11678d478b9113f = leftIndent + firstLineIndent + num;
		return x90e1c76d95d39e09(x504f3d4040b356d7, x11678d478b9113f);
	}

	private double x90e1c76d95d39e09(int xecf86884efc78f9d, double x11678d478b9113f1)
	{
		ParagraphFormat paragraphFormat = x8a5ed74f030bb90a(xecf86884efc78f9d);
		double firstLineIndent = paragraphFormat.FirstLineIndent;
		double leftIndent = paragraphFormat.LeftIndent;
		double num = 0.0;
		TabStop tabStop = paragraphFormat.TabStops?.After(x11678d478b9113f1);
		double num2 = ((firstLineIndent < 0.0) ? (leftIndent - x11678d478b9113f1) : 0.0);
		if (tabStop != null && tabStop.Alignment == TabAlignment.Left && xecf86884efc78f9d == x504f3d4040b356d7)
		{
			num = tabStop.Position - x11678d478b9113f1;
			if (tabStop.Alignment != TabAlignment.List && num2 > 0.0 && num2 < num)
			{
				num = num2;
			}
		}
		else if (num2 > 0.0)
		{
			num = num2;
		}
		if (num > 0.0)
		{
			return x11678d478b9113f1 + num;
		}
		if (num <= 0.0 && xecf86884efc78f9d < 9)
		{
			ParagraphFormat paragraphFormat2 = x8a5ed74f030bb90a(xecf86884efc78f9d + 1);
			double leftIndent2 = paragraphFormat2.LeftIndent;
			if (leftIndent2 - x11678d478b9113f1 > 0.0)
			{
				return leftIndent2;
			}
		}
		if (xecf86884efc78f9d < 9)
		{
			return x90e1c76d95d39e09(xecf86884efc78f9d + 1, x11678d478b9113f1);
		}
		return x11678d478b9113f1;
	}

	private ParagraphFormat x8a5ed74f030bb90a(int xecf86884efc78f9d)
	{
		StyleIdentifier styleIdentifier = x1552b3704ef89039.x84a48c5d2367b712(xecf86884efc78f9d);
		Style style = x2c8c6741422a1298.Styles.xf21e14e2c9db279a(styleIdentifier, x988fcf605f8efa7e: false);
		if (style != null)
		{
			return style.ParagraphFormat;
		}
		style = x2c8c6741422a1298.Styles.xc6b4c6fa9a60b0fc[styleIdentifier];
		ParagraphFormat paragraphFormat = new ParagraphFormat((xac4d96a62eaba39e)style.x1a78664fa10a3755.x8b61531c8ea35b85(), x2c8c6741422a1298.Styles);
		paragraphFormat.LeftIndent = (double)(xecf86884efc78f9d - 1) * 11.0;
		return paragraphFormat;
	}
}
