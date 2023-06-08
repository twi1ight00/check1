using Aspose.Words;
using x28925c9b27b37a46;

namespace xfbd1009a0cbb9842;

internal class xfaf63ce8c54cd8e9 : x99591af092599bad, xe83a6b069ec8efc2
{
	internal xfaf63ce8c54cd8e9(Style tocEntryStyle)
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
	}

	protected override bool IsExtraDirectAttribute(int directAttrKey, object directAttrValue, Inline sourceInline)
	{
		if (!xb14c46d788f0762a(directAttrKey) && !base.IsExtraDirectAttribute(directAttrKey, directAttrValue, sourceInline))
		{
			return x5c38a73d13c3ae2d(directAttrKey);
		}
		return true;
	}

	private static bool xb14c46d788f0762a(int x337751f7ff5a51da)
	{
		if (x337751f7ff5a51da != 160)
		{
			return x337751f7ff5a51da == 140;
		}
		return true;
	}

	private bool x5c38a73d13c3ae2d(int x337751f7ff5a51da)
	{
		Style x44ecfea61c937b8e = x0ae496095d389ba7(StyleIdentifier.Hyperlink);
		if (!x553c2a4f27ffe325(x44ecfea61c937b8e, x337751f7ff5a51da))
		{
			return x553c2a4f27ffe325(base.x5b6656344a1f0b8e, x337751f7ff5a51da);
		}
		return true;
	}

	private bool x553c2a4f27ffe325(Style x44ecfea61c937b8e, int x337751f7ff5a51da)
	{
		if (x44ecfea61c937b8e == null)
		{
			return false;
		}
		object obj = x44ecfea61c937b8e.x61d8cd76508e76c3(x337751f7ff5a51da, x9ee6c2f047893ddc: false);
		if (obj == null)
		{
			return false;
		}
		if (obj is x9b28b1f7f0cc963f)
		{
			return true;
		}
		object obj2 = xb2e9d2cfd9321b9c(x337751f7ff5a51da);
		return obj.Equals(obj2);
	}

	private object xb2e9d2cfd9321b9c(int x337751f7ff5a51da)
	{
		return x0ae496095d389ba7(StyleIdentifier.DefaultParagraphFont)?.x61d8cd76508e76c3(x337751f7ff5a51da, x9ee6c2f047893ddc: true);
	}

	private Style x0ae496095d389ba7(StyleIdentifier xe98722bc47ad3bb3)
	{
		if (base.x5b6656344a1f0b8e == null)
		{
			return null;
		}
		return base.x5b6656344a1f0b8e.Styles.xf21e14e2c9db279a(xe98722bc47ad3bb3, x988fcf605f8efa7e: true);
	}
}
