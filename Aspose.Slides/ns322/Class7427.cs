using System;
using System.Collections;
using System.Collections.Generic;

namespace ns322;

internal sealed class Class7427 : Class7399, IEnumerable, IEnumerable<Class7397>
{
	private class Class7680 : IEnumerable
	{
		private class Class7681 : IEnumerator
		{
			private Class7427 class7427_0;

			private IEnumerator ienumerator_0;

			private string string_0;

			public object Current => string_0;

			public Class7681(Class7427 array)
			{
				class7427_0 = array;
				ienumerator_0 = array.sortedList_0.Keys.GetEnumerator();
			}

			public bool MoveNext()
			{
				bool result;
				if (!(result = ienumerator_0.MoveNext()))
				{
					ienumerator_0 = class7427_0.method_5().GetEnumerator();
					ienumerator_0.MoveNext();
				}
				if (ienumerator_0.Current != null)
				{
					string_0 = ienumerator_0.Current.ToString();
				}
				else
				{
					string_0 = null;
				}
				return result;
			}

			public void Reset()
			{
				class7427_0.sortedList_0.Keys.GetEnumerator().Reset();
				class7427_0.method_5().GetEnumerator().Reset();
				ienumerator_0 = class7427_0.sortedList_0.Keys.GetEnumerator();
			}
		}

		private Class7427 class7427_0;

		public IEnumerator GetEnumerator()
		{
			return new Class7681(class7427_0);
		}

		public Class7680(Class7427 array)
		{
			class7427_0 = array;
		}
	}

	private class Class7682 : IEnumerable, IEnumerable<Class7397>
	{
		private class Class7683 : IDisposable, IEnumerator, IEnumerator<Class7397>
		{
			private Class7427 class7427_0;

			private IEnumerator ienumerator_0;

			private Class7397 class7397_0;

			object IEnumerator.Current => Current;

			public Class7397 Current => class7397_0;

			public Class7683(Class7427 array)
			{
				class7427_0 = array;
				ienumerator_0 = array.sortedList_0.GetEnumerator();
			}

			public bool MoveNext()
			{
				bool result;
				if (!(result = ienumerator_0.MoveNext()))
				{
					ienumerator_0 = class7427_0.method_4().GetEnumerator();
					result = ienumerator_0.MoveNext();
				}
				if (ienumerator_0.Current != null)
				{
					class7397_0 = (Class7397)((DictionaryEntry)ienumerator_0.Current).Value;
				}
				else
				{
					class7397_0 = null;
				}
				return result;
			}

			public void Reset()
			{
				class7427_0.sortedList_0.GetEnumerator().Reset();
				class7427_0.method_4().GetEnumerator().Reset();
				ienumerator_0 = class7427_0.sortedList_0.GetEnumerator();
			}

			public void Dispose()
			{
				if (class7427_0 != null)
				{
					class7427_0 = null;
					ienumerator_0 = null;
				}
			}
		}

		private Class7427 class7427_0;

		public IEnumerator<Class7397> GetEnumerator()
		{
			return new Class7683(class7427_0);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public Class7682(Class7427 array)
		{
			class7427_0 = array;
		}
	}

	private int int_1;

	private SortedList sortedList_0 = new SortedList();

	public override string _Class => "Array";

	public override int Length
	{
		get
		{
			return int_1;
		}
		set
		{
			method_8(value);
		}
	}

	public override Class7397 this[string index]
	{
		get
		{
			if (int.TryParse(index, out var result))
			{
				return method_6(result);
			}
			return base[index];
		}
		set
		{
			if (int.TryParse(index, out var result))
			{
				method_7(result, value);
			}
			else
			{
				base[index] = value;
			}
		}
	}

	public override Class7397 this[Class7397 key]
	{
		get
		{
			double num = key.vmethod_3();
			int num2 = (int)num;
			if ((double)num2 == num && num2 >= 0)
			{
				return method_6(num2);
			}
			return base[key.ToString()];
		}
		set
		{
			double num = key.vmethod_3();
			int num2 = (int)num;
			if ((double)num2 == num && num2 >= 0)
			{
				method_7(num2, value);
			}
			else
			{
				base[key.ToString()] = value;
			}
		}
	}

	private IEnumerable method_4()
	{
		return base.vmethod_20();
	}

	private IEnumerable method_5()
	{
		return base.vmethod_19();
	}

	public override bool vmethod_2()
	{
		return Length > 0;
	}

	public override void vmethod_18(Class7352 d)
	{
		if (int.TryParse(d.Name, out var result))
		{
			method_7(result, d.vmethod_1(this));
		}
		else
		{
			base.vmethod_18(d);
		}
	}

	public Class7397 method_6(int i)
	{
		Class7397 @class;
		try
		{
			@class = (Class7397)sortedList_0.GetByIndex(i);
		}
		catch
		{
			return Class7437.class7437_0;
		}
		if (@class == null)
		{
			return Class7437.class7437_0;
		}
		return @class;
	}

	public Class7397 method_7(int i, Class7397 value)
	{
		if (i >= int_1)
		{
			int_1 = i + 1;
		}
		object obj = (sortedList_0[i] = value);
		return (Class7397)obj;
	}

	private void method_8(int newLength)
	{
		if (newLength < 0)
		{
			throw new ArgumentOutOfRangeException("New length is out of range");
		}
		if (newLength < int_1)
		{
			int num = method_9(newLength);
			if (num >= 0)
			{
				for (int num2 = sortedList_0.Count - 1; num2 >= num; num2--)
				{
					sortedList_0.RemoveAt(num2);
				}
			}
		}
		int_1 = newLength;
	}

	public override bool vmethod_15(string key, out Class7397 result)
	{
		result = Class7437.class7437_0;
		try
		{
			int value = int.Parse(key);
			try
			{
				result = (Class7397)sortedList_0.GetByIndex(Convert.ToInt32(value));
			}
			catch
			{
			}
		}
		catch
		{
			base.vmethod_15(key, out result);
		}
		return result != Class7437.class7437_0;
	}

	private int method_9(int key)
	{
		int[] array = new int[sortedList_0.Keys.Count];
		int num = 0;
		foreach (int key2 in sortedList_0.Keys)
		{
			array[num++] = key2;
		}
		int num3 = 0;
		int num4 = sortedList_0.Count - 1;
		int num5 = 0;
		while (true)
		{
			if (num3 <= num4)
			{
				int num6 = array[num5];
				if (num6 == key)
				{
					break;
				}
				if (num6 > key)
				{
					num4 = num5 - 1;
				}
				else
				{
					num3 = num5 + 1;
				}
				num5 = (num3 + num4) / 2;
				continue;
			}
			if (num3 >= sortedList_0.Count)
			{
				return -1;
			}
			return num3;
		}
		return num5;
	}

	public override void vmethod_17(string key)
	{
		if (int.TryParse(key, out var result))
		{
			sortedList_0.Remove(result);
		}
		else
		{
			base.vmethod_17(key);
		}
	}

	public Class7427 method_10(Interface401 global, Class7397[] args)
	{
		SortedList sortedList = new SortedList(sortedList_0);
		int num = int_1;
		foreach (Class7397 @class in args)
		{
			if (@class is Class7427 class2)
			{
				foreach (DictionaryEntry item in class2.sortedList_0)
				{
					sortedList.Add((int)item.Key + num, item.Value);
				}
				num += class2.Length;
			}
			else if (global.ArrayClass.vmethod_23(@class as Class7399))
			{
				Class7399 class3 = (Class7399)@class;
				for (int j = 0; j < class3.Length; j++)
				{
					if (class3.vmethod_15(j.ToString(), out var result))
					{
						sortedList.Add(num + j, result);
					}
				}
			}
			else
			{
				sortedList.Add(num, @class);
				num++;
			}
		}
		return new Class7427(sortedList, num, global.ArrayClass.PrototypeProperty);
	}

	public Class7436 method_11(Interface401 global, Class7397 separator)
	{
		if (int_1 == 0)
		{
			return global.StringClass.method_4();
		}
		string separator2 = ((separator == Class7437.class7437_0) ? "," : separator.ToString());
		string[] array = new string[int_1];
		for (int i = 0; i < int_1; i++)
		{
			try
			{
				Class7397 @class = (Class7397)sortedList_0.GetByIndex(i);
				if (@class != Class7433.class7433_0 && @class != Class7437.class7437_0)
				{
					array[i] = @class.ToString();
				}
				else
				{
					array[i] = string.Empty;
				}
			}
			catch
			{
				array[i] = string.Empty;
			}
		}
		return global.StringClass.method_5(string.Join(separator2, array));
	}

	IEnumerator<Class7397> IEnumerable<Class7397>.GetEnumerator()
	{
		return new Class7682(this).GetEnumerator();
	}

	public override string ToString()
	{
		ArrayList arrayList = new ArrayList();
		foreach (Class7397 item in vmethod_20())
		{
			arrayList.Add(item);
		}
		string[] array = new string[arrayList.Count];
		for (int i = 0; i < arrayList.Count; i++)
		{
			if (arrayList[i] != null)
			{
				array[i] = arrayList[i].ToString();
			}
		}
		return string.Join(",", array);
	}

	public override IEnumerable vmethod_19()
	{
		return new Class7680(this);
	}

	public override IEnumerable vmethod_20()
	{
		return new Class7682(this);
	}

	public override bool vmethod_8(string key)
	{
		if (int.TryParse(key, out var result))
		{
			if (result >= 0 && result < int_1)
			{
				return sortedList_0.ContainsKey(result);
			}
			return false;
		}
		return base.vmethod_8(key);
	}

	public override double vmethod_3()
	{
		return Length;
	}

	public override bool Equals(object obj)
	{
		return this == obj;
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public Class7427(Class7399 prototype)
		: base(prototype)
	{
	}

	private Class7427(SortedList data, int len, Class7399 prototype)
		: base(prototype)
	{
		sortedList_0 = data;
		int_1 = len;
	}
}
