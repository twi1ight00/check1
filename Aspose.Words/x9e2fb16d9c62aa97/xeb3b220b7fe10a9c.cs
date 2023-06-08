using System;
using System.IO;
using Aspose.Words.Saving;
using x1c8faa688b1f0b0c;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using xe8a881d5eff3c473;
using xf989f31a236ff98c;

namespace x9e2fb16d9c62aa97;

internal class xeb3b220b7fe10a9c : x6c74398bceb133f8
{
	private x7fcf08d8ade7229c x574b2eddfff7d520;

	protected override void DoStartDocument(x8556eed81191af11 saveInfo, xfaf91ffd88d78c15 docInfo)
	{
		if (!x0d299f323d241756.x5959bccb67bbf051(saveInfo.xa39af5a82860a9a3))
		{
			throw new InvalidOperationException("In this version saving in the XAML fixed document format can only be done to a file, not to a stream.");
		}
		string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(saveInfo.xa39af5a82860a9a3);
		string resourcesFolderPath = Path.Combine(Path.GetDirectoryName(saveInfo.xa39af5a82860a9a3), fileNameWithoutExtension);
		x54b98d0096d7251a warningCallback = new x7c8328a75e9baa2d(saveInfo.xf57de0fd37d5e97d.WarningCallback);
		x574b2eddfff7d520 = new x7fcf08d8ade7229c(saveInfo.xb8a774e0111d0fbe, resourcesFolderPath, fileNameWithoutExtension, warningCallback);
	}

	protected override void DoRenderPage(xc67adcdbca121a26 page)
	{
		x574b2eddfff7d520.xe406325e56f74b46(page);
	}

	protected override SaveOutputParameters DoEndDocument()
	{
		x574b2eddfff7d520.xa0dfc102c691b11f();
		return new SaveOutputParameters("application/xml");
	}
}
