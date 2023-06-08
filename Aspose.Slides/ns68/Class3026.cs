using ns67;

namespace ns68;

internal sealed class Class3026 : Class3024
{
	private Struct159 struct159_0;

	private Struct159 struct159_1;

	private Struct159 struct159_2;

	public Struct159 Top => struct159_0;

	public Struct159 BottomA => struct159_1;

	public Struct159 BottomB => struct159_2;

	public Class3026(double bottomDistToEdge, double topDistToEdge, Struct159 top, Struct159 bottomA, Struct159 bottomB)
		: base(bottomDistToEdge, topDistToEdge)
	{
		struct159_0 = top;
		struct159_1 = bottomA;
		struct159_2 = bottomB;
	}
}
