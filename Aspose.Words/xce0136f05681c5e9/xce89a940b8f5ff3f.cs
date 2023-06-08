using System;
using Aspose.Words;
using Aspose.Words.Fields;
using Aspose.Words.Saving;
using x13f1efc79617a47b;
using x28925c9b27b37a46;
using x381fb081d11d6275;
using xf989f31a236ff98c;
using xf9a9481c3f63a419;

namespace xce0136f05681c5e9;

internal class xce89a940b8f5ff3f : x6868017fd9012087
{
	private readonly HtmlSaveOptions x1cb867f3d40f3203;

	private readonly xe2ff3c3cd396cfd9 x09b9574bb5661d62;

	private readonly x4eefe5e664198999 x12954a224495d3c0;

	private x515d2f71e3e1988e xe1410f585439c7d4 => x09b9574bb5661d62.xe1410f585439c7d4;

	internal xce89a940b8f5ff3f(Document document, HtmlSaveOptions saveOptions, x08802e9e984cd3ee runWriter, x05df33911093beb0 hyperlinkWriter, xe2ff3c3cd396cfd9 htmlWriterCommon, x4eefe5e664198999 spanWriter)
		: base(document, saveOptions.ExportTocPageNumbers, saveOptions.ExportTextInputFormFieldAsText, runWriter, hyperlinkWriter)
	{
		x1cb867f3d40f3203 = saveOptions;
		x09b9574bb5661d62 = htmlWriterCommon;
		x12954a224495d3c0 = spanWriter;
	}

	internal override VisitorAction x85599597a4d57020(FormField x0ab8fc6e4b8e829c)
	{
		switch (x0ab8fc6e4b8e829c.Type)
		{
		case FieldType.FieldFormTextInput:
			if (!x1cb867f3d40f3203.ExportTextInputFormFieldAsText)
			{
				xe1410f585439c7d4.x2307058321cdb62f("input");
				xe1410f585439c7d4.xff520a0047c27122("type", "text");
				xe1410f585439c7d4.xff520a0047c27122("name", x0ab8fc6e4b8e829c.Name);
				if (x0ab8fc6e4b8e829c.MaxLength != 0)
				{
					xe1410f585439c7d4.x55b893148f746a6f("maxlength", x0ab8fc6e4b8e829c.MaxLength);
				}
				xe1410f585439c7d4.xff520a0047c27122("value", x0ab8fc6e4b8e829c.Result);
				xe1410f585439c7d4.x2dfde153f4ef96d0();
			}
			break;
		case FieldType.FieldFormDropDown:
		{
			if (x1cb867f3d40f3203.x4e3c1d16eaf20ef3)
			{
				string x6e77c7675d1ac = x0ab8fc6e4b8e829c.x6e77c7675d1ac719;
				if (x6e77c7675d1ac.Length != 0)
				{
					x12954a224495d3c0.x7e87e53a0ba2f770(x0ab8fc6e4b8e829c.Font, x6e77c7675d1ac, x000f21cbda739311.x175297738c8b8d1e, x07532f30a274f493: false, xf544375d86767c28: true);
				}
				break;
			}
			xe1410f585439c7d4.x2307058321cdb62f("select");
			xe1410f585439c7d4.xff520a0047c27122("name", x0ab8fc6e4b8e829c.Name);
			for (int i = 0; i < x0ab8fc6e4b8e829c.DropDownItems.Count; i++)
			{
				xe1410f585439c7d4.x2307058321cdb62f("option");
				if (i == x0ab8fc6e4b8e829c.DropDownSelectedIndex)
				{
					xe1410f585439c7d4.xff520a0047c27122("selected", "selected");
				}
				xe1410f585439c7d4.x3d1be38abe5723e3(x0ab8fc6e4b8e829c.DropDownItems[i]);
				xe1410f585439c7d4.x538f0e0fb2bf15ab();
			}
			xe1410f585439c7d4.x538f0e0fb2bf15ab();
			break;
		}
		case FieldType.FieldFormCheckBox:
			if (x1cb867f3d40f3203.x4e3c1d16eaf20ef3)
			{
				string arg = (x0ab8fc6e4b8e829c.Checked ? "&#xfd;" : "&#x6f;");
				xe1410f585439c7d4.xd52401bdf5aacef6($"<span style=\"font:{xca004f56614e2431.xdbca7a004e2d3753(x0ab8fc6e4b8e829c.Font.Size)}pt Wingdings\">{arg}</span>");
				break;
			}
			xe1410f585439c7d4.x2307058321cdb62f("input");
			xe1410f585439c7d4.xff520a0047c27122("type", "checkbox");
			xe1410f585439c7d4.xff520a0047c27122("name", x0ab8fc6e4b8e829c.Name);
			if (x0ab8fc6e4b8e829c.Checked)
			{
				xe1410f585439c7d4.xff520a0047c27122("checked", "checked");
			}
			xe1410f585439c7d4.x2dfde153f4ef96d0();
			break;
		default:
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("kkcfamjfklagklhgilognlfhblmhagdidkkijkbjjkijbkpjbfgkejnkejelnillbjcmgijmpdanajhncjongifoihmooddp", 1517376085)));
		}
		return VisitorAction.Continue;
	}
}
