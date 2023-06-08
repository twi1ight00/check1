using System.IO;
using ns60;

namespace ns63;

internal class Class2968 : Interface40
{
	private Class2973 class2973_0 = new Class2973();

	private Class2970 class2970_0 = new Class2970();

	private Class2977 class2977_0 = new Class2977();

	public Class2973 ParagraphFormat9 => class2973_0;

	public Class2970 CharFormat9 => class2970_0;

	public Class2977 SpecialInfo => class2977_0;

	internal void method_0(BinaryReader reader)
	{
		class2973_0.method_0(reader);
		class2970_0.method_0(reader);
		class2977_0.method_0(reader);
	}

	internal void method_1(BinaryWriter writer)
	{
		class2973_0.method_1(writer);
		class2970_0.method_1(writer);
		class2977_0.method_1(writer);
	}

	internal int method_2()
	{
		return class2973_0.method_2() + class2970_0.method_2() + class2977_0.method_2();
	}

	public bool method_3(Class2968 styleTextProp9)
	{
		if (!class2973_0.method_4(styleTextProp9.ParagraphFormat9))
		{
			return false;
		}
		if (!class2970_0.method_5(styleTextProp9.CharFormat9))
		{
			return false;
		}
		if (!class2977_0.method_4(styleTextProp9.SpecialInfo))
		{
			return false;
		}
		return true;
	}
}
