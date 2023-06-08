using Aspose.Words.Properties;
using x6c95d9cf46ff5f25;
using xda075892eccab2ad;

namespace x79490184cecf12a1;

internal class x6b4f5de672d5a92b
{
	private x6b4f5de672d5a92b()
	{
	}

	internal static void x06b0e25aa6ad68a9(xae13d15563a3a703 xe134235b3526fa75)
	{
		x9ea8b270a83f04a0 x9ea8b270a83f04a = xe134235b3526fa75.x953c9e9688085b0b("http://schemas.openxmlformats.org/officeDocument/2006/relationships/extended-properties");
		if (x9ea8b270a83f04a == null)
		{
			return;
		}
		BuiltInDocumentProperties builtInDocumentProperties = xe134235b3526fa75.x2c8c6741422a1298.BuiltInDocumentProperties;
		while (x9ea8b270a83f04a.x152cbadbfa8061b1("Properties"))
		{
			switch (x9ea8b270a83f04a.xa66385d80d4d296f)
			{
			case "Template":
				builtInDocumentProperties.Template = x9ea8b270a83f04a.x2a1ea9d24e62bf84();
				break;
			case "TotalTime":
				builtInDocumentProperties.xcc3f5a7a232023b9(x9ea8b270a83f04a.xab461f3453328cf7());
				break;
			case "Pages":
				builtInDocumentProperties.Pages = x9ea8b270a83f04a.xab461f3453328cf7();
				break;
			case "Words":
				builtInDocumentProperties.Words = x9ea8b270a83f04a.xab461f3453328cf7();
				break;
			case "Characters":
				builtInDocumentProperties.Characters = x9ea8b270a83f04a.xab461f3453328cf7();
				break;
			case "Application":
				builtInDocumentProperties.NameOfApplication = x9ea8b270a83f04a.x2a1ea9d24e62bf84();
				break;
			case "DocSecurity":
				builtInDocumentProperties.Security = (DocumentSecurity)x9ea8b270a83f04a.xab461f3453328cf7();
				break;
			case "Lines":
				builtInDocumentProperties.Lines = x9ea8b270a83f04a.xab461f3453328cf7();
				break;
			case "Paragraphs":
				builtInDocumentProperties.Paragraphs = x9ea8b270a83f04a.xab461f3453328cf7();
				break;
			case "HeadingPairs":
				builtInDocumentProperties.HeadingPairs = x87d43649714b8351(x9ea8b270a83f04a);
				break;
			case "TitlesOfParts":
				builtInDocumentProperties.TitlesOfParts = xb5f055b49e1a7bd6(x9ea8b270a83f04a);
				break;
			case "Manager":
				builtInDocumentProperties.Manager = x9ea8b270a83f04a.x2a1ea9d24e62bf84();
				break;
			case "Company":
				builtInDocumentProperties.Company = x9ea8b270a83f04a.x2a1ea9d24e62bf84();
				break;
			case "CharactersWithSpaces":
				builtInDocumentProperties.CharactersWithSpaces = x9ea8b270a83f04a.xab461f3453328cf7();
				break;
			case "HyperlinkBase":
				builtInDocumentProperties.HyperlinkBase = x9ea8b270a83f04a.x2a1ea9d24e62bf84();
				break;
			case "AppVersion":
				builtInDocumentProperties.Version = xc1b08afa36bf580c.x059ac2aa14131725(x9ea8b270a83f04a.x2a1ea9d24e62bf84());
				break;
			default:
				x9ea8b270a83f04a.IgnoreElement();
				break;
			case "ScaleCrop":
			case "LinksUpToDate":
			case "SharedDoc":
			case "HLinks":
			case "HyperlinksChanged":
			case "DigSig":
				break;
			}
		}
	}

	private static object[] x87d43649714b8351(x9ea8b270a83f04a0 x97bf2eeabd4abc7b)
	{
		while (x97bf2eeabd4abc7b.x152cbadbfa8061b1("HeadingPairs"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x97bf2eeabd4abc7b.xa66385d80d4d296f) != null && xa66385d80d4d296f == "vector")
			{
				return x45109d442ef52f39(x97bf2eeabd4abc7b);
			}
		}
		return new object[0];
	}

	private static string[] xb5f055b49e1a7bd6(x9ea8b270a83f04a0 x97bf2eeabd4abc7b)
	{
		while (x97bf2eeabd4abc7b.x152cbadbfa8061b1("TitlesOfParts"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x97bf2eeabd4abc7b.xa66385d80d4d296f) != null && xa66385d80d4d296f == "vector")
			{
				object[] array = x45109d442ef52f39(x97bf2eeabd4abc7b);
				string[] array2 = new string[array.Length];
				array.CopyTo(array2, 0);
				return array2;
			}
		}
		return new string[0];
	}

	private static object[] x45109d442ef52f39(x9ea8b270a83f04a0 x97bf2eeabd4abc7b)
	{
		int num = 0;
		while (x97bf2eeabd4abc7b.x1ac1960adc8c4c39())
		{
			switch (x97bf2eeabd4abc7b.xa66385d80d4d296f)
			{
			case "size":
				num = x97bf2eeabd4abc7b.xbba6773b8ce56a01;
				break;
			}
		}
		object[] array = new object[num];
		int num2 = 0;
		while (x97bf2eeabd4abc7b.x416ea3123144a39f("vector", x764dfdef5d60f7e6.x96ad199d34a16ce4))
		{
			switch (x97bf2eeabd4abc7b.xa66385d80d4d296f)
			{
			case "variant":
				array[num2] = x75b12e912959b546(x97bf2eeabd4abc7b);
				num2++;
				break;
			case "lpstr":
				array[num2] = x97bf2eeabd4abc7b.x2a1ea9d24e62bf84();
				num2++;
				break;
			}
		}
		return array;
	}

	private static object x75b12e912959b546(x9ea8b270a83f04a0 x97bf2eeabd4abc7b)
	{
		while (x97bf2eeabd4abc7b.x152cbadbfa8061b1("variant"))
		{
			switch (x97bf2eeabd4abc7b.xa66385d80d4d296f)
			{
			case "lpstr":
				return x97bf2eeabd4abc7b.x2a1ea9d24e62bf84();
			case "i4":
				return x97bf2eeabd4abc7b.xab461f3453328cf7();
			}
		}
		return null;
	}
}
