using System.IO;

namespace ns63;

internal class Class2860 : Class2845
{
	public const int int_0 = 4006;

	private Class2981 class2981_0 = new Class2981();

	public Class2981 TextRuler
	{
		get
		{
			return class2981_0;
		}
		set
		{
			class2981_0 = value;
		}
	}

	public Class2860(Class2951 stf)
		: base(stf)
	{
		base.Header.Type = 4006;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		class2981_0.method_2(reader);
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		class2981_0.method_3(writer);
	}

	public override int vmethod_2()
	{
		return class2981_0.method_4();
	}
}
