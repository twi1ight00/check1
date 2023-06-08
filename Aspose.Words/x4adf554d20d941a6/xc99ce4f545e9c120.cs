using System.Collections;

namespace x4adf554d20d941a6;

internal class xc99ce4f545e9c120
{
	internal static void xc1d98b06788daae1(xac6c82c74ce247fb x337e217cb3ba0627, xac6c82c74ce247fb x7d95d971d8923f4c)
	{
		Hashtable hashtable = new Hashtable();
		ArrayList arrayList = new ArrayList();
		xf3f447691ab38eee xf3f447691ab38eee2 = x337e217cb3ba0627.xb3a79d506b0e2f7f.x8b61531c8ea35b85();
		xf3f447691ab38eee2.x74f5a1ef3906e23c();
		while (xf3f447691ab38eee2.x47f176deff0d42e2())
		{
			x56410a8dd70087c5 x56410a8dd70087c6 = (x56410a8dd70087c5)xf3f447691ab38eee2.x35cfcea4890f4e7d;
			x56410a8dd70087c5 value = x56410a8dd70087c6.xa9d7e8f6fbdcbcfc(null);
			arrayList.Add(value);
			hashtable.Add(x56410a8dd70087c6, value);
		}
		x3c81b884cf5d3405 x3c81b884cf5d3406 = new x3c81b884cf5d3405(x7d95d971d8923f4c);
		x56410a8dd70087c5 xd9ff4dee1dba180e = null;
		int num = 0;
		xf3f447691ab38eee2.x74f5a1ef3906e23c();
		while (xf3f447691ab38eee2.x47f176deff0d42e2())
		{
			x56410a8dd70087c5 x337e217cb3ba628 = (x56410a8dd70087c5)xf3f447691ab38eee2.x35cfcea4890f4e7d;
			x56410a8dd70087c5 x56410a8dd70087c7 = (x56410a8dd70087c5)arrayList[num++];
			x3c81b884cf5d3406.xef23aa45e7612fdd(xd9ff4dee1dba180e, x56410a8dd70087c7);
			x56410a8dd70087c7.xb19ff4e6c96375bd(hashtable, x337e217cb3ba628);
			x19f654f517d2c323(x337e217cb3ba628, x56410a8dd70087c7);
			xd9ff4dee1dba180e = x56410a8dd70087c7;
		}
		x3c81b884cf5d3406.x408f4b7efc86fd49();
	}

	private static void x19f654f517d2c323(x56410a8dd70087c5 x337e217cb3ba0627, x56410a8dd70087c5 x3b2496727a21f4a2)
	{
		if (x337e217cb3ba0627 is x91e144d65ff41819)
		{
			string x759aa16c2016a = ((x91e144d65ff41819)x337e217cb3ba0627).x759aa16c2016a289;
			x56410a8dd70087c5 x56410a8dd70087c6 = (x56410a8dd70087c5)x337e217cb3ba0627.x2c8c6741422a1298.xeafe18c850ae3127[x759aa16c2016a];
			if (x56410a8dd70087c6 == null || x56410a8dd70087c6 == x337e217cb3ba0627 || !x56410a8dd70087c6.x00fa20d37841acd0)
			{
				x337e217cb3ba0627.x2c8c6741422a1298.xeafe18c850ae3127[x759aa16c2016a] = x3b2496727a21f4a2;
			}
		}
	}
}
