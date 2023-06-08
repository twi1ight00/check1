using System.Collections;
using Aspose.Words;
using x1a3e96f4b89a7a77;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using xb92b7270f78a4e8d;
using xfc5388ad7dff404f;

namespace xa8550ea6ae4a81a5;

internal class xce0f75acb04bbc55
{
	internal static void x6210059f049f0d48(x07e190e23dab42a9 xbdfb620b7167944b)
	{
		if (xbdfb620b7167944b.x2c8c6741422a1298.HasMacros)
		{
			xa2f1c3dcbd86f20a x0501749e7b78eacc = x471bb50dbdb9f40d(xbdfb620b7167944b);
			x43f5c54204105ab6(xbdfb620b7167944b, x0501749e7b78eacc);
			x98d80e429e05be42(xbdfb620b7167944b, x0501749e7b78eacc);
		}
	}

	private static xa2f1c3dcbd86f20a x471bb50dbdb9f40d(x07e190e23dab42a9 xbdfb620b7167944b)
	{
		xa2f1c3dcbd86f20a xa2f1c3dcbd86f20a = xbdfb620b7167944b.x39c7aeeec1af9dd0.x42c5f80e2ed823ff(xbdfb620b7167944b.x2a0bb2f6650f6a43, "vbaProject.bin", "application/vnd.ms-office.vbaProject", "http://schemas.microsoft.com/office/2006/relationships/vbaProject");
		xd8c3135513b9115b xd8c3135513b9115b = new xd8c3135513b9115b(xbdfb620b7167944b.x2c8c6741422a1298.x92e2e3377da135e8);
		xd8c3135513b9115b.x0acd3c2012ea2ee8(xa2f1c3dcbd86f20a.xb8a774e0111d0fbe);
		return xa2f1c3dcbd86f20a;
	}

	private static void x43f5c54204105ab6(x07e190e23dab42a9 xbdfb620b7167944b, xa2f1c3dcbd86f20a x0501749e7b78eacc)
	{
		Document x2c8c6741422a = xbdfb620b7167944b.x2c8c6741422a1298;
		if (x2c8c6741422a.xd7b817e9f42390ee != null)
		{
			xa2f1c3dcbd86f20a xa2f1c3dcbd86f20a = xbdfb620b7167944b.x39c7aeeec1af9dd0.x42c5f80e2ed823ff(x0501749e7b78eacc, "vbaProjectSignature.bin", "application/vnd.ms-office.vbaProjectSignature", "http://schemas.microsoft.com/office/2006/relationships/vbaProjectSignature");
			xa2f1c3dcbd86f20a.xb8a774e0111d0fbe.Write(x2c8c6741422a.xd7b817e9f42390ee, 8, x2c8c6741422a.xd7b817e9f42390ee.Length - 8);
		}
	}

	private static void x98d80e429e05be42(x07e190e23dab42a9 xbdfb620b7167944b, xa2f1c3dcbd86f20a x0501749e7b78eacc)
	{
		Document x2c8c6741422a = xbdfb620b7167944b.x2c8c6741422a1298;
		if (x63ddee350f3963ee(x2c8c6741422a) || x3ee52977c11dff05(x2c8c6741422a))
		{
			string xc06e652f250a;
			x8f3af96aa56f1e32 x8f3af96aa56f1e33 = xbdfb620b7167944b.xa24813b526772a3b(x0501749e7b78eacc, "vbaData.xml", "application/vnd.ms-word.vbaData+xml", "http://schemas.microsoft.com/office/2006/relationships/wordVbaData", out xc06e652f250a);
			x8f3af96aa56f1e33.x454da6e050647673("wne:vbaSuppData");
			x865547c1b9ee0ec8(xbdfb620b7167944b.x2c8c6741422a1298, x8f3af96aa56f1e33);
			x8e4e3dfe9b560833(xbdfb620b7167944b.x2c8c6741422a1298, x8f3af96aa56f1e33);
			x8f3af96aa56f1e33.xa0dfc102c691b11f();
		}
	}

	private static bool x3ee52977c11dff05(Document x6beba47238e0ade6)
	{
		if (x6beba47238e0ade6.x3829bffd91c3b45d != null)
		{
			return x6beba47238e0ade6.x3829bffd91c3b45d.Count > 0;
		}
		return false;
	}

	private static bool x63ddee350f3963ee(Document x6beba47238e0ade6)
	{
		return x6beba47238e0ade6.xa0a845678e16cf58 != (xa0a845678e16cf58)0;
	}

	private static void x865547c1b9ee0ec8(Document x6beba47238e0ade6, x3c74b3c4f21844f9 xd07ce4b74c5774a7)
	{
		if (x63ddee350f3963ee(x6beba47238e0ade6))
		{
			xd07ce4b74c5774a7.x2307058321cdb62f("wne:docEvents");
			xa0a845678e16cf58 xa0a845678e16cf = x6beba47238e0ade6.xa0a845678e16cf58;
			x369a7861a441f574(xa0a845678e16cf, xa0a845678e16cf58.xd8e728222b18ff13, "wne:eventDocNew", xd07ce4b74c5774a7);
			x369a7861a441f574(xa0a845678e16cf, xa0a845678e16cf58.xe410125f7519de90, "wne:eventDocOpen", xd07ce4b74c5774a7);
			x369a7861a441f574(xa0a845678e16cf, xa0a845678e16cf58.x8ffe90e7fbccfccd, "wne:eventDocClose", xd07ce4b74c5774a7);
			x369a7861a441f574(xa0a845678e16cf, xa0a845678e16cf58.x6c1268b8fdc7ecbd, "wne:eventDocSync", xd07ce4b74c5774a7);
			x369a7861a441f574(xa0a845678e16cf, xa0a845678e16cf58.x156620e2664eda89, "wne:eventDocXmlAfterInsert", xd07ce4b74c5774a7);
			x369a7861a441f574(xa0a845678e16cf, xa0a845678e16cf58.x5c0bde052a1d09d5, "wne:eventDocXmlBeforeDelete", xd07ce4b74c5774a7);
			x369a7861a441f574(xa0a845678e16cf, xa0a845678e16cf58.x22826ed13ee2c26e, "wne:eventDocContentControlAfterInsert", xd07ce4b74c5774a7);
			x369a7861a441f574(xa0a845678e16cf, xa0a845678e16cf58.xaeff9345c9acdc37, "wne:eventDocContentControlBeforeDelete", xd07ce4b74c5774a7);
			x369a7861a441f574(xa0a845678e16cf, xa0a845678e16cf58.xb1198dc1f9d70f80, "wne:eventDocContentControlOnExit", xd07ce4b74c5774a7);
			x369a7861a441f574(xa0a845678e16cf, xa0a845678e16cf58.xac4a0b5b118607e9, "wne:eventDocContentControlOnEnter", xd07ce4b74c5774a7);
			x369a7861a441f574(xa0a845678e16cf, xa0a845678e16cf58.x0761b27b6b672349, "wne:eventDocStoreUpdate", xd07ce4b74c5774a7);
			x369a7861a441f574(xa0a845678e16cf, xa0a845678e16cf58.x0415d2e7a614fa3c, "wne:eventDocContentControlContentUpdate", xd07ce4b74c5774a7);
			x369a7861a441f574(xa0a845678e16cf, xa0a845678e16cf58.x81fdc5669058a208, "wne:eventDocBuildingBlockAfterInsert", xd07ce4b74c5774a7);
			xd07ce4b74c5774a7.x2dfde153f4ef96d0();
		}
	}

	private static void x369a7861a441f574(xa0a845678e16cf58 xaf3c682990d31166, xa0a845678e16cf58 x0967ec0d7f130f61, string x4c12babe29167a55, x3c74b3c4f21844f9 xd07ce4b74c5774a7)
	{
		if ((xaf3c682990d31166 & x0967ec0d7f130f61) != 0)
		{
			xd07ce4b74c5774a7.xf68f9c3818e1f4b1(x4c12babe29167a55);
		}
	}

	private static void x8e4e3dfe9b560833(Document x6beba47238e0ade6, x873451caae5ad4ae xd07ce4b74c5774a7)
	{
		if (!x3ee52977c11dff05(x6beba47238e0ade6))
		{
			return;
		}
		ArrayList x3829bffd91c3b45d = x6beba47238e0ade6.x3829bffd91c3b45d;
		xd07ce4b74c5774a7.x2307058321cdb62f("wne:mcds");
		foreach (string item in x3829bffd91c3b45d)
		{
			xd07ce4b74c5774a7.x2307058321cdb62f("wne:mcd");
			xd07ce4b74c5774a7.x943f6be3acf634db("wne:macroName", item.ToUpper());
			xd07ce4b74c5774a7.x943f6be3acf634db("wne:name", item);
			xd07ce4b74c5774a7.x943f6be3acf634db("wne:bEncrypt", "00");
			xd07ce4b74c5774a7.x943f6be3acf634db("wne:cmg", "56");
			xd07ce4b74c5774a7.x2dfde153f4ef96d0();
		}
		xd07ce4b74c5774a7.x2dfde153f4ef96d0();
	}
}
