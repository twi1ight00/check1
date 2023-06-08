using System.Collections.Generic;
using System.IO;
using ns101;
using ns146;
using ns149;

namespace ns147;

internal class Class4664 : Class4655
{
	public class Class4675
	{
		private List<Struct182> list_0;

		public int Count => list_0.Count;

		public Struct182 this[int glyphIndex]
		{
			get
			{
				return list_0[glyphIndex];
			}
			set
			{
				list_0[glyphIndex] = value;
			}
		}

		internal Class4675(int numGlyphs)
		{
			list_0 = new List<Struct182>(numGlyphs);
		}

		internal Class4675()
		{
			list_0 = new List<Struct182>();
		}

		internal void Add(Struct182 offset)
		{
			list_0.Add(offset);
		}
	}

	public struct Struct182
	{
		public ushort ushort_0;

		public short short_0;

		internal Struct182(ushort advanceWidth, short leftSideBearing)
		{
			short_0 = leftSideBearing;
			ushort_0 = advanceWidth;
		}
	}

	public const string string_0 = "hmtx";

	internal const string string_1 = "hmtx";

	private Class4675 class4675_0;

	private short[] short_0;

	public Class4675 Hmetrics
	{
		get
		{
			method_0();
			return class4675_0;
		}
	}

	public short[] LeftSidebearings
	{
		get
		{
			method_0();
			return short_0;
		}
	}

	internal Class4664(Class4681 ttfTables, Class4411 font)
		: base(ttfTables, font)
	{
	}

	internal Class4664(Class4651 context, uint checkSum, uint offset, uint length)
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
			int numOfLongHorMetrics = base.TTFTables.HheaTable.NumOfLongHorMetrics;
			class4675_0 = new Class4675(numOfLongHorMetrics);
			for (int i = 0; i < numOfLongHorMetrics; i++)
			{
				class4675_0.Add(new Struct182(ttfReader.method_18(), ttfReader.method_14()));
			}
			int num = base.TTFTables.MaxpTable.NumGlyphs - base.TTFTables.HheaTable.NumOfLongHorMetrics;
			if (num >= 0)
			{
				short_0 = new short[num];
				for (int j = 0; j < num; j++)
				{
					short_0[j] = ttfReader.method_10();
				}
			}
		}
		else
		{
			class4675_0 = new Class4675();
			short_0 = new short[0];
		}
	}

	internal override void Save(out byte[] tableBytes, out uint length, out uint checksum)
	{
		if (base.IsNewFont)
		{
			using (MemoryStream stream = new MemoryStream())
			{
				using Class4685 @class = new Class4685(stream, closeStreamOnDispose: true);
				for (int i = 0; i < class4675_0.Count; i++)
				{
					Struct182 @struct = class4675_0[i];
					@class.method_6(@struct.ushort_0);
					@class.method_5(@struct.short_0);
				}
				short[] array = short_0;
				foreach (short xMin in array)
				{
					@class.method_15(xMin);
				}
				method_1(@class, stream, out tableBytes, out length, out checksum);
				return;
			}
		}
		base.Save(out tableBytes, out length, out checksum);
	}

	internal override bool vmethod_1()
	{
		bool result = true;
		int numOfLongHorMetrics = base.TTFTables.HheaTable.NumOfLongHorMetrics;
		if (class4675_0.Count != numOfLongHorMetrics)
		{
			result = false;
		}
		int num = base.TTFTables.MaxpTable.NumGlyphs - base.TTFTables.HheaTable.NumOfLongHorMetrics;
		if (short_0.Length != num)
		{
			result = false;
		}
		return result;
	}
}
