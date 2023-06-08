using System.IO;
using ns60;

namespace ns63;

internal class Class2871 : Class2623
{
	public enum Enum406
	{
		const_0 = 1,
		const_1 = 3
	}

	internal const int int_0 = 4049;

	private uint uint_0;

	private Enum406 enum406_0;

	public uint SlideIdRef
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

	public Enum406 OleUpdateMode
	{
		get
		{
			return enum406_0;
		}
		set
		{
			enum406_0 = value;
		}
	}

	public Class2871()
	{
		base.Header.Type = 4049;
		uint_0 = 0u;
		enum406_0 = Enum406.const_0;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		uint_0 = reader.ReadUInt32();
		enum406_0 = (Enum406)reader.ReadInt32();
		reader.ReadInt32();
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		writer.Write(uint_0);
		writer.Write((int)enum406_0);
		writer.Write(0);
	}

	public override int vmethod_2()
	{
		return 12;
	}
}
