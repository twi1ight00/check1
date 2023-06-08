using System;
using System.Runtime.CompilerServices;
using ns47;

namespace ns18;

internal class Class1058 : Class1057
{
	private readonly Class1050 class1050_0;

	private Class1051 class1051_0;

	internal Class1058(Class1050 class1050_1)
		: base("/Resources")
	{
		class1050_0 = class1050_1;
	}

	internal override string vmethod_0(Class1460 class1460_0)
	{
		string text = base.vmethod_0(class1460_0);
		class1051_0.method_3().Add("http://schemas.microsoft.com/xps/2005/06/required-resource", text, bool_0: false);
		return text;
	}

	internal override Class1063 vmethod_1(byte[] byte_0)
	{
		Class1063 @class = base.vmethod_1(byte_0);
		class1051_0.method_3().Add("http://schemas.microsoft.com/xps/2005/06/required-resource", @class.Uri, bool_0: false);
		return @class;
	}

	internal override void vmethod_2()
	{
		foreach (object key in method_9().Keys)
		{
			class1050_0.method_0().Add(Class1062.smethod_0((Class1077)method_9()[key], (string)key));
		}
		foreach (object key2 in method_10().Keys)
		{
			Class1051 @class = smethod_1((Class1063)method_10()[key2]);
			class1050_0.method_0().Add(@class);
		}
	}

	internal void method_11(int int_2)
	{
		Class1051 @class = new Class1051($"/Documents/1/Pages/{int_2}.fpage", "application/vnd.ms-package.xps-fixedpage+xml");
		class1051_0 = @class;
	}

	internal void method_12()
	{
		class1050_0.method_0().Add(class1051_0);
	}

	private static Class1051 smethod_1(Class1063 class1063_0)
	{
		Enum200 enum200_ = Class1404.smethod_1(class1063_0.method_0());
		Class1051 @class = new Class1051(class1063_0.Uri, smethod_2(enum200_));
		@class.method_1().Write(class1063_0.method_0(), 0, class1063_0.method_0().Length);
		return @class;
	}

	private static string smethod_2(Enum200 enum200_0)
	{
		return enum200_0 switch
		{
			Enum200.const_4 => "image/jpeg", 
			Enum200.const_5 => "image/png", 
			Enum200.const_8 => "image/tiff", 
			_ => throw new InvalidOperationException("Unexpected image type."), 
		};
	}

	[SpecialName]
	internal Class1051 method_13()
	{
		return class1051_0;
	}
}
