using System;
using System.Collections;
using System.Reflection;
using Aspose.Words;
using Aspose.Words.Markup;
using x26869753cb97bfe9;
using xa604c4d210ae0581;
using xaa035fc640f94856;

namespace x9e260ffa1ac41ffa;

[DefaultMember("Item")]
internal class xe397b5e25a350375 : ArrayList
{
	private readonly Stack x2541962fa4cd7d53 = new Stack();

	private readonly x2b702525301ee74a x4bd039d469a1155d = new x2b702525301ee74a();

	private readonly x31a5ab258b5c21f3 x6b14c9185a3728ac = new x31a5ab258b5c21f3();

	private readonly x39a0e849afa5b554 x9e13e6ed8c58777d = new x39a0e849afa5b554();

	private readonly xd078c45cd488fe12 x36e301e29d2c8d7c = new xd078c45cd488fe12();

	private static bool x492f529cee830a40;

	internal int x3e287ef15dc898f3 => x160148977c47d910.x1be93eed8950d961;

	internal int x94a76e3a5bbb5ca6
	{
		get
		{
			int num = 0;
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					x34324dde15a17bf1 x34324dde15a17bf2 = (x34324dde15a17bf1)enumerator.Current;
					num += x34324dde15a17bf2.xf9ad6fb78355fe13.Length;
				}
				return num;
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
		}
	}

	internal x34324dde15a17bf1 xe6d4b1b411ed94b5 => base[(int)x77b06614416ee4d3] as x34324dde15a17bf1;

	internal x9e131021ba70185c x9e131021ba70185c => x160148977c47d910.x9e131021ba70185c;

	internal int xb8414804f39a9e90 => x160148977c47d910.xb8414804f39a9e90;

	internal x2b702525301ee74a xeafe18c850ae3127 => x4bd039d469a1155d;

	internal x31a5ab258b5c21f3 xd0816c20f484d380 => x6b14c9185a3728ac;

	internal x39a0e849afa5b554 x79d596439da1c44b => x9e13e6ed8c58777d;

	internal xd078c45cd488fe12 x32cf407a95cab3cd => x36e301e29d2c8d7c;

	private x34324dde15a17bf1 x160148977c47d910 => x2541962fa4cd7d53.Peek() as x34324dde15a17bf1;

	internal xe397b5e25a350375()
	{
		for (int i = 0; i <= 6; i++)
		{
			Add(new x34324dde15a17bf1((x9e131021ba70185c)i));
		}
	}

	internal void xb264ad2ce3daa0a4(x9e131021ba70185c x77b06614416ee4d3)
	{
		_ = x492f529cee830a40;
		x2541962fa4cd7d53.Push(this.get_xe6d4b1b411ed94b5(x77b06614416ee4d3));
	}

	internal void xc4104b442b4f6eb6()
	{
		_ = x492f529cee830a40;
		x2541962fa4cd7d53.Pop();
	}

	internal void x8ffe90e7fbccfccd(int x65533babc4098e1c)
	{
		x692f3f46f8381b0f();
		xede0b8130b9f5166(x65533babc4098e1c);
		xdd0c5d9abfb2e0be();
		xbbc294c030ba6ebd();
		x35909a4b0ca27c7d();
		xb22e80a126ed3258();
	}

	private void x692f3f46f8381b0f()
	{
		int x5808173d = x94a76e3a5bbb5ca6;
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				x34324dde15a17bf1 x34324dde15a17bf2 = (x34324dde15a17bf1)enumerator.Current;
				x34324dde15a17bf2.x692f3f46f8381b0f(x5808173d);
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
	}

	private void xede0b8130b9f5166(int x65533babc4098e1c)
	{
		int num = x65533babc4098e1c;
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				x34324dde15a17bf1 x34324dde15a17bf2 = (x34324dde15a17bf1)enumerator.Current;
				x34324dde15a17bf2.xf8b5e62cf3165594.x09663d2eb09f3fd9(num);
				x34324dde15a17bf2.xdb6ea7a460485a97.x09663d2eb09f3fd9(num);
				num += x34324dde15a17bf2.xf9ad6fb78355fe13.Length * 2;
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
	}

	private void xdd0c5d9abfb2e0be()
	{
		int num = 0;
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				x34324dde15a17bf1 x34324dde15a17bf2 = (x34324dde15a17bf1)enumerator.Current;
				x4bd039d469a1155d.xf3280842efde82ac(x34324dde15a17bf2.xeafe18c850ae3127, num);
				num += x34324dde15a17bf2.xf9ad6fb78355fe13.Length;
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
	}

	private void xbbc294c030ba6ebd()
	{
		int num = 0;
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				x34324dde15a17bf1 x34324dde15a17bf2 = (x34324dde15a17bf1)enumerator.Current;
				x6b14c9185a3728ac.x21befe581f77d29a(x34324dde15a17bf2.xd0816c20f484d380, num);
				num += x34324dde15a17bf2.xf9ad6fb78355fe13.Length;
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		x6b14c9185a3728ac.x8ffe90e7fbccfccd(x94a76e3a5bbb5ca6);
	}

	private void x35909a4b0ca27c7d()
	{
		int num = 0;
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				x34324dde15a17bf1 x34324dde15a17bf2 = (x34324dde15a17bf1)enumerator.Current;
				x9e13e6ed8c58777d.x63886010ed8cb7a5(x34324dde15a17bf2.x79d596439da1c44b, num);
				num += x34324dde15a17bf2.xf9ad6fb78355fe13.Length;
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		x9e13e6ed8c58777d.x8ffe90e7fbccfccd(x94a76e3a5bbb5ca6);
	}

	private void xb22e80a126ed3258()
	{
		int num = 0;
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				x34324dde15a17bf1 x34324dde15a17bf2 = (x34324dde15a17bf1)enumerator.Current;
				x36e301e29d2c8d7c.x2369ec465d328eba(x34324dde15a17bf2.x32cf407a95cab3cd, num);
				num += x34324dde15a17bf2.xf9ad6fb78355fe13.Length;
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		x36e301e29d2c8d7c.x8ffe90e7fbccfccd(x94a76e3a5bbb5ca6);
	}

	internal void x917b69030691beda(string xb41faee6912a2313)
	{
		x160148977c47d910.xf9ad6fb78355fe13.Append(xb41faee6912a2313);
	}

	internal void x811fbd3fde91eb05(int xfe2db68d5eb8b6f4, int x881407805cd3b591, x9dba795deb731d48 x95ebd6ae2e7f8ff5)
	{
		x160148977c47d910.xdb6ea7a460485a97.xd6b6ed77479ef68c(xfe2db68d5eb8b6f4, x881407805cd3b591, x95ebd6ae2e7f8ff5);
	}

	internal void x69dc2014b9eea9e3(xb96b10c688c10ef2 xbecee44ffb4c67ff)
	{
		x160148977c47d910.x84aa3570d857bec4.xd6b6ed77479ef68c(x3e287ef15dc898f3, xbecee44ffb4c67ff);
	}

	internal void xa5c8bd4eb8264c5b(string xc15bd84e01929885, int xebf45bdcaa1fd1e1)
	{
		x160148977c47d910.xeafe18c850ae3127.xffb003338cfde846(x3e287ef15dc898f3, xc15bd84e01929885, xebf45bdcaa1fd1e1);
	}

	internal void x6d5145c03507a8ad(string xc15bd84e01929885)
	{
		x160148977c47d910.xeafe18c850ae3127.x1ff8ac05a72bd9dd(x3e287ef15dc898f3, xc15bd84e01929885);
	}

	internal void xdfafe7603e2ef7d0(SmartTag xdc6161a296532e34)
	{
		x160148977c47d910.xd0816c20f484d380.xffb003338cfde846(x3e287ef15dc898f3, xdc6161a296532e34);
	}

	internal void x386937ee946030a9(SmartTag xdc6161a296532e34)
	{
		x160148977c47d910.xd0816c20f484d380.x1ff8ac05a72bd9dd(x3e287ef15dc898f3, xdc6161a296532e34);
	}

	internal void x2a6a39361495c83c(CustomXmlMarkup x2f992229ae4fc9a1)
	{
		x160148977c47d910.x79d596439da1c44b.xffb003338cfde846(x3e287ef15dc898f3, x2f992229ae4fc9a1);
	}

	internal void x69b2ede4917298d1(CustomXmlMarkup x2f992229ae4fc9a1)
	{
		x160148977c47d910.x79d596439da1c44b.x1ff8ac05a72bd9dd(x3e287ef15dc898f3, x2f992229ae4fc9a1);
	}

	internal void xa2cd36b80ce91fbe(SubDocument x099a571ab336faf8)
	{
		x160148977c47d910.x32cf407a95cab3cd.xd6b6ed77479ef68c(x3e287ef15dc898f3, x099a571ab336faf8);
	}

	internal void x959bfe125105856a(x3ff949c473a702d2 x03ef0b0129c670a6)
	{
		x160148977c47d910.xf8b5e62cf3165594.xd6b6ed77479ef68c(x3e287ef15dc898f3, x03ef0b0129c670a6);
	}

	internal void x5e3f44647fcfb8fc()
	{
		x160148977c47d910.x5e3f44647fcfb8fc();
	}

	internal void xbdbbc98113b6b783()
	{
		x160148977c47d910.xbdbbc98113b6b783();
	}
}
