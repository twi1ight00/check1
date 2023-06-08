namespace ns68;

internal sealed class Class3023
{
	private Class3000 class3000_0;

	public Class3023(Class3000 projectionsLayer)
	{
		class3000_0 = projectionsLayer;
	}

	public void method_0()
	{
		Class2998 structuralEdges = class3000_0.StructuralEdges;
		int count = structuralEdges.Count;
		for (int i = 0; i < count; i++)
		{
			structuralEdges[i].Step2PrimitiveBuilder.method_0();
		}
	}
}
