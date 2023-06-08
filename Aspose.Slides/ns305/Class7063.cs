using System;
using System.Collections;
using System.Collections.Generic;

namespace ns305;

internal class Class7063 : Class7062, IEnumerable, IEnumerable<Class7045>
{
	private class Class7064 : IDisposable, IEnumerator, IEnumerator<Class7045>
	{
		private IEnumerator<Class6976> ienumerator_0;

		public Class7045 Current => ienumerator_0.Current as Class7045;

		object IEnumerator.Current => Current;

		public Class7064(IEnumerable<Class6976> nodes)
		{
			ienumerator_0 = nodes.GetEnumerator();
		}

		public void Dispose()
		{
			ienumerator_0.Dispose();
		}

		public bool MoveNext()
		{
			return ienumerator_0.MoveNext();
		}

		public void Reset()
		{
			ienumerator_0.Reset();
		}
	}

	public Class7045 this[int index] => method_7(index) as Class7045;

	internal Class7063(Class6981 parent)
		: base(parent)
	{
	}

	public bool Contains(string name)
	{
		return method_4(name) != null;
	}

	public Class7045 method_11(string name)
	{
		return method_4(name) as Class7045;
	}

	public Class7045 method_12(Class7045 arg)
	{
		method_18(arg);
		return method_5(arg) as Class7045;
	}

	public Class7045 method_13(string name)
	{
		return method_6(name) as Class7045;
	}

	public Class7045 method_14(Class7045 attr)
	{
		int num = 0;
		while (true)
		{
			if (num < base.Length)
			{
				if (base.Nodes[num] == attr)
				{
					break;
				}
				num++;
				continue;
			}
			return null;
		}
		method_2(num);
		return attr;
	}

	public Class7045 method_15(string namespaceURI, string localName)
	{
		return method_8(namespaceURI, localName) as Class7045;
	}

	public Class7045 method_16(Class7045 arg)
	{
		method_18(arg);
		return method_9(arg) as Class7045;
	}

	public Class7045 method_17(string namespaceURI, string localName)
	{
		return method_10(namespaceURI, localName) as Class7045;
	}

	public IEnumerator<Class7045> GetEnumerator()
	{
		return new Class7064(base.Nodes);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	private void method_18(Class7045 attr)
	{
		if (attr.Prefix.Equals("xmlns"))
		{
			attr.OwnerDocument.NamespaceManager.AddNamespace(attr.LocalName, attr.Value);
		}
	}
}
