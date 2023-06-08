using System.IO;

namespace ns63;

internal class Class2855 : Class2845
{
	public const int int_0 = 1011;

	private uint uint_0;

	private int int_1;

	private int int_2;

	private uint uint_1;

	private int int_3;

	public uint PersistIdRef
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

	public bool FShouldCollapse
	{
		get
		{
			return (int_1 & 2) == 2;
		}
		set
		{
			if (value)
			{
				int_1 |= 2;
			}
			else
			{
				int_1 &= -3;
			}
		}
	}

	public bool FNonOutlineData
	{
		get
		{
			return (int_1 & 4) == 4;
		}
		set
		{
			if (value)
			{
				int_1 |= 4;
			}
			else
			{
				int_1 &= -5;
			}
		}
	}

	public int CTexts
	{
		get
		{
			return int_2;
		}
		set
		{
			int_2 = value;
		}
	}

	public uint SlideId
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

	public Class2855(Class2951 subTextFrame)
		: base(subTextFrame)
	{
		base.Header.Type = 1011;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		uint_0 = reader.ReadUInt32();
		int_1 = reader.ReadInt32();
		int_2 = reader.ReadInt32();
		uint_1 = reader.ReadUInt32();
		int_3 = reader.ReadInt32();
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		writer.Write(uint_0);
		writer.Write(int_1);
		writer.Write(int_2);
		writer.Write(uint_1);
		writer.Write(int_3);
	}

	public override int vmethod_2()
	{
		return 20;
	}
}
