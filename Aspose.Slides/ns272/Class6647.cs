using System;
using System.Collections;
using System.IO;
using ns218;
using ns221;
using ns271;

namespace ns272;

internal class Class6647 : Class6644
{
	private struct Struct222
	{
		public ushort ushort_0;

		public ushort ushort_1;

		public short short_0;

		public ushort ushort_2;

		public long long_0;
	}

	private Struct222[] struct222_0;

	private int[] int_0 = new int[256];

	private ushort[] ushort_2;

	private long long_0;

	public Class6647(ushort platformID, ushort platformSpecificID, Class6634 baseTable)
		: base(platformID, platformSpecificID, baseTable)
	{
	}

	[Attribute7(true)]
	internal override void vmethod_0(Class5950 ttfReader)
	{
		ttfReader.method_3();
		ttfReader.method_3();
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < 256; i++)
		{
			int_0[i] = ttfReader.method_3();
			hashtable[int_0[i]] = null;
		}
		struct222_0 = new Struct222[hashtable.Count];
		long_0 = ttfReader.BaseStream.Length - 1L;
		long num = 0L;
		for (int j = 0; j < struct222_0.Length; j++)
		{
			struct222_0[j] = default(Struct222);
			struct222_0[j].ushort_0 = ttfReader.method_3();
			struct222_0[j].ushort_1 = ttfReader.method_3();
			struct222_0[j].short_0 = ttfReader.method_2();
			struct222_0[j].ushort_2 = ttfReader.method_3();
			struct222_0[j].long_0 = ttfReader.BaseStream.Position;
			long num2 = ttfReader.BaseStream.Position + struct222_0[j].ushort_2;
			long num3 = ttfReader.BaseStream.Position + struct222_0[j].ushort_2 + struct222_0[j].ushort_1 * 2;
			if (num2 < long_0)
			{
				long_0 = num2;
			}
			if (num3 > num)
			{
				num = num3;
			}
		}
		ushort_2 = new ushort[(num - long_0) / 2L];
		ttfReader.BaseStream.Seek(long_0, SeekOrigin.Begin);
		for (long num4 = 0L; num4 < ushort_2.Length; num4++)
		{
			ushort_2[num4] = ttfReader.method_3();
		}
		base.vmethod_0(ttfReader);
	}

	public override int vmethod_3(char charCode)
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
		Struct222 @struct = struct222_0[num];
		if (@struct.ushort_0 <= b2 && b2 < @struct.ushort_0 + @struct.ushort_1)
		{
			int num2 = ushort_2[(@struct.long_0 + @struct.ushort_2 - long_0) / 2L + (b2 - @struct.ushort_0)];
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

	internal override Class6735 vmethod_2(Class6728 hMetrics)
	{
		Class6735 @class = new Class6735(((Class6636)base.BaseTable).IsSymbolicFont);
		for (char c = '\0'; c <= '\uffff'; c = (char)(c + 1))
		{
			int num = vmethod_3(c);
			if (num > 0)
			{
				Struct223 @struct = hMetrics.method_0(num);
				Class6734 class2 = new Class6734(c, num, @struct.ushort_0, @struct.short_0);
				@class.Add(class2);
				if (class2.OldGlyphIndex == 0)
				{
					@class.MissingGlyph = class2;
				}
			}
			if (c >= '\uffff')
			{
				break;
			}
		}
		return @class;
	}
}
