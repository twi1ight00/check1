using System.Runtime.CompilerServices;
using Aspose.Cells;

namespace ns26;

internal class Class1500
{
	private string string_0;

	private string string_1;

	private string string_2;

	internal string Name => string_0;

	[SpecialName]
	internal string method_0()
	{
		return string_1;
	}

	[SpecialName]
	internal string method_1()
	{
		return string_2;
	}

	internal Class1500(Font font_0)
	{
		string_0 = font_0.Name;
	}

	internal bool Equals(Font font_0)
	{
		if (font_0.Name.Equals(string_0))
		{
			return true;
		}
		return false;
	}
}
