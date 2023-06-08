using System;
using System.Runtime.CompilerServices;
using Aspose.Cells.Charts;

namespace ns3;

internal struct Struct66 : IComparable
{
	private int int_0;

	private Series series_0;

	internal Struct66(Series series_1)
	{
		series_0 = series_1;
		int_0 = -1;
	}

	[SpecialName]
	internal int method_0()
	{
		return int_0;
	}

	[SpecialName]
	internal void method_1(int int_1)
	{
		int_0 = int_1;
	}

	[SpecialName]
	internal Series method_2()
	{
		return series_0;
	}

	[SpecialName]
	internal int method_3()
	{
		return series_0.method_0();
	}

	public int CompareTo(object obj)
	{
		if (obj == null)
		{
			return -1;
		}
		Struct66 @struct = (Struct66)obj;
		if (method_3() == @struct.method_3())
		{
			return 0;
		}
		if (method_3() > @struct.method_3())
		{
			return 1;
		}
		return -1;
	}
}
