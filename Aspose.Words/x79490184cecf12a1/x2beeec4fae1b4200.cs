using Aspose.Words.Properties;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace x79490184cecf12a1;

internal class x2beeec4fae1b4200
{
	private x2beeec4fae1b4200()
	{
	}

	internal static void x06b0e25aa6ad68a9(xae13d15563a3a703 xe134235b3526fa75)
	{
		x9ea8b270a83f04a0 x9ea8b270a83f04a = xe134235b3526fa75.x953c9e9688085b0b("http://schemas.openxmlformats.org/officeDocument/2006/relationships/custom-properties");
		if (x9ea8b270a83f04a == null)
		{
			return;
		}
		CustomDocumentProperties customDocumentProperties = xe134235b3526fa75.x2c8c6741422a1298.CustomDocumentProperties;
		while (x9ea8b270a83f04a.x152cbadbfa8061b1("Properties"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x9ea8b270a83f04a.xa66385d80d4d296f) != null && xa66385d80d4d296f == "property")
			{
				x28dded36d4f49079(customDocumentProperties, x9ea8b270a83f04a);
			}
			else
			{
				x9ea8b270a83f04a.IgnoreElement();
			}
		}
	}

	private static void x28dded36d4f49079(CustomDocumentProperties xa5ea04da0b735c3b, x9ea8b270a83f04a0 x97bf2eeabd4abc7b)
	{
		string text = null;
		string text2 = null;
		while (x97bf2eeabd4abc7b.x1ac1960adc8c4c39())
		{
			switch (x97bf2eeabd4abc7b.xa66385d80d4d296f)
			{
			case "name":
				text = x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb;
				break;
			case "linkTarget":
				text2 = x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb;
				break;
			}
		}
		if (!x0d299f323d241756.x5959bccb67bbf051(text))
		{
			return;
		}
		while (x97bf2eeabd4abc7b.x152cbadbfa8061b1("property"))
		{
			switch (x97bf2eeabd4abc7b.xa66385d80d4d296f)
			{
			case "bool":
				xa5ea04da0b735c3b.x1cd8943d02c5342f(text, x97bf2eeabd4abc7b.xe90b56390d1b0697(xc6e85c82d0d89508: false));
				break;
			case "i4":
				xa5ea04da0b735c3b.x1cd8943d02c5342f(text, x97bf2eeabd4abc7b.xab461f3453328cf7());
				break;
			case "r8":
				xa5ea04da0b735c3b.x1cd8943d02c5342f(text, xca004f56614e2431.xec25d08a2af152f0(x97bf2eeabd4abc7b.x2a1ea9d24e62bf84()));
				break;
			case "lpwstr":
			{
				DocumentProperty documentProperty = xa5ea04da0b735c3b.x1cd8943d02c5342f(text, x97bf2eeabd4abc7b.x2a1ea9d24e62bf84());
				if (x0d299f323d241756.x5959bccb67bbf051(text2))
				{
					documentProperty.x1321c7b28b151682 = text2;
				}
				break;
			}
			case "filetime":
				xa5ea04da0b735c3b.x1cd8943d02c5342f(text, xca004f56614e2431.x70982613fd6240f9(x97bf2eeabd4abc7b.x2a1ea9d24e62bf84()));
				break;
			default:
				x97bf2eeabd4abc7b.IgnoreElement();
				break;
			}
		}
	}
}
