using System.IO;
using Aspose;

namespace xe9865c3fb834da49;

internal class x3d213ffad4d30370
{
	private readonly Stream x7bd3dc4ffc51e023;

	private readonly bool xdf0cff1d38053b5d;

	internal x3d213ffad4d30370(Stream userStream, bool keepStreamOpen)
	{
		x7bd3dc4ffc51e023 = userStream;
		xdf0cff1d38053b5d = keepStreamOpen;
	}

	internal Stream x59aa197935be8c77()
	{
		return x7bd3dc4ffc51e023;
	}

	[JavaThrows(true)]
	internal void x14e5354973c7740e()
	{
		if (!xdf0cff1d38053b5d)
		{
			x7bd3dc4ffc51e023.Close();
		}
	}
}
