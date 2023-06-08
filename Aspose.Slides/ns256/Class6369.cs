using ns234;

namespace ns256;

internal class Class6369
{
	public static double smethod_0(string valueString, Interface288 valueProvider)
	{
		double num = Class6159.smethod_9(valueString);
		if (!double.IsNaN(num))
		{
			return num;
		}
		return valueProvider.imethod_0(valueString);
	}
}
