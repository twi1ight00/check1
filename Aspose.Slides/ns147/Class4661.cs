using System;
using System.IO;
using ns101;
using ns149;
using ns99;

namespace ns147;

internal class Class4661 : Class4660
{
	private Class4412 class4412_0;

	internal Class4661(Class4660 originalGlyfTable)
		: base(originalGlyfTable.Context, 0u, 0u, 0u)
	{
	}

	internal void method_10(Class4412 fontSubset)
	{
		class4412_0 = fontSubset;
	}

	public override bool vmethod_4(int glyphIndex)
	{
		if (class4412_0.UsedGlyphsIndexes.Contains(glyphIndex))
		{
			return base.Context.TTFTables.GlyfTable.vmethod_4(glyphIndex);
		}
		return false;
	}

	public override Class4480 vmethod_5(int glyphIndex)
	{
		if (class4412_0.UsedGlyphsIndexes.Contains(glyphIndex))
		{
			return base.Context.TTFTables.GlyfTable.vmethod_5(glyphIndex);
		}
		return null;
	}

	internal override void Save(out byte[] tableBytes, out uint length, out uint checksum)
	{
		using Class4689 @class = new Class4689(base.Context.vmethod_0());
		length = 0u;
		foreach (int usedGlyphsIndex in class4412_0.UsedGlyphsIndexes)
		{
			uint num2 = base.TTFTables.LocaTable.Offsets[usedGlyphsIndex];
			uint num3 = base.TTFTables.LocaTable.Offsets[usedGlyphsIndex + 1];
			length += (uint)(int)Math.Abs(num3 - num2);
		}
		using MemoryStream stream = new MemoryStream();
		using Class4685 class2 = new Class4685(stream, closeStreamOnDispose: true);
		byte[] array = new byte[256];
		for (int i = 0; i < base.TTFTables.LocaTable.Offsets.Count; i++)
		{
			if (class4412_0.UsedGlyphsIndexes.Contains(i))
			{
				uint num4 = base.TTFTables.LocaTable.Offsets[i];
				uint num5 = base.TTFTables.LocaTable.Offsets[i + 1];
				@class.Seek(base.TTFTables.GlyfTable.Offset + num4);
				int num6 = (int)Math.Abs(num5 - num4);
				_ = class4412_0.TTFTables.LocaTable.Offsets[i];
				if (array.Length < num6)
				{
					array = new byte[num6];
				}
				@class.method_2(num6, array, 0);
				class2.method_2(array, num6);
			}
		}
		method_1(class2, stream, out tableBytes, out length, out checksum);
	}
}
