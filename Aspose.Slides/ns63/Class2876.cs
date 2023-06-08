using System.IO;
using ns60;
using ns62;

namespace ns63;

internal class Class2876 : Class2623
{
	internal const int int_0 = 2041;

	private byte byte_0;

	private Class2628 class2628_0;

	public byte WinBlipType
	{
		get
		{
			return byte_0;
		}
		set
		{
			byte_0 = value;
		}
	}

	public Class2628 Blip
	{
		get
		{
			return class2628_0;
		}
		set
		{
			class2628_0 = value;
		}
	}

	public Class2876()
	{
		base.Header.Type = 2041;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		WinBlipType = reader.ReadByte();
		reader.ReadByte();
		MemoryStream input = new MemoryStream(reader.ReadBytes(base.Header.Length - 2), writable: false);
		BinaryReader binaryReader = new BinaryReader(input);
		class2628_0 = (Class2629)Class2950.smethod_1(binaryReader, null);
		binaryReader.Close();
	}

	public override int vmethod_2()
	{
		return 2 + class2628_0.vmethod_2() + 8;
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		ushort value = 0;
		if (class2628_0 is Class2629)
		{
			value = (ushort)((uint)((Class2629)class2628_0).BlipType * 257u);
		}
		writer.Write(value);
		class2628_0.Write(writer);
	}
}
