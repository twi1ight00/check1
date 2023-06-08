using System;
using Aspose.Cells;
using ns2;

namespace ns9;

internal class Class360 : Class316
{
	internal Class360()
	{
		int_0 = 370;
	}

	internal void method_6(Class1116 class1116_0)
	{
		byte_0 = new byte[5];
		Array.Copy(BitConverter.GetBytes(class1116_0.int_0), 0, byte_0, 0, 4);
		byte b = smethod_0((ErrorType)class1116_0.object_0);
		byte_0[4] = b;
	}

	internal static byte smethod_0(ErrorType errorType_0)
	{
		return errorType_0 switch
		{
			ErrorType.Div => 7, 
			ErrorType.NA => 42, 
			ErrorType.Name => 29, 
			ErrorType.Null => 0, 
			ErrorType.Number => 36, 
			ErrorType.Ref => 23, 
			ErrorType.Value => 15, 
			_ => 0, 
		};
	}
}
