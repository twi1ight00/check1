using System;
using System.Collections;
using Aspose.Words;
using Aspose.Words.Fields;
using Aspose.Words.Reporting;
using Aspose.Words.Tables;
using x13f1efc79617a47b;
using x2a6f63b6650e76c4;
using xfbd1009a0cbb9842;

namespace xe86f37adaccef1c3;

internal class xc5c3f438428cb03b : x13d974d3119bccb2, xc0f77867ac6b6a92
{
	private readonly string xc61ff88f1f98652d;

	private readonly ArrayList x519a5291fb5be08c = new ArrayList();

	private Node x212ae880d15d2ed1;

	private Node xb664a8c25c0c85cc;

	private MailMerge x17e7624bcb28c892;

	private xa11a4c48b53f49a6 xb94636afa262d297;

	private bool xb0d569846faaa0de;

	private int xaff733c5c16ee620;

	private bool x3e61945adbb4ad79;

	private readonly Field xba47e1f61097ef1c;

	private readonly Field xb58d31c48521f199;

	private x69699a35aa7dd867 x951c817b79594395;

	private string xb234d1655cddc99e;

	private bool x20453693a7dad459;

	private xa60db17c10eefc60 x22d8cbfe692cedf2;

	private CompositeNode x0b230171259c871d;

	private Node x6b52fe795905cc67;

	private bool x52ef58e804233ad2;

	internal string x759aa16c2016a289 => xc61ff88f1f98652d;

	internal Node x12cb12b5d2cad53d => x212ae880d15d2ed1;

	internal Node x9fd888e65466818c => xb664a8c25c0c85cc;

	internal xc5c3f438428cb03b(Document doc)
	{
		xc61ff88f1f98652d = "";
		x212ae880d15d2ed1 = doc.FirstSection;
		xb664a8c25c0c85cc = doc.LastSection;
		x17e7624bcb28c892 = doc.MailMerge;
		xba47e1f61097ef1c = null;
		xb58d31c48521f199 = null;
	}

	internal xc5c3f438428cb03b(string regionName, Field fieldStart, Field fieldEnd)
	{
		xc61ff88f1f98652d = regionName;
		x17e7624bcb28c892 = fieldStart.x357c90b33d6bb8e6().MailMerge;
		x1dab9c7b4e32730b(fieldStart, fieldEnd);
		xba47e1f61097ef1c = fieldStart;
		xb58d31c48521f199 = fieldEnd;
	}

	internal int xd5da23b762ce52a2(xa11a4c48b53f49a6 xef1769c4fe6ae4ca, bool xc9c7b90943167aed)
	{
		xb94636afa262d297 = xef1769c4fe6ae4ca;
		xb0d569846faaa0de = xc9c7b90943167aed;
		xaff733c5c16ee620 = -1;
		x3e61945adbb4ad79 = false;
		xdeeb682062ef79a5();
		return xaff733c5c16ee620 + 1;
	}

	private void x1dab9c7b4e32730b(Field x045f0bdb9ca4a73c, Field xd464e581982adaf8)
	{
		if (x045f0bdb9ca4a73c.x201282ef5b887ec3 || xd464e581982adaf8.x201282ef5b887ec3)
		{
			return;
		}
		if (x045f0bdb9ca4a73c.Start.xdfa6ecc6f742f086.NodeType != NodeType.Paragraph || xd464e581982adaf8.Start.xdfa6ecc6f742f086.NodeType != NodeType.Paragraph)
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("ecjbfdackdhckdocloedfdmdkcdeedkegcbfbcifjnoficggibnghbehgblhjbcifbjiempiebhjcbojmpekkamkjadlcljlapamkphmnoomgkfniomnoodobokokjbpkoipmnppaogadonahnebmmlbficcemjcemadmhhdcmodemfegmmejldfblkfpkbghgigelpgckghalnhmjeipjlihkcjdjjjpjakejhkmjokeffl", 1524570327)));
		}
		Paragraph paragraph = (Paragraph)x045f0bdb9ca4a73c.Start.xdfa6ecc6f742f086;
		Paragraph paragraph2 = (Paragraph)xd464e581982adaf8.Start.xdfa6ecc6f742f086;
		if (paragraph.xdfa6ecc6f742f086 == paragraph2.xdfa6ecc6f742f086)
		{
			bool x6f8b96bfa12bb = x17e7624bcb28c892.x6f8b96bfa12bb473;
			bool flag = paragraph.LastChild == x045f0bdb9ca4a73c.End;
			x212ae880d15d2ed1 = ((x6f8b96bfa12bb && flag) ? paragraph.NextSibling : paragraph);
			bool flag2 = paragraph2.FirstChild == xd464e581982adaf8.Start;
			xb664a8c25c0c85cc = ((x6f8b96bfa12bb && flag2) ? paragraph2.PreviousSibling : paragraph2);
		}
		else
		{
			if (paragraph.xdfa6ecc6f742f086.NodeType != NodeType.Cell || paragraph2.xdfa6ecc6f742f086.NodeType != NodeType.Cell || paragraph.xdfa6ecc6f742f086.xdfa6ecc6f742f086 != paragraph2.xdfa6ecc6f742f086.xdfa6ecc6f742f086)
			{
				throw new InvalidOperationException(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("glgehmnemmefmmlfnhcghmjgmlahgmhhilohdlfilgmikldjkkkjjkbkikiklkpkhkglgfnlkfemlklmnfcnhkjnoeaoeehokioobjfpldmpkhdaghkaghbblhibfipbjcgcmgncchedchldkgcepfjelfafcchfbbofcefgmemgkedhbfkhhebicdiiafpikdgjienjheekapkkocclidjllcameogmfbompbfnnbmnecdokbkohpapnbipabppjmfajbnalaebpalbcbccgajclppcelgddpnddpeelklebpcfdpjfckagdphgeoogonfhgjmhgodibnkiknbjpmijhipjhngkgmnkbmelpmllbmcmemjmamanlhhnmgonmlfohkmoaldpfkkpnfbaokiaijpagjgbnjnbdjeclelckjcdejjdjjaepdhelioeliffgdmfgidgbhkgkhbhpgihhcphihgicgniagejhgljnfckfbjkffalefhlifolfffmebmm", 1534150249)), xc61ff88f1f98652d));
			}
			Cell xc5464084edc8e = paragraph.xc5464084edc8e226;
			xb664a8c25c0c85cc = (x212ae880d15d2ed1 = xc5464084edc8e.ParentRow);
		}
	}

	private void xcbac07297348428a()
	{
		xde77ad93fc29ec60();
		x0b230171259c871d = x212ae880d15d2ed1.ParentNode;
		if (x0b230171259c871d == null)
		{
			return;
		}
		x6b52fe795905cc67 = x212ae880d15d2ed1;
		Node node;
		do
		{
			node = x6b52fe795905cc67;
			if (node == null)
			{
				throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("lebibgiiffpifggjkfnjmeekhelkffcldejlpdamipgmkdomaefnddmnmocoidkomcbpdohpdcppfcgadcnadcebiblbdcccdbjcjbadimgddbodbbfedamebadfmakfglagfaigfpogoofhnomhpodijokifobjmkij", 1197048054)));
			}
			x6b52fe795905cc67 = node.NextSibling;
			node.Remove();
			x519a5291fb5be08c.Add(node);
		}
		while (node != xb664a8c25c0c85cc);
		x52ef58e804233ad2 = x0b230171259c871d.NodeType == NodeType.Body && x6b52fe795905cc67 == null;
		if (x52ef58e804233ad2)
		{
			x6b52fe795905cc67 = new Paragraph(x0b230171259c871d.x357c90b33d6bb8e6());
			x0b230171259c871d.InsertAfter(x6b52fe795905cc67, x0b230171259c871d.LastChild);
		}
	}

	private void xde77ad93fc29ec60()
	{
		if (xba47e1f61097ef1c != null)
		{
			xc59718c0511825ea(xba47e1f61097ef1c, xba47e1f61097ef1c.Start);
			xc59718c0511825ea(xb58d31c48521f199, xb58d31c48521f199.End);
		}
	}

	private void xc59718c0511825ea(Field x980b46a5b595bce1, FieldChar x4a2f1628ef1d6a1a)
	{
		if (x4a2f1628ef1d6a1a.ParentNode.ParentNode != null)
		{
			Paragraph paragraph = (x17e7624bcb28c892.x6f8b96bfa12bb473 ? (x4a2f1628ef1d6a1a.ParentNode as Paragraph) : null);
			x980b46a5b595bce1.Remove();
			if (paragraph != null && !paragraph.x2aea422a99819d44)
			{
				paragraph.Remove();
			}
		}
	}

	internal void x52b190e626f65140()
	{
		Node node = x212ae880d15d2ed1;
		while (true)
		{
			Node nextSibling = node.NextSibling;
			node.Remove();
			if (node == xb664a8c25c0c85cc)
			{
				break;
			}
			node = nextSibling;
			if (node == null)
			{
				throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("dnpejogfnnnfnoegcolgenchpmjhnnailmhihmoiaifjcmmjimdkllkkehblamilelpllggmlknmnkenlklnlkcoakjolkapljhpbkopaffaljmajjdblikbjibcejicodpcnigdnhndgheefhlehhcfbhjfngagedhg", 522538878)));
			}
		}
		xde77ad93fc29ec60();
	}

	private void xdeeb682062ef79a5()
	{
		bool flag = false;
		xfedf115fd9c03862 xfedf115fd9c = new xfedf115fd9c03862();
		xfedf115fd9c.xb7abe6d71d9b4488(this);
		xfedf115fd9c.xa0ab61ba0ad5683f(this);
		while (xb94636afa262d297.x47f176deff0d42e2())
		{
			if (!flag)
			{
				xcbac07297348428a();
				flag = true;
			}
			xaff733c5c16ee620++;
			xce7dc32b5471a761();
			ArrayList x292b5f49fee = x3fcb591244640aec();
			xd01ea9131ba53b87(x292b5f49fee, xfedf115fd9c);
		}
		xfedf115fd9c.x31985aa8d57a7b7e(this);
		xfedf115fd9c.xbf6830df94a05495(this);
		xfedf115fd9c.x118a2acc122f2bb3();
		if (flag)
		{
			x7a089a9b0c1d09c6();
		}
		else if (x17e7624bcb28c892.x1a980306a733f105)
		{
			x52b190e626f65140();
		}
		x17e7624bcb28c892.x2c8c6741422a1298.xe4f03767b6c9b92b();
	}

	private void xd01ea9131ba53b87(ArrayList x292b5f49fee42032, xfedf115fd9c03862 xcc5022025f73a533)
	{
		x951c817b79594395 = new x69699a35aa7dd867(createRegions: true);
		x6435b7bbb0879a04 xa942970cc8a85fd = xe25d778fe9f1252a.x105bab38d511372f(x292b5f49fee42032, x0d900d42b3598fde: false);
		xcc5022025f73a533.xdf269951086089ce(xa942970cc8a85fd);
	}

	private void xce7dc32b5471a761()
	{
		if (x22d8cbfe692cedf2 != null)
		{
			x22d8cbfe692cedf2.xb92b9f52422fe898();
		}
	}

	private void x714821359c2a8f33()
	{
		if (!xb0d569846faaa0de)
		{
			return;
		}
		x951c817b79594395.xe641355482f2e5c9();
		foreach (xc5c3f438428cb03b item in x951c817b79594395.xf7e212954bf72f68)
		{
			xa11a4c48b53f49a6 xa11a4c48b53f49a7 = xb94636afa262d297.x438eef0af7e648c2(item.x759aa16c2016a289);
			if (xa11a4c48b53f49a7 != null)
			{
				item.xd5da23b762ce52a2(xa11a4c48b53f49a7, xc9c7b90943167aed: true);
			}
		}
	}

	private Field x53da3f408445046e(Field xe01ae93d9fe5a880)
	{
		if (x17e7624bcb28c892.UseNonMergeFields && xe01ae93d9fe5a880 is x5da40b5371fb63c5)
		{
			x5da40b5371fb63c5 x5da40b5371fb63c = (x5da40b5371fb63c5)xe01ae93d9fe5a880;
			if (!x5da40b5371fb63c.x0d1a19db852a73bf())
			{
				return null;
			}
			return x561fa53c007d3597.x19b147e6909d4320(x5da40b5371fb63c);
		}
		return null;
	}

	internal bool xb7e46440d2a34d6d(x561fa53c007d3597 xe01ae93d9fe5a880, out FieldMergingArgs xfbf34718e704c6bc)
	{
		xb234d1655cddc99e = x17e7624bcb28c892.x8b00baeb99adecc8(xe01ae93d9fe5a880.xae9d2e3eea32978f);
		xb234d1655cddc99e = x05c34083e53cd5bc(xb234d1655cddc99e);
		x20453693a7dad459 = xb94636afa262d297.x3f88a25febd23896(xb234d1655cddc99e, out var x5fc53c4ffd3eb8c);
		xfbf34718e704c6bc = new FieldMergingArgs(x17e7624bcb28c892.x2c8c6741422a1298, xb94636afa262d297.x0e167222a6700ac9, xaff733c5c16ee620, xe01ae93d9fe5a880, xb234d1655cddc99e, xe01ae93d9fe5a880.xae9d2e3eea32978f, x5fc53c4ffd3eb8c);
		x17e7624bcb28c892.x338aa1b17bb2a0c8(xfbf34718e704c6bc);
		return x20453693a7dad459;
	}

	internal bool xbab965d1b5a8be25(x561fa53c007d3597 xe01ae93d9fe5a880, out ImageFieldMergingArgs xfbf34718e704c6bc)
	{
		string x66ac3558868cc = x17e7624bcb28c892.x8b00baeb99adecc8(xe01ae93d9fe5a880.xae9d2e3eea32978f);
		x66ac3558868cc = x05c34083e53cd5bc(x66ac3558868cc);
		object x5fc53c4ffd3eb8c;
		bool result = xb94636afa262d297.x3f88a25febd23896(x66ac3558868cc, out x5fc53c4ffd3eb8c);
		xfbf34718e704c6bc = new ImageFieldMergingArgs(x17e7624bcb28c892.x2c8c6741422a1298, xb94636afa262d297.x0e167222a6700ac9, xaff733c5c16ee620, xe01ae93d9fe5a880, x66ac3558868cc, xe01ae93d9fe5a880.xae9d2e3eea32978f, x5fc53c4ffd3eb8c, xe01ae93d9fe5a880.x9e7ae1da8539c294(), xe01ae93d9fe5a880.x1bb8c0117ad009d3());
		x17e7624bcb28c892.x8ac49bb85e2a468f(xfbf34718e704c6bc);
		return result;
	}

	private string x05c34083e53cd5bc(string x66ac3558868cc255)
	{
		if (!x17e7624bcb28c892.UseNonMergeFields)
		{
			return x66ac3558868cc255;
		}
		if (x69c36a228a9b3b39.xe19ff57f82f3515e(xb94636afa262d297))
		{
			return x66ac3558868cc255;
		}
		return x69c36a228a9b3b39.x7a72474f72a62daf(x66ac3558868cc255, x69c36a228a9b3b39.x9d4069700729134e(x66ac3558868cc255));
	}

	internal int xe3cf0bedd5b81485()
	{
		if (!xb94636afa262d297.x0180a8f719ebb034)
		{
			return -1;
		}
		if (x22d8cbfe692cedf2 == null)
		{
			x22d8cbfe692cedf2 = new xa60db17c10eefc60(x17e7624bcb28c892, xb94636afa262d297);
		}
		return x22d8cbfe692cedf2.xef7b3bfee793d3d9(xb234d1655cddc99e, x20453693a7dad459);
	}

	private void xa02248be84004d11()
	{
		if (xb94636afa262d297.x47f176deff0d42e2())
		{
			xaff733c5c16ee620++;
			xce7dc32b5471a761();
		}
		else
		{
			x3e61945adbb4ad79 = true;
		}
	}

	private ArrayList x3fcb591244640aec()
	{
		ArrayList arrayList = new ArrayList();
		foreach (Node item in x519a5291fb5be08c)
		{
			Node node2 = item.x8b61531c8ea35b85(x7a5f12b98e34a590: true, x17e7624bcb28c892.x422d34b3419d8be0);
			if (x6b52fe795905cc67 != null)
			{
				x0b230171259c871d.InsertBefore(node2, x6b52fe795905cc67);
			}
			else
			{
				x0b230171259c871d.InsertAfter(node2, x0b230171259c871d.LastChild);
			}
			arrayList.Add(node2);
		}
		return arrayList;
	}

	private void x7a089a9b0c1d09c6()
	{
		if (x52ef58e804233ad2)
		{
			x6b52fe795905cc67.Remove();
			((Body)x0b230171259c871d).EnsureMinimum();
		}
	}

	private bool xd6537b28bd8ef500(Field xe01ae93d9fe5a880)
	{
		if (xe01ae93d9fe5a880.x201282ef5b887ec3)
		{
			return true;
		}
		if (x951c817b79594395.x1f14e048f5f7a72a)
		{
			return true;
		}
		if (xe01ae93d9fe5a880.Type == FieldType.FieldMergeField)
		{
			x561fa53c007d3597 x561fa53c007d = (x561fa53c007d3597)xe01ae93d9fe5a880;
			if (x561fa53c007d.x6f452516cc92f528 || x561fa53c007d.x5aafe4417767ef58)
			{
				return true;
			}
		}
		return false;
	}

	private void xda40b7e8515a7a3d(xcf417e2db4fe9ed3 xe00c282e1a49fcfb)
	{
		if (xe00c282e1a49fcfb == xcf417e2db4fe9ed3.xa4eb7166eb7f09b4)
		{
			x714821359c2a8f33();
		}
	}

	void x13d974d3119bccb2.x9d0488f6bfd3c0b3(xcf417e2db4fe9ed3 xe00c282e1a49fcfb)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xda40b7e8515a7a3d
		this.xda40b7e8515a7a3d(xe00c282e1a49fcfb);
	}

	private x7685e6f393e64c44 x2589f56ae3056d08(Field xe01ae93d9fe5a880, bool x39b88a192280e4dd)
	{
		if (x951c817b79594395.x3dba3735b42cd449(xe01ae93d9fe5a880) && x39b88a192280e4dd)
		{
			return new x7685e6f393e64c44(xe01ae93d9fe5a880, x261cafdff9716109.x1a2ddf6ed77d277c);
		}
		if (xd6537b28bd8ef500(xe01ae93d9fe5a880))
		{
			return new x7685e6f393e64c44(xe01ae93d9fe5a880, x261cafdff9716109.xcc32d73386110a60);
		}
		Field field = x53da3f408445046e(xe01ae93d9fe5a880);
		if (field != null)
		{
			return new x7685e6f393e64c44(field, x261cafdff9716109.x295cb4a1df7a5add);
		}
		return new x7685e6f393e64c44(xe01ae93d9fe5a880, x261cafdff9716109.x295cb4a1df7a5add);
	}

	x7685e6f393e64c44 x13d974d3119bccb2.xc18d99c2ffb751c0(Field xe01ae93d9fe5a880, bool x39b88a192280e4dd)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x2589f56ae3056d08
		return this.x2589f56ae3056d08(xe01ae93d9fe5a880, x39b88a192280e4dd);
	}

	private x82e26649b09596bd x01e8e6d18b9b4573(Field xe01ae93d9fe5a880)
	{
		if (x3e61945adbb4ad79)
		{
			return null;
		}
		switch (xe01ae93d9fe5a880.Type)
		{
		case FieldType.FieldNext:
			xa02248be84004d11();
			return new x414971650f35e163();
		case FieldType.FieldNextIf:
		{
			xafecb8edcd253997 xafecb8edcd = (xafecb8edcd253997)xe01ae93d9fe5a880;
			x82e26649b09596bd x82e26649b09596bd = xafecb8edcd.x2e61ff4c17b83d74();
			if (!x82e26649b09596bd.x6b54bdfbc4586f55 && x82e26649b09596bd.x3a56e581f7d70f0a)
			{
				xa02248be84004d11();
			}
			return x82e26649b09596bd;
		}
		case FieldType.FieldMergeRec:
		case FieldType.FieldMergeSeq:
			return new x35d8d79b119cae44(xaff733c5c16ee620 + 1);
		default:
			return null;
		}
	}

	x82e26649b09596bd xc0f77867ac6b6a92.x3f88a25febd23896(Field xe01ae93d9fe5a880)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x01e8e6d18b9b4573
		return this.x01e8e6d18b9b4573(xe01ae93d9fe5a880);
	}

	private object xa1e1d850069940af(Field xe01ae93d9fe5a880)
	{
		if (x3e61945adbb4ad79)
		{
			return null;
		}
		if (xe01ae93d9fe5a880 is x561fa53c007d3597)
		{
			return this;
		}
		switch (xe01ae93d9fe5a880.Type)
		{
		case FieldType.FieldAddressBlock:
		case FieldType.FieldGreetingLine:
			return xb94636afa262d297;
		default:
			return null;
		}
	}

	object xc0f77867ac6b6a92.xd378208b5267f7e2(Field xe01ae93d9fe5a880)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xa1e1d850069940af
		return this.xa1e1d850069940af(xe01ae93d9fe5a880);
	}
}
