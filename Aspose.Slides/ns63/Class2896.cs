using System.IO;
using ns60;

namespace ns63;

internal class Class2896 : Class2623
{
	internal const int int_0 = 1024;

	private uint uint_0;

	private int int_1;

	private int int_2 = 2;

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

	public bool FHasMacros
	{
		get
		{
			return int_1 == 1;
		}
		set
		{
			int_1 = (value ? 1 : 0);
		}
	}

	internal Class2896()
	{
		base.Header.Version = 2;
		base.Header.Type = 1024;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		uint_0 = reader.ReadUInt32();
		int_1 = reader.ReadInt32();
		int_2 = reader.ReadInt32();
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		writer.Write(uint_0);
		writer.Write(int_1);
		writer.Write(int_2);
	}

	public override int vmethod_2()
	{
		return 12;
	}
}
