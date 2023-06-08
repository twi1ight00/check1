using ns18;

namespace ns47;

internal class Class1076
{
	internal ushort ushort_0;

	internal short short_0;

	private int int_0;

	internal Struct77[] struct77_0;

	internal Class1076(Class1393 class1393_0, Class1459 class1459_0, int int_1)
	{
		if (class1459_0 != null)
		{
			class1393_0.method_0().Position = class1459_0.int_1;
			ushort_0 = class1393_0.method_4();
			short_0 = class1393_0.method_3();
			int_0 = class1393_0.method_1();
			struct77_0 = new Struct77[short_0];
			for (int i = 0; i < short_0; i++)
			{
				class1393_0.method_0().Position = class1459_0.int_1 + 8 + i * int_0;
				Struct77 @struct = new Struct77
				{
					byte_0 = class1393_0.ReadByte(),
					byte_1 = class1393_0.ReadByte(),
					byte_2 = class1393_0.method_5(int_1)
				};
				struct77_0[i] = @struct;
			}
		}
	}
}
