using System.Collections;
using ns30;
using ns57;

namespace Aspose.Cells.Properties;

/// <summary>
///       Base class for <see cref="T:Aspose.Cells.Properties.BuiltInDocumentPropertyCollection" /> and <see cref="T:Aspose.Cells.Properties.CustomDocumentPropertyCollection" /> collections.
///       </summary>
/// <example>
///   <code>
///
///       [C#]
///
///       //Instantiate a Workbook object by calling its empty constructor
///       Workbook workbook = new Workbook("C:\\book1.xls");
///
///       //Retrieve a list of all custom document properties of the Excel file
///       DocumentPropertyCollection customProperties = workbook.Worksheets.CustomDocumentProperties;
///
///       //Accessng a custom document property by using the property index
///       DocumentProperty customProperty1 = customProperties[3];
///
///       //Accessng a custom document property by using the property name
///       DocumentProperty customProperty2 = customProperties["Owner"];
///
///       [VB.NET]
///
///       'Instantiate a Workbook object by calling its empty constructor
///       Dim workbook As Workbook = New Workbook("C:\\book1.xls")
///
///       'Retrieve a list of all custom document properties of the Excel file
///       Dim customProperties As DocumentPropertyCollection = workbook.Worksheets.CustomDocumentProperties
///
///       'Accessng a custom document property by using the property index
///       Dim customProperty1 As DocumentProperty = customProperties(3)
///
///       'Accessng a custom document property by using the property name
///       Dim customProperty2 As DocumentProperty = customProperties("Owner")
///
///       </code>
/// </example>
public abstract class DocumentPropertyCollection : IEnumerable
{
	private ArrayList arrayList_0 = new ArrayList();

	/// <summary>
	///       Gets number of items in the collection.
	///       </summary>
	public int Count => arrayList_0.Count;

	/// <overloads>Returns a <see cref="T:Aspose.Cells.Properties.DocumentProperty" /> object.</overloads>
	/// <summary>
	///       Returns a <see cref="T:Aspose.Cells.Properties.DocumentProperty" /> object by the name of the property.
	///       </summary>
	/// <remarks>
	///   <p>Returns null if a property with the specified name is not found.</p>
	/// </remarks>
	/// <param name="name">The case-insensitive name of the property to retrieve.</param>
	public virtual DocumentProperty this[string name]
	{
		get
		{
			if (!Class1321.smethod_6(name))
			{
				throw new CellsException(ExceptionType.InvalidOperator, "The argument cannot be null or empty string.");
			}
			Class1321.smethod_7(name, "name");
			int num = 0;
			DocumentProperty documentProperty;
			while (true)
			{
				if (num < arrayList_0.Count)
				{
					documentProperty = (DocumentProperty)arrayList_0[num];
					if (documentProperty.Name.ToLower() == name.ToLower())
					{
						break;
					}
					num++;
					continue;
				}
				return null;
			}
			return documentProperty;
		}
	}

	/// <summary>
	///       Returns a <see cref="T:Aspose.Cells.Properties.DocumentProperty" /> object by index.
	///       </summary>
	/// <param name="index">Zero-based index of the <see cref="T:Aspose.Cells.Properties.DocumentProperty" /> to retrieve.</param>
	public DocumentProperty this[int index] => (DocumentProperty)arrayList_0[index];

	/// <summary>
	/// </summary>
	/// <returns>
	/// </returns>
	public IEnumerator GetEnumerator()
	{
		return arrayList_0.GetEnumerator();
	}

	internal DocumentProperty Add(Enum218 enum218_0, int int_0, string string_0, object object_0, bool bool_0)
	{
		DocumentProperty documentProperty = new DocumentProperty(this, enum218_0, int_0, string_0, object_0, bool_0);
		arrayList_0.Add(documentProperty);
		return documentProperty;
	}

	/// <summary>
	///       Returns true if a property with the specified name exists in the collection.
	///       </summary>
	/// <param name="name">The case-insensitive name of the property.</param>
	/// <returns>True if the property exists in the collection; false otherwise.</returns>
	public bool Contains(string name)
	{
		int num = IndexOf(name);
		return num != -1;
	}

	/// <summary>
	///       Gets the index of a property by name.
	///       </summary>
	/// <param name="name">The case-insensitive name of the property.</param>
	/// <returns>The zero based index. Negative value if not found.</returns>
	public int IndexOf(string name)
	{
		int num = 0;
		while (true)
		{
			if (num < arrayList_0.Count)
			{
				DocumentProperty documentProperty = (DocumentProperty)arrayList_0[num];
				if (documentProperty.Name.ToLower() == name.ToLower())
				{
					break;
				}
				num++;
				continue;
			}
			return -1;
		}
		return num;
	}

	/// <summary>
	///       Removes a property with the specified name from the collection.
	///       </summary>
	/// <param name="name">The case-insensitive name of the property.</param>
	public void Remove(string name)
	{
		Class1321.smethod_7(name, "name");
		int num = IndexOf(name);
		if (num != -1)
		{
			RemoveAt(num);
		}
	}

	/// <summary>
	///       Removes a property at the specified index.
	///       </summary>
	/// <param name="index">The zero based index.</param>
	public void RemoveAt(int index)
	{
		DocumentProperty documentProperty = this[index];
		arrayList_0.RemoveAt(index);
		int num = 0;
		while (true)
		{
			if (num < Count)
			{
				DocumentProperty documentProperty2 = this[num];
				if (documentProperty2.IsLink && documentProperty2.method_1() == documentProperty.method_0())
				{
					break;
				}
				num++;
				continue;
			}
			return;
		}
		arrayList_0.RemoveAt(num);
	}

	/// <summary>
	///       Removes all properties from the collection.
	///       </summary>
	public void Clear()
	{
		arrayList_0.Clear();
	}
}
