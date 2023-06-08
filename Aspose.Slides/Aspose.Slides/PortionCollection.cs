using System.Collections;
using System.Collections.Generic;

namespace Aspose.Slides;

public sealed class PortionCollection : IEnumerable, IEnumerable<IPortion>, IPortionCollection
{
	internal List<IPortion> list_0;

	internal Paragraph paragraph_0;

	public int Count => list_0.Count;

	public bool IsReadOnly => ((ICollection<IPortion>)list_0).IsReadOnly;

	public IPortion this[int index]
	{
		get
		{
			return list_0[index];
		}
		set
		{
			Portion portion = (Portion)this[index];
			portion.paragraph_0 = null;
			if (((Portion)value).paragraph_0 != null)
			{
				throw new PptxEditException("Can't insert already used portion");
			}
			((Portion)value).paragraph_0 = paragraph_0;
			list_0[index] = value;
			method_1(value);
		}
	}

	IEnumerable IPortionCollection.AsIEnumerable => this;

	internal PortionCollection(Paragraph parent)
	{
		paragraph_0 = parent;
		list_0 = new List<IPortion>();
	}

	internal IPortion Add()
	{
		Portion portion = new Portion("");
		Add(portion);
		return portion;
	}

	public void Add(IPortion value)
	{
		if (((Portion)value).paragraph_0 != null)
		{
			throw new PptxEditException("Can't add already used portion");
		}
		((Portion)value).paragraph_0 = paragraph_0;
		list_0.Add(value);
		method_1(value);
	}

	public int IndexOf(IPortion item)
	{
		return list_0.IndexOf(item);
	}

	public void Insert(int index, IPortion value)
	{
		if (((Portion)value).paragraph_0 != null)
		{
			throw new PptxEditException("Can't insert already used portion");
		}
		((Portion)value).paragraph_0 = paragraph_0;
		list_0.Insert(index, value);
		method_1(value);
	}

	public void Clear()
	{
		foreach (Portion item in list_0)
		{
			item.paragraph_0 = null;
		}
		list_0.Clear();
		method_1(null);
	}

	public bool Contains(IPortion item)
	{
		return list_0.Contains(item);
	}

	public void CopyTo(IPortion[] array, int arrayIndex)
	{
		list_0.CopyTo(array, arrayIndex);
	}

	public bool Remove(IPortion item)
	{
		Portion portion = (Portion)item;
		portion.paragraph_0 = null;
		bool result;
		if (result = list_0.Remove(item))
		{
			method_1(null);
		}
		return result;
	}

	public void RemoveAt(int index)
	{
		Portion portion = (Portion)this[index];
		portion.paragraph_0 = null;
		list_0.RemoveAt(index);
		method_1(null);
	}

	internal void method_0()
	{
		if (Count != 0)
		{
			RemoveAt(Count - 1);
		}
	}

	IEnumerator<IPortion> IEnumerable<IPortion>.GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	public IEnumerator GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	private void method_1(IPortion port)
	{
		if (paragraph_0 != null)
		{
			if (port != null)
			{
				paragraph_0.method_4(port.PortionFormat);
			}
			else
			{
				paragraph_0.method_4(null);
			}
		}
	}
}
