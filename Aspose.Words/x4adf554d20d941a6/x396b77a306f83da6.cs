using System;
using System.Drawing;
using Aspose.Words;
using x28925c9b27b37a46;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;
using xeb665d1aeef09d64;

namespace x4adf554d20d941a6;

internal class x396b77a306f83da6 : xcf9d359063aa93f2
{
	private const float x56fd6ec83b3dfd68 = 0.15f;

	private const float xd5cb95a8afef260e = -0.303f;

	private const float x4cba4c13f250c226 = 0.65f;

	private const float x7902fa835e6aa32e = 0.8f;

	private xe39d06eee35dd23d x9c3aade31d9f02e3;

	private string xc61ff88f1f98652d = xca92ff9de922cda5;

	private string x9bb92a035769093b = x356de5070514ea7f;

	private int x3b77a41bd57164d6 = x0d463bea0ea19697;

	private int xbc45ce13829f839a = x648c0039ab1385f7;

	private FontStyle x5d9fbd9603e9dee5 = xafb26f9d36aac302;

	private FontStyle x6be3aea3c48f1c57 = x4fb15352fae50f16;

	private x26d9ecb4bdf0456d x78e4acec873c7675 = xb25b078706c08b33;

	private xa79d032ee44aba11 xcdf544eb89f5a085 = xd3c4697066973aa5;

	private x7af53bbecc5ccdd5 x4f252da769414406 = x9b881e26aedb41b4;

	private xc92cdbffb9d00ef3 x263a1d58881eac81 = x615ba745962075d6;

	private x0ae5fe02c6cbfde7 x72a434804f069d96 = x9b52992d419c7207;

	private bool x33420055ffc98118 = x98ec11f174114510;

	private bool x1ac95c5076e9c954 = x221bfc8cfc24b05e;

	private bool xed59c429c6e58585 = x47a430d988ac69bd;

	private bool x7be0bb52839eae9c = xe9556fd0feba1223;

	private int xa3f9b2fd98264390 = xe965bd2c99fd75a5;

	private Underline xa68cb11d4b5dd9ab = x9baca3b708bccd23;

	private x26d9ecb4bdf0456d x0a3117e28c2d0595 = xad0ca6cf4f8dc60f;

	private x26d9ecb4bdf0456d x9e12207760592881 = x3b7633918e6b1d8f;

	private int x53f147a75a984b21 = xded8336e736567e8;

	private int x7bccdf4f2aec7e0d = x3200f2762438e0ae;

	private x5709acc7200773ff xd5b8e665718e74aa = x6fcc1539fbde2520;

	private xc8e01097217ac9d2 x3befc831c712898b = x4aa537625a578e63;

	private xe39d06eee35dd23d x83cd810ab70afec3;

	private bool x17a79d6481a0c3e4 = xd4937a21f63856b9;

	private x29ade4ed2382a039 x4fa5692f652572f4 = x9d888f53892d94df.x9834ddb0e0bd5996;

	private static readonly string xca92ff9de922cda5 = (string)xeedad81aaed42a76.x0095b789d636f3ae(230);

	private static readonly string x356de5070514ea7f = "";

	private static readonly int x0d463bea0ea19697 = x4574ea26106f0edb.x9e20b93bb584bff2((int)xeedad81aaed42a76.x0095b789d636f3ae(190));

	private static readonly int x648c0039ab1385f7 = x4574ea26106f0edb.x9e20b93bb584bff2((int)xeedad81aaed42a76.x0095b789d636f3ae(350));

	private static readonly FontStyle xafb26f9d36aac302 = FontStyle.Regular;

	private static readonly FontStyle x4fb15352fae50f16 = FontStyle.Regular;

	private static readonly x26d9ecb4bdf0456d xb25b078706c08b33 = (x26d9ecb4bdf0456d)xeedad81aaed42a76.x0095b789d636f3ae(160);

	private static readonly xa79d032ee44aba11 xd3c4697066973aa5 = xa79d032ee44aba11.x4d0b9d4447ba7566;

	private static readonly x7af53bbecc5ccdd5 x9b881e26aedb41b4 = x7af53bbecc5ccdd5.x139412b8dea2f02b;

	private static readonly xc92cdbffb9d00ef3 x615ba745962075d6 = xc92cdbffb9d00ef3.x4d0b9d4447ba7566;

	private static readonly x0ae5fe02c6cbfde7 x9b52992d419c7207 = x0ae5fe02c6cbfde7.x4d0b9d4447ba7566;

	private static readonly bool x98ec11f174114510 = false;

	private static readonly bool x221bfc8cfc24b05e = false;

	private static readonly bool x47a430d988ac69bd = false;

	private static readonly bool xe9556fd0feba1223 = xeedad81aaed42a76.x0095b789d636f3ae(268) == x9b28b1f7f0cc963f.xbbad6bbe73c6b1dc;

	private static readonly int xe965bd2c99fd75a5 = -x4574ea26106f0edb.x9e20b93bb584bff2((int)xeedad81aaed42a76.x0095b789d636f3ae(200));

	private static readonly Underline x9baca3b708bccd23 = (Underline)xeedad81aaed42a76.x0095b789d636f3ae(140);

	private static readonly x26d9ecb4bdf0456d xad0ca6cf4f8dc60f = (x26d9ecb4bdf0456d)xeedad81aaed42a76.x0095b789d636f3ae(450);

	private static readonly x26d9ecb4bdf0456d x3b7633918e6b1d8f = (x26d9ecb4bdf0456d)xeedad81aaed42a76.x0095b789d636f3ae(20);

	private static readonly x5709acc7200773ff x6fcc1539fbde2520 = new x5709acc7200773ff(null, initKey: true);

	private static readonly xc8e01097217ac9d2 x4aa537625a578e63 = xc8e01097217ac9d2.x45260ad4b94166f2;

	private static readonly int xded8336e736567e8 = (int)xeedad81aaed42a76.x0095b789d636f3ae(290);

	private static readonly int x3200f2762438e0ae = x4574ea26106f0edb.x370502bb60141209((int)xeedad81aaed42a76.x0095b789d636f3ae(150));

	private static readonly bool xd4937a21f63856b9 = false;

	internal string x759aa16c2016a289
	{
		get
		{
			return xc61ff88f1f98652d;
		}
		set
		{
			x71c6d753219cc1b7();
			xc61ff88f1f98652d = x09d499c483428bd1.x728c19b085a53832(value);
		}
	}

	internal string x622e47c05b903ad2
	{
		get
		{
			return x9bb92a035769093b;
		}
		set
		{
			x71c6d753219cc1b7();
			x9bb92a035769093b = x09d499c483428bd1.x728c19b085a53832(value);
		}
	}

	internal int x437e3b626c0fdd43
	{
		get
		{
			return x3b77a41bd57164d6;
		}
		set
		{
			x71c6d753219cc1b7();
			x3b77a41bd57164d6 = value;
		}
	}

	internal int xa7229a54449aaf49
	{
		get
		{
			return xbc45ce13829f839a;
		}
		set
		{
			x71c6d753219cc1b7();
			xbc45ce13829f839a = value;
		}
	}

	internal int x33b9d351396f0e2f
	{
		get
		{
			if (!x3a7473f820dd300b && !x4dcd0de8fd7fe251)
			{
				return x437e3b626c0fdd43;
			}
			return xa7229a54449aaf49;
		}
	}

	internal FontStyle xfe2178c1f916f36c
	{
		get
		{
			return x5d9fbd9603e9dee5;
		}
		set
		{
			x71c6d753219cc1b7();
			x5d9fbd9603e9dee5 = value;
		}
	}

	internal FontStyle x94a199d827e52b9b
	{
		get
		{
			return x6be3aea3c48f1c57;
		}
		set
		{
			x71c6d753219cc1b7();
			x6be3aea3c48f1c57 = value;
		}
	}

	internal FontStyle xdd1a27afdb54ae5b
	{
		get
		{
			if (!x3a7473f820dd300b && !x4dcd0de8fd7fe251)
			{
				return xfe2178c1f916f36c;
			}
			return x94a199d827e52b9b;
		}
	}

	internal x26d9ecb4bdf0456d x9b41425268471380
	{
		get
		{
			return x78e4acec873c7675;
		}
		set
		{
			x71c6d753219cc1b7();
			x78e4acec873c7675 = x9e48744bdf3be5f8(value);
		}
	}

	internal xa79d032ee44aba11 xa6417f0b87702333
	{
		get
		{
			return xcdf544eb89f5a085;
		}
		set
		{
			x71c6d753219cc1b7();
			xcdf544eb89f5a085 = value;
		}
	}

	internal x7af53bbecc5ccdd5 x838b2dfd1391264c
	{
		get
		{
			return x4f252da769414406;
		}
		set
		{
			x71c6d753219cc1b7();
			x4f252da769414406 = value;
		}
	}

	internal xc92cdbffb9d00ef3 x2fb115b47db0d216
	{
		get
		{
			return x263a1d58881eac81;
		}
		set
		{
			x71c6d753219cc1b7();
			x263a1d58881eac81 = value;
		}
	}

	internal x0ae5fe02c6cbfde7 xfedaa23df3912116
	{
		get
		{
			return x72a434804f069d96;
		}
		set
		{
			x71c6d753219cc1b7();
			x72a434804f069d96 = value;
		}
	}

	internal bool x24385217e0d88ab8
	{
		get
		{
			return x33420055ffc98118;
		}
		set
		{
			x71c6d753219cc1b7();
			x33420055ffc98118 = value;
		}
	}

	internal bool x17c40acbe47f16cc
	{
		get
		{
			return x1ac95c5076e9c954;
		}
		set
		{
			x71c6d753219cc1b7();
			x1ac95c5076e9c954 = value;
		}
	}

	internal bool x3a7473f820dd300b
	{
		get
		{
			return xed59c429c6e58585;
		}
		set
		{
			x71c6d753219cc1b7();
			xed59c429c6e58585 = value;
		}
	}

	internal bool x4dcd0de8fd7fe251
	{
		get
		{
			return x7be0bb52839eae9c;
		}
		set
		{
			x71c6d753219cc1b7();
			x7be0bb52839eae9c = value;
		}
	}

	internal bool x7727f8ae3791a45c
	{
		get
		{
			return x17a79d6481a0c3e4;
		}
		set
		{
			x71c6d753219cc1b7();
			x17a79d6481a0c3e4 = value;
		}
	}

	internal int xbe1e23e7d5b43370
	{
		get
		{
			return xa3f9b2fd98264390;
		}
		set
		{
			x71c6d753219cc1b7();
			xa3f9b2fd98264390 = value;
		}
	}

	internal Underline x2588d8c20c42e232
	{
		get
		{
			return xa68cb11d4b5dd9ab;
		}
		set
		{
			x71c6d753219cc1b7();
			xa68cb11d4b5dd9ab = value;
		}
	}

	internal x26d9ecb4bdf0456d x36197c67d114da57
	{
		get
		{
			return x0a3117e28c2d0595;
		}
		set
		{
			x71c6d753219cc1b7();
			x0a3117e28c2d0595 = x9e48744bdf3be5f8(value);
		}
	}

	internal x26d9ecb4bdf0456d xabb599f76795ecaf
	{
		get
		{
			return x9e12207760592881;
		}
		set
		{
			x71c6d753219cc1b7();
			x9e12207760592881 = value;
		}
	}

	internal int x5152a5707921c783
	{
		get
		{
			return x53f147a75a984b21;
		}
		set
		{
			x71c6d753219cc1b7();
			x53f147a75a984b21 = value;
		}
	}

	internal int x9ba60a33bc3988dc
	{
		get
		{
			return x7bccdf4f2aec7e0d;
		}
		set
		{
			x71c6d753219cc1b7();
			x7bccdf4f2aec7e0d = value;
		}
	}

	internal x5709acc7200773ff x554aca059bdf6d48
	{
		get
		{
			if (xd5b8e665718e74aa == null)
			{
				xd5b8e665718e74aa = new x5709acc7200773ff(x17dcbf5fe3c0d2d2, initKey: false);
			}
			return xd5b8e665718e74aa;
		}
		set
		{
			x71c6d753219cc1b7();
			xd5b8e665718e74aa = value;
		}
	}

	internal xc8e01097217ac9d2 x51d60f077c5fc6e0
	{
		get
		{
			if (x3befc831c712898b == null)
			{
				x3befc831c712898b = new xc8e01097217ac9d2(x17dcbf5fe3c0d2d2, initKey: false);
			}
			return x3befc831c712898b;
		}
		set
		{
			x71c6d753219cc1b7();
			x3befc831c712898b = value;
		}
	}

	internal xe39d06eee35dd23d xc2d4efc42998d87b
	{
		get
		{
			if (x83cd810ab70afec3 == null)
			{
				int x23f780eed403f = xfffbd0151e8dd680(x282df02f8c72bc6f: false);
				FontStyle x183d1a5479ec50ad = ((x3a7473f820dd300b && x7727f8ae3791a45c && (xdd1a27afdb54ae5b & FontStyle.Italic) != 0) ? (xdd1a27afdb54ae5b ^ FontStyle.Italic) : xdd1a27afdb54ae5b);
				x83cd810ab70afec3 = x76cdec455967c074.x491f5a7224612753(x759aa16c2016a289, x4574ea26106f0edb.xc96d70553223ee04(x23f780eed403f), xdd1a27afdb54ae5b, x622e47c05b903ad2, x183d1a5479ec50ad);
			}
			return x83cd810ab70afec3;
		}
	}

	internal bool xa143daf3bef8b339 => 0 != (FontStyle.Bold & xdd1a27afdb54ae5b);

	internal bool xb65ca9637cc40782 => 0 != (FontStyle.Italic & xdd1a27afdb54ae5b);

	internal xe39d06eee35dd23d x35bec0bfb68de7e7
	{
		get
		{
			if (x9c3aade31d9f02e3 == null && x4fa5692f652572f4 != null)
			{
				x9c3aade31d9f02e3 = x4fa5692f652572f4.x491f5a7224612753(x759aa16c2016a289, x4574ea26106f0edb.xc96d70553223ee04(x33b9d351396f0e2f), xdd1a27afdb54ae5b, x622e47c05b903ad2);
			}
			return x9c3aade31d9f02e3;
		}
	}

	internal int xb693569a6983902d
	{
		get
		{
			int num = 0;
			if (x7af53bbecc5ccdd5.x1b1f4712a1a0c38c == x838b2dfd1391264c)
			{
				num = (int)((float)x437e3b626c0fdd43 * 0.15f);
			}
			else if (x7af53bbecc5ccdd5.xab66d68facbadf18 == x838b2dfd1391264c)
			{
				num = (int)((float)x437e3b626c0fdd43 * -0.303f);
			}
			return num + xbe1e23e7d5b43370;
		}
	}

	internal x29ade4ed2382a039 x76cdec455967c074
	{
		get
		{
			return x4fa5692f652572f4;
		}
		set
		{
			x4fa5692f652572f4 = value;
		}
	}

	internal x396b77a306f83da6(x17dcbf5fe3c0d2d2 cacheContext)
		: base(cacheContext)
	{
	}

	public override bool Equals(object obj)
	{
		if (obj == this)
		{
			return true;
		}
		if (!x39f156868f37b760(obj))
		{
			return false;
		}
		x396b77a306f83da6 x396b77a306f83da7 = (x396b77a306f83da6)obj;
		return object.Equals(x759aa16c2016a289, x396b77a306f83da7.x759aa16c2016a289) && object.Equals(x622e47c05b903ad2, x396b77a306f83da7.x622e47c05b903ad2) && object.Equals(x9b41425268471380, x396b77a306f83da7.x9b41425268471380) && xa6417f0b87702333 == x396b77a306f83da7.xa6417f0b87702333 && x838b2dfd1391264c == x396b77a306f83da7.x838b2dfd1391264c && x2fb115b47db0d216 == x396b77a306f83da7.x2fb115b47db0d216 && xfedaa23df3912116 == x396b77a306f83da7.xfedaa23df3912116 && x24385217e0d88ab8 == x396b77a306f83da7.x24385217e0d88ab8 && x17c40acbe47f16cc == x396b77a306f83da7.x17c40acbe47f16cc && x3a7473f820dd300b == x396b77a306f83da7.x3a7473f820dd300b && x4dcd0de8fd7fe251 == x396b77a306f83da7.x4dcd0de8fd7fe251 && xbe1e23e7d5b43370.Equals(x396b77a306f83da7.xbe1e23e7d5b43370) && x2588d8c20c42e232 == x396b77a306f83da7.x2588d8c20c42e232 && object.Equals(x36197c67d114da57, x396b77a306f83da7.x36197c67d114da57) && object.Equals(xabb599f76795ecaf, x396b77a306f83da7.xabb599f76795ecaf) && x5152a5707921c783.Equals(x396b77a306f83da7.x5152a5707921c783) && x9ba60a33bc3988dc.Equals(x396b77a306f83da7.x9ba60a33bc3988dc) && x51d60f077c5fc6e0.Equals(x396b77a306f83da7.x51d60f077c5fc6e0) && object.Equals(x554aca059bdf6d48, x396b77a306f83da7.x554aca059bdf6d48) && x33b9d351396f0e2f.Equals(x396b77a306f83da7.x33b9d351396f0e2f) && xdd1a27afdb54ae5b == x396b77a306f83da7.xdd1a27afdb54ae5b && x7727f8ae3791a45c == x396b77a306f83da7.x7727f8ae3791a45c;
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	protected override void AddKeysToHashCode()
	{
		xd94964d84c426258(x759aa16c2016a289);
		xd94964d84c426258(x622e47c05b903ad2);
		xd94964d84c426258(x9b41425268471380);
		x1e94bce19c84490b(xa6417f0b87702333);
		x1e94bce19c84490b(x838b2dfd1391264c);
		x1e94bce19c84490b(x2fb115b47db0d216);
		x1e94bce19c84490b(xfedaa23df3912116);
		x1e94bce19c84490b(x24385217e0d88ab8);
		x1e94bce19c84490b(x17c40acbe47f16cc);
		x1e94bce19c84490b(x3a7473f820dd300b);
		x1e94bce19c84490b(x4dcd0de8fd7fe251);
		x1e94bce19c84490b(xbe1e23e7d5b43370);
		x1e94bce19c84490b(x2588d8c20c42e232);
		xd94964d84c426258(x36197c67d114da57);
		xd94964d84c426258(xabb599f76795ecaf);
		x1e94bce19c84490b(x5152a5707921c783);
		x1e94bce19c84490b(x9ba60a33bc3988dc);
		xd94964d84c426258(x51d60f077c5fc6e0);
		xd94964d84c426258(x554aca059bdf6d48);
		xd94964d84c426258(x7727f8ae3791a45c);
		x1e94bce19c84490b(x33b9d351396f0e2f);
		x1e94bce19c84490b(xdd1a27afdb54ae5b);
	}

	internal int x7537b54a407680bd(int x9b0739496f8b5475, int x10f4d88af727adbc)
	{
		return Math.Max(0, x9b0739496f8b5475 * x5152a5707921c783 / 100 + x9ba60a33bc3988dc * x10f4d88af727adbc);
	}

	internal static x396b77a306f83da6 xdb83cd4968ca9d31(x396b77a306f83da6 x94aec03cf2ae750b)
	{
		if (x94aec03cf2ae750b == null)
		{
			throw new ArgumentNullException("pr");
		}
		x396b77a306f83da6 x396b77a306f83da7 = new x396b77a306f83da6(x94aec03cf2ae750b.x17dcbf5fe3c0d2d2);
		x396b77a306f83da7.x759aa16c2016a289 = x94aec03cf2ae750b.xc61ff88f1f98652d;
		x396b77a306f83da7.x622e47c05b903ad2 = x94aec03cf2ae750b.x9bb92a035769093b;
		x396b77a306f83da7.x437e3b626c0fdd43 = x94aec03cf2ae750b.x3b77a41bd57164d6;
		x396b77a306f83da7.xa7229a54449aaf49 = x94aec03cf2ae750b.xbc45ce13829f839a;
		x396b77a306f83da7.xfe2178c1f916f36c = x94aec03cf2ae750b.x5d9fbd9603e9dee5;
		x396b77a306f83da7.x94a199d827e52b9b = x94aec03cf2ae750b.x6be3aea3c48f1c57;
		x396b77a306f83da7.x9b41425268471380 = x94aec03cf2ae750b.x78e4acec873c7675;
		x396b77a306f83da7.xa6417f0b87702333 = x94aec03cf2ae750b.xcdf544eb89f5a085;
		x396b77a306f83da7.x838b2dfd1391264c = x94aec03cf2ae750b.x4f252da769414406;
		x396b77a306f83da7.x2fb115b47db0d216 = x94aec03cf2ae750b.x263a1d58881eac81;
		x396b77a306f83da7.xfedaa23df3912116 = x94aec03cf2ae750b.x72a434804f069d96;
		x396b77a306f83da7.xbe1e23e7d5b43370 = x94aec03cf2ae750b.xa3f9b2fd98264390;
		x396b77a306f83da7.x2588d8c20c42e232 = x94aec03cf2ae750b.xa68cb11d4b5dd9ab;
		x396b77a306f83da7.x36197c67d114da57 = x94aec03cf2ae750b.x0a3117e28c2d0595;
		x396b77a306f83da7.xabb599f76795ecaf = x94aec03cf2ae750b.xabb599f76795ecaf;
		x396b77a306f83da7.x554aca059bdf6d48 = x5709acc7200773ff.xdb83cd4968ca9d31(x94aec03cf2ae750b.x554aca059bdf6d48);
		x396b77a306f83da7.x51d60f077c5fc6e0 = xc8e01097217ac9d2.xdb83cd4968ca9d31(x94aec03cf2ae750b.x51d60f077c5fc6e0);
		x396b77a306f83da7.x24385217e0d88ab8 = x94aec03cf2ae750b.x24385217e0d88ab8;
		x396b77a306f83da7.x17c40acbe47f16cc = x94aec03cf2ae750b.x17c40acbe47f16cc;
		x396b77a306f83da7.x3a7473f820dd300b = x94aec03cf2ae750b.x3a7473f820dd300b;
		x396b77a306f83da7.x4dcd0de8fd7fe251 = x94aec03cf2ae750b.x4dcd0de8fd7fe251;
		x396b77a306f83da7.x7727f8ae3791a45c = x94aec03cf2ae750b.x7727f8ae3791a45c;
		x396b77a306f83da7.x76cdec455967c074 = x94aec03cf2ae750b.x4fa5692f652572f4;
		return x396b77a306f83da7;
	}

	internal static x396b77a306f83da6 x38758cbbee49e4cb(x396b77a306f83da6 x50a18ad2656e7181)
	{
		if (x50a18ad2656e7181 == null)
		{
			x50a18ad2656e7181 = new x396b77a306f83da6(null);
		}
		if (x50a18ad2656e7181.x17dcbf5fe3c0d2d2 == null)
		{
			return x50a18ad2656e7181;
		}
		if (x50a18ad2656e7181.xe76bdd563aa52beb)
		{
			return x50a18ad2656e7181;
		}
		x396b77a306f83da6 x396b77a306f83da7 = (x396b77a306f83da6)x50a18ad2656e7181.x17dcbf5fe3c0d2d2.x5eb03bde75c05b09[x50a18ad2656e7181];
		if (x396b77a306f83da7 == null)
		{
			x50a18ad2656e7181.x17dcbf5fe3c0d2d2.x5eb03bde75c05b09.Add(x50a18ad2656e7181, x396b77a306f83da7 = x50a18ad2656e7181);
		}
		return x396b77a306f83da7;
	}

	internal static x26d9ecb4bdf0456d x9e48744bdf3be5f8(x26d9ecb4bdf0456d x6c50a99faab7d741)
	{
		if (!x6c50a99faab7d741.x7149c962c02931b3)
		{
			return x4574ea26106f0edb.xd28d528ac0b51a0b(x6c50a99faab7d741);
		}
		return x6c50a99faab7d741;
	}

	private int xfffbd0151e8dd680(bool x282df02f8c72bc6f)
	{
		float num = x4574ea26106f0edb.xb4666701f4f1abda(x33b9d351396f0e2f);
		if (x838b2dfd1391264c != 0)
		{
			num *= 0.65f;
		}
		if (!x282df02f8c72bc6f && xa79d032ee44aba11.x3225daf421fc5451 == xa6417f0b87702333)
		{
			num *= 0.8f;
		}
		return x4574ea26106f0edb.x9e20b93bb584bff2((float)Math.Round(num));
	}
}
