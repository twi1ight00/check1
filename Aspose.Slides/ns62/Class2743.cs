using System;
using System.IO;
using ns60;

namespace ns62;

internal class Class2743 : Class2623
{
	internal const int int_0 = 61448;

	private uint uint_0;

	private uint uint_1;

	public ushort DrawingId
	{
		get
		{
			return (ushort)base.Header.Instance;
		}
		set
		{
			if (value > 4079)
			{
				throw new ArgumentOutOfRangeException("value", "Value MUST be less than or equal to 0xFFE.");
			}
			base.Header.Instance = (short)value;
		}
	}

	public uint ShapeCount
	{
		get
		{
			return uint_0;
		}
		set
		{
			uint_0 = value;
		}
	}

	public uint SpidLast
	{
		get
		{
			return uint_1;
		}
		set
		{
			uint_1 = value;
		}
	}

	public Class2743()
		: base(61448, 0)
	{
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		uint_0 = reader.ReadUInt32();
		uint_1 = reader.ReadUInt32();
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		writer.Write(uint_0);
		writer.Write(uint_1);
	}

	public override int vmethod_2()
	{
		return 8;
	}
}
