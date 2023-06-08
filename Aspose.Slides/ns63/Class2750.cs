using System.IO;
using ns60;
using ns64;

namespace ns63;

internal class Class2750 : Class2623
{
	internal const int int_0 = 61736;

	private uint uint_0;

	private uint uint_1;

	private uint uint_2;

	private int int_1;

	public Enum402 TriggerObject
	{
		get
		{
			return (Enum402)uint_0;
		}
		set
		{
			uint_0 = (uint)value;
		}
	}

	public uint TriggerEvent
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

	public uint Id
	{
		get
		{
			return uint_2;
		}
		set
		{
			uint_2 = value;
		}
	}

	public int Delay
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	public Class2750()
	{
		base.Header.Type = 61736;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		uint_0 = reader.ReadUInt32();
		uint_1 = reader.ReadUInt32();
		uint_2 = reader.ReadUInt32();
		int_1 = reader.ReadInt32();
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		writer.Write(uint_0);
		writer.Write(uint_1);
		writer.Write(uint_2);
		writer.Write(int_1);
	}

	public override int vmethod_2()
	{
		return 16;
	}
}
