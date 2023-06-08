namespace x2a6f63b6650e76c4;

internal class xc31570bcb246a8f4 : x3e270ab1f00c767a
{
	protected override int ParameterCountMin => 2;

	protected override int ParameterCountMax => 2;

	protected override x82e26649b09596bd EvaluateCore(xc50df386fc548c72 parameters)
	{
		double x7ce859afc0c = parameters.get_xe6d4b1b411ed94b5(0).x7ce859afc0c75642;
		double x7ce859afc0c2 = parameters.get_xe6d4b1b411ed94b5(1).x7ce859afc0c75642;
		if (x7ce859afc0c2 == 0.0)
		{
			return new xf7d966ea5d1701b6("!Zero Divide");
		}
		return x918e475ee39e3253.xcf290d1e33e810d0(parameters.get_xe6d4b1b411ed94b5(0), parameters.get_xe6d4b1b411ed94b5(1), x7ce859afc0c % x7ce859afc0c2);
	}
}
