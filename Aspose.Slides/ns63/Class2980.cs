using System.IO;
using ns60;

namespace ns63;

internal class Class2980 : Interface40
{
	private readonly Class2973 class2973_0 = new Class2973();

	private readonly Class2970 class2970_0 = new Class2970();

	public Class2973 ParagraphFormat9 => class2973_0;

	public Class2970 CharFormat9 => class2970_0;

	internal void method_0(BinaryReader reader)
	{
		class2973_0.method_0(reader);
		class2970_0.method_0(reader);
	}

	internal void method_1(BinaryWriter writer)
	{
		class2973_0.method_1(writer);
		class2970_0.method_1(writer);
	}

	internal int method_2()
	{
		int num = 0;
		num = 0 + class2973_0.method_2();
		return num + class2970_0.method_2();
	}
}
