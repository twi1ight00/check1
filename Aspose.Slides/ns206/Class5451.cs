namespace ns206;

internal class Class5451
{
	private Class5450 class5450_0;

	private Class5450 class5450_1;

	public Class5451(Class5450 fromQualifier, Class5450 toQualifier)
	{
		class5450_0 = fromQualifier;
		class5450_1 = toQualifier;
	}

	public Class5450 method_0()
	{
		return class5450_0;
	}

	public Class5450 method_1()
	{
		return class5450_1;
	}

	public override string ToString()
	{
		return string.Concat("from=", class5450_0, ", to=", class5450_1);
	}
}
