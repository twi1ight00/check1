using System.IO;

namespace ns63;

internal class Class2847 : Class2846
{
	public const int int_1 = 4087;

	private byte byte_0;

	public byte Index
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

	public Class2847(Class2951 stf)
		: base(stf)
	{
		base.Header.Type = 4087;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		base.Position = reader.ReadInt32();
		byte_0 = reader.ReadByte();
		reader.ReadByte();
		reader.ReadByte();
		reader.ReadByte();
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		writer.Write(base.Position);
		writer.Write(byte_0);
		writer.Write((byte)0);
		writer.Write((byte)0);
		writer.Write((byte)0);
	}

	public override int vmethod_2()
	{
		return 8;
	}
}
