namespace ns67;

internal abstract class Class3063
{
	private readonly Class3068 class3068_0;

	public Class3068 RenderingAttributes => class3068_0;

	public abstract void vmethod_0(Interface53 device);

	protected Class3063(Class3068 attributes)
	{
		class3068_0 = attributes;
	}

	protected Class3427 method_0(Struct159 point2D)
	{
		return new Class3427(point2D.X, point2D.Y, 0.0);
	}
}
