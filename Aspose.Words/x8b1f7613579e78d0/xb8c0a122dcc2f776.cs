using System.Drawing;
using System.Drawing.Drawing2D;
using x0a3ff9616df4cd36;
using x38a89dee67fc7a16;
using x5794c252ba25e723;
using xa6cc8e39f9a280d7;

namespace x8b1f7613579e78d0;

internal class xb8c0a122dcc2f776 : x48d7478d49393961
{
	private x241ec192a9b04589 x1e85e97d2d60083b;

	private xc9689b5f2fdc3c03 xb16dd6e84ef2f792;

	private uint xbb5b9011fc78f659;

	private bool xd9fece4c46822c29;

	private x60eea316590e7fe7 x6ad1ca1cd79b3b95 = new x60eea316590e7fe7();

	private xfb58278c3b8ccfea x6e6a4a95f5a2ee43;

	public x241ec192a9b04589 x90c6e45466e5b849
	{
		get
		{
			if (x1e85e97d2d60083b == null)
			{
				x1e85e97d2d60083b = new x241ec192a9b04589();
			}
			return x1e85e97d2d60083b;
		}
		set
		{
			x1e85e97d2d60083b = value;
		}
	}

	public uint xf6a4131d6347f6d5
	{
		get
		{
			return xbb5b9011fc78f659;
		}
		set
		{
			xbb5b9011fc78f659 = value;
		}
	}

	public bool x3012fceed1fc4fbf
	{
		get
		{
			return xd9fece4c46822c29;
		}
		set
		{
			xd9fece4c46822c29 = value;
		}
	}

	public x60eea316590e7fe7 x38f7d62de9bd2349
	{
		get
		{
			if (x6ad1ca1cd79b3b95 == null)
			{
				x6ad1ca1cd79b3b95 = new x60eea316590e7fe7();
			}
			return x6ad1ca1cd79b3b95;
		}
		set
		{
			x6ad1ca1cd79b3b95 = value;
		}
	}

	public xc9689b5f2fdc3c03 x5817d0e429334953
	{
		get
		{
			if (xb16dd6e84ef2f792 == null)
			{
				xb16dd6e84ef2f792 = new x3a60f72bd240f5dc();
			}
			return xb16dd6e84ef2f792;
		}
		set
		{
			xb16dd6e84ef2f792 = value;
		}
	}

	internal xfb58278c3b8ccfea xb2bd46daa9daeaa9
	{
		get
		{
			if (x6e6a4a95f5a2ee43 == null)
			{
				x6e6a4a95f5a2ee43 = new xf0fba9688c8e31e8();
			}
			return x6e6a4a95f5a2ee43;
		}
		set
		{
			x6e6a4a95f5a2ee43 = value;
		}
	}

	public override x845d6a068e0b03c5 CreateBrush(x8b545195dd56c1c7 brushRenderingContext)
	{
		byte[] array = x90c6e45466e5b849.x601e9a2243ca6720(brushRenderingContext.xe9e9c556ec0c3e33);
		if (array == null)
		{
			return new xc020fa2f5133cba8(x26d9ecb4bdf0456d.x45260ad4b94166f2);
		}
		x5e9754e56a4f759f x5e9754e56a4f759f = new x5e9754e56a4f759f(array);
		xb2bd46daa9daeaa9.xf7786447fe437170(x5e9754e56a4f759f, brushRenderingContext, x90c6e45466e5b849.x819589f292a61f6b);
		x2c25322cc44977e3(x5e9754e56a4f759f, brushRenderingContext, array);
		xc61fc83c427e7d49(x5e9754e56a4f759f, brushRenderingContext);
		xb0ba71da9bddce3f(x5e9754e56a4f759f, brushRenderingContext);
		return x5e9754e56a4f759f;
	}

	public override void xbd7d8a7a0df4684a(xd7e8497b32a408b8 x8b80cdce7a15befe)
	{
	}

	public override x48d7478d49393961 Clone()
	{
		xb8c0a122dcc2f776 xb8c0a122dcc2f777 = new xb8c0a122dcc2f776();
		xb8c0a122dcc2f777.xf6a4131d6347f6d5 = xf6a4131d6347f6d5;
		xb8c0a122dcc2f777.x3012fceed1fc4fbf = x3012fceed1fc4fbf;
		if (x6ad1ca1cd79b3b95 != null)
		{
			xb8c0a122dcc2f777.x38f7d62de9bd2349 = x6ad1ca1cd79b3b95.x8b61531c8ea35b85();
		}
		if (xb16dd6e84ef2f792 != null)
		{
			xb8c0a122dcc2f777.x5817d0e429334953 = xb16dd6e84ef2f792.x8b61531c8ea35b85();
		}
		if (x1e85e97d2d60083b != null)
		{
			xb8c0a122dcc2f777.x90c6e45466e5b849 = x1e85e97d2d60083b.x8b61531c8ea35b85();
		}
		return xb8c0a122dcc2f777;
	}

	public override x26d9ecb4bdf0456d GetSingleColor(x8b545195dd56c1c7 brushRenderingContext)
	{
		return x26d9ecb4bdf0456d.x89fffa2751fdecbe;
	}

	private void x2c25322cc44977e3(x5e9754e56a4f759f xd8f1949f8950238a, x8b545195dd56c1c7 xf1125c563ec28c45, byte[] xe058541ca798c059)
	{
		xa2745adfabe0c674 x95dac044246123ac = xdd1b8f14cc8ba86d.x16a7fb03c627ebfb(xe058541ca798c059);
		x95dac044246123ac = x4e4c1451627c6f7a(x95dac044246123ac);
		xd8f1949f8950238a.x42eb8f4390d1e7ba = x9b8eb29a544bfbab(x95dac044246123ac);
		x5817d0e429334953.x99abbb429861fb9d(xd8f1949f8950238a, xf1125c563ec28c45, x95dac044246123ac);
	}

	private RectangleF x9b8eb29a544bfbab(xa2745adfabe0c674 x95dac044246123ac)
	{
		RectangleF rectangleF = new RectangleF(0f, 0f, x95dac044246123ac.xdc1bf80853046136, x95dac044246123ac.xb0f146032f47c24e);
		RectangleF a = x38f7d62de9bd2349.xfaab97dd0218026f(rectangleF);
		return RectangleF.Intersect(a, rectangleF);
	}

	private xa2745adfabe0c674 x4e4c1451627c6f7a(xa2745adfabe0c674 x95dac044246123ac)
	{
		if (xf6a4131d6347f6d5 == 0)
		{
			return x95dac044246123ac;
		}
		return xa2745adfabe0c674.xe6a756f8b9f6fe18(x95dac044246123ac.x72d92bd1aff02e37, x95dac044246123ac.xe360b1885d8d4a41, x95dac044246123ac.x419ba17a5322627b, x95dac044246123ac.x9bcb07e204e30218, xf6a4131d6347f6d5, xf6a4131d6347f6d5);
	}

	private void xc61fc83c427e7d49(x5e9754e56a4f759f xd8f1949f8950238a, x8b545195dd56c1c7 xf1125c563ec28c45)
	{
		if (x3012fceed1fc4fbf)
		{
			PointF xeeb1f7e9c2d6528d = new PointF(xf1125c563ec28c45.x6a1f9e96254c40aa.Width / 2f, xf1125c563ec28c45.x6a1f9e96254c40aa.Height / 2f);
			x54366fa5f75a02f7 x470ecea91abfd1aa = x82aca35e35e7bf31.x0fa1cea464b61ce1(xf1125c563ec28c45, xeeb1f7e9c2d6528d);
			xd8f1949f8950238a.xaccac17571a8d9fa.x490e30087768649f(x470ecea91abfd1aa, MatrixOrder.Append);
		}
	}

	private void xb0ba71da9bddce3f(x5e9754e56a4f759f xd8f1949f8950238a, x8b545195dd56c1c7 xf1125c563ec28c45)
	{
		float m = ((xf1125c563ec28c45.x1a31c5dbe3231791 < 0.0) ? xf1125c563ec28c45.x6a1f9e96254c40aa.Width : 0f);
		float m2 = ((xf1125c563ec28c45.xaf2abb0b85eac4e2 < 0.0) ? xf1125c563ec28c45.x6a1f9e96254c40aa.Height : 0f);
		x54366fa5f75a02f7 x470ecea91abfd1aa = new x54366fa5f75a02f7((float)xf1125c563ec28c45.x1a31c5dbe3231791, 0f, 0f, (float)xf1125c563ec28c45.xaf2abb0b85eac4e2, m, m2);
		xd8f1949f8950238a.xaccac17571a8d9fa.x490e30087768649f(x470ecea91abfd1aa, MatrixOrder.Append);
	}
}
