using ns53;

namespace ns54;

internal abstract class Class1344
{
	private Class1348 class1348_0;

	private readonly Class1183 class1183_0;

	public Class1348 RelationshipsOfCurrentPartEntry
	{
		get
		{
			return class1348_0;
		}
		set
		{
			class1348_0 = value;
		}
	}

	public Class1183 Package => class1183_0;

	public Class1344(Class1183 package)
	{
		class1183_0 = package;
	}
}
