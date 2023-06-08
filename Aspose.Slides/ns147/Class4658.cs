using System.IO;
using ns101;
using ns119;
using ns146;
using ns149;

namespace ns147;

internal class Class4658 : Class4655
{
	public const string string_0 = "cvt";

	internal const string string_1 = "cvt";

	internal byte[] byte_0;

	private short[] short_0;

	private short[] TableItems
	{
		get
		{
			method_0();
			return short_0;
		}
	}

	internal Class4658(Class4681 ttfTables, Class4411 font)
		: base(ttfTables, font)
	{
	}

	internal Class4658(Class4651 context, uint checkSum, uint offset, uint length)
		: base(context, checkSum, offset, length)
	{
	}

	internal override void vmethod_2(Class4689 ttfReader)
	{
		base.vmethod_2(ttfReader);
	}

	internal override void vmethod_0(Class4689 ttfReader)
	{
		base.vmethod_0(ttfReader);
		ttfReader.Seek(base.Offset);
		byte_0 = ttfReader.method_1((int)base.Length);
		using Class4689 @class = new Class4689(new Class4488(byte_0));
		short_0 = new short[byte_0.Length / 2];
		int num = 0;
		while (@class.Position < byte_0.Length - 2)
		{
			short_0[num++] = @class.method_10();
		}
	}

	internal short method_2(int entryIndex)
	{
		if (entryIndex < TableItems.Length)
		{
			return TableItems[entryIndex];
		}
		return 0;
	}

	internal void method_3(int entryIndex, short value)
	{
		if (entryIndex < TableItems.Length)
		{
			TableItems[entryIndex] = value;
		}
	}

	internal override void Save(out byte[] tableBytes, out uint length, out uint checksum)
	{
		if (base.IsNewFont)
		{
			using (MemoryStream stream = new MemoryStream())
			{
				using Class4685 @class = new Class4685(stream, closeStreamOnDispose: true);
				if (byte_0 != null)
				{
					@class.method_1(byte_0);
				}
				method_1(@class, stream, out tableBytes, out length, out checksum);
				return;
			}
		}
		base.Save(out tableBytes, out length, out checksum);
	}
}
