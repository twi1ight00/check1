using System;
using System.Collections;
using System.Reflection;
using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Fields;
using Aspose.Words.Saving;
using x13cd31bb39e0b7ea;
using x1c8faa688b1f0b0c;
using x28925c9b27b37a46;
using x4adf554d20d941a6;

namespace x59d6a4fc5007b7a4;

[DefaultMember("Item")]
internal class xcde671c53995c411 : xb850ecb8335a2e09
{
	private Hashtable x7201cfb195568ab8;

	private readonly Document xd1424e1a0bb4a72b;

	private readonly x4e2f8bff72d83f71 xe1b1f1bb8f4debec;

	internal ArrayList xc7b443f1cdbccfbe => xe1b1f1bb8f4debec.xdeb77ea37ad74c56.xc7b443f1cdbccfbe;

	internal xdcf47a8f1807f37c xe6d4b1b411ed94b5
	{
		get
		{
			xc7f90d9c7c51cede xc7f90d9c7c51cede = x86a0dde4c22f516b;
			if (xbf13a47a02af0066 != 0)
			{
				xc7f90d9c7c51cede = (xc7f90d9c7c51cede)xc7f90d9c7c51cede.x3c1c340351d94fbd.x874c84c476778297.x0efc8c115f3f0df7.get_xe6d4b1b411ed94b5(xbf13a47a02af0066);
			}
			return new xdcf47a8f1807f37c(xd1424e1a0bb4a72b, xc7f90d9c7c51cede);
		}
	}

	internal int xd44988f225497f3a => xe1b1f1bb8f4debec.x80f061859cd048ae.x0efc8c115f3f0df7.xd44988f225497f3a;

	internal override float x72d92bd1aff02e37
	{
		get
		{
			throw new InvalidOperationException();
		}
	}

	internal override float xe360b1885d8d4a41
	{
		get
		{
			throw new InvalidOperationException();
		}
	}

	private xc7f90d9c7c51cede x86a0dde4c22f516b => xe1b1f1bb8f4debec.x80f061859cd048ae.x86a0dde4c22f516b;

	internal static xcde671c53995c411 xd9db07500873ae98(Document x3664041d21d73fdc, xdeb77ea37ad74c56 xdfde339da46db651)
	{
		xcc0b5baa75272714 xcc0b5baa = new xcc0b5baa75272714();
		x8556eed81191af11 x8556eed81191af = new x8556eed81191af11(x3664041d21d73fdc, null, null, new PdfSaveOptions());
		xcc0b5baa.x18dfca7c5fd2402f(x8556eed81191af);
		xdfde339da46db651.x10fc1ff17b56245c = !x8556eed81191af.xd72e197c9500653f && !x8556eed81191af.x427aee4dfcc89c31;
		xdfde339da46db651.xc7b443f1cdbccfbe.Clear();
		if (!xdfde339da46db651.x10fc1ff17b56245c && x3664041d21d73fdc.x245aa7750b4a8072.xd44988f225497f3a > 0)
		{
			xdfde339da46db651.xbbf9a1ead81dd3a1("Custom footnote/endnote separator is not supported. Default separator will be rendered. This may affect layout of content on the page.", null);
		}
		xa268fdb9ca040dde xa268fdb9ca040dde = new xa268fdb9ca040dde();
		x4e2f8bff72d83f71 x4e2f8bff72d83f = xa268fdb9ca040dde.x4e2f8bff72d83f71;
		x4e2f8bff72d83f.xdeb77ea37ad74c56 = xdfde339da46db651;
		x487cdc969fefe3d6 x487cdc969fefe3d7 = new x487cdc969fefe3d6(x3664041d21d73fdc, x4e2f8bff72d83f.xdeb77ea37ad74c56, x4e2f8bff72d83f.x17dcbf5fe3c0d2d2, x4e2f8bff72d83f.xeafe18c850ae3127);
		while (x487cdc969fefe3d7.x83f07df6a659e05b())
		{
			xa268fdb9ca040dde.xef23aa45e7612fdd(x487cdc969fefe3d7.xbe1e23e7d5b43370, x487cdc969fefe3d7.x56410a8dd70087c5);
			xbf152843c1ed2887.x3bc66b20ee9d88e1();
		}
		x4e2f8bff72d83f.xb1a5e9f516a373ea(x3664041d21d73fdc, xa268fdb9ca040dde);
		x4e2f8bff72d83f.xc3819e13f60dd8e6();
		x3664041d21d73fdc.BuiltInDocumentProperties.Pages = x4e2f8bff72d83f.x80f061859cd048ae.x0efc8c115f3f0df7.xd44988f225497f3a;
		xcde671c53995c411 result = new xcde671c53995c411(x3664041d21d73fdc, x4e2f8bff72d83f);
		xcc0b5baa.x3522790e002e1ba4();
		return result;
	}

	internal void xc3819e13f60dd8e6()
	{
		xe1b1f1bb8f4debec.xc3819e13f60dd8e6();
	}

	internal x5c28fdcd27dee7d9 x2f356dc98cc87b99(FieldStart xe01ae93d9fe5a880)
	{
		return (x5c28fdcd27dee7d9)xe1b1f1bb8f4debec.x84aa3570d857bec4[xe01ae93d9fe5a880];
	}

	internal x4fdf549af9de6b97 x64cf48da0043a586(ShapeBase x8739b0dd3627f37e)
	{
		if (x8739b0dd3627f37e == null)
		{
			throw new ArgumentNullException("shapeBase");
		}
		if (x8739b0dd3627f37e.Document != xd1424e1a0bb4a72b)
		{
			throw new ArgumentException("Shape is not from the document used to build this layout.", "shapeBase");
		}
		if (x7201cfb195568ab8 == null)
		{
			x7201cfb195568ab8 = new Hashtable();
			x3772e2ac59760e15(xe1b1f1bb8f4debec.x80f061859cd048ae.xb3a79d506b0e2f7f.x8b61531c8ea35b85(), x7201cfb195568ab8);
			x3772e2ac59760e15(xe1b1f1bb8f4debec.x31b433cb13e4aa24.xb3a79d506b0e2f7f.x8b61531c8ea35b85(), x7201cfb195568ab8);
			x3772e2ac59760e15(xe1b1f1bb8f4debec.xe427d253f517c8ee.xb3a79d506b0e2f7f.x8b61531c8ea35b85(), x7201cfb195568ab8);
			for (xc7f90d9c7c51cede x3d695937fd09df4b = x86a0dde4c22f516b; x3d695937fd09df4b != null; x3d695937fd09df4b = x3d695937fd09df4b.x3d695937fd09df4b)
			{
				if (x3d695937fd09df4b.x1ea60bde2b5d0d28 != null)
				{
					x3772e2ac59760e15(x3d695937fd09df4b.x1ea60bde2b5d0d28.x53111d6596d16a99.xb3a79d506b0e2f7f, x7201cfb195568ab8);
				}
				if (x3d695937fd09df4b.x1d7b771e95a9abb5 != null)
				{
					x3772e2ac59760e15(x3d695937fd09df4b.x1d7b771e95a9abb5.x53111d6596d16a99.xb3a79d506b0e2f7f, x7201cfb195568ab8);
				}
			}
		}
		return ((xa67197c42bddc7dc)x7201cfb195568ab8[x8739b0dd3627f37e])?.x2d6658ad60c6ebe9;
	}

	internal int xeabba48ad7f85cb7(FieldStart x10aaa7cdfa38f254)
	{
		return ((x5c28fdcd27dee7d9)xe1b1f1bb8f4debec.x84aa3570d857bec4[x10aaa7cdfa38f254])?.x9ec60fbbaa3117a2() ?? (-1);
	}

	private xcde671c53995c411(Document document, x4e2f8bff72d83f71 documentLayout)
		: base(documentLayout.x80f061859cd048ae.x86a0dde4c22f516b)
	{
		xd1424e1a0bb4a72b = document;
		xe1b1f1bb8f4debec = documentLayout;
	}

	private static void x3772e2ac59760e15(xf3f447691ab38eee x887d55e3f220b5b9, Hashtable x1991a49fd85e55aa)
	{
		x887d55e3f220b5b9.x74f5a1ef3906e23c();
		while (x887d55e3f220b5b9.x47f176deff0d42e2())
		{
			x56410a8dd70087c5 x56410a8dd70087c = (x56410a8dd70087c5)x887d55e3f220b5b9.x35cfcea4890f4e7d;
			if (x56410a8dd70087c.x00fa20d37841acd0 && !x56410a8dd70087c.xd181cfc9bf12b1ac && x56410a8dd70087c.x5566e2d2acbd1fbe == 25604)
			{
				Node x40212106aad8a8b = ((xa67197c42bddc7dc)x56410a8dd70087c).x40212106aad8a8b0;
				if (!x1991a49fd85e55aa.ContainsKey(x40212106aad8a8b))
				{
					x1991a49fd85e55aa.Add(x40212106aad8a8b, x56410a8dd70087c);
				}
			}
		}
	}
}
