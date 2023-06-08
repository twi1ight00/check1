using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Aspose.Cells.Charts;

namespace ns7;

internal class Class1388 : CollectionBase
{
	private Chart chart_0;

	public Class1387 this[int int_0] => (Class1387)base.InnerList[int_0];

	internal Chart Chart => chart_0;

	internal Class1388(Chart chart_1)
	{
		chart_0 = chart_1;
	}

	internal Class1387 method_0(int int_0)
	{
		if (int_0 >= base.Count)
		{
			for (int i = base.Count; i <= int_0; i++)
			{
				Class1387 value = new Class1387(this);
				base.InnerList.Add(value);
			}
		}
		return this[int_0];
	}

	internal int Add(Class1387 class1387_0)
	{
		if (!class1387_0.PlotOnSecondAxis)
		{
			for (int i = 0; i < base.InnerList.Count; i++)
			{
				Class1387 @class = (Class1387)base.InnerList[i];
				if (@class.PlotOnSecondAxis)
				{
					base.InnerList.Insert(i, class1387_0);
					return base.Count - 1;
				}
			}
		}
		base.InnerList.Add(class1387_0);
		return base.Count - 1;
	}

	[SpecialName]
	internal bool method_1()
	{
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Class1387 @class = (Class1387)enumerator.Current;
				if (@class.PlotOnSecondAxis)
				{
					return true;
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
		return false;
	}

	internal Class1387 method_2(bool bool_0)
	{
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Class1387 @class = (Class1387)enumerator.Current;
				if (@class.PlotOnSecondAxis == bool_0)
				{
					return @class;
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
		return null;
	}

	internal void Remove(Class1387 class1387_0)
	{
		base.InnerList.Remove(class1387_0);
	}
}
