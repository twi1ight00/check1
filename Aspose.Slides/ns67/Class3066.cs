using System;

namespace ns67;

internal sealed class Class3066
{
	private Struct159 struct159_0;

	private Struct159 struct159_1;

	private readonly Class3067 class3067_0;

	public Struct159 Begin
	{
		get
		{
			return struct159_0;
		}
		set
		{
			struct159_0 = value;
		}
	}

	public Struct159 End
	{
		get
		{
			return struct159_1;
		}
		set
		{
			struct159_1 = value;
		}
	}

	public Class3066 Next
	{
		get
		{
			if (class3067_0 != null)
			{
				return class3067_0.method_5(this);
			}
			return null;
		}
	}

	public Class3066 Prev
	{
		get
		{
			if (class3067_0 != null)
			{
				return class3067_0.method_6(this);
			}
			return null;
		}
	}

	public Class3066(Struct159 begin, Struct159 end, Class3067 list)
	{
		Begin = begin;
		End = end;
		class3067_0 = list;
	}

	public Class3066(Struct159 begin, Struct159 end)
	{
		Begin = begin;
		End = end;
		class3067_0 = null;
	}

	public bool method_0(Class3066 segment)
	{
		double num = End.Y - Begin.Y;
		double num2 = Begin.X - End.X;
		double num3 = segment.End.Y - segment.Begin.Y;
		double num4 = segment.Begin.X - segment.End.X;
		double value = num * num4 - num3 * num2;
		return Math.Abs(value) > 1E-06;
	}

	public Struct159 method_1(Class3066 segment)
	{
		double num = End.Y - Begin.Y;
		double num2 = Begin.X - End.X;
		double num3 = num * Begin.X + num2 * Begin.Y;
		double num4 = segment.End.Y - segment.Begin.Y;
		double num5 = segment.Begin.X - segment.End.X;
		double num6 = num4 * segment.Begin.X + num5 * segment.Begin.Y;
		double num7 = num * num5 - num4 * num2;
		if (Math.Abs(num7) < 1E-06)
		{
			throw new InvalidOperationException("Lines don't have cross point.");
		}
		double x = (num5 * num3 - num2 * num6) / num7;
		double y = (num * num6 - num4 * num3) / num7;
		return new Struct159(x, y);
	}

	public Struct158 method_2()
	{
		return Struct158.smethod_0(Begin, End);
	}
}
