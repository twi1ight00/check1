namespace x2a6f63b6650e76c4;

internal abstract class x2b6290a438cfc02d : x3e270ab1f00c767a
{
	protected virtual double InitialValue => 0.0;

	internal override bool xd06fa436eec0b476 => true;

	protected override int ParameterCountMin => 1;

	protected override int ParameterCountMax => int.MaxValue;

	protected override x82e26649b09596bd EvaluateCore(xc50df386fc548c72 parameters)
	{
		double currentValue = InitialValue;
		int num = 0;
		foreach (x82e26649b09596bd parameter in parameters)
		{
			num++;
			if (parameter.xca3ee5e02f497e0b != 0)
			{
				currentValue = Apply(currentValue, parameter.x7ce859afc0c75642);
			}
		}
		return x918e475ee39e3253.xcf290d1e33e810d0(parameters, FinalizeCalculation(currentValue, num));
	}

	protected virtual double Apply(double currentValue, double parameterValue)
	{
		return currentValue;
	}

	protected virtual double FinalizeCalculation(double currentValue, int parameterCount)
	{
		return currentValue;
	}
}
