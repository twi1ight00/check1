using System;
using System.Collections;
using System.ComponentModel;
using System.IO;
using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Markup;
using Aspose.Words.Saving;
using x13f1efc79617a47b;
using x1a3e96f4b89a7a77;
using x7c7a1dceb600404e;
using xc76255e87e5986c6;
using xf989f31a236ff98c;
using xfc5388ad7dff404f;

namespace xa8550ea6ae4a81a5;

internal class x07e190e23dab42a9 : xaf66e8c590b2b553
{
	private readonly x2d5c6b020426990c x5658018be97d0c02;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public new Document x2c8c6741422a1298 => (Document)base.x2c8c6741422a1298;

	internal x07e190e23dab42a9(xe41cdb7a2a4611b4 writer, x2d5c6b020426990c tempFiler)
		: base(writer, writer.x2c8c6741422a1298, writer.xf69ca7a9bb4a4a51)
	{
		x5658018be97d0c02 = tempFiler;
	}

	protected override xa2f1c3dcbd86f20a DoCreateDocumentPart()
	{
		xa2f1c3dcbd86f20a xa2f1c3dcbd86f20a = base.x39c7aeeec1af9dd0.x42c5f80e2ed823ff(null, "/word/document.xml", xdfec55e0fe5df813(), "http://schemas.openxmlformats.org/officeDocument/2006/relationships/officeDocument");
		if (x5658018be97d0c02.xea795c1b94b2c099)
		{
			xa2f1c3dcbd86f20a.xb8a774e0111d0fbe = x5658018be97d0c02.x6795cf98c786308b();
		}
		return xa2f1c3dcbd86f20a;
	}

	private string xdfec55e0fe5df813()
	{
		switch (base.x8556eed81191af11.x707d72c3570dbf2d)
		{
		case SaveFormat.Docx:
		case SaveFormat.FlatOpc:
			return "application/vnd.openxmlformats-officedocument.wordprocessingml.document.main+xml";
		case SaveFormat.Docm:
		case SaveFormat.FlatOpcMacroEnabled:
			return "application/vnd.ms-word.document.macroEnabled.main+xml";
		case SaveFormat.Dotx:
		case SaveFormat.FlatOpcTemplate:
			return "application/vnd.openxmlformats-officedocument.wordprocessingml.template.main+xml";
		case SaveFormat.Dotm:
		case SaveFormat.FlatOpcTemplateMacroEnabled:
			return "application/vnd.ms-word.template.macroEnabledTemplate.main+xml";
		default:
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("anlmgocnknjnkoaopnhobnoommfpknmpimdaemkanhbbamibampbamgcglncogedblldhlcehljepkafakhfalofhgfg", 435145595)));
		}
	}

	protected override void DoWrite()
	{
		x9045155c605c2116.x6210059f049f0d48(this);
		xe3d2f5ee6867cec8();
		xce0f75acb04bbc55.x6210059f049f0d48(this);
		x2191414f532035e4.x6210059f049f0d48(this);
		x3b01fb751cf2c46a();
		x7f233e73740ef24f();
	}

	private void xe3d2f5ee6867cec8()
	{
		Document document = base.x8556eed81191af11.x2c8c6741422a1298;
		x8f3af96aa56f1e32 x8f3af96aa56f1e33 = base.xca93abf9292cd4f1;
		if (x8f3af96aa56f1e33.xd115f8f0cdf9cf2f == OoxmlCompliance.Ecma376_2006)
		{
			x8f3af96aa56f1e33.x454da6e050647673("w:document");
			if (x6cd225a42531a409(document))
			{
				x8f3af96aa56f1e33.xff520a0047c27122("xmlns:mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
				x8f3af96aa56f1e33.xff520a0047c27122("xmlns:w14", "http://schemas.microsoft.com/office/word/2010/wordml");
				x8f3af96aa56f1e33.xff520a0047c27122("mc:Ignorable", "w14");
			}
		}
		else
		{
			x8f3af96aa56f1e33.x17784f246e4754b0("w:document");
		}
		if (base.xf57de0fd37d5e97d.xbfa4c2c3efbf56fd)
		{
			x8f3af96aa56f1e33.x5222f4285e37d66b.WriteComment(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("lmlkpoclkaklabbmeaimoapmkpfnkannipdoepkonkbpmoipaaaaekgampnaokebiplbijcc", 1643555755)), "Aspose.Words for .NET 11.9.0.0"));
		}
		x409f6d17d51b0ce0();
		x8f3af96aa56f1e33.x2307058321cdb62f("w:body");
		x427772a8a25f1c7a(document);
		if (base.x875353c6f45c336d.x16479f42fe4547f2)
		{
			xce7f0abd6b3cc3be.x6210059f049f0d48(base.x875353c6f45c336d, this);
		}
		x8f3af96aa56f1e33.x2dfde153f4ef96d0("w:body");
		x8f3af96aa56f1e33.xa0dfc102c691b11f();
	}

	private static bool x6cd225a42531a409(Document x6beba47238e0ade6)
	{
		NodeCollection childNodes = x6beba47238e0ade6.GetChildNodes(NodeType.StructuredDocumentTag, isDeep: true);
		foreach (StructuredDocumentTag item in childNodes)
		{
			if (item.x96381e70e1c51c6d.x3146d638ec378671 == SdtType.Checkbox)
			{
				return true;
			}
		}
		return false;
	}

	private void x409f6d17d51b0ce0()
	{
		Shape backgroundShape = base.x8556eed81191af11.x2c8c6741422a1298.BackgroundShape;
		if (Shape.x2e634d5c614a25de(backgroundShape))
		{
			x8f3af96aa56f1e32 x8f3af96aa56f1e33 = base.xca93abf9292cd4f1;
			x8f3af96aa56f1e33.x2307058321cdb62f("w:background");
			x8f3af96aa56f1e33.xff520a0047c27122("w:color", x8f3af96aa56f1e33.xb12f52d1ec4f4369(backgroundShape.Fill.x63b1a7c31a962459));
			xa25dec8c824ea182.x6210059f049f0d48(backgroundShape, xe4b4fecd3c706380: true, x8f3af96aa56f1e33, this);
			x8f3af96aa56f1e33.x2dfde153f4ef96d0();
			x8f3af96aa56f1e33.x2dfde153f4ef96d0();
		}
	}

	private void x3b01fb751cf2c46a()
	{
		CompositeNode glossaryDocument = base.x8556eed81191af11.x2c8c6741422a1298.GlossaryDocument;
		if (glossaryDocument != null && glossaryDocument.HasChildNodes)
		{
			xd202579be1a2666f xd202579be1a2666f2 = new xd202579be1a2666f(base.x5aa326f374b3d0ef);
			xd202579be1a2666f2.x6210059f049f0d48();
		}
	}

	private void x7f233e73740ef24f()
	{
		x3dabda6865ed239d x3dabda6865ed239d = base.x8556eed81191af11.x2c8c6741422a1298.x9bb3f6e28fa55f34();
		if (x3dabda6865ed239d == null)
		{
			return;
		}
		xa2f1c3dcbd86f20a xa2f1c3dcbd86f20a = base.x39c7aeeec1af9dd0.x42c5f80e2ed823ff(base.x2a0bb2f6650f6a43, "theme/theme1.xml", "application/vnd.openxmlformats-officedocument.theme+xml", "http://schemas.openxmlformats.org/officeDocument/2006/relationships/theme");
		xa2f1c3dcbd86f20a.xb8a774e0111d0fbe = x3dabda6865ed239d.x4b27d9fdab2746ba.xb8a774e0111d0fbe;
		foreach (x5b6f1954712b741f item in (IEnumerable)x3dabda6865ed239d.x4b27d9fdab2746ba.xadb7000bed559a9a)
		{
			if (item.x0552da4f5c09bde5)
			{
				xa2f1c3dcbd86f20a.xadb7000bed559a9a.xd6b6ed77479ef68c(item.xea1e81378298fa81, item.x3146d638ec378671, item.x42f4c234c9358072, item.x0552da4f5c09bde5);
				continue;
			}
			string text = xa2f1c3dcbd86f20a.xa687196d807ab9c0(item);
			if (base.x39c7aeeec1af9dd0.x7bd3b08f3e0470ca(text) != null)
			{
				text = Path.ChangeExtension(text, Guid.NewGuid().ToString() + Path.GetExtension(text));
			}
			xa2f1c3dcbd86f20a xa2f1c3dcbd86f20a2 = (xa2f1c3dcbd86f20a)x3dabda6865ed239d.x8c7d2c74298d462f[item.xea1e81378298fa81];
			xa2f1c3dcbd86f20a xa2f1c3dcbd86f20a3 = new xa2f1c3dcbd86f20a(text, xa2f1c3dcbd86f20a2.x0b93856f95be30d0);
			xa2f1c3dcbd86f20a3.xb8a774e0111d0fbe = xa2f1c3dcbd86f20a2.xb8a774e0111d0fbe;
			base.x39c7aeeec1af9dd0.xd6abb2ab950b4d22.xd6b6ed77479ef68c(xa2f1c3dcbd86f20a3);
			string x7a6cd6daf4195b8a = xada461b17cdccac0.x4063f4f83c7a7157(xa2f1c3dcbd86f20a.x759aa16c2016a289, text);
			xa2f1c3dcbd86f20a.xadb7000bed559a9a.xd6b6ed77479ef68c(item.xea1e81378298fa81, item.x3146d638ec378671, x7a6cd6daf4195b8a, item.x0552da4f5c09bde5);
		}
	}
}
