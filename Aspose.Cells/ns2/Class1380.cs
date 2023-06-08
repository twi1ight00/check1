using System.Collections;
using Aspose.Cells;

namespace ns2;

internal class Class1380
{
	private int int_0;

	private Hashtable hashtable_0 = new Hashtable(8);

	internal Hashtable hashtable_1 = new Hashtable(8);

	private ArrayList arrayList_0 = new ArrayList(8);

	public int Count => hashtable_0.Count - int_0;

	public void method_0()
	{
		hashtable_0.Clear();
		arrayList_0.Clear();
		int_0 = 0;
	}

	public void method_1()
	{
		if (arrayList_0.Count > 0)
		{
			foreach (Cell item in arrayList_0)
			{
				item.method_2();
			}
		}
		hashtable_0.Clear();
		arrayList_0.Clear();
		int_0 = 0;
	}

	public void method_2(Cell cell_0)
	{
		ulong num = (ulong)(((long)cell_0.method_4().method_3().Index << 34) + ((long)cell_0.Row << 14) + cell_0.Column);
		if (!hashtable_0.Contains(num))
		{
			hashtable_0[num] = 0;
			arrayList_0.Add(cell_0);
			cell_0.method_61(0);
		}
	}

	public void method_3(Cell cell_0)
	{
		hashtable_1[cell_0] = 0;
	}

	public Cell method_4()
	{
		if (hashtable_0.Count != 0 && int_0 != arrayList_0.Count)
		{
			Cell result = (Cell)arrayList_0[int_0];
			int_0++;
			return result;
		}
		return null;
	}

	public void method_5()
	{
		if (hashtable_1.Count > 0)
		{
			IEnumerator enumerator = hashtable_1.Keys.GetEnumerator();
			while (enumerator.MoveNext())
			{
				Cell cell = (Cell)enumerator.Current;
				cell.method_61(0);
				method_2(cell);
			}
		}
		for (int i = 0; i < hashtable_0.Count; i++)
		{
			Cell cell2 = (Cell)arrayList_0[i];
			IEnumerator leafs = cell2.GetLeafs();
			if (leafs != null)
			{
				while (leafs.MoveNext())
				{
					Cell cell_ = (Cell)leafs.Current;
					method_2(cell_);
				}
			}
			ArrayList arrayList = cell2.method_3();
			if (arrayList.Count <= 0)
			{
				continue;
			}
			foreach (Cell item in arrayList)
			{
				method_2(item);
			}
		}
	}
}
