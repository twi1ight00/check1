using System.Runtime.CompilerServices;

namespace ns57;

internal class Class1322
{
	internal int int_0;

	internal string string_0;

	internal object object_0;

	internal Class1322(int int_1, string string_1, object object_1)
	{
		int_0 = int_1;
		string_0 = string_1;
		object_0 = object_1;
	}

	[SpecialName]
	internal bool method_0()
	{
		if (string_0 != null)
		{
			return string_0 != "";
		}
		return false;
	}
}
