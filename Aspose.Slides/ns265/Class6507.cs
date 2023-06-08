using System.Collections;
using ns237;

namespace ns265;

internal class Class6507 : Class6505
{
	private readonly int int_0;

	public Class6507(int pageNumber)
	{
		int_0 = pageNumber;
	}

	internal override void vmethod_1(IDictionary destinations)
	{
		if (destinations.Contains(int_0))
		{
			class6673_0 = (Class6673)destinations[int_0];
		}
	}
}
