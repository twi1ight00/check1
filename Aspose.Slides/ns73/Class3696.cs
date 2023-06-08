namespace ns73;

internal class Class3696<T>
{
	private Delegate2774<T> delegate2774_0;

	private T gparam_0;

	private bool bool_0;

	public T Value
	{
		get
		{
			if (!bool_0)
			{
				gparam_0 = delegate2774_0();
			}
			return gparam_0;
		}
	}

	public Class3696(Delegate2774<T> valueBuilder)
	{
		delegate2774_0 = valueBuilder;
	}
}
