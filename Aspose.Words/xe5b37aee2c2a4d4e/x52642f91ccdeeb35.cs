using Aspose.Words;
using Aspose.Words.Math;
using x28925c9b27b37a46;

namespace xe5b37aee2c2a4d4e;

internal abstract class x52642f91ccdeeb35 : x4c1e058c67948d6a
{
	internal const char xfb5888eb7493933e = '\0';

	private static readonly x4c1e058c67948d6a x6f9bbccfb67dfb8c;

	internal abstract x3e68720d12325f49 x3e68720d12325f49 { get; }

	internal virtual bool xcbe541d3325b8546 => true;

	internal virtual bool x48738d418e15105b => true;

	internal virtual bool x8a4414b7d9d4073f(Node xda5bf54deb817e37)
	{
		if (xcbe541d3325b8546)
		{
			return xda5bf54deb817e37.NodeType == NodeType.OfficeMath && ((OfficeMath)xda5bf54deb817e37).x52642f91ccdeeb35.x3e68720d12325f49 == x3e68720d12325f49.x1745ba6c6d5efbc4;
		}
		return x6696894f491bb1a0(xda5bf54deb817e37);
	}

	internal static bool x6696894f491bb1a0(Node xda5bf54deb817e37)
	{
		switch (xda5bf54deb817e37.NodeType)
		{
		case NodeType.OfficeMath:
			return ((OfficeMath)xda5bf54deb817e37).x52642f91ccdeeb35.x48738d418e15105b;
		case NodeType.BookmarkStart:
		case NodeType.BookmarkEnd:
		case NodeType.Comment:
		case NodeType.Run:
		case NodeType.FieldStart:
		case NodeType.FieldSeparator:
		case NodeType.FieldEnd:
		case NodeType.SmartTag:
		case NodeType.CommentRangeStart:
		case NodeType.CommentRangeEnd:
			return true;
		default:
			return false;
		}
	}

	protected override x4c1e058c67948d6a GetDefaults()
	{
		return x6f9bbccfb67dfb8c;
	}

	static x52642f91ccdeeb35()
	{
		x6f9bbccfb67dfb8c = new xb19ef215dab9ccd8();
		x6f9bbccfb67dfb8c.xd6b6ed77479ef68c(15010, x2cdbcd6273a149f1.xfa862982140742a7);
		x6f9bbccfb67dfb8c.xd6b6ed77479ef68c(15030, xce8b2ce767b2485c.x9bcb07e204e30218);
		x6f9bbccfb67dfb8c.xd6b6ed77479ef68c(15040, '\u0302');
		x6f9bbccfb67dfb8c.xd6b6ed77479ef68c(15050, false);
		x6f9bbccfb67dfb8c.xd6b6ed77479ef68c(15060, false);
		x6f9bbccfb67dfb8c.xd6b6ed77479ef68c(15070, false);
		x6f9bbccfb67dfb8c.xd6b6ed77479ef68c(15080, false);
		x6f9bbccfb67dfb8c.xd6b6ed77479ef68c(15090, false);
		x6f9bbccfb67dfb8c.xd6b6ed77479ef68c(15100, false);
		x6f9bbccfb67dfb8c.xd6b6ed77479ef68c(15110, false);
		x6f9bbccfb67dfb8c.xd6b6ed77479ef68c(15120, false);
		x6f9bbccfb67dfb8c.xd6b6ed77479ef68c(15130, false);
		x6f9bbccfb67dfb8c.xd6b6ed77479ef68c(15140, false);
		x6f9bbccfb67dfb8c.xd6b6ed77479ef68c(15170, false);
		x6f9bbccfb67dfb8c.xd6b6ed77479ef68c(15160, true);
		x6f9bbccfb67dfb8c.xd6b6ed77479ef68c(15180, '(');
		x6f9bbccfb67dfb8c.xd6b6ed77479ef68c(15190, ')');
		x6f9bbccfb67dfb8c.xd6b6ed77479ef68c(15200, '│');
		x6f9bbccfb67dfb8c.xd6b6ed77479ef68c(15210, false);
		x6f9bbccfb67dfb8c.xd6b6ed77479ef68c(15220, x6813eed7028d8bfc.xf2957594ee857616);
		x6f9bbccfb67dfb8c.xd6b6ed77479ef68c(15270, x77581da1860d0f9e.x63374d6ffed4adeb);
		x6f9bbccfb67dfb8c.xd6b6ed77479ef68c(15260, 0);
		x6f9bbccfb67dfb8c.xd6b6ed77479ef68c(15230, xb474f98b96852a6e.x58d2ccae3c5cfd08);
		x6f9bbccfb67dfb8c.xd6b6ed77479ef68c(15240, false);
		x6f9bbccfb67dfb8c.xd6b6ed77479ef68c(15250, false);
		x6f9bbccfb67dfb8c.xd6b6ed77479ef68c(15290, xce8b2ce767b2485c.x9bcb07e204e30218);
		x6f9bbccfb67dfb8c.xd6b6ed77479ef68c(15300, x63bdb8b878b040d9.xe360b1885d8d4a41);
		x6f9bbccfb67dfb8c.xd6b6ed77479ef68c(15280, '⏟');
		x6f9bbccfb67dfb8c.xd6b6ed77479ef68c(15310, true);
		x6f9bbccfb67dfb8c.xd6b6ed77479ef68c(15320, false);
		x6f9bbccfb67dfb8c.xd6b6ed77479ef68c(15330, false);
		x6f9bbccfb67dfb8c.xd6b6ed77479ef68c(15450, false);
		x6f9bbccfb67dfb8c.xd6b6ed77479ef68c(15340, false);
		x6f9bbccfb67dfb8c.xd6b6ed77479ef68c(15460, x890a027c82a36a95.xced856c17df679c5);
		x6f9bbccfb67dfb8c.xd6b6ed77479ef68c(15470, false);
		x6f9bbccfb67dfb8c.xd6b6ed77479ef68c(15480, 0);
		x6f9bbccfb67dfb8c.xd6b6ed77479ef68c(15490, x77581da1860d0f9e.x63374d6ffed4adeb);
		x6f9bbccfb67dfb8c.xd6b6ed77479ef68c(15500, 0);
		x6f9bbccfb67dfb8c.xd6b6ed77479ef68c(15510, xf47bac63068c8fd6.x236cb0a4295bc034);
		x6f9bbccfb67dfb8c.xd6b6ed77479ef68c(15520, false);
		x6f9bbccfb67dfb8c.xd6b6ed77479ef68c(15530, false);
		x6f9bbccfb67dfb8c.xd6b6ed77479ef68c(15045, '∫');
		x6f9bbccfb67dfb8c.xd6b6ed77479ef68c(15540, false);
		x6f9bbccfb67dfb8c.xd6b6ed77479ef68c(15550, false);
	}
}
