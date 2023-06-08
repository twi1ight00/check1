using System;
using System.Collections;
using System.Drawing;
using ns166;

namespace ns167;

internal class Class4846 : IEnumerable, IEnumerator, Interface147
{
	private readonly ArrayList arrayList_0 = new ArrayList();

	private Class4820 class4820_0;

	private IEnumerator ienumerator_0;

	private Enum673 enum673_0;

	private bool bool_0;

	private bool bool_1;

	object IEnumerator.Current => ienumerator_0.Current;

	Class4845 Interface147.Current => class4820_0.Current;

	internal int Count => arrayList_0.Count;

	internal Class4845 this[int index]
	{
		get
		{
			if (index < Count && index >= 0)
			{
				return (Class4845)arrayList_0[index];
			}
			return null;
		}
	}

	internal Class4846()
	{
		bool_1 = false;
	}

	internal Class4846(Enum673 dimension, bool isReverse)
	{
		enum673_0 = dimension;
		bool_0 = isReverse;
		bool_1 = false;
	}

	internal void Clear()
	{
		bool_1 = false;
		arrayList_0.Clear();
	}

	internal bool method_0()
	{
		bool result = false;
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Class4845 @class = (Class4845)enumerator.Current;
				if (@class.Value is Class4785)
				{
					result = true;
					break;
				}
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		return result;
	}

	internal double method_1(Class4779 element)
	{
		double num = 0.0;
		float num2 = 0f;
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Class4845 @class = (Class4845)enumerator.Current;
				num2 += 1f;
				num += Class4778.smethod_9(@class.Value, element);
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		if (num2 != 0f)
		{
			return num / (double)num2;
		}
		return double.PositiveInfinity;
	}

	public IEnumerator GetEnumerator()
	{
		((IEnumerator)this).Reset();
		ienumerator_0.Reset();
		return this;
	}

	internal Interface147 method_2()
	{
		((Interface147)this).Reset();
		return this;
	}

	internal bool method_3()
	{
		return arrayList_0.Count == 0;
	}

	internal void method_4()
	{
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Class4845 @class = (Class4845)enumerator.Current;
				@class.Remove();
			}
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

	internal void Add(Class4845 el)
	{
		arrayList_0.Add(el);
		bool_1 = false;
	}

	internal void Remove(Class4846 elements)
	{
		for (int num = elements.Count - 1; num >= 0; num--)
		{
			Remove((Class4845)elements.arrayList_0[num]);
		}
	}

	internal void Remove(Class4845 el)
	{
		int num = arrayList_0.IndexOf(el);
		if (num != -1)
		{
			arrayList_0.RemoveAt(num);
		}
	}

	internal void RemoveAt(int index)
	{
		arrayList_0.RemoveAt(index);
	}

	internal RectangleF method_5()
	{
		RectangleF rectangleF = default(RectangleF);
		for (int i = 0; i < Count; i++)
		{
			if (!(this[i].Value is Class4789))
			{
				rectangleF = ((!rectangleF.IsEmpty) ? RectangleF.Union(rectangleF, this[i].Value.BoundingBox) : this[i].Value.BoundingBox);
			}
		}
		return rectangleF;
	}

	internal void method_6(Class4845 el)
	{
		arrayList_0.Insert(0, el);
		bool_1 = false;
	}

	internal bool Contains(Class4845 elPtr)
	{
		return arrayList_0.Contains(elPtr);
	}

	internal bool method_7()
	{
		bool result = true;
		for (int i = 0; i < Count; i++)
		{
			if (!this[i].method_1())
			{
				result = false;
				break;
			}
		}
		return result;
	}

	internal void method_8(Class4846 collection)
	{
		bool flag = false;
		for (int num = arrayList_0.Count - 1; num >= 0; num--)
		{
			if (!collection.arrayList_0.Contains(this[num]))
			{
				arrayList_0.RemoveAt(num);
				flag = true;
			}
		}
		if (flag)
		{
			ienumerator_0 = null;
			class4820_0 = null;
		}
	}

	internal bool method_9(Class4846 collection)
	{
		if (collection == null)
		{
			return false;
		}
		bool result = false;
		for (int i = 0; i < collection.arrayList_0.Count; i++)
		{
			if (!arrayList_0.Contains(collection[i]))
			{
				Add(collection[i]);
				result = true;
			}
		}
		return result;
	}

	internal bool method_10(Class4845 el)
	{
		if (!arrayList_0.Contains(el))
		{
			Add(el);
			return true;
		}
		return false;
	}

	void IEnumerator.Reset()
	{
		method_13();
		ienumerator_0 = arrayList_0.GetEnumerator();
		ienumerator_0.Reset();
	}

	void Interface147.Reset()
	{
		enum673_0 = Enum673.const_0;
		method_13();
		class4820_0 = new Class4820(GetEnumerator());
	}

	bool IEnumerator.MoveNext()
	{
		bool result = false;
		bool flag;
		do
		{
			if (flag = ienumerator_0.MoveNext())
			{
				((Class4845)ienumerator_0.Current).method_0();
			}
			if (flag && !(((Class4845)ienumerator_0.Current).Value is Class4789))
			{
				result = true;
				break;
			}
		}
		while (flag);
		return result;
	}

	bool Interface147.imethod_0()
	{
		return class4820_0.method_0();
	}

	bool Interface147.imethod_1()
	{
		return class4820_0.method_1();
	}

	internal void method_11(Enum673 dimension, bool isReverse)
	{
		if (!bool_1 || enum673_0 != dimension || bool_0 != isReverse)
		{
			enum673_0 = dimension;
			bool_0 = isReverse;
			ienumerator_0 = null;
			class4820_0 = null;
			bool_1 = false;
			method_13();
		}
	}

	internal void method_12(Enum673 dimension)
	{
		method_11(dimension, isReverse: false);
	}

	internal void method_13()
	{
		if (!bool_1)
		{
			IComparer comparer = ((!bool_0) ? Class4821.smethod_0(enum673_0) : Class4821.smethod_1(enum673_0));
			try
			{
				arrayList_0.Sort(comparer);
				bool_1 = true;
			}
			catch (Exception)
			{
			}
		}
	}
}
