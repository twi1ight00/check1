using ns218;

namespace ns271;

internal class Class6729
{
	internal const int int_0 = 16;

	public string string_0;

	internal int int_1;

	public int int_2;

	internal int int_3;

	public Class6729(Class5950 reader)
	{
		string_0 = new string(reader.method_10(4));
		int_1 = reader.method_0();
		int_2 = reader.method_0();
		int_3 = reader.method_0();
	}

	internal void Write(Class5951 writer)
	{
		for (int i = 0; i < string_0.Length; i++)
		{
			writer.WriteByte((byte)string_0[i]);
		}
		writer.method_0(int_1);
		writer.method_0(int_2);
		writer.method_0(int_3);
	}

	internal static int smethod_0(byte[] data, int index, int count)
	{
		int num = 0;
		int num2 = index;
		int num3 = count / 4;
		int num4;
		int num5;
		int num6;
		int num7;
		for (int i = 0; i < num3; i++)
		{
			num4 = data[num2++];
			num5 = data[num2++];
			num6 = data[num2++];
			num7 = data[num2++];
			int num8 = num7 | (num6 << 8) | (num5 << 16) | (num4 << 24);
			num += num8;
		}
		num4 = ((num2 < count) ? data[num2++] : 0);
		num5 = ((num2 < count) ? data[num2++] : 0);
		num6 = ((num2 < count) ? data[num2++] : 0);
		num7 = 0;
		int num9 = 0 | (num6 << 8) | (num5 << 16) | (num4 << 24);
		return num + num9;
	}
}
