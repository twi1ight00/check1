using System;
using System.Collections;
using System.Text;

namespace ns196;

internal abstract class Class5274 : ArrayList
{
	internal int int_0 = -1;

	public Class5274()
	{
	}

	public Class5274(ArrayList list)
		: base(list)
	{
	}

	public virtual void vmethod_0()
	{
	}

	public abstract Class5274 vmethod_1();

	public abstract bool vmethod_2(Class5274 sequence);

	public abstract bool vmethod_3(Class5274 sequence, bool keepTogether, Class5336 breakElement);

	public abstract bool vmethod_4(Class5274 sequence);

	public bool method_0(Class5274 sequence)
	{
		if (!vmethod_4(sequence))
		{
			vmethod_1();
			return false;
		}
		return true;
	}

	public bool method_1(Class5274 sequence, bool keepTogether, Class5336 breakElement)
	{
		if (!vmethod_3(sequence, keepTogether, breakElement))
		{
			vmethod_1();
			return false;
		}
		return true;
	}

	public void method_2(Interface173 lm)
	{
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Class5328 @class = (Class5328)enumerator.Current;
				@class.method_1(lm.imethod_22(new Class5255(lm, @class.method_0())));
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

	public Class5328 method_3()
	{
		if (Count != 0)
		{
			return (Class5328)base[Count - 1];
		}
		return null;
	}

	public Class5328 method_4()
	{
		if (Count == 0)
		{
			return null;
		}
		Class5328 result = (Class5328)base[Count - 1];
		base.RemoveAt(Count - 1);
		return result;
	}

	public Class5328 method_5(int index)
	{
		if (index < Count && index >= 0)
		{
			return (Class5328)base[index];
		}
		return null;
	}

	protected int method_6()
	{
		if (Count == 0)
		{
			return -1;
		}
		return method_7(0);
	}

	internal int method_7(int startIndex)
	{
		if (Count != 0 && startIndex >= 0 && startIndex < Count)
		{
			Class5328 @class = null;
			int i = startIndex;
			for (int count = Count; i < count; i++)
			{
				@class = method_5(i);
				if (@class.vmethod_0())
				{
					break;
				}
			}
			if (i != startIndex)
			{
				if (@class != null && @class.vmethod_0())
				{
					return i - 1;
				}
				return startIndex;
			}
			return startIndex;
		}
		return -1;
	}

	public abstract bool vmethod_5();

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("<KnuthSequence [");
		for (int i = 0; i < Count; i++)
		{
			stringBuilder.Append(this[i]);
			if (i != Count - 1)
			{
				stringBuilder.Append(", ");
			}
		}
		stringBuilder.Append("]>");
		return stringBuilder.ToString();
	}
}
