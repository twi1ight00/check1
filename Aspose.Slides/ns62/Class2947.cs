using System.IO;
using ns60;

namespace ns62;

internal class Class2947 : Interface40
{
	private uint uint_0;

	private uint uint_1;

	public uint Dgid
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

	public uint CspidCur
	{
		get
		{
			return uint_1;
		}
		set
		{
			uint_1 = value;
		}
	}

	public Class2947(uint dgid, uint cspidCur)
	{
		uint_0 = dgid;
		uint_1 = cspidCur;
	}

	public override string ToString()
	{
		return $"OfficeArtIDCL, dgid:{uint_0}, cspidCur:{uint_1}";
	}

	internal Class2947(BinaryReader reader)
	{
		uint_0 = reader.ReadUInt32();
		uint_1 = reader.ReadUInt32();
	}

	internal void Write(BinaryWriter writer)
	{
		writer.Write(uint_0);
		writer.Write(uint_1);
	}

	internal virtual int vmethod_0()
	{
		return 8;
	}
}
