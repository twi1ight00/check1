using System;

namespace ns67;

internal abstract class Class3378 : ICloneable
{
	public abstract double Length { get; }

	public object Clone()
	{
		return vmethod_0();
	}

	public abstract Class3378 vmethod_0();

	public abstract Class3378 vmethod_1(double distance);

	public abstract Struct159 vmethod_2(double percent);

	public abstract Struct158 vmethod_3(double percent, double length, bool isOutside);
}
