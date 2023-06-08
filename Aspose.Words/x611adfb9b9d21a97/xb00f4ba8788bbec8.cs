using System.Text;
using Aspose.Words;
using Aspose.Words.Saving;
using x1a3e96f4b89a7a77;
using x28925c9b27b37a46;
using x55b2bd426d41d30c;
using x6c95d9cf46ff5f25;
using xbe73d5820f7f4ae3;

namespace x611adfb9b9d21a97;

internal abstract class xb00f4ba8788bbec8 : x873451caae5ad4ae
{
	protected const string x746c488f87a31292 = "uid";

	private readonly x0ca5e8b532953a51 x9fb0e9c0b1bdc4b3;

	private readonly string xc37fae031f714e86;

	private readonly x8556eed81191af11 xb36c250515e408ad;

	private static readonly Encoding x9f38ac3db73a8ba8 = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);

	internal x0ca5e8b532953a51 x0e063e8407aa6f22 => x9fb0e9c0b1bdc4b3;

	internal string xf1929ebebc6226d4 => xc37fae031f714e86;

	internal HtmlSaveOptions xf57de0fd37d5e97d => (HtmlSaveOptions)xb36c250515e408ad.xf57de0fd37d5e97d;

	internal Document xbd43463cc8d073a3 => xb36c250515e408ad.x2c8c6741422a1298;

	internal string x38b59ec08314c0f0 => x845b43043aba36eb(xc37fae031f714e86);

	protected xb00f4ba8788bbec8(string partName, string documentBaseName, x8556eed81191af11 saveInfo)
		: this(new x0ca5e8b532953a51(partName), documentBaseName, saveInfo)
	{
	}

	protected xb00f4ba8788bbec8(x0ca5e8b532953a51 part, string documentBaseName, x8556eed81191af11 saveInfo)
		: base(part.xb8a774e0111d0fbe, x9f38ac3db73a8ba8, saveInfo.xf57de0fd37d5e97d.PrettyFormat, useOnOff: true)
	{
		x9fb0e9c0b1bdc4b3 = part;
		xc37fae031f714e86 = documentBaseName;
		xb36c250515e408ad = saveInfo;
	}

	protected void x05e6e2c11290d2b0(string x121383aa64985888, string xb591dc602a67d872, string x14ce39bb4fe9496c, string xbcea506a33cf9111)
	{
		if (x0d299f323d241756.x5959bccb67bbf051(xbcea506a33cf9111))
		{
			x2307058321cdb62f(x121383aa64985888);
			xff520a0047c27122(xb591dc602a67d872, x14ce39bb4fe9496c);
			x3d1be38abe5723e3(xbcea506a33cf9111);
			x2dfde153f4ef96d0();
		}
	}

	protected void x4495d55170e56e28(string xc15bd84e01929885, string xd1d55a56253db2df)
	{
		x2307058321cdb62f("meta");
		xff520a0047c27122("name", xc15bd84e01929885);
		xff520a0047c27122("content", xd1d55a56253db2df);
		x2dfde153f4ef96d0();
	}

	protected static string x4f579785e809375e(string x37a96021dbbe3532)
	{
		if (!x0d299f323d241756.x5959bccb67bbf051(x37a96021dbbe3532))
		{
			return "Untitled";
		}
		return x37a96021dbbe3532;
	}

	protected string x0a758a5b915637a6()
	{
		string result = "en-US";
		Style style = xb36c250515e408ad.x2c8c6741422a1298.Styles[0];
		if (style != null)
		{
			int localeId = style.Font.LocaleId;
			if (localeId != 1024)
			{
				string text = x0eb9a864413f34de.xef1c76b0fb2ec874(localeId);
				if (x0d299f323d241756.x5959bccb67bbf051(text))
				{
					result = text.Replace('_', '-');
				}
			}
		}
		return result;
	}

	internal static string x845b43043aba36eb(string x79ecfa9d72eb3b1a)
	{
		return $"OEBPS/{x79ecfa9d72eb3b1a}.opf";
	}

	internal static string xe6ef738f4b633cf2(string x79ecfa9d72eb3b1a, bool x6c20b1df8047763a)
	{
		string format = (x6c20b1df8047763a ? "{0}.html" : "OEBPS/{0}.html");
		return string.Format(format, x79ecfa9d72eb3b1a);
	}

	internal static string xc40d5fe84864cc92(string x79ecfa9d72eb3b1a, bool x6c20b1df8047763a)
	{
		string format = (x6c20b1df8047763a ? "{0}.ncx" : "OEBPS/{0}.ncx");
		return string.Format(format, x79ecfa9d72eb3b1a);
	}
}
