using ns67;

namespace ns68;

internal sealed class Class3025 : Class3024
{
	private Struct159 struct159_0;

	private Struct159 struct159_1;

	private Struct159 struct159_2;

	private Struct159 struct159_3;

	public Struct159 TopA => struct159_0;

	public Struct159 TopB => struct159_1;

	public Struct159 BottomA => struct159_2;

	public Struct159 BottomB => struct159_3;

	public Class3025(double bottomDistToEdge, double topDistToEdge, Struct159 topA, Struct159 topB, Struct159 bottomA, Struct159 bottomB)
		: base(bottomDistToEdge, topDistToEdge)
	{
		struct159_0 = topA;
		struct159_1 = topB;
		struct159_2 = bottomA;
		struct159_3 = bottomB;
	}
}
