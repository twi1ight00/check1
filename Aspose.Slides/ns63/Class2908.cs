using System.IO;
using Aspose.Slides;
using ns60;

namespace ns63;

internal class Class2908 : Class2623
{
	internal const int int_0 = 4005;

	private Class2974 class2974_0 = new Class2974();

	public Class2974 ParagraphFormat
	{
		get
		{
			return class2974_0;
		}
		set
		{
			class2974_0 = value;
		}
	}

	public Class2908()
	{
		base.Header.Type = 4005;
	}

	public void method_1()
	{
		class2974_0.TextAlignment = Enum455.const_1;
		class2974_0.CharWrap = NullableBool.True;
		class2974_0.WordWrap = NullableBool.True;
		class2974_0.Overflow = NullableBool.True;
		class2974_0.TextDirection = Enum445.const_0;
		class2974_0.method_3(3016704u);
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		reader.ReadInt16();
		class2974_0.method_0(reader);
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		writer.Write((short)0);
		class2974_0.method_1(writer);
	}

	public override int vmethod_2()
	{
		return 2 + class2974_0.method_2();
	}
}
