using System.Collections;
using Aspose.Words;
using x28925c9b27b37a46;

namespace xfbd1009a0cbb9842;

internal class x43bb7ecffe7e5855 : x8b9b7e0edc8c7c4f
{
	private xeedad81aaed42a76 xd0c44e5ae0011daa;

	private xeedad81aaed42a76 xababd6b536739792;

	private bool x572b3b60acd3cc96;

	internal xeedad81aaed42a76 xeedad81aaed42a76 => xd0c44e5ae0011daa;

	internal x43bb7ecffe7e5855(IEnumerable resultNodes, Paragraph startParagraph)
		: base(resultNodes, startParagraph)
	{
	}

	internal override bool x47f176deff0d42e2()
	{
		if (x572b3b60acd3cc96)
		{
			xd0c44e5ae0011daa = null;
			return true;
		}
		return base.x47f176deff0d42e2();
	}

	protected override void OnChar(char c)
	{
		if (xd0c44e5ae0011daa == null)
		{
			xd0c44e5ae0011daa = base.x4092a781b3b7aab4.xeedad81aaed42a76;
		}
	}

	protected override void OnNextChar(char c)
	{
		xababd6b536739792 = base.x4092a781b3b7aab4.xeedad81aaed42a76;
	}

	protected override void OnNextNode()
	{
		if (base.x273d95283e8fc8d2)
		{
			xababd6b536739792 = base.x6b1ebac4b985013b.x344511c4e4ce09da;
		}
	}

	protected override void ApplyNext()
	{
		xd0c44e5ae0011daa = xababd6b536739792;
		xababd6b536739792 = null;
	}

	internal void x75be698bf0c3a5c5()
	{
		x572b3b60acd3cc96 = true;
	}

	internal void x45277e5380a187db()
	{
		x572b3b60acd3cc96 = false;
	}
}
