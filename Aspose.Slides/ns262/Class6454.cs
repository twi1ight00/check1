using ns218;
using ns253;

namespace ns262;

internal class Class6454 : Class6452
{
	public Class6454(Interface304 serviceLocator, Class6438 run, Interface314 tokenIterator)
		: base(serviceLocator, run, tokenIterator)
	{
	}

	protected override string vmethod_0()
	{
		return string_0;
	}

	protected override void vmethod_1()
	{
		double_0 = Class5955.smethod_38(class5999_0.method_2(string_0));
		double_0 += base.RunProperties.Spacing.ValueInEmus * (double)string_0.Length;
	}
}
