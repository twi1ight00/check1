using System;
using Aspose.Words;
using x13f1efc79617a47b;
using x6c95d9cf46ff5f25;

namespace x28925c9b27b37a46;

internal class xfcbee4820570241e : DocumentVisitor
{
	private readonly string x113ec0a83b1ef460;

	private readonly bool xd14dc6c8d19c9a6f;

	private BookmarkStart x8408170975a63c2a;

	private BookmarkEnd xd6a7d07cb70f9923;

	private xfcbee4820570241e(string bookmarkName, bool isLookingForStart)
	{
		x113ec0a83b1ef460 = bookmarkName;
		xd14dc6c8d19c9a6f = isLookingForStart;
	}

	internal static BookmarkStart x7dff5baaa927f80f(Node xda5bf54deb817e37, string xd17ec8f278d25c87)
	{
		xfcbee4820570241e xfcbee4820570241e2 = new xfcbee4820570241e(xd17ec8f278d25c87, isLookingForStart: true);
		xda5bf54deb817e37.Accept(xfcbee4820570241e2);
		return xfcbee4820570241e2.x8408170975a63c2a;
	}

	internal static BookmarkEnd x1c27bfd94cd10eef(Node xda5bf54deb817e37, string xd17ec8f278d25c87)
	{
		if (xda5bf54deb817e37 == null)
		{
			throw new ArgumentNullException("node");
		}
		xfcbee4820570241e xfcbee4820570241e2 = new xfcbee4820570241e(xd17ec8f278d25c87, isLookingForStart: false);
		xda5bf54deb817e37.Accept(xfcbee4820570241e2);
		return xfcbee4820570241e2.xd6a7d07cb70f9923;
	}

	internal static BookmarkStart xca0fdfb9d22559d0(Node xda5bf54deb817e37, string xd17ec8f278d25c87)
	{
		BookmarkStart bookmarkStart = x7dff5baaa927f80f(xda5bf54deb817e37, xd17ec8f278d25c87);
		if (bookmarkStart == null)
		{
			throw new InvalidOperationException(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("hpopcbgambnajbebhblbjbcccmicfaadfahdhaodkpeedllecpcfmpjfjpagcphgbpogcofhapmhgodiijkimjbjnoijpjpjjogkajnkgielmmllomcmnhjmomanplhnjlonbhfoclmokldplkkpklbapkiaekpakkgbnknbegec", 709295796)), xd17ec8f278d25c87));
		}
		return bookmarkStart;
	}

	internal static BookmarkEnd x826809a474c46025(Node xda5bf54deb817e37, string xd17ec8f278d25c87)
	{
		BookmarkEnd bookmarkEnd = x1c27bfd94cd10eef(xda5bf54deb817e37, xd17ec8f278d25c87);
		if (bookmarkEnd == null)
		{
			throw new InvalidOperationException(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("olaljnhldoolaofmonmmaodnjiknmmbommioompobmgpkhnpjleadmlaamcbjljbilacjkhchlocnkfdpfmddgdeelkeggbfalifhfpfneggdjngfjeheelhfjcigijiaiajidhjjhojbifkchmkbidlghkllgbmbhimehpmlcgn", 724807803)), xd17ec8f278d25c87));
		}
		return bookmarkEnd;
	}

	public override VisitorAction VisitBookmarkStart(BookmarkStart node)
	{
		if (xd14dc6c8d19c9a6f && x0d299f323d241756.x90637a473b1ceaaa(x113ec0a83b1ef460, node.Name))
		{
			x8408170975a63c2a = node;
			return VisitorAction.Stop;
		}
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitBookmarkEnd(BookmarkEnd node)
	{
		if (!xd14dc6c8d19c9a6f && x0d299f323d241756.x90637a473b1ceaaa(x113ec0a83b1ef460, node.Name))
		{
			xd6a7d07cb70f9923 = node;
			return VisitorAction.Stop;
		}
		return VisitorAction.Continue;
	}
}
