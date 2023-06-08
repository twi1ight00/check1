using System.IO;
using ns60;

namespace ns63;

internal class Class2866 : Class2623
{
	internal const int int_0 = 4114;

	private byte byte_0;

	private short short_0;

	private byte byte_1;

	private short short_1;

	public byte StartTrack
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

	public short StartTime
	{
		get
		{
			return short_0;
		}
		set
		{
			short_0 = value;
		}
	}

	public byte EndTrack
	{
		get
		{
			return byte_1;
		}
		set
		{
			byte_1 = value;
		}
	}

	public short EndTime
	{
		get
		{
			return short_1;
		}
		set
		{
			short_1 = value;
		}
	}

	internal Class2866()
	{
		base.Header.Type = 4114;
		base.Header.Instance = 1;
		base.Header.Version = 1;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		byte_0 = reader.ReadByte();
		short_0 = (short)(reader.ReadByte() * 60 + reader.ReadByte());
		reader.ReadByte();
		byte_1 = reader.ReadByte();
		short_1 = (short)(reader.ReadByte() * 60 + reader.ReadByte());
		reader.ReadByte();
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		writer.Write(byte_0);
		writer.Write((byte)(short_0 / 60));
		writer.Write((byte)(short_0 % 60));
		writer.Write((byte)0);
		writer.Write(EndTrack);
		writer.Write((byte)(short_1 / 60));
		writer.Write((byte)(short_1 % 60));
		writer.Write((byte)0);
	}

	public override int vmethod_2()
	{
		return 8;
	}
}
