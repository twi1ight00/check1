using System;

namespace ns67;

internal sealed class Class3347 : Class3344
{
	private bool bool_0;

	private Class3453 class3453_0 = new Class3453(0f, 0f, 0f, 0f);

	private Class3453 class3453_1 = new Class3453(0f, 0f, 0f, 0f);

	public bool ConsiderAlphaValues
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public Class3453 ColorFrom
	{
		get
		{
			return class3453_0;
		}
		set
		{
			if (class3453_0 != value)
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				class3453_0 = value.method_1();
			}
		}
	}

	public Class3453 ColorTo
	{
		get
		{
			return class3453_1;
		}
		set
		{
			if (class3453_1 != value)
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				class3453_1 = value.method_1();
			}
		}
	}

	public Class3347(Class3453 colorFrom, Class3453 colorTo, bool considerAlphaValues)
	{
		ColorFrom = colorFrom;
		ColorTo = colorTo;
		ConsiderAlphaValues = considerAlphaValues;
	}

	public override Class3344 vmethod_0()
	{
		return new Class3347(class3453_0, class3453_1, bool_0);
	}
}
