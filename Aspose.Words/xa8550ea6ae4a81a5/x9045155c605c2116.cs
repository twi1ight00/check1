using System.IO;
using Aspose.Words.Markup;
using xf989f31a236ff98c;
using xfc5388ad7dff404f;

namespace xa8550ea6ae4a81a5;

internal class x9045155c605c2116
{
	private x9045155c605c2116()
	{
	}

	internal static void x6210059f049f0d48(x07e190e23dab42a9 xbdfb620b7167944b)
	{
		int num = 1;
		int num2 = 1;
		foreach (CustomXmlPart customXmlPart in xbdfb620b7167944b.x2c8c6741422a1298.CustomXmlParts)
		{
			xa2f1c3dcbd86f20a xa2f1c3dcbd86f20a = xbdfb620b7167944b.x39c7aeeec1af9dd0.x42c5f80e2ed823ff(xbdfb620b7167944b.x2a0bb2f6650f6a43, $"/customXml/item{num++}.xml", "application/xml", "http://schemas.openxmlformats.org/officeDocument/2006/relationships/customXml");
			xa2f1c3dcbd86f20a.xb8a774e0111d0fbe = new MemoryStream(customXmlPart.Data);
			string xc06e652f250a;
			x8f3af96aa56f1e32 xd07ce4b74c5774a = xbdfb620b7167944b.xa24813b526772a3b(xa2f1c3dcbd86f20a, $"/customXml/itemProps{num2++}.xml", "application/vnd.openxmlformats-officedocument.customXmlProperties+xml", "http://schemas.openxmlformats.org/officeDocument/2006/relationships/customXmlProps", out xc06e652f250a);
			xb2de080ec26d1a63.x6210059f049f0d48(customXmlPart, xd07ce4b74c5774a);
		}
	}
}
