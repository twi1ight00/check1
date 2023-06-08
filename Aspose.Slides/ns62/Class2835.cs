using System.IO;
using ns60;

namespace ns62;

internal class Class2835 : Class2623
{
	internal const int int_0 = 61450;

	private uint uint_0;

	private int int_1;

	public uint Spid
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

	public bool FGroup
	{
		get
		{
			return (int_1 & 1) != 0;
		}
		set
		{
			int_1 |= 1;
			if (!value)
			{
				int_1 ^= 1;
			}
		}
	}

	public bool FChild
	{
		get
		{
			return (int_1 & 2) != 0;
		}
		set
		{
			int_1 |= 2;
			if (!value)
			{
				int_1 ^= 2;
			}
		}
	}

	public bool FPatriarch
	{
		get
		{
			return (int_1 & 4) != 0;
		}
		set
		{
			int_1 |= 4;
			if (!value)
			{
				int_1 ^= 4;
			}
		}
	}

	public bool FDeleted
	{
		get
		{
			return (int_1 & 8) != 0;
		}
		set
		{
			int_1 |= 8;
			if (!value)
			{
				int_1 ^= 8;
			}
		}
	}

	public bool FOleShape
	{
		get
		{
			return (int_1 & 0x10) != 0;
		}
		set
		{
			int_1 |= 16;
			if (!value)
			{
				int_1 ^= 16;
			}
		}
	}

	public bool FHaveMaster
	{
		get
		{
			return (int_1 & 0x20) != 0;
		}
		set
		{
			int_1 |= 32;
			if (!value)
			{
				int_1 ^= 32;
			}
		}
	}

	public bool FFlipH
	{
		get
		{
			return (int_1 & 0x40) != 0;
		}
		set
		{
			int_1 |= 64;
			if (!value)
			{
				int_1 ^= 64;
			}
		}
	}

	public bool FFlipV
	{
		get
		{
			return (int_1 & 0x80) != 0;
		}
		set
		{
			int_1 |= 128;
			if (!value)
			{
				int_1 ^= 128;
			}
		}
	}

	public bool FConnector
	{
		get
		{
			return (int_1 & 0x100) != 0;
		}
		set
		{
			int_1 |= 256;
			if (!value)
			{
				int_1 ^= 256;
			}
		}
	}

	public bool FHaveAnchor
	{
		get
		{
			return (int_1 & 0x200) != 0;
		}
		set
		{
			int_1 |= 512;
			if (!value)
			{
				int_1 ^= 512;
			}
		}
	}

	public bool FBackground
	{
		get
		{
			return (int_1 & 0x400) != 0;
		}
		set
		{
			int_1 |= 1024;
			if (!value)
			{
				int_1 ^= 1024;
			}
		}
	}

	public bool FHaveSpt
	{
		get
		{
			return (int_1 & 0x800) != 0;
		}
		set
		{
			int_1 |= 2048;
			if (!value)
			{
				int_1 ^= 2048;
			}
		}
	}

	public Enum425 ShapeType
	{
		get
		{
			return (Enum425)base.Header.Instance;
		}
		set
		{
			base.Header.Instance = (short)value;
		}
	}

	public Class2835()
		: base(61450, 2)
	{
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		uint_0 = reader.ReadUInt32();
		int_1 = reader.ReadInt32();
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		writer.Write(uint_0);
		writer.Write(int_1);
	}

	public override int vmethod_2()
	{
		return 8;
	}
}
