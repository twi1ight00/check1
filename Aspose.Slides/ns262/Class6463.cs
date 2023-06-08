using System;
using ns224;
using ns235;
using ns252;
using ns253;

namespace ns262;

internal class Class6463 : Interface307
{
	private readonly Class6471 class6471_0 = new Class6471();

	private bool bool_0;

	private double double_0;

	private double double_1;

	private Class6324<Interface305> class6324_0;

	private Class6324<Interface305> class6324_1;

	private double double_2;

	private double double_3;

	private double double_4;

	public Interface300 VerticalMeasurement => class6471_0;

	public bool IsOverflowed
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

	public double Y
	{
		get
		{
			return double_4;
		}
		set
		{
			double_4 = value;
		}
	}

	public double X
	{
		get
		{
			return double_3;
		}
		set
		{
			double_3 = value;
		}
	}

	public Class6324<Interface305> VisibleSpanRange => class6324_1;

	internal Class6324<Interface305> SpanRange => class6324_0;

	public Class6463(double lineWidth, Class6324<Interface305> spanRange)
	{
		class6324_0 = spanRange;
		double_0 = lineWidth;
		method_3();
		method_0();
	}

	public void imethod_0(Enum825 alignment)
	{
		double num = double_1 + double_2;
		switch (alignment)
		{
		default:
			throw new ArgumentOutOfRangeException("alignment");
		case Enum825.const_0:
			method_2(0.0);
			break;
		case Enum825.const_1:
			method_2((double_0 - num) / 2.0);
			break;
		case Enum825.const_2:
			method_2(double_0 - num);
			break;
		case Enum825.const_3:
		case Enum825.const_4:
		case Enum825.const_5:
		case Enum825.const_6:
			method_1();
			break;
		}
	}

	public Class6204 imethod_1()
	{
		Class6213 @class = new Class6213();
		for (int i = 0; i < class6324_1.Count; i++)
		{
			Interface305 @interface = class6324_1.method_0(i);
			@class.Add(@interface.imethod_0());
		}
		@class.RenderTransform = new Class6002();
		@class.RenderTransform.method_8((float)X, (float)Y);
		return @class;
	}

	private void method_0()
	{
		double_1 = 0.0;
		double_2 = 0.0;
		class6471_0.Reset();
		for (int i = 0; i < class6324_1.Count; i++)
		{
			Interface305 @interface = class6324_1.method_0(i);
			class6471_0.Add(@interface.VerticalMeasurement);
			switch (@interface.Type)
			{
			case Enum835.const_0:
				double_2 += @interface.OriginalWidth;
				break;
			case Enum835.const_1:
				double_1 += @interface.OriginalWidth;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	private void method_1()
	{
		double num = (double_0 - double_2) / double_1;
		double num2 = 0.0;
		for (int i = 0; i < class6324_1.Count; i++)
		{
			Interface305 @interface = class6324_1.method_0(i);
			if (@interface.Type == Enum835.const_1)
			{
				@interface.ActualWidth = @interface.OriginalWidth * num;
			}
			else
			{
				@interface.ActualWidth = @interface.OriginalWidth;
			}
			@interface.X = num2;
			num2 += @interface.ActualWidth;
		}
	}

	private void method_2(double offset)
	{
		for (int i = 0; i < class6324_1.Count; i++)
		{
			Interface305 @interface = class6324_1.method_0(i);
			@interface.X = offset;
			@interface.ActualWidth = @interface.OriginalWidth;
			offset += @interface.ActualWidth;
		}
	}

	private void method_3()
	{
		class6324_1 = class6324_0.Clone();
		while (VisibleSpanRange.HasItems)
		{
			Interface305 firstItem = class6324_1.FirstItem;
			if (firstItem.Type == Enum835.const_0)
			{
				break;
			}
			class6324_1.method_1(1);
		}
		while (VisibleSpanRange.HasItems)
		{
			Interface305 lastItem = class6324_1.LastItem;
			if (lastItem.Type != 0)
			{
				class6324_1.method_2(1);
				continue;
			}
			break;
		}
	}
}
