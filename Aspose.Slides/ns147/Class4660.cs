using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using ns101;
using ns119;
using ns121;
using ns128;
using ns138;
using ns139;
using ns144;
using ns146;
using ns149;
using ns99;

namespace ns147;

internal class Class4660 : Class4655
{
	private struct Struct180
	{
		private Class4674 class4674_0;

		public Struct180(Class4674 points)
		{
			class4674_0 = points;
		}
	}

	private class Class4674 : CollectionBase
	{
		private List<Struct181> list_0 = new List<Struct181>();

		public new int Count => list_0.Count;

		public Struct181 this[int index] => list_0[index];

		public void Add(Struct181 point)
		{
			list_0.Add(point);
		}
	}

	private struct Struct181
	{
		public byte byte_0;

		public int int_0;

		public int int_1;
	}

	[Flags]
	internal enum Enum653 : byte
	{
		flag_0 = 1,
		flag_1 = 2,
		flag_2 = 4,
		flag_3 = 8,
		flag_4 = 0x10,
		flag_5 = 0x20
	}

	[Flags]
	internal enum Enum654 : ushort
	{
		flag_0 = 1,
		flag_1 = 2,
		flag_2 = 4,
		flag_3 = 8,
		flag_4 = 0x20,
		flag_5 = 0x40,
		flag_6 = 0x80,
		flag_7 = 0x100,
		flag_8 = 0x200,
		flag_9 = 0x400
	}

	public const string string_0 = "glyf";

	internal const string string_1 = "glyf";

	private ArrayList arrayList_0 = new ArrayList();

	private Hashtable hashtable_0 = new Hashtable();

	internal Class4660(Class4681 ttfTables, Class4411 font)
		: base(ttfTables, font)
	{
	}

	internal Class4660(Class4651 context, uint checkSum, uint offset, uint length)
		: base(context, checkSum, offset, length)
	{
	}

	public virtual bool vmethod_4(int glyphIndex)
	{
		if (glyphIndex >= 0)
		{
			return glyphIndex < base.TTFTables.MaxpTable.NumGlyphs;
		}
		return false;
	}

	public virtual Class4480 vmethod_5(int glyphIndex)
	{
		return method_3(glyphIndex);
	}

	internal void method_2(int glyphIndex, Class4505 glyphIDs)
	{
		using Class4689 @class = new Class4689(base.Context.vmethod_1(glyphIndex));
		uint num = base.TTFTables.LocaTable.Offsets[glyphIndex];
		uint num2 = base.TTFTables.LocaTable.Offsets[glyphIndex + 1];
		if (Math.Abs(num2 - num) <= 0L)
		{
			return;
		}
		@class.Seek(base.Offset + num);
		short num3 = @class.method_14();
		if (num3 >= 0)
		{
			return;
		}
		@class.Seek(@class.Position + 8L);
		ushort num4;
		do
		{
			num4 = @class.method_18();
			Class4508 glyphID = new Class4508(@class.method_18());
			if (!glyphIDs.Contains(glyphID))
			{
				glyphIDs.Add(glyphID);
			}
			if ((num4 & 0x20) == 0)
			{
				break;
			}
			int num5 = (((num4 & 1) == 0) ? 2 : 4);
			if ((num4 & 8u) != 0)
			{
				num5 += 2;
			}
			else if ((num4 & 0x40u) != 0)
			{
				num5 += 4;
			}
			if ((num4 & 0x80u) != 0)
			{
				num5 += 8;
			}
			@class.Seek(@class.Position + num5);
		}
		while ((num4 & 0x20u) != 0);
	}

	private Class4480 method_3(int glyphIndex)
	{
		Class4487 streamSource = (base.IsNewFont ? new Class4488((byte[])arrayList_0[glyphIndex]) : base.Context.vmethod_1(glyphIndex));
		Class4480 glyph;
		using (Class4689 ttfReader = new Class4689(streamSource))
		{
			try
			{
				int nestingLevel = 0;
				method_4(ttfReader, glyphIndex, out glyph, ref nestingLevel);
				glyph.SourceResolution = (int)base.TTFTables.HeadTable.UnitsPerEm;
			}
			catch (EndOfStreamException ex)
			{
				Class4555.smethod_0($"parsing of glyph#{glyphIndex} failed. exception: {ex.ToString()}");
				glyph = new Class4480();
				glyph.SourceResolution = (int)base.TTFTables.HeadTable.UnitsPerEm;
				glyph.State = Enum642.const_1;
			}
		}
		return glyph;
	}

	private void method_4(Class4689 ttfReader, int glyphNum, out Class4480 glyph, ref int nestingLevel)
	{
		uint num;
		uint num2;
		if (base.Context is Class4652)
		{
			num = 0u;
			num2 = (uint)ttfReader.StreamLength;
		}
		else if (!base.IsNewFont)
		{
			num = base.TTFTables.LocaTable.Offsets[glyphNum];
			num2 = base.TTFTables.LocaTable.Offsets[glyphNum + 1];
		}
		else
		{
			num = 0u;
			num2 = (uint)ttfReader.StreamLength;
		}
		double num3 = 0.0;
		double num4 = 0.0;
		double widthVectorX = 0.0;
		double widthVectorY = 0.0;
		Class4518 @class = new Class4518();
		num3 = 0.0;
		num4 = 0.0;
		if (base.TTFTables.HmtxTable != null)
		{
			if (base.TTFTables.HmtxTable.Hmetrics.Count == 1)
			{
				widthVectorX = (int)base.TTFTables.HmtxTable.Hmetrics[0].ushort_0;
				if (base.TTFTables.HmtxTable.LeftSidebearings.Length > 0)
				{
					num3 = base.TTFTables.HmtxTable.LeftSidebearings[0];
				}
			}
			else if (glyphNum <= base.TTFTables.HmtxTable.Hmetrics.Count - 1)
			{
				widthVectorX = (int)base.TTFTables.HmtxTable.Hmetrics[glyphNum].ushort_0;
				num3 = base.TTFTables.HmtxTable.Hmetrics[glyphNum].short_0;
			}
			else if (base.TTFTables.HheaTable != null)
			{
				widthVectorX = (int)base.TTFTables.HheaTable.AdvanceWidthMax;
				int num5 = glyphNum - base.TTFTables.HmtxTable.Hmetrics.Count;
				if (num5 >= 0 && num5 < base.TTFTables.HmtxTable.LeftSidebearings.Length)
				{
					num3 = base.TTFTables.HmtxTable.LeftSidebearings[num5];
				}
			}
		}
		if (Math.Abs(num2 - num) > 0L)
		{
			ttfReader.Seek(base.Offset + num);
			short num6 = ttfReader.method_14();
			short num7 = ttfReader.method_10();
			short num8 = ttfReader.method_10();
			short num9 = ttfReader.method_10();
			short num10 = ttfReader.method_10();
			@class = new Class4518();
			@class.double_0 = num7;
			@class.double_2 = num9;
			@class.double_1 = num8;
			@class.double_3 = num10;
			widthVectorY = num8;
			if (num6 > -1)
			{
				glyph = new Class4480();
				method_5(ttfReader, glyphNum, glyph, num, num6);
			}
			else
			{
				method_8(ttfReader, glyphNum, ref nestingLevel, (Class4481)(glyph = new Class4481()));
				if (nestingLevel >= 50)
				{
					glyph.State = Enum642.const_1;
				}
			}
		}
		else
		{
			glyph = new Class4480();
			glyph.InitialData = new Class4480.Class4482(base.Context, new Class4508(glyphNum), new byte[0]);
			Class4616 pathDefinition = Class4616.smethod_0();
			glyph.PathDefinition = pathDefinition;
		}
		glyph.LeftSidebearingX = num3;
		glyph.LeftSidebearingY = num4;
		glyph.WidthVectorX = widthVectorX;
		glyph.WidthVectorY = widthVectorY;
		glyph.GlyphBBox = @class;
	}

	private void method_5(Class4689 ttfReader, int glyphNum, Class4480 glyph, uint glyphOffset, short numberOfContours)
	{
		Class4616 pathDefinition;
		if (numberOfContours == 0)
		{
			pathDefinition = Class4616.smethod_0();
			glyph.PathDefinition = pathDefinition;
			return;
		}
		pathDefinition = (Class4616)(glyph.PathDefinition = Class4616.smethod_1());
		pathDefinition.int_0 = numberOfContours;
		pathDefinition.ushort_0 = new ushort[numberOfContours];
		for (int i = 0; i < numberOfContours; i++)
		{
			pathDefinition.ushort_0[i] = ttfReader.method_18();
		}
		ushort num = ttfReader.method_18();
		byte[] array = new byte[num];
		for (int j = 0; j < num; j++)
		{
			array[j] = ttfReader.method_17();
		}
		pathDefinition.int_1 = 0;
		ushort[] ushort_ = pathDefinition.ushort_0;
		foreach (ushort num2 in ushort_)
		{
			if (pathDefinition.int_1 < num2)
			{
				pathDefinition.int_1 = num2;
			}
		}
		pathDefinition.int_1++;
		pathDefinition.bool_0 = new bool[pathDefinition.int_1];
		pathDefinition.bool_1 = new bool[pathDefinition.int_1];
		pathDefinition.byte_0 = new byte[pathDefinition.int_1];
		for (int l = 0; l < pathDefinition.int_1; l++)
		{
			byte b = ttfReader.method_17();
			pathDefinition.byte_0[l] = b;
			if ((b & 8u) != 0)
			{
				int num3 = ttfReader.method_17();
				for (int m = 0; m < num3; m++)
				{
					l++;
					pathDefinition.byte_0[l] = b;
				}
			}
		}
		short[] array2 = new short[pathDefinition.int_1];
		pathDefinition.double_0 = new double[pathDefinition.int_1];
		for (int n = 0; n < pathDefinition.int_1; n++)
		{
			if ((pathDefinition.byte_0[n] & 2u) != 0)
			{
				if ((pathDefinition.byte_0[n] & 0x10u) != 0)
				{
					array2[n] = ttfReader.method_17();
				}
				else
				{
					array2[n] = (short)(-ttfReader.method_17());
				}
			}
			else if ((pathDefinition.byte_0[n] & 0x10u) != 0)
			{
				array2[n] = 0;
			}
			else
			{
				array2[n] = ttfReader.method_14();
			}
			if (n == 0)
			{
				pathDefinition.double_0[n] = array2[n];
			}
			else
			{
				pathDefinition.double_0[n] = (double)array2[n] + pathDefinition.double_0[n - 1];
			}
		}
		short[] array3 = new short[pathDefinition.int_1];
		pathDefinition.double_1 = new double[pathDefinition.int_1];
		for (int num4 = 0; num4 < pathDefinition.int_1; num4++)
		{
			if ((pathDefinition.byte_0[num4] & 4u) != 0)
			{
				if ((pathDefinition.byte_0[num4] & 0x20u) != 0)
				{
					array3[num4] = ttfReader.method_17();
				}
				else
				{
					array3[num4] = (short)(-ttfReader.method_17());
				}
			}
			else if ((pathDefinition.byte_0[num4] & 0x20u) != 0)
			{
				array3[num4] = 0;
			}
			else
			{
				array3[num4] = ttfReader.method_14();
			}
			if (num4 == 0)
			{
				pathDefinition.double_1[num4] = array3[num4];
			}
			else
			{
				pathDefinition.double_1[num4] = (double)array3[num4] + pathDefinition.double_1[num4 - 1];
			}
		}
		uint num5 = (uint)ttfReader.Position;
		ttfReader.Seek(base.Offset + glyphOffset);
		byte[] rawGlyphBytes = ttfReader.method_1((int)(num5 - (base.Offset + glyphOffset)));
		glyph.InitialData = new Class4480.Class4482(base.Context, new Class4508(glyphNum), rawGlyphBytes);
	}

	internal bool method_6(Class4480 glyph)
	{
		if (glyph.InitialData != Class4480.Class4482.class4482_0)
		{
			string key = smethod_1(glyph);
			return hashtable_0.ContainsKey(key);
		}
		return false;
	}

	internal ushort method_7(Class4480 glyph)
	{
		string key = smethod_1(glyph);
		return (ushort)hashtable_0[key];
	}

	private void method_8(Class4689 ttfReader, int glyphNum, ref int nestingLevel, Class4481 compositeGlyph)
	{
		nestingLevel++;
		ushort num;
		do
		{
			num = ttfReader.method_18();
			ushort num2 = ttfReader.method_18();
			Class4509 @class = new Class4509();
			int num3;
			int num4;
			if ((num & 1) == 0)
			{
				num3 = ttfReader.method_11();
				num4 = ttfReader.method_11();
			}
			else
			{
				num3 = ttfReader.method_14();
				num4 = ttfReader.method_14();
			}
			if ((num & 8u) != 0)
			{
				@class.A = ttfReader.method_12();
				@class.D = @class.A;
			}
			else if ((num & 0x40u) != 0)
			{
				@class.A = ttfReader.method_12();
				@class.D = ttfReader.method_12();
			}
			else if ((num & 0x80u) != 0)
			{
				@class.A = ttfReader.method_12();
				@class.B = ttfReader.method_12();
				@class.C = ttfReader.method_12();
				@class.D = ttfReader.method_12();
			}
			@class.TX = Math.Max(Math.Abs(@class.A), Math.Abs(@class.B));
			@class.TY = Math.Max(Math.Abs(@class.C), Math.Abs(@class.D));
			if (Math.Abs(Math.Abs(@class.A) - Math.Abs(@class.C)) <= 0.0)
			{
				@class.TX = 2.0 * @class.TX;
			}
			if (Math.Abs(Math.Abs(@class.C) - Math.Abs(@class.D)) <= 0.0)
			{
				@class.TY = 2.0 * @class.TY;
			}
			if ((num & 2u) != 0)
			{
				@class.TX *= num3;
				@class.TY *= num4;
			}
			long position = ttfReader.Position;
			if (nestingLevel >= 50)
			{
				break;
			}
			if (glyphNum != num2)
			{
				Class4480 glyph = null;
				if (base.Context is Class4652)
				{
					Class4487 class2 = ((Class4652)base.Context).vmethod_1(num2);
					if (class2 != null)
					{
						Class4689 ttfReader2 = new Class4689(class2);
						method_4(ttfReader2, num2, out glyph, ref nestingLevel);
					}
				}
				else
				{
					method_4(ttfReader, num2, out glyph, ref nestingLevel);
				}
				if (glyph != null)
				{
					compositeGlyph.Components.Add(new Class4483(glyph, @class));
				}
			}
			ttfReader.Seek(position);
		}
		while ((num & 0x20u) != 0);
		if ((num & 0x100u) != 0)
		{
			byte[] array = new byte[ttfReader.method_14()];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = ttfReader.method_17();
			}
			((Class4616)compositeGlyph.PathDefinition).byte_1 = array;
			try
			{
				if (base.Context.Font.RequiresBytecodeHinting)
				{
					Class4641 class3 = new Class4641(base.TTFTables.PrepTable.Program, base.TTFTables.PrepTable.Context);
					class3.method_0();
					class3.class4642_0.method_0(compositeGlyph);
					class3 = new Class4641(compositeGlyph, base.Context, class3.class4642_0);
					class3.method_0();
				}
			}
			catch (Exception ex)
			{
				if (Class4510.Current.Strictness != Class4510.Enum644.const_1)
				{
					throw;
				}
				Class4516.Instance.ErrorHandlerFactory.imethod_0().imethod_2(ex);
			}
		}
		compositeGlyph.InitialData = new Class4480.Class4482(base.Context, new Class4508(glyphNum), null);
	}

	internal void method_9(Class4480 glyph, out byte[] glyphBytes, out bool isNewGlyph)
	{
		string text = smethod_1(glyph);
		if (text != null && hashtable_0.ContainsKey(text))
		{
			ushort index = (ushort)hashtable_0[text];
			glyphBytes = (byte[])arrayList_0[index];
			isNewGlyph = false;
			return;
		}
		if (glyph.State == Enum642.const_1)
		{
			glyphBytes = new byte[0];
			arrayList_0.Add(glyphBytes);
			isNewGlyph = true;
			if (text != null)
			{
				hashtable_0[text] = (ushort)(arrayList_0.Count - 1);
			}
			return;
		}
		ArrayList arrayList = new ArrayList();
		Class4674 @class = null;
		int absX = 0;
		int absY = 0;
		Class4481 class2 = glyph as Class4481;
		if (class2 == null && base.Context.AdoptedHintingFrom != null && glyph.InitialData != Class4480.Class4482.class4482_0 && base.Context.AdoptedHintingFrom == glyph.InitialData.TTFParserContext)
		{
			using MemoryStream stream = new MemoryStream();
			using Class4685 class3 = new Class4685(stream);
			glyphBytes = glyph.InitialData.RawGlyphBytes;
			class3.method_1(glyphBytes);
		}
		else if (class2 != null && class2.Components.Count > 0)
		{
			using MemoryStream memoryStream = new MemoryStream();
			using (Class4685 class4 = new Class4685(memoryStream))
			{
				class4.method_5(-1);
				class4.method_5((short)glyph.GlyphBBox.double_0);
				class4.method_5((short)glyph.GlyphBBox.double_1);
				class4.method_5((short)glyph.GlyphBBox.double_2);
				class4.method_5((short)glyph.GlyphBBox.double_3);
				for (int i = 0; i < class2.Components.Count; i++)
				{
					Class4483 class5 = class2.Components[i];
					ushort num = 0;
					num = 1;
					num = 129;
					num = 131;
					if (i < class2.Components.Count - 1)
					{
						num = (ushort)(num | 0x20u);
					}
					class4.method_6(num);
					string key = smethod_1(class2.Components[i].Glyph);
					ushort value = (ushort)hashtable_0[key];
					class4.method_6(value);
					int num2 = (int)class5.Matrix.TX;
					int num3 = (int)class5.Matrix.TY;
					class4.method_5((short)num2);
					class4.method_5((short)num3);
					class4.method_12(class5.Matrix.A);
					class4.method_12(class5.Matrix.B);
					class4.method_12(class5.Matrix.C);
					class4.method_12(class5.Matrix.D);
				}
			}
			memoryStream.Close();
			glyphBytes = memoryStream.ToArray();
		}
		else
		{
			foreach (Interface143 segment in glyph.Path.Segments)
			{
				if (segment is Class4611)
				{
					@class = null;
					continue;
				}
				if (@class == null)
				{
					@class = new Class4674();
					arrayList.Add(@class);
				}
				if (segment is Class4614 class6)
				{
					smethod_2(@class, (int)class6.X, (int)class6.Y, 1, ref absX, ref absY);
				}
				else if (segment is Class4613 class7)
				{
					smethod_2(@class, (int)class7.X, (int)class7.Y, 1, ref absX, ref absY);
				}
				else if (segment is Class4612 class8)
				{
					int num4 = absX;
					int num5 = absY;
					smethod_2(@class, (int)((class8.X1 * 3.0 + (double)num4) / 4.0), (int)((class8.Y1 * 3.0 + (double)num5) / 4.0), 0, ref absX, ref absY);
					smethod_2(@class, (int)((class8.X2 * 3.0 + class8.X3) / 4.0), (int)((class8.Y2 * 3.0 + class8.Y3) / 4.0), 0, ref absX, ref absY);
					smethod_2(@class, (int)class8.X3, (int)class8.Y3, 1, ref absX, ref absY);
				}
			}
			using MemoryStream memoryStream2 = new MemoryStream();
			using (Class4685 class9 = new Class4685(memoryStream2))
			{
				if (arrayList.Count > 0)
				{
					class9.method_5((short)arrayList.Count);
					class9.method_5((short)glyph.GlyphBBox.double_0);
					class9.method_5((short)glyph.GlyphBBox.double_1);
					class9.method_5((short)glyph.GlyphBBox.double_2);
					class9.method_5((short)glyph.GlyphBBox.double_3);
					int num6 = 0;
					foreach (Class4674 item in arrayList)
					{
						num6 += item.Count;
						class9.method_6((ushort)(num6 - 1));
					}
					class9.method_6(0);
					foreach (Class4674 item2 in arrayList)
					{
						for (int j = 0; j < item2.Count; j++)
						{
							class9.method_0(item2[j].byte_0);
						}
					}
					foreach (Class4674 item3 in arrayList)
					{
						for (int k = 0; k < item3.Count; k++)
						{
							class9.method_5((short)item3[k].int_0);
						}
					}
					foreach (Class4674 item4 in arrayList)
					{
						for (int l = 0; l < item4.Count; l++)
						{
							class9.method_5((short)item4[l].int_1);
						}
					}
				}
			}
			memoryStream2.Close();
			glyphBytes = memoryStream2.ToArray();
		}
		arrayList_0.Add(glyphBytes);
		isNewGlyph = true;
		if (text != null)
		{
			hashtable_0[text] = (ushort)(arrayList_0.Count - 1);
		}
	}

	private static string smethod_1(Class4480 glyph)
	{
		if (glyph.InitialData != Class4480.Class4482.class4482_0)
		{
			int hashCode = glyph.InitialData.TTFParserContext.GetHashCode();
			int value = ((Class4508)glyph.InitialData.GlyphID).Value;
			return $"{hashCode}-{value}";
		}
		return null;
	}

	private static void smethod_2(Class4674 points, int x, int y, byte flags, ref int absX, ref int absY)
	{
		Struct181 point = default(Struct181);
		point.byte_0 |= flags;
		point.int_0 = x - absX;
		point.int_1 = y - absY;
		points.Add(point);
		absX = x;
		absY = y;
	}

	internal override void Save(out byte[] tableBytes, out uint length, out uint checksum)
	{
		if (!base.IsNewFont)
		{
			base.Save(out tableBytes, out length, out checksum);
			return;
		}
		using MemoryStream stream = new MemoryStream();
		using Class4685 @class = new Class4685(stream, closeStreamOnDispose: true);
		foreach (byte[] item in arrayList_0)
		{
			@class.method_1(item);
		}
		method_1(@class, stream, out tableBytes, out length, out checksum);
	}
}
