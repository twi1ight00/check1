using System;

namespace ns237;

internal abstract class Class6522 : Class6514
{
	private readonly int int_1;

	private readonly int int_2;

	private readonly float[] float_0;

	private readonly float[] float_1;

	internal float[] Domain => float_0;

	internal float[] Range => float_1;

	internal int NumberOfInputs => int_1;

	internal int NumberOfOutputs => int_2;

	protected abstract int FunctionType { get; }

	internal Class6522(Class6672 context, int nInputs, int nOutputs, float[] domain, float[] range)
		: base(context)
	{
		int_1 = nInputs;
		int_2 = nOutputs;
		smethod_0(domain, NumberOfInputs);
		float_0 = domain;
		smethod_0(range, NumberOfOutputs);
		float_1 = range;
	}

	private static void smethod_0(float[] minMaxArray, int arrSize)
	{
		if (minMaxArray.Length % arrSize != 0)
		{
			throw new ArgumentException("Incorrect array dimension.");
		}
		int num = 0;
		while (true)
		{
			if (num < arrSize)
			{
				if (!(minMaxArray[num * 2] <= minMaxArray[num * 2 + 1]))
				{
					break;
				}
				num++;
				continue;
			}
			return;
		}
		throw new ArgumentException("Min is greater than Max.");
	}

	internal override void vmethod_2(Class6679 writer)
	{
		writer.method_18("/FunctionType", FunctionType);
		writer.method_11("/Domain", float_0);
		writer.method_11("/Range", float_1);
		base.vmethod_2(writer);
	}
}
