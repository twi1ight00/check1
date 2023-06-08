using System;
using System.Collections;
using x13f1efc79617a47b;
using xd2754ae26d400653;

namespace Aspose.Words.Lists;

[JavaGenericArguments("Iterable<ListLevel>")]
public class ListLevelCollection : IEnumerable
{
	private ArrayList x82b70567a5f68f41;

	public ListLevel this[int index]
	{
		get
		{
			return (ListLevel)x82b70567a5f68f41[index];
		}
		set
		{
			x82b70567a5f68f41[index] = value;
		}
	}

	public int Count => x82b70567a5f68f41.Count;

	internal ListLevelCollection()
	{
		x82b70567a5f68f41 = new ArrayList();
	}

	internal ListLevelCollection(DocumentBase document, x902c8ac86fbaf048 listType)
	{
		int num = xd9d7b9e76301a44a(listType);
		x82b70567a5f68f41 = new ArrayList(num);
		for (int i = 0; i < num; i++)
		{
			x82b70567a5f68f41.Add(new ListLevel(document, i));
		}
	}

	internal void xd6b6ed77479ef68c(ListLevel xdcfcc0186c9811f1)
	{
		x82b70567a5f68f41.Add(xdcfcc0186c9811f1);
	}

	internal void xa3ba3a1106a23933(x902c8ac86fbaf048 xd275fdd8cec9b85e, DocumentBase x6beba47238e0ade6)
	{
		int num = xd9d7b9e76301a44a(xd275fdd8cec9b85e);
		while (x82b70567a5f68f41.Count > num)
		{
			x82b70567a5f68f41.RemoveAt(x82b70567a5f68f41.Count - 1);
		}
		while (x82b70567a5f68f41.Count < num)
		{
			xd6b6ed77479ef68c(new ListLevel(x6beba47238e0ade6, x82b70567a5f68f41.Count));
		}
	}

	private static int xd9d7b9e76301a44a(x902c8ac86fbaf048 xd275fdd8cec9b85e)
	{
		switch (xd275fdd8cec9b85e)
		{
		case x902c8ac86fbaf048.xabed123f43874357:
			return 1;
		case x902c8ac86fbaf048.x7e86ac926e2dc940:
		case x902c8ac86fbaf048.x598f41525926b38a:
			return 9;
		default:
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("eolpkpcaepjaepabcphbhpoblofckjmcdoddnnkdeobecoielipemngfonnfcnegemlgkich", 1650457487)));
		}
	}

	public IEnumerator GetEnumerator()
	{
		return x82b70567a5f68f41.GetEnumerator();
	}

	internal ListLevel x90a164d2f15bfc09(int x66bbd7ed8c65740d)
	{
		return this[x278f2422762a97e9(x66bbd7ed8c65740d)];
	}

	internal int x278f2422762a97e9(int x66bbd7ed8c65740d)
	{
		return System.Math.Min(x66bbd7ed8c65740d, Count - 1);
	}

	internal ListLevelCollection x8b61531c8ea35b85(DocumentBase x1f83c4681a4a3676)
	{
		ListLevelCollection listLevelCollection = (ListLevelCollection)MemberwiseClone();
		listLevelCollection.x82b70567a5f68f41 = new ArrayList(x82b70567a5f68f41.Count);
		foreach (ListLevel item in x82b70567a5f68f41)
		{
			listLevelCollection.x82b70567a5f68f41.Add(item.x8b61531c8ea35b85(x1f83c4681a4a3676));
		}
		return listLevelCollection;
	}
}
