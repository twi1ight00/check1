using System;
using System.Collections;
using System.Collections.Generic;
using Aspose.Slides;

namespace ns12;

internal sealed class Class181 : IEnumerable, IEnumerable<Class180>
{
	private readonly List<Class180> list_0;

	public int Count => list_0.Count;

	public Class180 this[int index] => list_0[index];

	internal Class181()
	{
		list_0 = new List<Class180>();
	}

	internal Class181(Class181 source)
	{
		list_0 = new List<Class180>(source.list_0);
	}

	public void method_0(string FontName, Enum14 Handling)
	{
		list_0.Add(new Class180(FontName, regex: false, Handling));
	}

	public void method_1(string FontNamePattern, Enum14 Handling)
	{
		try
		{
			list_0.Add(new Class180(FontNamePattern, regex: true, Handling));
		}
		catch (ArgumentException exception)
		{
			throw new PptException("Can't create Regex-based FontHandlingRule", exception);
		}
	}

	public void method_2(int index, string FontName, Enum14 Handling)
	{
		list_0.Insert(index, new Class180(FontName, regex: false, Handling));
	}

	public void method_3(int index, string FontNamePattern, Enum14 Handling)
	{
		try
		{
			list_0.Insert(index, new Class180(FontNamePattern, regex: true, Handling));
		}
		catch (ArgumentException exception)
		{
			throw new PptException("Can't create Regex-based FontHandlingRule", exception);
		}
	}

	public void Remove(Class180 rule)
	{
		list_0.Remove(rule);
	}

	public void RemoveAt(int index)
	{
		list_0.RemoveAt(index);
	}

	public void Clear()
	{
		list_0.Clear();
	}

	public Enum14 method_4(string FontName)
	{
		int num = Count - 1;
		Class180 @class;
		while (true)
		{
			if (num >= 0)
			{
				@class = this[num];
				if (@class.method_0(FontName))
				{
					break;
				}
				num--;
				continue;
			}
			return Enum14.const_0;
		}
		return @class.Handling;
	}

	IEnumerator<Class180> IEnumerable<Class180>.GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	public IEnumerator GetEnumerator()
	{
		return list_0.GetEnumerator();
	}
}
