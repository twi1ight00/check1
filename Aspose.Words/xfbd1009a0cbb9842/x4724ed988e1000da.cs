using Aspose.Words;
using Aspose.Words.Fields;
using x28925c9b27b37a46;

namespace xfbd1009a0cbb9842;

internal class x4724ed988e1000da : Field, x6ed66b5cf8da2955, x40276702cac1d5f7
{
	private x7e263f21a73a027a xed4a7b1500064e12;

	private string xfa6aceda0ccea535;

	private int xaabccab0c06d038b = 1;

	private bool xe0ee52604c6e5ea1;

	private bool xfb5dee37f384f4df;

	public int x504f3d4040b356d7 => xaabccab0c06d038b;

	internal string xe12071fbe3d25fe5 => xfa6aceda0ccea535;

	public bool x5c35225eba240e1a => xe0ee52604c6e5ea1;

	internal override void x20aee281977480cf(FieldStart x10aaa7cdfa38f254, FieldSeparator x3de314ab70bbd9bf, FieldEnd xca09b6c2b5b18485)
	{
		base.x20aee281977480cf(x10aaa7cdfa38f254, x3de314ab70bbd9bf, xca09b6c2b5b18485);
		x1f490eac106aee12();
	}

	private void x1f490eac106aee12()
	{
		x64629b07e6a0cb07 x64629b07e6a0cb8 = base.xb452e2ee706d7a67.xdd7e5aab5232094a(0);
		xfb5dee37f384f4df = x64629b07e6a0cb8 != null && x64629b07e6a0cb8.xd961adf06ad48c3f().Length > 0;
		xed4a7b1500064e12 = base.xb452e2ee706d7a67.xc1a7df85a9e87250(0);
		x2b5580c5440869a0();
	}

	private void x2b5580c5440869a0()
	{
		x38be5b3ac06e8fad x38be5b3ac06e8fad2 = new x38be5b3ac06e8fad();
		x38be5b3ac06e8fad.xb1190ddd5609cee8(base.xb452e2ee706d7a67, x38be5b3ac06e8fad2);
		xfa6aceda0ccea535 = x38be5b3ac06e8fad2.xe12071fbe3d25fe5;
		xaabccab0c06d038b = x38be5b3ac06e8fad2.x504f3d4040b356d7;
		xe0ee52604c6e5ea1 = x38be5b3ac06e8fad2.x271e0fac991fd9dc;
	}

	public Bookmark x7db09d025a6abf05(string xd17ec8f278d25c87)
	{
		if (!xfb5dee37f384f4df || xed4a7b1500064e12.x7149c962c02931b3)
		{
			return null;
		}
		xed4a7b1500064e12.x4973afdae604d531();
		BookmarkStart bookmarkStart = new BookmarkStart(x357c90b33d6bb8e6(), xd17ec8f278d25c87);
		Node x40212106aad8a8b = xed4a7b1500064e12.x12cb12b5d2cad53d.x40212106aad8a8b0;
		x58cb46a7cf40af2b(bookmarkStart, x40212106aad8a8b, xed4a7b1500064e12.x12cb12b5d2cad53d.x375e8189a5358be0);
		BookmarkEnd x40e458b3a58f = new BookmarkEnd(x357c90b33d6bb8e6(), xd17ec8f278d25c87);
		Node x40212106aad8a8b2 = xed4a7b1500064e12.x9fd888e65466818c.x40212106aad8a8b0;
		x58cb46a7cf40af2b(x40e458b3a58f, x40212106aad8a8b2, !xed4a7b1500064e12.x9fd888e65466818c.x83f9d074410e5abf);
		return new Bookmark(bookmarkStart);
	}

	private static void x58cb46a7cf40af2b(Node x40e458b3a58f5782, Node xff5adbb92d63bf52, bool xf83dc4dc442f6cd1)
	{
		if (xf83dc4dc442f6cd1)
		{
			xff5adbb92d63bf52.ParentNode.InsertAfter(x40e458b3a58f5782, xff5adbb92d63bf52);
		}
		else
		{
			xff5adbb92d63bf52.ParentNode.InsertBefore(x40e458b3a58f5782, xff5adbb92d63bf52);
		}
	}

	public void xff2bb2b3436f4d08(DocumentBuilder xd07ce4b74c5774a7)
	{
	}

	private x9f6b815e19fa8f62 x6b9dc5b8ca4335e3(string x724fbd227bfb6eda)
	{
		switch (x724fbd227bfb6eda)
		{
		case "\\n":
			return x9f6b815e19fa8f62.x8416ed4b8ffb3e34;
		case "\\f":
		case "\\l":
			return x9f6b815e19fa8f62.x47e3e032f7bd5d28;
		default:
			return x9f6b815e19fa8f62.xf6c17f648b65c793;
		}
	}

	x9f6b815e19fa8f62 x6ed66b5cf8da2955.x3ecf81e56889c4af(string x724fbd227bfb6eda)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x6b9dc5b8ca4335e3
		return this.x6b9dc5b8ca4335e3(x724fbd227bfb6eda);
	}
}
