using System.Collections;
using System.Collections.Generic;
using ns36;

namespace ns37;

internal class Class747 : CollectionBase, Interface11
{
	private Class759 class759_0;

	private Class740 class740_0;

	internal Class759 ASeries => class759_0;

	public Interface12 this[int index]
	{
		get
		{
			if (index >= 0 && index <= base.Count - 1)
			{
				return (Interface12)base.List[index];
			}
			return null;
		}
	}

	internal Class740 Chart => class740_0;

	internal IList ListPoints => base.List;

	internal Class747(Class740 chart, Class759 aSeries)
	{
		class740_0 = chart;
		class759_0 = aSeries;
	}

	public Class748 method_0(int index)
	{
		if (index >= 0 && index <= base.Count - 1)
		{
			return (Class748)base.List[index];
		}
		return null;
	}

	private int Add(Class748 point)
	{
		int result = base.InnerList.Add(point);
		point.ChartPoints = this;
		point.method_0();
		return result;
	}

	public void Add(params double[] yValues)
	{
		for (int i = 0; i < yValues.Length; i++)
		{
			Class748 point = new Class748(class740_0, yValues[i]);
			Add(point);
		}
	}

	public int Add(double yValues)
	{
		Class748 point = new Class748(class740_0, yValues);
		return Add(point);
	}

	public void imethod_0(params double[] xValues)
	{
		for (int i = 0; i < xValues.Length && base.List.Count >= i + 1; i++)
		{
			this[i].XValue = xValues[i];
		}
	}

	public void imethod_1(params double[] sizes)
	{
		for (int i = 0; i < sizes.Length && base.List.Count >= i + 1; i++)
		{
			this[i].BubbleSizeValue = sizes[i];
		}
	}

	internal List<Class748> method_1()
	{
		List<Class748> list = new List<Class748>();
		for (int i = 0; i < base.List.Count; i++)
		{
			Class748 @class = method_0(i);
			if (i == 0)
			{
				list.Add(@class);
				continue;
			}
			bool flag = false;
			for (int j = 0; j < list.Count; j++)
			{
				Class748 class2 = list[j];
				if (!(class2.XValue <= @class.XValue))
				{
					list.Insert(j, @class);
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				list.Add(@class);
			}
		}
		return list;
	}
}
