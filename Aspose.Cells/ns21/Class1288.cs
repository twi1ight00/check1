using System.Runtime.CompilerServices;
using Aspose.Cells;
using Aspose.Cells.Drawing;
using ns2;

namespace ns21;

internal class Class1288
{
	private ShapePropertyCollection shapePropertyCollection_0;

	private Class1287 class1287_0;

	private GlowEffect glowEffect_0;

	private Class1289 class1289_0;

	private Class1291 class1291_0;

	private Class1292 class1292_0;

	private Class1293 class1293_0;

	internal int int_0;

	internal Workbook Workbook => shapePropertyCollection_0.Workbook;

	internal GlowEffect GlowEffect
	{
		get
		{
			if (glowEffect_0 == null)
			{
				glowEffect_0 = new GlowEffect(this);
			}
			return glowEffect_0;
		}
	}

	public double SoftEdgeRadius
	{
		get
		{
			return (double)int_0 / Class1391.double_0;
		}
		set
		{
			int_0 = (int)(value * Class1391.double_0);
		}
	}

	internal Class1288(ShapePropertyCollection shapePropertyCollection_1)
	{
		shapePropertyCollection_0 = shapePropertyCollection_1;
	}

	internal bool method_0()
	{
		if (class1287_0 == null && class1289_0 == null && class1291_0 == null && class1292_0 == null && class1293_0 == null && int_0 == 0 && (glowEffect_0 == null || !glowEffect_0.method_0()))
		{
			return true;
		}
		return false;
	}

	[SpecialName]
	internal Class1287 method_1()
	{
		if (class1287_0 == null)
		{
			class1287_0 = new Class1287();
		}
		return class1287_0;
	}

	internal Class1287 method_2()
	{
		return class1287_0;
	}

	[SpecialName]
	internal void method_3(GlowEffect glowEffect_1)
	{
		glowEffect_0 = glowEffect_1;
	}

	internal GlowEffect method_4()
	{
		return glowEffect_0;
	}

	internal void method_5()
	{
		class1289_0 = null;
		class1291_0 = null;
		class1292_0 = null;
	}

	[SpecialName]
	internal Class1289 method_6()
	{
		if (class1289_0 == null)
		{
			class1289_0 = new Class1289(this);
		}
		return class1289_0;
	}

	internal Class1289 method_7()
	{
		return class1289_0;
	}

	[SpecialName]
	internal Class1291 method_8()
	{
		if (class1291_0 == null)
		{
			class1291_0 = new Class1291(this);
		}
		return class1291_0;
	}

	internal Class1291 method_9()
	{
		return class1291_0;
	}

	[SpecialName]
	internal Class1292 method_10()
	{
		if (class1292_0 == null)
		{
			class1292_0 = new Class1292(this);
		}
		return class1292_0;
	}

	internal Class1292 method_11()
	{
		return class1292_0;
	}

	[SpecialName]
	internal Class1293 method_12()
	{
		if (class1293_0 == null)
		{
			class1293_0 = new Class1293();
		}
		return class1293_0;
	}

	internal Class1293 method_13()
	{
		return class1293_0;
	}

	internal void Copy(Class1288 class1288_0)
	{
		if (class1288_0.class1287_0 != null)
		{
			class1287_0 = new Class1287();
			class1287_0.Copy(class1288_0.class1287_0);
		}
		if (class1288_0.glowEffect_0 != null)
		{
			glowEffect_0 = new GlowEffect(this);
			glowEffect_0.Copy(class1288_0.glowEffect_0);
		}
		if (class1288_0.class1289_0 != null)
		{
			class1289_0 = new Class1289(this);
			class1289_0.Copy(class1288_0.class1289_0);
		}
		if (class1288_0.class1291_0 != null)
		{
			class1291_0 = new Class1291(this);
			class1291_0.Copy(class1288_0.class1291_0);
		}
		if (class1288_0.class1292_0 != null)
		{
			class1292_0 = new Class1292(this);
			class1292_0.Copy(class1288_0.class1292_0);
		}
		if (class1288_0.class1293_0 != null)
		{
			class1293_0 = new Class1293();
			class1293_0.Copy(class1288_0.class1293_0);
		}
		int_0 = class1288_0.int_0;
	}
}
