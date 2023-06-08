using System;
using System.Collections;
using System.Collections.Generic;

namespace ns305;

internal sealed class Class7100 : IDisposable, IEnumerator, IEnumerator<Class6976>
{
	internal Class6976 class6976_0;

	internal Class6976 class6976_1;

	internal bool bool_0;

	public Class6976 Current
	{
		get
		{
			if (bool_0 || class6976_0 == null)
			{
				throw new InvalidOperationException();
			}
			return class6976_0;
		}
	}

	object IEnumerator.Current => Current;

	internal Class7100(Class6976 owner)
	{
		class6976_1 = owner;
		class6976_0 = owner.FirstChild;
		bool_0 = true;
	}

	internal bool MoveNext()
	{
		if (bool_0)
		{
			class6976_0 = class6976_1.FirstChild;
			bool_0 = false;
		}
		else if (class6976_0 != null)
		{
			class6976_0 = class6976_0.NextSibling;
		}
		return class6976_0 != null;
	}

	bool IEnumerator.MoveNext()
	{
		return MoveNext();
	}

	void IEnumerator.Reset()
	{
		bool_0 = true;
		class6976_0 = class6976_1.FirstChild;
	}

	public void Dispose()
	{
		class6976_1 = null;
		class6976_0 = null;
	}
}
