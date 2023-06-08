using System.Collections;
using Aspose.Cells;

namespace ns27;

internal class Class1189 : IComparer
{
	int IComparer.Compare(object x, object y)
	{
		int startIndex = ((FontSetting)x).StartIndex;
		int startIndex2 = ((FontSetting)y).StartIndex;
		return startIndex - startIndex2;
	}
}
