using System.Collections;

namespace ns270;

internal class Class6631 : IComparer
{
	int IComparer.Compare(object x, object y)
	{
		string text = x as string;
		string text2 = y as string;
		int num = text.Length.CompareTo(text2.Length);
		if (num == 0)
		{
			return string.CompareOrdinal(text.ToUpper(), text2.ToUpper());
		}
		return num;
	}
}
