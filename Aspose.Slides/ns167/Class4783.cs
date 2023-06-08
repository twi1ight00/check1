using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using ns166;

namespace ns167;

internal class Class4783 : Class4780
{
	private const float float_3 = -1f;

	private float float_4 = -1f;

	internal override float InsideTextDistance
	{
		get
		{
			float num = ((PageElementCount > 0) ? this[PageElementCount - 1].InsideTextDistance : 0f);
			for (int i = 0; i < PageElementCount - 1; i++)
			{
				num += (float)Class4778.smethod_7(this[i], this[i + 1]);
				num += this[i].InsideTextDistance;
			}
			if (PageElementCount <= 0)
			{
				return 0f;
			}
			return num / (float)(2 * PageElementCount - 1);
		}
	}

	internal new Class4779 this[int index]
	{
		get
		{
			if (LineCount == 1)
			{
				if (index < 0 || index >= class4844_0[0].Count)
				{
					throw new InvalidOperationException("Please report exception. Index of PlacementLine is invalid.");
				}
				return class4844_0[0][index];
			}
			throw new InvalidOperationException("Please report exception. Referenced empty placement Line instance.");
		}
	}

	internal float MaxHeight
	{
		get
		{
			float num = 0f;
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					Class4845 @class = (Class4845)enumerator.Current;
					if (@class.Value is Class4791 class2)
					{
						num = Math.Max(num, class2.ApsGlyphFont.method_4(class2.Text).Height);
					}
					else
					{
						if (!(@class.Value is Class4784 class3))
						{
							continue;
						}
						foreach (Class4845 item in class3)
						{
							num = smethod_7(num, item);
						}
						Class4846 textSubSuperscriptParts = class3.TextSubSuperscriptParts;
						foreach (Class4845 item2 in textSubSuperscriptParts)
						{
							num = smethod_7(num, item2);
						}
					}
				}
				return num;
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
		}
	}

	internal override float GetRealWidth
	{
		get
		{
			float num = 0f;
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					Class4845 @class = (Class4845)enumerator.Current;
					num += @class.Value.GetRealWidth;
				}
				return num;
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
		}
	}

	internal new int LineCount
	{
		get
		{
			if (base.LineCount > 1)
			{
				throw new ArgumentException("Please report exception. PlacementLine contains more than one line.");
			}
			return base.LineCount;
		}
	}

	internal override PointF Origin
	{
		get
		{
			return this[0].Origin;
		}
		set
		{
			base.Origin = value;
		}
	}

	internal int PageElementCount
	{
		get
		{
			if (class4844_0.LineCount == 1)
			{
				return class4844_0[0].Count;
			}
			return 0;
		}
	}

	internal Class4783()
	{
	}

	internal Class4783(List<Class4779> elements)
	{
		class4844_0.method_3(elements);
	}

	internal Class4783(Class4779 element)
	{
		if (element is Class4783 @class)
		{
			for (int i = 0; i < @class.PageElementCount; i++)
			{
				Add(@class[i]);
			}
		}
		else
		{
			Add(element);
		}
	}

	internal Class4845 method_33(int index)
	{
		return new Class4845(0, index, class4844_0);
	}

	internal override bool Add(Class4779 element)
	{
		if (element is Class4791 element2)
		{
			method_34(element2);
		}
		return base.Add(element);
	}

	private void method_34(Class4791 element)
	{
		if (float_4 == -1f)
		{
			float_4 = element.Origin.Y;
		}
		else if (element.Origin.Y != float_4)
		{
			element.Origin = new PointF(element.Origin.X, float_4);
		}
	}

	internal void method_35(PointF offset)
	{
		for (int i = 0; i < PageElementCount; i++)
		{
			PointF origin = this[i].Origin;
			this[i].Origin = new PointF(origin.X + offset.X, origin.Y + offset.Y);
		}
	}

	private static float smethod_7(float result, Class4845 textPointer)
	{
		if (textPointer.Value is Class4791 @class)
		{
			result = Math.Max(result, @class.ApsGlyphFont.method_4(@class.Text).Height);
		}
		return result;
	}
}
