using System.IO;
using ns60;

namespace ns63;

internal class Class2986 : Interface40
{
	private uint uint_0;

	private Class2977 class2977_0 = new Class2977();

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

	public Class2977 SpecialInfo
	{
		get
		{
			return class2977_0;
		}
		set
		{
			class2977_0 = value;
		}
	}

	internal void method_0(BinaryReader reader)
	{
		uint_0 = reader.ReadUInt32();
		class2977_0 = new Class2977();
		class2977_0.method_0(reader);
	}

	internal void method_1(BinaryWriter writer)
	{
		writer.Write(uint_0);
		class2977_0.method_1(writer);
	}

	internal int method_2()
	{
		return 4 + class2977_0.method_2();
	}

	internal bool method_3(Class2986 textSIRun)
	{
		return class2977_0.method_4(textSIRun.class2977_0);
	}
}
