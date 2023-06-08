namespace ns36;

internal interface Interface11
{
	Interface12 this[int index] { get; }

	int Count { get; }

	void Add(params double[] yValues);

	int Add(double yValues);

	void imethod_0(params double[] xValues);

	void imethod_1(params double[] sizes);
}
