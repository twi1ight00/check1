using ns87;

namespace ns84;

internal class Class4298 : Class4269
{
	public Class4295 Left => new Class4295(base.Model, Class4295.Enum601.const_0);

	public Class4295 Right => new Class4295(base.Model, Class4295.Enum601.const_1);

	public Class4295 Top => new Class4295(base.Model, Class4295.Enum601.const_2);

	public Class4295 Bottom => new Class4295(base.Model, Class4295.Enum601.const_3);

	public Enum606 Collapse => method_1<Enum606>(Enum600.const_38);

	public Class4220 Spacing => new Class4220(method_0(Enum600.const_55));

	public Class4288 Radius => new Class4288(base.Model);

	public Class4287 Image => new Class4287(base.Model);

	internal Class4298(Class4345 model)
		: base(model)
	{
	}
}
