using System;
using System.Collections;
using ns147;
using ns149;

namespace ns143;

internal class Class4629 : Class4625
{
	private struct Struct179
	{
		public ushort ushort_0;

		public ushort ushort_1;

		public short short_0;

		public ushort ushort_2;

		public long long_0;
	}

	private Struct179[] struct179_0;

	private int[] int_0 = new int[256];

	private ushort[] ushort_2;

	private long long_0;

	internal Class4629(ushort platformID, ushort platformSpecificID, Class4657 baseTable)
		: base(platformID, platformSpecificID, baseTable)
	{
	}

	internal override void vmethod_0(Class4689 ttfReader)
	{
		ttfReader.method_18();
		ttfReader.method_18();
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < 256; i++)
		{
			int_0[i] = ttfReader.method_18();
			hashtable[int_0[i]] = null;
		}
		struct179_0 = new Struct179[hashtable.Count];
		long_0 = ttfReader.StreamLength - 1L;
		long num = 0L;
		for (int j = 0; j < struct179_0.Length; j++)
		{
			struct179_0[j] = default(Struct179);
			struct179_0[j].ushort_0 = ttfReader.method_18();
			struct179_0[j].ushort_1 = ttfReader.method_18();
			struct179_0[j].short_0 = ttfReader.method_14();
			struct179_0[j].ushort_2 = ttfReader.method_18();
			struct179_0[j].long_0 = ttfReader.Position;
			long num2 = ttfReader.Position + struct179_0[j].ushort_2;
			long num3 = ttfReader.Position + struct179_0[j].ushort_2 + struct179_0[j].ushort_1 * 2;
			if (num2 < long_0)
			{
				long_0 = num2;
			}
			if (num3 > num)
			{
				num = num3;
			}
		}
		ushort_2 = new ushort[(int)((num - long_0) / 2L)];
		ttfReader.Seek(long_0);
		for (long num4 = 0L; num4 < ushort_2.Length; num4++)
		{
			ushort_2[(int)num4] = ttfReader.method_18();
		}
		base.vmethod_0(ttfReader);
	}

	public override int vmethod_2(char charCode)
	{
		byte[] array = BitConverter.GetBytes((short)charCode);
		if (!base.IsUnicodeEncoding)
		{
			array = method_0(charCode);
		}
		byte b = array[0];
		int num;
		byte b2;
		if (array.Length > 1)
		{
			num = int_0[b] / 8;
			b2 = ((num != 0) ? array[1] : b);
		}
		else
		{
			num = 0;
			b2 = b;
		}
		Struct179 @struct = struct179_0[num];
		if (@struct.ushort_0 <= b2 && b2 < @struct.ushort_0 + @struct.ushort_1)
		{
			int num2 = ushort_2[(int)((@struct.long_0 + @struct.ushort_2 - long_0) / 2L + (b2 - @struct.ushort_0))];
			num2--;
			if (num2 != 0)
			{
				num2 += @struct.short_0;
				num2 %= 65536;
			}
			return num2;
		}
		return 0;
	}
}
