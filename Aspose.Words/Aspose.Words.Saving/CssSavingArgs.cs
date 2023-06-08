using System.IO;
using xe9865c3fb834da49;

namespace Aspose.Words.Saving;

public class CssSavingArgs
{
	private Stream x9a0cf6bb22200d26;

	private readonly Document xd1424e1a0bb4a72b;

	private bool xfd4b45df44b8fc62;

	private bool xf41959cb591fe759;

	public Document Document => xd1424e1a0bb4a72b;

	public bool KeepCssStreamOpen
	{
		get
		{
			return xfd4b45df44b8fc62;
		}
		set
		{
			xfd4b45df44b8fc62 = value;
		}
	}

	public Stream CssStream
	{
		get
		{
			return x9a0cf6bb22200d26;
		}
		set
		{
			x9a0cf6bb22200d26 = value;
		}
	}

	public bool IsExportNeeded
	{
		get
		{
			return xf41959cb591fe759;
		}
		set
		{
			xf41959cb591fe759 = value;
		}
	}

	internal bool x3477a684b2bbe7b0 => x9a0cf6bb22200d26 != null;

	internal CssSavingArgs(Document document)
	{
		xd1424e1a0bb4a72b = document;
	}

	internal x3d213ffad4d30370 xd9984d5750dc6ac8()
	{
		return new x3d213ffad4d30370(x9a0cf6bb22200d26, xfd4b45df44b8fc62);
	}
}
