using System;
using System.IO;
using ns60;

namespace ns63;

internal class Class2981 : ICloneable, Interface40
{
	private enum Enum447
	{
		const_0 = 1,
		const_1 = 2,
		const_2 = 4,
		const_3 = 8,
		const_4 = 0x10,
		const_5 = 0x20,
		const_6 = 0x40,
		const_7 = 0x80,
		const_8 = 0x100,
		const_9 = 0x200,
		const_10 = 0x400,
		const_11 = 0x800,
		const_12 = 0x1000
	}

	private uint uint_0;

	private short short_0;

	private short short_1;

	private Class2942 class2942_0;

	private short[] short_2 = new short[5];

	private short[] short_3 = new short[5];

	public short? CLevels
	{
		get
		{
			if (method_11(Enum447.const_1))
			{
				return short_0;
			}
			return null;
		}
		set
		{
			if (value.HasValue)
			{
				short_0 = value.Value;
			}
			method_12(Enum447.const_1, value.HasValue);
		}
	}

	public short? DefaultTabSize
	{
		get
		{
			if (method_11(Enum447.const_0))
			{
				return short_1;
			}
			return null;
		}
		set
		{
			if (value.HasValue)
			{
				short_1 = value.Value;
			}
			method_12(Enum447.const_0, value.HasValue);
		}
	}

	public Class2942 TabStops
	{
		get
		{
			if (method_11(Enum447.const_2))
			{
				return class2942_0;
			}
			return null;
		}
		set
		{
			class2942_0 = value;
			method_12(Enum447.const_2, value != null);
		}
	}

	public short? LeftMargin1
	{
		get
		{
			return method_7(0);
		}
		set
		{
			method_8(0, value);
		}
	}

	public short? Indent1
	{
		get
		{
			return method_9(0);
		}
		set
		{
			method_10(0, value);
		}
	}

	public short? LeftMargin2
	{
		get
		{
			return method_7(1);
		}
		set
		{
			method_8(1, value);
		}
	}

	public short? Indent2
	{
		get
		{
			return method_9(1);
		}
		set
		{
			method_10(1, value);
		}
	}

	public short? LeftMargin3
	{
		get
		{
			return method_7(2);
		}
		set
		{
			method_8(2, value);
		}
	}

	public short? Indent3
	{
		get
		{
			return method_9(2);
		}
		set
		{
			method_10(2, value);
		}
	}

	public short? LeftMargin4
	{
		get
		{
			return method_7(3);
		}
		set
		{
			method_8(3, value);
		}
	}

	public short? Indent4
	{
		get
		{
			return method_9(3);
		}
		set
		{
			method_10(3, value);
		}
	}

	public short? LeftMargin5
	{
		get
		{
			return method_7(4);
		}
		set
		{
			method_8(4, value);
		}
	}

	public short? Indent5
	{
		get
		{
			return method_9(4);
		}
		set
		{
			method_10(4, value);
		}
	}

	public short[] LeftMargins => short_2;

	public short[] Indents => short_3;

	public void method_0(int levelIndex, Class2975 rulerLevel)
	{
		if (levelIndex < 0 || levelIndex > 4)
		{
			throw new IndexOutOfRangeException("LevelIndex of textRuler level is out-of-range!!! [" + levelIndex + "]");
		}
		method_8(levelIndex, rulerLevel.LeftMargin);
		method_10(levelIndex, rulerLevel.Indent);
	}

	public Class2975 method_1(int levelIndex)
	{
		if (levelIndex < 0 || levelIndex > 4)
		{
			throw new IndexOutOfRangeException("LevelIndex of textRuler level is out-of-range!!! [" + levelIndex + "]");
		}
		Class2975 @class = new Class2975();
		@class.LeftMargin = method_7(levelIndex);
		@class.Indent = method_9(levelIndex);
		return @class;
	}

	internal void method_2(BinaryReader reader)
	{
		uint_0 = reader.ReadUInt32();
		if (method_11(Enum447.const_1))
		{
			short_0 = reader.ReadInt16();
		}
		if (method_11(Enum447.const_0))
		{
			short_1 = reader.ReadInt16();
		}
		if (method_11(Enum447.const_2))
		{
			class2942_0 = new Class2942(reader);
		}
		if (method_11(Enum447.const_3))
		{
			short_2[0] = reader.ReadInt16();
		}
		if (method_11(Enum447.const_8))
		{
			short_3[0] = reader.ReadInt16();
		}
		if (method_11(Enum447.const_4))
		{
			short_2[1] = reader.ReadInt16();
		}
		if (method_11(Enum447.const_9))
		{
			short_3[1] = reader.ReadInt16();
		}
		if (method_11(Enum447.const_5))
		{
			short_2[2] = reader.ReadInt16();
		}
		if (method_11(Enum447.const_10))
		{
			short_3[2] = reader.ReadInt16();
		}
		if (method_11(Enum447.const_6))
		{
			short_2[3] = reader.ReadInt16();
		}
		if (method_11(Enum447.const_11))
		{
			short_3[3] = reader.ReadInt16();
		}
		if (method_11(Enum447.const_7))
		{
			short_2[4] = reader.ReadInt16();
		}
		if (method_11(Enum447.const_12))
		{
			short_3[4] = reader.ReadInt16();
		}
	}

	internal void method_3(BinaryWriter writer)
	{
		writer.Write(uint_0);
		if (method_11(Enum447.const_1))
		{
			writer.Write(short_0);
		}
		if (method_11(Enum447.const_0))
		{
			writer.Write(short_1);
		}
		if (method_11(Enum447.const_2))
		{
			class2942_0.method_3(writer);
		}
		if (method_11(Enum447.const_3))
		{
			writer.Write(short_2[0]);
		}
		if (method_11(Enum447.const_8))
		{
			writer.Write(short_3[0]);
		}
		if (method_11(Enum447.const_4))
		{
			writer.Write(short_2[1]);
		}
		if (method_11(Enum447.const_9))
		{
			writer.Write(short_3[1]);
		}
		if (method_11(Enum447.const_5))
		{
			writer.Write(short_2[2]);
		}
		if (method_11(Enum447.const_10))
		{
			writer.Write(short_3[2]);
		}
		if (method_11(Enum447.const_6))
		{
			writer.Write(short_2[3]);
		}
		if (method_11(Enum447.const_11))
		{
			writer.Write(short_3[3]);
		}
		if (method_11(Enum447.const_7))
		{
			writer.Write(short_2[4]);
		}
		if (method_11(Enum447.const_12))
		{
			writer.Write(short_3[4]);
		}
	}

	internal int method_4()
	{
		int num = 4;
		if (method_11(Enum447.const_1))
		{
			num += 2;
		}
		if (method_11(Enum447.const_0))
		{
			num += 2;
		}
		if (method_11(Enum447.const_2))
		{
			num += class2942_0.method_4();
		}
		if (method_11(Enum447.const_3))
		{
			num += 2;
		}
		if (method_11(Enum447.const_8))
		{
			num += 2;
		}
		if (method_11(Enum447.const_4))
		{
			num += 2;
		}
		if (method_11(Enum447.const_9))
		{
			num += 2;
		}
		if (method_11(Enum447.const_5))
		{
			num += 2;
		}
		if (method_11(Enum447.const_10))
		{
			num += 2;
		}
		if (method_11(Enum447.const_6))
		{
			num += 2;
		}
		if (method_11(Enum447.const_11))
		{
			num += 2;
		}
		if (method_11(Enum447.const_7))
		{
			num += 2;
		}
		if (method_11(Enum447.const_12))
		{
			num += 2;
		}
		return num;
	}

	public object Clone()
	{
		return MemberwiseClone();
	}

	private Enum447 method_5(int levelIndex)
	{
		if (levelIndex >= 0 && levelIndex <= 4)
		{
			return (Enum447)(4 << levelIndex + 1);
		}
		return (Enum447)0;
	}

	private Enum447 method_6(int levelIndex)
	{
		if (levelIndex >= 0 && levelIndex <= 4)
		{
			return (Enum447)(128 << levelIndex + 1);
		}
		return (Enum447)0;
	}

	private short? method_7(int levelIndex)
	{
		Enum447 mask = method_5(levelIndex);
		if (method_11(mask))
		{
			return short_2[levelIndex];
		}
		return null;
	}

	private void method_8(int levelIndex, short? value)
	{
		Enum447 @enum = method_5(levelIndex);
		if (@enum == (Enum447)0)
		{
			throw new ArgumentNullException();
		}
		if (value.HasValue)
		{
			short_2[levelIndex] = value.Value;
		}
		method_12(@enum, value.HasValue);
	}

	private short? method_9(int levelIndex)
	{
		Enum447 mask = method_6(levelIndex);
		if (method_11(mask))
		{
			return short_3[levelIndex];
		}
		return null;
	}

	private void method_10(int levelIndex, short? value)
	{
		Enum447 @enum = method_6(levelIndex);
		if (@enum == (Enum447)0)
		{
			throw new ArgumentNullException();
		}
		if (value.HasValue)
		{
			short_3[levelIndex] = value.Value;
		}
		method_12(@enum, value.HasValue);
	}

	private bool method_11(Enum447 mask)
	{
		return (uint_0 & (uint)mask) != 0;
	}

	private void method_12(Enum447 mask, bool condition)
	{
		uint_0 &= (uint)((Enum447)(-1) ^ mask);
		if (condition)
		{
			uint_0 |= (uint)mask;
		}
	}
}
