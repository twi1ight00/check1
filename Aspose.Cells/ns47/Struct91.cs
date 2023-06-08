using ns18;

namespace ns47;

internal struct Struct91
{
	internal ushort ushort_0;

	internal short short_0;

	internal Struct91(ushort ushort_1, short short_1)
	{
		ushort_0 = ushort_1;
		short_0 = short_1;
	}

	internal void Write(Class1394 class1394_0)
	{
		class1394_0.method_4(ushort_0);
		class1394_0.method_3(short_0);
	}
}
