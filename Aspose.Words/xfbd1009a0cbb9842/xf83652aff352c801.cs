using Aspose;
using Aspose.Words.Fields;
using x28925c9b27b37a46;

namespace xfbd1009a0cbb9842;

internal abstract class xf83652aff352c801
{
	private readonly Field x54c413cc80cb99d5;

	private readonly bool xa0c04543c9e6f9ea;

	protected Field xd1b40af56a8385d4 => x54c413cc80cb99d5;

	protected xf83652aff352c801(Field field)
		: this(field, applyFormat: true)
	{
	}

	protected xf83652aff352c801(Field field, bool applyFormat)
	{
		x54c413cc80cb99d5 = field;
		xa0c04543c9e6f9ea = applyFormat;
	}

	internal void x7d44c41f397d72e0()
	{
		x9710cfdf3f61d319 x9710cfdf3f61d320 = (xa0c04543c9e6f9ea ? xd1b40af56a8385d4.xa890d2fd18bed2bc.xab1a64aa04b401a0().xc5dc1bbbb8923eaa() : null);
		x54c413cc80cb99d5.x5f4c2139149eaf99(x5113d1e6ef8a0405: true);
		x7e263f21a73a027a x7e263f21a73a027a = x54c413cc80cb99d5.xabae4fa6681a6afd(x7d5e2f34b6651bf4.xf8d31d196ccd74c4);
		x7e263f21a73a027a.x52b190e626f65140();
		ApplyResultCore();
		x9710cfdf3f61d320?.x18739bb47cc530dd(x7e263f21a73a027a);
	}

	[JavaThrows(true)]
	protected abstract void ApplyResultCore();
}
