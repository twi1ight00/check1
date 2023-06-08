using System;
using System.Collections;
using System.IO;
using Aspose.Words;
using Aspose.Words.Markup;
using Aspose.Words.Properties;
using Aspose.Words.Saving;
using x28925c9b27b37a46;
using x5f3520a4b31ea90f;
using x6c95d9cf46ff5f25;
using xb92b7270f78a4e8d;
using xcf014befd8b52c3b;
using xf989f31a236ff98c;
using xfc5388ad7dff404f;

namespace xa8550ea6ae4a81a5;

internal class xe41cdb7a2a4611b4 : x3d2908992e1d1667
{
	private x8556eed81191af11 xb36c250515e408ad;

	private xada461b17cdccac0 x7e24ae8042d3886b = new xe965bada78e2d6b1();

	private readonly Hashtable x2538deb7db4a006c = new Hashtable();

	private readonly Hashtable xbe19a6c1cde850d8 = new Hashtable();

	private x2d5c6b020426990c x5658018be97d0c02;

	internal xada461b17cdccac0 x39c7aeeec1af9dd0 => x7e24ae8042d3886b;

	internal Document x2c8c6741422a1298 => xb36c250515e408ad.x2c8c6741422a1298;

	internal x8556eed81191af11 x8556eed81191af11 => xb36c250515e408ad;

	private bool x0849d69e288b2e83 => xf57de0fd37d5e97d.PrettyFormat;

	internal IWarningCallback xf69ca7a9bb4a4a51 => xb36c250515e408ad.xf57de0fd37d5e97d.WarningCallback;

	private OoxmlSaveOptions xf57de0fd37d5e97d => (OoxmlSaveOptions)xb36c250515e408ad.xf57de0fd37d5e97d;

	private SaveOutputParameters x8cac5adfe79bc025(x8556eed81191af11 x5ac1382edb7bf2c2)
	{
		xb36c250515e408ad = x5ac1382edb7bf2c2;
		x11d9a43a940c51ae();
		switch (x5ac1382edb7bf2c2.x707d72c3570dbf2d)
		{
		case SaveFormat.FlatOpc:
		case SaveFormat.FlatOpcMacroEnabled:
		case SaveFormat.FlatOpcTemplate:
		case SaveFormat.FlatOpcTemplateMacroEnabled:
			x7e24ae8042d3886b = new x252c4abfc5a8ee00();
			break;
		case SaveFormat.Docx:
		case SaveFormat.Docm:
		case SaveFormat.Dotx:
		case SaveFormat.Dotm:
			x7e24ae8042d3886b = new xe965bada78e2d6b1();
			break;
		default:
			throw new InvalidOperationException($"Unexpected SaveFormat value {x5ac1382edb7bf2c2.x707d72c3570dbf2d}.");
		}
		x5658018be97d0c02 = new x2d5c6b020426990c(x5ac1382edb7bf2c2);
		xe3d2f5ee6867cec8();
		x24a159cb5d2740ba.x6210059f049f0d48(this);
		xe380a2f741020f0c();
		x88b616adafef1fe9.x6210059f049f0d48(this);
		x463daa915136d6ec();
		x37e34a3456bf5150.x6210059f049f0d48(x7e24ae8042d3886b, x0849d69e288b2e83);
		switch (x5ac1382edb7bf2c2.x707d72c3570dbf2d)
		{
		case SaveFormat.Docx:
		case SaveFormat.Docm:
		case SaveFormat.Dotx:
		case SaveFormat.Dotm:
			x2819edc79dd3a61d.x6210059f049f0d48((xe965bada78e2d6b1)x7e24ae8042d3886b, x0849d69e288b2e83);
			break;
		}
		if (x5ac1382edb7bf2c2.xf57de0fd37d5e97d is OoxmlSaveOptions ooxmlSaveOptions && x0d299f323d241756.x5959bccb67bbf051(ooxmlSaveOptions.Password))
		{
			MemoryStream memoryStream = new MemoryStream();
			x7e24ae8042d3886b.Save(memoryStream);
			xd8c3135513b9115b xd8c3135513b9115b = xd855f141beac193d.x246b032720dd4c0d(memoryStream, ooxmlSaveOptions.Password);
			xd8c3135513b9115b.x0acd3c2012ea2ee8(x5ac1382edb7bf2c2.xb8a774e0111d0fbe);
		}
		else
		{
			x7e24ae8042d3886b.Save(x5ac1382edb7bf2c2.xb8a774e0111d0fbe);
		}
		x5658018be97d0c02.x618890967a836e8b();
		return new SaveOutputParameters(x6d7e93096186c0df());
	}

	SaveOutputParameters x3d2908992e1d1667.xa2e0b7f7da663553(x8556eed81191af11 x5ac1382edb7bf2c2)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x8cac5adfe79bc025
		return this.x8cac5adfe79bc025(x5ac1382edb7bf2c2);
	}

	private void x11d9a43a940c51ae()
	{
		if (xb36c250515e408ad.x2c8c6741422a1298.HasMacros)
		{
			switch (xb36c250515e408ad.x707d72c3570dbf2d)
			{
			case SaveFormat.Docx:
			case SaveFormat.Dotx:
			case SaveFormat.FlatOpc:
				throw new InvalidOperationException("This document contains macros (VBA project) and you are attempting to save it in a Macro-Free format. Such document will be invalid if created. You need to either save it in a Macro-Enabled format (.DOCM or .DOTM) or remove macros before saving using the Document.RemoveMacros method.");
			default:
				throw new InvalidOperationException("Unexpected save format.");
			case SaveFormat.Docm:
			case SaveFormat.Dotm:
			case SaveFormat.FlatOpcMacroEnabled:
			case SaveFormat.FlatOpcTemplateMacroEnabled:
				break;
			}
		}
	}

	private string x6d7e93096186c0df()
	{
		switch (xb36c250515e408ad.x707d72c3570dbf2d)
		{
		case SaveFormat.Docx:
		case SaveFormat.FlatOpc:
			return "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
		case SaveFormat.Docm:
		case SaveFormat.FlatOpcMacroEnabled:
			return "application/vnd.ms-word.document.macroEnabled.12";
		case SaveFormat.Dotx:
		case SaveFormat.FlatOpcTemplate:
			return "application/vnd.openxmlformats-officedocument.wordprocessingml.template";
		case SaveFormat.Dotm:
		case SaveFormat.FlatOpcTemplateMacroEnabled:
			return "application/vnd.ms-word.template.macroEnabled.12";
		default:
			throw new InvalidOperationException("Unexpected save format.");
		}
	}

	private void xe3d2f5ee6867cec8()
	{
		xb36c250515e408ad.x466c910d5f8cc342();
		x07e190e23dab42a9 x07e190e23dab42a10 = new x07e190e23dab42a9(this, x5658018be97d0c02);
		x07e190e23dab42a10.x6210059f049f0d48();
	}

	private void xe380a2f741020f0c()
	{
		x8f3af96aa56f1e32 xd07ce4b74c5774a = x082c3925d43afdad("/docProps/core.xml", "application/vnd.openxmlformats-package.core-properties+xml", "http://schemas.openxmlformats.org/package/2006/relationships/metadata/core-properties");
		BuiltInDocumentProperties builtInDocumentProperties = x2c8c6741422a1298.BuiltInDocumentProperties;
		xce0a9cd40869484e.x6210059f049f0d48(xd07ce4b74c5774a, builtInDocumentProperties.Title, builtInDocumentProperties.Subject, builtInDocumentProperties.Author, builtInDocumentProperties.Keywords, builtInDocumentProperties.Comments, builtInDocumentProperties.LastSavedBy, builtInDocumentProperties.RevisionNumber.ToString(), builtInDocumentProperties.LastPrinted, builtInDocumentProperties.CreatedTime, builtInDocumentProperties.LastSavedTime, builtInDocumentProperties.Category);
	}

	private void x463daa915136d6ec()
	{
		foreach (CustomPart packageCustomPart in x2c8c6741422a1298.PackageCustomParts)
		{
			if (x7e24ae8042d3886b.xd6abb2ab950b4d22.x263d579af1d0d43f(packageCustomPart.Name))
			{
				int startIndex = packageCustomPart.Name.LastIndexOf(".");
				packageCustomPart.Name = packageCustomPart.Name.Insert(startIndex, "1");
			}
			if (packageCustomPart.IsExternal)
			{
				x7e24ae8042d3886b.xadb7000bed559a9a.xd6b6ed77479ef68c(packageCustomPart.RelationshipType, packageCustomPart.Name, x1bc1cc5e4fd586bf: true);
				continue;
			}
			xa2f1c3dcbd86f20a xa2f1c3dcbd86f20a = x7e24ae8042d3886b.x42c5f80e2ed823ff(null, packageCustomPart.Name, packageCustomPart.ContentType, packageCustomPart.RelationshipType);
			xa2f1c3dcbd86f20a.xb8a774e0111d0fbe = new MemoryStream(packageCustomPart.Data);
		}
	}

	internal x8f3af96aa56f1e32 x082c3925d43afdad(string x69cb5ff2e6c23f47, string xe1d3286d17e44a37, string x061610664b4c984f)
	{
		xa2f1c3dcbd86f20a part = x7e24ae8042d3886b.x42c5f80e2ed823ff(null, x69cb5ff2e6c23f47, xe1d3286d17e44a37, x061610664b4c984f);
		return new x8f3af96aa56f1e32(part, x0849d69e288b2e83, xf57de0fd37d5e97d.Compliance);
	}

	internal int x15789b8c2554f92e(string x061610664b4c984f)
	{
		object obj = xbe19a6c1cde850d8[x061610664b4c984f];
		int num = ((obj != null) ? ((int)obj) : 0);
		num++;
		xbe19a6c1cde850d8[x061610664b4c984f] = num;
		return num;
	}

	internal string x4ce44a3c724a357f(byte[] x43e181e083db6cdf)
	{
		return (string)x2538deb7db4a006c[x66cdafe77e7aa42b.x8341ba999ffebb91(x43e181e083db6cdf)];
	}

	internal void x7760c45a55261d34(byte[] x43e181e083db6cdf, string xd8c5c0b23a1bfb3a)
	{
		x2538deb7db4a006c.Add(x66cdafe77e7aa42b.x8341ba999ffebb91(x43e181e083db6cdf), xd8c5c0b23a1bfb3a);
	}
}
