namespace ns69;

internal class Class3048 : Class3047
{
	private Class3033 class3033_0;

	private Class3033 class3033_1;

	private Class3033 class3033_2;

	private Class3040 class3040_0;

	public Class3033 IntersectedEdge => class3033_0;

	public Class3033 EdgeV0S0 => class3033_1;

	public Class3033 EdgeV0S1 => class3033_2;

	public Class3040 TriangleMustBeSplit => class3040_0;

	public Class3048(Class3033 intersectedEdge, Class3059 intersectedVertex, Class3033 edgeV0S0, Class3033 edgeV0S1, Class3040 triangleMustBeSplit)
	{
		class3033_0 = intersectedEdge;
		class3059_0 = intersectedVertex;
		class3033_1 = edgeV0S0;
		class3033_2 = edgeV0S1;
		class3040_0 = triangleMustBeSplit;
	}
}
