using System.Text;
using System.Text.RegularExpressions;
using Aspose.Words;
using Aspose.Words.Properties;
using x1495530f35d79681;
using x6c95d9cf46ff5f25;
using xda075892eccab2ad;
using xf9a9481c3f63a419;

namespace x2cc366c8657e2b6a;

internal class x0dbd709f05f41c5c
{
	private const int x0be8f8e6fdaae0fc = 2;

	private const int x149dbb2d5efe4acd = 3;

	private static readonly Regex x5740629b6f4295b0 = new Regex("((_x[a-f0-9]{4}_)|([\\w-_]+?))", RegexOptions.IgnoreCase | RegexOptions.Compiled);

	private x0dbd709f05f41c5c()
	{
	}

	internal static void xd40e142dfd23be4b(x21a61af92fc2a45e xe134235b3526fa75)
	{
		Document document = (Document)xe134235b3526fa75.x2c8c6741422a1298;
		BuiltInDocumentProperties builtInDocumentProperties = document.BuiltInDocumentProperties;
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		while (x3bcd232d01c.x152cbadbfa8061b1("DocumentProperties"))
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "Title":
				builtInDocumentProperties.Title = x3bcd232d01c.x2a1ea9d24e62bf84();
				break;
			case "Subject":
				builtInDocumentProperties.Subject = x3bcd232d01c.x2a1ea9d24e62bf84();
				break;
			case "Author":
				builtInDocumentProperties.Author = x3bcd232d01c.x2a1ea9d24e62bf84();
				break;
			case "Keywords":
				builtInDocumentProperties.Keywords = x3bcd232d01c.x2a1ea9d24e62bf84();
				break;
			case "Description":
				builtInDocumentProperties.Comments = x3bcd232d01c.x2a1ea9d24e62bf84();
				break;
			case "LastAuthor":
				builtInDocumentProperties.LastSavedBy = x3bcd232d01c.x2a1ea9d24e62bf84();
				break;
			case "Revision":
				builtInDocumentProperties.RevisionNumber = x3bcd232d01c.xab461f3453328cf7();
				break;
			case "AppName":
				builtInDocumentProperties.NameOfApplication = x3bcd232d01c.x2a1ea9d24e62bf84();
				break;
			case "TotalTime":
				builtInDocumentProperties.xcc3f5a7a232023b9(x3bcd232d01c.xab461f3453328cf7());
				break;
			case "LastPrinted":
				builtInDocumentProperties.LastPrinted = xca004f56614e2431.x70982613fd6240f9(x3bcd232d01c.x2a1ea9d24e62bf84());
				break;
			case "Created":
				builtInDocumentProperties.CreatedTime = xca004f56614e2431.x70982613fd6240f9(x3bcd232d01c.x2a1ea9d24e62bf84());
				break;
			case "LastSaved":
				builtInDocumentProperties.LastSavedTime = xca004f56614e2431.x70982613fd6240f9(x3bcd232d01c.x2a1ea9d24e62bf84());
				break;
			case "Pages":
				builtInDocumentProperties.Pages = x3bcd232d01c.xab461f3453328cf7();
				break;
			case "Words":
				builtInDocumentProperties.Words = x3bcd232d01c.xab461f3453328cf7();
				break;
			case "Characters":
				builtInDocumentProperties.Characters = x3bcd232d01c.xab461f3453328cf7();
				break;
			case "Category":
				builtInDocumentProperties.Category = x3bcd232d01c.x2a1ea9d24e62bf84();
				break;
			case "Manager":
				builtInDocumentProperties.Manager = x3bcd232d01c.x2a1ea9d24e62bf84();
				break;
			case "Company":
				builtInDocumentProperties.Company = x3bcd232d01c.x2a1ea9d24e62bf84();
				break;
			case "HyperlinkBase":
				builtInDocumentProperties.HyperlinkBase = x3bcd232d01c.x2a1ea9d24e62bf84();
				break;
			case "Bytes":
				builtInDocumentProperties.Bytes = x3bcd232d01c.xab461f3453328cf7();
				break;
			case "Lines":
				builtInDocumentProperties.Lines = x3bcd232d01c.xab461f3453328cf7();
				break;
			case "Paragraphs":
				builtInDocumentProperties.Paragraphs = x3bcd232d01c.xab461f3453328cf7();
				break;
			case "CharactersWithSpaces":
				builtInDocumentProperties.CharactersWithSpaces = x3bcd232d01c.xab461f3453328cf7();
				break;
			case "Version":
				builtInDocumentProperties.Version = xc1b08afa36bf580c.x059ac2aa14131725(x3bcd232d01c.x2a1ea9d24e62bf84());
				break;
			default:
				x3bcd232d01c.IgnoreElement();
				break;
			case "PresentationFormat":
			case "Guid":
				break;
			}
		}
	}

	internal static void x75b613efd8182791(x21a61af92fc2a45e xe134235b3526fa75)
	{
		Document document = (Document)xe134235b3526fa75.x2c8c6741422a1298;
		CustomDocumentProperties customDocumentProperties = document.CustomDocumentProperties;
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		while (x3bcd232d01c.x152cbadbfa8061b1("CustomDocumentProperties"))
		{
			string xc15bd84e = xd03457bb4d7bbf85(x3bcd232d01c.xa66385d80d4d296f);
			string text = null;
			string text2 = null;
			while (x3bcd232d01c.x1ac1960adc8c4c39())
			{
				switch (x3bcd232d01c.xa66385d80d4d296f)
				{
				case "dt":
					text2 = x3bcd232d01c.xd2f68ee6f47e9dfb;
					break;
				case "link":
					text = x3bcd232d01c.xd2f68ee6f47e9dfb;
					break;
				}
			}
			string text3 = x3bcd232d01c.x2a1ea9d24e62bf84();
			switch (text2)
			{
			case "string":
			{
				DocumentProperty documentProperty = customDocumentProperties.x1cd8943d02c5342f(xc15bd84e, text3);
				if (x0d299f323d241756.x5959bccb67bbf051(text))
				{
					documentProperty.x1321c7b28b151682 = text;
				}
				break;
			}
			case "float":
			{
				double num = xca004f56614e2431.xec25d08a2af152f0(text3);
				if ((double)(int)num == num)
				{
					customDocumentProperties.x1cd8943d02c5342f(xc15bd84e, (int)num);
				}
				else
				{
					customDocumentProperties.x1cd8943d02c5342f(xc15bd84e, num);
				}
				break;
			}
			case "boolean":
				customDocumentProperties.x1cd8943d02c5342f(xc15bd84e, x3bcd232d01c.xb2be52a3d2802fc5(text3));
				break;
			case "dateTime":
			case "dateTime.tz":
				customDocumentProperties.x1cd8943d02c5342f(xc15bd84e, xca004f56614e2431.x70982613fd6240f9(text3));
				break;
			}
		}
	}

	private static string xd03457bb4d7bbf85(string xc15bd84e01929885)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (Match item in x5740629b6f4295b0.Matches(xc15bd84e01929885))
		{
			string value = item.Groups[3].Value;
			if (x0d299f323d241756.x5959bccb67bbf051(value))
			{
				stringBuilder.Append(value);
			}
			else
			{
				stringBuilder.Append(xa97be7e956715c70(item.Groups[2].Value));
			}
		}
		return stringBuilder.ToString();
	}

	private static char xa97be7e956715c70(string xc1db5dbaf009ebd2)
	{
		xc1db5dbaf009ebd2 = xc1db5dbaf009ebd2.Trim('_', 'x');
		return (char)xca004f56614e2431.xadcf75bfc0bf31e3(xc1db5dbaf009ebd2);
	}
}
