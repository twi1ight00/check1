using System;
using System.Collections;
using System.Reflection;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace xfbd1009a0cbb9842;

[DefaultMember("Item")]
internal class xbe79105033f99558 : IEnumerable
{
	private class x85484311e7900b5f : IEnumerator
	{
		private readonly x0a80b8c2d1e8cf13 x0b3adedaedb5773e;

		public object Current
		{
			get
			{
				xcfa6f73a76d96956 xcfa6f73a76d96957 = (xcfa6f73a76d96956)x0b3adedaedb5773e.x35cfcea4890f4e7d;
				return xcfa6f73a76d96957.x1745ba6c6d5efbc4.xd961adf06ad48c3f();
			}
		}

		public x85484311e7900b5f(IEnumerator switchEnumerator)
		{
			x0b3adedaedb5773e = new x0a80b8c2d1e8cf13(switchEnumerator);
		}

		public bool MoveNext()
		{
			while (x0b3adedaedb5773e.x47f176deff0d42e2())
			{
				xcfa6f73a76d96956 x5f9c2fff5fcaeab = (xcfa6f73a76d96956)x0b3adedaedb5773e.x35cfcea4890f4e7d;
				if (xbfd984f469f0f82c(x5f9c2fff5fcaeab))
				{
					return true;
				}
			}
			return false;
		}

		public void Reset()
		{
			x0b3adedaedb5773e.x74f5a1ef3906e23c();
		}
	}

	private const string xb590a75cf7b4e9c5 = "\\*";

	private readonly x985dd08fd338eeea x17b196bc6252cd1a;

	internal int xd44988f225497f3a
	{
		get
		{
			int num = 0;
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					string text = (string)enumerator.Current;
					num++;
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

	internal string xe6d4b1b411ed94b5
	{
		get
		{
			int num = 0;
			foreach (xcfa6f73a76d96956 item in x17b196bc6252cd1a.x7261c103565fa212)
			{
				if (xbfd984f469f0f82c(item))
				{
					if (num == xc0c4c459c6ccbd00)
					{
						return item.x1745ba6c6d5efbc4.xd961adf06ad48c3f();
					}
					num++;
				}
			}
			return null;
		}
	}

	internal xbe79105033f99558(x985dd08fd338eeea fieldCode)
	{
		x17b196bc6252cd1a = fieldCode;
	}

	internal void xd6b6ed77479ef68c(string xbcea506a33cf9111)
	{
		x17b196bc6252cd1a.x3a70a872b0ded8b0("\\*", xbcea506a33cf9111, xd44988f225497f3a);
	}

	internal void x52b190e626f65140(string xbcea506a33cf9111)
	{
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < xd44988f225497f3a; i++)
		{
			if (x0d299f323d241756.x90637a473b1ceaaa(this.get_xe6d4b1b411ed94b5(i), xbcea506a33cf9111))
			{
				arrayList.Add(i);
			}
		}
		for (int num = arrayList.Count - 1; num >= 0; num--)
		{
			x7121e9e177952651((int)arrayList[num]);
		}
	}

	internal void x7121e9e177952651(int xc0c4c459c6ccbd00)
	{
		x17b196bc6252cd1a.x3a70a872b0ded8b0("\\*", null, xc0c4c459c6ccbd00);
	}

	public IEnumerator GetEnumerator()
	{
		return new x85484311e7900b5f(x17b196bc6252cd1a.x7261c103565fa212.GetEnumerator());
	}

	private static bool xbfd984f469f0f82c(xcfa6f73a76d96956 x5f9c2fff5fcaeab9)
	{
		if (x0d299f323d241756.x90637a473b1ceaaa(x5f9c2fff5fcaeab9.x759aa16c2016a289, "\\*"))
		{
			return x5f9c2fff5fcaeab9.x47e3e032f7bd5d28;
		}
		return false;
	}

	internal string xd113acd60d1dd3f6()
	{
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				string text = (string)enumerator.Current;
				switch (text.ToLower())
				{
				case "arabic":
				case "roman":
				case "alphabetic":
				case "cardtext":
				case "dollartext":
				case "ordinal":
				case "ordtext":
				case "hex":
					return text;
				}
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
		return null;
	}

	internal string xe4f99d01c82052fc()
	{
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				string text = (string)enumerator.Current;
				switch (text.ToLower())
				{
				case "charformat":
				case "mergeformat":
					return text;
				}
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
		return null;
	}
}
