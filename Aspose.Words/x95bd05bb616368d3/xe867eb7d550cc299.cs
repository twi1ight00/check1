using x6c95d9cf46ff5f25;
using x8bb6b4f09b5230a5;
using xa6cc8e39f9a280d7;
using xe5b61ba6cfc93cea;

namespace x95bd05bb616368d3;

internal class xe867eb7d550cc299 : xaaf059f0543cf507, x680f1b8709e9ba2a
{
	private xaeaeae8d38ef57bb x827e895033b76e5e;

	public xaeaeae8d38ef57bb xd98b6fc8af69e348
	{
		get
		{
			if (x827e895033b76e5e == null)
			{
				x827e895033b76e5e = new xd13db1e4c9fb8129(base.xca687bd498227c89);
			}
			return x827e895033b76e5e;
		}
		set
		{
			x827e895033b76e5e = value;
		}
	}

	public xe867eb7d550cc299(xe9481907c579c280 serviceLocator)
		: base(serviceLocator)
	{
	}

	public xa66a49a54c0cb12b xda09af88ab899a50(xc1dcd6189d01216e xe134235b3526fa75)
	{
		x4c28ef76f151d171(xe134235b3526fa75);
		if (x7450cc1e48712286.xa66385d80d4d296f != "style")
		{
			return null;
		}
		xa66a49a54c0cb12b xa66a49a54c0cb12b = new xa66a49a54c0cb12b();
		while (x7450cc1e48712286.x152cbadbfa8061b1("style"))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "effectRef":
				xa66a49a54c0cb12b.x9de4c7af36389395 = xe733cf2563de7f58();
				break;
			case "fillRef":
				xa66a49a54c0cb12b.x27530fd35f9b1774 = xf877c45e042220a1();
				break;
			case "fontRef":
				xa66a49a54c0cb12b.x129bfeeb7923cd16 = xe702706242977c43();
				break;
			case "lnRef":
				xa66a49a54c0cb12b.x7cb20a4137cdfdcc = x46316c4d26f85a2b();
				break;
			default:
				xf4732ad4641eec1a();
				break;
			}
		}
		return xa66a49a54c0cb12b;
	}

	private x05d25083ee1e07b8 x46316c4d26f85a2b()
	{
		x05d25083ee1e07b8 x05d25083ee1e07b = new x05d25083ee1e07b8();
		x05d25083ee1e07b.x1aeff1183939b437 = x7450cc1e48712286.xe8602379c60acf13("idx", 0);
		xe9ec0d312c7ffff2(x05d25083ee1e07b);
		return x05d25083ee1e07b;
	}

	private xd98611d1d2ce68f4 xe702706242977c43()
	{
		xd98611d1d2ce68f4 xd98611d1d2ce68f = new xd98611d1d2ce68f4();
		switch (x7450cc1e48712286.xd68abcd61e368af9("idx", string.Empty))
		{
		case "major":
			xd98611d1d2ce68f.x13553ffa465daccd = xd47ba8fa51a96eb4.xb12b26d90e429bbf;
			break;
		case "minor":
			xd98611d1d2ce68f.x13553ffa465daccd = xd47ba8fa51a96eb4.xa0df9730817e2e11;
			break;
		case "none":
			xd98611d1d2ce68f.x13553ffa465daccd = xd47ba8fa51a96eb4.x4d0b9d4447ba7566;
			break;
		}
		xe9ec0d312c7ffff2(xd98611d1d2ce68f);
		return xd98611d1d2ce68f;
	}

	private x75ae4c01db1bba1b xf877c45e042220a1()
	{
		x75ae4c01db1bba1b x75ae4c01db1bba1b = new x75ae4c01db1bba1b();
		x75ae4c01db1bba1b.x1aeff1183939b437 = x7450cc1e48712286.xe8602379c60acf13("idx", 0);
		xe9ec0d312c7ffff2(x75ae4c01db1bba1b);
		return x75ae4c01db1bba1b;
	}

	private xa50e01cc712865ad xe733cf2563de7f58()
	{
		xa50e01cc712865ad xa50e01cc712865ad = new xa50e01cc712865ad();
		xa50e01cc712865ad.x1aeff1183939b437 = x7450cc1e48712286.xe8602379c60acf13("idx", 0);
		xe9ec0d312c7ffff2(xa50e01cc712865ad);
		return xa50e01cc712865ad;
	}

	private void xe9ec0d312c7ffff2(x3f3baa9ffdb01f3b xa860e35844c20ac7)
	{
		string xa66385d80d4d296f = x7450cc1e48712286.xa66385d80d4d296f;
		while (x7450cc1e48712286.x152cbadbfa8061b1(xa66385d80d4d296f))
		{
			xd7e8497b32a408b8 xd7e8497b32a408b = xd98b6fc8af69e348.xda09af88ab899a50(x7450cc1e48712286);
			if (xd7e8497b32a408b != null)
			{
				xa860e35844c20ac7.x9b41425268471380 = xd7e8497b32a408b;
			}
		}
	}
}
