using System.Collections;
using x8b1f7613579e78d0;
using xa769c310fbec8a5a;

namespace xc76255e87e5986c6;

internal class x2053f56a9aea777a
{
	private ArrayList x22cddd2927401df4 = new ArrayList();

	private ArrayList xe278449b50d07bc1 = new ArrayList();

	private ArrayList xe819690179e23b0e = new ArrayList();

	private string xc61ff88f1f98652d;

	public string x759aa16c2016a289
	{
		get
		{
			return xc61ff88f1f98652d;
		}
		set
		{
			xc61ff88f1f98652d = value;
		}
	}

	public x48d7478d49393961 xc9e90b46232365f3(int xc0c4c459c6ccbd00)
	{
		if (x22cddd2927401df4.Count == 0)
		{
			return new xcffce73ccb792506();
		}
		if (xc0c4c459c6ccbd00 >= x22cddd2927401df4.Count)
		{
			xc0c4c459c6ccbd00 = x22cddd2927401df4.Count - 1;
		}
		return (x48d7478d49393961)x22cddd2927401df4[xc0c4c459c6ccbd00];
	}

	public int x2c141991a183f50a(x48d7478d49393961 xf6bbbbc72b0e608e)
	{
		x22cddd2927401df4.Add(xf6bbbbc72b0e608e);
		return x22cddd2927401df4.Count - 1;
	}

	public x48d7478d49393961 x0cf64e0fb1cb423b(int xc0c4c459c6ccbd00)
	{
		if (xe278449b50d07bc1.Count == 0)
		{
			return new xcffce73ccb792506();
		}
		if (xc0c4c459c6ccbd00 >= xe278449b50d07bc1.Count)
		{
			xc0c4c459c6ccbd00 = xe278449b50d07bc1.Count - 1;
		}
		return (x48d7478d49393961)xe278449b50d07bc1[xc0c4c459c6ccbd00];
	}

	public int x98901042681367ec(x48d7478d49393961 xf6bbbbc72b0e608e)
	{
		xe278449b50d07bc1.Add(xf6bbbbc72b0e608e);
		return xe278449b50d07bc1.Count - 1;
	}

	public x064e11d707aed84f xb29c732ce60a626d(int xc0c4c459c6ccbd00)
	{
		if (xe819690179e23b0e.Count == 0)
		{
			return new x064e11d707aed84f();
		}
		if (xc0c4c459c6ccbd00 >= xe819690179e23b0e.Count)
		{
			xc0c4c459c6ccbd00 = xe819690179e23b0e.Count - 1;
		}
		return (x064e11d707aed84f)xe819690179e23b0e[xc0c4c459c6ccbd00];
	}

	public int x15311d0220014649(x064e11d707aed84f x26516bbd7ae94699)
	{
		xe819690179e23b0e.Add(x26516bbd7ae94699);
		return xe819690179e23b0e.Count - 1;
	}
}
