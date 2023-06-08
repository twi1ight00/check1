using System;

namespace ns67;

internal sealed class Class3339 : Class3331
{
	private Class3453 class3453_0;

	public Class3453 FillColor
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

	public Class3339()
		: this(smethod_1())
	{
	}

	public Class3339(Class3453 color)
	{
		FillColor = color;
	}

	public override Class3331 vmethod_0()
	{
		return new Class3339(class3453_0);
	}

	internal override void vmethod_1(Enum492 fillMode)
	{
		float num3;
		float num2;
		float num;
		switch (fillMode)
		{
		default:
			throw new ApplicationException("Unexpected value of PathFillMode enumeration.");
		case Enum492.const_0:
			return;
		case Enum492.const_1:
			num3 = 0.6f;
			num2 = 0.6f;
			num = 0.6f;
			break;
		case Enum492.const_2:
			num3 = 0.8f;
			num2 = 0.8f;
			num = 0.8f;
			break;
		case Enum492.const_3:
			num = 1.88f;
			num2 = 1.38f;
			num3 = 1.14f;
			break;
		case Enum492.const_4:
			num = 1.44f;
			num2 = 1.2f;
			num3 = 1.06f;
			break;
		}
		class3453_0.Red = smethod_0(class3453_0.Red * num);
		class3453_0.Green = smethod_0(class3453_0.Green * num2);
		class3453_0.Blue = smethod_0(class3453_0.Blue * num3);
	}

	private static float smethod_0(float value)
	{
		if (value < 0f)
		{
			return 0f;
		}
		if (value > 1f)
		{
			return 1f;
		}
		return value;
	}

	private static Class3453 smethod_1()
	{
		return Class3453.smethod_1(79, 129, 189);
	}
}
