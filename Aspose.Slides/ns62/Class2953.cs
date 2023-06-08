using System;

namespace ns62;

internal class Class2953
{
	private readonly Enum431 enum431_0;

	private readonly byte byte_0;

	public byte Segments => byte_0;

	public Enum431 Type => enum431_0;

	public virtual ushort Value
	{
		get
		{
			ushort num = (ushort)((int)(Type & (Enum431)7) << 13);
			return (ushort)(num | (Segments & 0xFFu));
		}
	}

	public static Class2953 smethod_0(ushort data)
	{
		int num = data >> 13;
		int num2 = (data >> 8) & 0x1F;
		if (!Enum.IsDefined(typeof(Enum431), num))
		{
			throw new ArgumentException("Unknown path type.", "data");
		}
		if (!Enum.IsDefined(typeof(Enum430), num2))
		{
			throw new ArgumentException("Unknown path escape", "data");
		}
		Enum431 @enum = (Enum431)num;
		Enum430 escape = (Enum430)num2;
		byte segments = (byte)(data & 0xFFu);
		if (@enum != Enum431.const_5 && @enum != Enum431.const_6)
		{
			return new Class2953(@enum, segments);
		}
		return new Class2954(@enum, escape, segments);
	}

	public Class2953(Enum431 type, byte segments)
	{
		if (type == Enum431.const_5 || type == Enum431.const_6)
		{
			throw new ArgumentException("Path type can't be Escape (0x5) and ClientEscape (0x6) in MSPATHINFO structure.", "type");
		}
		enum431_0 = type;
		byte_0 = segments;
	}

	public override string ToString()
	{
		return $"EsPathInfoStructure: Type: {Type}, Segments: {Segments}.";
	}

	protected Class2953(Enum431 escapeType, byte segments, bool foo)
	{
		enum431_0 = escapeType;
		byte_0 = segments;
	}
}
