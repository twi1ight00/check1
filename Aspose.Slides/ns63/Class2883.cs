using System.IO;
using ns60;

namespace ns63;

internal class Class2883 : Class2623
{
	internal const int int_0 = 1042;

	internal uint[] uint_0;

	public uint[] RgSlideIdRef
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

	internal Class2883()
	{
		base.Header.Type = 1042;
		base.Header.Instance = 0;
	}

	public override int vmethod_2()
	{
		return uint_0.Length * 4;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		uint_0 = new uint[base.Header.Length / 4];
		for (int i = 0; i < uint_0.Length; i++)
		{
			uint_0[i] = reader.ReadUInt32();
		}
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		for (int i = 0; i < uint_0.Length; i++)
		{
			writer.Write(uint_0[i]);
		}
	}
}
