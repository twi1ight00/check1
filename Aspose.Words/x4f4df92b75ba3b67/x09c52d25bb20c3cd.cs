using x66dd9eaee57cfba4;
using x6c95d9cf46ff5f25;

namespace x4f4df92b75ba3b67;

internal class x09c52d25bb20c3cd : x6abbea4951acbffd
{
	private readonly xcd986872cf3bcf68 xe65db51216614d6f;

	public x09c52d25bb20c3cd(xcd986872cf3bcf68 fontSubset)
	{
		xe65db51216614d6f = fontSubset;
	}

	public override void WriteEncodingToFontDictionary(x4f40d990d5bf81a6 writer)
	{
		writer.xa4dc0ad8886e23a2("/Encoding", "/Identity-H");
	}

	public override void WriteText(string text, xcd769e39c0788209 writer)
	{
		writer.x6210059f049f0d48("(");
		foreach (int item in new x115139807e6482f7(text))
		{
			int num = xe65db51216614d6f.x3452aa488cc9006d(item);
			if (num >= 0)
			{
				writer.x3612a596c28e1b59(num);
			}
		}
		writer.x6210059f049f0d48(")");
	}
}
