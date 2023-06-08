namespace x2a6f63b6650e76c4;

internal class xd6040b0a733bd226 : x2b6290a438cfc02d
{
	protected override double Apply(double currentValue, double parameterValue)
	{
		return currentValue + parameterValue;
	}

	protected override double FinalizeCalculation(double currentValue, int parameterCount)
	{
		return currentValue / (double)parameterCount;
	}
}
