using System;
using ns305;
using ns307;

namespace ns308;

internal class Class7070 : Interface370
{
	private string string_0;

	public Class7070(string tagName)
	{
		string_0 = tagName;
	}

	public short imethod_0(Class6976 n)
	{
		if ((n as Class6981).TagName.Equals(string_0, StringComparison.OrdinalIgnoreCase))
		{
			return 1;
		}
		return 2;
	}
}
