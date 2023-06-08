using System.Collections;
using Aspose.Words.Properties;
using x55b2bd426d41d30c;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace xfce5b6a304778b89;

internal class x255ae964ece09fa0
{
	private static readonly char[] x8595062a6f359a6c = new char[3] { 'H', 'M', 'S' };

	private x255ae964ece09fa0()
	{
	}

	internal static void x06b0e25aa6ad68a9(xf871da68decec406 xe134235b3526fa75)
	{
		x0ca5e8b532953a51 x0ca5e8b532953a = xe134235b3526fa75.x39c7aeeec1af9dd0.x5621ebad67e4df79("/meta.xml");
		if (x0ca5e8b532953a == null)
		{
			return;
		}
		x536e1b48249b1390 x536e1b48249b1392 = (xe134235b3526fa75.xca994afbcb9073a2 = new x536e1b48249b1390(x0ca5e8b532953a.xb8a774e0111d0fbe));
		while (x536e1b48249b1392.x152cbadbfa8061b1("document-meta"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x536e1b48249b1392.xa66385d80d4d296f) != null && xa66385d80d4d296f == "meta")
			{
				x87dd1c1966690818(xe134235b3526fa75);
			}
			else
			{
				x536e1b48249b1392.IgnoreElement();
			}
		}
	}

	private static void x87dd1c1966690818(xf871da68decec406 xe134235b3526fa75)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		BuiltInDocumentProperties builtInDocumentProperties = xe134235b3526fa75.x2c8c6741422a1298.BuiltInDocumentProperties;
		bool flag = true;
		while (xe134235b3526fa75.xca994afbcb9073a2.x152cbadbfa8061b1("meta"))
		{
			switch (xe134235b3526fa75.xca994afbcb9073a2.xa66385d80d4d296f)
			{
			case "generator":
				builtInDocumentProperties.NameOfApplication = xca994afbcb9073a.x2a1ea9d24e62bf84();
				break;
			case "template":
				x105e479695b4d270(xe134235b3526fa75);
				break;
			case "description":
				builtInDocumentProperties.Comments = xca994afbcb9073a.x2a1ea9d24e62bf84();
				break;
			case "subject":
				builtInDocumentProperties.Subject = xca994afbcb9073a.x2a1ea9d24e62bf84();
				break;
			case "keyword":
				if (!flag)
				{
					builtInDocumentProperties.Keywords = $"{builtInDocumentProperties.Keywords},";
				}
				builtInDocumentProperties.Keywords = $"{builtInDocumentProperties.Keywords}{xca994afbcb9073a.x2a1ea9d24e62bf84()}";
				flag = false;
				break;
			case "initial-creator":
				builtInDocumentProperties.Author = xca994afbcb9073a.x2a1ea9d24e62bf84();
				break;
			case "creator":
				builtInDocumentProperties.LastSavedBy = xca994afbcb9073a.x2a1ea9d24e62bf84();
				break;
			case "title":
				builtInDocumentProperties.Title = xca994afbcb9073a.x2a1ea9d24e62bf84();
				break;
			case "creation-date":
				builtInDocumentProperties.CreatedTime = xca004f56614e2431.x70982613fd6240f9(xca994afbcb9073a.x2a1ea9d24e62bf84());
				break;
			case "date":
				builtInDocumentProperties.LastSavedTime = xca004f56614e2431.x70982613fd6240f9(xca994afbcb9073a.x2a1ea9d24e62bf84());
				break;
			case "print-date":
				builtInDocumentProperties.LastPrinted = xca004f56614e2431.x70982613fd6240f9(xca994afbcb9073a.x2a1ea9d24e62bf84());
				break;
			case "editing-cycles":
				builtInDocumentProperties.RevisionNumber = xca994afbcb9073a.xab461f3453328cf7();
				break;
			case "editing-duration":
				builtInDocumentProperties.xcc3f5a7a232023b9(x9de125ee237d2bf5(xca994afbcb9073a.x2a1ea9d24e62bf84()));
				break;
			case "document-statistic":
				xd97b98406f7d69dc(xe134235b3526fa75);
				break;
			case "user-defined":
				x463a1bd0771c9c40(xe134235b3526fa75);
				break;
			default:
				xe134235b3526fa75.xca994afbcb9073a2.IgnoreElement();
				break;
			}
		}
	}

	private static int x9de125ee237d2bf5(string x332bf6abcba87808)
	{
		x332bf6abcba87808 = x332bf6abcba87808.ToUpper();
		int num = x332bf6abcba87808.IndexOf("PT");
		if (num == -1)
		{
			return 0;
		}
		x332bf6abcba87808 = x332bf6abcba87808.Substring(num + 2);
		int num2 = x332bf6abcba87808.IndexOf("H");
		int num3 = x332bf6abcba87808.IndexOf("M");
		int num4 = x332bf6abcba87808.IndexOf("S");
		string[] array = x332bf6abcba87808.Split(x8595062a6f359a6c);
		ArrayList arrayList = new ArrayList();
		string[] array2 = array;
		foreach (string text in array2)
		{
			if (x0d299f323d241756.x5959bccb67bbf051(text))
			{
				arrayList.Add(text);
			}
		}
		if (arrayList.Count == 0)
		{
			return 0;
		}
		if (arrayList.Count == 1)
		{
			if (num4 != -1)
			{
				return (int)(xca004f56614e2431.xec25d08a2af152f0(array[0]) / 60.0);
			}
			if (num3 != -1)
			{
				return (int)xca004f56614e2431.xec25d08a2af152f0(array[0]);
			}
			if (num2 != -1)
			{
				return (int)(xca004f56614e2431.xec25d08a2af152f0(array[0]) * 60.0);
			}
		}
		if (arrayList.Count == 2)
		{
			if (num4 != -1 && num3 != -1)
			{
				return (int)(xca004f56614e2431.xec25d08a2af152f0(array[0]) + xca004f56614e2431.xec25d08a2af152f0(array[1]) / 60.0);
			}
			if (num4 != -1 && num2 != -1)
			{
				return (int)(xca004f56614e2431.xec25d08a2af152f0(array[0]) * 60.0 + xca004f56614e2431.xec25d08a2af152f0(array[1]) / 60.0);
			}
			if (num3 != -1 && num2 != -1)
			{
				return (int)(xca004f56614e2431.xec25d08a2af152f0(array[0]) * 60.0 + xca004f56614e2431.xec25d08a2af152f0(array[1]));
			}
		}
		if (arrayList.Count == 3)
		{
			return (int)(xca004f56614e2431.xec25d08a2af152f0(array[0]) * 60.0 + xca004f56614e2431.xec25d08a2af152f0(array[1]) + xca004f56614e2431.xec25d08a2af152f0(array[2]) / 60.0);
		}
		return 0;
	}

	private static void x463a1bd0771c9c40(xf871da68decec406 xe134235b3526fa75)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		xca994afbcb9073a.x99f8cdb2827fa686();
		string text = "";
		string text2 = "";
		while (xca994afbcb9073a.x1ac1960adc8c4c39())
		{
			switch (xca994afbcb9073a.xa66385d80d4d296f)
			{
			case "name":
				text = xca994afbcb9073a.xd2f68ee6f47e9dfb;
				if (xe134235b3526fa75.x2c8c6741422a1298.CustomDocumentProperties.Contains(text))
				{
					return;
				}
				break;
			case "value-type":
				text2 = xca994afbcb9073a.xd2f68ee6f47e9dfb;
				break;
			}
		}
		string text3 = xca994afbcb9073a.x2a1ea9d24e62bf84();
		switch (text2)
		{
		case "boolean":
			xe134235b3526fa75.x2c8c6741422a1298.CustomDocumentProperties.x1cd8943d02c5342f(text, xca004f56614e2431.xa0946eaa4f07cba1(text3));
			break;
		case "date":
		case "time":
			xe134235b3526fa75.x2c8c6741422a1298.CustomDocumentProperties.x1cd8943d02c5342f(text, xca004f56614e2431.x70982613fd6240f9(text3));
			break;
		case "float":
			xe134235b3526fa75.x2c8c6741422a1298.CustomDocumentProperties.x1cd8943d02c5342f(text, xca004f56614e2431.xec25d08a2af152f0(text3));
			break;
		default:
			xe134235b3526fa75.x2c8c6741422a1298.CustomDocumentProperties.x1cd8943d02c5342f(text, text3);
			break;
		}
	}

	private static void x105e479695b4d270(xf871da68decec406 xe134235b3526fa75)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		BuiltInDocumentProperties builtInDocumentProperties = xe134235b3526fa75.x2c8c6741422a1298.BuiltInDocumentProperties;
		while (xca994afbcb9073a.x1ac1960adc8c4c39())
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = xca994afbcb9073a.xa66385d80d4d296f) != null && xa66385d80d4d296f == "href")
			{
				builtInDocumentProperties.Template = xca994afbcb9073a.xd2f68ee6f47e9dfb;
			}
		}
	}

	private static void xd97b98406f7d69dc(xf871da68decec406 xe134235b3526fa75)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		BuiltInDocumentProperties builtInDocumentProperties = xe134235b3526fa75.x2c8c6741422a1298.BuiltInDocumentProperties;
		while (xca994afbcb9073a.x1ac1960adc8c4c39())
		{
			switch (xca994afbcb9073a.xa66385d80d4d296f)
			{
			case "page-count":
				builtInDocumentProperties.Pages = xca994afbcb9073a.xbba6773b8ce56a01;
				break;
			case "paragraph-count":
				builtInDocumentProperties.Paragraphs = xca994afbcb9073a.xbba6773b8ce56a01;
				break;
			case "row-count":
				builtInDocumentProperties.Lines = xca994afbcb9073a.xbba6773b8ce56a01;
				break;
			case "word-count":
				builtInDocumentProperties.Words = xca994afbcb9073a.xbba6773b8ce56a01;
				break;
			case "character-count":
				builtInDocumentProperties.CharactersWithSpaces = xca994afbcb9073a.xbba6773b8ce56a01;
				break;
			case "non-whitespace-character-count":
				builtInDocumentProperties.Characters = xca994afbcb9073a.xbba6773b8ce56a01;
				break;
			}
		}
	}
}
