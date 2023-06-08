using Aspose.Words.Fields;
using x28925c9b27b37a46;

namespace xfbd1009a0cbb9842;

internal class x54b0ce4be209efe2 : xf83652aff352c801
{
	private readonly x7e263f21a73a027a xbe1b3879b7d92a27;

	internal x54b0ce4be209efe2(Field field, x7e263f21a73a027a result)
		: base(field)
	{
		xbe1b3879b7d92a27 = result;
	}

	protected override void ApplyResultCore()
	{
		x78f7ad9d7fd68e82 xcbf24c118ac8aa0b = new x78f7ad9d7fd68e82(isTrimDoubleQuotes: true);
		if (xbe1b3879b7d92a27 != null && !xbe1b3879b7d92a27.x30d6662e83251ab4 && !xbe1b3879b7d92a27.x7149c962c02931b3)
		{
			x0a28863c804404d7.x5af2763689ebe731(xbe1b3879b7d92a27, base.xd1b40af56a8385d4.End, xcbf24c118ac8aa0b);
		}
	}
}
