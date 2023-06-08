using System.IO;
using ns60;

namespace ns63;

internal class Class2965 : Interface40
{
	private int int_0;

	private int int_1 = 1;

	public int Numer
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	public int Denom
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

	public Class2965()
	{
	}

	public Class2965(int numer, int denom)
	{
		int_0 = numer;
		int_1 = denom;
	}

	internal void method_0(BinaryReader reader)
	{
		int_0 = reader.ReadInt32();
		int_1 = reader.ReadInt32();
	}

	internal void method_1(BinaryWriter writer)
	{
		writer.Write(int_0);
		writer.Write(int_1);
	}

	internal int method_2()
	{
		return 8;
	}
}
