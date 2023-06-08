using System;
using Aspose.Words;
using Aspose.Words.Saving;
using x1c8faa688b1f0b0c;
using x28925c9b27b37a46;
using x4f4df92b75ba3b67;
using x6c95d9cf46ff5f25;
using xf989f31a236ff98c;

namespace x6a671772ec29137f;

internal class xcd769e39c0788209 : x6c74398bceb133f8
{
	private x92faf2a956f0f5a7 x574b2eddfff7d520;

	protected override void DoStartDocument(x8556eed81191af11 saveInfo, xfaf91ffd88d78c15 docInfo)
	{
		PdfSaveOptions pdfSaveOptions = (PdfSaveOptions)saveInfo.xf57de0fd37d5e97d;
		Document x2c8c6741422a = saveInfo.x2c8c6741422a1298;
		switch (pdfSaveOptions.Compliance)
		{
		case PdfCompliance.Pdf15:
			x2c8c6741422a.xdeb77ea37ad74c56.x74ae341968ceeebf = pdfSaveOptions.PreserveFormFields;
			break;
		case PdfCompliance.PdfA1b:
			x2c8c6741422a.xdeb77ea37ad74c56.x74ae341968ceeebf = false;
			break;
		default:
			throw new InvalidOperationException("Unexpected compliance option.");
		}
		x574b2eddfff7d520 = new x92faf2a956f0f5a7(saveInfo.xb8a774e0111d0fbe, pdfSaveOptions.x5eff1f3a09faac7e());
		x574b2eddfff7d520.x0d8cdce10fda1cfd.xb444c09fa044bbca = docInfo;
	}

	protected override bool AddCustomProperties(SaveOptions options)
	{
		return ((PdfSaveOptions)options).ExportCustomPropertiesAsMetadata;
	}

	protected override void DoRenderPage(xc67adcdbca121a26 page)
	{
		x574b2eddfff7d520.xe406325e56f74b46(page);
	}

	protected override SaveOutputParameters DoEndDocument()
	{
		x574b2eddfff7d520.xa0dfc102c691b11f();
		return new SaveOutputParameters("application/pdf");
	}
}
