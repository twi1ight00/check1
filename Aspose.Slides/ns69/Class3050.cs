namespace ns69;

internal sealed class Class3050
{
	private Class3056 class3056_0;

	private Class3060 class3060_0;

	private Class3035 class3035_0;

	private Class3044 class3044_0;

	private Class3035 class3035_1;

	private Class3041 class3041_0;

	public Class3060 VerticesToAdd => class3060_0;

	public Class3035 EdgesToAdd => class3035_0;

	public Class3044 TrianglesToAdd => class3044_0;

	public Class3035 EdgesToDel => class3035_1;

	public Class3041 TrianglesToDel => class3041_0;

	public Class3050(Class3056 triangulation)
	{
		class3056_0 = triangulation;
		class3060_0 = new Class3060();
		class3035_0 = new Class3035();
		class3044_0 = new Class3044();
		class3035_1 = new Class3035();
		class3041_0 = new Class3041();
	}

	public Class3041 method_0()
	{
		for (int i = 0; i < EdgesToDel.Count; i++)
		{
			Class3058.smethod_1(class3056_0, EdgesToDel[i], preserveAloneSecondaryEdges: true);
		}
		for (int j = 0; j < VerticesToAdd.Count; j++)
		{
			class3056_0.Vertices.Add(VerticesToAdd[j]);
		}
		for (int k = 0; k < EdgesToAdd.Count; k++)
		{
			class3056_0.Edges.method_4(EdgesToAdd[k]);
		}
		Class3041 @class = new Class3041();
		for (int l = 0; l < TrianglesToAdd.Count; l++)
		{
			Class3040 triangle;
			class3056_0.Triangles.Add(triangle = new Class3040(TrianglesToAdd[l].class3059_0, TrianglesToAdd[l].class3059_1, TrianglesToAdd[l].class3059_2, TrianglesToAdd[l].class3033_0, TrianglesToAdd[l].class3033_1, TrianglesToAdd[l].class3033_2));
			@class.Add(triangle);
		}
		return @class;
	}
}
