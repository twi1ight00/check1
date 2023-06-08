using Aspose;
using x6c95d9cf46ff5f25;

namespace x381fb081d11d6275;

internal abstract class x05df33911093beb0
{
	private string x44dc667473193862;

	private string xdb32b924c50f89cb;

	internal bool x9d9e341ca28e413c => x44dc667473193862 != null;

	internal bool x4e44079093b28b81(string x585da4d9795fa783, string x11d58b056c032b03, bool xe389b456117f37b2)
	{
		if (x9d9e341ca28e413c || !x0d299f323d241756.x5959bccb67bbf051(x585da4d9795fa783))
		{
			return false;
		}
		if (!ValidateHyperlinkCore(x585da4d9795fa783, xe389b456117f37b2))
		{
			return false;
		}
		x44dc667473193862 = xc40cd83fcfb1a3ba(x585da4d9795fa783);
		if (x11d58b056c032b03.Length != 0)
		{
			xdb32b924c50f89cb = xc40cd83fcfb1a3ba(x11d58b056c032b03);
		}
		WriteHyperlinkStartCore(x44dc667473193862, xdb32b924c50f89cb);
		return true;
	}

	internal void x7e7f331e0d5f065a()
	{
		if (x9d9e341ca28e413c)
		{
			WriteHyperlinkStartCore(x44dc667473193862, xdb32b924c50f89cb);
		}
	}

	internal void xd5a7d506e4113f23()
	{
		if (x9d9e341ca28e413c)
		{
			WriteHyperlinkEndCore();
		}
	}

	internal void x1210e8a0b401d5a2()
	{
		if (x9d9e341ca28e413c)
		{
			WriteHyperlinkEndCore();
			x44dc667473193862 = null;
			xdb32b924c50f89cb = null;
		}
	}

	[JavaThrows(true)]
	protected abstract void WriteHyperlinkStartCore(string href, string target);

	[JavaThrows(true)]
	protected abstract void WriteHyperlinkEndCore();

	[JavaThrows(true)]
	protected abstract bool ValidateHyperlinkCore(string href, bool forceOutput);

	protected abstract string CorrectHref(string href);

	private string xc40cd83fcfb1a3ba(string x585da4d9795fa783)
	{
		string x585da4d9795fa784 = CorrectHref(x585da4d9795fa783);
		return x0d4d45882065c63e.x8644581dcf469731(x585da4d9795fa784);
	}
}
