using System;
using System.Collections;
using System.Collections.Generic;
using ns307;

namespace ns305;

internal class Class7074 : IDisposable, IEnumerator, IEnumerator<Class6976>
{
	private Interface372 interface372_0;

	private Class6976 class6976_0;

	public Class6976 Current => interface372_0.CurrentNode;

	object IEnumerator.Current => Current;

	public Class7074(Interface372 treeWalker)
	{
		if (treeWalker == null)
		{
			throw new ArgumentNullException("treeWalker");
		}
		interface372_0 = treeWalker;
	}

	public void Dispose()
	{
		interface372_0.Dispose();
		interface372_0 = null;
	}

	public bool MoveNext()
	{
		class6976_0 = interface372_0.imethod_6();
		return class6976_0 != null;
	}

	public void Reset()
	{
		interface372_0.CurrentNode = interface372_0.Root;
	}
}
