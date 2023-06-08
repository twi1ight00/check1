using System.Collections;
using Aspose.Words;
using x28925c9b27b37a46;
using x4adf554d20d941a6;

namespace x59d6a4fc5007b7a4;

internal class x4518c5ad55b7a470 : x0e9935be205598e7
{
	private readonly xacf1bb6be5092987 xd70158dc57fa8855;

	private readonly SortedList x61d46bacc8164606;

	public SortedList x01e813efe52383e6 => x61d46bacc8164606;

	private x4518c5ad55b7a470(xacf1bb6be5092987 sectionPr, SortedList possibleBorders)
	{
		xd70158dc57fa8855 = sectionPr;
		x61d46bacc8164606 = possibleBorders;
	}

	internal static BorderCollection x9f327a13adf13172(xacf1bb6be5092987 x74551b590d6ef9a3, params BorderType[] x5e568db11360615c)
	{
		SortedList sortedList = new SortedList();
		foreach (BorderType borderType in x5e568db11360615c)
		{
			sortedList.Add(borderType, borderType);
		}
		return new BorderCollection(new x4518c5ad55b7a470(x74551b590d6ef9a3, sortedList));
	}

	public object x6e9ebce5ff38cae9(int xba08ce632055a1d9)
	{
		return x3557aa8566455ba9.x9f6bbfd6a9013899(xd70158dc57fa8855.xb70a9d14469748bf.get_xe6d4b1b411ed94b5((BorderType)xba08ce632055a1d9));
	}

	public object x3087b5fa67bcf3f4(int xba08ce632055a1d9)
	{
		return null;
	}

	public void x039f0f0de50f5575(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
	}
}
