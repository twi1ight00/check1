using Aspose.Words.Saving;
using x1c8faa688b1f0b0c;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using xc7ce8a6a920f8012;
using xf989f31a236ff98c;

namespace xd6ff03883d34d0de;

internal class xa58f8cc58d37b8dc : x6c74398bceb133f8
{
	private x487566b766195f84 x574b2eddfff7d520;

	private x8556eed81191af11 xb36c250515e408ad;

	protected override void DoStartDocument(x8556eed81191af11 saveInfo, xfaf91ffd88d78c15 docInfo)
	{
		xb36c250515e408ad = saveInfo;
		SwfSaveOptions swfSaveOptions = (SwfSaveOptions)saveInfo.xf57de0fd37d5e97d;
		x574b2eddfff7d520 = new x487566b766195f84(saveInfo.xb8a774e0111d0fbe, docInfo, swfSaveOptions.x5eff1f3a09faac7e());
	}

	protected override void DoRenderPage(xc67adcdbca121a26 page)
	{
		x574b2eddfff7d520.xe406325e56f74b46(page);
	}

	protected override SaveOutputParameters DoEndDocument()
	{
		x574b2eddfff7d520.xa0dfc102c691b11f();
		return new SaveOutputParameters("application/x-shockwave-flash");
	}
}
