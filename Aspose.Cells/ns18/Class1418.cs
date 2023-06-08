using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using ns22;

namespace ns18;

internal abstract class Class1418
{
	private readonly Class1416 class1416_0;

	private MemoryStream memoryStream_0;

	private Class1420 class1420_0;

	private readonly Class1426 class1426_0;

	internal Class1418(Class1416 class1416_1, Class1426 class1426_1)
	{
		class1416_0 = class1416_1;
		class1426_0 = class1426_1;
	}

	internal void method_0(PointF pointF_0, SizeF sizeF_0)
	{
		class1416_0.method_3(class1416_0.method_4().Size);
		method_1().method_2(class1416_0.method_4().Size);
		memoryStream_0 = new MemoryStream();
		class1420_0 = new Class1420(memoryStream_0);
		method_7().Initialize(pointF_0, sizeF_0);
		for (int i = 0; i < method_2().method_8(); i++)
		{
			Class1424 @class = method_2().method_13(i);
			if (@class.method_4() > 0)
			{
				memoryStream_0.Write(@class.Data, 0, @class.method_4());
				memoryStream_0.Position -= @class.Data.Length;
			}
			vmethod_0(@class);
			if (@class.Type == Enum155.const_82)
			{
				break;
			}
		}
		memoryStream_0.Close();
	}

	[Attribute0(true)]
	protected abstract void vmethod_0(Class1424 class1424_0);

	[SpecialName]
	protected Class1407 method_1()
	{
		return class1416_0.method_5();
	}

	[SpecialName]
	protected Class1414 method_2()
	{
		return class1416_0.method_4();
	}

	[SpecialName]
	internal RectangleF method_3()
	{
		return class1416_0.method_6();
	}

	[SpecialName]
	internal PointF method_4()
	{
		return class1416_0.method_8();
	}

	[SpecialName]
	internal void method_5(PointF pointF_0)
	{
		class1416_0.method_9(pointF_0);
	}

	[SpecialName]
	internal Class1420 method_6()
	{
		return class1420_0;
	}

	[SpecialName]
	internal Class1426 method_7()
	{
		return class1426_0;
	}

	internal void method_8()
	{
		class1416_0.method_0();
	}

	internal void method_9()
	{
		class1416_0.method_1();
	}

	internal void method_10(Interface46 interface46_0)
	{
		class1416_0.method_10().Add(interface46_0);
	}

	internal void method_11(uint uint_0)
	{
		class1416_0.method_10().method_0(uint_0);
	}

	internal void method_12(SizeF sizeF_0)
	{
		class1416_0.method_3(sizeF_0);
	}

	internal void method_13(PointF pointF_0)
	{
		class1416_0.method_2(pointF_0);
	}
}
