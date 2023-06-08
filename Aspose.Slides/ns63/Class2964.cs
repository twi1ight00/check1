using System.IO;
using ns60;

namespace ns63;

internal class Class2964 : Interface40
{
	private Class2965 class2965_0 = new Class2965();

	private Class2965 class2965_1 = new Class2965();

	public Class2965 X
	{
		get
		{
			return class2965_0;
		}
		set
		{
			class2965_0 = value;
		}
	}

	public Class2965 Y
	{
		get
		{
			return class2965_1;
		}
		set
		{
			class2965_1 = value;
		}
	}

	internal void method_0(BinaryReader reader)
	{
		class2965_0.method_0(reader);
		class2965_1.method_0(reader);
	}

	internal void method_1(BinaryWriter writer)
	{
		class2965_0.method_1(writer);
		class2965_1.method_1(writer);
	}

	internal int method_2()
	{
		return 16;
	}
}
