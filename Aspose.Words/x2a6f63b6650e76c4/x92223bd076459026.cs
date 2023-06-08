using System;

namespace x2a6f63b6650e76c4;

internal class x92223bd076459026 : x2b6290a438cfc02d
{
	protected override double InitialValue => double.MaxValue;

	protected override double Apply(double currentValue, double parameterValue)
	{
		return Math.Min(currentValue, parameterValue);
	}
}
