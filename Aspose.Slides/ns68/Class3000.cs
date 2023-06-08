using ns69;

namespace ns68;

internal sealed class Class3000
{
	private Class3023 class3023_0;

	private Class3021 class3021_0;

	private Class2998 class2998_0;

	private Class2999 class2999_0;

	private Class2996 class2996_0;

	public Class2998 StructuralEdges => class2998_0;

	public Class2996 StructuralEdgesBox
	{
		get
		{
			return class2996_0;
		}
		set
		{
			class2996_0 = value;
		}
	}

	public Class2999 Contours => class2999_0;

	public Class3021 Step1Builder => class3021_0;

	public Class3023 Step2Builder => class3023_0;

	private Class3000()
	{
		class2998_0 = new Class2998();
		class2999_0 = new Class2999();
	}

	public Class3000(Class3057 region)
		: this()
	{
		class3021_0 = new Class3021(this);
		class3021_0.method_0(region);
		class3023_0 = new Class3023(this);
		class3023_0.method_0();
	}
}
