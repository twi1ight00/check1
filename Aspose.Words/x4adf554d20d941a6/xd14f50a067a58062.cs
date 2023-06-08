using System.Collections;
using System.Drawing;
using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Lists;
using Aspose.Words.Saving;
using x28925c9b27b37a46;
using x59d6a4fc5007b7a4;
using x6c95d9cf46ff5f25;

namespace x4adf554d20d941a6;

internal class xd14f50a067a58062 : x61ebdec02c254c25
{
	private bool xe93eedabe4680a03;

	private ArrayList xcbd3160cde9c5b09 = new ArrayList();

	private x56410a8dd70087c5 x8298d7f8d08be8ed;

	private Shape x7518ba3ab0e3c336;

	private readonly Paragraph x233446e8759c5129;

	internal override int x1be93eed8950d961 => 0;

	internal override bool x1b4884baf08c8d62 => true;

	internal override x6e414db5d060a816 x6e414db5d060a816 => x6e414db5d060a816.x865739e9b580d3cf;

	private bool x89b37ca04efa4ce5
	{
		get
		{
			if (!xcd4bd3abd72ff2da.x57a8965bf85f0d71(x86e38944139b26ce))
			{
				return null != x3af1eed8ae516f2d;
			}
			return true;
		}
	}

	private bool xd8fc2f688b8bf3a6 => xcbd3160cde9c5b09.Count > 0;

	private bool x3f2bcd21b409f032 => ListTrailingCharacter.Nothing != x49b37abfabd470d8;

	private bool xe7839059a52b9e4f => x8298d7f8d08be8ed != null;

	private string[] x86e38944139b26ce
	{
		get
		{
			if (!xa5b0b2bd80e63541)
			{
				return x233446e8759c5129.ListLabel.x86e38944139b26ce;
			}
			return null;
		}
	}

	private Shape x3af1eed8ae516f2d
	{
		get
		{
			if (xa5b0b2bd80e63541 || x233446e8759c5129.ListFormat.ListLevel.xc9c754014952f758 == null)
			{
				return null;
			}
			if (x7518ba3ab0e3c336 == null)
			{
				x7518ba3ab0e3c336 = (Shape)x233446e8759c5129.ListFormat.ListLevel.xc9c754014952f758.Clone(isCloneChildren: true);
				SizeF sizeInPoints = x7518ba3ab0e3c336.SizeInPoints;
				x7518ba3ab0e3c336.Height = x0b5ee02972f2b9ba.xc051fce01f594339(base.x705ed5f9769744e5.xc2d4efc42998d87b.x53531537bb3331e6);
				x7518ba3ab0e3c336.Width = (double)sizeInPoints.Width * x7518ba3ab0e3c336.Height / (double)sizeInPoints.Height;
			}
			return x7518ba3ab0e3c336;
		}
	}

	private ListTrailingCharacter x49b37abfabd470d8
	{
		get
		{
			if (!xa5b0b2bd80e63541)
			{
				return x233446e8759c5129.ListFormat.ListLevel.TrailingCharacter;
			}
			return ListTrailingCharacter.Nothing;
		}
	}

	private bool xa5b0b2bd80e63541
	{
		get
		{
			if (x233446e8759c5129.ParentNode != null)
			{
				return !x233446e8759c5129.IsListItem;
			}
			return true;
		}
	}

	private bool x2079c634327972b3
	{
		get
		{
			foreach (x56410a8dd70087c5 item in xcbd3160cde9c5b09)
			{
				if (!item.x00fa20d37841acd0)
				{
					return false;
				}
			}
			return true;
		}
	}

	private bool x94a6269fb4ede02d
	{
		get
		{
			foreach (x56410a8dd70087c5 item in xcbd3160cde9c5b09)
			{
				if (!item.xf29810c0a232d826)
				{
					return false;
				}
			}
			return true;
		}
	}

	internal xd14f50a067a58062(Node node)
		: base(0)
	{
		x233446e8759c5129 = (Paragraph)node;
	}

	internal override void x3e04636bf524a4cf(xb9e48f11d7f06ec9 x27f5ecb735ac9676)
	{
		if (x27f5ecb735ac9676 != xb9e48f11d7f06ec9.x56410a8dd70087c5 || xe93eedabe4680a03)
		{
			return;
		}
		if (!base.xc0e56f2fca892328)
		{
			x2b1f4fb56dbfadc9(x0082719cc867c3d3: true);
			return;
		}
		if (!xd8fc2f688b8bf3a6 && !xe7839059a52b9e4f)
		{
			if (x89b37ca04efa4ce5)
			{
				x96cae28a54d522c4();
			}
			if (x3f2bcd21b409f032)
			{
				x2fe4551ae3a2dea9();
			}
		}
		x56410a8dd70087c5 x56410a8dd70087c6 = x446a20236cc82292();
		if (x3f2bcd21b409f032 && x8298d7f8d08be8ed.x00fa20d37841acd0)
		{
			if (x56410a8dd70087c6 != x8298d7f8d08be8ed.x61712f0b4f5455af)
			{
				x2b1f4fb56dbfadc9(x0082719cc867c3d3: false);
			}
		}
		else if (x89b37ca04efa4ce5 && x2079c634327972b3 && x56410a8dd70087c6 != x582912823dcf8b1d())
		{
			x2b1f4fb56dbfadc9(x0082719cc867c3d3: false);
		}
		if ((x89b37ca04efa4ce5 && !x2079c634327972b3) || (x3f2bcd21b409f032 && !x8298d7f8d08be8ed.x00fa20d37841acd0))
		{
			if (xd8fc2f688b8bf3a6)
			{
				x2c11041d3b4707c8(x56410a8dd70087c6.x772764427592d4bb);
			}
			if (xe7839059a52b9e4f)
			{
				x8298d7f8d08be8ed.x772764427592d4bb = x56410a8dd70087c6.x772764427592d4bb;
			}
			x75d6a65e41dc52f9(x56410a8dd70087c6.x7f6ad514996fb03a);
		}
		xe93eedabe4680a03 = true;
	}

	internal override void x9da22225f9eb6ab2(x1073233de8252b3e xd3311d815ca25f02)
	{
		x2b1f4fb56dbfadc9(x0082719cc867c3d3: true);
		base.x9da22225f9eb6ab2(xd3311d815ca25f02);
	}

	internal override void x7012609bcdb39574(x75b8b2f740aae644 x672ff13faf031f3d)
	{
		base.x7012609bcdb39574(x672ff13faf031f3d);
		x672ff13faf031f3d.x94f606521182906f(this);
	}

	internal override x56410a8dd70087c5 xa9d7e8f6fbdcbcfc(x56410a8dd70087c5 x7d95d971d8923f4c)
	{
		if (x7d95d971d8923f4c == null)
		{
			x7d95d971d8923f4c = new xd14f50a067a58062(x233446e8759c5129);
		}
		xd14f50a067a58062 xd14f50a067a58063 = (xd14f50a067a58062)x7d95d971d8923f4c;
		xd14f50a067a58063.xcbd3160cde9c5b09 = new ArrayList();
		xd14f50a067a58063.x8298d7f8d08be8ed = null;
		xd14f50a067a58063.xe93eedabe4680a03 = false;
		xd14f50a067a58063.x7518ba3ab0e3c336 = x7518ba3ab0e3c336;
		return base.xa9d7e8f6fbdcbcfc(x7d95d971d8923f4c);
	}

	private x56410a8dd70087c5 x446a20236cc82292()
	{
		x56410a8dd70087c5 x0eafd527bd1e778e = base.x406d8cd2af514771.x0eafd527bd1e778e;
		while (x0eafd527bd1e778e.x5566e2d2acbd1fbe == 21779 || x0eafd527bd1e778e.x5566e2d2acbd1fbe == 21788 || x0eafd527bd1e778e is x91e144d65ff41819 || x0eafd527bd1e778e == this || xcbd3160cde9c5b09.Contains(x0eafd527bd1e778e) || (xe7839059a52b9e4f && x0eafd527bd1e778e == x8298d7f8d08be8ed))
		{
			x0eafd527bd1e778e = x0eafd527bd1e778e.x61712f0b4f5455af;
		}
		return x0eafd527bd1e778e;
	}

	private void x2b1f4fb56dbfadc9(bool x0082719cc867c3d3)
	{
		if (!base.xf29810c0a232d826)
		{
			return;
		}
		xa268fdb9ca040dde xe1410f585439c7d = x2c8c6741422a1298.xe1410f585439c7d4;
		bool flag = x89b37ca04efa4ce5 && xd8fc2f688b8bf3a6;
		if (flag)
		{
			flag = x94a6269fb4ede02d;
			if (flag)
			{
				x225c5fadb5f30404(xe1410f585439c7d);
			}
			if (x0082719cc867c3d3)
			{
				xcbd3160cde9c5b09.Clear();
			}
		}
		bool flag2 = x3f2bcd21b409f032 && xe7839059a52b9e4f;
		if (flag2)
		{
			flag2 = x8298d7f8d08be8ed.xf29810c0a232d826;
			if (flag2)
			{
				xe1410f585439c7d.x52b190e626f65140(x8298d7f8d08be8ed);
			}
			if (x0082719cc867c3d3)
			{
				x8298d7f8d08be8ed = null;
			}
		}
		if (flag || flag2)
		{
			xe1410f585439c7d.x408f4b7efc86fd49();
		}
	}

	private void x75d6a65e41dc52f9(x56410a8dd70087c5 xd9ff4dee1dba180e)
	{
		if (!base.xf29810c0a232d826)
		{
			return;
		}
		xa268fdb9ca040dde xe1410f585439c7d = x2c8c6741422a1298.xe1410f585439c7d4;
		if (x89b37ca04efa4ce5 && xd8fc2f688b8bf3a6)
		{
			foreach (x56410a8dd70087c5 item in xcbd3160cde9c5b09)
			{
				xe1410f585439c7d.xef23aa45e7612fdd(x53111d6596d16a99, xd9ff4dee1dba180e, item);
				xd9ff4dee1dba180e = item;
			}
		}
		if (x3f2bcd21b409f032 && xe7839059a52b9e4f)
		{
			xe1410f585439c7d.xef23aa45e7612fdd(x53111d6596d16a99, xd9ff4dee1dba180e, x8298d7f8d08be8ed);
		}
		xe1410f585439c7d.x408f4b7efc86fd49();
	}

	private void x96cae28a54d522c4()
	{
		if (x3af1eed8ae516f2d != null)
		{
			x93129707db3837e5();
		}
		else
		{
			xf0b67a082888e2be();
		}
	}

	private void x93129707db3837e5()
	{
		xa67197c42bddc7dc xa67197c42bddc7dc2 = new xa67197c42bddc7dc(x3af1eed8ae516f2d);
		xa67197c42bddc7dc2.x4e1234ca2b87020b = true;
		xdeab92faa2eb558b xdeab92faa2eb558b2 = new xdeab92faa2eb558b(x2c8c6741422a1298.x17dcbf5fe3c0d2d2);
		if (xdeab92faa2eb558b2.x109e3389933c23a8.xab6edfb47ff0b74c != 0)
		{
			xdeab92faa2eb558b2.x109e3389933c23a8 = null;
			xdeab92faa2eb558b2.x109e3389933c23a8.xab6edfb47ff0b74c = WrapType.Inline;
		}
		xa67197c42bddc7dc2.x34251722ab416841 = xdeab92faa2eb558b.x38758cbbee49e4cb(xdeab92faa2eb558b2);
		xa67197c42bddc7dc2.xfc6971c7d8314663 = xfc6971c7d8314663.xe9605a4bea014f21;
		xa67197c42bddc7dc2.x705ed5f9769744e5 = xacc55eb1e4595209.x36f681ceb5afa4e0(x233446e8759c5129, x000f21cbda739311.x175297738c8b8d1e, xfd54855e4993adef: false, base.x705ed5f9769744e5.x17dcbf5fe3c0d2d2);
		xcbd3160cde9c5b09.Add(xa67197c42bddc7dc2);
	}

	private void xf0b67a082888e2be()
	{
		bool bidi = x233446e8759c5129.ParagraphFormat.Bidi;
		int xa59ac2c936c6b7bd = x233446e8759c5129.ListLabel.x856218fd0771d379().xa59ac2c936c6b7bd;
		NumeralFormat x515e84b3fc4c = x2c8c6741422a1298.xdeb77ea37ad74c56.x515e84b3fc4c5959;
		string[] array = x86e38944139b26ce;
		foreach (string text in array)
		{
			bool isMirroringRequired = bidi;
			x4e23280611779ac3 x4e23280611779ac = new x4e23280611779ac3(text, bidi, xa59ac2c936c6b7bd, isMirroringRequired);
			xa4665f59f0cb55bd.xaa12240713c4e5bd(x4e23280611779ac, x515e84b3fc4c);
			char x3c4da2980d043c = x4e23280611779ac.xf9ad6fb78355fe13[0];
			bool flag = x34a37b5a89c466fd.xfb345a6afecb5385(x3c4da2980d043c);
			x000f21cbda739311 x21a91e2ac6ef = x569800eaac1da502(x3c4da2980d043c, bidi, flag);
			xf543de5d109f4fda xf543de5d109f4fda2 = new xf543de5d109f4fda(x4e23280611779ac.xf9ad6fb78355fe13);
			xf543de5d109f4fda2.xfc6971c7d8314663 = xfc6971c7d8314663.xe9605a4bea014f21;
			xf543de5d109f4fda2.x705ed5f9769744e5 = xacc55eb1e4595209.x36f681ceb5afa4e0(x233446e8759c5129, x21a91e2ac6ef, flag, base.x705ed5f9769744e5.x17dcbf5fe3c0d2d2);
			xcbd3160cde9c5b09.Add(xf543de5d109f4fda2);
		}
	}

	private void x2fe4551ae3a2dea9()
	{
		if (x49b37abfabd470d8 == ListTrailingCharacter.Tab)
		{
			x8298d7f8d08be8ed = new xc0e747af79894e12();
		}
		else if (x49b37abfabd470d8 == ListTrailingCharacter.Space)
		{
			x8298d7f8d08be8ed = new xee65f8567b84ecd3(1);
		}
		if (x8298d7f8d08be8ed != null)
		{
			x8298d7f8d08be8ed.x4e1234ca2b87020b = true;
			x8298d7f8d08be8ed.xfc6971c7d8314663 = xfc6971c7d8314663.xe9605a4bea014f21;
			x8298d7f8d08be8ed.x705ed5f9769744e5 = xacc55eb1e4595209.x36f681ceb5afa4e0(x233446e8759c5129, x000f21cbda739311.x22a0fbb9469b35e1, xfd54855e4993adef: false, base.x705ed5f9769744e5.x17dcbf5fe3c0d2d2);
		}
	}

	private x000f21cbda739311 x569800eaac1da502(char x3c4da2980d043c95, bool x8afe8730f74ee629, bool x7ae1e969f148d882)
	{
		x000f21cbda739311 xfb064a7505df = x233446e8759c5129.ListFormat.ListLevel.xfb064a7505df1564;
		if (xfb064a7505df == x000f21cbda739311.x7c8c2d13fa5b79fa)
		{
			return xfb064a7505df;
		}
		if (x8afe8730f74ee629 && !x7ae1e969f148d882 && (xfb064a7505df == x000f21cbda739311.xd4e922ceeed89b74 || !x34a37b5a89c466fd.x6657b4a72cfac626(x3c4da2980d043c95)))
		{
			return x000f21cbda739311.xd4e922ceeed89b74;
		}
		if (!x233446e8759c5129.ListLabel.x5959bccb67bbf051)
		{
			return x000f21cbda739311.x175297738c8b8d1e;
		}
		return xb7dbd7bb3ed97d5b.xc0f0857806be03ff(x3c4da2980d043c95);
	}

	private static bool xb5ff083fb086c8b5(x8d9303345f12a846 x2612f62f94df47de)
	{
		x56410a8dd70087c5 x0eafd527bd1e778e = x2612f62f94df47de.x0eafd527bd1e778e;
		while (true)
		{
			if (x4adf554d20d941a6.x5566e2d2acbd1fbe.xd707791130626739(x0eafd527bd1e778e.x5566e2d2acbd1fbe))
			{
				return true;
			}
			if (x0eafd527bd1e778e.x5566e2d2acbd1fbe != 0 || x0eafd527bd1e778e.x55b6066f30988caf)
			{
				break;
			}
			x0eafd527bd1e778e = x0eafd527bd1e778e.x61712f0b4f5455af;
		}
		return false;
	}

	private x56410a8dd70087c5 x582912823dcf8b1d()
	{
		return ((x56410a8dd70087c5)xcbd3160cde9c5b09[xcbd3160cde9c5b09.Count - 1]).x61712f0b4f5455af;
	}

	private void x2c11041d3b4707c8(int x8a61868fbfcf5edd)
	{
		foreach (x56410a8dd70087c5 item in xcbd3160cde9c5b09)
		{
			item.x772764427592d4bb = x8a61868fbfcf5edd;
		}
	}

	private void x225c5fadb5f30404(xa268fdb9ca040dde xd07ce4b74c5774a7)
	{
		foreach (x56410a8dd70087c5 item in xcbd3160cde9c5b09)
		{
			xd07ce4b74c5774a7.x52b190e626f65140(item);
		}
	}
}
