using Aspose.Words;
using Aspose.Words.Fields;
using x28925c9b27b37a46;
using x2a6f63b6650e76c4;
using x6c95d9cf46ff5f25;

namespace xfbd1009a0cbb9842;

internal class x815c690bbd255c9e : x5dc2b4bc740c9563
{
	private readonly string x113ec0a83b1ef460;

	private readonly x7c04dbcdccf44713 x8096291ec1c14c81;

	internal x815c690bbd255c9e(Field field, string bookmarkName, string bookmarkValue)
		: this(field, bookmarkName, (bookmarkValue == null) ? null : new xe93eb88030ad2248(new xdfbdf8708b1e8b71(bookmarkValue)))
	{
	}

	internal x815c690bbd255c9e(Field field, string bookmarkName, x7c04dbcdccf44713 bookmarkValue)
		: base(field)
	{
		x113ec0a83b1ef460 = bookmarkName;
		x8096291ec1c14c81 = bookmarkValue;
	}

	protected override void PerformCore()
	{
		if (x0d299f323d241756.x5959bccb67bbf051(x113ec0a83b1ef460) && x8096291ec1c14c81 != null)
		{
			base.x2c8c6741422a1298.Range.Bookmarks[x113ec0a83b1ef460]?.Remove();
			x7e263f21a73a027a x7e263f21a73a027a = x8096291ec1c14c81.x2eb30ee04563e9e4();
			if (x7e263f21a73a027a == null)
			{
				string xf6e2349738d2d14e = x8096291ec1c14c81.x297a08accbde149a().xf6e2349738d2d14e;
				xe3b2513ab4d5789d xe3b2513ab4d5789d2 = new xe3b2513ab4d5789d(base.xd1b40af56a8385d4, xf6e2349738d2d14e, applyFormat: false);
				xe3b2513ab4d5789d2.x7d44c41f397d72e0();
			}
			else
			{
				base.xd1b40af56a8385d4.x52b190e626f65140(x7d5e2f34b6651bf4.xf8d31d196ccd74c4);
				base.xd1b40af56a8385d4.x5f4c2139149eaf99(x5113d1e6ef8a0405: true);
				x0a28863c804404d7.x775521112ede5e6f(x7e263f21a73a027a, base.xd1b40af56a8385d4.End, new x78f7ad9d7fd68e82(isTrimDoubleQuotes: true));
			}
			BookmarkStart newChild = new BookmarkStart(base.x2c8c6741422a1298, x113ec0a83b1ef460);
			base.xd1b40af56a8385d4.Separator.ParentParagraph.InsertAfter(newChild, base.xd1b40af56a8385d4.Separator);
			BookmarkEnd newChild2 = new BookmarkEnd(base.x2c8c6741422a1298, x113ec0a83b1ef460);
			base.xd1b40af56a8385d4.End.ParentParagraph.InsertBefore(newChild2, base.xd1b40af56a8385d4.End);
		}
	}
}
