using System.IO;

namespace ns62;

internal class Class2911 : Class2910
{
	private uint uint_0;

	public uint Value
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

	public Class2911(Enum426 id, uint value)
		: base(id, isBid: false)
	{
		uint_0 = value;
	}

	public Class2911(Enum426 id, bool isBid, uint value)
		: base(id, isBid)
	{
		uint_0 = value;
	}

	internal override void Write(BinaryWriter writer)
	{
		int id = (int)base.Id;
		id |= (base.IsBid ? 16384 : 0);
		writer.Write((short)id);
		writer.Write(uint_0);
	}

	internal override int vmethod_0()
	{
		return 6;
	}
}
