using System;
using System.Drawing.Drawing2D;
using x13f1efc79617a47b;

namespace x5794c252ba25e723;

internal class x31c19fcb724dfaf5
{
	private static readonly float[] xe8f5ec37f4f58fdd = new float[2] { 3f, 1f };

	private static readonly float[] x212dbbb3d349065e = new float[4] { 3f, 1f, 1f, 1f };

	private static readonly float[] xcf4ea18295d0d9af = new float[6] { 3f, 1f, 1f, 1f, 1f, 1f };

	private static readonly float[] x34a10350f9f79bfd = new float[2] { 1f, 1f };

	private static readonly float[] x41a174bca277c948 = new float[0];

	private PenAlignment xbe63ce924b03850f;

	private x845d6a068e0b03c5 xa31c8fed8093bc20;

	private float[] x94a880cb37e1668e = x41a174bca277c948;

	private DashCap xbe9c6ab5bcc24a2a;

	private float x4a4f8652c99d2e57;

	private float[] x2b01997a63132b03 = x41a174bca277c948;

	private DashStyle x61c902216478c7ad;

	private LineCap x34a69ca70dc2c2e0;

	private LineJoin x51104a936cd0965a;

	private float xe32c7c8fa55531f6 = 10f;

	private LineCap x079a19ca679c9880;

	private float xd74c65b8d28b1740 = 1f;

	public PenAlignment x9ba359ff37a3a63b
	{
		get
		{
			return xbe63ce924b03850f;
		}
		set
		{
			xbe63ce924b03850f = value;
		}
	}

	public float xdc1bf80853046136
	{
		get
		{
			return xd74c65b8d28b1740;
		}
		set
		{
			xd74c65b8d28b1740 = value;
		}
	}

	public LineCap x1e0dcb2cdd562cb2
	{
		get
		{
			return x079a19ca679c9880;
		}
		set
		{
			x079a19ca679c9880 = value;
		}
	}

	public LineCap xec7c14446b693774
	{
		get
		{
			return x34a69ca70dc2c2e0;
		}
		set
		{
			x34a69ca70dc2c2e0 = value;
		}
	}

	public LineJoin x03a8df074279275f
	{
		get
		{
			return x51104a936cd0965a;
		}
		set
		{
			x51104a936cd0965a = value;
		}
	}

	public x845d6a068e0b03c5 x60465f602599d327
	{
		get
		{
			return xa31c8fed8093bc20;
		}
		set
		{
			xa31c8fed8093bc20 = value;
		}
	}

	public float x3372c2e5fab45e9a
	{
		get
		{
			return xe32c7c8fa55531f6;
		}
		set
		{
			xe32c7c8fa55531f6 = value;
		}
	}

	public float xc19b368b60309472
	{
		get
		{
			return x4a4f8652c99d2e57;
		}
		set
		{
			x4a4f8652c99d2e57 = value;
		}
	}

	public DashCap x9526ba50e2183e01
	{
		get
		{
			return xbe9c6ab5bcc24a2a;
		}
		set
		{
			xbe9c6ab5bcc24a2a = value;
		}
	}

	public DashStyle xca08e8eb525b8a1a
	{
		get
		{
			return x61c902216478c7ad;
		}
		set
		{
			x61c902216478c7ad = value;
			switch (x61c902216478c7ad)
			{
			case DashStyle.Solid:
				x2b01997a63132b03 = x41a174bca277c948;
				break;
			case DashStyle.Dash:
				x2b01997a63132b03 = xe8f5ec37f4f58fdd;
				break;
			case DashStyle.DashDot:
				x2b01997a63132b03 = x212dbbb3d349065e;
				break;
			case DashStyle.DashDotDot:
				x2b01997a63132b03 = xcf4ea18295d0d9af;
				break;
			case DashStyle.Dot:
				x2b01997a63132b03 = x34a10350f9f79bfd;
				break;
			default:
				throw new ArgumentException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("oaldecceobjeobafmbhfbcoffbfgemlgfadhppjhoabiaaiifloifagjdanjfaekfpkkloblblil", 1880898233)));
			case DashStyle.Custom:
				break;
			}
		}
	}

	public float[] x358988d12e56bf69
	{
		get
		{
			return x2b01997a63132b03;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			x2b01997a63132b03 = value;
			x61c902216478c7ad = DashStyle.Custom;
		}
	}

	public float[] x6fd1e71abf8b8121
	{
		get
		{
			return x94a880cb37e1668e;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			x94a880cb37e1668e = value;
		}
	}

	public x31c19fcb724dfaf5()
	{
	}

	public x31c19fcb724dfaf5(x26d9ecb4bdf0456d color)
		: this(color, 1f)
	{
	}

	public x31c19fcb724dfaf5(x26d9ecb4bdf0456d color, float width)
		: this(new xc020fa2f5133cba8(color), width)
	{
	}

	public x31c19fcb724dfaf5(x845d6a068e0b03c5 brush)
		: this(brush, 1f)
	{
	}

	public x31c19fcb724dfaf5(x845d6a068e0b03c5 brush, float width)
	{
		if (brush == null)
		{
			throw new ArgumentNullException("brush");
		}
		xa31c8fed8093bc20 = brush;
		xd74c65b8d28b1740 = width;
	}

	public x31c19fcb724dfaf5 xfe8f67360e300e88()
	{
		return (x31c19fcb724dfaf5)MemberwiseClone();
	}
}
