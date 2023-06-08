using System.IO;
using System.Runtime.CompilerServices;

namespace ns18;

internal class Class473 : Class468
{
	private Class1442 class1442_0;

	public Class473(Stream stream_0, Class1448 class1448_0)
	{
		class1442_0 = new Class1442(stream_0, class1448_0);
	}

	public override void vmethod_0(Class452 class452_0)
	{
		class452_0.vmethod_0(this);
	}

	public override void vmethod_16()
	{
		class1442_0.method_0();
	}

	public override void vmethod_1(Class457 class457_0)
	{
		class1442_0.method_2(class457_0.Size);
	}

	public override void vmethod_2(Class457 class457_0)
	{
		class1442_0.method_3();
	}

	public override void vmethod_3(Class454 class454_0)
	{
		class1442_0.method_8().method_5(class454_0);
	}

	public override void vmethod_4(Class454 class454_0)
	{
		class1442_0.method_8().method_6(class454_0);
	}

	public override void vmethod_5(Class463 class463_0)
	{
		class1442_0.method_8().method_7(class463_0);
	}

	public override void vmethod_6(Class458 class458_0)
	{
		class1442_0.method_8().method_8(class458_0);
	}

	public override void vmethod_7(Class458 class458_0)
	{
		class1442_0.method_8().method_9(class458_0);
	}

	public override void vmethod_8(Class459 class459_0)
	{
		class1442_0.method_8().method_10(class459_0);
	}

	public override void vmethod_9(Class459 class459_0)
	{
		class1442_0.method_8().method_11(class459_0);
	}

	public override void vmethod_10(Class467 class467_0)
	{
		class1442_0.method_8().method_12(class467_0);
	}

	public override void vmethod_11(Class466 class466_0)
	{
		class1442_0.method_8().method_13(class466_0);
	}

	public override void vmethod_12(Class462 class462_0)
	{
		class1442_0.method_8().method_14(class462_0);
	}

	public override void vmethod_14(Class464 class464_0)
	{
		class1442_0.method_8().AddHyperlink(class464_0);
	}

	public override void vmethod_13(Class465 class465_0)
	{
		if (class465_0.Hyperlink != null)
		{
			vmethod_14(class465_0.Hyperlink);
		}
		switch (class465_0.ImageType)
		{
		case Enum200.const_1:
		case Enum200.const_2:
		{
			Class454 @class = Class1422.smethod_0(class465_0);
			@class.method_2(class465_0.Hyperlink);
			@class.vmethod_0(this);
			break;
		}
		case Enum200.const_3:
			break;
		case Enum200.const_0:
		case Enum200.const_4:
		case Enum200.const_5:
		case Enum200.const_6:
		case Enum200.const_7:
		case Enum200.const_8:
			class1442_0.method_8().method_15(class465_0);
			break;
		}
	}

	public override void vmethod_15(Class460 class460_0)
	{
		class1442_0.method_8().AddLine(class460_0);
	}

	[SpecialName]
	public Class1442 method_2()
	{
		return class1442_0;
	}
}
