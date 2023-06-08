using ns218;

namespace ns271;

internal struct Struct223
{
	internal ushort ushort_0;

	internal short short_0;

	internal Struct223(ushort advanceWidth, short leftSideBearing)
	{
		ushort_0 = advanceWidth;
		short_0 = leftSideBearing;
	}

	internal Struct223(Class5950 reader)
	{
		ushort_0 = reader.method_3();
		short_0 = reader.method_2();
	}

	internal void Write(Class5951 writer)
	{
		writer.method_3(ushort_0);
		writer.method_3(short_0);
	}
}
