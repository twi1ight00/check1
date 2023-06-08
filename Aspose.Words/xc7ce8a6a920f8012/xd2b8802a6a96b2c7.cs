using System.Drawing.Drawing2D;
using x38a89dee67fc7a16;
using x5794c252ba25e723;

namespace xc7ce8a6a920f8012;

internal class xd2b8802a6a96b2c7 : x0096796e2eb81db6
{
	public xd2b8802a6a96b2c7(x34b34bf589d8ec1e context)
		: base(context)
	{
	}

	public void xf5fe5bf90a2f2397(x845d6a068e0b03c5 xd8f1949f8950238a)
	{
		base.x5aa326f374b3d0ef.xc351d479ff7ee789(1);
		switch (xd8f1949f8950238a.x4bc21f84846f912d)
		{
		case x0b257a9fb413b6c3.xb8751dec55f64252:
			x2d4bd958d81cf347((xc020fa2f5133cba8)xd8f1949f8950238a);
			break;
		case x0b257a9fb413b6c3.x7b6a6d281546db99:
			x8b0138e3a8860975((x5e9754e56a4f759f)xd8f1949f8950238a);
			break;
		case x0b257a9fb413b6c3.x1b1f1b9a5f55b7ee:
			x2657b6d735e613cc((x5bdb4ba66c23277c)xd8f1949f8950238a);
			break;
		case x0b257a9fb413b6c3.x37b6ad6b01d0c641:
			xf67a8e38220ac6d5((x5f55370cc09dd787)xd8f1949f8950238a);
			break;
		default:
			x2d4bd958d81cf347(new xc020fa2f5133cba8(x26d9ecb4bdf0456d.x45260ad4b94166f2));
			break;
		}
	}

	public void x6210059f049f0d48(x845d6a068e0b03c5 xd8f1949f8950238a)
	{
		switch (xd8f1949f8950238a.x4bc21f84846f912d)
		{
		case x0b257a9fb413b6c3.xb8751dec55f64252:
			x2d4bd958d81cf347((xc020fa2f5133cba8)xd8f1949f8950238a);
			break;
		case x0b257a9fb413b6c3.x7b6a6d281546db99:
			x8b0138e3a8860975((x5e9754e56a4f759f)xd8f1949f8950238a);
			break;
		case x0b257a9fb413b6c3.x1b1f1b9a5f55b7ee:
			x2657b6d735e613cc((x5bdb4ba66c23277c)xd8f1949f8950238a);
			break;
		case x0b257a9fb413b6c3.x37b6ad6b01d0c641:
			xf67a8e38220ac6d5((x5f55370cc09dd787)xd8f1949f8950238a);
			break;
		default:
			x2d4bd958d81cf347(new xc020fa2f5133cba8(x26d9ecb4bdf0456d.x45260ad4b94166f2));
			break;
		}
	}

	private void x2d4bd958d81cf347(xc020fa2f5133cba8 xd8f1949f8950238a)
	{
		base.x5aa326f374b3d0ef.xc351d479ff7ee789(0);
		base.x5aa326f374b3d0ef.x556a54698802f31f(xd8f1949f8950238a.x9b41425268471380);
	}

	private void xf67a8e38220ac6d5(x5f55370cc09dd787 xd8f1949f8950238a)
	{
		base.x5aa326f374b3d0ef.xc351d479ff7ee789(16);
		x54366fa5f75a02f7 x54366fa5f75a02f = ((xd8f1949f8950238a.xaccac17571a8d9fa != null) ? xd8f1949f8950238a.xaccac17571a8d9fa.x8b61531c8ea35b85() : new x54366fa5f75a02f7());
		x54366fa5f75a02f.xce92de628aa023cf(xd8f1949f8950238a.x404d528fe2f10961.X + xd8f1949f8950238a.x404d528fe2f10961.Width / 2f, xd8f1949f8950238a.x404d528fe2f10961.Y + xd8f1949f8950238a.x404d528fe2f10961.Height / 2f, MatrixOrder.Prepend);
		x54366fa5f75a02f.x5152a5707921c783(xd8f1949f8950238a.x404d528fe2f10961.Width / 32768f, xd8f1949f8950238a.x404d528fe2f10961.Height / 32768f, MatrixOrder.Prepend);
		base.x5aa326f374b3d0ef.x215d2a6f35e16d24(x54366fa5f75a02f);
		x0ac6c127422cb855 x0ac6c127422cb856 = new x0ac6c127422cb855(base.x28fcdc775a1d069c);
		x0ac6c127422cb856.x9b7d5a7fc9e0bc4b(xd8f1949f8950238a);
	}

	private void x8b0138e3a8860975(x5e9754e56a4f759f xd8f1949f8950238a)
	{
		x927e197c87ba6884(xd8f1949f8950238a.xcc18177a965e0313, xd8f1949f8950238a.xaccac17571a8d9fa, xd8f1949f8950238a.x349ff0df1e641b4e);
	}

	private void x2657b6d735e613cc(x5bdb4ba66c23277c xd8f1949f8950238a)
	{
		byte[] x43e181e083db6cdf = x973c394bd6a899a2.xb19c72971505e3ca(xd8f1949f8950238a);
		x927e197c87ba6884(x43e181e083db6cdf, null, WrapMode.Tile);
	}

	private void x927e197c87ba6884(byte[] x43e181e083db6cdf, x54366fa5f75a02f7 x678241938de24d81, WrapMode xd3daaf20904f5daa)
	{
		if (x678241938de24d81 == null)
		{
			x678241938de24d81 = new x54366fa5f75a02f7();
		}
		short xbcea506a33cf = base.x28fcdc775a1d069c.xf41382d350a87348(x43e181e083db6cdf);
		base.x5aa326f374b3d0ef.xc351d479ff7ee789((byte)((xd3daaf20904f5daa == WrapMode.Clamp) ? 65 : 64));
		base.x5aa326f374b3d0ef.xab5f6b7526efa5be(xbcea506a33cf);
		base.x5aa326f374b3d0ef.x215d2a6f35e16d24(x678241938de24d81);
	}

	public void x4e60b3146687ee8f()
	{
		base.x5aa326f374b3d0ef.xc351d479ff7ee789(0);
	}
}
