using System;
using System.IO;
using System.Text;
using Aspose.Words;
using Aspose.Words.Drawing;
using x011d489fb9df7027;
using x5af3f327d745698a;
using x6c95d9cf46ff5f25;
using xb92b7270f78a4e8d;
using xfbd1009a0cbb9842;

namespace x2182451cabb5c30d;

internal class xc201253ba36819ef : x3b57052406b93b82
{
	private const int x404ae9799ae57318 = 1252;

	private Shape x317be79405176667;

	private readonly bool x777fa70df8f65834;

	private bool x840f959dd5025e96;

	private OleFormat x45e96d759c9be282 => x317be79405176667.OleFormat;

	internal xc201253ba36819ef(xe5e546ef5f0503b2 context)
		: base(context)
	{
		x777fa70df8f65834 = true;
	}

	internal xc201253ba36819ef(xe5e546ef5f0503b2 context, Shape shape)
		: base(context)
	{
		x317be79405176667 = shape;
		x777fa70df8f65834 = false;
	}

	internal override void x41e7a76e7e854e6e(x03f56b37a0050a82 x153c99a852375422)
	{
		switch (base.x1a55de3a01c1c82d.x3146d638ec378671)
		{
		case x25099a8bbbd55d1c.x71d39fdf56861cca:
			xdd42b2c3309e0d09();
			break;
		case x25099a8bbbd55d1c.xd09757579a9e7eef:
			x4f0d9f8af86ed0ad();
			break;
		default:
			base.x41e7a76e7e854e6e(x153c99a852375422);
			break;
		}
	}

	internal override void xa4085ff83f9ddeeb()
	{
		switch (base.x1a55de3a01c1c82d.x3146d638ec378671)
		{
		case x25099a8bbbd55d1c.x71d39fdf56861cca:
			x0abdcdb1b433145e();
			break;
		case x25099a8bbbd55d1c.xd09757579a9e7eef:
			x49a67bc1b51f26c9();
			break;
		default:
			base.xa4085ff83f9ddeeb();
			break;
		}
	}

	private void xdd42b2c3309e0d09()
	{
		if (x777fa70df8f65834)
		{
			x317be79405176667 = new Shape(base.x2c8c6741422a1298);
			x317be79405176667.WrapType = WrapType.Inline;
		}
		if (!x317be79405176667.xa170cce2bc40bdf5)
		{
			x317be79405176667.x88d1b78392d1a0ab(ShapeType.OleObject);
		}
	}

	private void x4f0d9f8af86ed0ad()
	{
		x840f959dd5025e96 = true;
		if (x45e96d759c9be282.IsLink && !x317be79405176667.xf7125312c7ee115c.x263d579af1d0d43f(4118))
		{
			x45e96d759c9be282.x2e7d767f7d782a7a = x2e7d767f7d782a7a.x5896ed36f2cf9162;
		}
		switch (x45e96d759c9be282.x2e7d767f7d782a7a)
		{
		case x2e7d767f7d782a7a.x7f4d496937f8c24c:
		case x2e7d767f7d782a7a.x1351df7d00b0ea53:
			if (x777fa70df8f65834)
			{
				base.xe1410f585439c7d4.xa00b7e8964d655b2(x317be79405176667);
			}
			break;
		case x2e7d767f7d782a7a.x5896ed36f2cf9162:
		case x2e7d767f7d782a7a.xf9ad6fb78355fe13:
		{
			base.xe1410f585439c7d4.xcf72734b7092bebe();
			string text = string.Format("{0} ", xcae1c68ad9da73de.xda09af88ab899a50(x45e96d759c9be282).Replace("\"", ""));
			base.xe1410f585439c7d4.xfc1c33c63bf625fc(new Run(base.x2c8c6741422a1298, text, base.xffb3238a8fd59aa7.x5f35c5e3977af81d()));
			base.xe1410f585439c7d4.x094e1db5f87bb62b((x71d39fdf56861cca)x45e96d759c9be282.x58932c7e6fa3b905);
			break;
		}
		default:
			throw x3c671e3c86de169a(x45e96d759c9be282.x2e7d767f7d782a7a);
		}
	}

	private void x49a67bc1b51f26c9()
	{
		x840f959dd5025e96 = false;
		switch (x45e96d759c9be282.x2e7d767f7d782a7a)
		{
		case x2e7d767f7d782a7a.x7f4d496937f8c24c:
		case x2e7d767f7d782a7a.x1351df7d00b0ea53:
			if (x777fa70df8f65834)
			{
				base.xe1410f585439c7d4.x63fb29d61f50770e(x317be79405176667);
			}
			break;
		case x2e7d767f7d782a7a.x5896ed36f2cf9162:
		case x2e7d767f7d782a7a.xf9ad6fb78355fe13:
			base.xe1410f585439c7d4.x3bb349c77392b35c();
			break;
		default:
			throw x3c671e3c86de169a(x45e96d759c9be282.x2e7d767f7d782a7a);
		}
	}

	private static InvalidOperationException x3c671e3c86de169a(x2e7d767f7d782a7a x2f84d106350c4099)
	{
		string arg = "Default";
		switch (x2f84d106350c4099)
		{
		case x2e7d767f7d782a7a.x4bc88de02db3a00d:
			arg = "Html";
			break;
		case x2e7d767f7d782a7a.xc6077c9598837311:
			arg = "Unicode";
			break;
		}
		return new InvalidOperationException($"Unexpected OleLinkType value {arg}.");
	}

	private void x0abdcdb1b433145e()
	{
		if (!x45e96d759c9be282.IsLink && x45e96d759c9be282.x58932c7e6fa3b905 == null)
		{
			xb77fa34cab432e7f();
		}
	}

	private void xb77fa34cab432e7f()
	{
		x317be79405176667.x88d1b78392d1a0ab(ShapeType.Image);
		x317be79405176667.xf7125312c7ee115c.x52b190e626f65140(4116);
		x317be79405176667.xf7125312c7ee115c.x52b190e626f65140(4119);
		x317be79405176667.xf7125312c7ee115c.x52b190e626f65140(826);
		x317be79405176667.xf7125312c7ee115c.x52b190e626f65140(4118);
		x317be79405176667.xf7125312c7ee115c.x52b190e626f65140(4112);
		x317be79405176667.xf7125312c7ee115c.x52b190e626f65140(4114);
		x317be79405176667.xf7125312c7ee115c.x52b190e626f65140(4115);
		x317be79405176667.xf7125312c7ee115c.x52b190e626f65140(267);
	}

	internal override void xa2d8e36cb99ac0f4(x03f56b37a0050a82 x153c99a852375422)
	{
		switch (x153c99a852375422.x1dafd189c5465293())
		{
		case "\\objocx":
			x317be79405176667.x88d1b78392d1a0ab(ShapeType.OleControl);
			return;
		case "\\objlink":
			x45e96d759c9be282.SourceFullName = " ";
			return;
		case "\\objautlink":
			x45e96d759c9be282.SourceFullName = " ";
			x45e96d759c9be282.AutoUpdate = true;
			return;
		case "\\objw":
			x317be79405176667.xf524ccc95fe8e714(x4574ea26106f0edb.x0e1fdb362561ddb2(x153c99a852375422.xd6f9e3c5ae6509d7()));
			return;
		case "\\objh":
			x317be79405176667.x404ab2fc377ad1ed(x4574ea26106f0edb.x0e1fdb362561ddb2(x153c99a852375422.xd6f9e3c5ae6509d7()));
			return;
		case "\\rsltbmp":
			x45e96d759c9be282.x2e7d767f7d782a7a = x2e7d767f7d782a7a.x1351df7d00b0ea53;
			return;
		case "\\rslttxt":
			x45e96d759c9be282.x2e7d767f7d782a7a = x2e7d767f7d782a7a.xf9ad6fb78355fe13;
			return;
		case "\\rsltmerge":
			x45e96d759c9be282.x2e7d767f7d782a7a = x2e7d767f7d782a7a.xc6077c9598837311;
			return;
		case "\\rslthtml":
			x45e96d759c9be282.x2e7d767f7d782a7a = x2e7d767f7d782a7a.x4bc88de02db3a00d;
			return;
		case "\\rsltrtf":
			x45e96d759c9be282.x2e7d767f7d782a7a = x2e7d767f7d782a7a.x5896ed36f2cf9162;
			return;
		case "\\rsltpict":
			x45e96d759c9be282.x2e7d767f7d782a7a = x2e7d767f7d782a7a.x7f4d496937f8c24c;
			return;
		case "\\objsetsize":
		case "\\objalign":
		case "\\objtransy":
		case "\\objcropt":
		case "\\objcropb":
		case "\\objcropl":
		case "\\objcropr":
		case "\\objscalex":
		case "\\objscaley":
			x28fcdc775a1d069c.xbd5e5733680bbfc8(x153c99a852375422.x1dafd189c5465293());
			return;
		case "\\v":
			x317be79405176667.xeedad81aaed42a76.xae20093bed1e48a8(130, x153c99a852375422.xc55827845a964d45());
			return;
		}
		if (xd2232f6e138d881d())
		{
			base.xa2d8e36cb99ac0f4(x153c99a852375422);
		}
	}

	private bool xd2232f6e138d881d()
	{
		if (x840f959dd5025e96)
		{
			return true;
		}
		if (x45e96d759c9be282 == null)
		{
			return false;
		}
		return true;
	}

	internal override void xbd6083b329527c4e(x03f56b37a0050a82 x153c99a852375422)
	{
		switch (base.x1a55de3a01c1c82d.x3146d638ec378671)
		{
		case x25099a8bbbd55d1c.x6cd6dc0513e5244d:
			x45e96d759c9be282.ProgId = x153c99a852375422.x9f1a6a3451a38d10();
			return;
		case x25099a8bbbd55d1c.x018f01fdb01bb454:
			xb4520cdd2782a16a(x153c99a852375422);
			return;
		case x25099a8bbbd55d1c.xbc6c7d7118f5e7c4:
		case x25099a8bbbd55d1c.x6be4f63c3ffabe41:
		case x25099a8bbbd55d1c.x52c4f870b075506f:
			x28fcdc775a1d069c.xbd5e5733680bbfc8(base.x1a55de3a01c1c82d.x759aa16c2016a289);
			return;
		}
		if (xd2232f6e138d881d())
		{
			base.xbd6083b329527c4e(x153c99a852375422);
		}
	}

	private void xb4520cdd2782a16a(x03f56b37a0050a82 x153c99a852375422)
	{
		byte[] buffer = x153c99a852375422.xbfeb690f3f95a932();
		BinaryReader xe134235b3526fa = new BinaryReader(new MemoryStream(buffer), Encoding.ASCII);
		x320b28ae68e47317 x320b28ae68e = x320b28ae68e47317.x06b0e25aa6ad68a9(xe134235b3526fa, 1252);
		if (!x0d299f323d241756.x5959bccb67bbf051(x45e96d759c9be282.ProgId))
		{
			x45e96d759c9be282.ProgId = x320b28ae68e.x570858a97a5a2c4a;
		}
		if (x320b28ae68e.xcfc06e7ce72a0f0b == x1ba6afab4f42a0ee.x1891c445b78b044b)
		{
			x8844513eda0a5d2e x8844513eda0a5d2e = (x8844513eda0a5d2e)x320b28ae68e;
			x45e96d759c9be282.SourceFullName = x8844513eda0a5d2e.xbd11df86767e08a3;
			x45e96d759c9be282.SourceItem = x8844513eda0a5d2e.x73cf5fe9b727ba52;
			return;
		}
		xfa9b77033f6e5e27 xfa9b77033f6e5e = (xfa9b77033f6e5e27)x320b28ae68e;
		byte[] x6a3df4ad78faf19b = xfa9b77033f6e5e.x6a3df4ad78faf19b;
		MemoryStream stream = (xd8c3135513b9115b.x995d1a25f2eac7ea(x6a3df4ad78faf19b, 4) ? new MemoryStream(x6a3df4ad78faf19b) : x9ac0da7388ceac43.x0c9f09d67b375fe9(x45e96d759c9be282.ProgId, x6a3df4ad78faf19b));
		xd8c3135513b9115b xd8c3135513b9115b = new xd8c3135513b9115b(stream);
		x45e96d759c9be282.x58932c7e6fa3b905 = new x71d39fdf56861cca(x28fcdc775a1d069c.x3031d94a4c859cd6(), xd8c3135513b9115b.x29e7ace4c90f74cd);
		if (x45e96d759c9be282.IsLink)
		{
			x64d2e942085ade70 x64d2e942085ade = new x64d2e942085ade70(xd8c3135513b9115b.x29e7ace4c90f74cd);
			x45e96d759c9be282.SourceFullName = x64d2e942085ade.xbd11df86767e08a3;
			x45e96d759c9be282.SourceItem = x64d2e942085ade.x73cf5fe9b727ba52;
		}
	}

	internal override x77fb5b1d5c73757b x3e0bce851c12a688(xbf575e106f2f2373 x8d3f74e5f925679c)
	{
		switch (x8d3f74e5f925679c.x3146d638ec378671)
		{
		case x25099a8bbbd55d1c.x6cd6dc0513e5244d:
		case x25099a8bbbd55d1c.xd09757579a9e7eef:
		case x25099a8bbbd55d1c.xbc6c7d7118f5e7c4:
		case x25099a8bbbd55d1c.x6be4f63c3ffabe41:
		case x25099a8bbbd55d1c.x52c4f870b075506f:
			return this;
		case x25099a8bbbd55d1c.x018f01fdb01bb454:
			if (base.x1a55de3a01c1c82d.x3146d638ec378671 != x25099a8bbbd55d1c.x71d39fdf56861cca)
			{
				return null;
			}
			return this;
		case x25099a8bbbd55d1c.x7f4d496937f8c24c:
			return new xc71a5c7f64b2230d(x28fcdc775a1d069c, x317be79405176667);
		default:
			return base.x3e0bce851c12a688(x8d3f74e5f925679c);
		}
	}
}
