using System;
using System.Collections;
using System.Collections.Generic;

namespace ns67;

internal sealed class Class3067 : IEnumerable, IDisposable, ICloneable, IEnumerator, IEnumerable<Class3066>, IEnumerator<Class3066>
{
	private readonly bool bool_0;

	private int int_0;

	private readonly List<Class3066> list_0;

	object IEnumerator.Current => ((IEnumerator<Class3066>)this).Current;

	Class3066 IEnumerator<Class3066>.Current
	{
		get
		{
			if (int_0 >= 0 && int_0 < list_0.Count)
			{
				return list_0[int_0];
			}
			return null;
		}
	}

	public Class3067(Struct159[] points, bool isClosed)
		: this(isClosed)
	{
		for (int i = 0; i < points.Length - 1; i++)
		{
			Add(points[i], points[i + 1]);
		}
		if (isClosed)
		{
			Add(points[points.Length - 1], points[0]);
		}
	}

	public Class3067 method_0(Enum491 alignment)
	{
		switch (alignment)
		{
		default:
			throw new NotImplementedException();
		case Enum491.const_2:
			throw new NotImplementedException();
		case Enum491.const_0:
		case Enum491.const_1:
			return method_7();
		}
	}

	public Class3067 method_1(Class3438 dash, double lineWidth)
	{
		if (dash != null && dash.DashStopList.Count != 0)
		{
			int num = 0;
			double num2 = 0.0;
			int num3 = 0;
			Struct159 @struct = list_0[0].Begin;
			Struct159 end = list_0[0].End;
			Class3067 @class = new Class3067(bool_0);
			while (true)
			{
				if (num3 < list_0.Count)
				{
					if (list_0[num3] == null)
					{
						break;
					}
					Class3341 class2 = dash.DashStopList[num];
					if ((double)(class2.DashLength + class2.SpaceLength) - num2 < 1E-06)
					{
						num2 = 0.0;
						num = (num + 1) % dash.DashStopList.Count;
						class2 = dash.DashStopList[num];
					}
					Struct158 struct2 = Struct158.smethod_0(@struct, end);
					bool flag;
					double num4 = ((flag = num2 < (double)class2.DashLength) ? ((double)class2.DashLength - num2) : ((double)class2.SpaceLength - (num2 - (double)class2.DashLength)));
					double num5 = lineWidth * num4 / 100000.0;
					if (num5 < struct2.Norm)
					{
						num2 += num4;
						Struct159 struct3 = Struct158.smethod_3(@struct, Struct158.smethod_5(struct2.method_1(), num5));
						if (flag)
						{
							@class.Add(@struct, struct3);
						}
						else
						{
							@class.method_8();
						}
						@struct = struct3;
						continue;
					}
					num2 += struct2.Norm / lineWidth * 100000.0;
					if (flag)
					{
						@class.Add(@struct, end);
					}
					else
					{
						@class.method_8();
					}
					num3++;
					if (num3 < list_0.Count)
					{
						@struct = list_0[num3].Begin;
						end = list_0[num3].End;
					}
					continue;
				}
				return @class;
			}
			throw new InvalidOperationException("Segments' list has been already dashed.");
		}
		return this;
	}

	public Class3067 method_2(double lineWidth, Enum487 headEnd, Enum487 tailEnd)
	{
		Class3067 @class = method_7();
		List<Class3066> list = @class.list_0;
		if (list.Count != 0 && list[0].Prev == null)
		{
			if (headEnd == Enum487.const_0 || headEnd == Enum487.const_1)
			{
				Class3066 class2 = list[0];
				class2.Begin = Struct158.smethod_4(class2.Begin, Struct158.smethod_5(class2.method_2().method_1(), lineWidth / 2.0));
			}
			if (tailEnd == Enum487.const_0 || tailEnd == Enum487.const_1)
			{
				Class3066 class3 = list[list.Count - 1];
				if (class3 != null)
				{
					class3.End = Struct158.smethod_3(class3.End, Struct158.smethod_5(class3.method_2().method_1(), lineWidth / 2.0));
				}
			}
			return @class;
		}
		return @class;
	}

	public Class3067 method_3(double lineWidth)
	{
		Class3067 @class = new Class3067(bool_0);
		for (int i = 0; i < list_0.Count; i++)
		{
			Class3066 class2 = list_0[i];
			if (class2 == null)
			{
				@class.method_8();
				continue;
			}
			if (class2.Next != null)
			{
				@class.Add(class2.Begin, class2.End);
				continue;
			}
			double num = lineWidth;
			Class3066 class3 = @class.Add(class2.Begin, class2.End);
			while (num > 0.0)
			{
				Struct158 @struct = class3.method_2();
				if (@struct.Norm > num)
				{
					class3.End = Struct158.smethod_4(class3.End, Struct158.smethod_5(class3.method_2().method_1(), num));
					num = 0.0;
				}
				else if (class2.Prev != null)
				{
					num -= class3.method_2().Norm;
					@class.list_0.RemoveAt(@class.list_0.Count - 1);
					class3 = @class.list_0[@class.list_0.Count - 1];
				}
				else
				{
					num = 0.0;
					class2.End = Struct158.smethod_3(class2.Begin, @struct.method_1());
				}
			}
		}
		return @class;
	}

	public Class3067 method_4(double lineWidth, double compound1, double compound2)
	{
		Class3067 @class = new Class3067(bool_0);
		for (int i = 0; i < list_0.Count; i++)
		{
			Class3066 class2 = list_0[i];
			if (class2 == null)
			{
				@class.method_8();
				continue;
			}
			Struct158 a = class2.method_2().method_2();
			double b = (compound1 + (compound2 - compound1 - 1.0) / 2.0) * lineWidth;
			Struct159 begin = Struct158.smethod_3(class2.Begin, Struct158.smethod_5(a, b));
			Struct159 end = Struct158.smethod_3(class2.End, Struct158.smethod_5(a, b));
			@class.Add(begin, end);
		}
		return @class;
	}

	public Class3066 method_5(Class3066 segment)
	{
		int num = list_0.IndexOf(segment);
		if (num >= 0 && segment != null && list_0.Count != 0)
		{
			if (num < list_0.Count - 1 && list_0[num + 1] != null)
			{
				return list_0[num + 1];
			}
			if (bool_0 && num == list_0.Count - 1 && list_0[0] != null)
			{
				return list_0[0];
			}
			return null;
		}
		return null;
	}

	public Class3066 method_6(Class3066 segment)
	{
		int num = list_0.IndexOf(segment);
		if (num >= 0 && segment != null && list_0.Count != 0)
		{
			if (num > 0 && list_0[num - 1] != null)
			{
				return list_0[num - 1];
			}
			if (bool_0 && num == 0 && list_0[list_0.Count - 1] != null)
			{
				return list_0[list_0.Count - 1];
			}
			return null;
		}
		return null;
	}

	public Class3067 method_7()
	{
		Class3067 @class = new Class3067(bool_0);
		for (int i = 0; i < list_0.Count; i++)
		{
			Class3066 class2 = list_0[i];
			if (class2 == null)
			{
				@class.method_8();
			}
			else
			{
				@class.Add(class2.Begin, class2.End);
			}
		}
		return @class;
	}

	public object Clone()
	{
		return method_7();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return this;
	}

	public IEnumerator<Class3066> GetEnumerator()
	{
		return this;
	}

	bool IEnumerator.MoveNext()
	{
		int_0++;
		while (true)
		{
			if (int_0 < list_0.Count)
			{
				if (list_0[int_0] != null)
				{
					break;
				}
				int_0++;
				continue;
			}
			return false;
		}
		return true;
	}

	void IEnumerator.Reset()
	{
		int_0 = -1;
	}

	void IDisposable.Dispose()
	{
	}

	private Class3067(bool closed)
	{
		list_0 = new List<Class3066>();
		bool_0 = closed;
		int_0 = -1;
	}

	private Class3066 Add(Struct159 begin, Struct159 end)
	{
		Class3066 @class = new Class3066(begin, end, this);
		list_0.Add(@class);
		return @class;
	}

	private void method_8()
	{
		if (list_0.Count <= 0 || list_0[list_0.Count - 1] != null)
		{
			list_0.Add(null);
		}
	}
}
