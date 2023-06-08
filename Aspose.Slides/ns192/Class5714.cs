using System.Collections;

namespace ns192;

internal class Class5714
{
	private int int_0 = 1;

	private BitArray bitArray_0 = new BitArray(1000);

	internal int method_0()
	{
		return int_0;
	}

	internal void method_1(int start, int end)
	{
		for (int i = start - 1; i < end; i++)
		{
			bitArray_0.Set(i, value: true);
		}
		int_0 = end + 1;
		while (bitArray_0.Get(int_0 - 1))
		{
			int_0++;
		}
	}

	internal void method_2(ArrayList pendingSpans)
	{
		bitArray_0.SetAll(value: false);
		for (int i = 0; i < pendingSpans.Count; i++)
		{
			Class5748 @class = (Class5748)pendingSpans[i];
			if (@class != null)
			{
				if (@class.method_1() == 0)
				{
					pendingSpans[i] = null;
				}
				else
				{
					bitArray_0.Set(i, value: true);
				}
			}
		}
		int_0 = 1;
		while (bitArray_0.Get(int_0 - 1))
		{
			int_0++;
		}
	}

	public bool method_3(int colNr)
	{
		return bitArray_0.Get(colNr - 1);
	}
}
