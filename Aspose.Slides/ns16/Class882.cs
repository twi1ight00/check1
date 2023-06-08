using System.Collections.Generic;

namespace ns16;

internal class Class882
{
	private Class1031 class1031_0;

	private int int_0 = -1;

	private Dictionary<uint, object> dictionary_0;

	private uint uint_0 = 1u;

	public Class1031 SlideSerializationContext => class1031_0;

	internal int MaxChartSeriesIdxUsed
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	internal Dictionary<uint, object> UsedChartSeriesIdxs
	{
		get
		{
			return dictionary_0;
		}
		set
		{
			dictionary_0 = value;
		}
	}

	internal Class882(Class1031 slideSerializationContext)
	{
		class1031_0 = slideSerializationContext;
		dictionary_0 = new Dictionary<uint, object>();
	}

	internal uint method_0()
	{
		return ++uint_0;
	}
}
