using ns67;

namespace ns68;

internal abstract class Class2991
{
	private Struct159 struct159_0;

	private Struct159 struct159_1;

	public Struct159 A => struct159_1;

	public Struct159 B => struct159_0;

	public Class2991(Struct159 a, Struct159 b)
	{
		struct159_1 = a;
		struct159_0 = b;
	}

	public void method_0()
	{
		struct159_0 = new Struct159(struct159_1.X - (struct159_0.X - struct159_1.X), struct159_1.Y - (struct159_0.Y - struct159_1.Y));
	}
}
