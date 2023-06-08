using System;
using System.Collections;

namespace Aspose.Words.Markup;

public class SdtListItemCollection : IEnumerable
{
	private int xcad48a5720820b88 = -1;

	private ArrayList xddc60c8d74d0f01b = new ArrayList();

	public SdtListItem SelectedValue
	{
		get
		{
			if (xcad48a5720820b88 != -1)
			{
				return this[xcad48a5720820b88];
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				xcad48a5720820b88 = -1;
				return;
			}
			if (xddc60c8d74d0f01b.Contains(value))
			{
				xcad48a5720820b88 = xddc60c8d74d0f01b.IndexOf(value);
				return;
			}
			throw new ArgumentException("Can not find such LastValue in this collection.");
		}
	}

	public SdtListItem this[int index] => (SdtListItem)xddc60c8d74d0f01b[index];

	public int Count => xddc60c8d74d0f01b.Count;

	internal SdtListItemCollection()
	{
	}

	public IEnumerator GetEnumerator()
	{
		return xddc60c8d74d0f01b.GetEnumerator();
	}

	public void Add(SdtListItem item)
	{
		xddc60c8d74d0f01b.Add(item);
	}

	public void RemoveAt(int index)
	{
		xddc60c8d74d0f01b.RemoveAt(index);
	}

	public void Clear()
	{
		xddc60c8d74d0f01b.Clear();
	}

	internal SdtListItemCollection x8b61531c8ea35b85()
	{
		SdtListItemCollection sdtListItemCollection = (SdtListItemCollection)MemberwiseClone();
		sdtListItemCollection.xddc60c8d74d0f01b = new ArrayList(xddc60c8d74d0f01b.Count);
		for (int i = 0; i < xddc60c8d74d0f01b.Count; i++)
		{
			sdtListItemCollection.Add(this[i].x8b61531c8ea35b85());
		}
		return sdtListItemCollection;
	}
}
