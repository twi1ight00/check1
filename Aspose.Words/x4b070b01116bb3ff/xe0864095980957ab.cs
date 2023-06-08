using System.IO;
using Aspose.Words.Saving;
using x1c8faa688b1f0b0c;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using x7dc87ca8f7f7b273;
using xf989f31a236ff98c;

namespace x4b070b01116bb3ff;

internal class xe0864095980957ab : x6c74398bceb133f8
{
	private x67cee8c622ddae95 x574b2eddfff7d520;

	protected override void DoStartDocument(x8556eed81191af11 saveInfo, xfaf91ffd88d78c15 docInfo)
	{
		SvgSaveOptions svgSaveOptions = (SvgSaveOptions)saveInfo.xf57de0fd37d5e97d;
		xbc9dfa2bfc69713d xbc9dfa2bfc69713d = svgSaveOptions.x5eff1f3a09faac7e();
		xbc9dfa2bfc69713d.xc605b5c8a6696acf = docInfo.xc605b5c8a6696acf;
		if (!x0d299f323d241756.x5959bccb67bbf051(xbc9dfa2bfc69713d.x95e7cce59d14bdff))
		{
			xbc9dfa2bfc69713d.x95e7cce59d14bdff = (x0d299f323d241756.x5959bccb67bbf051(saveInfo.xa39af5a82860a9a3) ? Path.GetFileNameWithoutExtension(saveInfo.xa39af5a82860a9a3) : "");
		}
		if (!x0d299f323d241756.x5959bccb67bbf051(xbc9dfa2bfc69713d.xda77249ca2dc4984))
		{
			if (x0d299f323d241756.x5959bccb67bbf051(saveInfo.xa39af5a82860a9a3))
			{
				xbc9dfa2bfc69713d.xda77249ca2dc4984 = Path.Combine(Path.GetDirectoryName(saveInfo.xa39af5a82860a9a3), xbc9dfa2bfc69713d.x95e7cce59d14bdff);
			}
			else
			{
				xbc9dfa2bfc69713d.x016e5a0032b3cd7b = true;
			}
		}
		x574b2eddfff7d520 = new x67cee8c622ddae95(saveInfo.xb8a774e0111d0fbe, xbc9dfa2bfc69713d);
		x574b2eddfff7d520.x9b9ed0109b743e3b();
	}

	protected override void DoRenderPage(xc67adcdbca121a26 page)
	{
		x574b2eddfff7d520.xe406325e56f74b46(page);
	}

	protected override SaveOutputParameters DoEndDocument()
	{
		x574b2eddfff7d520.xa0dfc102c691b11f();
		return new SaveOutputParameters("image/svg+xml");
	}
}
