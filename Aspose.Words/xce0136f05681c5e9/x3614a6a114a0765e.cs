using System.Collections;
using Aspose.Words;
using Aspose.Words.Saving;
using Aspose.Words.Tables;
using x2697283ff424107e;
using x28925c9b27b37a46;
using x381fb081d11d6275;
using x461bbf0a821e3c87;
using x7c4557e104065fc9;

namespace xce0136f05681c5e9;

internal class x3614a6a114a0765e : x202941c978357b4f
{
	private readonly x9df536d98415d2d0 xa737d500a7554634;

	internal x3614a6a114a0765e(Document document, bool documentFragmentSaving, HtmlSaveOptions saveOptions, x9df536d98415d2d0 fontColorResolver, xe2ff3c3cd396cfd9 htmlWriterCommon, x0ce95024f2f68661 shapeResourceWriter, x68331b8428496f91 warningCallback)
		: base(document, documentFragmentSaving, saveOptions, htmlWriterCommon, shapeResourceWriter, warningCallback)
	{
		xa737d500a7554634 = fontColorResolver;
	}

	internal override ArrayList xdbfcc0f818df30a4()
	{
		return new ArrayList();
	}

	internal override void xf567f5aadd93f9a8(Section xb32f8dd719a105db)
	{
		base.xf567f5aadd93f9a8(xb32f8dd719a105db);
		xa3fc7dcdc8182ff6 xa3fc7dcdc8182ff = new xa3fc7dcdc8182ff6();
		x015eb412e40a664b.xa19e6d20b842efde(xb32f8dd719a105db.PageSetup, xa3fc7dcdc8182ff, !xb32f8dd719a105db.x65c77554c620f590 && base.xf57de0fd37d5e97d.x4e3c1d16eaf20ef3);
		x314725af01129cb4(xa3fc7dcdc8182ff.x9a706f5d15bd6d95(base.x8d3e55aac9030e70));
	}

	internal override void x23c8b7ad9bfc5719(Paragraph x41baca1d6c0c2e8e, x1a78664fa10a3755 x9e5248b49f0df7e8, bool x1ebf5501f9a725fb, x4ef6b4f19b033b48 x1458787a87172e23)
	{
		Paragraph x43004763abb6b2ac = null;
		int x8301ab10c226b0c = x41baca1d6c0c2e8e.x1a78664fa10a3755.x8301ab10c226b0c2;
		if (x8301ab10c226b0c >= 1 && x8301ab10c226b0c <= 6)
		{
			x43004763abb6b2ac = x41baca1d6c0c2e8e;
		}
		x41baca1d6c0c2e8e.xdf27503bc6a15f75(out var _, out var x966a98c86f220d2e, out var _);
		ParagraphFormat xefceefc9504671df = new ParagraphFormat(x9e5248b49f0df7e8, x41baca1d6c0c2e8e.Document.Styles);
		xa3fc7dcdc8182ff6 xa3fc7dcdc8182ff = x4edf5a654b83812d.x893948bf4ed8e702(xefceefc9504671df, x966a98c86f220d2e, x1ebf5501f9a725fb, x1458787a87172e23, base.xf57de0fd37d5e97d.AllowNegativeIndent, base.xf57de0fd37d5e97d.WarningCallback);
		xbb2a2396386bdb03(xa3fc7dcdc8182ff, x43004763abb6b2ac, xbab733ddfd26bc0a: true);
		x314725af01129cb4(xa3fc7dcdc8182ff.x9a706f5d15bd6d95(base.x8d3e55aac9030e70));
	}

	internal override void xabeba2b272a12ca7(Font x26094932cf7a9139, x000f21cbda739311 xcb075c7088c3b520, bool xf544375d86767c28)
	{
		xa3fc7dcdc8182ff6 xa3fc7dcdc8182ff = new xa3fc7dcdc8182ff6();
		x69e8b423c22edb61.x626fe6c256bd3933(xa3fc7dcdc8182ff, x26094932cf7a9139, xcb075c7088c3b520, xf544375d86767c28, base.x0f1c1b952997f672, xa737d500a7554634);
		x6e55fba257b87843(xa3fc7dcdc8182ff);
		xd349b7f1296c4aca(xa3fc7dcdc8182ff.x9a706f5d15bd6d95(base.x8d3e55aac9030e70));
	}

	internal override void x746ca66f5c31e314(Table x1ec770899c98a268, double x072a638ef82da903)
	{
		string xa7505a15e36bfe1e = xbb04898cf6b5ed4f.x0453fd62c41d85e6(x1ec770899c98a268, x072a638ef82da903, base.xf57de0fd37d5e97d.TableWidthOutputMode);
		x314725af01129cb4(xa7505a15e36bfe1e);
	}

	internal override void x47fedfe9a943719d(Row xa806b754814b9ae0)
	{
		string xa7505a15e36bfe1e = xbb04898cf6b5ed4f.x86e41577fe04ea49(xa806b754814b9ae0.RowFormat);
		x314725af01129cb4(xa7505a15e36bfe1e);
	}

	internal override void x1b6c90c46e2852e3(x9546c9d5ffe8dc51 xe6de5e5fa2d44af5)
	{
		string xa7505a15e36bfe1e = xbb04898cf6b5ed4f.x2f927a70e85f8dee(xe6de5e5fa2d44af5, base.xf57de0fd37d5e97d.TableWidthOutputMode);
		x314725af01129cb4(xa7505a15e36bfe1e);
	}
}
