using System;
using System.Drawing;
using x5794c252ba25e723;

namespace x6c95d9cf46ff5f25;

internal class x4574ea26106f0edb
{
	public const double xe5333fdfc4b6b0ca = 32767.99998474121;

	public const double x8ca57f7ca66f67f1 = -32768.99998474121;

	public const double x9a669a9e31a71e99 = 25.4;

	public const double xd99d81b53cde8cdd = 72.0;

	public const float x1280b9a9635e55bf = 0.71999997f;

	public const float x088410bfe65ad1aa = 0.072000004f;

	private const double xdb2438abad5a9b0f = 2.834645669291339;

	public const float xcb59a65aa2f23dcf = 0.28346458f;

	public const float x6a36eea4ae862711 = 0.028346457f;

	public const float x7fab8684d69ccf6a = 0.0028346458f;

	private const double xd498e5fc864b8b18 = 28.34645669291339;

	private const double x5eb59d2d7c2f552d = 12.0;

	public const double x7bdcb85b862e28ea = 20.0;

	public const double x120efb27e7b67d2c = 1440.0;

	private const double x8c07b158db075a5b = 56.69291338582678;

	private const double x5441101610f482bd = 240.0;

	public const double xa69b3db0ad6aea00 = 0.05;

	public const double x95ee9e298e04a43b = 12700.0;

	private const double x6ea98ded9575f7c7 = 914400.0;

	private const double xb02047dee7146077 = 36000.00000000001;

	private const double x0b2958a067d8aeea = 635.0;

	public const int x9ef9cff4777ec8df = 1000;

	private const int x61244bdf9e66496b = 72000;

	public const int x38e33bf3b7636ae6 = 50;

	private const int x307fdddb5908c2c2 = 500;

	public const double xf14ce61e90fde772 = 1584.0;

	public const double xdf87570e665eba96 = 0.75;

	public const int x6eaf3b31289fae35 = 31680;

	public const int x05afd9cd9c8d4823 = 15;

	public const int xbfcfc6b243dcd38a = 1584000;

	public const double x3fdd7ba1ff6b9140 = 60000.0;

	public static float x9ff07e08ab648f94 = 1.3333334f;

	public static float x755f7ed650852c8b = (float)(1.0 / (double)x9ff07e08ab648f94);

	private x4574ea26106f0edb()
	{
	}

	public static double x1f1488a9109eace7(double x6fa2570084b2ad39)
	{
		return x1f1488a9109eace7(x6fa2570084b2ad39, 96.0);
	}

	public static double x1f1488a9109eace7(double x6fa2570084b2ad39, double x1de68a531466236f)
	{
		return x6fa2570084b2ad39 / 72.0 * x1de68a531466236f;
	}

	public static int xdbd829479885762d(double x6fa2570084b2ad39)
	{
		return x15e971129fd80714.x43fcc3f62534530b(x1f1488a9109eace7(x6fa2570084b2ad39));
	}

	public static int xdbd829479885762d(double x6fa2570084b2ad39, double x1de68a531466236f)
	{
		return x15e971129fd80714.x43fcc3f62534530b(x1f1488a9109eace7(x6fa2570084b2ad39, x1de68a531466236f));
	}

	public static int x4bec21b1de9d1b5b(double x6fa2570084b2ad39, double x1de68a531466236f)
	{
		return Math.Max((int)Math.Ceiling(x1f1488a9109eace7(x6fa2570084b2ad39, x1de68a531466236f)), 1);
	}

	public static Size x4bec21b1de9d1b5b(SizeF xdb421875a5f5258b, float x9bdeb785c5aca5b5, double xfa7300893f01343a)
	{
		if (x9bdeb785c5aca5b5 <= 0f)
		{
			throw new ArgumentOutOfRangeException("scale");
		}
		if (xfa7300893f01343a <= 0.0)
		{
			throw new ArgumentOutOfRangeException("dpi");
		}
		return new Size(xdbd829479885762d(xdb421875a5f5258b.Width * x9bdeb785c5aca5b5, xfa7300893f01343a), xdbd829479885762d(xdb421875a5f5258b.Height * x9bdeb785c5aca5b5, xfa7300893f01343a));
	}

	public static double x8c165822f9aea254(double x6fa2570084b2ad39)
	{
		return x6fa2570084b2ad39 / 0.002834645882776876;
	}

	public static int x5d11bb3eea3af0d2(double x6fa2570084b2ad39)
	{
		return x15e971129fd80714.x43fcc3f62534530b(x8c165822f9aea254(x6fa2570084b2ad39));
	}

	public static double xad2dd08366e0faf5(double x1037b05dde2943fa)
	{
		return xad2dd08366e0faf5(x1037b05dde2943fa, 96.0);
	}

	public static RectangleF xad2dd08366e0faf5(RectangleF xa270e578f34e0af3)
	{
		return RectangleF.FromLTRB((float)xad2dd08366e0faf5(xa270e578f34e0af3.Left), (float)xad2dd08366e0faf5(xa270e578f34e0af3.Top), (float)xad2dd08366e0faf5(xa270e578f34e0af3.Right), (float)xad2dd08366e0faf5(xa270e578f34e0af3.Bottom));
	}

	public static double xad2dd08366e0faf5(double x1037b05dde2943fa, double x1de68a531466236f)
	{
		return x1037b05dde2943fa / x1de68a531466236f * 72.0;
	}

	public static int xad0a638147bf044e(double x1037b05dde2943fa, double x1de68a531466236f)
	{
		return x15e971129fd80714.x43fcc3f62534530b(x1037b05dde2943fa / x1de68a531466236f * 1440.0);
	}

	public static int x7f5af7c46bbf7858(double x1037b05dde2943fa, double x837a1a69e44dad97, double x3c8b3aa87808ba31)
	{
		return x15e971129fd80714.x43fcc3f62534530b(x1037b05dde2943fa * x3c8b3aa87808ba31 / x837a1a69e44dad97);
	}

	public static double x9adffc4de2e5ac97(double x1be0f9f167c9ca98)
	{
		return x1be0f9f167c9ca98 * 72.0;
	}

	public static double xc4ed0440a9ee9c3e(double x6fa2570084b2ad39)
	{
		return x6fa2570084b2ad39 / 72.0;
	}

	public static double x5612f4c9f83f95d3(double xb83e5726160e1fd1)
	{
		return xb83e5726160e1fd1 * 2.834645669291339;
	}

	public static int x7d6de2a14bd3fd11(double xb83e5726160e1fd1)
	{
		return x15e971129fd80714.x43fcc3f62534530b(xb83e5726160e1fd1 * 56.69291338582678);
	}

	public static int xfcf9c235b4aef277(double xb83e5726160e1fd1)
	{
		return x15e971129fd80714.x43fcc3f62534530b(x2dec7440ed5bb457(xb83e5726160e1fd1));
	}

	public static double x2dec7440ed5bb457(double xb83e5726160e1fd1)
	{
		return x2dec7440ed5bb457(xb83e5726160e1fd1, 96.0);
	}

	public static double x2dec7440ed5bb457(double xb83e5726160e1fd1, double x1de68a531466236f)
	{
		return xb83e5726160e1fd1 * x1de68a531466236f / 25.4;
	}

	public static double xb0e438d6d798d50b(double x1be0f9f167c9ca98)
	{
		return xb0e438d6d798d50b(x1be0f9f167c9ca98, 96.0);
	}

	public static double xb0e438d6d798d50b(double x1be0f9f167c9ca98, double x1de68a531466236f)
	{
		return x1be0f9f167c9ca98 * x1de68a531466236f;
	}

	public static double x7ee6ab51d3d84831(double x503a2108d89b6fec)
	{
		return x503a2108d89b6fec * 28.34645669291339;
	}

	public static double xefebf4e0a5cd9e91(double x0383ec486664fa18)
	{
		return x0383ec486664fa18 * 12.0;
	}

	public static int x18d546e0f955c5a5(int x21e9f60a4b7c4b2b)
	{
		return x15e971129fd80714.x43fcc3f62534530b((double)x21e9f60a4b7c4b2b * 240.0 / 100.0);
	}

	public static double x99578b0350da4963(double x6fa2570084b2ad39)
	{
		return x6fa2570084b2ad39 / 12.0;
	}

	public static int x3f26fa43a4a41e70(double x6fa2570084b2ad39)
	{
		return x15e971129fd80714.x43fcc3f62534530b(x6fa2570084b2ad39 * 2.0);
	}

	public static double x4610495f80b4c267(int xad98231533632dd3)
	{
		return (double)xad98231533632dd3 / 2.0;
	}

	public static int xf4847d1e065c74fb(double x6fa2570084b2ad39)
	{
		return x15e971129fd80714.x43fcc3f62534530b(x6fa2570084b2ad39 * 8.0);
	}

	public static double x30719d7103d96aa2(int xa07664f00dfb36d6)
	{
		return (double)xa07664f00dfb36d6 / 8.0;
	}

	public static int x78d3dddae0ed1b0d(int x4b00065b6d43f0e9)
	{
		return x15e971129fd80714.x43fcc3f62534530b((double)x4b00065b6d43f0e9 * 2.5);
	}

	public static int x88bf16f2386d633e(double x6fa2570084b2ad39)
	{
		return x15e971129fd80714.x43fcc3f62534530b(x6fa2570084b2ad39 * 20.0);
	}

	public static double x0e1fdb362561ddb2(int xf6495da3f9ed2d9c)
	{
		return (double)xf6495da3f9ed2d9c / 20.0;
	}

	public static double x0e1fdb362561ddb2(double xf6495da3f9ed2d9c)
	{
		return xf6495da3f9ed2d9c / 20.0;
	}

	public static double xd0c830d607c0b179(int xf6495da3f9ed2d9c)
	{
		return (double)xf6495da3f9ed2d9c / 56.69291338582678;
	}

	public static double x984bdd10255a33a5(int xf6495da3f9ed2d9c)
	{
		return (double)xf6495da3f9ed2d9c / 240.0;
	}

	public static int xf85cde1a143e2f49(int xf6495da3f9ed2d9c)
	{
		return xdbd829479885762d(x0e1fdb362561ddb2(xf6495da3f9ed2d9c));
	}

	public static int x02191c6de86774e5(double x1be0f9f167c9ca98)
	{
		return x15e971129fd80714.x43fcc3f62534530b(x1be0f9f167c9ca98 * 1440.0);
	}

	public static int xf948c031f0159fef(int x93937990db098a97)
	{
		return x15e971129fd80714.x43fcc3f62534530b((double)x93937990db098a97 / 635.0);
	}

	public static int x274b3224606757b0(int xf6495da3f9ed2d9c)
	{
		return x15e971129fd80714.x43fcc3f62534530b((double)xf6495da3f9ed2d9c * 635.0);
	}

	public static int x3aa08882c9feaf96(double x6fa2570084b2ad39)
	{
		return x15e971129fd80714.x43fcc3f62534530b(x6fa2570084b2ad39 * 12700.0);
	}

	public static RectangleF x3aa08882c9feaf96(RectangleF x6e2fcd9110b85d96)
	{
		return RectangleF.FromLTRB(x3aa08882c9feaf96(x6e2fcd9110b85d96.Left), x3aa08882c9feaf96(x6e2fcd9110b85d96.Top), x3aa08882c9feaf96(x6e2fcd9110b85d96.Right), x3aa08882c9feaf96(x6e2fcd9110b85d96.Bottom));
	}

	public static double xa23e6b6c3169521d(int x93937990db098a97)
	{
		return (double)x93937990db098a97 / 12700.0;
	}

	public static double xa23e6b6c3169521d(double x93937990db098a97)
	{
		return x93937990db098a97 / 12700.0;
	}

	public static RectangleF xa23e6b6c3169521d(RectangleF xf1d89cbde1dd44f4)
	{
		return new RectangleF((float)xa23e6b6c3169521d(xf1d89cbde1dd44f4.Left), (float)xa23e6b6c3169521d(xf1d89cbde1dd44f4.Top), (float)xa23e6b6c3169521d(xf1d89cbde1dd44f4.Width), (float)xa23e6b6c3169521d(xf1d89cbde1dd44f4.Height));
	}

	public static double x0fb738636eebfc1e(int x1037b05dde2943fa)
	{
		return x3aa08882c9feaf96(xad2dd08366e0faf5(x1037b05dde2943fa));
	}

	public static double x0fb738636eebfc1e(int x1037b05dde2943fa, double x1de68a531466236f)
	{
		return x3aa08882c9feaf96(xad2dd08366e0faf5(x1037b05dde2943fa, x1de68a531466236f));
	}

	public static RectangleF x0fb738636eebfc1e(RectangleF xdd287c74be16b6a2, double x1de68a531466236f)
	{
		return RectangleF.FromLTRB((float)x0fb738636eebfc1e((int)xdd287c74be16b6a2.Left, x1de68a531466236f), (float)x0fb738636eebfc1e((int)xdd287c74be16b6a2.Top, x1de68a531466236f), (float)x0fb738636eebfc1e((int)xdd287c74be16b6a2.Right, x1de68a531466236f), (float)x0fb738636eebfc1e((int)xdd287c74be16b6a2.Bottom, x1de68a531466236f));
	}

	public static RectangleF x0fb738636eebfc1e(RectangleF xdd287c74be16b6a2)
	{
		return new RectangleF((float)x0fb738636eebfc1e((int)xdd287c74be16b6a2.Left), (float)x0fb738636eebfc1e((int)xdd287c74be16b6a2.Top), (float)x0fb738636eebfc1e((int)xdd287c74be16b6a2.Width), (float)x0fb738636eebfc1e((int)xdd287c74be16b6a2.Height));
	}

	public static double x7c938cd3c8eb5262(int x93937990db098a97)
	{
		return (double)x93937990db098a97 / 914400.0;
	}

	public static float x6e9f5b67f7d0b8da(int xd77e018982b01b52)
	{
		return (float)x1f1488a9109eace7((double)xd77e018982b01b52 / 12700.0);
	}

	public static RectangleF x6e9f5b67f7d0b8da(RectangleF xf1d89cbde1dd44f4)
	{
		return RectangleF.FromLTRB(x6e9f5b67f7d0b8da((int)xf1d89cbde1dd44f4.Left), x6e9f5b67f7d0b8da((int)xf1d89cbde1dd44f4.Top), x6e9f5b67f7d0b8da((int)xf1d89cbde1dd44f4.Right), x6e9f5b67f7d0b8da((int)xf1d89cbde1dd44f4.Bottom));
	}

	public static double x9e9e006b3108fa4a(int x93937990db098a97)
	{
		return (double)x93937990db098a97 / 36000.00000000001;
	}

	public static int x2f9861b646a8b798(double x23f780eed403f116, double x1de68a531466236f)
	{
		return x15e971129fd80714.x43fcc3f62534530b(x1de68a531466236f * x23f780eed403f116 / 72000.0);
	}

	public static int x2f9861b646a8b798(int x9b0739496f8b5475)
	{
		return x2f9861b646a8b798(x9b0739496f8b5475, 96.0);
	}

	public static int x8d50b8a62ba1cd84(double x6fa2570084b2ad39)
	{
		return x15e971129fd80714.x43fcc3f62534530b(x6fa2570084b2ad39 * 1000.0);
	}

	public static float xc96d70553223ee04(int x23f780eed403f116)
	{
		return (float)x23f780eed403f116 / 1000f;
	}

	public static int x370502bb60141209(int xf6495da3f9ed2d9c)
	{
		return xf6495da3f9ed2d9c * 50;
	}

	public static int x5df565b312141b2b(int x23f780eed403f116)
	{
		return x23f780eed403f116 / 50;
	}

	public static int x9e20b93bb584bff2(double xad98231533632dd3)
	{
		return x15e971129fd80714.x43fcc3f62534530b(xad98231533632dd3 * 500.0);
	}

	public static float xb4666701f4f1abda(int x23f780eed403f116)
	{
		return (float)x23f780eed403f116 / 500f;
	}

	public static RectangleF xc96d70553223ee04(Rectangle xf671230c49fb86ad)
	{
		return new RectangleF(xc96d70553223ee04(xf671230c49fb86ad.X), xc96d70553223ee04(xf671230c49fb86ad.Y), xc96d70553223ee04(xf671230c49fb86ad.Width), xc96d70553223ee04(xf671230c49fb86ad.Height));
	}

	public static PointF xc96d70553223ee04(Point xf671230c49fb86ad)
	{
		return new PointF(xc96d70553223ee04(xf671230c49fb86ad.X), xc96d70553223ee04(xf671230c49fb86ad.Y));
	}

	public static SizeF xc96d70553223ee04(Size xf671230c49fb86ad)
	{
		return new SizeF(xc96d70553223ee04(xf671230c49fb86ad.Width), xc96d70553223ee04(xf671230c49fb86ad.Height));
	}

	public static Rectangle x8d50b8a62ba1cd84(RectangleF x0b433f30d6157b49)
	{
		return new Rectangle(x8d50b8a62ba1cd84(x0b433f30d6157b49.X), x8d50b8a62ba1cd84(x0b433f30d6157b49.Y), x8d50b8a62ba1cd84(x0b433f30d6157b49.Width), x8d50b8a62ba1cd84(x0b433f30d6157b49.Height));
	}

	public static Point x8d50b8a62ba1cd84(PointF x0b433f30d6157b49)
	{
		return new Point(x8d50b8a62ba1cd84(x0b433f30d6157b49.X), x8d50b8a62ba1cd84(x0b433f30d6157b49.Y));
	}

	public static float x22cebee58d0a8c37(int x23f780eed403f116)
	{
		return (float)x23f780eed403f116 / 1000f / 12f;
	}

	public static x26d9ecb4bdf0456d xd28d528ac0b51a0b(x26d9ecb4bdf0456d x6c50a99faab7d741)
	{
		if (!x6c50a99faab7d741.x7149c962c02931b3)
		{
			return new x26d9ecb4bdf0456d(x6c50a99faab7d741.xc613adc4330033f3, x6c50a99faab7d741.x26463655896fd90a, x6c50a99faab7d741.x8e8f6cc6a0756b05);
		}
		return x6c50a99faab7d741;
	}

	public static double x97ab502db0c0e5c2(int xbcea506a33cf9111)
	{
		return (double)xbcea506a33cf9111 / 65536.0;
	}

	public static int x091b250f00534aae(double xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111 > 32767.99998474121)
		{
			xbcea506a33cf9111 = 32767.99998474121;
		}
		else if (xbcea506a33cf9111 < -32768.99998474121)
		{
			xbcea506a33cf9111 = -32768.99998474121;
		}
		return x15e971129fd80714.x43fcc3f62534530b(xbcea506a33cf9111 * 65536.0);
	}

	public static double xabc7127d76567c74(double xa7c3217ec474cbeb)
	{
		return x15e971129fd80714.xcdc7b29a812dd7df(xa7c3217ec474cbeb / 60000.0);
	}

	public static double xbef9f017978fea0c(double xbcea506a33cf9111)
	{
		return x15e971129fd80714.xc9211137ad7bfa2a(xbcea506a33cf9111) * 60000.0;
	}

	public static double x61473648fd740ec5(double xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 * 60000.0;
	}

	public static double xb7a17dcef81f1c64(double xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 / 60000.0;
	}
}
