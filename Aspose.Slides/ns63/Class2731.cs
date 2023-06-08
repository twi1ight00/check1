using System.Collections.Generic;
using System.IO;

namespace ns63;

internal sealed class Class2731 : Class2639
{
	public const int int_0 = 4080;

	private Class2982 class2982_0;

	private List<Class2951> list_1;

	public static byte[] byte_0 = new byte[28]
	{
		0, 0, 243, 3, 20, 0, 0, 0, 6, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 1, 0, 0, 0, 0, 0, 0
	};

	public static byte[] byte_1 = new byte[20]
	{
		6, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 1, 0, 0, 0, 0, 0, 0
	};

	public List<Class2951> SubTextFrames => list_1;

	public Class2982 ContentRecords => class2982_0;

	public Class2731()
	{
		base.Header.Type = 4080;
		list_1 = new List<Class2951>();
		class2982_0 = new Class2982(this, list_1);
	}

	internal void method_5(int index)
	{
		class2982_0 = new Class2982(this);
		switch (index)
		{
		case 0:
		{
			Class2855 @class = new Class2855(null);
			@class.Header.Version = 0;
			@class.Header.Instance = 0;
			@class.PersistIdRef = 2u;
			@class.SlideId = 2147483648u;
			class2982_0.method_2(@class);
			break;
		}
		case 1:
		{
			Class2855 @class = new Class2855(null);
			@class.Header.Version = 0;
			@class.Header.Instance = 0;
			@class.PersistIdRef = 3u;
			@class.CTexts = 2;
			@class.SlideId = 256u;
			class2982_0.method_2(@class);
			Class2859 class2 = new Class2859(null);
			class2.Header.Version = 0;
			class2.Header.Instance = 0;
			class2.TextType = Enum449.const_5;
			class2982_0.method_2(class2);
			Class2861 class3 = new Class2861(null);
			class3.Header.Version = 0;
			class3.Header.Instance = 0;
			Class2986 class4 = new Class2986();
			class4.Count = 1u;
			class4.SpecialInfo.SpellInfo = new Class2967();
			class4.SpecialInfo.method_3(1u);
			class3.RgTextSIRun = new Class2986[1] { class4 };
			class2982_0.method_2(class3);
			class2 = new Class2859(null);
			class2.Header.Version = 0;
			class2.Header.Instance = 1;
			class2.TextType = Enum449.const_4;
			class2982_0.method_2(class2);
			class3 = new Class2861(null);
			class3.Header.Version = 0;
			class3.Header.Instance = 0;
			class4 = new Class2986();
			class4.Count = 1u;
			class4.SpecialInfo.SpellInfo = new Class2967();
			class4.SpecialInfo.method_3(1u);
			class3.RgTextSIRun = new Class2986[1] { class4 };
			class2982_0.method_2(class3);
			break;
		}
		}
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		class2982_0.method_6(reader, base.Header.Length);
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		class2982_0.method_7(writer);
	}

	public override int vmethod_2()
	{
		return class2982_0.method_8();
	}
}
