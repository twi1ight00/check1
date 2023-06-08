using System.Text.RegularExpressions;
using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Lists;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using xbe73d5820f7f4ae3;

namespace xa2462df43988ffad;

internal class x560f0e9efcf5b9b1
{
	private const int x653418d025211ba2 = 1;

	private const int xaa67d24a1a9a08f8 = 2;

	private const int xd84c9e906f4cb76c = 3;

	private const int xf59f377bf95b4fcf = 4;

	private const int xb0aedee6c7d96a19 = 5;

	private const int x7b298ef703fd0e66 = 6;

	private const int xe3a213f2f6df335f = 7;

	private const int xaa219b434a2059b9 = 8;

	private const int x1d45d8b4112bfe21 = 9;

	private const int xae225c8cd941cd6f = 10;

	private const int xbfce25d3eddc2556 = 11;

	private const int xd2aa6d454af012d0 = 12;

	private const int x2dc35fb59cf58d16 = 13;

	private const int x85d74fb3569941b2 = 14;

	private const int xea507eacff3777dc = 15;

	private const int xf07f56e8fe5923dd = 16;

	private const int x9173286f5aabb3a3 = 17;

	private const int xe4fc51b4962e2fe2 = 18;

	private const int x4a15258af53e56ac = 19;

	private const int xca10b4200082304f = 20;

	private const int x9c1c389c23de2c41 = 21;

	private readonly xdb0bf9f81de4b38c x9b287b671d592594;

	private readonly xefe741166bf97418 x87311d0449340cb1;

	private readonly x76b14a346ff269e6 x36b22abff3afc8ef;

	private readonly xc3c9a857aa7f07ee xb40af1dcb7c844eb;

	private readonly x962ccb54f78556e9 x047ee985d0cfc992;

	private static readonly Regex x81477698220100d7 = new Regex("(am/pm|AM/PM)|(g|G)|(yyyy|YYYY)|(yy|YY)|(MMMM)|(MMM)|(MM)|(M)|(dddd)|(ddd)|(dd)|(d)|(hh)|(h)|(HH)|(H)|(mm)|(m)|(ss|SS)|(s|S)|([^gGyYMdHhmsSapAP]*)", RegexOptions.Compiled | RegexOptions.Singleline);

	internal x560f0e9efcf5b9b1(xdb0bf9f81de4b38c writer)
	{
		x9b287b671d592594 = writer;
		x87311d0449340cb1 = new xefe741166bf97418(x9b287b671d592594);
		x36b22abff3afc8ef = new x76b14a346ff269e6(x9b287b671d592594);
		xb40af1dcb7c844eb = new xc3c9a857aa7f07ee(x9b287b671d592594);
		x047ee985d0cfc992 = new x962ccb54f78556e9(x9b287b671d592594);
	}

	internal void x6210059f049f0d48()
	{
		x9c77c7e782b62883 xe1410f585439c7d = x9b287b671d592594.xe1410f585439c7d4;
		x9b287b671d592594.x553875efa602203e();
		x9b287b671d592594.x05ee8ce4d7312eb5 = x14bf6f47128e4438.x213a21086ebb469c;
		xe1410f585439c7d.x2307058321cdb62f("office:automatic-styles");
		for (Section section = (Section)x9b287b671d592594.x2c8c6741422a1298.FirstChild; section != null; section = (Section)section.NextSibling)
		{
			x9b287b671d592594.x10d7a1cae426b158 = section;
			x9b287b671d592594.x10d7a1cae426b158.Accept(x9b287b671d592594);
		}
		xe1410f585439c7d.x2dfde153f4ef96d0("office:automatic-styles");
		x9b287b671d592594.x553875efa602203e();
	}

	internal void xaedce5725e456ac5(ShapeBase x8739b0dd3627f37e, bool x637e9fd1a4793118)
	{
		if (x637e9fd1a4793118)
		{
			x7836b37ea6311ff0(xfb973fa049c32c2d(), "text", x891e94d5f7be2eef(x8739b0dd3627f37e));
			xb40af1dcb7c844eb.x6210059f049f0d48(x8739b0dd3627f37e, x8739b0dd3627f37e.xeedad81aaed42a76);
		}
		else
		{
			x7836b37ea6311ff0(x455e44058f4e8da3(), "graphic", x891e94d5f7be2eef(x8739b0dd3627f37e));
			x87311d0449340cb1.x6210059f049f0d48(x8739b0dd3627f37e);
		}
		x9b287b671d592594.xe1410f585439c7d4.x2dfde153f4ef96d0("style:style");
	}

	internal void xaedce5725e456ac5(Inline x31545d7c306a55e4)
	{
		x7836b37ea6311ff0(xfb973fa049c32c2d(), "text", x891e94d5f7be2eef(x31545d7c306a55e4));
		xb40af1dcb7c844eb.x6210059f049f0d48(x31545d7c306a55e4, x31545d7c306a55e4.xeedad81aaed42a76);
		x9b287b671d592594.xe1410f585439c7d4.x2dfde153f4ef96d0("style:style");
	}

	internal void xaedce5725e456ac5(Comment x77c5a31ec0891f38)
	{
		x7836b37ea6311ff0(xfb973fa049c32c2d(), "text", x891e94d5f7be2eef(x77c5a31ec0891f38.ParentParagraph));
		xb40af1dcb7c844eb.x6210059f049f0d48(x77c5a31ec0891f38.ParentParagraph, x77c5a31ec0891f38.xeedad81aaed42a76);
		x9b287b671d592594.xe1410f585439c7d4.x2dfde153f4ef96d0("style:style");
	}

	internal void xaedce5725e456ac5(Footnote x897ec71a9f9588a0)
	{
		x7836b37ea6311ff0(xfb973fa049c32c2d(), "text", x891e94d5f7be2eef(x897ec71a9f9588a0));
		xb40af1dcb7c844eb.x6210059f049f0d48(x897ec71a9f9588a0, x897ec71a9f9588a0.xeedad81aaed42a76);
		x9b287b671d592594.xe1410f585439c7d4.x2dfde153f4ef96d0("style:style");
	}

	internal void xaedce5725e456ac5(Style x44ecfea61c937b8e)
	{
		if (x44ecfea61c937b8e.Type == StyleType.Table)
		{
			return;
		}
		string text = x0eb9a864413f34de.xb19294b14e3c8598(x44ecfea61c937b8e);
		if (x0d299f323d241756.x5959bccb67bbf051(text))
		{
			x7836b37ea6311ff0(text, x0eb9a864413f34de.xd70034c69864bb0b(x44ecfea61c937b8e.Type), x891e94d5f7be2eef(x44ecfea61c937b8e));
			if (x44ecfea61c937b8e.x1a78664fa10a3755.xdd05b9fa0fd72684 != OutlineLevel.BodyText)
			{
				x9b287b671d592594.xe1410f585439c7d4.x943f6be3acf634db("style:default-outline-level", (int)(x44ecfea61c937b8e.x1a78664fa10a3755.xdd05b9fa0fd72684 + 1));
			}
			if (x44ecfea61c937b8e.Type != StyleType.Character)
			{
				x36b22abff3afc8ef.x6210059f049f0d48(x44ecfea61c937b8e, x44ecfea61c937b8e.x1a78664fa10a3755);
			}
			xb40af1dcb7c844eb.x6210059f049f0d48(x44ecfea61c937b8e, x44ecfea61c937b8e.xeedad81aaed42a76);
			x9b287b671d592594.xe1410f585439c7d4.x2dfde153f4ef96d0("style:style");
		}
	}

	private void xaedce5725e456ac5(Paragraph x31e6518f5e08db6c)
	{
		x9b287b671d592594.x84e55246091c35af = 0;
		x9b287b671d592594.xa0c811de7638c8b1 = 0;
		string xbd5a2e7a4ff749c = x738231306863c7ae();
		x7836b37ea6311ff0(xbd5a2e7a4ff749c, "paragraph", x891e94d5f7be2eef(x31e6518f5e08db6c));
		xae77568195671cdc(x9b287b671d592594.x5417a7be6b5ed8a2 == 1 && x31e6518f5e08db6c.ParentSection.x65c77554c620f590, x4520f9b08f5a50d7: false);
		x36b22abff3afc8ef.x6210059f049f0d48(x31e6518f5e08db6c, x31e6518f5e08db6c.x1a78664fa10a3755);
		xb40af1dcb7c844eb.x6210059f049f0d48(x31e6518f5e08db6c, x31e6518f5e08db6c.x344511c4e4ce09da);
		x9b287b671d592594.xe1410f585439c7d4.x2dfde153f4ef96d0("style:style");
	}

	internal void xae77568195671cdc(bool x04e94399655d8f62, bool x4520f9b08f5a50d7)
	{
		if (x9b287b671d592594.x918fb62389d96551 || x04e94399655d8f62)
		{
			string text = x2b7914478090f4f7(x9b287b671d592594, x9b287b671d592594.x10d7a1cae426b158);
			if (text == null && (!x4520f9b08f5a50d7 || x04e94399655d8f62))
			{
				text = "Standard";
			}
			x9b287b671d592594.xe1410f585439c7d4.x943f6be3acf634db("style:master-page-name", text);
			x9b287b671d592594.x918fb62389d96551 = false;
		}
	}

	internal static string x2b7914478090f4f7(xdb0bf9f81de4b38c xbdfb620b7167944b, Section xb32f8dd719a105db)
	{
		int num = xbdfb620b7167944b.x2c8c6741422a1298.Sections.IndexOf(xb32f8dd719a105db);
		if (num == 0)
		{
			if (xbdfb620b7167944b.x05ee8ce4d7312eb5 == x14bf6f47128e4438.x213a21086ebb469c || xbdfb620b7167944b.x05ee8ce4d7312eb5 == x14bf6f47128e4438.x05a725d9893e5a35)
			{
				return null;
			}
			return "Standard";
		}
		return $"MasterPage{num}";
	}

	internal void xaedce5725e456ac5(Paragraph x31e6518f5e08db6c, bool x9509445ad0c3e86a, bool xabdcf516a31c311c)
	{
		x36b22abff3afc8ef.xc9616fd35264939f = x9509445ad0c3e86a;
		x36b22abff3afc8ef.x6f60ee90ecc71e66 = xabdcf516a31c311c;
		xaedce5725e456ac5(x31e6518f5e08db6c);
		x36b22abff3afc8ef.xc9616fd35264939f = false;
		x36b22abff3afc8ef.x6f60ee90ecc71e66 = false;
	}

	internal void xaedce5725e456ac5(Section xb32f8dd719a105db)
	{
		x7836b37ea6311ff0(xea449a379fa390a6(), "section", null);
		if (xb32f8dd719a105db.PageSetup.SectionStart == SectionStart.NewPage)
		{
			x9b287b671d592594.xe1410f585439c7d4.x943f6be3acf634db("style:master-page-name", x2b7914478090f4f7(x9b287b671d592594, x9b287b671d592594.x10d7a1cae426b158));
		}
		x047ee985d0cfc992.x6210059f049f0d48(xb32f8dd719a105db);
		x9b287b671d592594.xe1410f585439c7d4.x2dfde153f4ef96d0("style:style");
	}

	internal void xaedce5725e456ac5(ListLevel xdcfcc0186c9811f1, List x8a0b266419f09a55, string xbd5a2e7a4ff749c9)
	{
		if (xb40af1dcb7c844eb.x1dc6435a987402fa(null, xdcfcc0186c9811f1.xeedad81aaed42a76))
		{
			Style style = x9b287b671d592594.x2c8c6741422a1298.Styles.x1976fb6958cf7237(x8a0b266419f09a55.x178ff6dcbf808c38.xc657ea789af2c1f0, x988fcf605f8efa7e: false);
			string x48ab6faa4a = ((style != null && style.StyleIdentifier != StyleIdentifier.NoList) ? x0eb9a864413f34de.xb19294b14e3c8598(style) : "");
			x7836b37ea6311ff0(xbd5a2e7a4ff749c9, "text", x48ab6faa4a);
			xb40af1dcb7c844eb.xa07be38424ba1ddf(xaab0c5f1acc303e5: false);
			x9b287b671d592594.xe1410f585439c7d4.x2dfde153f4ef96d0("style:style");
		}
	}

	private void x7836b37ea6311ff0(string xbd5a2e7a4ff749c9, string x690ee913dde10e08, string x48ab6faa4a136507)
	{
		string text = xbd5a2e7a4ff749c9;
		if (!x9b287b671d592594.xb872fbc83a2cb9a6)
		{
			int num = 0;
			while (x9b287b671d592594.x010e51d18aa06ecc.ContainsValue($"{text}{x690ee913dde10e08}"))
			{
				text = $"{xbd5a2e7a4ff749c9}_{num++}";
			}
			x9b287b671d592594.x010e51d18aa06ecc.Add(x9b287b671d592594.x010e51d18aa06ecc.Count, $"{text}{x690ee913dde10e08}");
		}
		x9c77c7e782b62883 xe1410f585439c7d = x9b287b671d592594.xe1410f585439c7d4;
		xe1410f585439c7d.x2307058321cdb62f("style:style");
		xe1410f585439c7d.xa10744432d06325a(text);
		xe1410f585439c7d.x943f6be3acf634db("style:family", x690ee913dde10e08);
		xe1410f585439c7d.x943f6be3acf634db("style:parent-style-name", xbb857c9fc36f5054.x127fca996f5c76e4(x48ab6faa4a136507));
	}

	internal void x7836b37ea6311ff0(string xbd5a2e7a4ff749c9, string x690ee913dde10e08)
	{
		x7836b37ea6311ff0(xbd5a2e7a4ff749c9, x690ee913dde10e08, null);
	}

	internal void xdca0be0024cc142b(string x690ee913dde10e08)
	{
		x9b287b671d592594.xe1410f585439c7d4.x2307058321cdb62f("style:default-style");
		x9b287b671d592594.xe1410f585439c7d4.x943f6be3acf634db("style:family", x690ee913dde10e08);
	}

	private static Style x0ae496095d389ba7(xf5ecf429e74b1c04 x1a84eefd5d3e114a)
	{
		if (x1a84eefd5d3e114a is Style)
		{
			return (Style)x1a84eefd5d3e114a;
		}
		if (x1a84eefd5d3e114a is Paragraph)
		{
			return ((Paragraph)x1a84eefd5d3e114a).xfcffbd79482d97c7;
		}
		if (x1a84eefd5d3e114a is Footnote)
		{
			return ((Footnote)x1a84eefd5d3e114a).ParentParagraph.xfcffbd79482d97c7;
		}
		if (x1a84eefd5d3e114a is Shape || x1a84eefd5d3e114a is GroupShape)
		{
			Paragraph parentParagraph = ((ShapeBase)x1a84eefd5d3e114a).ParentParagraph;
			if (((ShapeBase)x1a84eefd5d3e114a).ParentNode is GroupShape)
			{
				parentParagraph = (((ShapeBase)x1a84eefd5d3e114a).ParentNode as GroupShape).ParentParagraph;
			}
			return parentParagraph?.xfcffbd79482d97c7;
		}
		Inline inline = (Inline)x1a84eefd5d3e114a;
		Style style = inline.Document.Styles.x1976fb6958cf7237(inline.xeedad81aaed42a76.x8301ab10c226b0c2, x988fcf605f8efa7e: false);
		if (style != null && style.StyleIdentifier != StyleIdentifier.DefaultParagraphFont)
		{
			return style;
		}
		return null;
	}

	private static string x891e94d5f7be2eef(xf5ecf429e74b1c04 x1a84eefd5d3e114a)
	{
		Style style = x0ae496095d389ba7(x1a84eefd5d3e114a);
		if (style == null)
		{
			return null;
		}
		if (x1a84eefd5d3e114a is Style)
		{
			Style style2 = style.Styles.x1976fb6958cf7237(style.xe709b224f455b863, x988fcf605f8efa7e: false);
			if (style2 != null)
			{
				return x0eb9a864413f34de.xb19294b14e3c8598(style2);
			}
			return null;
		}
		return x0eb9a864413f34de.xb19294b14e3c8598(style);
	}

	internal void xe9a75dda66f89395(string xeaba6e9280895554)
	{
		if (!x0d299f323d241756.x5959bccb67bbf051(xeaba6e9280895554))
		{
			return;
		}
		x9c77c7e782b62883 xe1410f585439c7d = x9b287b671d592594.xe1410f585439c7d4;
		xe1410f585439c7d.x2307058321cdb62f("number:date-style");
		xe1410f585439c7d.xa10744432d06325a(xe2d376da6365120b());
		MatchCollection matchCollection = x81477698220100d7.Matches(xeaba6e9280895554);
		foreach (Match item in matchCollection)
		{
			xe84e5e6c10f644f7(item);
			xafc73dc48ae8f924(item);
			x0254d928783dcabe(item);
			x8e340262614f8356(item);
			x4844e01ff6939da7(item);
			x3edf78ce3d784b9c(item);
			xdd59b4ea5cbabcf4(item);
			x730b857f3b69d39d(item);
			if (x0d299f323d241756.x5959bccb67bbf051(item.Groups[1].Value))
			{
				xe1410f585439c7d.xf68f9c3818e1f4b1("number:am-pm");
			}
			string xbcea506a33cf = item.Groups[21].Value.Trim('\'');
			if (x0d299f323d241756.x5959bccb67bbf051(xbcea506a33cf))
			{
				xe1410f585439c7d.x6b73ce92fd8e3f2c("number:text", xbcea506a33cf);
			}
		}
		xe1410f585439c7d.x2dfde153f4ef96d0("number:date-style");
	}

	private void xe84e5e6c10f644f7(Match x1b25e8c7ff13d736)
	{
		if (x0d299f323d241756.x5959bccb67bbf051(x1b25e8c7ff13d736.Groups[2].Value))
		{
			x9b287b671d592594.xe1410f585439c7d4.xf68f9c3818e1f4b1("number:era");
		}
	}

	private void xafc73dc48ae8f924(Match x1b25e8c7ff13d736)
	{
		xffa4544e4eecf231("number:year", x0d299f323d241756.x5959bccb67bbf051(x1b25e8c7ff13d736.Groups[4].Value), x0d299f323d241756.x5959bccb67bbf051(x1b25e8c7ff13d736.Groups[3].Value));
	}

	private void x0254d928783dcabe(Match x1b25e8c7ff13d736)
	{
		xffa4544e4eecf231("number:month", x0d299f323d241756.x5959bccb67bbf051(x1b25e8c7ff13d736.Groups[8].Value) || x0d299f323d241756.x5959bccb67bbf051(x1b25e8c7ff13d736.Groups[6].Value), x0d299f323d241756.x5959bccb67bbf051(x1b25e8c7ff13d736.Groups[7].Value) || x0d299f323d241756.x5959bccb67bbf051(x1b25e8c7ff13d736.Groups[5].Value), x0d299f323d241756.x5959bccb67bbf051(x1b25e8c7ff13d736.Groups[6].Value) || x0d299f323d241756.x5959bccb67bbf051(x1b25e8c7ff13d736.Groups[5].Value));
	}

	private void x8e340262614f8356(Match x1b25e8c7ff13d736)
	{
		xffa4544e4eecf231("number:day", x0d299f323d241756.x5959bccb67bbf051(x1b25e8c7ff13d736.Groups[12].Value), x0d299f323d241756.x5959bccb67bbf051(x1b25e8c7ff13d736.Groups[11].Value));
	}

	private void x730b857f3b69d39d(Match x1b25e8c7ff13d736)
	{
		xffa4544e4eecf231("number:day-of-week", x0d299f323d241756.x5959bccb67bbf051(x1b25e8c7ff13d736.Groups[10].Value), x0d299f323d241756.x5959bccb67bbf051(x1b25e8c7ff13d736.Groups[9].Value));
	}

	private void x4844e01ff6939da7(Match x1b25e8c7ff13d736)
	{
		xffa4544e4eecf231("number:hours", x0d299f323d241756.x5959bccb67bbf051(x1b25e8c7ff13d736.Groups[14].Value) || x0d299f323d241756.x5959bccb67bbf051(x1b25e8c7ff13d736.Groups[16].Value), x0d299f323d241756.x5959bccb67bbf051(x1b25e8c7ff13d736.Groups[13].Value) || x0d299f323d241756.x5959bccb67bbf051(x1b25e8c7ff13d736.Groups[15].Value));
	}

	private void x3edf78ce3d784b9c(Match x1b25e8c7ff13d736)
	{
		xffa4544e4eecf231("number:minutes", x0d299f323d241756.x5959bccb67bbf051(x1b25e8c7ff13d736.Groups[18].Value), x0d299f323d241756.x5959bccb67bbf051(x1b25e8c7ff13d736.Groups[17].Value));
	}

	private void xdd59b4ea5cbabcf4(Match x1b25e8c7ff13d736)
	{
		xffa4544e4eecf231("number:seconds", x0d299f323d241756.x5959bccb67bbf051(x1b25e8c7ff13d736.Groups[20].Value), x0d299f323d241756.x5959bccb67bbf051(x1b25e8c7ff13d736.Groups[19].Value));
	}

	private void xffa4544e4eecf231(string x121383aa64985888, bool x91c11d7aa8b5fc54, bool xf7f67b47f36d3d12)
	{
		xffa4544e4eecf231(x121383aa64985888, x91c11d7aa8b5fc54, xf7f67b47f36d3d12, xf528d9d6b1af6cdc: false);
	}

	private void xffa4544e4eecf231(string x121383aa64985888, bool x91c11d7aa8b5fc54, bool xf7f67b47f36d3d12, bool xf528d9d6b1af6cdc)
	{
		if (x91c11d7aa8b5fc54 || xf7f67b47f36d3d12)
		{
			x9c77c7e782b62883 xe1410f585439c7d = x9b287b671d592594.xe1410f585439c7d4;
			xe1410f585439c7d.x2307058321cdb62f(x121383aa64985888);
			if (xf7f67b47f36d3d12)
			{
				xe1410f585439c7d.x943f6be3acf634db("number:style", "long");
			}
			if (xf528d9d6b1af6cdc)
			{
				xe1410f585439c7d.x943f6be3acf634db("number:textual", "true");
			}
			xe1410f585439c7d.x2dfde153f4ef96d0(x121383aa64985888);
		}
	}

	internal string x455e44058f4e8da3()
	{
		x9b287b671d592594.x9ccf4cb9c6099e0a++;
		return $"FR{x9b287b671d592594.x9ccf4cb9c6099e0a}";
	}

	internal string xfb973fa049c32c2d()
	{
		x9b287b671d592594.x84e55246091c35af++;
		return $"T{x9b287b671d592594.x5417a7be6b5ed8a2}_{x9b287b671d592594.x84e55246091c35af}";
	}

	internal string x738231306863c7ae()
	{
		x9b287b671d592594.x5417a7be6b5ed8a2++;
		return $"P{x9b287b671d592594.x5417a7be6b5ed8a2}";
	}

	internal string xea449a379fa390a6()
	{
		return $"S{x9b287b671d592594.x2c8c6741422a1298.Sections.IndexOf(x9b287b671d592594.x10d7a1cae426b158) + 1}";
	}

	internal string xe2d376da6365120b()
	{
		x9b287b671d592594.xc6722b414f454e78++;
		return $"DT{x9b287b671d592594.xc6722b414f454e78}";
	}
}
