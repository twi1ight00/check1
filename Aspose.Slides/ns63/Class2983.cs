using System.IO;
using ns60;

namespace ns63;

internal class Class2983 : Interface40
{
	private uint uint_0;

	private Class2971 class2971_0 = new Class2971();

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

	public Class2971 CharFormat
	{
		get
		{
			return class2971_0;
		}
		set
		{
			class2971_0 = value;
		}
	}

	internal void method_0(BinaryReader reader)
	{
		uint_0 = reader.ReadUInt32();
		class2971_0 = new Class2971();
		class2971_0.method_0(reader);
	}

	internal void method_1(BinaryWriter writer)
	{
		writer.Write(uint_0);
		class2971_0.method_1(writer);
	}

	internal int method_2()
	{
		return 4 + class2971_0.method_2();
	}

	internal bool method_3(Class2983 textCFRun)
	{
		return class2971_0.method_5(textCFRun.class2971_0);
	}
}
