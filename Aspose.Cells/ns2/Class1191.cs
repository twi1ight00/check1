using System.Collections;
using Aspose.Cells;

namespace ns2;

internal class Class1191 : IComparer
{
	int IComparer.Compare(object x, object y)
	{
		FormatCondition formatCondition = (FormatCondition)x;
		FormatCondition formatCondition2 = (FormatCondition)y;
		if (formatCondition.Priority > formatCondition2.Priority)
		{
			return -1;
		}
		if (formatCondition.Priority < formatCondition2.Priority)
		{
			return 1;
		}
		return 0;
	}
}
