using System;
using Aspose.Words;
using Aspose.Words.BuildingBlocks;
using x909757d9fd2dd6ae;
using xfc5388ad7dff404f;

namespace xa8550ea6ae4a81a5;

internal class xd202579be1a2666f : xaf66e8c590b2b553
{
	internal xd202579be1a2666f(xe41cdb7a2a4611b4 writer)
		: base(writer, writer.x2c8c6741422a1298.GlossaryDocument, writer.xf69ca7a9bb4a4a51)
	{
	}

	protected override xa2f1c3dcbd86f20a DoCreateDocumentPart()
	{
		xa2f1c3dcbd86f20a x660bfbc29977d3c = base.x39c7aeeec1af9dd0.xe55f59c79966b924(null, "http://schemas.openxmlformats.org/officeDocument/2006/relationships/officeDocument");
		return base.x39c7aeeec1af9dd0.x42c5f80e2ed823ff(x660bfbc29977d3c, "glossary/document.xml", "application/vnd.openxmlformats-officedocument.wordprocessingml.document.glossary+xml", "http://schemas.openxmlformats.org/officeDocument/2006/relationships/glossaryDocument");
	}

	protected override void DoWrite()
	{
		x8f3af96aa56f1e32 x8f3af96aa56f1e33 = base.xca93abf9292cd4f1;
		x8f3af96aa56f1e33.x454da6e050647673("w:glossaryDocument");
		x8f3af96aa56f1e33.x2307058321cdb62f("w:docParts");
		base.x2c8c6741422a1298.Accept(this);
		x8f3af96aa56f1e33.x2dfde153f4ef96d0();
		x8f3af96aa56f1e33.xa0dfc102c691b11f();
	}

	public override VisitorAction VisitBuildingBlockStart(BuildingBlock block)
	{
		base.xca93abf9292cd4f1.x2307058321cdb62f("w:docPart");
		x292ff38e4213c94f(block);
		base.xca93abf9292cd4f1.x2307058321cdb62f("w:docPartBody");
		x427772a8a25f1c7a(block);
		base.xca93abf9292cd4f1.x2dfde153f4ef96d0();
		base.xca93abf9292cd4f1.x2dfde153f4ef96d0();
		return VisitorAction.SkipThisNode;
	}

	private void x292ff38e4213c94f(BuildingBlock xe413319369b234aa)
	{
		x8f3af96aa56f1e32 x8f3af96aa56f1e33 = base.xca93abf9292cd4f1;
		x8f3af96aa56f1e33.x2307058321cdb62f("w:docPartPr");
		x8f3af96aa56f1e33.x2307058321cdb62f("w:name");
		x8f3af96aa56f1e33.x0ea3ef8dd3ae2f3f("w:decorated", xe413319369b234aa.xd448af18fed11a9d);
		x8f3af96aa56f1e33.x943f6be3acf634db("w:val", xe413319369b234aa.Name);
		x8f3af96aa56f1e33.x2dfde153f4ef96d0();
		x8f3af96aa56f1e33.x547195bcc386fe66("w:style", xe413319369b234aa.xfe2178c1f916f36c);
		x8f3af96aa56f1e33.x2307058321cdb62f("w:category");
		x8f3af96aa56f1e33.x547195bcc386fe66("w:name", xe413319369b234aa.Category);
		x8f3af96aa56f1e33.x547195bcc386fe66("w:gallery", xc62574be95c1c918.xe043c7f7b071a6c5(xe413319369b234aa.Gallery));
		x8f3af96aa56f1e33.x2dfde153f4ef96d0();
		if (xe413319369b234aa.Type != 0)
		{
			x8f3af96aa56f1e33.x2307058321cdb62f("w:types");
			if (xe413319369b234aa.Type == BuildingBlockType.All)
			{
				x8f3af96aa56f1e33.x943f6be3acf634db("all", xbcea506a33cf9111: true);
			}
			else
			{
				x8f3af96aa56f1e33.x547195bcc386fe66("w:type", xc62574be95c1c918.x291f2518c2c27e2d(xe413319369b234aa.Type));
			}
			x8f3af96aa56f1e33.x2dfde153f4ef96d0();
		}
		x8f3af96aa56f1e33.x2307058321cdb62f("w:behaviors");
		x8f3af96aa56f1e33.x547195bcc386fe66("w:behavior", xc62574be95c1c918.xe43d1430fdb4a8b1(xe413319369b234aa.Behavior));
		x8f3af96aa56f1e33.x2dfde153f4ef96d0();
		x8f3af96aa56f1e33.x547195bcc386fe66("w:description", xe413319369b234aa.Description);
		if (!xe413319369b234aa.Guid.Equals(Guid.Empty))
		{
			x8f3af96aa56f1e33.x547195bcc386fe66("w:guid", xe413319369b234aa.Guid.ToString("B").ToUpper());
		}
		x8f3af96aa56f1e33.x2dfde153f4ef96d0();
	}
}
