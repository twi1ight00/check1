namespace x583d72a986201ed7;

internal class xfa0fcb008e364b10
{
	private const int x7a9d1db7bd215bcc = 8;

	private static readonly x829e0857a06af038[] xe2397eca3f4f13bd;

	internal x02344c8663635c5d xdef7f68a22ec051d(string xb41faee6912a2313)
	{
		x829e0857a06af038[] array = xe2397eca3f4f13bd;
		foreach (x829e0857a06af038 x829e0857a06af39 in array)
		{
			xd0213f18a88e2027 xd0213f18a88e2028 = x829e0857a06af39.x22bdad7984a6b53a(xb41faee6912a2313);
			if (xd0213f18a88e2028 != null && xd0213f18a88e2028.x3c24f47680ce5966.Length <= 8)
			{
				return new x02344c8663635c5d(x829e0857a06af39, xd0213f18a88e2028.x3c24f47680ce5966, xd0213f18a88e2028.xf9ad6fb78355fe13);
			}
		}
		return null;
	}

	static xfa0fcb008e364b10()
	{
		xe2397eca3f4f13bd = new x829e0857a06af038[10]
		{
			new x6ae49747a15f10a4(),
			new xfcd94753d9b2d2ef(),
			new x3fb4bc2992c5ddb1(),
			new x871294bca16bf5c2(),
			new xec614f8803a150ee(),
			new xe3f501f9f1d37192(),
			new x168475514483ad94(),
			new x27a6ace5e49fbfa0(),
			new xf68cce5bf3450c0a(),
			new xb0795713b04ed741()
		};
	}
}
