using System.IO;
using ns60;

namespace ns63;

internal class Class2878 : Class2623
{
	internal const int int_0 = 4115;

	private uint uint_0;

	private int int_1;

	public uint SoundIdRef
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

	public int SoundLength
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

	internal Class2878()
	{
		base.Header.Type = 4115;
		base.Header.Instance = 1;
		base.Header.Version = 1;
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
