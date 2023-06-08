using x5794c252ba25e723;

namespace xc7ce8a6a920f8012;

internal class x0ac6c127422cb855 : x0096796e2eb81db6
{
	public x0ac6c127422cb855(x34b34bf589d8ec1e context)
		: base(context)
	{
	}

	public void x9b7d5a7fc9e0bc4b(x5f55370cc09dd787 xd8f1949f8950238a)
	{
		base.x5aa326f374b3d0ef.xbd9d4226f381e56d(2, 2, xde809bbd71bb692c: false);
		base.x5aa326f374b3d0ef.xbd9d4226f381e56d(0, 2, xde809bbd71bb692c: false);
		if (xd8f1949f8950238a.xcc7b76ceb682651c == null)
		{
			base.x5aa326f374b3d0ef.xbd9d4226f381e56d(2, 4, xde809bbd71bb692c: false);
			x415acf01a55ec964(xd8f1949f8950238a.x7d2dc175c2f289c5, 0);
			x415acf01a55ec964(xd8f1949f8950238a.xf3874816968aabd7, byte.MaxValue);
			return;
		}
		base.x5aa326f374b3d0ef.xbd9d4226f381e56d(xd8f1949f8950238a.xcc7b76ceb682651c.Length, 4, xde809bbd71bb692c: false);
		for (int i = 0; i < xd8f1949f8950238a.xcc7b76ceb682651c.Length; i++)
		{
			x26d9ecb4bdf0456d x9b41425268471380 = xd8f1949f8950238a.xcc7b76ceb682651c[i].x9b41425268471380;
			byte xcbf4aad10d696dcc = (byte)(xd8f1949f8950238a.xcc7b76ceb682651c[i].xbe1e23e7d5b43370 * 255f);
			x415acf01a55ec964(x9b41425268471380, xcbf4aad10d696dcc);
		}
	}

	private void x415acf01a55ec964(x26d9ecb4bdf0456d x6c50a99faab7d741, byte xcbf4aad10d696dcc)
	{
		base.x5aa326f374b3d0ef.xc351d479ff7ee789(xcbf4aad10d696dcc);
		base.x5aa326f374b3d0ef.x556a54698802f31f(x6c50a99faab7d741);
	}
}
