using System.Collections;
using Aspose.Words;
using Aspose.Words.Markup;
using x6c95d9cf46ff5f25;
using xf989f31a236ff98c;
using xfc5388ad7dff404f;

namespace x79490184cecf12a1;

internal class x980bf27aa9764302
{
	private x980bf27aa9764302()
	{
	}

	internal static void x06b0e25aa6ad68a9(xa52ef41af20225f0 xe134235b3526fa75, IWarningCallback x57fef5933b41d0c2)
	{
		xa2f1c3dcbd86f20a x2a0bb2f6650f6a = xe134235b3526fa75.x2a0bb2f6650f6a43;
		foreach (x5b6f1954712b741f item in (IEnumerable)x2a0bb2f6650f6a.xadb7000bed559a9a)
		{
			if (item.x3146d638ec378671 == "http://schemas.openxmlformats.org/officeDocument/2006/relationships/customXml")
			{
				x4483a473014a2a6f(xe134235b3526fa75, x2a0bb2f6650f6a.xa687196d807ab9c0(item), x57fef5933b41d0c2);
			}
		}
	}

	private static void x4483a473014a2a6f(xa52ef41af20225f0 xe134235b3526fa75, string x915ed0d3e80a25a1, IWarningCallback x57fef5933b41d0c2)
	{
		xa2f1c3dcbd86f20a xa2f1c3dcbd86f20a = xe134235b3526fa75.xd4e2719ccf56f4d7(x915ed0d3e80a25a1);
		CustomXmlPart customXmlPart = new CustomXmlPart();
		customXmlPart.Data = x0d299f323d241756.xa0aed4cd3b3d5d92(xa2f1c3dcbd86f20a.xb8a774e0111d0fbe);
		xa2f1c3dcbd86f20a xa2f1c3dcbd86f20a2 = xe134235b3526fa75.x4bfdbcbc6a51d705(xa2f1c3dcbd86f20a, "http://schemas.openxmlformats.org/officeDocument/2006/relationships/customXmlProps");
		if (xa2f1c3dcbd86f20a2 == null)
		{
			x57fef5933b41d0c2?.Warning(new WarningInfo(WarningType.DataLoss, WarningSource.Docx, $"Custom XML part properties are missed for {x915ed0d3e80a25a1}."));
		}
		else
		{
			xb2de080ec26d1a63.x06b0e25aa6ad68a9(xa2f1c3dcbd86f20a2.xb8a774e0111d0fbe, customXmlPart);
		}
		xe134235b3526fa75.x2c8c6741422a1298.CustomXmlParts.Add(customXmlPart);
	}
}
