using Aspose;
using Aspose.Words;
using Aspose.Words.Fields;

namespace xfbd1009a0cbb9842;

internal abstract class x5dc2b4bc740c9563
{
	private readonly Field x54c413cc80cb99d5;

	private readonly x57af31d8c74e631c xf7c2bb1665513b83;

	protected Document x2c8c6741422a1298 => x54c413cc80cb99d5.x357c90b33d6bb8e6();

	protected x5e36356bc92c609b x28fcdc775a1d069c => x54c413cc80cb99d5.x6edce55dcd2d335b;

	protected Field xd1b40af56a8385d4 => x54c413cc80cb99d5;

	protected x57af31d8c74e631c x004daeac26db37fe => xf7c2bb1665513b83;

	protected x5dc2b4bc740c9563(Field field)
		: this(field, null)
	{
	}

	protected x5dc2b4bc740c9563(Field field, x57af31d8c74e631c cleanupAction)
	{
		x54c413cc80cb99d5 = field;
		xf7c2bb1665513b83 = cleanupAction;
	}

	[JavaThrows(true)]
	internal void xb333e1e6c01c2be2()
	{
		PerformCore();
		if (xf7c2bb1665513b83 != null)
		{
			x54c413cc80cb99d5.x77764e51cb2070f9(xf7c2bb1665513b83);
		}
	}

	[JavaThrows(true)]
	protected abstract void PerformCore();
}
