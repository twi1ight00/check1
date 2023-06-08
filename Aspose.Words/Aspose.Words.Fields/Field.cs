using System;
using System.Collections;
using x13f1efc79617a47b;
using x28925c9b27b37a46;
using x2a6f63b6650e76c4;
using x4adf554d20d941a6;
using x6c95d9cf46ff5f25;
using xb1090543d168d647;
using xda075892eccab2ad;
using xf9a9481c3f63a419;
using xfbd1009a0cbb9842;

namespace Aspose.Words.Fields;

public class Field
{
	private x928b31adb20d5cc6 x4490d25db4164ab6;

	private x985dd08fd338eeea xef8b23deb509f187;

	private x25abb95a730411e4 xe46a7a8c510f8bd1;

	private x5e36356bc92c609b x02a9efce5fdffaef;

	private x1b286cd42deb2210 x4e3db8304327e38e;

	private ArrayList x88485bf5e43cb3fd;

	protected bool IsInHeaderFooter => Start.GetAncestor(NodeType.HeaderFooter) != null;

	public FieldStart Start => x4490d25db4164ab6.x12cb12b5d2cad53d;

	public FieldSeparator Separator => x4490d25db4164ab6.x43604484a3deae4f;

	public FieldEnd End => x4490d25db4164ab6.x9fd888e65466818c;

	public FieldType Type => Start.FieldType;

	public string Result
	{
		get
		{
			if (!xc077cfa8d6f9e3c5)
			{
				return string.Empty;
			}
			return x9f265cdf86e37e15.x633d57e35b6715a4(Separator, x579197826ce035a3: false, End, x230d76aa903b832a: false);
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "value");
			x5f4c2139149eaf99(x5113d1e6ef8a0405: false);
			if (x5c29822913be33c1.xdd6a5784f801bb64(this))
			{
				xf9d8551009fb4b3d();
			}
			xe3b2513ab4d5789d xe3b2513ab4d5789d = new xe3b2513ab4d5789d(this, value);
			xe3b2513ab4d5789d.x7d44c41f397d72e0();
			x6c680c465f828abb();
		}
	}

	public bool IsLocked
	{
		get
		{
			return Start.IsLocked;
		}
		set
		{
			Start.IsLocked = value;
		}
	}

	internal FieldChar xb29355c4bafca5da => x4490d25db4164ab6.xb29355c4bafca5da;

	internal x985dd08fd338eeea xb452e2ee706d7a67
	{
		get
		{
			if (xef8b23deb509f187 == null)
			{
				xc8f5f9bd30e5d3f3();
			}
			return xef8b23deb509f187;
		}
	}

	internal x25abb95a730411e4 xa890d2fd18bed2bc
	{
		get
		{
			if (xe46a7a8c510f8bd1 == null)
			{
				xe46a7a8c510f8bd1 = new x25abb95a730411e4(this);
			}
			return xe46a7a8c510f8bd1;
		}
	}

	internal bool xc077cfa8d6f9e3c5 => Separator != null;

	internal bool x201282ef5b887ec3 => Start.ParentNode == null;

	internal xfedf115fd9c03862 x34a4695711b84f85 => x02a9efce5fdffaef.x34a4695711b84f85;

	internal x5e36356bc92c609b x6edce55dcd2d335b => x02a9efce5fdffaef;

	internal bool x21f09c4bcee72280 => x02a9efce5fdffaef != null;

	internal DocumentBase x2c8c6741422a1298 => Start.Document;

	internal x1b286cd42deb2210 x27968a06d5b19214 => x4e3db8304327e38e;

	internal IEnumerable x1a58ab8aeb0cc722 => x88485bf5e43cb3fd;

	internal Field()
	{
	}

	internal virtual void x20aee281977480cf(FieldStart x10aaa7cdfa38f254, FieldSeparator x3de314ab70bbd9bf, FieldEnd xca09b6c2b5b18485)
	{
		x4490d25db4164ab6 = new x928b31adb20d5cc6(x10aaa7cdfa38f254, x3de314ab70bbd9bf, xca09b6c2b5b18485);
	}

	internal virtual void xc8f5f9bd30e5d3f3()
	{
		xef8b23deb509f187 = new x985dd08fd338eeea(this);
	}

	public string GetFieldCode()
	{
		return x4490d25db4164ab6.x071b5fbe719eaec7();
	}

	internal void x462912a00c2a2b88(string x0e59413709b18038)
	{
		x52b190e626f65140(x7d5e2f34b6651bf4.xb0b4ff1622a01d12);
		DocumentBuilder documentBuilder = new DocumentBuilder(x357c90b33d6bb8e6());
		documentBuilder.MoveTo(xb29355c4bafca5da);
		documentBuilder.Write(x0e59413709b18038);
	}

	public void Remove()
	{
		x5699f8523a546a42.x52b190e626f65140(Start, End);
	}

	internal void x77764e51cb2070f9(x57af31d8c74e631c xab8fe3cd8c5556fb)
	{
		if (!x02a9efce5fdffaef.x752cfab9af626fd5)
		{
			xab8fe3cd8c5556fb.xb333e1e6c01c2be2(this);
		}
		else if (xab8fe3cd8c5556fb.xe6148f06a6efc950)
		{
			x5e36356bc92c609b x5e36356bc92c609b = x02a9efce5fdffaef.xfb9ab092513c65d9();
			x5e36356bc92c609b.x9a64fac49f4da132(xab8fe3cd8c5556fb);
		}
		else
		{
			x02a9efce5fdffaef.x9a64fac49f4da132(xab8fe3cd8c5556fb);
		}
	}

	internal void x8d30e5d567e20f37()
	{
		if (x201282ef5b887ec3)
		{
			return;
		}
		if (xc077cfa8d6f9e3c5)
		{
			string result = Result;
			bool flag = result.Length == 0 || x0d299f323d241756.x6df149467337111e(result);
			if (x02a9efce5fdffaef.x752cfab9af626fd5 && !x02a9efce5fdffaef.x06768d79f7751c4d && flag)
			{
				Separator.ParentNode.InsertAfter(x6892678ea842dad3(Separator, Separator.NextSibling), Separator);
				End.ParentNode.InsertBefore(x6892678ea842dad3(End, End.PreviousSibling), End);
			}
			x5699f8523a546a42.x52b190e626f65140(Start, Separator);
			End.Remove();
		}
		else
		{
			Remove();
		}
	}

	private Run x6892678ea842dad3(Inline x2223f7db33837fbd, Node x9885ca17c1b6bfb1)
	{
		return new Run(x2c8c6741422a1298, "\"", xe2a98c71583bd909(x2223f7db33837fbd, x9885ca17c1b6bfb1));
	}

	private static xeedad81aaed42a76 xe2a98c71583bd909(Inline x2223f7db33837fbd, Node x9885ca17c1b6bfb1)
	{
		if (x9885ca17c1b6bfb1 is Inline)
		{
			return (xeedad81aaed42a76)((Inline)x9885ca17c1b6bfb1).xeedad81aaed42a76.x8b61531c8ea35b85();
		}
		return (xeedad81aaed42a76)x2223f7db33837fbd.xeedad81aaed42a76.x8b61531c8ea35b85();
	}

	internal void x52b190e626f65140(x7d5e2f34b6651bf4 xdd2e02377d7065ba)
	{
		switch (xdd2e02377d7065ba)
		{
		case x7d5e2f34b6651bf4.xb0b4ff1622a01d12:
			x5699f8523a546a42.x52b190e626f65140(Start, x4ec19a117bbb0963: false, xb29355c4bafca5da, xead571f03cb4ee1d: false);
			break;
		case x7d5e2f34b6651bf4.xf8d31d196ccd74c4:
			if (xc077cfa8d6f9e3c5)
			{
				x5699f8523a546a42.x52b190e626f65140(Separator, x4ec19a117bbb0963: false, End, xead571f03cb4ee1d: false);
			}
			break;
		default:
			throw new InvalidOperationException();
		}
	}

	internal bool x263d579af1d0d43f(Node xcdead1089042c2a4)
	{
		if (xcdead1089042c2a4 == null)
		{
			throw new ArgumentNullException("nodeToFind");
		}
		Node node = Start;
		Node nextSibling = End.NextSibling;
		while (node != null && node != nextSibling)
		{
			if (node == xcdead1089042c2a4)
			{
				return true;
			}
			node = node.NextSibling;
		}
		return xcdead1089042c2a4 == End;
	}

	public void Update()
	{
		x5e36356bc92c609b x5e36356bc92c609b = new x5e36356bc92c609b(this);
		x5e36356bc92c609b.x34a4695711b84f85.x384c03e4298b53bf();
	}

	internal x98c1867b219333bc x295cb4a1df7a5add(x5e36356bc92c609b x0f7b23d1c393aed9)
	{
		if (IsLocked)
		{
			return new x98c1867b219333bc(isUpdated: false);
		}
		string text = null;
		string text2 = null;
		bool flag = xe9859780b00e6530();
		if (!flag)
		{
			int x609daf39d = xb452e2ee706d7a67.x609daf39d0822544;
			text = xf2a0216b53787578.xd16e1d14e9bd81a9(x609daf39d, x5fbb1a9c98604ef5: true);
			text2 = xed747ca236d86aa0.xe8201cb97474aaaf();
			flag = x609daf39d == 1024 || text == text2;
		}
		if (flag)
		{
			return x42a25ae95099edb8(x0f7b23d1c393aed9);
		}
		try
		{
			xed747ca236d86aa0.xcb651329dbd67ff0(text);
			return x42a25ae95099edb8(x0f7b23d1c393aed9);
		}
		finally
		{
			xed747ca236d86aa0.xcb651329dbd67ff0(text2);
		}
	}

	private bool xe9859780b00e6530()
	{
		if (x357c90b33d6bb8e6().FieldOptions.FieldUpdateCultureSource == FieldUpdateCultureSource.CurrentThread)
		{
			return true;
		}
		if (xb452e2ee706d7a67 == null)
		{
			return true;
		}
		if (!xb452e2ee706d7a67.xcc2d426b867d703d("\\@") && !x5c29822913be33c1.xa3cf2f66fe7bf817(Type))
		{
			return true;
		}
		return false;
	}

	private x98c1867b219333bc x42a25ae95099edb8(x5e36356bc92c609b x0f7b23d1c393aed9)
	{
		if (x5c29822913be33c1.xd668adf9377c05ee(Type) == x5576a2206c3fc746.xf99e3386924fbeb6 && !xc077cfa8d6f9e3c5 && !(this is x561fa53c007d3597))
		{
			return new x98c1867b219333bc(isUpdated: false);
		}
		xcf417e2db4fe9ed3 xcf417e2db4fe9ed = xcf417e2db4fe9ed3.x35cfcea4890f4e7d;
		if (x58daf9beaf8b1ae0() && IsInHeaderFooter && !x0f7b23d1c393aed9.x933af3effe3af4af)
		{
			x0f7b23d1c393aed9.x34a4695711b84f85.x874035a07982e6e7(new x2de8d443b21560d5(x357c90b33d6bb8e6()), xcf417e2db4fe9ed3.x290a7f421b080483);
			if (!x9c3cf3451811c728())
			{
				return new x98c1867b219333bc(isUpdated: false);
			}
		}
		else
		{
			xcf417e2db4fe9ed = x0f7b23d1c393aed9.xcf4268d5a79e653b();
			if (xcf417e2db4fe9ed != 0 && !x9c3cf3451811c728())
			{
				return new x98c1867b219333bc(xcf417e2db4fe9ed, isUpdated: false);
			}
		}
		x02a9efce5fdffaef = x0f7b23d1c393aed9;
		x5dc2b4bc740c9563 x5dc2b4bc740c = null;
		if (!x7ff30deb4e281744())
		{
			x0ad87ca7d276f896();
			xc8f5f9bd30e5d3f3();
			if (x02a9efce5fdffaef.x45bd6960cee454bd())
			{
				xc8f5f9bd30e5d3f3();
			}
			if (xef8b23deb509f187.x2dd813bbd92bbe25 == null)
			{
				if (x5c29822913be33c1.xdd6a5784f801bb64(this))
				{
					xf9d8551009fb4b3d();
				}
				x5dc2b4bc740c = x83bcdf1790545fdb();
			}
			else
			{
				x5dc2b4bc740c = new xd5801a931e010963(this, xef8b23deb509f187.x2dd813bbd92bbe25);
			}
			if (x5dc2b4bc740c != null)
			{
				x5dc2b4bc740c.xb333e1e6c01c2be2();
				x6c680c465f828abb();
				x02a9efce5fdffaef.xcd5c6b74a5207c7d();
				if (x5c29822913be33c1.x65acaa0a43cc4d6c(this))
				{
					x9cb2542bafed44b0(x7d5e2f34b6651bf4.xf8d31d196ccd74c4);
				}
			}
			else
			{
				x6c680c465f828abb();
				x9cb2542bafed44b0(x7d5e2f34b6651bf4.xf8d31d196ccd74c4);
			}
		}
		if (!x02a9efce5fdffaef.x752cfab9af626fd5)
		{
			if (x02a9efce5fdffaef.x004daeac26db37fe != null)
			{
				x02a9efce5fdffaef.x004daeac26db37fe.xb333e1e6c01c2be2(this);
			}
			if (!x02a9efce5fdffaef.x933af3effe3af4af)
			{
				x02a9efce5fdffaef = null;
			}
		}
		xef8b23deb509f187 = null;
		return new x98c1867b219333bc(xcf417e2db4fe9ed, x5dc2b4bc740c != null);
	}

	private bool x9c3cf3451811c728()
	{
		foreach (Node item in xabae4fa6681a6afd(x7d5e2f34b6651bf4.xb0b4ff1622a01d12))
		{
			if (item.NodeType == NodeType.FieldStart && x5c29822913be33c1.x5eaa4d0262a0cf5d(((FieldStart)item).FieldType))
			{
				return true;
			}
		}
		return false;
	}

	private void x0ad87ca7d276f896()
	{
		if (x5c29822913be33c1.x3bb982278b787f27(Type) && !xfa17dd0127bd5c83())
		{
			x0b575d343c8e4df3();
		}
		else
		{
			x9cb2542bafed44b0(x7d5e2f34b6651bf4.xb0b4ff1622a01d12);
		}
	}

	private bool xfa17dd0127bd5c83()
	{
		if (IsInHeaderFooter)
		{
			return x58daf9beaf8b1ae0();
		}
		return false;
	}

	private void x0b575d343c8e4df3()
	{
		x859103dcc2a939af(x1b286cd42deb2210.x4cb6bfd176a54d84);
		x9cb2542bafed44b0(x7d5e2f34b6651bf4.xb0b4ff1622a01d12);
		x859103dcc2a939af(x1b286cd42deb2210.xbdd18baa4fa2b89f);
		x8169d349e75cbc3b();
		x9cb2542bafed44b0(x7d5e2f34b6651bf4.xb0b4ff1622a01d12);
		x859103dcc2a939af(x1b286cd42deb2210.x4d0b9d4447ba7566);
	}

	private void x9cb2542bafed44b0(x7d5e2f34b6651bf4 xdd2e02377d7065ba)
	{
		x109ecce6e2a0da51 x109ecce6e2a0da = new x109ecce6e2a0da51(this, xdd2e02377d7065ba);
		while (x109ecce6e2a0da.x47f176deff0d42e2())
		{
			Field x38a7520391277515 = x109ecce6e2a0da.x38a7520391277515;
			x5e36356bc92c609b x0f7b23d1c393aed = x5e36356bc92c609b.x48539ee51dba0fcf(x38a7520391277515, x02a9efce5fdffaef, xdd2e02377d7065ba);
			x98c1867b219333bc x98c1867b219333bc = x34a4695711b84f85.x4e3cfc222c92cda7(x38a7520391277515, x0f7b23d1c393aed);
			if (x98c1867b219333bc.x43601cc1260d5f58 != 0)
			{
				switch (xdd2e02377d7065ba)
				{
				case x7d5e2f34b6651bf4.xb0b4ff1622a01d12:
				{
					x5e36356bc92c609b x5e36356bc92c609b = x02a9efce5fdffaef.xfb9ab092513c65d9();
					x34a4695711b84f85.xcf4268d5a79e653b(x5e36356bc92c609b.xd1b40af56a8385d4, x98c1867b219333bc.x43601cc1260d5f58);
					break;
				}
				case x7d5e2f34b6651bf4.xf8d31d196ccd74c4:
					x34a4695711b84f85.xcf4268d5a79e653b(x38a7520391277515, x98c1867b219333bc.x43601cc1260d5f58);
					break;
				default:
					throw new ArgumentOutOfRangeException("area");
				}
			}
		}
	}

	private void x859103dcc2a939af(x1b286cd42deb2210 xe00c282e1a49fcfb)
	{
		if (x4e3db8304327e38e != 0)
		{
			xef8b23deb509f187 = null;
		}
		x4e3db8304327e38e = xe00c282e1a49fcfb;
	}

	[JavaThrows(true)]
	internal virtual void x8169d349e75cbc3b()
	{
	}

	private bool x7ff30deb4e281744()
	{
		if (x02a9efce5fdffaef.x933af3effe3af4af)
		{
			return false;
		}
		Document document = x357c90b33d6bb8e6();
		if (document.xc6ce8b20496b71f5 || x58daf9beaf8b1ae0())
		{
			x5c28fdcd27dee7d9 x5c28fdcd27dee7d = document.xcde671c53995c411.x2f356dc98cc87b99(Start);
			if (x5c28fdcd27dee7d == null)
			{
				return false;
			}
			x5c28fdcd27dee7d.x295cb4a1df7a5add(this);
			return true;
		}
		return false;
	}

	[JavaThrows(true)]
	internal virtual x5dc2b4bc740c9563 x83bcdf1790545fdb()
	{
		x82e26649b09596bd x82e26649b09596bd = x6edce55dcd2d335b.x803fdc6662fa3f31();
		if (x82e26649b09596bd == null)
		{
			return null;
		}
		return new xca592a476766b11a(this, x82e26649b09596bd);
	}

	private void xf9d8551009fb4b3d()
	{
		x88485bf5e43cb3fd = new ArrayList();
		foreach (Node item in xabae4fa6681a6afd(x7d5e2f34b6651bf4.xf8d31d196ccd74c4))
		{
			x88485bf5e43cb3fd.Add(item);
		}
	}

	private void x6c680c465f828abb()
	{
		x88485bf5e43cb3fd = null;
	}

	private x7e263f21a73a027a x3f0d60b6b3704e89()
	{
		if (x201282ef5b887ec3)
		{
			return x7e263f21a73a027a.x825c3b6fa3e39f20;
		}
		return new x7e263f21a73a027a(Start, End);
	}

	internal x7e263f21a73a027a xabae4fa6681a6afd(x7d5e2f34b6651bf4 xdd2e02377d7065ba)
	{
		return xabae4fa6681a6afd(xdd2e02377d7065ba, xac58cb801bdb137c: true);
	}

	private x7e263f21a73a027a xabae4fa6681a6afd(x7d5e2f34b6651bf4 xdd2e02377d7065ba, bool xac58cb801bdb137c)
	{
		if (xac58cb801bdb137c && x201282ef5b887ec3)
		{
			return x7e263f21a73a027a.x825c3b6fa3e39f20;
		}
		switch (xdd2e02377d7065ba)
		{
		case x7d5e2f34b6651bf4.xb0b4ff1622a01d12:
			return new x7e263f21a73a027a(Start, includeStart: false, xb29355c4bafca5da, includeEnd: false);
		case x7d5e2f34b6651bf4.xf8d31d196ccd74c4:
			if (!xc077cfa8d6f9e3c5)
			{
				return x7e263f21a73a027a.x825c3b6fa3e39f20;
			}
			return new x7e263f21a73a027a(Separator, includeStart: false, End, includeEnd: false);
		default:
			throw new InvalidOperationException();
		}
	}

	internal virtual x7e263f21a73a027a xc29c85f333b133e4(x7d5e2f34b6651bf4 xdd2e02377d7065ba)
	{
		x1b286cd42deb2210 x1b286cd42deb = x4e3db8304327e38e;
		if (x1b286cd42deb == x1b286cd42deb2210.xbdd18baa4fa2b89f)
		{
			switch (xdd2e02377d7065ba)
			{
			case x7d5e2f34b6651bf4.xb0b4ff1622a01d12:
			case x7d5e2f34b6651bf4.xf8d31d196ccd74c4:
				return x7e263f21a73a027a.x825c3b6fa3e39f20;
			default:
				throw new InvalidOperationException();
			}
		}
		return xabae4fa6681a6afd(xdd2e02377d7065ba, xac58cb801bdb137c: false);
	}

	internal virtual xea515a7e0d19a986 xadf6796b90c1934e()
	{
		return new x6fe74eca7967f69d(((bool)Start.xeedad81aaed42a76.xcedf9c82728ad579.xcc8077a1fcb56a8f(Start, 265)) ? 1 : 0);
	}

	internal void x5f4c2139149eaf99(bool x5113d1e6ef8a0405)
	{
		if (!xc077cfa8d6f9e3c5)
		{
			if (!x5113d1e6ef8a0405 && x5c29822913be33c1.xd668adf9377c05ee(Type) == x5576a2206c3fc746.xf99e3386924fbeb6)
			{
				throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("ghcmbjjmljanijhngjonijfobemobjdpaikpmibafdiaeipaehgbphnbohecchlchhcdacjdmgaeaghehboeffffbbmfefdgefkgnebhbfihgephppfiafnibeejhdljheckapikbdaljdhlmcolhdfmbolmmcdnkcknmcbofnhokbpoabgpccnpoaeagmkaeacbamibabacppgchaocfpeddamdpoceppjehpafhphfalof", 329564723)));
			}
			x4490d25db4164ab6.x43604484a3deae4f = new FieldSeparator(End.Document, new xeedad81aaed42a76(), Type);
			End.ParentNode.InsertBefore(Separator, End);
			End.x254cab982e9946b2(xbcea506a33cf9111: true);
		}
	}

	internal virtual Section xe8d4351bdfdbf28a()
	{
		return null;
	}

	internal Document x357c90b33d6bb8e6()
	{
		return Start.x357c90b33d6bb8e6();
	}

	internal virtual x7e263f21a73a027a x1c428e55430b2acc()
	{
		return null;
	}

	internal x825568e289c5e629 xda55dc11084967d0(xdac068096ca09318 xb4edacb3d605f604)
	{
		x7e263f21a73a027a x7e263f21a73a027a = x1c428e55430b2acc();
		if (x7e263f21a73a027a != null)
		{
			return new x825568e289c5e629(x7e263f21a73a027a, xc16aad357e715234.xc15967a69fd4424e);
		}
		if (!xc077cfa8d6f9e3c5)
		{
			return null;
		}
		x5e36356bc92c609b x5e36356bc92c609b = (x21f09c4bcee72280 ? x02a9efce5fdffaef : new x5e36356bc92c609b(this));
		x5e36356bc92c609b.xefabd160dd587f64 = xb4edacb3d605f604;
		x98c1867b219333bc x98c1867b219333bc = x295cb4a1df7a5add(x5e36356bc92c609b);
		x5e36356bc92c609b.xefabd160dd587f64 = null;
		if (!x98c1867b219333bc.xa609f7a4683d08a5)
		{
			return null;
		}
		if (x5c29822913be33c1.xb2cdffc8e47588c8(Type))
		{
			return null;
		}
		if (x201282ef5b887ec3)
		{
			return new x825568e289c5e629(x7e263f21a73a027a.x825c3b6fa3e39f20, xc16aad357e715234.xede4646e426cf6a7);
		}
		if (x5e36356bc92c609b.x2f525bda126aa442)
		{
			return new x825568e289c5e629(x3f0d60b6b3704e89(), xc16aad357e715234.xede4646e426cf6a7);
		}
		return new x825568e289c5e629(xabae4fa6681a6afd(x7d5e2f34b6651bf4.xf8d31d196ccd74c4), xc16aad357e715234.xe93eb88030ad2248);
	}

	internal bool x58daf9beaf8b1ae0()
	{
		if (x5c29822913be33c1.x6caf38183f332e86(Type))
		{
			return true;
		}
		x109ecce6e2a0da51 x109ecce6e2a0da = new x109ecce6e2a0da51(this, x7d5e2f34b6651bf4.xb0b4ff1622a01d12);
		while (x109ecce6e2a0da.x47f176deff0d42e2())
		{
			if (x109ecce6e2a0da.x38a7520391277515.x58daf9beaf8b1ae0())
			{
				return true;
			}
		}
		return false;
	}
}
