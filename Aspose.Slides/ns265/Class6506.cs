using System.Collections;
using ns237;

namespace ns265;

internal class Class6506 : Class6505
{
	private readonly string string_0;

	public Class6506(string linkId)
	{
		string_0 = linkId;
	}

	internal override void vmethod_1(IDictionary destinations)
	{
		if (destinations.Contains(string_0))
		{
			class6673_0 = (Class6673)destinations[string_0];
		}
		else if (destinations.Contains('#' + string_0))
		{
			class6673_0 = (Class6673)destinations['#' + string_0];
		}
	}
}
