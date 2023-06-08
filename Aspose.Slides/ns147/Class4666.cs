using System.Collections.Generic;
using System.IO;
using ns101;
using ns146;
using ns149;

namespace ns147;

internal class Class4666 : Class4655
{
	internal class Class4676
	{
		private List<uint> list_0;

		public int Count => list_0.Count;

		public uint this[int index]
		{
			get
			{
				return list_0[index];
			}
			set
			{
				list_0[index] = value;
			}
		}

		internal Class4676(int numGlyphs)
		{
			list_0 = new List<uint>(numGlyphs);
		}

		public void Add(uint offset)
		{
			list_0.Add(offset);
		}

		public void Add(int offset)
		{
			list_0.Add((uint)offset);
		}
	}

	public const string string_0 = "loca";

	internal const string string_1 = "loca";

	private Class4676 class4676_0;

	internal virtual Class4676 Offsets
	{
		get
		{
			method_0();
			return class4676_0;
		}
	}

	internal Class4666(Class4681 ttfTables, Class4411 font)
		: base(ttfTables, font)
	{
	}

	internal Class4666(Class4651 context, uint checkSum, uint offset, uint length)
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
		if (!base.IsNewFont)
		{
			ttfReader.Seek(base.Offset);
			int numGlyphs = base.TTFTables.MaxpTable.NumGlyphs;
			int indexToLocFormat = base.TTFTables.HeadTable.IndexToLocFormat;
			class4676_0 = new Class4676(numGlyphs + 1);
			if (indexToLocFormat == 0)
			{
				for (int i = 0; i < numGlyphs + 1; i++)
				{
					class4676_0.Add((uint)(ttfReader.method_18() * 2));
				}
			}
			else
			{
				for (int j = 0; j < numGlyphs + 1; j++)
				{
					class4676_0.Add(ttfReader.method_19());
				}
			}
		}
		else
		{
			class4676_0 = new Class4676(1);
		}
	}

	internal override void Save(out byte[] tableBytes, out uint length, out uint checksum)
	{
		if (!base.IsNewFont)
		{
			base.Save(out tableBytes, out length, out checksum);
		}
		MemoryStream stream = new MemoryStream();
		using Class4685 @class = new Class4685(stream, closeStreamOnDispose: true);
		for (int i = 0; i < Offsets.Count; i++)
		{
			switch (base.TTFTables.HeadTable.IndexToLocFormat)
			{
			case 0:
				@class.method_5((short)(Offsets[i] / 2u));
				break;
			case 1:
				@class.method_7((int)Offsets[i]);
				break;
			}
		}
		method_1(@class, stream, out tableBytes, out length, out checksum);
	}
}
