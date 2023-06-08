using System.IO;
using ns60;

namespace ns63;

internal class Class2961 : Interface40
{
	private uint uint_0;

	private ushort ushort_0;

	public uint Count
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

	public ushort IndentLevel
	{
		get
		{
			return ushort_0;
		}
		set
		{
			ushort_0 = value;
		}
	}

	public Class2961(uint count, ushort indent)
	{
		uint_0 = count;
		ushort_0 = indent;
	}

	internal Class2961(BinaryReader reader)
	{
		uint_0 = reader.ReadUInt32();
		ushort_0 = reader.ReadUInt16();
	}

	internal void method_0(BinaryWriter writer)
	{
		writer.Write(uint_0);
		writer.Write(ushort_0);
	}
}
