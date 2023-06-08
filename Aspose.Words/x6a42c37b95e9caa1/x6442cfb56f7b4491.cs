using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using x1c8faa688b1f0b0c;
using x5794c252ba25e723;
using x59d6a4fc5007b7a4;

namespace x6a42c37b95e9caa1;

internal class x6442cfb56f7b4491
{
	private const float x2778adfff4dd6dd9 = 5f;

	private const float xaf9628b9850ffdb1 = 0.125f;

	private const float x4dcb05d492c61477 = 10f;

	private xfef22f4f866de8d2 x9641dec64980b2ca;

	private x26d9ecb4bdf0456d x6196504f1f36b003 = new x26d9ecb4bdf0456d(242, 242, 242);

	internal x6442cfb56f7b4491(xfef22f4f866de8d2 builder)
	{
		x9641dec64980b2ca = builder;
	}

	internal void x7d146f9a953b4c96(xdcf47a8f1807f37c xbbe2f7d7c86e0379)
	{
		if (xbbe2f7d7c86e0379.x53a759df62a20324)
		{
			xbbe2f7d7c86e0379.x4dac52894f72430e(x9641dec64980b2ca);
			xbfda2561908204f7(xbbe2f7d7c86e0379);
			ArrayList arrayList = xbbe2f7d7c86e0379.x008093d2a2c25e80();
			for (int i = 0; i < arrayList.Count; i++)
			{
				xbe34d29d368fc922 xbe34d29d368fc = (xbe34d29d368fc922)arrayList[i];
				xbff2c69676f9a9c8(xbe34d29d368fc);
				x83cb510f4253add0(xbe34d29d368fc);
				xbe34d29d368fc.x7012609bcdb39574(x9641dec64980b2ca);
			}
		}
	}

	private void xbfda2561908204f7(xdcf47a8f1807f37c xbbe2f7d7c86e0379)
	{
		xab391c46ff9a0a38 xab391c46ff9a0a = new xab391c46ff9a0a38(new x31c19fcb724dfaf5(x6196504f1f36b003));
		xab391c46ff9a0a.x60465f602599d327 = new xc020fa2f5133cba8(x6196504f1f36b003);
		x1cab6af0a41b70e2 x1cab6af0a41b70e = new x1cab6af0a41b70e2();
		xab391c46ff9a0a.xd6b6ed77479ef68c(x1cab6af0a41b70e);
		x1cab6af0a41b70e.x5e6c52cb3256cc85 = true;
		x1cab6af0a41b70e.xb90eeef3d2a5a96b(xbbe2f7d7c86e0379.xd39e4a5fb49400d6());
		x9641dec64980b2ca.x28fcdc775a1d069c.x1fa9148f6731ff24(xab391c46ff9a0a);
	}

	internal void xa096b947452fa2d4(xdcf47a8f1807f37c xbbe2f7d7c86e0379)
	{
		if (xbbe2f7d7c86e0379.x53a759df62a20324)
		{
			ArrayList arrayList = xbbe2f7d7c86e0379.x008093d2a2c25e80();
			for (int i = 0; i < arrayList.Count; i++)
			{
				xbe34d29d368fc922 x77c5a31ec0891f = (xbe34d29d368fc922)arrayList[i];
				x83279624050d118e(x77c5a31ec0891f);
			}
			xffc4b52b968e04ab(xbbe2f7d7c86e0379);
		}
	}

	private void xbff2c69676f9a9c8(xbe34d29d368fc922 x77c5a31ec0891f38)
	{
		ArrayList arrayList = x77c5a31ec0891f38.xe655e88796bdba2a();
		for (int i = 0; i < arrayList.Count; i++)
		{
			RectangleF x26545669838eb36e = (RectangleF)arrayList[i];
			xab391c46ff9a0a38 xab391c46ff9a0a = new xab391c46ff9a0a38(new x31c19fcb724dfaf5(x77c5a31ec0891f38.xf83c69bb98e96a69));
			xab391c46ff9a0a.x60465f602599d327 = new xc020fa2f5133cba8(x77c5a31ec0891f38.xf83c69bb98e96a69);
			x1cab6af0a41b70e2 x1cab6af0a41b70e = new x1cab6af0a41b70e2();
			xab391c46ff9a0a.xd6b6ed77479ef68c(x1cab6af0a41b70e);
			x1cab6af0a41b70e.x5e6c52cb3256cc85 = true;
			x1cab6af0a41b70e.xb90eeef3d2a5a96b(x26545669838eb36e);
			x9641dec64980b2ca.x28fcdc775a1d069c.x1fa9148f6731ff24(xab391c46ff9a0a);
		}
	}

	private void x83cb510f4253add0(xbe34d29d368fc922 x77c5a31ec0891f38)
	{
		RectangleF xa07a9457a2ebbbfc = x77c5a31ec0891f38.xa07a9457a2ebbbfc;
		xab391c46ff9a0a38 xab391c46ff9a0a = new xab391c46ff9a0a38(new x31c19fcb724dfaf5(x77c5a31ec0891f38.x7dd793a62d047456));
		xab391c46ff9a0a.x60465f602599d327 = new xc020fa2f5133cba8(x77c5a31ec0891f38.xf83c69bb98e96a69);
		x1cab6af0a41b70e2 x1cab6af0a41b70e = new x1cab6af0a41b70e2();
		xab391c46ff9a0a.xd6b6ed77479ef68c(x1cab6af0a41b70e);
		x1cab6af0a41b70e.x5e6c52cb3256cc85 = true;
		x2ef83fca52cac48d(x1cab6af0a41b70e, xa07a9457a2ebbbfc.Location, 10f, 180f, 90f);
		x2ef83fca52cac48d(x1cab6af0a41b70e, new PointF(xa07a9457a2ebbbfc.Right - 10f, xa07a9457a2ebbbfc.Top), 10f, 270f, 90f);
		x2ef83fca52cac48d(x1cab6af0a41b70e, new PointF(xa07a9457a2ebbbfc.Right - 10f, xa07a9457a2ebbbfc.Bottom - 10f), 10f, 0f, 90f);
		x2ef83fca52cac48d(x1cab6af0a41b70e, new PointF(xa07a9457a2ebbbfc.Left, xa07a9457a2ebbbfc.Bottom - 10f), 10f, 90f, 90f);
		x9641dec64980b2ca.x28fcdc775a1d069c.x1fa9148f6731ff24(xab391c46ff9a0a);
	}

	private void x2ef83fca52cac48d(x1cab6af0a41b70e2 x372aeb543642dbdb, PointF xf40b804a8cc7bff8, float x1bb0b04c95fb61c2, float x32bf744f8e9a8c29, float x4b7a727a9fc82698)
	{
		x1fb5d45c2d0b868a x1fb5d45c2d0b868a = new x1fb5d45c2d0b868a();
		x1fb5d45c2d0b868a.x437e3b626c0fdd43 = new SizeF(x1bb0b04c95fb61c2, x1bb0b04c95fb61c2);
		x1fb5d45c2d0b868a.xba40a5b113d122a1 = x32bf744f8e9a8c29;
		x1fb5d45c2d0b868a.xae49680937687932 = x4b7a727a9fc82698;
		x1fb5d45c2d0b868a.xab07b26048f600ba = xf40b804a8cc7bff8;
		x9fe47a4de491f4aa[] array = x1fb5d45c2d0b868a.x1a10ab118b131ef0();
		for (int i = 0; i < array.Length; i++)
		{
			x372aeb543642dbdb.xd6b6ed77479ef68c(new x519b1bd0625473ff(array[i]));
		}
	}

	private void x83279624050d118e(xbe34d29d368fc922 x77c5a31ec0891f38)
	{
		ArrayList arrayList = x77c5a31ec0891f38.xe655e88796bdba2a();
		RectangleF xc5f45dd594ff = (RectangleF)arrayList[0];
		RectangleF x6625e5a709cd = (RectangleF)arrayList[arrayList.Count - 1];
		xab391c46ff9a0a38 xda5bf54deb817e = x21b12b934d30c236(x77c5a31ec0891f38.x7dd793a62d047456, xc5f45dd594ff);
		x9641dec64980b2ca.x28fcdc775a1d069c.x1fa9148f6731ff24(xda5bf54deb817e);
		xab391c46ff9a0a38 xda5bf54deb817e2 = x241126ae3550dd7b(x77c5a31ec0891f38.x7dd793a62d047456, x6625e5a709cd);
		x9641dec64980b2ca.x28fcdc775a1d069c.x1fa9148f6731ff24(xda5bf54deb817e2);
		xab391c46ff9a0a38 xda5bf54deb817e3 = xd30603e0f77ed8d2(x77c5a31ec0891f38.x7dd793a62d047456, x6625e5a709cd, x77c5a31ec0891f38.xa07a9457a2ebbbfc);
		x9641dec64980b2ca.x28fcdc775a1d069c.x1fa9148f6731ff24(xda5bf54deb817e3);
	}

	private xab391c46ff9a0a38 xd30603e0f77ed8d2(x26d9ecb4bdf0456d x6c50a99faab7d741, RectangleF x6625e5a709cd4497, RectangleF x9a39c8619b904b99)
	{
		float num = x9a39c8619b904b99.X - x6625e5a709cd4497.Right;
		float num2 = num - 30f;
		x31c19fcb724dfaf5 x31c19fcb724dfaf = new x31c19fcb724dfaf5(x6c50a99faab7d741);
		x31c19fcb724dfaf.xca08e8eb525b8a1a = DashStyle.Dash;
		xab391c46ff9a0a38 xab391c46ff9a0a = new xab391c46ff9a0a38(x31c19fcb724dfaf);
		x1cab6af0a41b70e2 x1cab6af0a41b70e = new x1cab6af0a41b70e2();
		xab391c46ff9a0a.xd6b6ed77479ef68c(x1cab6af0a41b70e);
		x1cab6af0a41b70e.x8992595b6d42d9bd(new PointF[3]
		{
			new PointF(x6625e5a709cd4497.Right, x6625e5a709cd4497.Bottom),
			new PointF(x6625e5a709cd4497.Right + num2, x6625e5a709cd4497.Bottom),
			new PointF(x9a39c8619b904b99.X, x9a39c8619b904b99.Y + 5f)
		});
		return xab391c46ff9a0a;
	}

	private xab391c46ff9a0a38 x21b12b934d30c236(x26d9ecb4bdf0456d x6c50a99faab7d741, RectangleF xc5f45dd594ff6313)
	{
		float num = xc5f45dd594ff6313.Height * 0.125f;
		return x30184de7b0acb4e1(x6c50a99faab7d741, new PointF[4]
		{
			new PointF(xc5f45dd594ff6313.Left + num, xc5f45dd594ff6313.Top),
			new PointF(xc5f45dd594ff6313.Left, xc5f45dd594ff6313.Top + num),
			new PointF(xc5f45dd594ff6313.Left, xc5f45dd594ff6313.Bottom - num),
			new PointF(xc5f45dd594ff6313.Left + num, xc5f45dd594ff6313.Bottom)
		});
	}

	private xab391c46ff9a0a38 x241126ae3550dd7b(x26d9ecb4bdf0456d x6c50a99faab7d741, RectangleF x6625e5a709cd4497)
	{
		float num = x6625e5a709cd4497.Height * 0.125f;
		return x30184de7b0acb4e1(x6c50a99faab7d741, new PointF[4]
		{
			new PointF(x6625e5a709cd4497.Right - num, x6625e5a709cd4497.Top),
			new PointF(x6625e5a709cd4497.Right, x6625e5a709cd4497.Top + num),
			new PointF(x6625e5a709cd4497.Right, x6625e5a709cd4497.Bottom - num),
			new PointF(x6625e5a709cd4497.Right - num, x6625e5a709cd4497.Bottom)
		});
	}

	private xab391c46ff9a0a38 x30184de7b0acb4e1(x26d9ecb4bdf0456d x6c50a99faab7d741, PointF[] x6fa2570084b2ad39)
	{
		xab391c46ff9a0a38 xab391c46ff9a0a = new xab391c46ff9a0a38(new x31c19fcb724dfaf5(x6c50a99faab7d741));
		x1cab6af0a41b70e2 x1cab6af0a41b70e = new x1cab6af0a41b70e2();
		xab391c46ff9a0a.xd6b6ed77479ef68c(x1cab6af0a41b70e);
		x1cab6af0a41b70e.x8992595b6d42d9bd(x6fa2570084b2ad39);
		return xab391c46ff9a0a;
	}

	private void xffc4b52b968e04ab(xdcf47a8f1807f37c xbbe2f7d7c86e0379)
	{
		RectangleF rectangleF = xbbe2f7d7c86e0379.xd39e4a5fb49400d6();
		float num = xbbe2f7d7c86e0379.xdc1bf80853046136 / (rectangleF.Right + 10f);
		float num2 = xbbe2f7d7c86e0379.xb0f146032f47c24e * num;
		float x6842879318972d9e = (xbbe2f7d7c86e0379.xb0f146032f47c24e - num2) / 2f;
		if (xbbe2f7d7c86e0379.xaccac17571a8d9fa == null)
		{
			xbbe2f7d7c86e0379.xaccac17571a8d9fa = new x54366fa5f75a02f7();
		}
		xbbe2f7d7c86e0379.xaccac17571a8d9fa.x5152a5707921c783(num, num, MatrixOrder.Append);
		xbbe2f7d7c86e0379.xaccac17571a8d9fa.xce92de628aa023cf(0f, x6842879318972d9e, MatrixOrder.Append);
	}
}
