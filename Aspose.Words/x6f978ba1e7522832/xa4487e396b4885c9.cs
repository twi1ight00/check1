using System.Collections;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using x9db5f2e5af3d596e;
using xa604c4d210ae0581;

namespace x6f978ba1e7522832;

internal class xa4487e396b4885c9
{
	private static readonly IComparer x2ee4a2fc4c1e4e24 = new x68213df305cc23fe();

	private xa4487e396b4885c9()
	{
	}

	internal static void xd25ac1f77750d4b5(xdb4d596cc6b8659f x62947fad1bd23bff, int xba08ce632055a1d9, x875aca5784596b73 x28180b3c3774af93, xf77fd3dab66c510a xc30cd6401e231d63)
	{
		x5fe8658e514d4a1c(xd93381e499c2d21b(x62947fad1bd23bff, xba08ce632055a1d9), x28180b3c3774af93, xc30cd6401e231d63, null);
	}

	internal static void xca30019ffb591c2f(x7f77ea92be0d9042 xe9707cb1ec88db49, x875aca5784596b73 x28180b3c3774af93, xf77fd3dab66c510a xc30cd6401e231d63)
	{
		xca30019ffb591c2f(xe9707cb1ec88db49, x28180b3c3774af93, xc30cd6401e231d63, x2ee4a2fc4c1e4e24);
	}

	internal static void xca30019ffb591c2f(x7f77ea92be0d9042 xe9707cb1ec88db49, x875aca5784596b73 x28180b3c3774af93, xf77fd3dab66c510a xc30cd6401e231d63, IComparer xccf897dbab20ed8c)
	{
		Hashtable hashtable = x66c1f60c7c0ebcb5(xe9707cb1ec88db49, x28180b3c3774af93, xc30cd6401e231d63);
		ArrayList arrayList = new ArrayList();
		foreach (object key in hashtable.Keys)
		{
			x8f1cf61f24a43e61 sides = (x8f1cf61f24a43e61)hashtable[key];
			arrayList.Add(new xc86c21c356e363c0(0, 0, sides, key));
		}
		x5fe8658e514d4a1c(arrayList, x28180b3c3774af93, xc30cd6401e231d63, xccf897dbab20ed8c);
	}

	internal static void xc18fefd1c2317979(xdb4d596cc6b8659f x62947fad1bd23bff, x875aca5784596b73 x28180b3c3774af93, xf77fd3dab66c510a xc30cd6401e231d63)
	{
		xc18fefd1c2317979(x62947fad1bd23bff, x28180b3c3774af93, xc30cd6401e231d63, x2ee4a2fc4c1e4e24);
	}

	internal static void xc18fefd1c2317979(xdb4d596cc6b8659f x62947fad1bd23bff, x875aca5784596b73 x28180b3c3774af93, xf77fd3dab66c510a xc30cd6401e231d63, IComparer xccf897dbab20ed8c)
	{
		ArrayList arrayList = new ArrayList();
		x8f1cf61f24a43e61 x8f1cf61f24a43e62 = x8f1cf61f24a43e61.x4d0b9d4447ba7566;
		for (int i = 0; i < x62947fad1bd23bff.Count; i++)
		{
			Hashtable hashtable = x66c1f60c7c0ebcb5(x62947fad1bd23bff.get_xe6d4b1b411ed94b5(i), x28180b3c3774af93, xc30cd6401e231d63);
			x09ce2c02826e31a6 x09ce2c02826e31a = new x09ce2c02826e31a6();
			foreach (object key in hashtable.Keys)
			{
				x8f1cf61f24a43e61 x8f1cf61f24a43e63 = (x8f1cf61f24a43e61)hashtable[key];
				x09ce2c02826e31a.xd6b6ed77479ef68c((int)x8f1cf61f24a43e63, key);
				x8f1cf61f24a43e62 |= x8f1cf61f24a43e63;
			}
			arrayList.Add(x09ce2c02826e31a);
		}
		ArrayList arrayList2 = new ArrayList();
		for (x8f1cf61f24a43e61 x8f1cf61f24a43e64 = x8f1cf61f24a43e61.x4d0b9d4447ba7566; x8f1cf61f24a43e64 <= x8f1cf61f24a43e62; x8f1cf61f24a43e64++)
		{
			arrayList2.AddRange(xd93381e499c2d21b(arrayList, (int)x8f1cf61f24a43e64));
		}
		x5fe8658e514d4a1c(arrayList2, x28180b3c3774af93, xc30cd6401e231d63, xccf897dbab20ed8c);
	}

	private static void x5fe8658e514d4a1c(ArrayList xf8b54ce7724a27f2, x875aca5784596b73 x28180b3c3774af93, xf77fd3dab66c510a xc30cd6401e231d63, IComparer xccf897dbab20ed8c)
	{
		if (xccf897dbab20ed8c != null)
		{
			xf8b54ce7724a27f2.Sort(xccf897dbab20ed8c);
		}
		foreach (xc86c21c356e363c0 item in xf8b54ce7724a27f2)
		{
			xc30cd6401e231d63.xe9decf879352095e(x28180b3c3774af93, item.x38ced5a01a389303, item.x2569902fd5a858dc, item.x0f99c8963adcf9a2, item.xd2f68ee6f47e9dfb);
		}
	}

	private static ArrayList xd93381e499c2d21b(ArrayList x9eaa0d859448e75c, int xba08ce632055a1d9)
	{
		ArrayList arrayList = new ArrayList();
		object obj = ((x09ce2c02826e31a6)x9eaa0d859448e75c[0]).get_xe6d4b1b411ed94b5(xba08ce632055a1d9);
		int first = 0;
		for (int i = 1; i < x9eaa0d859448e75c.Count; i++)
		{
			object obj2 = ((x09ce2c02826e31a6)x9eaa0d859448e75c[i]).get_xe6d4b1b411ed94b5(xba08ce632055a1d9);
			if (!object.Equals(obj, obj2))
			{
				if (obj != null)
				{
					arrayList.Add(new xc86c21c356e363c0(first, i, (x8f1cf61f24a43e61)xba08ce632055a1d9, obj));
				}
				obj = obj2;
				first = i;
			}
		}
		if (obj != null)
		{
			arrayList.Add(new xc86c21c356e363c0(first, x9eaa0d859448e75c.Count, (x8f1cf61f24a43e61)xba08ce632055a1d9, obj));
		}
		return arrayList;
	}

	private static Hashtable x66c1f60c7c0ebcb5(x7f77ea92be0d9042 xe9707cb1ec88db49, x875aca5784596b73 x28180b3c3774af93, xf77fd3dab66c510a xc30cd6401e231d63)
	{
		Hashtable hashtable = new Hashtable();
		x56d049d647b4aa42(hashtable, xe9707cb1ec88db49, x28180b3c3774af93, x8f1cf61f24a43e61.x72d92bd1aff02e37, xc30cd6401e231d63);
		x56d049d647b4aa42(hashtable, xe9707cb1ec88db49, x28180b3c3774af93, x8f1cf61f24a43e61.x419ba17a5322627b, xc30cd6401e231d63);
		x56d049d647b4aa42(hashtable, xe9707cb1ec88db49, x28180b3c3774af93, x8f1cf61f24a43e61.xe360b1885d8d4a41, xc30cd6401e231d63);
		x56d049d647b4aa42(hashtable, xe9707cb1ec88db49, x28180b3c3774af93, x8f1cf61f24a43e61.x9bcb07e204e30218, xc30cd6401e231d63);
		x56d049d647b4aa42(hashtable, xe9707cb1ec88db49, x28180b3c3774af93, x8f1cf61f24a43e61.xc22f71a5b8ad0027, xc30cd6401e231d63);
		x56d049d647b4aa42(hashtable, xe9707cb1ec88db49, x28180b3c3774af93, x8f1cf61f24a43e61.x694a7e0cabea79b6, xc30cd6401e231d63);
		return hashtable;
	}

	private static void x56d049d647b4aa42(Hashtable x1991a49fd85e55aa, x7f77ea92be0d9042 xe9707cb1ec88db49, x875aca5784596b73 x28180b3c3774af93, x8f1cf61f24a43e61 x2356aaca890347a5, xf77fd3dab66c510a xc30cd6401e231d63)
	{
		int xba08ce632055a1d = xc30cd6401e231d63.x607ca7b6672ba4ae(x28180b3c3774af93, x2356aaca890347a5);
		object obj = xe9707cb1ec88db49.xf7866f89640a29a3(xba08ce632055a1d);
		if (obj != null)
		{
			if (x1991a49fd85e55aa[obj] != null)
			{
				x2356aaca890347a5 |= (x8f1cf61f24a43e61)x1991a49fd85e55aa[obj];
			}
			x1991a49fd85e55aa[obj] = x2356aaca890347a5;
		}
	}
}
