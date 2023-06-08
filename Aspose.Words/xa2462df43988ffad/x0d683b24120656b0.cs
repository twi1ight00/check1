using System.Collections;
using Aspose.Words;
using Aspose.Words.Lists;
using Aspose.Words.Settings;
using x28925c9b27b37a46;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;
using xbe73d5820f7f4ae3;
using xf9a9481c3f63a419;

namespace xa2462df43988ffad;

internal class x0d683b24120656b0
{
	internal const double x8d4182ba05edc0cf = 1.499;

	internal const double x9098cf75e3dfd859 = 3.0;

	private const double x95d3b612bd4194a0 = 2.0;

	private const double x3eed210bd89f8a8f = 2.0;

	private readonly x9c77c7e782b62883 x800085dd555f7711;

	private readonly xdb0bf9f81de4b38c x9b287b671d592594;

	private readonly x88c62cf8fe0ab427 x26e8f4c9d5e1872f;

	private readonly xc3c9a857aa7f07ee xb40af1dcb7c844eb;

	private readonly x76b14a346ff269e6 x36b22abff3afc8ef;

	private readonly x560f0e9efcf5b9b1 x6962cbeae4129aa3;

	private readonly Hashtable x40e8e6689fbdf4b4;

	internal x0d683b24120656b0(xdb0bf9f81de4b38c writer)
	{
		x40e8e6689fbdf4b4 = new Hashtable();
		x9b287b671d592594 = writer;
		x800085dd555f7711 = writer.x082c3925d43afdad("/styles.xml");
		x26e8f4c9d5e1872f = new x88c62cf8fe0ab427(x9b287b671d592594);
		xb40af1dcb7c844eb = new xc3c9a857aa7f07ee(x9b287b671d592594);
		x36b22abff3afc8ef = new x76b14a346ff269e6(x9b287b671d592594);
		x6962cbeae4129aa3 = new x560f0e9efcf5b9b1(x9b287b671d592594);
	}

	internal void x6210059f049f0d48()
	{
		x800085dd555f7711.xa4f71b437449ecdc();
		x26e8f4c9d5e1872f.x6210059f049f0d48();
		x6f126bc7f29ba4bf();
		x906270ea7656caa7();
		xa4356a1ff8715748();
		x800085dd555f7711.xa0dfc102c691b11f();
	}

	private void x6f126bc7f29ba4bf()
	{
		x9b287b671d592594.x05ee8ce4d7312eb5 = x14bf6f47128e4438.x3231bc142724c8b3;
		x40e8e6689fbdf4b4.Clear();
		for (Section section = (Section)x9b287b671d592594.x2c8c6741422a1298.FirstChild; section != null; section = (Section)section.NextSibling)
		{
			xaa925c370fe2a33b(section);
		}
		x9b287b671d592594.x05ee8ce4d7312eb5 = x14bf6f47128e4438.xc1cb551a56877efb;
		x800085dd555f7711.x2307058321cdb62f("office:styles");
		x296226133d4a8057();
		xd8160a007205efc0();
		xf8ee33153b7f3c7a();
		x11a865e3671ff053();
		x4b1c1194fb124396();
		xed9b2b906d237d96();
		x2f971fb9b0e60473();
		x80feb21379133d57();
		x800085dd555f7711.x2dfde153f4ef96d0("office:styles");
	}

	private void x80feb21379133d57()
	{
		xfc72d4c9b765cad7 xfc72d4c9b765cad = x9b287b671d592594.x2c8c6741422a1298.FirstSection.xfc72d4c9b765cad7;
		if (xfc72d4c9b765cad.xf7866f89640a29a3(2120) != null)
		{
			x800085dd555f7711.x2307058321cdb62f("text:linenumbering-configuration");
			x800085dd555f7711.x943f6be3acf634db("text:number-lines", "true");
			x800085dd555f7711.x943f6be3acf634db("text:increment", xfc72d4c9b765cad.x33683704df16e3dc);
			x800085dd555f7711.x943f6be3acf634db("text:offset", xbb857c9fc36f5054.xf7c347cb12d2a63f(xfc72d4c9b765cad.xeae841520367cd95));
			if (xfc72d4c9b765cad.xf7866f89640a29a3(2180) != null || xfc72d4c9b765cad.xf7866f89640a29a3(2110) != null)
			{
				x800085dd555f7711.x943f6be3acf634db("text:restart-on-page", "true");
			}
			x800085dd555f7711.x2dfde153f4ef96d0("text:linenumbering-configuration");
		}
	}

	private void xd8160a007205efc0()
	{
		for (int i = 0; i < x9b287b671d592594.xa74e18b54d0273fb.xcf2fd36bc07b78ec; i++)
		{
			xf2c5ad4b4d2975c8 xf2c5ad4b4d2975c = (xf2c5ad4b4d2975c8)x9b287b671d592594.xa74e18b54d0273fb.xe12908afde76bfa4(i);
			x800085dd555f7711.x2307058321cdb62f("draw:stroke-dash");
			x800085dd555f7711.x943f6be3acf634db("draw:name", xf2c5ad4b4d2975c.x759aa16c2016a289);
			x800085dd555f7711.x943f6be3acf634db("draw:display-name", xf2c5ad4b4d2975c.xba89ca2127612c56);
			x800085dd555f7711.x943f6be3acf634db("draw:style", xf2c5ad4b4d2975c.xfe2178c1f916f36c);
			x800085dd555f7711.x943f6be3acf634db("draw:dots1", xf2c5ad4b4d2975c.xa307ed3e7b388bae);
			x60bcadad746390d1("draw:dots1-length", xf2c5ad4b4d2975c.x9303663085079165);
			x800085dd555f7711.x943f6be3acf634db("draw:dots2", xf2c5ad4b4d2975c.xa022bd8ca9b57d09);
			x60bcadad746390d1("draw:dots2-length", xf2c5ad4b4d2975c.xe92560c39205e82d);
			x60bcadad746390d1("draw:distance", xf2c5ad4b4d2975c.x58316dde3396e982);
			x800085dd555f7711.x2dfde153f4ef96d0("draw:stroke-dash");
		}
	}

	private void x60bcadad746390d1(string xb591dc602a67d872, string x14ce39bb4fe9496c)
	{
		if (x9b287b671d592594.xf57de0fd37d5e97d.IsStrictSchema11 && x0d299f323d241756.x5959bccb67bbf051(x14ce39bb4fe9496c) && x14ce39bb4fe9496c.EndsWith("%"))
		{
			x800085dd555f7711.x943f6be3acf634db(xb591dc602a67d872, string.Format("{0}cm", xca004f56614e2431.xcaaeec2e96b2cecc(xca004f56614e2431.xec25d08a2af152f0(x14ce39bb4fe9496c.Replace("%", "")) / 10000.0)));
		}
		else
		{
			x800085dd555f7711.x943f6be3acf634db(xb591dc602a67d872, x14ce39bb4fe9496c);
		}
	}

	private void xf8ee33153b7f3c7a()
	{
		for (int i = 0; i < x9b287b671d592594.x9de31f20dd54f2d6.xcf2fd36bc07b78ec; i++)
		{
			x425eec8888f9cefa x425eec8888f9cefa = (x425eec8888f9cefa)x9b287b671d592594.x9de31f20dd54f2d6.xe12908afde76bfa4(i);
			x800085dd555f7711.xc049ea80ee267201("draw:gradient", "draw:name", x425eec8888f9cefa.x759aa16c2016a289, "draw:display-name", x425eec8888f9cefa.xba89ca2127612c56, "draw:style", x425eec8888f9cefa.xfe2178c1f916f36c, "draw:cx", x425eec8888f9cefa.xb5e5bf124e3ded2d, "draw:cy", x425eec8888f9cefa.x9af8f492114408ed, "draw:angle", x425eec8888f9cefa.x6b1fe03343d9a6a4, "draw:border", x425eec8888f9cefa.x51d60f077c5fc6e0, "draw:start-color", x425eec8888f9cefa.x7d2dc175c2f289c5, "draw:end-color", x425eec8888f9cefa.xf3874816968aabd7, "draw:start-intensity", x425eec8888f9cefa.x869fb763fab11919, "draw:end-intensity", x425eec8888f9cefa.xfaf5ba04f7a15657);
		}
	}

	private void x296226133d4a8057()
	{
		for (int i = 0; i < x9b287b671d592594.xe80a456c411edf35.xcf2fd36bc07b78ec; i++)
		{
			xcb29cf976b7ec398 xcb29cf976b7ec = (xcb29cf976b7ec398)x9b287b671d592594.xe80a456c411edf35.xe12908afde76bfa4(i);
			x800085dd555f7711.xc049ea80ee267201("draw:marker", "draw:name", xcb29cf976b7ec.x759aa16c2016a289, "draw:display-name", xcb29cf976b7ec.xba89ca2127612c56, "svg:viewBox", xcb29cf976b7ec.x8251b2a60565655e, "svg:d", xcb29cf976b7ec.x5d593cee9d844848);
		}
	}

	private void x2f971fb9b0e60473()
	{
		x58969c6915103c17(x26f77e2004716cc6: false);
		x58969c6915103c17(x26f77e2004716cc6: true);
	}

	private void x58969c6915103c17(bool x26f77e2004716cc6)
	{
		FootnoteOptions footnoteOptions = (x26f77e2004716cc6 ? x9b287b671d592594.x2c8c6741422a1298.EndnoteOptions : x9b287b671d592594.x2c8c6741422a1298.FootnoteOptions);
		x800085dd555f7711.x2307058321cdb62f("text:notes-configuration");
		x800085dd555f7711.x943f6be3acf634db("text:note-class", x26f77e2004716cc6 ? "endnote" : "footnote");
		x800085dd555f7711.x943f6be3acf634db("style:num-format", x0eb9a864413f34de.xbc2e1c29972a40ee(footnoteOptions.NumberStyle));
		if (footnoteOptions.StartNumber > 0)
		{
			x800085dd555f7711.x943f6be3acf634db("text:start-value", (footnoteOptions.StartNumber - 1).ToString());
		}
		x800085dd555f7711.x943f6be3acf634db("text:footnotes-position", x0eb9a864413f34de.x7ad4832bddeecba4(footnoteOptions.Location));
		x800085dd555f7711.x943f6be3acf634db("text:start-numbering-at", x0eb9a864413f34de.x718695a87d5257db(footnoteOptions.RestartRule));
		x5343269d79a88a86("text:citation-style-name", x26f77e2004716cc6 ? StyleIdentifier.EndnoteReference : StyleIdentifier.FootnoteReference);
		x5343269d79a88a86("text:citation-body-style-name", x26f77e2004716cc6 ? StyleIdentifier.EndnoteText : StyleIdentifier.FootnoteText);
		x800085dd555f7711.x2dfde153f4ef96d0("text:notes-configuration");
	}

	private void x5343269d79a88a86(string xb591dc602a67d872, StyleIdentifier x1efa8f9b84a88d30)
	{
		if (x9b287b671d592594.x2c8c6741422a1298.Styles.x263d579af1d0d43f(x1efa8f9b84a88d30))
		{
			x800085dd555f7711.x943f6be3acf634db(xb591dc602a67d872, x0eb9a864413f34de.xb19294b14e3c8598(x9b287b671d592594.x2c8c6741422a1298.Styles[x1efa8f9b84a88d30]));
		}
	}

	private void xed9b2b906d237d96()
	{
		foreach (List list in x9b287b671d592594.x2c8c6741422a1298.Lists)
		{
			x30f831271b1c1630(list);
			x10a2aae8c7fd0156(list);
		}
	}

	private void x30f831271b1c1630(List x8a0b266419f09a55)
	{
		for (int i = 0; i < 9; i++)
		{
			ListLevel listLevel = x8a0b266419f09a55.x1fc16b41653eb571(i);
			if (listLevel.xeedad81aaed42a76.xd44988f225497f3a > 0 && !listLevel.x44b52529222cea8a)
			{
				x6962cbeae4129aa3.xaedce5725e456ac5(listLevel, x8a0b266419f09a55, $"List{x8a0b266419f09a55.ListId}Level{i}");
			}
		}
	}

	private void x10a2aae8c7fd0156(List x8a0b266419f09a55)
	{
		x800085dd555f7711.x2307058321cdb62f("text:list-style");
		x800085dd555f7711.xa10744432d06325a($"LS{x8a0b266419f09a55.ListId}");
		xc0710d4700d900bc(x8a0b266419f09a55);
		x800085dd555f7711.x2dfde153f4ef96d0("text:list-style");
	}

	private void xc0710d4700d900bc(List x8a0b266419f09a55)
	{
		for (int i = 0; i < 9; i++)
		{
			x6403e2e269084313(x8a0b266419f09a55.x1fc16b41653eb571(i), x8a0b266419f09a55.ListId, i);
		}
	}

	private void x6403e2e269084313(ListLevel x66bbd7ed8c65740d, int x43eb71c4e55e38d0, int xb53acfe332ad6e91)
	{
		string x121383aa;
		if (x66bbd7ed8c65740d.x44b52529222cea8a)
		{
			x121383aa = "text:list-level-style-image";
			x800085dd555f7711.x2307058321cdb62f(x121383aa);
			xe4424b4bab7902c7 xe4424b4bab7902c8 = new xe4424b4bab7902c7(x9b287b671d592594);
			xe4424b4bab7902c8.x56c6b9360de4fb23(x121383aa, x66bbd7ed8c65740d.xc9c754014952f758);
		}
		else
		{
			if (x66bbd7ed8c65740d.NumberStyle == NumberStyle.Bullet)
			{
				x121383aa = "text:list-level-style-bullet";
				string text = x800085dd555f7711.x80134a53bcbb9665(x66bbd7ed8c65740d.NumberFormat);
				x800085dd555f7711.x2307058321cdb62f(x121383aa);
				x800085dd555f7711.x943f6be3acf634db("text:bullet-char", x0d299f323d241756.x5959bccb67bbf051(text) ? text.Substring(0, 1) : " ");
			}
			else
			{
				x121383aa = "text:list-level-style-number";
				x800085dd555f7711.x2307058321cdb62f(x121383aa);
				x800085dd555f7711.x943f6be3acf634db("style:num-format", x0eb9a864413f34de.xbc2e1c29972a40ee(x66bbd7ed8c65740d.NumberStyle));
				x800085dd555f7711.x943f6be3acf634db("text:display-levels", x0eb9a864413f34de.xb7771d27b3454277(x66bbd7ed8c65740d.NumberFormat, xb53acfe332ad6e91));
				if (x66bbd7ed8c65740d.StartAt > 1)
				{
					x800085dd555f7711.x943f6be3acf634db("text:start-value", x66bbd7ed8c65740d.StartAt.ToString());
				}
			}
			x800085dd555f7711.x943f6be3acf634db("text:style-name", $"List{x43eb71c4e55e38d0}Level{xb53acfe332ad6e91}");
			x800085dd555f7711.x943f6be3acf634db("style:num-suffix", x0eb9a864413f34de.x69cc6ab89d735dcd(x66bbd7ed8c65740d.NumberFormat, xb53acfe332ad6e91));
			x800085dd555f7711.x943f6be3acf634db("style:num-prefix", x0eb9a864413f34de.x7df5568a93d9f858(x66bbd7ed8c65740d.NumberFormat, xb53acfe332ad6e91));
		}
		x800085dd555f7711.x943f6be3acf634db("text:level", xb53acfe332ad6e91 + 1);
		bool flag = xb40af1dcb7c844eb.x1dc6435a987402fa(null, x66bbd7ed8c65740d.xeedad81aaed42a76);
		if (x66bbd7ed8c65740d.TextPosition != 0.0 || x66bbd7ed8c65740d.NumberPosition != 0.0 || x66bbd7ed8c65740d.Alignment != 0 || x66bbd7ed8c65740d.x44b52529222cea8a)
		{
			x8c6a0099957b3045(x66bbd7ed8c65740d);
		}
		if (flag && !x66bbd7ed8c65740d.x44b52529222cea8a)
		{
			xb40af1dcb7c844eb.xa07be38424ba1ddf(xaab0c5f1acc303e5: false);
		}
		x800085dd555f7711.x2dfde153f4ef96d0(x121383aa);
	}

	private void x8c6a0099957b3045(ListLevel x66bbd7ed8c65740d)
	{
		x800085dd555f7711.x2307058321cdb62f("style:list-level-properties");
		if (x66bbd7ed8c65740d.Alignment == ListLevelAlignment.Right)
		{
			x800085dd555f7711.x943f6be3acf634db("text:min-label-width", xbb857c9fc36f5054.x96d7e563211411f6(x66bbd7ed8c65740d.TextPosition));
			x800085dd555f7711.x943f6be3acf634db("text:min-label-distance", xbb857c9fc36f5054.x96d7e563211411f6(x66bbd7ed8c65740d.TextPosition - x66bbd7ed8c65740d.NumberPosition));
		}
		else
		{
			x800085dd555f7711.x943f6be3acf634db("text:space-before", xbb857c9fc36f5054.x96d7e563211411f6(x66bbd7ed8c65740d.NumberPosition));
			x800085dd555f7711.x943f6be3acf634db("text:min-label-width", xbb857c9fc36f5054.x96d7e563211411f6(x66bbd7ed8c65740d.TextPosition - x66bbd7ed8c65740d.NumberPosition));
		}
		x800085dd555f7711.x943f6be3acf634db("fo:text-align", x0eb9a864413f34de.x3b70322bc9053ed5(x66bbd7ed8c65740d.Alignment));
		x7484aa150e70c474(x66bbd7ed8c65740d);
		x800085dd555f7711.x2dfde153f4ef96d0("style:list-level-properties");
	}

	private void x7484aa150e70c474(ListLevel x66bbd7ed8c65740d)
	{
		if (x66bbd7ed8c65740d.x44b52529222cea8a)
		{
			double num = x4574ea26106f0edb.x4610495f80b4c267(x66bbd7ed8c65740d.xeedad81aaed42a76.x437e3b626c0fdd43);
			double num2 = x66bbd7ed8c65740d.xc9c754014952f758.SizeInPoints.Height;
			double num3 = x66bbd7ed8c65740d.xc9c754014952f758.SizeInPoints.Width;
			if (num < num2)
			{
				num3 *= num / num2;
				num2 = num;
			}
			x800085dd555f7711.x943f6be3acf634db("fo:width", xbb857c9fc36f5054.x96d7e563211411f6(num3));
			x800085dd555f7711.x943f6be3acf634db("fo:height", xbb857c9fc36f5054.x96d7e563211411f6(num2));
		}
	}

	private void x11a865e3671ff053()
	{
		x4f9ac837d7a753f3();
		x1a0b2adc4d860ecc();
		x58edb0adb62a37d1();
	}

	private void x4f9ac837d7a753f3()
	{
		x6962cbeae4129aa3.xdca0be0024cc142b("paragraph");
		x36b22abff3afc8ef.x6210059f049f0d48(x9b287b671d592594.x2c8c6741422a1298.Styles[StyleIdentifier.Normal], x9b287b671d592594.x2c8c6741422a1298.Styles.xf4eb04b8b9073eeb, xaab0c5f1acc303e5: true);
		xb40af1dcb7c844eb.x6210059f049f0d48(x9b287b671d592594.x2c8c6741422a1298.Styles[StyleIdentifier.Normal], x9b287b671d592594.x2c8c6741422a1298.Styles.x27096df7ca0cfe2e, xaab0c5f1acc303e5: true);
		x800085dd555f7711.x2dfde153f4ef96d0("style:default-style");
	}

	private static void x58edb0adb62a37d1()
	{
	}

	private void x1a0b2adc4d860ecc()
	{
		x6962cbeae4129aa3.xdca0be0024cc142b("table");
		x800085dd555f7711.xc049ea80ee267201("style:table-properties", "table:border-model", "collapsing");
		x800085dd555f7711.x2dfde153f4ef96d0("style:default-style");
	}

	private void x4b1c1194fb124396()
	{
		StyleCollection styles = x9b287b671d592594.x2c8c6741422a1298.Styles;
		for (int i = 0; i < styles.Count; i++)
		{
			x6962cbeae4129aa3.xaedce5725e456ac5(styles[i]);
		}
	}

	private void x906270ea7656caa7()
	{
		x9b287b671d592594.x05ee8ce4d7312eb5 = x14bf6f47128e4438.x05a725d9893e5a35;
		x9b287b671d592594.x553875efa602203e();
		x40e8e6689fbdf4b4.Clear();
		x800085dd555f7711.x2307058321cdb62f("office:automatic-styles");
		for (Section section = (Section)x9b287b671d592594.x2c8c6741422a1298.FirstChild; section != null; section = (Section)section.NextSibling)
		{
			if (section.PageSetup.SectionStart == SectionStart.NewPage || section.x65c77554c620f590)
			{
				x1cc792fb3567e2a0(section);
				xaa925c370fe2a33b(section);
			}
		}
		x800085dd555f7711.x2dfde153f4ef96d0("office:automatic-styles");
		x9b287b671d592594.x553875efa602203e();
	}

	private void xaa925c370fe2a33b(Section xb32f8dd719a105db)
	{
		if (xb32f8dd719a105db.PageSetup.DifferentFirstPageHeaderFooter)
		{
			xaa925c370fe2a33b(xb32f8dd719a105db, x2b4c81c9b87ffafc: false);
		}
		xaa925c370fe2a33b(xb32f8dd719a105db, x2b4c81c9b87ffafc: true);
	}

	private void x1cc792fb3567e2a0(Section xb32f8dd719a105db)
	{
		x800085dd555f7711.x2307058321cdb62f("style:page-layout");
		x800085dd555f7711.x943f6be3acf634db("style:name", xa9ec6c64c1fcfe3a(xb32f8dd719a105db));
		xf095bd20ab541310(xb32f8dd719a105db);
		if (xbfa03c1f542da4fb(xb32f8dd719a105db, HeaderFooterType.HeaderPrimary) != null)
		{
			xa7f265f74222ca95(xb32f8dd719a105db, x59c6d00e0898f6b8: true);
		}
		if (xbfa03c1f542da4fb(xb32f8dd719a105db, HeaderFooterType.FooterPrimary) != null)
		{
			xa7f265f74222ca95(xb32f8dd719a105db, x59c6d00e0898f6b8: false);
		}
		x800085dd555f7711.x2dfde153f4ef96d0("style:page-layout");
	}

	private void xe93044347b2e7142(Section xb32f8dd719a105db, string x2e150ee07990e32a)
	{
		if (xb32f8dd719a105db.PageSetup.SectionStart == SectionStart.NewPage || xb32f8dd719a105db.x65c77554c620f590)
		{
			x9b287b671d592594.x05ee8ce4d7312eb5 = x14bf6f47128e4438.x62af77d3c3af0871;
			bool differentFirstPageHeaderFooter = xb32f8dd719a105db.PageSetup.DifferentFirstPageHeaderFooter;
			string text = ((x2e150ee07990e32a == null) ? x560f0e9efcf5b9b1.x2b7914478090f4f7(x9b287b671d592594, xb32f8dd719a105db) : x2e150ee07990e32a);
			string text2 = $"MasterPageNext{x9b287b671d592594.x2c8c6741422a1298.Sections.IndexOf(xb32f8dd719a105db)}";
			if (differentFirstPageHeaderFooter)
			{
				xe93044347b2e7142(xb32f8dd719a105db, text, text2, x2b4c81c9b87ffafc: false);
			}
			xe93044347b2e7142(xb32f8dd719a105db, differentFirstPageHeaderFooter ? text2 : text, null, x2b4c81c9b87ffafc: true);
		}
	}

	private void xe93044347b2e7142(Section xb32f8dd719a105db, string x2e150ee07990e32a, string x91240666e1dfdbcc, bool x2b4c81c9b87ffafc)
	{
		x800085dd555f7711.x2307058321cdb62f("style:master-page");
		x800085dd555f7711.xa10744432d06325a(x2e150ee07990e32a);
		x800085dd555f7711.x943f6be3acf634db("style:page-layout-name", xa9ec6c64c1fcfe3a(xb32f8dd719a105db));
		x800085dd555f7711.x943f6be3acf634db("style:next-style-name", x91240666e1dfdbcc);
		if (x2e150ee07990e32a != "Endnote")
		{
			xaa925c370fe2a33b(xb32f8dd719a105db, x2b4c81c9b87ffafc);
		}
		x800085dd555f7711.x2dfde153f4ef96d0("style:master-page");
	}

	private void xa7f265f74222ca95(Section xb32f8dd719a105db, bool x59c6d00e0898f6b8)
	{
		string x121383aa = (x59c6d00e0898f6b8 ? "style:header-style" : "style:footer-style");
		x800085dd555f7711.x2307058321cdb62f(x121383aa);
		x800085dd555f7711.x2307058321cdb62f("style:header-footer-properties");
		if (x59c6d00e0898f6b8)
		{
			string xbcea506a33cf = xbb857c9fc36f5054.xf7c347cb12d2a63f(xb32f8dd719a105db.xfc72d4c9b765cad7.xc07fe3840d9e6d76 - xb32f8dd719a105db.xfc72d4c9b765cad7.x2cdd18500759ef24);
			x800085dd555f7711.x943f6be3acf634db("fo:min-height", xbcea506a33cf);
			x800085dd555f7711.x943f6be3acf634db("fo:margin-bottom", xbcea506a33cf);
		}
		else
		{
			string xbcea506a33cf2 = xbb857c9fc36f5054.xf7c347cb12d2a63f(xb32f8dd719a105db.xfc72d4c9b765cad7.x65011a5ae8c64a43 - xb32f8dd719a105db.xfc72d4c9b765cad7.x9c94a32b8fac5210);
			x800085dd555f7711.x943f6be3acf634db("fo:min-height", xbcea506a33cf2);
			x800085dd555f7711.x943f6be3acf634db("fo:margin-top", xbcea506a33cf2);
		}
		x800085dd555f7711.x943f6be3acf634db("style:dynamic-spacing", "true");
		x800085dd555f7711.x2dfde153f4ef96d0("style:header-footer-properties");
		x800085dd555f7711.x2dfde153f4ef96d0(x121383aa);
	}

	private void xa4356a1ff8715748()
	{
		x800085dd555f7711.x2307058321cdb62f("office:master-styles");
		x40e8e6689fbdf4b4.Clear();
		for (Section section = (Section)x9b287b671d592594.x2c8c6741422a1298.FirstChild; section != null; section = (Section)section.NextSibling)
		{
			xe93044347b2e7142(section);
		}
		if (x9b287b671d592594.xcfbb77d2d3868462)
		{
			xe93044347b2e7142(x9b287b671d592594.x2c8c6741422a1298.LastSection, "Endnote");
		}
		x800085dd555f7711.x2dfde153f4ef96d0("office:master-styles");
	}

	private void xe93044347b2e7142(Section xb32f8dd719a105db)
	{
		xe93044347b2e7142(xb32f8dd719a105db, null);
	}

	private void xaa925c370fe2a33b(Section xb32f8dd719a105db, bool x2b4c81c9b87ffafc)
	{
		x6075c9125351e131(xb32f8dd719a105db, x2b4c81c9b87ffafc ? HeaderFooterType.HeaderPrimary : HeaderFooterType.HeaderFirst);
		x6075c9125351e131(xb32f8dd719a105db, x2b4c81c9b87ffafc ? HeaderFooterType.FooterPrimary : HeaderFooterType.FooterFirst);
		if (xb32f8dd719a105db.PageSetup.OddAndEvenPagesHeaderFooter)
		{
			x6075c9125351e131(xb32f8dd719a105db, HeaderFooterType.HeaderEven);
			x6075c9125351e131(xb32f8dd719a105db, HeaderFooterType.FooterEven);
		}
	}

	private void x6075c9125351e131(Section xb32f8dd719a105db, HeaderFooterType xa685fef1a31f5d4d)
	{
		xbfa03c1f542da4fb(xb32f8dd719a105db, xa685fef1a31f5d4d)?.Accept(x9b287b671d592594);
	}

	private HeaderFooter xbfa03c1f542da4fb(Section xb32f8dd719a105db, HeaderFooterType xa685fef1a31f5d4d)
	{
		HeaderFooter headerFooter = xb32f8dd719a105db.HeadersFooters[xa685fef1a31f5d4d];
		if (headerFooter != null && headerFooter.HasChildNodes)
		{
			x40e8e6689fbdf4b4[headerFooter.HeaderFooterType] = headerFooter;
		}
		else
		{
			headerFooter = (HeaderFooter)x40e8e6689fbdf4b4[xa685fef1a31f5d4d];
		}
		return headerFooter;
	}

	private string xa9ec6c64c1fcfe3a(Section xb32f8dd719a105db)
	{
		return $"pm{x9b287b671d592594.x2c8c6741422a1298.Sections.IndexOf(xb32f8dd719a105db) + 1}";
	}

	private void xf095bd20ab541310(Section xb32f8dd719a105db)
	{
		x800085dd555f7711.x2307058321cdb62f("style:page-layout-properties");
		x638843d10ce471ae(xb32f8dd719a105db);
		x962ccb54f78556e9 x962ccb54f78556e10 = new x962ccb54f78556e9(x9b287b671d592594);
		xfb6a9597c6d089e0 xfb6a9597c6d089e = x962ccb54f78556e10.x8f04d6bdc85b09f3(xb32f8dd719a105db, xb32f8dd719a105db.xfc72d4c9b765cad7);
		Document document = xb32f8dd719a105db.x357c90b33d6bb8e6();
		if (xfb6a9597c6d089e.x5840ec53f70adb17 > 0 && document.Sections.Count == 1 && !document.xdade2366eaa6f915.xe322902ca0e695f5.NoColumnBalance)
		{
			x962ccb54f78556e10.xee68c4a2afc4e5c1();
		}
		if (x9b287b671d592594.x2c8c6741422a1298.BackgroundShape != null && x9b287b671d592594.x2c8c6741422a1298.ViewOptions.DisplayBackgroundShape)
		{
			xe4424b4bab7902c7 xe4424b4bab7902c8 = new xe4424b4bab7902c7(x9b287b671d592594);
			xe4424b4bab7902c8.x56c6b9360de4fb23("style:background-image", x9b287b671d592594.x2c8c6741422a1298.BackgroundShape);
		}
		x800085dd555f7711.x2dfde153f4ef96d0("style:page-layout-properties");
	}

	private void x638843d10ce471ae(Section xb32f8dd719a105db)
	{
		x3e9c9415336ee7c5 x3e9c9415336ee7c6 = x5f225df307b5f37e(xb32f8dd719a105db);
		x800085dd555f7711.x943f6be3acf634db("style:print-orientation", x3e9c9415336ee7c6.x03d7bcc58f57385f);
		x800085dd555f7711.x943f6be3acf634db("fo:page-width", x3e9c9415336ee7c6.x3114e27f80122981);
		x800085dd555f7711.x943f6be3acf634db("fo:page-height", x3e9c9415336ee7c6.x995a78d99ada0d0c);
		x800085dd555f7711.x943f6be3acf634db("style:writing-mode", x3e9c9415336ee7c6.x28e5011224ac892b);
		x800085dd555f7711.x943f6be3acf634db("style:num-format", x3e9c9415336ee7c6.x648708fcd8a1a0b7);
		if (!x9b287b671d592594.x2c8c6741422a1298.PageColor.IsEmpty && (x9b287b671d592594.x2c8c6741422a1298.ViewOptions.DisplayBackgroundShape || x9b287b671d592594.x2c8c6741422a1298.ViewOptions.ViewType == ViewType.Web))
		{
			x800085dd555f7711.x943f6be3acf634db("fo:background-color", xbb857c9fc36f5054.x5de8b3baf75f4df6(new x26d9ecb4bdf0456d(x9b287b671d592594.x2c8c6741422a1298.PageColor.ToArgb())));
		}
		x3e9c9415336ee7c6.x950295903e1e85d3.x6210059f049f0d48(x800085dd555f7711);
	}

	private x3e9c9415336ee7c5 x5f225df307b5f37e(Section xb32f8dd719a105db)
	{
		x7f77ea92be0d9042 x7f77ea92be0d = (x7f77ea92be0d9042)xb32f8dd719a105db.xfc72d4c9b765cad7.x8b61531c8ea35b85();
		x3e9c9415336ee7c5 x3e9c9415336ee7c6 = new x3e9c9415336ee7c5();
		x3e9c9415336ee7c6.x950295903e1e85d3.xd7a21e27974f626c.xdce98c019bd9517d = 1.499;
		x3e9c9415336ee7c6.x950295903e1e85d3.xaea087ab32102492.xdce98c019bd9517d = 3.0;
		x3e9c9415336ee7c6.x950295903e1e85d3.xa8c2637cc4888928.xdce98c019bd9517d = 2.0;
		x3e9c9415336ee7c6.x950295903e1e85d3.x79d902473861f242.xdce98c019bd9517d = 2.0;
		for (int i = 0; i < x7f77ea92be0d.xd44988f225497f3a; i++)
		{
			int num = x7f77ea92be0d.xf15263674eb297bb(i);
			object obj = x7f77ea92be0d.x6d3720b962bd3112(i);
			if (obj == null)
			{
				continue;
			}
			switch (num)
			{
			case 2010:
			{
				NumberStyle numberStyle = (NumberStyle)obj;
				if (numberStyle != 0 && numberStyle != NumberStyle.Number)
				{
					x3e9c9415336ee7c6.x648708fcd8a1a0b7 = x0eb9a864413f34de.xbc2e1c29972a40ee((NumberStyle)obj);
				}
				break;
			}
			case 2440:
				if ((x6d434087bc06a37d)obj == x6d434087bc06a37d.x61c108cc44ef385a)
				{
					x3e9c9415336ee7c6.x28e5011224ac892b = "tb-rl";
				}
				if ((x6d434087bc06a37d)obj == x6d434087bc06a37d.x048554b0a8122c07)
				{
					x3e9c9415336ee7c6.x28e5011224ac892b = "rl-tb";
				}
				break;
			case 2450:
				x3e9c9415336ee7c6.x28e5011224ac892b = (((bool)obj) ? "rl-tb" : "lr-tb");
				break;
			case 2260:
				x3e9c9415336ee7c6.x3114e27f80122981 = xbb857c9fc36f5054.xf7c347cb12d2a63f(obj);
				break;
			case 2270:
				x3e9c9415336ee7c6.x995a78d99ada0d0c = xbb857c9fc36f5054.xf7c347cb12d2a63f(obj);
				break;
			case 2210:
				x3e9c9415336ee7c6.x03d7bcc58f57385f = x0eb9a864413f34de.xf7e611d1d8ca4bb2((Orientation)obj);
				break;
			case 2320:
				x3e9c9415336ee7c6.x950295903e1e85d3.xa8c2637cc4888928.xfe8b2581f8989da7 = xbb857c9fc36f5054.x658344ad68429ed9((int)obj);
				break;
			case 2330:
				x3e9c9415336ee7c6.x950295903e1e85d3.x79d902473861f242.xfe8b2581f8989da7 = xbb857c9fc36f5054.x658344ad68429ed9((int)obj);
				break;
			case 2130:
				x3e9c9415336ee7c6.x950295903e1e85d3.xa8c2637cc4888928.x03cb705fbd5700a4 = (Border)obj;
				break;
			case 2150:
				x3e9c9415336ee7c6.x950295903e1e85d3.x79d902473861f242.x03cb705fbd5700a4 = (Border)obj;
				break;
			case 2140:
				x3e9c9415336ee7c6.x950295903e1e85d3.xaea087ab32102492.x03cb705fbd5700a4 = (Border)obj;
				break;
			case 2160:
				x3e9c9415336ee7c6.x950295903e1e85d3.xd7a21e27974f626c.x03cb705fbd5700a4 = (Border)obj;
				break;
			case 2300:
				x3e9c9415336ee7c6.x950295903e1e85d3.xa8c2637cc4888928.xdce98c019bd9517d = xbb857c9fc36f5054.x658344ad68429ed9((int)obj);
				break;
			case 2310:
				x3e9c9415336ee7c6.x950295903e1e85d3.x79d902473861f242.xdce98c019bd9517d = xbb857c9fc36f5054.x658344ad68429ed9((int)obj);
				break;
			case 2280:
				x3e9c9415336ee7c6.x950295903e1e85d3.xaea087ab32102492.xdce98c019bd9517d = xbb857c9fc36f5054.x658344ad68429ed9((int)obj);
				break;
			case 2290:
				x3e9c9415336ee7c6.x950295903e1e85d3.xd7a21e27974f626c.xdce98c019bd9517d = xbb857c9fc36f5054.x658344ad68429ed9((int)obj);
				break;
			case 2240:
				x3e9c9415336ee7c6.x950295903e1e85d3.x7e7782b21b2e73d0 = (PageBorderDistanceFrom)obj == PageBorderDistanceFrom.PageEdge;
				break;
			}
		}
		x3e9c9415336ee7c6.x950295903e1e85d3.x5f92400e1485c05c(x2b818897b65c872e: true, xa6651a0a6d059494: true);
		if (xbfa03c1f542da4fb(xb32f8dd719a105db, HeaderFooterType.HeaderPrimary) != null && !double.IsNaN(x3e9c9415336ee7c6.x950295903e1e85d3.xa8c2637cc4888928.xfe8b2581f8989da7))
		{
			x3e9c9415336ee7c6.x950295903e1e85d3.xa8c2637cc4888928.x6545d1f2c1b77773 = xbb857c9fc36f5054.x34bdf37bc4f6368b(x3e9c9415336ee7c6.x950295903e1e85d3.xa8c2637cc4888928.xfe8b2581f8989da7);
		}
		if (xbfa03c1f542da4fb(xb32f8dd719a105db, HeaderFooterType.FooterPrimary) != null && !double.IsNaN(x3e9c9415336ee7c6.x950295903e1e85d3.x79d902473861f242.xfe8b2581f8989da7))
		{
			x3e9c9415336ee7c6.x950295903e1e85d3.x79d902473861f242.x6545d1f2c1b77773 = xbb857c9fc36f5054.x34bdf37bc4f6368b(x3e9c9415336ee7c6.x950295903e1e85d3.x79d902473861f242.xfe8b2581f8989da7);
		}
		if (x3e9c9415336ee7c6.x03d7bcc58f57385f == null)
		{
			x3e9c9415336ee7c6.x03d7bcc58f57385f = x0eb9a864413f34de.xf7e611d1d8ca4bb2((Orientation)xfc72d4c9b765cad7.x0095b789d636f3ae(2210));
		}
		return x3e9c9415336ee7c6;
	}
}
