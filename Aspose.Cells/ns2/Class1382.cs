using System.Collections;
using Aspose.Cells;

namespace ns2;

internal class Class1382
{
	private Hashtable hashtable_0 = new Hashtable(16);

	public void method_0()
	{
		hashtable_0.Clear();
	}

	public void RemoveRange(Cell cell_0)
	{
		hashtable_0.Remove(cell_0);
	}

	public int AddRange(Cell cell_0, Worksheet worksheet_0, int int_0, int int_1, int int_2, int int_3)
	{
		if (cell_0 == null)
		{
			return 0;
		}
		ArrayList arrayList;
		if (hashtable_0.Contains(cell_0))
		{
			arrayList = (ArrayList)hashtable_0[cell_0];
		}
		else
		{
			arrayList = new ArrayList();
			hashtable_0[cell_0] = arrayList;
		}
		foreach (Class1381 item in arrayList)
		{
			if (item.worksheet_0 == worksheet_0 && item.int_0[0] == int_0 && item.int_0[1] == int_1 && item.int_0[2] == int_2 && item.int_0[3] == int_3)
			{
				return 1;
			}
		}
		Class1381 value = new Class1381(worksheet_0, int_0, int_1, int_2, int_3);
		arrayList.Add(value);
		return 0;
	}

	public ArrayList method_1(Worksheet worksheet_0, int int_0, int int_1)
	{
		ArrayList arrayList = new ArrayList();
		IDictionaryEnumerator enumerator = hashtable_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			foreach (Class1381 item in (ArrayList)enumerator.Value)
			{
				if (item.method_0(worksheet_0, int_0, int_1))
				{
					arrayList.Add(enumerator.Key);
				}
			}
		}
		return arrayList;
	}
}
