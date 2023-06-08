using System.Collections;
using System.Collections.Generic;

namespace ns290;

internal class Class6852 : Class6845
{
	private readonly IList<float> ilist_1;

	private readonly IList<float> ilist_2;

	private readonly IList ilist_3;

	private IDictionary idictionary_0;

	public IList MaxColumnsWidths => (IList)ilist_1;

	public IList MinColumnsWidths => (IList)ilist_2;

	public IList ColumnsWidths => ilist_3;

	public IDictionary RowsSpaned
	{
		get
		{
			return idictionary_0;
		}
		set
		{
			idictionary_0 = value;
		}
	}

	public int ColumnsCount => MinColumnsWidths.Count;

	public Class6852(Class6844 parent)
		: base(parent)
	{
		ilist_1 = new List<float>();
		ilist_2 = new List<float>();
		ilist_3 = new ArrayList();
		idictionary_0 = new Hashtable();
	}

	public void method_0(int rowIndex, int columnIndex)
	{
		if (RowsSpaned.Contains(rowIndex))
		{
			Hashtable hashtable = (Hashtable)RowsSpaned[rowIndex];
			if (!hashtable.ContainsKey(columnIndex))
			{
				hashtable.Add(columnIndex, columnIndex);
			}
		}
		else
		{
			Hashtable hashtable2 = new Hashtable();
			RowsSpaned.Add(rowIndex, hashtable2);
			hashtable2.Add(columnIndex, columnIndex);
		}
	}
}
