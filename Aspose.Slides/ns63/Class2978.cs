using System;
using System.IO;
using ns60;

namespace ns63;

internal sealed class Class2978 : IComparable, Interface40
{
	private short short_0;

	private Enum456 enum456_0;

	internal Class2942 class2942_0;

	public short Position
	{
		get
		{
			return short_0;
		}
		set
		{
			method_0(value);
		}
	}

	internal Class2942 ParentCollection
	{
		get
		{
			return class2942_0;
		}
		set
		{
			class2942_0 = value;
		}
	}

	public Enum456 TabType
	{
		get
		{
			return enum456_0;
		}
		set
		{
			enum456_0 = value;
		}
	}

	public Class2978(short position, Enum456 type)
	{
		short_0 = position;
		enum456_0 = type;
	}

	internal void method_0(short value)
	{
		if (short_0 != value)
		{
			Class2942 @class = class2942_0;
			@class.method_0(short_0);
			short_0 = value;
			@class.Add(this);
		}
	}

	internal Class2978(BinaryReader reader)
	{
		method_1(reader);
	}

	internal void method_1(BinaryReader reader)
	{
		short_0 = reader.ReadInt16();
		enum456_0 = (Enum456)reader.ReadUInt16();
	}

	internal void method_2(BinaryWriter writer)
	{
		writer.Write(short_0);
		writer.Write((ushort)enum456_0);
	}

	public int CompareTo(object obj)
	{
		return Position.CompareTo(((Class2978)obj).Position);
	}
}
