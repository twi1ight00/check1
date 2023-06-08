using System;
using System.Collections;
using System.IO;
using Aspose.Words;
using x6c95d9cf46ff5f25;
using xcf014befd8b52c3b;
using xfc5388ad7dff404f;

namespace x79490184cecf12a1;

internal class xae13d15563a3a703
{
	private readonly xada461b17cdccac0 x7e24ae8042d3886b;

	private readonly Document x232be220f517f721;

	private readonly LoadOptions xd545ef71ef25db52;

	internal Document x2c8c6741422a1298 => x232be220f517f721;

	internal xae13d15563a3a703(Stream stream, Document doc, LoadOptions loadOptions)
	{
		switch (doc.OriginalLoadFormat)
		{
		case LoadFormat.FlatOpc:
		case LoadFormat.FlatOpcMacroEnabled:
		case LoadFormat.FlatOpcTemplate:
		case LoadFormat.FlatOpcTemplateMacroEnabled:
			x7e24ae8042d3886b = new x252c4abfc5a8ee00(stream);
			break;
		case LoadFormat.Docx:
		case LoadFormat.Docm:
		case LoadFormat.Dotx:
		case LoadFormat.Dotm:
			x7e24ae8042d3886b = new xe965bada78e2d6b1(stream);
			break;
		default:
			throw new InvalidOperationException($"Unexpected LoadFormat value {doc.OriginalLoadFormat}.");
		}
		x232be220f517f721 = doc;
		xd545ef71ef25db52 = loadOptions;
		x50f330d2e9110a2e();
	}

	internal void x50f330d2e9110a2e()
	{
		xa2f1c3dcbd86f20a xa2f1c3dcbd86f20a = x7e24ae8042d3886b.x4bfdbcbc6a51d705(null, "http://schemas.openxmlformats.org/package/2006/relationships/digital-signature/origin");
		if (xa2f1c3dcbd86f20a == null)
		{
			return;
		}
		foreach (x5b6f1954712b741f item in (IEnumerable)xa2f1c3dcbd86f20a.xadb7000bed559a9a)
		{
			string xc15bd84e = xa2f1c3dcbd86f20a.xa687196d807ab9c0(item);
			xa2f1c3dcbd86f20a xa2f1c3dcbd86f20a2 = x7e24ae8042d3886b.xd4e2719ccf56f4d7(xc15bd84e);
			x616fc5ae23ca7e6e.x06b0e25aa6ad68a9(xa2f1c3dcbd86f20a2.xb8a774e0111d0fbe, new xff730791225e269d(x7e24ae8042d3886b), x232be220f517f721.DigitalSignatures, xd545ef71ef25db52.WarningCallback);
		}
	}

	internal void x06b0e25aa6ad68a9()
	{
		x867d8f7b30a3103b.x06b0e25aa6ad68a9(this);
		x6b4f5de672d5a92b.x06b0e25aa6ad68a9(this);
		x2beeec4fae1b4200.x06b0e25aa6ad68a9(this);
		x748a2047fcb706ad();
		xac1e2fd5e8226038.x06b0e25aa6ad68a9(x7e24ae8042d3886b.xadb7000bed559a9a, x7e24ae8042d3886b, x232be220f517f721.PackageCustomParts);
	}

	private void x748a2047fcb706ad()
	{
		xa2f1c3dcbd86f20a documentPart = x7e24ae8042d3886b.xe55f59c79966b924(null, "http://schemas.openxmlformats.org/officeDocument/2006/relationships/officeDocument");
		xa52ef41af20225f0 xa52ef41af20225f = new xa52ef41af20225f0(x7e24ae8042d3886b, documentPart, x232be220f517f721, xd545ef71ef25db52);
		xa52ef41af20225f.x06b0e25aa6ad68a9();
	}

	internal x9ea8b270a83f04a0 x953c9e9688085b0b(string x061610664b4c984f)
	{
		xa2f1c3dcbd86f20a xa2f1c3dcbd86f20a = x7e24ae8042d3886b.x4bfdbcbc6a51d705(null, x061610664b4c984f);
		if (xa2f1c3dcbd86f20a == null)
		{
			return null;
		}
		return new x9ea8b270a83f04a0(xa2f1c3dcbd86f20a);
	}

	internal static LoadFormat x6c4f542a03d83ce6(Stream xc21f6cb64a6d970f)
	{
		xc1dcd6189d01216e xc1dcd6189d01216e = new xc1dcd6189d01216e(xc21f6cb64a6d970f);
		while (xc1dcd6189d01216e.x152cbadbfa8061b1("Types"))
		{
			switch (xc1dcd6189d01216e.xa66385d80d4d296f)
			{
			case "Default":
			case "Override":
				switch (xc1dcd6189d01216e.xd68abcd61e368af9("ContentType", ""))
				{
				case "application/vnd.openxmlformats-officedocument.wordprocessingml.document.main+xml":
					return LoadFormat.Docx;
				case "application/vnd.ms-word.document.macroEnabled.main+xml":
					return LoadFormat.Docm;
				case "application/vnd.openxmlformats-officedocument.wordprocessingml.template.main+xml":
					return LoadFormat.Dotx;
				case "application/vnd.ms-word.template.macroEnabledTemplate.main+xml":
					return LoadFormat.Dotm;
				}
				break;
			default:
				xc1dcd6189d01216e.IgnoreElement();
				break;
			}
		}
		return LoadFormat.Unknown;
	}

	internal static bool x727228e6a08acf61(Stream xb351a4e577012fd5)
	{
		xc1dcd6189d01216e xc1dcd6189d01216e = new xc1dcd6189d01216e(xb351a4e577012fd5);
		while (xc1dcd6189d01216e.x152cbadbfa8061b1("Relationships"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = xc1dcd6189d01216e.xa66385d80d4d296f) != null && xa66385d80d4d296f == "Relationship")
			{
				string text = xc1dcd6189d01216e.xd68abcd61e368af9("Type", "");
				string text2;
				if ((text2 = text) != null && text2 == "http://schemas.openxmlformats.org/package/2006/relationships/digital-signature/origin")
				{
					return true;
				}
			}
			else
			{
				xc1dcd6189d01216e.IgnoreElement();
			}
		}
		return false;
	}
}
