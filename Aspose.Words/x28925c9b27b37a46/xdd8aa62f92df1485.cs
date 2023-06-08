using System;
using System.Collections;
using Aspose.Words;
using Aspose.Words.Tables;
using x13f1efc79617a47b;
using x9db5f2e5af3d596e;

namespace x28925c9b27b37a46;

internal class xdd8aa62f92df1485
{
	private xdd8aa62f92df1485()
	{
	}

	internal static void xbbf84cd4316306d6(Node xda5bf54deb817e37, bool x510619ea70954ab6, ArrayList x51e539cc77490bdc)
	{
		if (xda5bf54deb817e37 is xcf3b0f04424de818)
		{
			x1fa50dc1a5d45584(xda5bf54deb817e37, x510619ea70954ab6, x51e539cc77490bdc);
		}
		else if (xda5bf54deb817e37 is Paragraph)
		{
			x406f343fb41e50a7(xda5bf54deb817e37, x510619ea70954ab6, x51e539cc77490bdc);
		}
		else if (xda5bf54deb817e37 is Section)
		{
			x2e034f4032cbeef2(xda5bf54deb817e37, x510619ea70954ab6);
		}
		else if (xda5bf54deb817e37 is Row)
		{
			x07f0e18ba03af85b(xda5bf54deb817e37, x510619ea70954ab6);
		}
		else if (xda5bf54deb817e37 is Cell)
		{
			x2412690961ab335e(xda5bf54deb817e37, x510619ea70954ab6);
		}
	}

	internal static void x698d7efb49fcb65f(ArrayList x9674563da4f0d0a4, ArrayList xefe46aafcb6c3873)
	{
		xb14ae4c3ad30aa36(x9674563da4f0d0a4);
		x3e8ec97c00cb1dc5(xefe46aafcb6c3873);
	}

	internal static x7f77ea92be0d9042 x67e96301bb4dca85(Node xda5bf54deb817e37)
	{
		if (xda5bf54deb817e37 is xcf3b0f04424de818)
		{
			xcf3b0f04424de818 xcf3b0f04424de819 = (xcf3b0f04424de818)xda5bf54deb817e37;
			return xcf3b0f04424de819.xc87649c48f7756d2;
		}
		if (xda5bf54deb817e37 is Paragraph)
		{
			Paragraph paragraph = (Paragraph)xda5bf54deb817e37;
			return paragraph.x1a78664fa10a3755;
		}
		if (xda5bf54deb817e37 is Section)
		{
			Section section = (Section)xda5bf54deb817e37;
			return section.xfc72d4c9b765cad7;
		}
		if (xda5bf54deb817e37 is Row)
		{
			Row row = (Row)xda5bf54deb817e37;
			return row.xedb0eb766e25e0c9;
		}
		if (xda5bf54deb817e37 is Cell)
		{
			Cell cell = (Cell)xda5bf54deb817e37;
			return cell.xf8cef531dae89ea3;
		}
		return null;
	}

	private static void x2412690961ab335e(Node xda5bf54deb817e37, bool x510619ea70954ab6)
	{
		xf8cef531dae89ea3 xf8cef531dae89ea = ((Cell)xda5bf54deb817e37).xf8cef531dae89ea3;
		if (x510619ea70954ab6)
		{
			xf8cef531dae89ea.xcb395027497bc067();
		}
		else
		{
			xf8cef531dae89ea.x097e4f3c708bd29c();
		}
	}

	private static void x2e034f4032cbeef2(Node xda5bf54deb817e37, bool x510619ea70954ab6)
	{
		xfc72d4c9b765cad7 xfc72d4c9b765cad8 = ((Section)xda5bf54deb817e37).xfc72d4c9b765cad7;
		if (x510619ea70954ab6)
		{
			xfc72d4c9b765cad8.xcb395027497bc067();
		}
		else
		{
			xfc72d4c9b765cad8.x097e4f3c708bd29c();
		}
	}

	private static void x406f343fb41e50a7(Node xda5bf54deb817e37, bool x510619ea70954ab6, ArrayList x51e539cc77490bdc)
	{
		Paragraph x41baca1d6c0c2e8e = (Paragraph)xda5bf54deb817e37;
		if (x510619ea70954ab6)
		{
			x4673295665993d49(x41baca1d6c0c2e8e, x51e539cc77490bdc);
		}
		else
		{
			x33276d26fa8589c4(x41baca1d6c0c2e8e, x51e539cc77490bdc);
		}
	}

	private static void x1fa50dc1a5d45584(Node xda5bf54deb817e37, bool x510619ea70954ab6, ArrayList x51e539cc77490bdc)
	{
		xcf3b0f04424de818 x31545d7c306a55e = (xcf3b0f04424de818)xda5bf54deb817e37;
		if (x510619ea70954ab6)
		{
			x2b7f32b63353f6ea(x31545d7c306a55e, x51e539cc77490bdc, Run.xe190c8f083575592(xda5bf54deb817e37.GetText()));
		}
		else
		{
			x7d81eeefc50c7c0b(x31545d7c306a55e, x51e539cc77490bdc);
		}
	}

	private static void x07f0e18ba03af85b(Node xda5bf54deb817e37, bool x510619ea70954ab6)
	{
		Row row = (Row)xda5bf54deb817e37;
		xedb0eb766e25e0c9 xedb0eb766e25e0c = row.xedb0eb766e25e0c9;
		if (x510619ea70954ab6)
		{
			xedb0eb766e25e0c.xcb395027497bc067();
			xedb0eb766e25e0c.x52b190e626f65140(14);
		}
		else
		{
			xedb0eb766e25e0c.x097e4f3c708bd29c();
			xedb0eb766e25e0c.x52b190e626f65140(12);
		}
		foreach (Cell item in row)
		{
			xf8cef531dae89ea3 xf8cef531dae89ea = item.xf8cef531dae89ea3;
			if (x8ae1842c1e07f340(xf8cef531dae89ea))
			{
				xf8cef531dae89ea.x52b190e626f65140(10010);
			}
		}
	}

	private static bool x8ae1842c1e07f340(xf8cef531dae89ea3 x51dd02ffcbaa972d)
	{
		if (!x51dd02ffcbaa972d.x0f53f53f15b61ef5)
		{
			return x51dd02ffcbaa972d.x5fb16e270c21db2e != null;
		}
		return false;
	}

	private static void x4673295665993d49(Paragraph x41baca1d6c0c2e8e, ArrayList x51e539cc77490bdc)
	{
		x41baca1d6c0c2e8e.x1a78664fa10a3755.xcb395027497bc067();
		x41baca1d6c0c2e8e.x1a78664fa10a3755.x52b190e626f65140(1125);
		x41baca1d6c0c2e8e.x344511c4e4ce09da.xcb395027497bc067();
		x41baca1d6c0c2e8e.x344511c4e4ce09da.x52b190e626f65140(14);
		if (x41baca1d6c0c2e8e.x344511c4e4ce09da.x0392c0938d22c790)
		{
			if (x51e539cc77490bdc != null)
			{
				x51e539cc77490bdc.Add(x41baca1d6c0c2e8e);
			}
			else
			{
				x212a360274515023(x41baca1d6c0c2e8e);
			}
		}
	}

	private static void x33276d26fa8589c4(Paragraph x41baca1d6c0c2e8e, ArrayList x51e539cc77490bdc)
	{
		x41baca1d6c0c2e8e.x1a78664fa10a3755.x097e4f3c708bd29c();
		x41baca1d6c0c2e8e.x1a78664fa10a3755.x52b190e626f65140(1125);
		x41baca1d6c0c2e8e.x344511c4e4ce09da.x097e4f3c708bd29c();
		x41baca1d6c0c2e8e.x344511c4e4ce09da.x52b190e626f65140(12);
		if (x41baca1d6c0c2e8e.x344511c4e4ce09da.xba4e1d8a3e3316c8)
		{
			if (x51e539cc77490bdc != null)
			{
				x51e539cc77490bdc.Add(x41baca1d6c0c2e8e);
			}
			else
			{
				x212a360274515023(x41baca1d6c0c2e8e);
			}
		}
	}

	private static void x2b7f32b63353f6ea(xcf3b0f04424de818 x31545d7c306a55e4, ArrayList x51e539cc77490bdc, bool x5c176b21f7df818b)
	{
		xeedad81aaed42a76 xc87649c48f7756d = x31545d7c306a55e4.xc87649c48f7756d2;
		xc87649c48f7756d.x58506bf670336fcf(x5c176b21f7df818b);
		xc87649c48f7756d.x52b190e626f65140(14);
		if (xc87649c48f7756d.x0392c0938d22c790)
		{
			if (x51e539cc77490bdc != null)
			{
				x51e539cc77490bdc.Add(x31545d7c306a55e4);
			}
			else
			{
				x9179d81e3c0aaeb2((Node)x31545d7c306a55e4);
			}
		}
	}

	private static void x7d81eeefc50c7c0b(xcf3b0f04424de818 x31545d7c306a55e4, ArrayList x51e539cc77490bdc)
	{
		xeedad81aaed42a76 xc87649c48f7756d = x31545d7c306a55e4.xc87649c48f7756d2;
		xc87649c48f7756d.x097e4f3c708bd29c();
		xc87649c48f7756d.x52b190e626f65140(12);
		if (xc87649c48f7756d.xba4e1d8a3e3316c8)
		{
			if (x51e539cc77490bdc != null)
			{
				x51e539cc77490bdc.Add(x31545d7c306a55e4);
			}
			else
			{
				x9179d81e3c0aaeb2((Node)x31545d7c306a55e4);
			}
		}
	}

	private static void xb14ae4c3ad30aa36(ArrayList xc9d04899b7c0e1a0)
	{
		for (int i = 0; i < xc9d04899b7c0e1a0.Count; i++)
		{
			x9179d81e3c0aaeb2((Node)xc9d04899b7c0e1a0[i]);
		}
		xc9d04899b7c0e1a0.Clear();
	}

	private static void x3e8ec97c00cb1dc5(ArrayList x9d76a1b0d10fb96e)
	{
		for (int i = 0; i < x9d76a1b0d10fb96e.Count; i++)
		{
			x212a360274515023((Paragraph)x9d76a1b0d10fb96e[i]);
		}
		x9d76a1b0d10fb96e.Clear();
	}

	private static void x9179d81e3c0aaeb2(Node x31545d7c306a55e4)
	{
		CompositeNode parentNode = x31545d7c306a55e4.ParentNode;
		x31545d7c306a55e4.Remove();
		if (parentNode.NodeType == NodeType.SmartTag && !parentNode.x843b0ab4e04a29f2)
		{
			parentNode.Remove();
		}
	}

	private static void x212a360274515023(Paragraph x41baca1d6c0c2e8e)
	{
		if (x41baca1d6c0c2e8e.IsEndOfCell)
		{
			xbb24cd42d5d4e252(x41baca1d6c0c2e8e);
		}
		else if (x41baca1d6c0c2e8e.IsEndOfSection)
		{
			x9a015836f817455f(x41baca1d6c0c2e8e);
		}
		else
		{
			x0140d16fa1b95991(x41baca1d6c0c2e8e);
		}
	}

	private static void xbb24cd42d5d4e252(Paragraph x41baca1d6c0c2e8e)
	{
		Cell xc5464084edc8e = x41baca1d6c0c2e8e.xc5464084edc8e226;
		Row parentRow = xc5464084edc8e.ParentRow;
		Table parentTable = parentRow.ParentTable;
		xc5464084edc8e.Remove();
		if (parentRow.FirstCell == null)
		{
			parentRow.Remove();
		}
		if (parentTable.FirstRow == null)
		{
			parentTable.Remove();
		}
	}

	private static void x9a015836f817455f(Paragraph x41baca1d6c0c2e8e)
	{
		Body body = (Body)x41baca1d6c0c2e8e.xdfa6ecc6f742f086;
		Section parentSection = body.ParentSection;
		Section section = (Section)parentSection.NextSibling;
		if (section == null)
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("anjoeoapephpnoopgjfagomafndbankbonbcanicdnpcpmgdohndemeelmlefhcfamjfemagilhgflogehfh", 667150722)));
		}
		Body body2 = section.Body;
		Paragraph firstParagraph = body2.FirstParagraph;
		if (x41baca1d6c0c2e8e.HasChildNodes)
		{
			firstParagraph.x2729186e1a0b4aeb(x41baca1d6c0c2e8e.FirstChild, null, null);
		}
		body2.x2729186e1a0b4aeb(body.FirstChild, x41baca1d6c0c2e8e, null);
		parentSection.Remove();
	}

	private static void x0140d16fa1b95991(Paragraph x41baca1d6c0c2e8e)
	{
		Node xa6890a1cb2b8896e = x41baca1d6c0c2e8e.xa6890a1cb2b8896e;
		if (xa6890a1cb2b8896e is Paragraph && x41baca1d6c0c2e8e.HasChildNodes)
		{
			((Paragraph)xa6890a1cb2b8896e).x2729186e1a0b4aeb(x41baca1d6c0c2e8e.FirstChild, null, null);
		}
		x41baca1d6c0c2e8e.Remove();
	}
}
