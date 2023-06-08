using ns69;

namespace ns68;

internal sealed class Class3021
{
	private Class3019 class3019_0;

	private Class3002 class3002_0;

	private Class3000 class3000_0;

	public Class3019 BackBuffer => class3019_0;

	internal Class3002 CellRecognizer => class3002_0;

	public Class3021(Class3000 projectionsLayer)
	{
		class3000_0 = projectionsLayer;
	}

	public void method_0(Class3057 region)
	{
		Class2998 structuralEdges = class3000_0.StructuralEdges;
		Class2999 contours = class3000_0.Contours;
		Class3022 @class = new Class3022(class3000_0);
		@class.method_0(region);
		class3019_0 = new Class3019(structuralEdges, class3000_0.StructuralEdgesBox, contours);
		class3002_0 = new Class3002(class3000_0);
		CellRecognizer.method_0();
	}
}
