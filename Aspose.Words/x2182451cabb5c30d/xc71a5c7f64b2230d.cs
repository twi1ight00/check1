using System;
using System.Drawing;
using Aspose;
using Aspose.Words;
using Aspose.Words.Drawing;
using x011d489fb9df7027;
using x13f1efc79617a47b;
using x38a89dee67fc7a16;
using x6c95d9cf46ff5f25;
using x884584cc69c5c378;
using xa7850104c8d8c135;

namespace x2182451cabb5c30d;

internal class xc71a5c7f64b2230d : x77fb5b1d5c73757b
{
	private const double xd3fdd5cbe2762f81 = 216.0;

	private Shape x317be79405176667;

	private int xe22857bcbfe45de5;

	private bool xb565a4352befeb83;

	private bool x5c0098dceab7194c;

	private bool x59a4e62a1f90f4e1;

	private int x62e0cb0e66f284ac;

	private int x57002ce6d61b5e41;

	private int x4b64415da58db335;

	private int xa52dc9e8dabad06e;

	private int x2a2374f227e6e468;

	private int x28cb01a0087a0397;

	private int xcfd0a8f56018035e;

	private int xc8990fbd499ea2a0;

	private int xd28675ce3467238f;

	private int x8da4227161459355;

	private int x324a4d4da800de4a;

	private int x0532dd7a0f7d0d7f;

	private int xda3af8c49890009d;

	private readonly x8a31fc9888704a72 xac44741bdb344b18;

	private bool xd209f0856b9d045d;

	private bool xc3008572421112e9
	{
		get
		{
			if (xd209f0856b9d045d && (x28cb01a0087a0397 <= 0 || xcfd0a8f56018035e <= 0))
			{
				if (xa52dc9e8dabad06e > 0)
				{
					return x2a2374f227e6e468 > 0;
				}
				return false;
			}
			return true;
		}
	}

	internal override bool x700ee24405039e9a => true;

	internal Shape xa9993ed2e0c64574 => x317be79405176667;

	private xf7125312c7ee115c xf7125312c7ee115c => x317be79405176667.xf7125312c7ee115c;

	internal xc71a5c7f64b2230d(xe5e546ef5f0503b2 context, Shape shape, int attr)
		: base(context)
	{
		x317be79405176667 = shape;
		xe22857bcbfe45de5 = attr;
		xb565a4352befeb83 = false;
		xac44741bdb344b18 = new x8a31fc9888704a72(context);
		xd209f0856b9d045d = false;
	}

	internal xc71a5c7f64b2230d(xe5e546ef5f0503b2 context, Shape shape)
		: this(context, shape, shouldEndShape: false)
	{
	}

	internal xc71a5c7f64b2230d(xe5e546ef5f0503b2 context, Shape shape, bool shouldEndShape)
		: base(context)
	{
		x317be79405176667 = shape;
		x5c0098dceab7194c = shouldEndShape;
		xb565a4352befeb83 = true;
		xac44741bdb344b18 = new x8a31fc9888704a72(context);
	}

	[JavaThrows(true)]
	internal override void xa4085ff83f9ddeeb()
	{
		if (base.x1a55de3a01c1c82d.x3146d638ec378671 == x25099a8bbbd55d1c.x7f4d496937f8c24c && xb565a4352befeb83)
		{
			if (!x317be79405176667.x8934557a18f73b70)
			{
				x75ac0afde80b0e8a();
				x5846084bb3a596db();
			}
			if (x5c0098dceab7194c)
			{
				base.xe1410f585439c7d4.x63fb29d61f50770e(x317be79405176667);
			}
		}
	}

	private void x75ac0afde80b0e8a()
	{
		int num = 0;
		int num2 = 0;
		if (x28cb01a0087a0397 > 0 && xcfd0a8f56018035e > 0)
		{
			num = x28cb01a0087a0397;
			num2 = xcfd0a8f56018035e;
		}
		else if (xa52dc9e8dabad06e > 0 && x2a2374f227e6e468 > 0)
		{
			num = x4574ea26106f0edb.x7d6de2a14bd3fd11((double)xa52dc9e8dabad06e / 100.0);
			num2 = x4574ea26106f0edb.x7d6de2a14bd3fd11((double)x2a2374f227e6e468 / 100.0);
		}
		else if (x317be79405176667.x169baa05e57bf312)
		{
			ImageSize imageSize = x317be79405176667.ImageData.ImageSize;
			if (imageSize.x22ab5dfa6f12e902)
			{
				num = imageSize.x2293d3e399e86e50;
				num2 = imageSize.x2a8c8b799b415917;
			}
		}
		if (xc3008572421112e9)
		{
			if (xc8990fbd499ea2a0 <= 0)
			{
				xc8990fbd499ea2a0 = 100;
			}
			if (xd28675ce3467238f <= 0)
			{
				xd28675ce3467238f = 100;
			}
		}
		num = num - x8da4227161459355 - x324a4d4da800de4a;
		num2 = num2 - x0532dd7a0f7d0d7f - xda3af8c49890009d;
		double num3 = x4574ea26106f0edb.x0e1fdb362561ddb2(num) * (double)xc8990fbd499ea2a0 / 100.0;
		double num4 = x4574ea26106f0edb.x0e1fdb362561ddb2(num2) * (double)xd28675ce3467238f / 100.0;
		if (x317be79405176667.x169baa05e57bf312)
		{
			if (num3 == 0.0)
			{
				num3 = 216.0;
			}
			if (num4 == 0.0)
			{
				num4 = 216.0;
			}
		}
		SizeF x0ceec69a97f = new SizeF((float)num3, (float)num4);
		if (x317be79405176667.IsTopLevel)
		{
			x0ceec69a97f = x409512556c3f2a9a.x71b0f13c06d08cd9(x0ceec69a97f, x317be79405176667.Rotation);
		}
		x317be79405176667.xf524ccc95fe8e714(x0ceec69a97f.Width);
		x317be79405176667.x404ab2fc377ad1ed(x0ceec69a97f.Height);
		x317be79405176667.x4ad54dc2280f4b6f();
	}

	private void x5846084bb3a596db()
	{
		if (!x317be79405176667.x169baa05e57bf312)
		{
			return;
		}
		ImageSize imageSize = x317be79405176667.ImageData.ImageSize;
		if (imageSize.x22ab5dfa6f12e902)
		{
			if (x8da4227161459355 != 0)
			{
				xf7125312c7ee115c.xae20093bed1e48a8(258, x4574ea26106f0edb.x091b250f00534aae((double)x8da4227161459355 / (double)imageSize.x2293d3e399e86e50));
			}
			if (x324a4d4da800de4a != 0)
			{
				xf7125312c7ee115c.xae20093bed1e48a8(259, x4574ea26106f0edb.x091b250f00534aae((double)x324a4d4da800de4a / (double)imageSize.x2293d3e399e86e50));
			}
			if (x0532dd7a0f7d0d7f != 0)
			{
				xf7125312c7ee115c.xae20093bed1e48a8(256, x4574ea26106f0edb.x091b250f00534aae((double)x0532dd7a0f7d0d7f / (double)imageSize.x2a8c8b799b415917));
			}
			if (xda3af8c49890009d != 0)
			{
				xf7125312c7ee115c.xae20093bed1e48a8(257, x4574ea26106f0edb.x091b250f00534aae((double)xda3af8c49890009d / (double)imageSize.x2a8c8b799b415917));
			}
		}
	}

	internal override void xa2d8e36cb99ac0f4(x03f56b37a0050a82 x153c99a852375422)
	{
		switch (x153c99a852375422.x1dafd189c5465293())
		{
		case "\\bin":
			x7debc73bf6a9d65e(x153c99a852375422.xd181aea83ad73c96);
			break;
		case "\\picw":
			xa52dc9e8dabad06e = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\pich":
			x2a2374f227e6e468 = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\picwgoal":
		case "\\picwGoal":
			x28cb01a0087a0397 = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\pichgoal":
		case "\\pichGoal":
			xcfd0a8f56018035e = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\picscalex":
			xc8990fbd499ea2a0 = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\picscaley":
			xd28675ce3467238f = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\piccropl":
			x8da4227161459355 = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\piccropr":
			x324a4d4da800de4a = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\piccropt":
			x0532dd7a0f7d0d7f = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\piccropb":
			xda3af8c49890009d = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\bliptag":
			x2344e6beb2348b54(x153c99a852375422.xd6f9e3c5ae6509d7());
			break;
		case "\\brdrl":
			x28fcdc775a1d069c.x51d60f077c5fc6e0 = x317be79405176667.ImageData.Borders[BorderType.Left];
			break;
		case "\\brdrr":
			x28fcdc775a1d069c.x51d60f077c5fc6e0 = x317be79405176667.ImageData.Borders[BorderType.Right];
			break;
		case "\\brdrt":
			x28fcdc775a1d069c.x51d60f077c5fc6e0 = x317be79405176667.ImageData.Borders[BorderType.Top];
			break;
		case "\\brdrb":
			x28fcdc775a1d069c.x51d60f077c5fc6e0 = x317be79405176667.ImageData.Borders[BorderType.Bottom];
			break;
		case "\\wbitmap":
			if (x153c99a852375422.xd6f9e3c5ae6509d7() != 0)
			{
				throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("iglbajccmijcceadmihdfdodnhfenhmelhdfaikfgcbglgigpgpgehghkbnhlgeidglibbcjgfjjmeakgfhkjeokoefleemlmpcmldkmpdbnheinndpnocgokdnohodpidlpkdcaocjaacabingbecobgcfchbmcbbddlbkdgmaehbieiapeopffianfhldgemkgblbhgpihapphkpgikonialej", 1697782564)));
			}
			x59a4e62a1f90f4e1 = true;
			break;
		case "\\wbmbitspixel":
			x62e0cb0e66f284ac = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\wbmplanes":
			x57002ce6d61b5e41 = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\wbmwidthbytes":
			x4b64415da58db335 = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		default:
			xac44741bdb344b18.x06b0e25aa6ad68a9(x153c99a852375422);
			break;
		}
	}

	private void x2344e6beb2348b54(int xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111 > 0 && xbcea506a33cf9111 < 255)
		{
			xf7125312c7ee115c.xae20093bed1e48a8(4122, (x10884bb8036bcee0)xbcea506a33cf9111);
		}
		else
		{
			xf7125312c7ee115c.xae20093bed1e48a8(4122, x10884bb8036bcee0.x1a23317d325de634);
		}
	}

	internal override void xbd6083b329527c4e(x03f56b37a0050a82 x153c99a852375422)
	{
		if (base.x1a55de3a01c1c82d.x3146d638ec378671 == x25099a8bbbd55d1c.x7f4d496937f8c24c)
		{
			x7debc73bf6a9d65e(x153c99a852375422.xbfeb690f3f95a932());
		}
	}

	private void x7debc73bf6a9d65e(byte[] x43e181e083db6cdf)
	{
		if (x43e181e083db6cdf.Length == 0)
		{
			return;
		}
		if (x59a4e62a1f90f4e1)
		{
			int x95621538cdd84e0c = (int)(56692.913385826774 / (double)x28cb01a0087a0397 * (double)xa52dc9e8dabad06e);
			int xc96b6f9ff71ab = (int)(56692.913385826774 / (double)xcfd0a8f56018035e * (double)x2a2374f227e6e468);
			x43e181e083db6cdf = xdd1b8f14cc8ba86d.xaef648f0fd1e5f8e(xa52dc9e8dabad06e, x2a2374f227e6e468, x95621538cdd84e0c, xc96b6f9ff71ab, x57002ce6d61b5e41, x62e0cb0e66f284ac, x4b64415da58db335, x43e181e083db6cdf);
		}
		else if (xdd1b8f14cc8ba86d.xc1b340365f5fd1f7(x43e181e083db6cdf) || xdd1b8f14cc8ba86d.xb9c89ee787d0f8de(x43e181e083db6cdf))
		{
			x3fa09e8d7b952fbc x3fa09e8d7b952fbc = new x3fa09e8d7b952fbc(x43e181e083db6cdf);
			byte[] array = x3fa09e8d7b952fbc.x4e7f5d5a42ec39f1();
			if (array != null)
			{
				x43e181e083db6cdf = array;
				xd209f0856b9d045d = true;
			}
		}
		if (xdd1b8f14cc8ba86d.xa112135733098ff7(x43e181e083db6cdf))
		{
			xa2745adfabe0c674 x95dac044246123ac = xa2745adfabe0c674.xe6a756f8b9f6fe18(x4574ea26106f0edb.xfcf9c235b4aef277((double)xa52dc9e8dabad06e / 100.0), x4574ea26106f0edb.xfcf9c235b4aef277((double)x2a2374f227e6e468 / 100.0), 96.0, 96.0);
			x43e181e083db6cdf = xdd1b8f14cc8ba86d.x300bc69d382eb52c(x43e181e083db6cdf, x95dac044246123ac);
		}
		if (xb565a4352befeb83)
		{
			if (!x317be79405176667.IsWordArt)
			{
				x317be79405176667.ImageData.x7a0cb9855dd2eab1(x43e181e083db6cdf);
			}
		}
		else
		{
			xf7125312c7ee115c.xae20093bed1e48a8(xe22857bcbfe45de5, x43e181e083db6cdf);
		}
	}

	internal override x77fb5b1d5c73757b x3e0bce851c12a688(xbf575e106f2f2373 x8d3f74e5f925679c)
	{
		x25099a8bbbd55d1c x3146d638ec = x8d3f74e5f925679c.x3146d638ec378671;
		if (x3146d638ec == x25099a8bbbd55d1c.xf7c62d7842139957)
		{
			if (x317be79405176667.xa170cce2bc40bdf5)
			{
				return null;
			}
			return new x7210e80256b3610c(x28fcdc775a1d069c, x317be79405176667, !x5c0098dceab7194c);
		}
		return null;
	}
}
