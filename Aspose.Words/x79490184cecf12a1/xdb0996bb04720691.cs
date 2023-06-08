using System.Collections;
using Aspose.Words;
using x1495530f35d79681;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using xb92b7270f78a4e8d;
using xfc5388ad7dff404f;

namespace x79490184cecf12a1;

internal class xdb0996bb04720691
{
	internal static void x06b0e25aa6ad68a9(xa52ef41af20225f0 xe134235b3526fa75)
	{
		xa2f1c3dcbd86f20a xa2f1c3dcbd86f20a = x1a047997cef57d5f(xe134235b3526fa75);
		if (xa2f1c3dcbd86f20a != null)
		{
			xb4aa4f0a98d8dc79(xe134235b3526fa75, xa2f1c3dcbd86f20a);
			x70b0753a0ae26e74(xe134235b3526fa75, xa2f1c3dcbd86f20a);
		}
	}

	private static xa2f1c3dcbd86f20a x1a047997cef57d5f(xa52ef41af20225f0 xe134235b3526fa75)
	{
		xa2f1c3dcbd86f20a xa2f1c3dcbd86f20a = xe134235b3526fa75.x4bfdbcbc6a51d705(xe134235b3526fa75.x2a0bb2f6650f6a43, "http://schemas.microsoft.com/office/2006/relationships/vbaProject");
		if (xa2f1c3dcbd86f20a == null)
		{
			return null;
		}
		xd8c3135513b9115b xd8c3135513b9115b = new xd8c3135513b9115b(xa2f1c3dcbd86f20a.xb8a774e0111d0fbe);
		xe134235b3526fa75.x2c8c6741422a1298.x92e2e3377da135e8 = xd8c3135513b9115b.x29e7ace4c90f74cd;
		return xa2f1c3dcbd86f20a;
	}

	private static void xb4aa4f0a98d8dc79(xa52ef41af20225f0 xe134235b3526fa75, xa2f1c3dcbd86f20a x0501749e7b78eacc)
	{
		xa2f1c3dcbd86f20a xa2f1c3dcbd86f20a = xe134235b3526fa75.x4bfdbcbc6a51d705(x0501749e7b78eacc, "http://schemas.microsoft.com/office/2006/relationships/vbaProjectSignature");
		if (xa2f1c3dcbd86f20a != null)
		{
			int num = (int)xa2f1c3dcbd86f20a.xb8a774e0111d0fbe.Length;
			byte[] array = new byte[8 + num];
			x0d299f323d241756.x3ae29f473f29ef2a(num, array, 0);
			x0d299f323d241756.x3ae29f473f29ef2a(8, array, 4);
			xa2f1c3dcbd86f20a.xb8a774e0111d0fbe.Read(array, 8, num);
			xe134235b3526fa75.x2c8c6741422a1298.xd7b817e9f42390ee = array;
		}
	}

	private static void x70b0753a0ae26e74(xa52ef41af20225f0 xe134235b3526fa75, xa2f1c3dcbd86f20a x0501749e7b78eacc)
	{
		xa2f1c3dcbd86f20a xa2f1c3dcbd86f20a = xe134235b3526fa75.x4bfdbcbc6a51d705(x0501749e7b78eacc, "http://schemas.microsoft.com/office/2006/relationships/wordVbaData");
		if (xa2f1c3dcbd86f20a == null)
		{
			return;
		}
		x3c85359e1389ad43 x3c85359e1389ad = new x3c85359e1389ad43(xa2f1c3dcbd86f20a.xb8a774e0111d0fbe);
		while (x3c85359e1389ad.x152cbadbfa8061b1("vbaSuppData"))
		{
			switch (x3c85359e1389ad.xa66385d80d4d296f)
			{
			case "docEvents":
				xc4b26407cb7f1aa6(x3c85359e1389ad, xe134235b3526fa75.x2c8c6741422a1298);
				break;
			case "mcds":
				x26de2e70e5175b1b(x3c85359e1389ad, xe134235b3526fa75.x2c8c6741422a1298);
				break;
			default:
				x3c85359e1389ad.IgnoreElement();
				break;
			}
		}
	}

	private static void xc4b26407cb7f1aa6(xc1dcd6189d01216e x97bf2eeabd4abc7b, Document x6beba47238e0ade6)
	{
		xa0a845678e16cf58 xa0a845678e16cf = (xa0a845678e16cf58)0;
		while (x97bf2eeabd4abc7b.x152cbadbfa8061b1("docEvents"))
		{
			switch (x97bf2eeabd4abc7b.xa66385d80d4d296f)
			{
			case "eventDocNew":
				xa0a845678e16cf |= xa0a845678e16cf58.xd8e728222b18ff13;
				break;
			case "eventDocOpen":
				xa0a845678e16cf |= xa0a845678e16cf58.xe410125f7519de90;
				break;
			case "eventDocClose":
				xa0a845678e16cf |= xa0a845678e16cf58.x8ffe90e7fbccfccd;
				break;
			case "eventDocSync":
				xa0a845678e16cf |= xa0a845678e16cf58.x6c1268b8fdc7ecbd;
				break;
			case "eventDocXmlAfterInsert":
				xa0a845678e16cf |= xa0a845678e16cf58.x156620e2664eda89;
				break;
			case "eventDocXmlBeforeDelete":
				xa0a845678e16cf |= xa0a845678e16cf58.x5c0bde052a1d09d5;
				break;
			case "eventDocContentControlAfterInsert":
				xa0a845678e16cf |= xa0a845678e16cf58.x22826ed13ee2c26e;
				break;
			case "eventDocContentControlBeforeDelete":
				xa0a845678e16cf |= xa0a845678e16cf58.xaeff9345c9acdc37;
				break;
			case "eventDocContentControlOnExit":
				xa0a845678e16cf |= xa0a845678e16cf58.xb1198dc1f9d70f80;
				break;
			case "eventDocContentControlOnEnter":
				xa0a845678e16cf |= xa0a845678e16cf58.xac4a0b5b118607e9;
				break;
			case "eventDocStoreUpdate":
				xa0a845678e16cf |= xa0a845678e16cf58.x0761b27b6b672349;
				break;
			case "eventDocContentControlContentUpdate":
				xa0a845678e16cf |= xa0a845678e16cf58.x0415d2e7a614fa3c;
				break;
			case "eventDocBuildingBlockAfterInsert":
				xa0a845678e16cf |= xa0a845678e16cf58.x81fdc5669058a208;
				break;
			default:
				x97bf2eeabd4abc7b.IgnoreElement();
				break;
			}
		}
		x6beba47238e0ade6.xa0a845678e16cf58 = xa0a845678e16cf;
	}

	private static void x26de2e70e5175b1b(xc1dcd6189d01216e x97bf2eeabd4abc7b, Document x6beba47238e0ade6)
	{
		x6beba47238e0ade6.x3829bffd91c3b45d = new ArrayList();
		while (x97bf2eeabd4abc7b.x152cbadbfa8061b1("mcds"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x97bf2eeabd4abc7b.xa66385d80d4d296f) != null && xa66385d80d4d296f == "mcd")
			{
				x1ac2e2641e590d1c(x97bf2eeabd4abc7b, x6beba47238e0ade6);
			}
			else
			{
				x97bf2eeabd4abc7b.IgnoreElement();
			}
		}
	}

	private static void x1ac2e2641e590d1c(xc1dcd6189d01216e x97bf2eeabd4abc7b, Document x6beba47238e0ade6)
	{
		while (x97bf2eeabd4abc7b.x1ac1960adc8c4c39())
		{
			switch (x97bf2eeabd4abc7b.xa66385d80d4d296f)
			{
			case "name":
				x6beba47238e0ade6.x3829bffd91c3b45d.Add(x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb);
				break;
			}
		}
	}
}
