using System.Runtime.CompilerServices;
using Aspose.Cells.Drawing;

namespace ns21;

internal class Class1290
{
	internal Class1294 class1294_0;

	private LightRigType lightRigType_0;

	private Enum177 enum177_0;

	internal Class1290()
	{
		enum177_0 = Enum177.const_5;
		lightRigType_0 = LightRigType.ThreePoint;
	}

	[SpecialName]
	internal Class1294 method_0()
	{
		if (class1294_0 == null)
		{
			class1294_0 = new Class1294();
		}
		return class1294_0;
	}

	[SpecialName]
	internal LightRigType method_1()
	{
		return lightRigType_0;
	}

	[SpecialName]
	internal void method_2(LightRigType lightRigType_1)
	{
		lightRigType_0 = lightRigType_1;
	}

	[SpecialName]
	internal Enum177 method_3()
	{
		return enum177_0;
	}

	[SpecialName]
	internal void method_4(Enum177 enum177_1)
	{
		enum177_0 = enum177_1;
	}

	internal void Copy(Class1290 class1290_0)
	{
		lightRigType_0 = class1290_0.lightRigType_0;
		enum177_0 = class1290_0.enum177_0;
		if (class1290_0.class1294_0 != null)
		{
			class1294_0 = new Class1294();
			class1294_0.Copy(class1290_0.class1294_0);
		}
	}
}
