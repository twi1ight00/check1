using ns218;

namespace ns271;

internal class Class6728
{
	internal Struct223[] struct223_0;

	internal short[] short_0;

	internal Class6728(Class5950 reader, int hMetricCount, int glyphCount)
	{
		struct223_0 = new Struct223[hMetricCount];
		for (int i = 0; i < struct223_0.Length; i++)
		{
			ref Struct223 reference = ref struct223_0[i];
			reference = new Struct223(reader);
		}
		int num = glyphCount - hMetricCount;
		short_0 = new short[num];
		for (int j = 0; j < short_0.Length; j++)
		{
			short_0[j] = reader.method_2();
		}
	}

	internal Struct223 method_0(int glyphIndex)
	{
		if (glyphIndex < struct223_0.Length)
		{
			return struct223_0[glyphIndex];
		}
		Struct223 @struct = struct223_0[struct223_0.Length - 1];
		short leftSideBearing = 0;
		if (glyphIndex - struct223_0.Length < short_0.Length)
		{
			leftSideBearing = short_0[glyphIndex - struct223_0.Length];
		}
		return new Struct223(@struct.ushort_0, leftSideBearing);
	}
}
