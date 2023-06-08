using Aspose.Cells;
using ns2;
using ns27;

namespace ns29;

internal class Class1129
{
	internal static Enum134 smethod_0()
	{
		return Class972.smethod_0();
	}

	internal static void smethod_1()
	{
		if (smethod_0() == Enum134.const_0)
		{
			Class675.int_0++;
			if (Class675.int_0 > 100)
			{
				throw new CellsException(ExceptionType.Limitation, "You are using an evaluation copy and have opened files exceeding limitation.");
			}
		}
	}
}
