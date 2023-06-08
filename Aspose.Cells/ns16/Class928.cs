using System.Drawing;
using System.Runtime.CompilerServices;

namespace ns16;

internal class Class928
{
	private bool bool_0;

	internal Color color_0 = Color.Empty;

	internal string string_0;

	internal string string_1;

	internal Class1363 class1363_0 = new Class1363();

	internal Color Color
	{
		get
		{
			return color_0;
		}
		set
		{
			color_0 = value;
			bool_0 = false;
		}
	}

	[SpecialName]
	internal bool method_0()
	{
		return bool_0;
	}

	[SpecialName]
	internal void method_1(bool bool_1)
	{
		bool_0 = bool_1;
	}
}
