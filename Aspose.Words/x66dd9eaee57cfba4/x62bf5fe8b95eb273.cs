using System;
using System.Collections;
using x13f1efc79617a47b;
using x6c95d9cf46ff5f25;

namespace x66dd9eaee57cfba4;

internal abstract class x62bf5fe8b95eb273 : xba15250b3f24fd3a
{
	public const int x5a9ec8ad21ee92a9 = 4;

	public const int x464de4841b86f189 = 12;

	internal const int x6bf4501128464302 = 0;

	internal const int x1c2ece31161568cc = 1;

	internal const int x4c75ab17d5292221 = 3;

	internal const int xdc5ee3bc5012d10e = 0;

	internal const int x6f452aa557207af9 = 1;

	internal const int x4ccd6e7af8ab418a = 10;

	internal const int x9a1b564742a3b8ae = 0;

	internal const int x1f98579018811e76 = 1;

	internal const int x57032aa8c7403173 = 2;

	internal const int xe163d8758a364948 = 3;

	internal const int xf01a38df298f6041 = 25;

	internal const int x78bd0f76f9b7ce66 = 1033;

	internal const int x98eccc9ff66470ac = 0;

	protected x09ce2c02826e31a6 xe6414aff183c47a1;

	protected readonly int x448900fcb384c333;

	public abstract bool IsSymbolEncoding { get; }

	protected x62bf5fe8b95eb273(x09ce2c02826e31a6 charMap, int language)
	{
		xe6414aff183c47a1 = charMap;
		x448900fcb384c333 = language;
	}

	public static x62bf5fe8b95eb273 x06b0e25aa6ad68a9(xa8866d7566da0aa2 xe134235b3526fa75)
	{
		if (xe134235b3526fa75.xdb264d863790ee7b() != 0)
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("nabgdcighbpghcghmbnhoaeijalihbcjfajjbaakklgkkpnkbaflcpllopcmlkjmmpangohneoonlofobomojjdpmokpinbacoiaaopadngbgnnbcnecpilc", 1449484472)));
		}
		int x139e3125b0368c7f = xe134235b3526fa75.xdb264d863790ee7b();
		x84845c0d8e00bf00[] x1120528caaac0fef = x3c690af49e39332d(xe134235b3526fa75, x139e3125b0368c7f);
		return x02586bd9b4b297f7(xe134235b3526fa75, x1120528caaac0fef);
	}

	private static x84845c0d8e00bf00[] x3c690af49e39332d(xa8866d7566da0aa2 xe134235b3526fa75, int x139e3125b0368c7f)
	{
		long num = xe134235b3526fa75.x9e418ad9a56d1cf5.Position - 4;
		x84845c0d8e00bf00[] array = new x84845c0d8e00bf00[x139e3125b0368c7f];
		for (int i = 0; i < x139e3125b0368c7f; i++)
		{
			int platformId = xe134235b3526fa75.xdb264d863790ee7b();
			int encodingId = xe134235b3526fa75.xdb264d863790ee7b();
			int num2 = xe134235b3526fa75.x95ea7d23cc8ee04d();
			long position = xe134235b3526fa75.x9e418ad9a56d1cf5.Position;
			long position2 = num + num2;
			xe134235b3526fa75.x9e418ad9a56d1cf5.Position = position2;
			int format = xe134235b3526fa75.xdb264d863790ee7b();
			xe134235b3526fa75.x9e418ad9a56d1cf5.Position = position;
			array[i] = new x84845c0d8e00bf00(platformId, encodingId, format, position2);
		}
		return array;
	}

	private static x62bf5fe8b95eb273 x02586bd9b4b297f7(xa8866d7566da0aa2 xe134235b3526fa75, x84845c0d8e00bf00[] x1120528caaac0fef)
	{
		x84845c0d8e00bf00 x84845c0d8e00bf = x4a15fd75a381e356(x1120528caaac0fef, 3, 10, 12);
		if (x84845c0d8e00bf != null)
		{
			x954dd57976a05061 x954dd57976a5062 = x954dd57976a05061.x06b0e25aa6ad68a9(xe134235b3526fa75, x84845c0d8e00bf);
			return new x55ed23c5fdd2eb54(x954dd57976a5062.xe6414aff183c47a1, x954dd57976a5062.x448900fcb384c333);
		}
		x84845c0d8e00bf = x4a15fd75a381e356(x1120528caaac0fef, 3, 0, 4);
		if (x84845c0d8e00bf != null)
		{
			x3668d88d65d61a11 x3668d88d65d61a12 = x3668d88d65d61a11.x06b0e25aa6ad68a9(xe134235b3526fa75, x84845c0d8e00bf);
			return new x901fc661b84875af(x3668d88d65d61a12.xe6414aff183c47a1, x3668d88d65d61a12.x448900fcb384c333, x84845c0d8e00bf.xa6fc5ae695dd3435, x84845c0d8e00bf.xb120d6e4572c845b);
		}
		x84845c0d8e00bf = x4a15fd75a381e356(x1120528caaac0fef, 3, 1, 4);
		if (x84845c0d8e00bf != null)
		{
			x3668d88d65d61a11 x3668d88d65d61a13 = x3668d88d65d61a11.x06b0e25aa6ad68a9(xe134235b3526fa75, x84845c0d8e00bf);
			return new x901fc661b84875af(x3668d88d65d61a13.xe6414aff183c47a1, x3668d88d65d61a13.x448900fcb384c333, x84845c0d8e00bf.xa6fc5ae695dd3435, x84845c0d8e00bf.xb120d6e4572c845b);
		}
		x84845c0d8e00bf = x4a15fd75a381e356(x1120528caaac0fef, 0, 4);
		if (x84845c0d8e00bf != null)
		{
			x3668d88d65d61a11 x3668d88d65d61a14 = x3668d88d65d61a11.x06b0e25aa6ad68a9(xe134235b3526fa75, x84845c0d8e00bf);
			return new x901fc661b84875af(x3668d88d65d61a14.xe6414aff183c47a1, x3668d88d65d61a14.x448900fcb384c333, x84845c0d8e00bf.xa6fc5ae695dd3435, x84845c0d8e00bf.xb120d6e4572c845b);
		}
		throw new InvalidOperationException("Cannot find a required cmap encoding record.");
	}

	private static x84845c0d8e00bf00 x4a15fd75a381e356(x84845c0d8e00bf00[] x123a240f709ab110, int x0cd5a0cb9bc0ea92, int x260a5f1fd72412c6, int x5786461d089b10a0)
	{
		foreach (x84845c0d8e00bf00 x84845c0d8e00bf in x123a240f709ab110)
		{
			if (x84845c0d8e00bf.xa6fc5ae695dd3435 == x0cd5a0cb9bc0ea92 && x84845c0d8e00bf.xb120d6e4572c845b == x260a5f1fd72412c6 && x84845c0d8e00bf.xa890d2fd18bed2bc == x5786461d089b10a0)
			{
				return x84845c0d8e00bf;
			}
		}
		return null;
	}

	private static x84845c0d8e00bf00 x4a15fd75a381e356(x84845c0d8e00bf00[] x123a240f709ab110, int x0cd5a0cb9bc0ea92, int x5786461d089b10a0)
	{
		foreach (x84845c0d8e00bf00 x84845c0d8e00bf in x123a240f709ab110)
		{
			if (x84845c0d8e00bf.xa6fc5ae695dd3435 == x0cd5a0cb9bc0ea92 && x84845c0d8e00bf.xa890d2fd18bed2bc == x5786461d089b10a0)
			{
				return x84845c0d8e00bf;
			}
		}
		return null;
	}

	public x1d2b8403c6dd52f1 x914b35472a606900(x49a6906320d20269 xd1b03054aee6fc53, bool xcc2d531f2a952cc5)
	{
		x1d2b8403c6dd52f1 x1d2b8403c6dd52f2 = new x1d2b8403c6dd52f1(xcc2d531f2a952cc5);
		for (int i = 0; i < xe6414aff183c47a1.xd44988f225497f3a; i++)
		{
			int charCode = xe6414aff183c47a1.xf15263674eb297bb(i);
			int num = (int)xe6414aff183c47a1.x6d3720b962bd3112(i);
			x00ef2e50265c0d3e x00ef2e50265c0d3e2 = xd1b03054aee6fc53.xc9b9fba2361cb131(num);
			x7c1d47b289dfd9fa x7c1d47b289dfd9fa2 = new x7c1d47b289dfd9fa(charCode, num, x00ef2e50265c0d3e2.xf58adb71a3d2dade, x00ef2e50265c0d3e2.x25b14f802c09d3cc);
			x1d2b8403c6dd52f2.xd6b6ed77479ef68c(x7c1d47b289dfd9fa2);
			if (x7c1d47b289dfd9fa2.xf642ec8fe8ccb98e == 0)
			{
				x1d2b8403c6dd52f2.x03efdcbb7b70d603 = x7c1d47b289dfd9fa2;
			}
		}
		return x1d2b8403c6dd52f2;
	}

	public void xbb283a1aa30876b0(x09ce2c02826e31a6 xf587a89edd1bf25b)
	{
		xe6414aff183c47a1 = xf587a89edd1bf25b;
	}

	internal override void x6210059f049f0d48(x73087173962e3778 xbdfb620b7167944b)
	{
		x6c5a92230c2f59e2[] array = BuildSubtables();
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < array.Length; i++)
		{
			arrayList.Add(array[i].xbdc1ba5a08db0865());
		}
		xbdfb620b7167944b.xab5f6b7526efa5be(0);
		xbdfb620b7167944b.xab5f6b7526efa5be(array.Length);
		int num = 4 + 8 * array.Length;
		for (int j = 0; j < array.Length; j++)
		{
			xbdfb620b7167944b.xab5f6b7526efa5be(array[j].xa6fc5ae695dd3435);
			xbdfb620b7167944b.xab5f6b7526efa5be(array[j].xb120d6e4572c845b);
			xbdfb620b7167944b.x04aa082effd9db6b((uint)num);
			num += ((byte[])arrayList[j]).Length;
		}
		for (int k = 0; k < array.Length; k++)
		{
			xbdfb620b7167944b.x4c116b70372a3c6d((byte[])arrayList[k]);
		}
	}

	protected abstract x6c5a92230c2f59e2[] BuildSubtables();
}
