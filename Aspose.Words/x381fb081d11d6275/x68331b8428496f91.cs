using Aspose.Words;

namespace x381fb081d11d6275;

internal abstract class x68331b8428496f91
{
	private readonly IWarningCallback xa056586c1f99e199;

	protected x68331b8428496f91(IWarningCallback warningCallback)
	{
		xa056586c1f99e199 = warningCallback;
	}

	internal void xbbf9a1ead81dd3a1(WarningType x9f91de645a9fe01a, string xc2358fbac7da3d45)
	{
		if (xa056586c1f99e199 != null)
		{
			xa056586c1f99e199.Warning(new WarningInfo(x9f91de645a9fe01a, GetWarningSource(), xc2358fbac7da3d45));
		}
	}

	protected abstract WarningSource GetWarningSource();
}
