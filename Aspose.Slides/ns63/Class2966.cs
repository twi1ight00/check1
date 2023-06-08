using System;
using System.Drawing;
using ns33;
using ns60;

namespace ns63;

internal class Class2966 : ICloneable, Interface40
{
	public enum Enum441 : uint
	{
		const_0 = 0u,
		const_1 = 1u,
		const_2 = 2u,
		const_3 = 3u,
		const_4 = 4u,
		const_5 = 5u,
		const_6 = 6u,
		const_7 = 7u,
		const_8 = 254u,
		const_9 = 255u
	}

	private Color color_0;

	private Enum441 enum441_0;

	public Color Color
	{
		get
		{
			return color_0;
		}
		set
		{
			color_0 = value;
		}
	}

	public Enum441 Index
	{
		get
		{
			return enum441_0;
		}
		set
		{
			enum441_0 = value;
		}
	}

	public uint Struct => ((uint)Index << 24) | Class1165.smethod_9(Color);

	public Class2966(Enum441 index, Color color)
	{
		Color = color;
		Index = index;
	}

	public Class2966(uint colorStruct)
	{
		Color = Class1165.smethod_7(colorStruct & 0xFFFFFFu);
		Index = (Enum441)(colorStruct >> 24);
	}

	public override string ToString()
	{
		return $"ColorIndexStruct: Color: {Color}, Index: {Index}, Struct: 0x{Struct:X}";
	}

	public object Clone()
	{
		return new Class2966(Index, Color);
	}
}
