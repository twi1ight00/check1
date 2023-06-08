using Aspose.Words;
using Aspose.Words.Fields;

namespace xfbd1009a0cbb9842;

internal abstract class x57af31d8c74e631c
{
	private readonly bool xebbe181ca4d77438;

	private readonly bool x4ad9f3fd9aa3592d;

	internal bool xe6148f06a6efc950 => xebbe181ca4d77438;

	protected x57af31d8c74e631c(bool applyToContainingField, bool removeParentParagraph)
	{
		xebbe181ca4d77438 = applyToContainingField;
		x4ad9f3fd9aa3592d = removeParentParagraph;
	}

	internal void xb333e1e6c01c2be2(Field xe01ae93d9fe5a880)
	{
		Paragraph parentParagraph = xe01ae93d9fe5a880.Start.ParentParagraph;
		PerformCore(xe01ae93d9fe5a880);
		if (x4ad9f3fd9aa3592d && !parentParagraph.x2aea422a99819d44)
		{
			parentParagraph.Remove();
		}
	}

	protected abstract void PerformCore(Field field);
}
