using System.IO;
using Aspose.Slides;
using ns60;

namespace ns63;

internal class Class2909 : Class2623
{
	internal const int int_0 = 4004;

	private Class2971 class2971_0;

	public Class2971 CharFormat => class2971_0;

	public Class2909()
	{
		class2971_0 = new Class2971();
		base.Header.Type = 4004;
	}

	public void method_1()
	{
		class2971_0.Kumi = NullableBool.True;
		class2971_0.AnsiFontRef = ushort.MaxValue;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		class2971_0.method_0(reader);
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		class2971_0.method_1(writer);
	}

	public override int vmethod_2()
	{
		return class2971_0.method_2();
	}
}
