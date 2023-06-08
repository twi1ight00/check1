using System.IO;
using ns60;

namespace ns63;

internal class Class2885 : Class2623
{
	internal const int int_0 = 3011;

	private int int_1;

	private Enum384 enum384_0;

	private Enum385 enum385_0;

	private short short_0;

	public int Position
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

	public Enum384 PlacementId
	{
		get
		{
			return enum384_0;
		}
		set
		{
			enum384_0 = value;
		}
	}

	public Enum385 Size
	{
		get
		{
			return enum385_0;
		}
		set
		{
			enum385_0 = value;
		}
	}

	public Class2885()
	{
		base.Header.Type = 3011;
		base.Header.Version = 0;
		base.Header.Instance = 0;
		short_0 = 0;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		int_1 = reader.ReadInt32();
		enum384_0 = (Enum384)reader.ReadByte();
		enum385_0 = (Enum385)reader.ReadByte();
		short_0 = reader.ReadInt16();
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		writer.Write(int_1);
		writer.Write((byte)enum384_0);
		writer.Write((byte)enum385_0);
		writer.Write(short_0);
	}

	public override int vmethod_2()
	{
		return 8;
	}
}
