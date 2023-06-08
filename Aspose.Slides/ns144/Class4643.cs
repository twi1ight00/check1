using ns139;

namespace ns144;

internal class Class4643
{
	private Class4616 class4616_0;

	private Class4616 class4616_1;

	public Class4616 OriginalPathDefinition => class4616_0;

	public Class4616 PathDefinition => class4616_1;

	public Class4643(Class4616 pathDefinition)
	{
		class4616_1 = pathDefinition;
		class4616_0 = (Class4616)class4616_1.Clone();
	}
}
