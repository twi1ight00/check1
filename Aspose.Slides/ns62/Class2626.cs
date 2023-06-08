using System.IO;

namespace ns62;

internal class Class2626 : Class2624
{
	internal const int int_0 = 61458;

	private uint uint_0;

	private uint uint_1;

	private uint uint_2;

	private uint uint_3;

	private uint uint_4;

	private uint uint_5;

	public uint RuleId
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

	public uint ShapeA
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

	public uint ShapeB
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

	public uint ConnectorId
	{
		get
		{
			return uint_3;
		}
		set
		{
			uint_3 = value;
		}
	}

	public int ConnectionPointA
	{
		get
		{
			return (int)uint_4;
		}
		set
		{
			uint_4 = (uint)value;
		}
	}

	public int ConnectionPointB
	{
		get
		{
			return (int)uint_5;
		}
		set
		{
			uint_5 = (uint)value;
		}
	}

	internal Class2626()
		: base(61458, 0)
	{
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		uint_0 = reader.ReadUInt32();
		uint_1 = reader.ReadUInt32();
		uint_2 = reader.ReadUInt32();
		uint_3 = reader.ReadUInt32();
		uint_4 = reader.ReadUInt32();
		uint_5 = reader.ReadUInt32();
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		writer.Write(uint_0);
		writer.Write(uint_1);
		writer.Write(uint_2);
		writer.Write(uint_3);
		writer.Write(uint_4);
		writer.Write(uint_5);
	}

	public override int vmethod_2()
	{
		return 24;
	}
}
