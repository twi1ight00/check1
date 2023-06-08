using Aspose.Words;
using x28925c9b27b37a46;

namespace x1a62aaf14e3c5909;

internal class x373059570f6cfe23
{
	internal DocumentBase x2c8c6741422a1298;

	internal xc93de5b84cb7a11f x1824eec534cbacf7;

	internal x663fe87979a30296 x2a2338af2f7e610e;

	private readonly IWarningCallback xa056586c1f99e199;

	internal x373059570f6cfe23(DocumentBase document, xc93de5b84cb7a11f blipStore, x663fe87979a30296 ruleEngine, IWarningCallback warningCallback)
	{
		x2c8c6741422a1298 = document;
		x1824eec534cbacf7 = blipStore;
		x2a2338af2f7e610e = ruleEngine;
		xa056586c1f99e199 = warningCallback;
	}

	internal void x3dc950453374051a(string xc2358fbac7da3d45)
	{
		x98b0e09ccece0a5a.x3dc950453374051a(xa056586c1f99e199, WarningSource.Doc, xc2358fbac7da3d45);
	}
}
