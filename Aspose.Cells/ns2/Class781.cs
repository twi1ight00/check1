using System.Collections;
using System.ComponentModel;
using Aspose.Cells;

namespace ns2;

internal class Class781 : ICellsDataTable
{
	internal string[] string_0;

	internal ICollection icollection_0;

	private Hashtable hashtable_0;

	private IEnumerator ienumerator_0;

	private PropertyDescriptorCollection propertyDescriptorCollection_0;

	public object this[int columnIndex] => propertyDescriptorCollection_0[columnIndex].GetValue(ienumerator_0.Current);

	public object this[string columnName] => ((PropertyDescriptor)hashtable_0[columnName]).GetValue(ienumerator_0.Current);

	public string[] Columns => string_0;

	public int Count => icollection_0.Count;

	internal Class781(ICollection icollection_1, PropertyDescriptorCollection propertyDescriptorCollection_1)
	{
		icollection_0 = icollection_1;
		propertyDescriptorCollection_0 = propertyDescriptorCollection_1;
		string_0 = new string[propertyDescriptorCollection_0.Count];
		hashtable_0 = new Hashtable(propertyDescriptorCollection_0.Count);
		for (int i = 0; i < propertyDescriptorCollection_1.Count; i++)
		{
			string_0[i] = propertyDescriptorCollection_1[i].Name.ToUpper();
			hashtable_0.Add(propertyDescriptorCollection_1[i].Name, propertyDescriptorCollection_1[i]);
		}
		ienumerator_0 = icollection_0.GetEnumerator();
	}

	public void BeforeFirst()
	{
		ienumerator_0 = icollection_0.GetEnumerator();
	}

	public bool Next()
	{
		if (ienumerator_0 == null)
		{
			return false;
		}
		return ienumerator_0.MoveNext();
	}
}
