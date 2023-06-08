using System.IO;
using ns60;

namespace ns63;

internal class Class2907 : Class2623
{
	internal const int int_0 = 4009;

	private readonly Class2977 class2977_0;

	public Class2977 SpecialInfo => class2977_0;

	public Class2907()
	{
		base.Header.Version = 0;
		base.Header.Instance = 0;
		base.Header.Type = 4009;
		class2977_0 = new Class2977();
	}

	internal void method_1()
	{
		class2977_0.SpellInfo = new Class2967(error: false, clean: true, grammar: false);
		class2977_0.Lid = 1049;
		class2977_0.AltLid = 0;
		class2977_0.method_3(7u);
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		class2977_0.method_0(reader);
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		class2977_0.method_1(writer);
	}

	public override int vmethod_2()
	{
		return class2977_0.method_2();
	}
}
