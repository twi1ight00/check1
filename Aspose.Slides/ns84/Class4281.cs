using ns87;

namespace ns84;

internal class Class4281 : Class4269
{
	public Class4193 Name => new Class4193(method_0(Enum600.const_11));

	public Class4338 Duration => Class4338.smethod_4(method_0(Enum600.const_8));

	public Class4338 Delay => Class4338.smethod_4(method_0(Enum600.const_6));

	public Enum518 Direction => method_1<Enum518>(Enum600.const_7);

	public Class4191 TimingFunction => new Class4191(method_0(Enum600.const_13));

	public Enum519 FillMode => method_1<Enum519>(Enum600.const_9);

	public Enum520 PlayState => method_1<Enum520>(Enum600.const_12);

	public float IterationCount => method_3(Enum600.const_10).Value;

	internal Class4281(Class4347 model)
		: base(model)
	{
	}
}
