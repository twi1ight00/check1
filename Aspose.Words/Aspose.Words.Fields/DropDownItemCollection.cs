using System;
using System.Collections;
using System.ComponentModel;
using x13f1efc79617a47b;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;

namespace Aspose.Words.Fields;

[JavaGenericArguments("Iterable<String>")]
public class DropDownItemCollection : x11e014059489ae95, IEnumerable
{
	internal const int xb099d192feb97b67 = 25;

	private readonly ArrayList x82b70567a5f68f41 = new ArrayList();

	public int Count => x82b70567a5f68f41.Count;

	public string this[int index]
	{
		get
		{
			return (string)x82b70567a5f68f41[index];
		}
		set
		{
			x82b70567a5f68f41[index] = value;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool xc8ea2954a6825f32 => false;

	internal DropDownItemCollection()
	{
	}

	public IEnumerator GetEnumerator()
	{
		return x82b70567a5f68f41.GetEnumerator();
	}

	public int Add(string value)
	{
		int count = Count;
		Insert(count, value);
		return count;
	}

	public bool Contains(string value)
	{
		return x82b70567a5f68f41.Contains(value);
	}

	public int IndexOf(string value)
	{
		return x82b70567a5f68f41.IndexOf(value);
	}

	public void Insert(int index, string value)
	{
		x0d299f323d241756.x0aaaea7864a53f26(value, "value");
		if (Count >= 25)
		{
			throw new InvalidOperationException(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("hjfgikmgckdhmkkhmjbiefiiejpipigjjjnjieekhilkhiclpdjlnhamjdhmdiomehfniimnghdohhkomhbpbhipbcppnggabgnaibebahlbccccmgjcmaadcfhdkfodiefenemeafdfkpjfaebgceigbpogpcghlomhmceihdlibdcjpcjjacakichkncokbcflanlldbdmjbkmjbbnbbinbmoneagoeanonpdpbalpgpbanlia", 1363371331)), 25));
		}
		x82b70567a5f68f41.Insert(index, value);
	}

	public void Remove(string name)
	{
		x82b70567a5f68f41.Remove(name);
	}

	public void RemoveAt(int index)
	{
		x82b70567a5f68f41.RemoveAt(index);
	}

	public void Clear()
	{
		x82b70567a5f68f41.Clear();
	}

	internal DropDownItemCollection x8b61531c8ea35b85()
	{
		DropDownItemCollection dropDownItemCollection = new DropDownItemCollection();
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				string value = (string)enumerator.Current;
				dropDownItemCollection.Add(value);
			}
			return dropDownItemCollection;
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

	[EditorBrowsable(EditorBrowsableState.Never)]
	private x11e014059489ae95 xa9c9dc40c97ccfd0()
	{
		return x8b61531c8ea35b85();
	}

	x11e014059489ae95 x11e014059489ae95.xcc4933610939ad04()
	{
		//ILSpy generated this explicit interface implementation from .override directive in xa9c9dc40c97ccfd0
		return this.xa9c9dc40c97ccfd0();
	}
}
