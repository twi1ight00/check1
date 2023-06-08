using System.IO;
using ns60;

namespace ns63;

internal class Class2979 : Interface40
{
	private Enum444 enum444_0;

	private short short_0;

	public Enum444 Scheme => enum444_0;

	public short StartNum => short_0;

	public Class2979()
	{
		enum444_0 = Enum444.const_0;
		short_0 = 1;
	}

	public Class2979(Enum444 scheme, short startNum)
	{
		enum444_0 = scheme;
		short_0 = startNum;
	}

	internal void method_0(BinaryReader reader)
	{
		enum444_0 = (Enum444)reader.ReadInt16();
		short_0 = reader.ReadInt16();
	}

	internal void method_1(BinaryWriter writer)
	{
		writer.Write((short)enum444_0);
		writer.Write(short_0);
	}

	internal int method_2()
	{
		return 4;
	}

	internal bool method_3(Class2979 textAutoNumberScheme)
	{
		if (enum444_0 != textAutoNumberScheme.enum444_0)
		{
			return false;
		}
		if (short_0 != textAutoNumberScheme.short_0)
		{
			return false;
		}
		return true;
	}

	public override string ToString()
	{
		return string.Concat("[ Scheme: ", enum444_0, " / StartNum: ", short_0, " ]");
	}
}
