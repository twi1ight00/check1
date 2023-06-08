using System;

namespace x2a6f63b6650e76c4;

internal class xd11e829291b202c6 : x2b6290a438cfc02d
{
	protected override double InitialValue => double.MinValue;

	protected override double Apply(double currentValue, double parameterValue)
	{
		return Math.Max(currentValue, parameterValue);
	}
}
