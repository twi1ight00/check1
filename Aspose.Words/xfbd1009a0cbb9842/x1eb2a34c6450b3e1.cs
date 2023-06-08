using Aspose.Words;
using x28925c9b27b37a46;

namespace xfbd1009a0cbb9842;

internal class x1eb2a34c6450b3e1 : x99591af092599bad, xe83a6b069ec8efc2
{
	internal x1eb2a34c6450b3e1(Style tocEntryStyle)
		: base(tocEntryStyle)
	{
	}

	private Node x65611a033680c59d(Node x98cacf1c34b53cca, Node xc926b680b06084a7, bool xdc5889e5d1efc748)
	{
		return x57f70b425b43a885(x98cacf1c34b53cca, xc926b680b06084a7);
	}

	Node xe83a6b069ec8efc2.x57f70b425b43a885(Node x98cacf1c34b53cca, Node xc926b680b06084a7, bool xdc5889e5d1efc748)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x65611a033680c59d
		return this.x65611a033680c59d(x98cacf1c34b53cca, xc926b680b06084a7, xdc5889e5d1efc748);
	}

	protected override void ModifyInlineNode(Inline sourceInline, Inline modifiedInline)
	{
		xcfa8ff6665b463cb(sourceInline, modifiedInline);
		xead38284db3076f3(sourceInline, modifiedInline);
	}

	internal static void xb8a4bfef71d3ed05(Node xda5bf54deb817e37)
	{
		if (xda5bf54deb817e37 != null)
		{
			x7e263f21a73a027a xad3a4203a31b = new x7e263f21a73a027a(xda5bf54deb817e37, xda5bf54deb817e37);
			Style tocEntryStyle = xda5bf54deb817e37.Document.Styles.xf21e14e2c9db279a(StyleIdentifier.DefaultParagraphFont, x988fcf605f8efa7e: true);
			x1eb2a34c6450b3e1 x1eb2a34c6450b3e2 = new x1eb2a34c6450b3e1(tocEntryStyle);
			x1eb2a34c6450b3e2.xb8a4bfef71d3ed05(xad3a4203a31b);
		}
	}

	private void xb8a4bfef71d3ed05(x7e263f21a73a027a xad3a4203a31b3836)
	{
		xb56968f92e308c8a xb56968f92e308c8a = new xb56968f92e308c8a(xad3a4203a31b3836);
		while (xb56968f92e308c8a.x1ef2c3be187f37a2())
		{
			if (xb56968f92e308c8a.x3387295f12854dfd is Inline)
			{
				Inline inline = (Inline)xb56968f92e308c8a.x3387295f12854dfd;
				xcfa8ff6665b463cb(inline, inline);
			}
		}
	}

	private void xead38284db3076f3(Inline xf7a250c42a4b8fc1, Inline xe947890993704cca)
	{
		if (base.x5b6656344a1f0b8e == null)
		{
			return;
		}
		xeedad81aaed42a76 xeedad81aaed42a = xf7a250c42a4b8fc1.xcdd1fdba92902f20.x856218fd0771d379(xecac24b19ed3a2b7.xe9e531d1a6725226);
		xeedad81aaed42a76 xeedad81aaed42a2 = xf7a250c42a4b8fc1.xeedad81aaed42a76;
		xeedad81aaed42a76 xeedad81aaed42a3 = xe947890993704cca.xeedad81aaed42a76;
		for (int i = 0; i < xeedad81aaed42a.xe252973deea04dda; i++)
		{
			xeedad81aaed42a.x16b3a875e7cc38ed(i, out var xba08ce632055a1d, out var xbcea506a33cf);
			if (x3c4054366b5d58c7(xba08ce632055a1d) || xeedad81aaed42a2.x9bd0b4c41657450b(xba08ce632055a1d) != null)
			{
				continue;
			}
			if (xbcea506a33cf is x9b28b1f7f0cc963f)
			{
				if (xbcea506a33cf == x9b28b1f7f0cc963f.xbbad6bbe73c6b1dc && !x1da8b385123b5912(xba08ce632055a1d, xf7a250c42a4b8fc1))
				{
					xeedad81aaed42a3.xd6b6ed77479ef68c(xba08ce632055a1d, x9b28b1f7f0cc963f.x10a64d88e6f4fac9);
				}
			}
			else if (!x1da8b385123b5912(xba08ce632055a1d, xf7a250c42a4b8fc1))
			{
				xeedad81aaed42a3.xd6b6ed77479ef68c(xba08ce632055a1d, xbcea506a33cf);
			}
		}
	}
}
