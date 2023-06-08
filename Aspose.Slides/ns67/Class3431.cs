using System;

namespace ns67;

internal abstract class Class3431
{
	private readonly Class3452 class3452_0;

	private readonly Class3432 class3432_0;

	private Class3434 class3434_0;

	public Class3452 Slide => class3452_0;

	public Class3432 Parent => class3432_0;

	public Class3431 Prior => Container.imethod_4(this);

	public Class3431 Next => Container.imethod_5(this);

	public Class3434 Attributes
	{
		get
		{
			return class3434_0;
		}
		set
		{
			if (class3434_0 != value)
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				class3434_0 = (Class3434)value.Clone();
			}
		}
	}

	private Interface50 Container
	{
		get
		{
			if (class3432_0 != null)
			{
				return class3432_0.Children;
			}
			return class3452_0.Shapes;
		}
	}

	public void method_0()
	{
		Container.imethod_2(this);
	}

	public void method_1()
	{
		Container.imethod_3(this);
	}

	protected Class3431(Class3452 slide, Class3432 parent)
	{
		class3434_0 = new Class3434();
		class3452_0 = slide;
		class3432_0 = parent;
		if (class3432_0 != null)
		{
			class3432_0.method_2(this);
		}
		else
		{
			class3452_0.method_1(this);
		}
	}

	internal abstract void vmethod_0(Class3428 renderer, Class3434 parentAttributes);
}
