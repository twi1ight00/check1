using System.IO;

namespace ns63;

internal class Class2863 : Class2845
{
	public const int int_0 = 4007;

	private int int_1;

	private int int_2;

	private uint uint_0;

	public int Begin
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

	public int End
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

	public uint BookmarkId
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

	public Class2863(Class2951 stf)
		: base(stf)
	{
		base.Header.Type = 4007;
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		writer.Write(int_1);
		writer.Write(int_2);
		writer.Write(uint_0);
	}

	public override int vmethod_2()
	{
		return 12;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		int_1 = reader.ReadInt32();
		int_2 = reader.ReadInt32();
		uint_0 = reader.ReadUInt32();
	}
}
