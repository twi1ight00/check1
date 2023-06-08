using Aspose.Words;
using x28925c9b27b37a46;
using x381fb081d11d6275;
using x6c95d9cf46ff5f25;

namespace xce0136f05681c5e9;

internal class x9e83e90818260fa5 : x05df33911093beb0
{
	private readonly xe2ff3c3cd396cfd9 x09b9574bb5661d62;

	private readonly DocumentBase xd1424e1a0bb4a72b;

	private readonly bool x9e44a5089e11f806;

	internal x9e83e90818260fa5(DocumentBase document, bool enforceEpubCompliance, xe2ff3c3cd396cfd9 htmlWriterCommon)
	{
		x09b9574bb5661d62 = htmlWriterCommon;
		xd1424e1a0bb4a72b = document;
		x9e44a5089e11f806 = enforceEpubCompliance;
	}

	internal void xc2550bde00ba6ebf(string xb41faee6912a2313, string x585da4d9795fa783, bool xe389b456117f37b2)
	{
		x4e44079093b28b81(x585da4d9795fa783, string.Empty, xe389b456117f37b2);
		x09b9574bb5661d62.xe1410f585439c7d4.x3d1be38abe5723e3(xb41faee6912a2313);
		x1210e8a0b401d5a2();
	}

	protected override void WriteHyperlinkStartCore(string href, string target)
	{
		x09b9574bb5661d62.xe1410f585439c7d4.xd52401bdf5aacef6("<a");
		x09b9574bb5661d62.xe1410f585439c7d4.x3d1be38abe5723e3($" href=\"{href}\"");
		if (x0d299f323d241756.x5959bccb67bbf051(target))
		{
			x09b9574bb5661d62.xe1410f585439c7d4.x3d1be38abe5723e3($" target=\"{target}\"");
		}
		x09b9574bb5661d62.xe1410f585439c7d4.xd52401bdf5aacef6(">");
	}

	protected override void WriteHyperlinkEndCore()
	{
		x09b9574bb5661d62.xe1410f585439c7d4.xd52401bdf5aacef6("</a>");
	}

	protected override bool ValidateHyperlinkCore(string href, bool forceOutput)
	{
		if (!forceOutput && x9e44a5089e11f806 && href.StartsWith("#"))
		{
			string xd17ec8f278d25c = href.Substring(1);
			BookmarkStart bookmarkStart = xfcbee4820570241e.x7dff5baaa927f80f(xd1424e1a0bb4a72b, xd17ec8f278d25c);
			if (bookmarkStart == null)
			{
				return false;
			}
		}
		return true;
	}

	protected override string CorrectHref(string href)
	{
		return x09b9574bb5661d62.xb3b0ef5bb7f5a407(href);
	}
}
