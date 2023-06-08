using System;
using System.Collections;
using x13f1efc79617a47b;
using x6c95d9cf46ff5f25;
using xeb665d1aeef09d64;

namespace x66dd9eaee57cfba4;

internal class xd369be2fe9fecb8f
{
	private readonly Hashtable x911e3317ce57abd8 = new Hashtable();

	private readonly Hashtable xe08ac69cd88db829 = new Hashtable();

	private readonly Hashtable x6760d98dadf87765 = new Hashtable();

	private readonly Hashtable xc247aa16b4f97438 = new Hashtable();

	internal void xd6b6ed77479ef68c(x075846a119f47dd1 x4fb5718687161b71, int x7b0d599fbcbd0087, string xc15bd84e01929885)
	{
		if (x0d299f323d241756.x5959bccb67bbf051(xc15bd84e01929885))
		{
			Hashtable hashtable = x3aac652f28fd5227(x4fb5718687161b71);
			if (hashtable != null)
			{
				hashtable[x7b0d599fbcbd0087] = xc15bd84e01929885;
			}
		}
	}

	internal string x445d52193d07ef86(x075846a119f47dd1 x4fb5718687161b71)
	{
		string text = x1dafd189c5465293(x4fb5718687161b71);
		if (text == null)
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("nfbbngibghpbhhgcegncpgedngldlfcehfjeabafoehfkaoffffgfemgoedhdekhlpaileiijepieegjidnjkdekadlkgoblhdjlicamobhmocomhnennbmnecdoomjojbbphbipjbppcmfapanaoaebopkbjaccipicoppcbahdkkndapeecplebkcfcpjfdoagnnhgfjoginfhonmhkndinnkiejbj", 200971)));
		}
		return text;
	}

	internal string x1dafd189c5465293(x075846a119f47dd1 x4fb5718687161b71)
	{
		Hashtable hashtable = x3aac652f28fd5227(x4fb5718687161b71);
		if (hashtable == null)
		{
			return null;
		}
		if (hashtable.Count <= 0)
		{
			return null;
		}
		string text = (string)hashtable[1033];
		if (text == null)
		{
			text = (string)x87015811b11a6aa1(hashtable);
		}
		return text;
	}

	internal string[] x42d74655af47d6fb(x075846a119f47dd1 x4fb5718687161b71)
	{
		Hashtable hashtable = x3aac652f28fd5227(x4fb5718687161b71);
		if (hashtable == null)
		{
			return null;
		}
		string[] array = new string[hashtable.Count];
		int num = 0;
		foreach (string value in hashtable.Values)
		{
			array[num] = value;
			num++;
		}
		return array;
	}

	internal x8989ff189b375934[] x0033df3de08eb797()
	{
		Hashtable hashtable = x3aac652f28fd5227(x075846a119f47dd1.x0a4b32fbe2e5933b);
		Hashtable hashtable2 = x3aac652f28fd5227(x075846a119f47dd1.x6054c4379c01a50d);
		if (hashtable.Count == 0 || hashtable2.Count == 0)
		{
			return null;
		}
		x8989ff189b375934[] array = new x8989ff189b375934[hashtable.Count];
		int num = 0;
		foreach (DictionaryEntry item in hashtable)
		{
			string text = (string)hashtable2[item.Key];
			if (text == null)
			{
				text = (string)hashtable2[1033];
			}
			if (text == null)
			{
				text = (string)x87015811b11a6aa1(hashtable2);
			}
			array[num++] = new x8989ff189b375934(text, (string)item.Value);
		}
		return array;
	}

	private Hashtable x3aac652f28fd5227(x075846a119f47dd1 x4fb5718687161b71)
	{
		return x4fb5718687161b71 switch
		{
			x075846a119f47dd1.x6054c4379c01a50d => x911e3317ce57abd8, 
			x075846a119f47dd1.x8eab654c3f64ae79 => xe08ac69cd88db829, 
			x075846a119f47dd1.x0a4b32fbe2e5933b => x6760d98dadf87765, 
			x075846a119f47dd1.xf90356c32ec38694 => xc247aa16b4f97438, 
			_ => null, 
		};
	}

	private static object x87015811b11a6aa1(Hashtable x1ec770899c98a268)
	{
		IEnumerator enumerator = x1ec770899c98a268.Values.GetEnumerator();
		try
		{
			if (enumerator.MoveNext())
			{
				return enumerator.Current;
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
