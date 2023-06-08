using System.Runtime.CompilerServices;
using Aspose.Cells.Rendering;

namespace ns18;

internal class Class953 : Class938
{
	private float float_0 = 1f;

	private float float_1 = 1f;

	internal Class953(Class1440 class1440_1)
		: base(class1440_1)
	{
	}

	public override void vmethod_1(Class1447 class1447_0)
	{
		class1447_0.method_24(this);
		class1447_0.method_9();
		class1447_0.method_11("/Type", "/ExtGState");
		if (class1440_0.method_1().Compliance == PdfCompliance.PdfA1b)
		{
			class1447_0.method_11("/CA", "1.0");
			class1447_0.method_11("/ca", "1.0");
		}
		else
		{
			class1447_0.method_17("/CA", float_0);
			class1447_0.method_17("/ca", float_1);
		}
		class1447_0.method_10();
		class1447_0.method_25();
	}

	internal bool Equals(Class953 class953_0)
	{
		if (class953_0 != null && method_4() == class953_0.method_4())
		{
			return method_6() == class953_0.method_6();
		}
		return false;
	}

	[SpecialName]
	internal override Enum209 vmethod_0()
	{
		return Enum209.const_3;
	}

	[SpecialName]
	internal float method_4()
	{
		return float_0;
	}

	[SpecialName]
	internal void method_5(float float_2)
	{
		float_0 = float_2;
	}

	[SpecialName]
	internal float method_6()
	{
		return float_1;
	}

	[SpecialName]
	internal void method_7(float float_2)
	{
		float_1 = float_2;
	}
}
