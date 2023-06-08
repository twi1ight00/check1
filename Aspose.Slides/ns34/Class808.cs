using System;
using System.Collections.Generic;
using Aspose.Slides.Charts;
using ns56;

namespace ns34;

internal sealed class Class808
{
	private List<Class1676> list_0;

	private ChartDataWorkbook chartDataWorkbook_0;

	internal uint uint_0;

	internal uint uint_1;

	private Class1502 class1502_0;

	public int Count => list_0.Count;

	public string this[int index]
	{
		get
		{
			Class1676 @class = list_0[index];
			string text = @class.T;
			if (text != null)
			{
				return text;
			}
			if (@class.RList.Length > 0)
			{
				Class1653[] rList = @class.RList;
				foreach (Class1653 class2 in rList)
				{
					text += class2.T;
				}
				return text;
			}
			throw new NotImplementedException("SharedString with index " + index + " has unknown type");
		}
	}

	internal Class1502 ExtLst
	{
		get
		{
			return class1502_0;
		}
		set
		{
			class1502_0 = value;
		}
	}

	internal Class808(ChartDataWorkbook parent)
	{
		list_0 = new List<Class1676>();
		chartDataWorkbook_0 = parent;
	}

	public void Clear()
	{
		uint_0 = 0u;
		uint_1 = 0u;
		list_0.Clear();
	}

	internal int Add(string value)
	{
		Class1676 @class = new Class1676();
		@class.T = value;
		list_0.Add(@class);
		return list_0.Count - 1;
	}

	internal int Add(Class1676 rstElementData)
	{
		list_0.Add(rstElementData);
		return list_0.Count - 1;
	}

	internal Class1676 method_0(int index)
	{
		return list_0[index];
	}
}
