using System;
using System.Collections;
using Aspose.Cells;
using ns16;
using ns2;

namespace ns10;

internal class Class1210
{
	private Class1718 class1718_0;

	private Class1212 class1212_0;

	private Class1218 class1218_0;

	private int int_0;

	private int int_1;

	private byte[] byte_0;

	private Hashtable hashtable_0;

	internal Class1210(Class1218 class1218_1, Class1718 class1718_1)
	{
		class1218_0 = class1218_1;
		class1718_0 = class1718_1;
	}

	internal void Read(Class1212 class1212_1, Hashtable hashtable_1)
	{
		class1212_0 = class1212_1;
		hashtable_0 = hashtable_1;
		while (true)
		{
			int_0 = class1212_0.method_0();
			switch (int_0)
			{
			case 363:
				method_1();
				break;
			default:
				int_1 = class1212_0.method_1();
				class1212_0.Seek(int_1);
				break;
			case 360:
				method_8();
				break;
			case 359:
				method_7();
				break;
			case 588:
				return;
			case 577:
				method_0();
				break;
			}
		}
	}

	private void method_0()
	{
		byte_0 = class1218_0.method_0(class1212_0);
		Class1653 @class = new Class1653(class1718_0);
		@class.Name = Class1217.smethod_8(byte_0, 0);
		class1718_0.method_0().Add(@class);
		while (true)
		{
			int_0 = class1212_0.method_0();
			switch (int_0)
			{
			case 586:
				byte_0 = class1218_0.method_0(class1212_0);
				@class.method_11(BitConverter.ToUInt16(byte_0, 0));
				@class.method_2(BitConverter.ToInt32(byte_0, 2));
				break;
			case 585:
				byte_0 = class1218_0.method_0(class1212_0);
				if (byte_0.Length > 4)
				{
					int num = byte_0.Length;
					@class.method_13(new byte[num]);
					Array.Copy(byte_0, 0, @class.method_12(), 0, num);
				}
				break;
			default:
				int_1 = class1212_0.method_1();
				class1212_0.Seek(int_1);
				break;
			case 587:
				class1212_0.Seek(1L);
				return;
			}
		}
	}

	private void method_1()
	{
		byte_0 = class1218_0.method_0(class1212_0);
		int num = BitConverter.ToInt32(byte_0, 0);
		bool flag = ((((uint)byte_0[4] & (true ? 1u : 0u)) != 0) ? true : false);
		Class1373 @class = class1718_0.method_9(num);
		if (flag)
		{
			@class.method_0().Add(Enum129.const_2, "true");
		}
		Class1117 class1117_ = null;
		while (true)
		{
			int_0 = class1212_0.method_0();
			switch (int_0)
			{
			case 371:
				method_6(class1117_);
				break;
			case 370:
				method_5(class1117_);
				break;
			case 369:
				method_4(class1117_);
				break;
			case 368:
				method_3(class1117_);
				break;
			case 367:
				method_2(class1117_);
				break;
			case 366:
			{
				byte_0 = class1218_0.method_0(class1212_0);
				int num2 = BitConverter.ToInt32(byte_0, 0);
				class1117_ = @class.GetRow(num2);
				break;
			}
			default:
				int_1 = class1212_0.method_1();
				class1212_0.Seek(int_1);
				break;
			case 364:
				class1212_0.Seek(1L);
				return;
			}
		}
	}

	private void method_2(Class1117 class1117_0)
	{
		byte_0 = class1218_0.method_0(class1212_0);
		int num = BitConverter.ToInt32(byte_0, 0);
		class1117_0.Add(num, null);
	}

	private void method_3(Class1117 class1117_0)
	{
		byte_0 = class1218_0.method_0(class1212_0);
		int num = BitConverter.ToInt32(byte_0, 0);
		double num2 = BitConverter.ToDouble(byte_0, 4);
		class1117_0.Add(num, num2);
	}

	private void method_4(Class1117 class1117_0)
	{
		byte_0 = class1218_0.method_0(class1212_0);
		int num = BitConverter.ToInt32(byte_0, 0);
		bool flag = byte_0[4] == 1;
		class1117_0.Add(num, flag);
	}

	private void method_5(Class1117 class1117_0)
	{
		byte_0 = class1218_0.method_0(class1212_0);
		int num = BitConverter.ToInt32(byte_0, 0);
		byte byte_ = byte_0[4];
		ErrorType errorType = smethod_0(byte_);
		class1117_0.Add(num, errorType);
	}

	internal static ErrorType smethod_0(byte byte_1)
	{
		return byte_1 switch
		{
			15 => ErrorType.Value, 
			7 => ErrorType.Div, 
			0 => ErrorType.Null, 
			29 => ErrorType.Name, 
			23 => ErrorType.Ref, 
			42 => ErrorType.NA, 
			36 => ErrorType.Number, 
			_ => ErrorType.Invalid, 
		};
	}

	private void method_6(Class1117 class1117_0)
	{
		byte_0 = class1218_0.method_0(class1212_0);
		int num = BitConverter.ToInt32(byte_0, 0);
		string object_ = Class1217.smethod_8(byte_0, 4);
		class1117_0.Add(num, object_);
	}

	private void method_7()
	{
		byte_0 = class1218_0.method_0(class1212_0);
		int num = BitConverter.ToInt32(byte_0, 0);
		int num2 = 4;
		string[] array = new string[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = Class1217.smethod_5(byte_0, ref num2);
		}
		class1718_0.method_5(array);
	}

	private void method_8()
	{
		byte_0 = class1218_0.method_0(class1212_0);
		int num = 2;
		string text = Class1217.smethod_5(byte_0, ref num);
		string string_ = Class1217.smethod_5(byte_0, ref num);
		switch (byte_0[0])
		{
		case 0:
			class1718_0.Type = Enum194.const_0;
			text = ((Class1564)hashtable_0[text]).string_3;
			class1718_0.method_27(Class1718.smethod_0(text, Enum188.const_0));
			break;
		case 1:
			class1718_0.Type = Enum194.const_3;
			class1718_0.method_23(string_, text);
			break;
		case 2:
			class1718_0.Type = Enum194.const_4;
			text = ((Class1564)hashtable_0[text]).string_3;
			class1718_0.method_23(string_, text);
			break;
		}
	}
}
