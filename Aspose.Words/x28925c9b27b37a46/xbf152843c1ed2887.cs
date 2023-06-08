using System;
using System.Threading;
using Aspose;
using Aspose.Words;

namespace x28925c9b27b37a46;

[JavaManual("Completelly different in java: java has standard thread interruption framevork.")]
internal class xbf152843c1ed2887
{
	[ThreadStatic]
	private static InterruptionToken xeee835e03a3a30f8;

	internal static void x3bc66b20ee9d88e1()
	{
		if (xeee835e03a3a30f8 != null && xeee835e03a3a30f8.x0efc97b7d837bd49)
		{
			xeee835e03a3a30f8.x74f5a1ef3906e23c();
			throw new ThreadInterruptedException("Aspose.Words has been interrupted by a user request.");
		}
	}

	internal static void x2e0d2f695a7a4634(InterruptionToken x153c99a852375422)
	{
		xeee835e03a3a30f8 = x153c99a852375422;
	}
}
