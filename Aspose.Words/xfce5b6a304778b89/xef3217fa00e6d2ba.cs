using System.Collections;
using System.Text;
using System.Text.RegularExpressions;
using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Lists;
using Aspose.Words.Tables;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace xfce5b6a304778b89;

internal class xef3217fa00e6d2ba
{
	private static bool xc4b7067557b5d3f8;

	private xef3217fa00e6d2ba()
	{
	}

	internal static void x06b0e25aa6ad68a9(xf871da68decec406 xe134235b3526fa75, string x4bbc2c453c470189, CompositeNode xbe8ce7206677d91d, x09bf2b07acaf11a4 xfb7c3d67fd08b1e3, bool x0ff7f9ed695bb89a)
	{
		xc4b7067557b5d3f8 = x0ff7f9ed695bb89a;
		x06b0e25aa6ad68a9(xe134235b3526fa75, x4bbc2c453c470189, xbe8ce7206677d91d);
		xc4b7067557b5d3f8 = false;
		if (xfb7c3d67fd08b1e3 == null)
		{
			return;
		}
		Paragraph paragraph = (Paragraph)xbe8ce7206677d91d.LastChild;
		if (x0ff7f9ed695bb89a)
		{
			List list = xfb7c3d67fd08b1e3.x06ca69422bbb7502;
			if (!xe134235b3526fa75.x49e385128b291987 && xfb7c3d67fd08b1e3.x13129000d8a343ae && list.ListLevels[xe134235b3526fa75.xf13a626e550cef8f].NumberStyle != NumberStyle.Bullet)
			{
				list = xe134235b3526fa75.x2c8c6741422a1298.Lists.AddCopy(xfb7c3d67fd08b1e3.x06ca69422bbb7502);
			}
			paragraph.x1a78664fa10a3755.x71c63f7e57f7ede5 = list.ListId;
			paragraph.x1a78664fa10a3755.xf13a626e550cef8f = xe134235b3526fa75.xf13a626e550cef8f;
			xfb7c3d67fd08b1e3.x13129000d8a343ae = true;
		}
		else
		{
			paragraph.x1a78664fa10a3755.xc0741c7ff92cf1aa = xfb7c3d67fd08b1e3.x06ca69422bbb7502.ListLevels.x90a164d2f15bfc09(xe134235b3526fa75.xf13a626e550cef8f).x1a78664fa10a3755.xc0741c7ff92cf1aa;
		}
	}

	internal static void x06b0e25aa6ad68a9(xf871da68decec406 xe134235b3526fa75, string x4bbc2c453c470189, CompositeNode xbe8ce7206677d91d)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		xe134235b3526fa75.xe5ffcf1e3f9bd387 = null;
		while (xca994afbcb9073a.x1ac1960adc8c4c39())
		{
			xffbf6c5acf32ac4b(xe134235b3526fa75);
		}
		x38c672d671ef22c7 x38c672d671ef22c8 = (x38c672d671ef22c7)xe134235b3526fa75.x37eb83f4e2a8fe56.get_xe6d4b1b411ed94b5(xe134235b3526fa75.xe5ffcf1e3f9bd387, "paragraph", xe134235b3526fa75.xb9e32c79bd755ad8, xafd04c36a00d5bcf: true);
		Paragraph paragraph;
		if (xe134235b3526fa75.x6147b51b34c29eea.Count > 0 && xbe8ce7206677d91d is Body)
		{
			paragraph = (Paragraph)xe134235b3526fa75.x6147b51b34c29eea[xe134235b3526fa75.x6147b51b34c29eea.Count - 1];
			xe134235b3526fa75.x6147b51b34c29eea.RemoveAt(xe134235b3526fa75.x6147b51b34c29eea.Count - 1);
		}
		else
		{
			paragraph = new Paragraph(xe134235b3526fa75.x2c8c6741422a1298);
			xbe8ce7206677d91d.AppendChild(paragraph);
		}
		if (x4bbc2c453c470189 == "h")
		{
			xc78c2ee92f99e653(xe134235b3526fa75, paragraph);
		}
		xf871da68decec406.x3da162cd5d0dd2a4 = "";
		x4b7c2f007465fd90(xe134235b3526fa75, paragraph, x4bbc2c453c470189, x38c672d671ef22c8, xbe8ce7206677d91d);
		xc8e7dcf5cb9a777a(xe134235b3526fa75, paragraph, x38c672d671ef22c8);
		if (x38c672d671ef22c8 == null)
		{
			Style style = xe134235b3526fa75.x2c8c6741422a1298.Styles[(xe134235b3526fa75.xe5ffcf1e3f9bd387 == null) ? "Standard" : xe134235b3526fa75.xe5ffcf1e3f9bd387];
			if (style != null)
			{
				paragraph.ParagraphFormat.Style = style;
			}
		}
		else
		{
			if (x38c672d671ef22c8.x1a78664fa10a3755 != null)
			{
				paragraph.x1a78664fa10a3755 = (x1a78664fa10a3755)x38c672d671ef22c8.x1a78664fa10a3755.x8b61531c8ea35b85();
			}
			if (x0d299f323d241756.x5959bccb67bbf051(x38c672d671ef22c8.x6901ea11a338ff2b))
			{
				Style style2 = xe134235b3526fa75.x2c8c6741422a1298.Styles[x38c672d671ef22c8.x6901ea11a338ff2b];
				if (style2 != null)
				{
					paragraph.x1a78664fa10a3755.x8301ab10c226b0c2 = style2.x8301ab10c226b0c2;
					x3550b06eb6642718(paragraph.ParagraphFormat.Style.x1a78664fa10a3755.x8df6f6ca274123b0, paragraph.x1a78664fa10a3755.x8df6f6ca274123b0);
				}
			}
			if (paragraph.x7f316d7196a18aa6 && x38c672d671ef22c8.x4f039b1e0e8b59ec != 0)
			{
				paragraph.xc5464084edc8e226.xf8cef531dae89ea3.xae20093bed1e48a8(3050, x38c672d671ef22c8.x4f039b1e0e8b59ec);
			}
			x4b66571195618e95(paragraph, x38c672d671ef22c8);
		}
		xa517c5f99e7b6e48(paragraph, x38c672d671ef22c8);
		x1691bd9a385f30c6(paragraph);
	}

	private static void x4b66571195618e95(Paragraph x9c79b5ad7b769b12, x38c672d671ef22c7 x5173842427610357)
	{
		if (x9c79b5ad7b769b12.ParentSection != null && x9c79b5ad7b769b12 == x9c79b5ad7b769b12.ParentSection.Body.FirstParagraph)
		{
			if (x0d299f323d241756.x5959bccb67bbf051(x5173842427610357.x7155dda3b72cd3e5))
			{
				x9c79b5ad7b769b12.ParentSection.xfc72d4c9b765cad7.xae20093bed1e48a8(2200, xca004f56614e2431.x59884ab46dd0d856(x5173842427610357.x7155dda3b72cd3e5));
				x9c79b5ad7b769b12.ParentSection.xfc72d4c9b765cad7.xae20093bed1e48a8(2050, true);
			}
			if (x5173842427610357.x845183cdf0fdbeec > 0 && x9c79b5ad7b769b12.ParentSection.xfc72d4c9b765cad7.x68f66930d0ba42cc != LineNumberRestartMode.Continuous)
			{
				x9c79b5ad7b769b12.ParentSection.xfc72d4c9b765cad7.xae20093bed1e48a8(2180, x5173842427610357.x845183cdf0fdbeec);
				x9c79b5ad7b769b12.ParentSection.xfc72d4c9b765cad7.xae20093bed1e48a8(2110, LineNumberRestartMode.RestartSection);
				x9c79b5ad7b769b12.x1a78664fa10a3755.xb6157b6da9895c0d(1130, false);
			}
		}
	}

	private static void x1691bd9a385f30c6(Paragraph x9c79b5ad7b769b12)
	{
		ParagraphAlignment x9ba359ff37a3a63b = x9c79b5ad7b769b12.x1a78664fa10a3755.x9ba359ff37a3a63b;
		if (!x9c79b5ad7b769b12.IsInCell)
		{
			return;
		}
		TextOrientation x2c5926113e = x9c79b5ad7b769b12.xc5464084edc8e226.xf8cef531dae89ea3.x2c5926113e101674;
		CellVerticalAlignment xf6ce0e8106e6a1d = x9c79b5ad7b769b12.xc5464084edc8e226.xf8cef531dae89ea3.xf6ce0e8106e6a1d8;
		if (x2c5926113e != TextOrientation.Upward)
		{
			return;
		}
		if (xf6ce0e8106e6a1d == CellVerticalAlignment.Bottom)
		{
			if (x9ba359ff37a3a63b == ParagraphAlignment.Left)
			{
				x9c79b5ad7b769b12.xc5464084edc8e226.xf8cef531dae89ea3.xf6ce0e8106e6a1d8 = CellVerticalAlignment.Top;
			}
			if (x9ba359ff37a3a63b == ParagraphAlignment.Right)
			{
				x9c79b5ad7b769b12.x1a78664fa10a3755.x9ba359ff37a3a63b = ParagraphAlignment.Left;
			}
			if (x9ba359ff37a3a63b == ParagraphAlignment.Center)
			{
				x9c79b5ad7b769b12.x1a78664fa10a3755.x9ba359ff37a3a63b = ParagraphAlignment.Left;
				x9c79b5ad7b769b12.xc5464084edc8e226.xf8cef531dae89ea3.xf6ce0e8106e6a1d8 = CellVerticalAlignment.Center;
			}
		}
		if (xf6ce0e8106e6a1d == CellVerticalAlignment.Top)
		{
			if (x9ba359ff37a3a63b == ParagraphAlignment.Left)
			{
				x9c79b5ad7b769b12.x1a78664fa10a3755.x9ba359ff37a3a63b = ParagraphAlignment.Right;
			}
			if (x9ba359ff37a3a63b == ParagraphAlignment.Right)
			{
				x9c79b5ad7b769b12.xc5464084edc8e226.xf8cef531dae89ea3.xf6ce0e8106e6a1d8 = CellVerticalAlignment.Bottom;
			}
		}
		if (xf6ce0e8106e6a1d == CellVerticalAlignment.Center)
		{
			if (x9ba359ff37a3a63b == ParagraphAlignment.Left)
			{
				x9c79b5ad7b769b12.x1a78664fa10a3755.x9ba359ff37a3a63b = ParagraphAlignment.Center;
				x9c79b5ad7b769b12.xc5464084edc8e226.xf8cef531dae89ea3.xf6ce0e8106e6a1d8 = CellVerticalAlignment.Top;
			}
			if (x9ba359ff37a3a63b == ParagraphAlignment.Right)
			{
				x9c79b5ad7b769b12.x1a78664fa10a3755.x9ba359ff37a3a63b = ParagraphAlignment.Center;
				x9c79b5ad7b769b12.xc5464084edc8e226.xf8cef531dae89ea3.xf6ce0e8106e6a1d8 = CellVerticalAlignment.Bottom;
			}
		}
		if (xf6ce0e8106e6a1d == CellVerticalAlignment.Top && x9ba359ff37a3a63b == ParagraphAlignment.Center)
		{
			x9c79b5ad7b769b12.x1a78664fa10a3755.x9ba359ff37a3a63b = ParagraphAlignment.Right;
			x9c79b5ad7b769b12.xc5464084edc8e226.xf8cef531dae89ea3.xf6ce0e8106e6a1d8 = CellVerticalAlignment.Center;
		}
	}

	private static void x3550b06eb6642718(TabStopCollection x82cf3fc7148a245f, TabStopCollection xe09493546381bd00)
	{
		if (x82cf3fc7148a245f == null || xe09493546381bd00 == null)
		{
			return;
		}
		for (int i = 0; i < x82cf3fc7148a245f.Count; i++)
		{
			if (xe09493546381bd00.GetByPositionTwips(x82cf3fc7148a245f[i].PositionTwips) == null)
			{
				TabStop tabStop = x82cf3fc7148a245f[i].Clone();
				tabStop.Alignment = TabAlignment.Clear;
				xe09493546381bd00.Add(tabStop);
			}
		}
	}

	private static void xa517c5f99e7b6e48(Paragraph x9c79b5ad7b769b12, x38c672d671ef22c7 x5173842427610357)
	{
		if (!x9c79b5ad7b769b12.x1a78664fa10a3755.x263d579af1d0d43f(1450) || x9c79b5ad7b769b12.Runs.Count == 0 || x5173842427610357 == null)
		{
			return;
		}
		Paragraph paragraph = (Paragraph)x9c79b5ad7b769b12.Clone(isCloneChildren: false);
		x9c79b5ad7b769b12.ParentNode.InsertBefore(paragraph, x9c79b5ad7b769b12);
		int num = ((x5173842427610357.x8bd988af0c57af6d <= 1) ? 1 : x5173842427610357.x8bd988af0c57af6d);
		if (x5173842427610357.x1f57ac233e4af6b3)
		{
			num = Regex.Matches(x9c79b5ad7b769b12.GetText(), "\\w+")[0].Length;
		}
		int num2 = 0;
		while (num2 < x9c79b5ad7b769b12.Runs.Count && num > 0)
		{
			Run run = x9c79b5ad7b769b12.Runs[num2];
			Run run2 = (Run)run.Clone(isCloneChildren: true);
			if (num >= run.Text.Length)
			{
				run.Remove();
				num -= run.Text.Length;
			}
			else
			{
				run2.Text = run2.Text.Substring(0, num);
				run.Text = run.Text.Substring(num);
				num = 0;
				num2++;
			}
			paragraph.Runs.Add(run2);
		}
		paragraph.x1a78664fa10a3755.xb6157b6da9895c0d(1440, DropCapPosition.Normal);
		paragraph.x1a78664fa10a3755.xb6157b6da9895c0d(1340, WrapType.Square);
		if (x9c79b5ad7b769b12.HasChildNodes)
		{
			x9c79b5ad7b769b12.x1a78664fa10a3755.xb55a99e2e1381d7f(1450);
		}
		else
		{
			x9c79b5ad7b769b12.Remove();
		}
	}

	private static void xc78c2ee92f99e653(xf871da68decec406 xe134235b3526fa75, Paragraph x9c79b5ad7b769b12)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		xca994afbcb9073a.x99f8cdb2827fa686();
		string text = xca994afbcb9073a.xd68abcd61e368af9("outline-level", null);
		if (x0d299f323d241756.x5959bccb67bbf051(text))
		{
			x9c79b5ad7b769b12.x1a78664fa10a3755.xb6157b6da9895c0d(1000, xca004f56614e2431.x59884ab46dd0d856(text));
		}
	}

	private static void xffbf6c5acf32ac4b(xf871da68decec406 xe134235b3526fa75)
	{
		xe134235b3526fa75.x81c468031b83f5fc(xe134235b3526fa75.xca994afbcb9073a2);
	}

	internal static void x4b7c2f007465fd90(xf871da68decec406 xe134235b3526fa75, Paragraph x9c79b5ad7b769b12, string x65bb1537d51f4cd7, x38c672d671ef22c7 x5173842427610357, CompositeNode xbe8ce7206677d91d)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		string text = ((x65bb1537d51f4cd7 == "span") ? "text" : "paragraph");
		x5668c8829b7abcee x5668c8829b7abcee2 = (x5668c8829b7abcee)xe134235b3526fa75.x37eb83f4e2a8fe56.get_xe6d4b1b411ed94b5(xe134235b3526fa75.xe5ffcf1e3f9bd387, text, xe134235b3526fa75.xb9e32c79bd755ad8, xafd04c36a00d5bcf: true);
		if (x5668c8829b7abcee2 == null)
		{
			x5668c8829b7abcee2 = (x5668c8829b7abcee)xe134235b3526fa75.x37eb83f4e2a8fe56.get_xe6d4b1b411ed94b5(xe134235b3526fa75.xe5ffcf1e3f9bd387, text, x0bfe184ad871a4c2: false, xafd04c36a00d5bcf: false);
		}
		xeedad81aaed42a76 x789564759d = new xeedad81aaed42a76();
		Style xce987d84406b1bfc = null;
		if (x5668c8829b7abcee2 != null)
		{
			if (x5668c8829b7abcee2.xeedad81aaed42a76 != null)
			{
				x789564759d = x5668c8829b7abcee2.xce6166c4dcb8f2b4(x5173842427610357);
			}
			if (text == "text" && x0d299f323d241756.x5959bccb67bbf051(x5668c8829b7abcee2.x6901ea11a338ff2b))
			{
				xce987d84406b1bfc = xe134235b3526fa75.x2c8c6741422a1298.Styles[x5668c8829b7abcee2.x6901ea11a338ff2b];
			}
		}
		xe134235b3526fa75.x5886c1038090f427 = true;
		while (xca994afbcb9073a.x416ea3123144a39f(x65bb1537d51f4cd7, x764dfdef5d60f7e6.x278cc3fa1e8f2bcd))
		{
			if (!xf871da68decec406.xfe4f7dca36c0076c(xe134235b3526fa75, x9c79b5ad7b769b12, x789564759d, xce987d84406b1bfc))
			{
				switch (xca994afbcb9073a.xa66385d80d4d296f)
				{
				case "":
					xc3a6fb8513d320a3(xe134235b3526fa75, x9c79b5ad7b769b12, x789564759d, xce987d84406b1bfc);
					continue;
				case "s":
					x0c14b069e863a154(xe134235b3526fa75, x9c79b5ad7b769b12, x789564759d, xce987d84406b1bfc);
					continue;
				case "tab":
					x7f3c983d2f4af32f(xe134235b3526fa75, x9c79b5ad7b769b12, x789564759d, xce987d84406b1bfc);
					continue;
				case "line-break":
					x2037c969f8f81f97(xe134235b3526fa75, x9c79b5ad7b769b12, x789564759d, ControlChar.LineBreak, xce987d84406b1bfc);
					continue;
				case "script":
					xcd31a4b5f18731d5(xe134235b3526fa75, x9c79b5ad7b769b12);
					continue;
				case "span":
					xc9bcf48b160797e1(xe134235b3526fa75, x9c79b5ad7b769b12, x5173842427610357, xbe8ce7206677d91d);
					xe134235b3526fa75.x5886c1038090f427 = true;
					continue;
				case "note":
					xfc4e6807e4311551(xe134235b3526fa75, x9c79b5ad7b769b12, x789564759d);
					xe134235b3526fa75.x5886c1038090f427 = true;
					continue;
				case "annotation":
					x1fe71dc8b99f97bf(xe134235b3526fa75, x9c79b5ad7b769b12, x789564759d);
					xe134235b3526fa75.x5886c1038090f427 = true;
					continue;
				case "bookmark":
					x9c79b5ad7b769b12.AppendChild(new BookmarkStart(xe134235b3526fa75.x2c8c6741422a1298, xca994afbcb9073a.xd68abcd61e368af9("name", null)));
					x9c79b5ad7b769b12.AppendChild(new BookmarkEnd(xe134235b3526fa75.x2c8c6741422a1298, xca994afbcb9073a.xd68abcd61e368af9("name", null)));
					xe134235b3526fa75.x5886c1038090f427 = true;
					continue;
				case "bookmark-start":
					x9c79b5ad7b769b12.AppendChild(new BookmarkStart(xe134235b3526fa75.x2c8c6741422a1298, xca994afbcb9073a.xd68abcd61e368af9("name", null)));
					xe134235b3526fa75.x5886c1038090f427 = true;
					continue;
				case "bookmark-end":
					x9c79b5ad7b769b12.AppendChild(new BookmarkEnd(xe134235b3526fa75.x2c8c6741422a1298, xca994afbcb9073a.xd68abcd61e368af9("name", null)));
					xe134235b3526fa75.x5886c1038090f427 = true;
					continue;
				case "ruby":
					x49e8946bf309e12f(xe134235b3526fa75, x9c79b5ad7b769b12, x789564759d, xce987d84406b1bfc);
					continue;
				}
				if (x0d299f323d241756.x5959bccb67bbf051(xf871da68decec406.x3da162cd5d0dd2a4) && !x3c7f98d679952a99(x9c79b5ad7b769b12.GetText()))
				{
					x2037c969f8f81f97(xe134235b3526fa75, x9c79b5ad7b769b12, x789564759d, " ", xce987d84406b1bfc);
					xf871da68decec406.x3da162cd5d0dd2a4 = "";
				}
				if (x5136f81f5d4bec94.x06b0e25aa6ad68a9(xe134235b3526fa75, x9c79b5ad7b769b12, x789564759d, xce987d84406b1bfc, x5173842427610357, xbe8ce7206677d91d))
				{
					xe134235b3526fa75.x5886c1038090f427 = true;
				}
				else
				{
					x4b7c2f007465fd90(xe134235b3526fa75, x9c79b5ad7b769b12, xca994afbcb9073a.xa66385d80d4d296f, x5173842427610357, xbe8ce7206677d91d);
				}
			}
			else
			{
				xe134235b3526fa75.x5886c1038090f427 = true;
			}
		}
		if (x5668c8829b7abcee2 != null && (!x9c79b5ad7b769b12.HasChildNodes || xc4b7067557b5d3f8) && x5668c8829b7abcee2.xeedad81aaed42a76 != null && (x65bb1537d51f4cd7 == "p" || x65bb1537d51f4cd7 == "h"))
		{
			x9c79b5ad7b769b12.x344511c4e4ce09da = x5668c8829b7abcee2.xeedad81aaed42a76;
		}
	}

	private static void xcd31a4b5f18731d5(xf871da68decec406 xe134235b3526fa75, Paragraph x9c79b5ad7b769b12)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		Shape shape = new Shape(xe134235b3526fa75.x2c8c6741422a1298);
		shape.x5e4f8afadf326191 = "text/javascript";
		while (xca994afbcb9073a.x416ea3123144a39f("script", x764dfdef5d60f7e6.x278cc3fa1e8f2bcd))
		{
			shape.xd402a2e9eed80360 = $"{shape.xd402a2e9eed80360}{xca994afbcb9073a.xd2f68ee6f47e9dfb}";
		}
		shape.xf7125312c7ee115c.xae20093bed1e48a8(952, true);
		x9c79b5ad7b769b12.AppendChild(shape);
	}

	private static void x49e8946bf309e12f(xf871da68decec406 xe134235b3526fa75, Paragraph x9c79b5ad7b769b12, xeedad81aaed42a76 x789564759d365819, Style xce987d84406b1bfc)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		while (xca994afbcb9073a.x152cbadbfa8061b1("ruby"))
		{
			switch (xe134235b3526fa75.xca994afbcb9073a2.xa66385d80d4d296f)
			{
			case "ruby-text":
				x9824b56a5b9aff04(xe134235b3526fa75, x9c79b5ad7b769b12, "ruby-text", x789564759d365819, xce987d84406b1bfc);
				break;
			case "ruby-base":
				x9824b56a5b9aff04(xe134235b3526fa75, x9c79b5ad7b769b12, "ruby-base", x789564759d365819, xce987d84406b1bfc);
				break;
			default:
				xe134235b3526fa75.xca994afbcb9073a2.IgnoreElement();
				break;
			}
		}
	}

	private static void x9824b56a5b9aff04(xf871da68decec406 xe134235b3526fa75, Paragraph x9c79b5ad7b769b12, string x65bb1537d51f4cd7, xeedad81aaed42a76 x789564759d365819, Style xce987d84406b1bfc)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		while (xca994afbcb9073a.x416ea3123144a39f(x65bb1537d51f4cd7, x764dfdef5d60f7e6.x278cc3fa1e8f2bcd))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = xca994afbcb9073a.xa66385d80d4d296f) != null && xa66385d80d4d296f == "")
			{
				xc3a6fb8513d320a3(xe134235b3526fa75, x9c79b5ad7b769b12, x789564759d365819, xce987d84406b1bfc);
			}
		}
	}

	private static void x2037c969f8f81f97(xf871da68decec406 xe134235b3526fa75, Paragraph x9c79b5ad7b769b12, xeedad81aaed42a76 x789564759d365819, string xb41faee6912a2313, Style xce987d84406b1bfc)
	{
		if (xe134235b3526fa75.x5886c1038090f427 || x9c79b5ad7b769b12.Runs.Count == 0)
		{
			Run run = new Run(xe134235b3526fa75.x2c8c6741422a1298, xb41faee6912a2313, x789564759d365819);
			xf871da68decec406.x7440208dce82f530(run, xce987d84406b1bfc);
			x9c79b5ad7b769b12.Runs.Add(run);
			xe134235b3526fa75.x5886c1038090f427 = false;
		}
		else
		{
			x9c79b5ad7b769b12.Runs[x9c79b5ad7b769b12.Runs.Count - 1].Text = $"{x9c79b5ad7b769b12.Runs[x9c79b5ad7b769b12.Runs.Count - 1].Text}{xb41faee6912a2313}";
		}
	}

	internal static void xc8e7dcf5cb9a777a(xf871da68decec406 xe134235b3526fa75, Paragraph x9c79b5ad7b769b12, x38c672d671ef22c7 x5173842427610357)
	{
		if (xe134235b3526fa75.x331aa0caef1d0657)
		{
			x9c79b5ad7b769b12.x1a78664fa10a3755.xb6157b6da9895c0d(1060, true);
			xe134235b3526fa75.x331aa0caef1d0657 = false;
		}
		xe134235b3526fa75.x331aa0caef1d0657 = x5173842427610357?.x331aa0caef1d0657 ?? false;
		if (x5173842427610357 == null)
		{
			return;
		}
		if (x9c79b5ad7b769b12.Runs.Count > 0)
		{
			if (x5173842427610357.x182d2ff0a0cf9645)
			{
				x9c79b5ad7b769b12.x38453dde2dc1ee92.Text = $"{ControlChar.ColumnBreak}{x9c79b5ad7b769b12.x38453dde2dc1ee92.Text}";
			}
			if (x5173842427610357.x32214f13df983792)
			{
				x9c79b5ad7b769b12.Runs[x9c79b5ad7b769b12.Runs.Count - 1].Text = $"{x9c79b5ad7b769b12.Runs[x9c79b5ad7b769b12.Runs.Count - 1].Text}{ControlChar.ColumnBreak}";
			}
		}
		else if (x5173842427610357.x182d2ff0a0cf9645 || x5173842427610357.x32214f13df983792)
		{
			x9c79b5ad7b769b12.Runs.Add(new Run(xe134235b3526fa75.x2c8c6741422a1298, ControlChar.ColumnBreak));
		}
	}

	private static ArrayList x8dd551a172714f33(string xb41faee6912a2313)
	{
		char[] separator = new char[2] { '\r', '\n' };
		string[] array = xb41faee6912a2313.Split(separator);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < array.Length; i++)
		{
			if (x0d299f323d241756.x5959bccb67bbf051(array[i]))
			{
				arrayList.Add(array[i]);
			}
		}
		return arrayList;
	}

	private static void x0c14b069e863a154(xf871da68decec406 xe134235b3526fa75, Paragraph x9c79b5ad7b769b12, xeedad81aaed42a76 x789564759d365819, Style xce987d84406b1bfc)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		string text = ControlChar.x3e1feffd8ca6feb2;
		while (xca994afbcb9073a.x1ac1960adc8c4c39())
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = xca994afbcb9073a.xa66385d80d4d296f) != null && xa66385d80d4d296f == "c")
			{
				text = new string(' ', xca994afbcb9073a.xbba6773b8ce56a01);
			}
		}
		if (x0d299f323d241756.x5959bccb67bbf051(xf871da68decec406.x3da162cd5d0dd2a4))
		{
			text = $" {text}";
			xf871da68decec406.x3da162cd5d0dd2a4 = "";
		}
		x2037c969f8f81f97(xe134235b3526fa75, x9c79b5ad7b769b12, x789564759d365819, text, xce987d84406b1bfc);
	}

	private static void x7f3c983d2f4af32f(xf871da68decec406 xe134235b3526fa75, Paragraph x9c79b5ad7b769b12, xeedad81aaed42a76 x789564759d365819, Style xce987d84406b1bfc)
	{
		string text = ControlChar.Tab;
		if (x0d299f323d241756.x5959bccb67bbf051(xf871da68decec406.x3da162cd5d0dd2a4))
		{
			text = $" {text}";
			xf871da68decec406.x3da162cd5d0dd2a4 = "";
		}
		x2037c969f8f81f97(xe134235b3526fa75, x9c79b5ad7b769b12, x789564759d365819, text, xce987d84406b1bfc);
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		string xa66385d80d4d296f;
		while (xca994afbcb9073a.x1ac1960adc8c4c39() && ((xa66385d80d4d296f = xca994afbcb9073a.xa66385d80d4d296f) == null || !(xa66385d80d4d296f == "text:tab-ref")))
		{
		}
	}

	private static void xc9bcf48b160797e1(xf871da68decec406 xe134235b3526fa75, Paragraph x9c79b5ad7b769b12, x38c672d671ef22c7 x5173842427610357, CompositeNode xbe8ce7206677d91d)
	{
		string xe5ffcf1e3f9bd = xe134235b3526fa75.xe5ffcf1e3f9bd387;
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		while (xca994afbcb9073a.x1ac1960adc8c4c39())
		{
			xe134235b3526fa75.x81c468031b83f5fc(xca994afbcb9073a);
		}
		x4b7c2f007465fd90(xe134235b3526fa75, x9c79b5ad7b769b12, "span", x5173842427610357, xbe8ce7206677d91d);
		xe134235b3526fa75.xe5ffcf1e3f9bd387 = xe5ffcf1e3f9bd;
	}

	private static void xfc4e6807e4311551(xf871da68decec406 xe134235b3526fa75, Paragraph x9c79b5ad7b769b12, xeedad81aaed42a76 x789564759d365819)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		FootnoteType footnoteType = ((xca994afbcb9073a.xd68abcd61e368af9("note-class", "endnote") == "endnote") ? FootnoteType.Endnote : FootnoteType.Footnote);
		Footnote footnote = new Footnote(xe134235b3526fa75.x2c8c6741422a1298, footnoteType, isAuto: true, null, x789564759d365819);
		x789564759d365819.xab3af626b1405ee8(footnote.xeedad81aaed42a76);
		while (xca994afbcb9073a.x152cbadbfa8061b1("note"))
		{
			switch (xca994afbcb9073a.xa66385d80d4d296f)
			{
			case "note-citation":
			{
				string text = xca994afbcb9073a.xd68abcd61e368af9("label", null);
				if (text != null)
				{
					footnote.xa72bf798a679c0aa = false;
					footnote.x715a8c5c33fdc1a6 = text;
				}
				break;
			}
			case "note-body":
				xe134235b3526fa75.x51811c878dba9ce3 = true;
				x78ad567c64a94dad.x06b0e25aa6ad68a9(xe134235b3526fa75, "note-body", footnote);
				xf871da68decec406.x3da162cd5d0dd2a4 = "";
				xe134235b3526fa75.x51811c878dba9ce3 = false;
				break;
			default:
				xca994afbcb9073a.IgnoreElement();
				break;
			}
		}
		Paragraph firstParagraph = footnote.FirstParagraph;
		if (firstParagraph != null)
		{
			if (footnote.xa72bf798a679c0aa)
			{
				firstParagraph.InsertBefore(new SpecialChar(xe134235b3526fa75.x2c8c6741422a1298, '\u0002', x789564759d365819), firstParagraph.FirstChild);
			}
			else
			{
				firstParagraph.InsertBefore(new Run(xe134235b3526fa75.x2c8c6741422a1298, footnote.x715a8c5c33fdc1a6, x789564759d365819), firstParagraph.FirstChild);
			}
		}
		x9c79b5ad7b769b12.AppendChild(footnote);
	}

	private static void x1fe71dc8b99f97bf(xf871da68decec406 xe134235b3526fa75, Paragraph x9c79b5ad7b769b12, xeedad81aaed42a76 x789564759d365819)
	{
		if (x0d299f323d241756.x5959bccb67bbf051(xf871da68decec406.x3da162cd5d0dd2a4))
		{
			Run run = x9c79b5ad7b769b12.xf562da51e0b3c429();
			if (run != null)
			{
				run.Text = $"{run.Text} ";
			}
			xf871da68decec406.x3da162cd5d0dd2a4 = "";
		}
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		Comment comment = new Comment(xe134235b3526fa75.x2c8c6741422a1298, x789564759d365819);
		while (xca994afbcb9073a.x152cbadbfa8061b1("annotation"))
		{
			switch (xe134235b3526fa75.xca994afbcb9073a2.xa66385d80d4d296f)
			{
			case "creator":
				comment.Author = xca994afbcb9073a.x2a1ea9d24e62bf84();
				if (x0d299f323d241756.x5959bccb67bbf051(comment.Author))
				{
					comment.Initial = comment.Author.Substring(0, 1).ToUpper();
				}
				break;
			case "date":
				comment.DateTime = xca004f56614e2431.x70982613fd6240f9(xca994afbcb9073a.x2a1ea9d24e62bf84());
				break;
			case "p":
				x06b0e25aa6ad68a9(xe134235b3526fa75, xca994afbcb9073a.xa66385d80d4d296f, comment);
				break;
			case "list":
				x51bdb35997d05bcf.x06b0e25aa6ad68a9(xe134235b3526fa75, comment, null);
				break;
			default:
				xe134235b3526fa75.xca994afbcb9073a2.IgnoreElement();
				break;
			}
		}
		x9c79b5ad7b769b12.AppendChild(comment);
	}

	private static string xfb9c631bccfa22d4(xf871da68decec406 xe134235b3526fa75, Paragraph x9c79b5ad7b769b12, string xb41faee6912a2313)
	{
		if (xb41faee6912a2313.IndexOf(ControlChar.Cr) < 0 && xb41faee6912a2313.IndexOf(ControlChar.Lf) < 0)
		{
			return xb41faee6912a2313;
		}
		ArrayList arrayList = x8dd551a172714f33(xb41faee6912a2313);
		xb41faee6912a2313 = "";
		for (int i = 0; i < arrayList.Count; i++)
		{
			string text = (string)arrayList[i];
			bool flag = i != 0 && x3c7f98d679952a99((string)arrayList[i - 1]);
			bool flag2 = text.Trim(' ').Length > 0 && ((i == 0 && x9c79b5ad7b769b12.Runs.Count == 0) || flag);
			if (xe134235b3526fa75.x5886c1038090f427)
			{
				text = string.Format("{0}{1}", flag2 ? "" : " ", text.TrimStart(' '));
			}
			xb41faee6912a2313 = $"{xb41faee6912a2313}{text}";
		}
		return xb41faee6912a2313;
	}

	private static void xc3a6fb8513d320a3(xf871da68decec406 xe134235b3526fa75, Paragraph x9c79b5ad7b769b12, xeedad81aaed42a76 x789564759d365819, Style xce987d84406b1bfc)
	{
		string text = xc817aa2e2e5e4667(xe134235b3526fa75, x9c79b5ad7b769b12);
		if (x0d299f323d241756.x5959bccb67bbf051(text))
		{
			x2037c969f8f81f97(xe134235b3526fa75, x9c79b5ad7b769b12, x789564759d365819, text, xce987d84406b1bfc);
		}
	}

	private static string xc817aa2e2e5e4667(xf871da68decec406 xe134235b3526fa75, Paragraph x9c79b5ad7b769b12)
	{
		string xd2f68ee6f47e9dfb = xe134235b3526fa75.xca994afbcb9073a2.xd2f68ee6f47e9dfb;
		xd2f68ee6f47e9dfb = xd2f68ee6f47e9dfb.Replace('\r', ' ');
		xd2f68ee6f47e9dfb = xd2f68ee6f47e9dfb.Replace('\n', ' ');
		xd2f68ee6f47e9dfb = xd2f68ee6f47e9dfb.Replace('\t', ' ');
		xd2f68ee6f47e9dfb = xfb9c631bccfa22d4(xe134235b3526fa75, x9c79b5ad7b769b12, xd2f68ee6f47e9dfb);
		xd2f68ee6f47e9dfb = xd2f68ee6f47e9dfb.Replace('‑', '\u001e');
		xd2f68ee6f47e9dfb = xd2f68ee6f47e9dfb.Replace('\u00ad', '\u001f');
		string text = xd2f68ee6f47e9dfb.Trim(' ');
		bool flag = x9c79b5ad7b769b12.Runs.Count == 0;
		if (!x0d299f323d241756.x5959bccb67bbf051(text))
		{
			if (x0d299f323d241756.x5959bccb67bbf051(xd2f68ee6f47e9dfb) && !flag)
			{
				xf871da68decec406.x3da162cd5d0dd2a4 = " ";
			}
			return null;
		}
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < text.Length; i++)
		{
			if (i == text.Length - 1 || text[i] != ' ' || text[i + 1] != ' ')
			{
				stringBuilder.Append(text[i]);
			}
		}
		if ((x8ff8a42e63391ea9(xd2f68ee6f47e9dfb) || x0d299f323d241756.x5959bccb67bbf051(xf871da68decec406.x3da162cd5d0dd2a4)) && !flag)
		{
			stringBuilder.Insert(0, ' ');
		}
		xf871da68decec406.x3da162cd5d0dd2a4 = x02445f0e8c1a9314(xd2f68ee6f47e9dfb);
		return stringBuilder.ToString();
	}

	private static string x02445f0e8c1a9314(string xb41faee6912a2313)
	{
		int length = xb41faee6912a2313.TrimEnd(' ').Length;
		return new string(' ', xb41faee6912a2313.Length - length);
	}

	private static bool x8ff8a42e63391ea9(string xb41faee6912a2313)
	{
		if (x0d299f323d241756.x5959bccb67bbf051(xb41faee6912a2313))
		{
			return xb41faee6912a2313[0] == ' ';
		}
		return false;
	}

	private static bool x3c7f98d679952a99(string xb41faee6912a2313)
	{
		if (x0d299f323d241756.x5959bccb67bbf051(xb41faee6912a2313))
		{
			return xb41faee6912a2313[xb41faee6912a2313.Length - 1] == ' ';
		}
		return false;
	}
}
