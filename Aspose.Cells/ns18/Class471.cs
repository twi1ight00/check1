using System.IO;

namespace ns18;

internal class Class471 : Class468
{
	private readonly Class1050 class1050_0;

	private readonly Class1060 class1060_0;

	public Class471(Stream stream_0)
	{
		class1050_0 = new Class1050(stream_0);
		class1060_0 = new Class1060(class1050_0);
	}

	public override void vmethod_0(Class452 class452_0)
	{
		class452_0.vmethod_0(this);
	}

	public override void vmethod_16()
	{
		class1060_0.method_0();
		class1050_0.method_3();
	}

	public override void vmethod_1(Class457 class457_0)
	{
		class1060_0.method_1(class457_0.Width, class457_0.Height);
		class1060_0.method_3(class457_0.Size);
	}

	public override void vmethod_2(Class457 class457_0)
	{
		class1060_0.method_2();
	}

	public override void vmethod_3(Class454 class454_0)
	{
		class1060_0.method_9().method_2(class454_0);
	}

	public override void vmethod_4(Class454 class454_0)
	{
		class1060_0.method_9().method_3();
	}

	public override void vmethod_5(Class463 class463_0)
	{
		class1060_0.method_9().method_7(class463_0);
	}

	public override void vmethod_6(Class458 class458_0)
	{
		class1060_0.method_9().method_4(class458_0);
	}

	public override void vmethod_7(Class458 class458_0)
	{
		class1060_0.method_9().method_5();
	}

	public override void vmethod_15(Class460 class460_0)
	{
		Class458 @class = Class458.smethod_3(class460_0.pointF_0, class460_0.pointF_1);
		@class.class770_0 = class460_0.class770_0;
		@class.vmethod_0(this);
		@class = null;
	}

	public override void vmethod_13(Class465 class465_0)
	{
		if (class465_0 != null)
		{
			if (class465_0.ImageType != Enum200.const_1 && class465_0.ImageType != Enum200.const_2)
			{
				class1060_0.method_9().method_6(class465_0);
				return;
			}
			Class454 @class = Class1422.smethod_0(class465_0);
			@class.method_2(class465_0.Hyperlink);
			@class.vmethod_0(this);
		}
	}
}
