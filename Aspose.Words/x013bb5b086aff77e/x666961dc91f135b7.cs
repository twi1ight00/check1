using Aspose.Words.Saving;
using x1c8faa688b1f0b0c;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using xaf73fad8cede26de;
using xf989f31a236ff98c;

namespace x013bb5b086aff77e;

internal class x666961dc91f135b7 : x6c74398bceb133f8
{
	private x8ffc07717f2f315f x574b2eddfff7d520;

	private x8556eed81191af11 xb36c250515e408ad;

	protected override void DoStartDocument(x8556eed81191af11 saveInfo, xfaf91ffd88d78c15 docInfo)
	{
		xb36c250515e408ad = saveInfo;
		x574b2eddfff7d520 = x66536e369c26d80c(saveInfo, docInfo);
	}

	protected override void DoRenderPage(xc67adcdbca121a26 page)
	{
		x574b2eddfff7d520.xe406325e56f74b46(page);
	}

	protected override SaveOutputParameters DoEndDocument()
	{
		x574b2eddfff7d520.xa0dfc102c691b11f();
		x574b2eddfff7d520.x39c7aeeec1af9dd0.Save(xb36c250515e408ad.xb8a774e0111d0fbe);
		return new SaveOutputParameters("application/vnd.ms-xpsdocument");
	}

	private static x8ffc07717f2f315f x66536e369c26d80c(x8556eed81191af11 x5ac1382edb7bf2c2, xfaf91ffd88d78c15 xf19321cdbf6cb3f5)
	{
		XpsSaveOptions xpsSaveOptions = (XpsSaveOptions)x5ac1382edb7bf2c2.xf57de0fd37d5e97d;
		return new x8ffc07717f2f315f(xf19321cdbf6cb3f5, xpsSaveOptions.x5eff1f3a09faac7e());
	}
}
