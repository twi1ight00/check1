using System.Collections;
using x59d6a4fc5007b7a4;

namespace xf989f31a236ff98c;

internal class xe8abfa8506874b16
{
	private enum xddfe41bc4cab0a03
	{
		x89fbe586cf2759a7,
		xe1c2256213a6fa81
	}

	private static readonly Hashtable xfdec10cbd837872a;

	private static readonly Hashtable x7a86d9baa4c38f4b;

	internal static bool xe5e9215c47c64515(char x3c4da2980d043c95, int x312b9ebd5ce96b7b)
	{
		return x7c8dc72414793292(x3c4da2980d043c95, x312b9ebd5ce96b7b) == xddfe41bc4cab0a03.x89fbe586cf2759a7;
	}

	private static xddfe41bc4cab0a03 x7c8dc72414793292(char x3c4da2980d043c95, int x312b9ebd5ce96b7b)
	{
		xddfe41bc4cab0a03 result = xddfe41bc4cab0a03.x89fbe586cf2759a7;
		if (x3c4da2980d043c95 >= '\u00a0' && x3c4da2980d043c95 <= 'ÿ')
		{
			result = xddfe41bc4cab0a03.xe1c2256213a6fa81;
			if (xfdec10cbd837872a.ContainsKey(x3c4da2980d043c95))
			{
				result = (xddfe41bc4cab0a03)xfdec10cbd837872a[x3c4da2980d043c95];
			}
			if (!x769ea5e930af2cbc.x679ecae06db987e4(x312b9ebd5ce96b7b) && x312b9ebd5ce96b7b != 1024 && x7a86d9baa4c38f4b.ContainsKey(x3c4da2980d043c95))
			{
				result = (xddfe41bc4cab0a03)x7a86d9baa4c38f4b[x3c4da2980d043c95];
			}
		}
		return result;
	}

	static xe8abfa8506874b16()
	{
		xfdec10cbd837872a = new Hashtable();
		x7a86d9baa4c38f4b = new Hashtable();
		xfdec10cbd837872a['¡'] = xddfe41bc4cab0a03.x89fbe586cf2759a7;
		xfdec10cbd837872a['¤'] = xddfe41bc4cab0a03.x89fbe586cf2759a7;
		xfdec10cbd837872a['§'] = xddfe41bc4cab0a03.x89fbe586cf2759a7;
		xfdec10cbd837872a['\u00a8'] = xddfe41bc4cab0a03.x89fbe586cf2759a7;
		xfdec10cbd837872a['ª'] = xddfe41bc4cab0a03.x89fbe586cf2759a7;
		xfdec10cbd837872a['\u00ad'] = xddfe41bc4cab0a03.x89fbe586cf2759a7;
		xfdec10cbd837872a['\u00af'] = xddfe41bc4cab0a03.x89fbe586cf2759a7;
		xfdec10cbd837872a['°'] = xddfe41bc4cab0a03.x89fbe586cf2759a7;
		xfdec10cbd837872a['±'] = xddfe41bc4cab0a03.x89fbe586cf2759a7;
		xfdec10cbd837872a['²'] = xddfe41bc4cab0a03.x89fbe586cf2759a7;
		xfdec10cbd837872a['³'] = xddfe41bc4cab0a03.x89fbe586cf2759a7;
		xfdec10cbd837872a['\u00b4'] = xddfe41bc4cab0a03.x89fbe586cf2759a7;
		xfdec10cbd837872a['¶'] = xddfe41bc4cab0a03.x89fbe586cf2759a7;
		xfdec10cbd837872a['·'] = xddfe41bc4cab0a03.x89fbe586cf2759a7;
		xfdec10cbd837872a['\u00b8'] = xddfe41bc4cab0a03.x89fbe586cf2759a7;
		xfdec10cbd837872a['¹'] = xddfe41bc4cab0a03.x89fbe586cf2759a7;
		xfdec10cbd837872a['º'] = xddfe41bc4cab0a03.x89fbe586cf2759a7;
		xfdec10cbd837872a['¼'] = xddfe41bc4cab0a03.x89fbe586cf2759a7;
		xfdec10cbd837872a['½'] = xddfe41bc4cab0a03.x89fbe586cf2759a7;
		xfdec10cbd837872a['¾'] = xddfe41bc4cab0a03.x89fbe586cf2759a7;
		xfdec10cbd837872a['¿'] = xddfe41bc4cab0a03.x89fbe586cf2759a7;
		xfdec10cbd837872a['×'] = xddfe41bc4cab0a03.x89fbe586cf2759a7;
		xfdec10cbd837872a['à'] = xddfe41bc4cab0a03.x89fbe586cf2759a7;
		xfdec10cbd837872a['á'] = xddfe41bc4cab0a03.x89fbe586cf2759a7;
		xfdec10cbd837872a['è'] = xddfe41bc4cab0a03.x89fbe586cf2759a7;
		xfdec10cbd837872a['é'] = xddfe41bc4cab0a03.x89fbe586cf2759a7;
		xfdec10cbd837872a['ê'] = xddfe41bc4cab0a03.x89fbe586cf2759a7;
		xfdec10cbd837872a['ì'] = xddfe41bc4cab0a03.x89fbe586cf2759a7;
		xfdec10cbd837872a['í'] = xddfe41bc4cab0a03.x89fbe586cf2759a7;
		xfdec10cbd837872a['ò'] = xddfe41bc4cab0a03.x89fbe586cf2759a7;
		xfdec10cbd837872a['ó'] = xddfe41bc4cab0a03.x89fbe586cf2759a7;
		xfdec10cbd837872a['÷'] = xddfe41bc4cab0a03.x89fbe586cf2759a7;
		xfdec10cbd837872a['ù'] = xddfe41bc4cab0a03.x89fbe586cf2759a7;
		xfdec10cbd837872a['ú'] = xddfe41bc4cab0a03.x89fbe586cf2759a7;
		xfdec10cbd837872a['ü'] = xddfe41bc4cab0a03.x89fbe586cf2759a7;
		x7a86d9baa4c38f4b['à'] = xddfe41bc4cab0a03.xe1c2256213a6fa81;
		x7a86d9baa4c38f4b['á'] = xddfe41bc4cab0a03.xe1c2256213a6fa81;
		x7a86d9baa4c38f4b['è'] = xddfe41bc4cab0a03.xe1c2256213a6fa81;
		x7a86d9baa4c38f4b['é'] = xddfe41bc4cab0a03.xe1c2256213a6fa81;
		x7a86d9baa4c38f4b['ê'] = xddfe41bc4cab0a03.xe1c2256213a6fa81;
		x7a86d9baa4c38f4b['ì'] = xddfe41bc4cab0a03.xe1c2256213a6fa81;
		x7a86d9baa4c38f4b['í'] = xddfe41bc4cab0a03.xe1c2256213a6fa81;
		x7a86d9baa4c38f4b['ò'] = xddfe41bc4cab0a03.xe1c2256213a6fa81;
		x7a86d9baa4c38f4b['ó'] = xddfe41bc4cab0a03.xe1c2256213a6fa81;
		x7a86d9baa4c38f4b['ù'] = xddfe41bc4cab0a03.xe1c2256213a6fa81;
		x7a86d9baa4c38f4b['ú'] = xddfe41bc4cab0a03.xe1c2256213a6fa81;
		x7a86d9baa4c38f4b['ü'] = xddfe41bc4cab0a03.xe1c2256213a6fa81;
	}
}
