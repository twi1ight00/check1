using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;

namespace ns18;

internal class Class454 : Class453, Interface5
{
	private Class461 class461_0;

	private Matrix matrix_0;

	private Class458 class458_0;

	private Class464 class464_0;

	public Class464 Hyperlink => class464_0;

	public override void vmethod_0(Class468 class468_0)
	{
		if (method_3() == null)
		{
			class468_0.vmethod_3(this);
			base.vmethod_0(class468_0);
			class468_0.vmethod_4(this);
		}
		else if (method_3().method_1(class468_0.class461_0))
		{
			class468_0.vmethod_3(this);
			base.vmethod_0(class468_0);
			class468_0.vmethod_4(this);
			if (imethod_0() != null)
			{
				imethod_0().Dispose();
			}
		}
		else if (method_3().method_3(class468_0.class461_0))
		{
			if (method_3().int_0 == 0)
			{
				int num = method_3().method_2(class468_0.class461_0);
				if (num > 1)
				{
					method_3().int_0 = num;
					method_3().int_1 = 1;
					class468_0.arrayList_0.Add(this);
				}
				else
				{
					method_3().int_0 = 1;
					method_3().int_1 = 1;
				}
			}
			class468_0.vmethod_3(this);
			base.vmethod_0(class468_0);
			class468_0.vmethod_4(this);
			if (method_3().int_0 <= method_3().int_1 && imethod_0() != null)
			{
				imethod_0().Dispose();
			}
		}
		else if (imethod_0() != null)
		{
			imethod_0().Dispose();
		}
	}

	[SpecialName]
	public Matrix imethod_0()
	{
		return matrix_0;
	}

	[SpecialName]
	public void vmethod_1(Matrix matrix_1)
	{
		matrix_0 = matrix_1;
	}

	[SpecialName]
	public Class458 imethod_1()
	{
		return class458_0;
	}

	[SpecialName]
	public void vmethod_2(Class458 class458_1)
	{
		class458_0 = class458_1;
	}

	[SpecialName]
	public bool imethod_2()
	{
		return false;
	}

	[SpecialName]
	public void method_2(Class464 class464_1)
	{
		class464_0 = class464_1;
	}

	[SpecialName]
	public Class461 method_3()
	{
		return class461_0;
	}

	[SpecialName]
	public void method_4(Class461 class461_1)
	{
		class461_0 = class461_1;
	}
}
