using System;

namespace ns62;

internal class Class2954 : Class2953
{
	private readonly Enum430 enum430_0;

	public Enum430 Escape => enum430_0;

	public override ushort Value
	{
		get
		{
			ushort num = (ushort)((int)(base.Type & (Enum431)7) << 13);
			num = (ushort)(num | (ushort)((int)(Escape & (Enum430)31) << 8));
			return (ushort)(num | (ushort)(base.Segments & 0xFFu));
		}
	}

	public Class2954(Enum431 type, Enum430 escape, byte segments)
		: base(type, segments, foo: true)
	{
		enum430_0 = escape;
		if (type != Enum431.const_5 && type != Enum431.const_6)
		{
			throw new ArgumentException("Path type can be Escape (0x5) or ClientEscape (0x6).", "type");
		}
	}

	public override string ToString()
	{
		return $"EsPathEscapeInfoStructure: Type: {base.Type}, Segments: {base.Segments}, Escape: {Escape}.";
	}
}
