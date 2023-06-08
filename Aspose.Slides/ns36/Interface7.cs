namespace ns36;

internal interface Interface7
{
	Interface8 this[int index] { get; }

	int Count { get; }

	Interface8 imethod_0(object labelValue);

	void imethod_1(params object[] labels);

	void Clear();

	void RemoveAt(int i);
}
