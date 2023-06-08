using System.Text;
using Aspose.Words.Settings;
using x28925c9b27b37a46;
using x556d8f9846e43329;

namespace x2182451cabb5c30d;

internal class xb12e85764fe123c7 : x3b57052406b93b82
{
	private OdsoFieldMapData x20663473a2028730;

	private OdsoRecipientData x4411de89c59af82e;

	private x25099a8bbbd55d1c x164c19a26a4543bf => x28fcdc775a1d069c.xa3a0cc3e91617aca.xffb3238a8fd59aa7.x1a55de3a01c1c82d.x3146d638ec378671;

	private Odso xfc1e3dd58fb9e14e => x28fcdc775a1d069c.x2c8c6741422a1298.xdade2366eaa6f915.xe690cef2446c7d46.Odso;

	internal xb12e85764fe123c7(xe5e546ef5f0503b2 context)
		: base(context)
	{
		x28fcdc775a1d069c.x2c8c6741422a1298.xdade2366eaa6f915.xe690cef2446c7d46.Odso = new Odso();
	}

	internal override void x41e7a76e7e854e6e(x03f56b37a0050a82 x153c99a852375422)
	{
		switch (x164c19a26a4543bf)
		{
		case x25099a8bbbd55d1c.x1aef7be8aa383af6:
			x20663473a2028730 = new OdsoFieldMapData();
			break;
		case x25099a8bbbd55d1c.x3976e431ed643e92:
			x4411de89c59af82e = new OdsoRecipientData();
			break;
		default:
			base.x41e7a76e7e854e6e(x153c99a852375422);
			break;
		}
	}

	internal override void xa4085ff83f9ddeeb()
	{
		switch (x164c19a26a4543bf)
		{
		case x25099a8bbbd55d1c.x1aef7be8aa383af6:
			xfc1e3dd58fb9e14e.FieldMapDatas.Add(x20663473a2028730);
			break;
		case x25099a8bbbd55d1c.x3976e431ed643e92:
			xfc1e3dd58fb9e14e.RecipientDatas.Add(x4411de89c59af82e);
			break;
		default:
			base.xa4085ff83f9ddeeb();
			break;
		}
	}

	internal override void xa2d8e36cb99ac0f4(x03f56b37a0050a82 x153c99a852375422)
	{
		switch (x164c19a26a4543bf)
		{
		case x25099a8bbbd55d1c.x1aef7be8aa383af6:
			xacd5cedf750ed483(x153c99a852375422);
			break;
		case x25099a8bbbd55d1c.x3976e431ed643e92:
			x1d20960eea253ca4(x153c99a852375422);
			break;
		case x25099a8bbbd55d1c.x207bba6610a1ab10:
			x5797a12f64f43ce2(x153c99a852375422);
			break;
		default:
			base.xa2d8e36cb99ac0f4(x153c99a852375422);
			break;
		}
	}

	internal override void xbd6083b329527c4e(x03f56b37a0050a82 x153c99a852375422)
	{
		switch (x164c19a26a4543bf)
		{
		case x25099a8bbbd55d1c.xc1cc2fbe658cf21a:
			if (xfc1e3dd58fb9e14e.UdlConnectString == string.Empty)
			{
				xfc1e3dd58fb9e14e.UdlConnectString = x153c99a852375422.x9f1a6a3451a38d10();
			}
			break;
		case x25099a8bbbd55d1c.x4a4644de25ba0eaa:
			xfc1e3dd58fb9e14e.UdlConnectString = Encoding.Unicode.GetString(x153c99a852375422.xbfeb690f3f95a932());
			break;
		case x25099a8bbbd55d1c.xdeedfa0324e21cd9:
			xfc1e3dd58fb9e14e.TableName = x153c99a852375422.x9f1a6a3451a38d10();
			break;
		case x25099a8bbbd55d1c.x4d675c3b2fb690dc:
			xfc1e3dd58fb9e14e.DataSource = x153c99a852375422.x9f1a6a3451a38d10();
			break;
		case x25099a8bbbd55d1c.x1aef7be8aa383af6:
		case x25099a8bbbd55d1c.xccccdc9b772c0fc1:
		case x25099a8bbbd55d1c.x27d55b75fcfbf72e:
			x54b25e88f94cc6b4(x153c99a852375422);
			break;
		case x25099a8bbbd55d1c.x582203348a135651:
			x4411de89c59af82e.UniqueTag = Encoding.Unicode.GetBytes(x153c99a852375422.x9f1a6a3451a38d10());
			break;
		default:
			base.xbd6083b329527c4e(x153c99a852375422);
			break;
		case x25099a8bbbd55d1c.x763db4b39a6c2c51:
		case x25099a8bbbd55d1c.x90f4d60b43bb0e73:
			break;
		}
	}

	internal override x77fb5b1d5c73757b x3e0bce851c12a688(xbf575e106f2f2373 x8d3f74e5f925679c)
	{
		switch (x8d3f74e5f925679c.x3146d638ec378671)
		{
		case x25099a8bbbd55d1c.xc1cc2fbe658cf21a:
		case x25099a8bbbd55d1c.x4a4644de25ba0eaa:
		case x25099a8bbbd55d1c.xdeedfa0324e21cd9:
		case x25099a8bbbd55d1c.x4d675c3b2fb690dc:
		case x25099a8bbbd55d1c.x763db4b39a6c2c51:
		case x25099a8bbbd55d1c.x90f4d60b43bb0e73:
		case x25099a8bbbd55d1c.x1aef7be8aa383af6:
		case x25099a8bbbd55d1c.xccccdc9b772c0fc1:
		case x25099a8bbbd55d1c.x27d55b75fcfbf72e:
		case x25099a8bbbd55d1c.x3976e431ed643e92:
		case x25099a8bbbd55d1c.x582203348a135651:
			return this;
		default:
			return base.x3e0bce851c12a688(x8d3f74e5f925679c);
		}
	}

	private void x5797a12f64f43ce2(x03f56b37a0050a82 x153c99a852375422)
	{
		switch (x153c99a852375422.x1dafd189c5465293())
		{
		case "\\mmodsocoldelim":
			xfc1e3dd58fb9e14e.ColumnDelimiter = (char)x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\mmjdsotype":
			xfc1e3dd58fb9e14e.DataSourceType = (OdsoDataSourceType)x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\mmodsofhdr":
			xfc1e3dd58fb9e14e.FirstRowContainsColumnNames = x153c99a852375422.x1ad7968449b109cd();
			break;
		}
	}

	private void x1d20960eea253ca4(x03f56b37a0050a82 x153c99a852375422)
	{
		switch (x153c99a852375422.x1dafd189c5465293())
		{
		case "\\mmodsocolumn":
			x4411de89c59af82e.Column = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\mmodsoactive":
			x4411de89c59af82e.Active = x153c99a852375422.x1ad7968449b109cd();
			break;
		case "\\mmodsohash":
			x4411de89c59af82e.Hash = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		}
	}

	private void x54b25e88f94cc6b4(x03f56b37a0050a82 x153c99a852375422)
	{
		switch (x164c19a26a4543bf)
		{
		case x25099a8bbbd55d1c.x27d55b75fcfbf72e:
			x20663473a2028730.MappedName = x153c99a852375422.x9f1a6a3451a38d10();
			break;
		case x25099a8bbbd55d1c.xccccdc9b772c0fc1:
			x20663473a2028730.Name = x153c99a852375422.x9f1a6a3451a38d10();
			break;
		}
	}

	private void xacd5cedf750ed483(x03f56b37a0050a82 x153c99a852375422)
	{
		switch (x153c99a852375422.x1dafd189c5465293())
		{
		case "\\mmfttypenull":
		case "\\mmfttypedbcolumn":
		case "\\mmfttypeaddress":
		case "\\mmfttypesalutation":
		case "\\mmfttypemapped":
		case "\\mmfttypebarcode":
			x20663473a2028730.Type = xa0d3611565b2a1f2.x2e9471c187353611(x153c99a852375422.x1dafd189c5465293());
			break;
		case "\\mmodsofmcolumn":
			x20663473a2028730.xc68740e2faa12e13(x153c99a852375422.xd6f9e3c5ae6509d7());
			break;
		case "\\mmodsodynaddr":
			x20663473a2028730.x3fe67f230278a6df = x153c99a852375422.x1ad7968449b109cd();
			break;
		case "\\mmodsolid":
			x20663473a2028730.x448900fcb384c333 = (x448900fcb384c333)x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		}
	}
}
