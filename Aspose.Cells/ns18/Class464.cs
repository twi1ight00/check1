using System.Drawing;
using System.Runtime.CompilerServices;

namespace ns18;

internal class Class464 : Class452
{
	private readonly RectangleF rectangleF_0;

	private readonly bool bool_0;

	private string string_0;

	public Class464(RectangleF rectangleF_1, string string_1)
	{
		rectangleF_0 = rectangleF_1;
		if (Class1399.smethod_6(string_1))
		{
			bool_0 = true;
			string_0 = string_1.Substring(1);
		}
		else
		{
			bool_0 = false;
			string_0 = string_1;
		}
	}

	[SpecialName]
	public RectangleF method_1()
	{
		return rectangleF_0;
	}

	[SpecialName]
	public bool method_2()
	{
		return bool_0;
	}

	[SpecialName]
	public string method_3()
	{
		return string_0;
	}

	[SpecialName]
	public void method_4(string string_1)
	{
		string_0 = string_1;
	}

	public override void vmethod_0(Class468 class468_0)
	{
		class468_0.vmethod_14(this);
	}
}
