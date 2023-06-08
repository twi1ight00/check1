using System;
using System.Text;
using Aspose.Words;
using Aspose.Words.Properties;
using x13f1efc79617a47b;
using x1a3e96f4b89a7a77;
using x6c95d9cf46ff5f25;
using x79578da6a8a3ae37;
using xda075892eccab2ad;
using xf9a9481c3f63a419;

namespace xf989f31a236ff98c;

internal class x311bb10d5871a09f
{
	private x311bb10d5871a09f()
	{
	}

	internal static void xfb2c8e68dcdb7b29(Document x6beba47238e0ade6, x873451caae5ad4ae xd07ce4b74c5774a7, bool x5060af8676e106e7)
	{
		xcbcac482872e5c97(x6beba47238e0ade6.BuiltInDocumentProperties, xd07ce4b74c5774a7, x5060af8676e106e7);
		x14ddfea90d7259e3(x6beba47238e0ade6.CustomDocumentProperties, xd07ce4b74c5774a7, x5060af8676e106e7);
	}

	private static void xcbcac482872e5c97(BuiltInDocumentProperties xa5ea04da0b735c3b, x873451caae5ad4ae xd07ce4b74c5774a7, bool x5060af8676e106e7)
	{
		xd07ce4b74c5774a7.x2307058321cdb62f("o:DocumentProperties");
		x93f71021f6f2fb9e(xd07ce4b74c5774a7, "o:Title", xa5ea04da0b735c3b.Title, x5060af8676e106e7);
		x93f71021f6f2fb9e(xd07ce4b74c5774a7, "o:Subject", xa5ea04da0b735c3b.Subject, x5060af8676e106e7);
		x93f71021f6f2fb9e(xd07ce4b74c5774a7, "o:Author", xa5ea04da0b735c3b.Author, x5060af8676e106e7);
		x93f71021f6f2fb9e(xd07ce4b74c5774a7, "o:Keywords", xa5ea04da0b735c3b.Keywords, x5060af8676e106e7);
		x93f71021f6f2fb9e(xd07ce4b74c5774a7, "o:Description", xa5ea04da0b735c3b.Comments, x5060af8676e106e7);
		x93f71021f6f2fb9e(xd07ce4b74c5774a7, "o:LastAuthor", xa5ea04da0b735c3b.LastSavedBy, x5060af8676e106e7);
		xd07ce4b74c5774a7.x6b73ce92fd8e3f2c("o:Revision", xa5ea04da0b735c3b.RevisionNumber);
		xd07ce4b74c5774a7.x6b73ce92fd8e3f2c("o:TotalTime", xa5ea04da0b735c3b.TotalEditingTime);
		xd07ce4b74c5774a7.x6d7247ebbf9a7643("o:LastPrinted", xa5ea04da0b735c3b.LastPrinted);
		xd07ce4b74c5774a7.x6d7247ebbf9a7643("o:Created", xa5ea04da0b735c3b.CreatedTime);
		xd07ce4b74c5774a7.x6d7247ebbf9a7643("o:LastSaved", xa5ea04da0b735c3b.LastSavedTime);
		xd07ce4b74c5774a7.x6b73ce92fd8e3f2c("o:Pages", xa5ea04da0b735c3b.Pages);
		xd07ce4b74c5774a7.x6b73ce92fd8e3f2c("o:Words", xa5ea04da0b735c3b.Words);
		xd07ce4b74c5774a7.x6b73ce92fd8e3f2c("o:Characters", xa5ea04da0b735c3b.Characters);
		x93f71021f6f2fb9e(xd07ce4b74c5774a7, "o:Category", xa5ea04da0b735c3b.Category, x5060af8676e106e7);
		x93f71021f6f2fb9e(xd07ce4b74c5774a7, "o:Manager", xa5ea04da0b735c3b.Manager, x5060af8676e106e7);
		x93f71021f6f2fb9e(xd07ce4b74c5774a7, "o:Company", xa5ea04da0b735c3b.Company, x5060af8676e106e7);
		x93f71021f6f2fb9e(xd07ce4b74c5774a7, "o:HyperlinkBase", xa5ea04da0b735c3b.HyperlinkBase, x5060af8676e106e7);
		if (xa5ea04da0b735c3b.Bytes > 0)
		{
			xd07ce4b74c5774a7.x6b73ce92fd8e3f2c("o:Bytes", xa5ea04da0b735c3b.Bytes);
		}
		xd07ce4b74c5774a7.x6b73ce92fd8e3f2c("o:Lines", xa5ea04da0b735c3b.Lines);
		xd07ce4b74c5774a7.x6b73ce92fd8e3f2c("o:Paragraphs", xa5ea04da0b735c3b.Paragraphs);
		xd07ce4b74c5774a7.x6b73ce92fd8e3f2c("o:CharactersWithSpaces", xa5ea04da0b735c3b.CharactersWithSpaces);
		xd07ce4b74c5774a7.x6b73ce92fd8e3f2c("o:Version", xc1b08afa36bf580c.xe60ec335a4cca083(xa5ea04da0b735c3b.Version));
		xd07ce4b74c5774a7.x2dfde153f4ef96d0();
	}

	private static void x93f71021f6f2fb9e(x873451caae5ad4ae xd07ce4b74c5774a7, string x121383aa64985888, string xbcea506a33cf9111, bool x5060af8676e106e7)
	{
		xd07ce4b74c5774a7.x6d7247ebbf9a7643(x121383aa64985888, xfde1ba0213840cde(xbcea506a33cf9111, x5060af8676e106e7));
	}

	private static string xfde1ba0213840cde(string xbcea506a33cf9111, bool x5060af8676e106e7)
	{
		if (!x5060af8676e106e7)
		{
			return xbcea506a33cf9111;
		}
		return xbcea506a33cf9111.Replace("--", "- ");
	}

	private static void x14ddfea90d7259e3(CustomDocumentProperties xa5ea04da0b735c3b, x873451caae5ad4ae xd07ce4b74c5774a7, bool x5060af8676e106e7)
	{
		if (!xe8be26df1e9a02d5(xa5ea04da0b735c3b))
		{
			return;
		}
		xd07ce4b74c5774a7.x2307058321cdb62f("o:CustomDocumentProperties");
		foreach (DocumentProperty item in xa5ea04da0b735c3b)
		{
			if (xbf999c8ebd28bbaf(item))
			{
				x13b929f6fca40255(item, xd07ce4b74c5774a7, x5060af8676e106e7);
			}
		}
		xd07ce4b74c5774a7.x2dfde153f4ef96d0();
	}

	private static void x13b929f6fca40255(DocumentProperty x5ca6b6e12a4d9043, x873451caae5ad4ae xd07ce4b74c5774a7, bool x5060af8676e106e7)
	{
		xd07ce4b74c5774a7.x2307058321cdb62f(x1a6c3cf01c84d82a(x5ca6b6e12a4d9043.Name));
		switch (x5ca6b6e12a4d9043.Type)
		{
		case PropertyType.Boolean:
			xd07ce4b74c5774a7.xff520a0047c27122("dt:dt", "boolean");
			xd07ce4b74c5774a7.x3d1be38abe5723e3(x5ca6b6e12a4d9043.ToBool() ? "1" : "0");
			break;
		case PropertyType.Number:
			xd07ce4b74c5774a7.xff520a0047c27122("dt:dt", "float");
			xd07ce4b74c5774a7.x3d1be38abe5723e3(x5ca6b6e12a4d9043.ToString());
			break;
		case PropertyType.Double:
			xd07ce4b74c5774a7.xff520a0047c27122("dt:dt", "float");
			xd07ce4b74c5774a7.x3d1be38abe5723e3(xca004f56614e2431.xcaaeec2e96b2cecc(x5ca6b6e12a4d9043.ToDouble()));
			break;
		case PropertyType.String:
			xd07ce4b74c5774a7.xff520a0047c27122("dt:dt", "string");
			xd07ce4b74c5774a7.x943f6be3acf634db("link", x5ca6b6e12a4d9043.x1321c7b28b151682);
			xd07ce4b74c5774a7.x3d1be38abe5723e3(xfde1ba0213840cde(x5ca6b6e12a4d9043.ToString(), x5060af8676e106e7));
			break;
		case PropertyType.DateTime:
			xd07ce4b74c5774a7.xff520a0047c27122("dt:dt", "dateTime.tz");
			xd07ce4b74c5774a7.x3d1be38abe5723e3(xca004f56614e2431.x6efbf9d15154c80d(x5ca6b6e12a4d9043.ToDateTime()));
			break;
		default:
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("jkppplgadlnadmebillbkkccfkjcdladbkhdnjodgffedkmeckdfmjkfkjbgmiiggjpgfjghhjnhldeimilioicjcijjehakkdhk", 2091515732)));
		}
		xd07ce4b74c5774a7.x2dfde153f4ef96d0();
	}

	private static string x1a6c3cf01c84d82a(string xc15bd84e01929885)
	{
		StringBuilder stringBuilder = new StringBuilder("o:");
		foreach (char c in xc15bd84e01929885)
		{
			if (char.IsLetterOrDigit(c) || c == '_' || c == '-')
			{
				stringBuilder.Append(c);
				continue;
			}
			stringBuilder.Append("_x");
			stringBuilder.Append(xca004f56614e2431.x7c1a0f9da8274fe8(c));
			stringBuilder.Append('_');
		}
		return stringBuilder.ToString();
	}

	internal static bool xe8be26df1e9a02d5(CustomDocumentProperties xa5ea04da0b735c3b)
	{
		foreach (DocumentProperty item in xa5ea04da0b735c3b)
		{
			if (xbf999c8ebd28bbaf(item))
			{
				return true;
			}
		}
		return false;
	}

	internal static bool xbf999c8ebd28bbaf(DocumentProperty x5ca6b6e12a4d9043)
	{
		if (x5ca6b6e12a4d9043.Name.StartsWith("_PID_"))
		{
			return false;
		}
		return x7e525a006f9be2c7(x5ca6b6e12a4d9043.Type);
	}

	private static bool x7e525a006f9be2c7(PropertyType x43163d22e8cd5a71)
	{
		switch (x43163d22e8cd5a71)
		{
		case PropertyType.Boolean:
		case PropertyType.DateTime:
		case PropertyType.Double:
		case PropertyType.Number:
		case PropertyType.String:
			return true;
		default:
			return false;
		}
	}

	internal static void x5d31016f933a128f(xdade2366eaa6f915 xe31d35d3e8fc8bf2, x873451caae5ad4ae xd07ce4b74c5774a7, string xd80e464e4e73d3e6)
	{
		if (x0d299f323d241756.x5959bccb67bbf051(xe31d35d3e8fc8bf2.x466141be69711980))
		{
			xd07ce4b74c5774a7.xc049ea80ee267201("w:noLineBreaksAfter", "w:lang", xd80e464e4e73d3e6, "w:val", xe31d35d3e8fc8bf2.x466141be69711980);
		}
		if (x0d299f323d241756.x5959bccb67bbf051(xe31d35d3e8fc8bf2.xfc71ac47a3606511))
		{
			xd07ce4b74c5774a7.xc049ea80ee267201("w:noLineBreaksBefore", "w:lang", xd80e464e4e73d3e6, "w:val", xe31d35d3e8fc8bf2.xfc71ac47a3606511);
		}
	}
}
