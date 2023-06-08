using System.IO;

namespace ns62;

internal class Class2946
{
	private uint uint_0;

	private uint uint_1;

	private uint uint_2;

	private uint uint_3;

	public uint SpidMax
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

	public uint Cidcl
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

	public uint CspSaved
	{
		get
		{
			return uint_2;
		}
		set
		{
			uint_2 = value;
		}
	}

	public uint CdgSaved
	{
		get
		{
			return uint_3;
		}
		set
		{
			uint_3 = value;
		}
	}

	public Class2946()
	{
	}

	public Class2946(uint spidMax, uint cidcl, uint cspSaved, uint cdgSaved)
	{
		SpidMax = spidMax;
		Cidcl = cidcl;
		CspSaved = cspSaved;
		CdgSaved = cdgSaved;
	}

	internal void method_0(BinaryReader reader)
	{
		SpidMax = reader.ReadUInt32();
		Cidcl = reader.ReadUInt32();
		CspSaved = reader.ReadUInt32();
		CdgSaved = reader.ReadUInt32();
	}

	internal void method_1(BinaryWriter writer)
	{
		writer.Write(SpidMax);
		writer.Write(Cidcl);
		writer.Write(CspSaved);
		writer.Write(CdgSaved);
	}

	internal int method_2()
	{
		return 16;
	}
}
