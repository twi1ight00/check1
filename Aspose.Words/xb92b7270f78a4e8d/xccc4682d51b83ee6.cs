using System.Collections;

namespace xb92b7270f78a4e8d;

internal class xccc4682d51b83ee6 : IComparer
{
	private int x91c86e0de828cc9f(object x08db3aeabb253cb1, object x1e218ceaee1bb583)
	{
		string text = (string)x08db3aeabb253cb1;
		string text2 = (string)x1e218ceaee1bb583;
		int num = text.Length.CompareTo(text2.Length);
		if (num == 0)
		{
			return string.CompareOrdinal(text.ToUpper(), text2.ToUpper());
		}
		return num;
	}

	int IComparer.Compare(object x08db3aeabb253cb1, object x1e218ceaee1bb583)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x91c86e0de828cc9f
		return this.x91c86e0de828cc9f(x08db3aeabb253cb1, x1e218ceaee1bb583);
	}
}
