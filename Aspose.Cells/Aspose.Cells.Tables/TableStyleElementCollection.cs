using System.Collections;
using System.Runtime.CompilerServices;

namespace Aspose.Cells.Tables;

/// <summary>
///       Represents all elements of the table style.
///       </summary>
public class TableStyleElementCollection : CollectionBase
{
	private TableStyle tableStyle_0;

	/// <summary>
	///       Gets an element of the table style by the index.
	///       </summary>
	/// <param name="index">The index.</param>
	/// <returns>Returns <see cref="T:Aspose.Cells.Tables.TableStyleElement" /> object</returns>
	public TableStyleElement this[int index] => (TableStyleElement)base.InnerList[index];

	/// <summary>
	///       Gets the element of the table style by the <see cref="T:Aspose.Cells.Tables.TableStyleElementType" /></summary>
	/// <param name="type">The element type.</param>
	/// <returns>Returns <see cref="T:Aspose.Cells.Tables.TableStyleElement" /> object</returns>
	public TableStyleElement this[TableStyleElementType type]
	{
		get
		{
			int num = 0;
			while (true)
			{
				if (num < base.Count)
				{
					if (this[num].Type == type)
					{
						break;
					}
					num++;
					continue;
				}
				return null;
			}
			return this[num];
		}
	}

	[SpecialName]
	internal TableStyle method_0()
	{
		return tableStyle_0;
	}

	internal TableStyleElementCollection(TableStyle tableStyle_1)
	{
		tableStyle_0 = tableStyle_1;
	}

	/// <summary>
	///       Adds an element.
	///       </summary>
	/// <param name="type">The type of the element</param>
	/// <returns>Returns the index of the element in the list.</returns>
	public int Add(TableStyleElementType type)
	{
		int num = 0;
		while (true)
		{
			if (num < base.Count)
			{
				if (this[num].Type == type)
				{
					break;
				}
				num++;
				continue;
			}
			TableStyleElement tableStyleElement_ = new TableStyleElement(this, type);
			return Add(tableStyleElement_);
		}
		return num;
	}

	internal int Add(TableStyleElement tableStyleElement_0)
	{
		base.InnerList.Add(tableStyleElement_0);
		return base.Count - 1;
	}

	internal void Copy(TableStyleElementCollection tableStyleElementCollection_0)
	{
		for (int i = 0; i < tableStyleElementCollection_0.Count; i++)
		{
			TableStyleElement tableStyleElement = tableStyleElementCollection_0[i];
			TableStyleElement tableStyleElement2 = new TableStyleElement(this, tableStyleElement.Type);
			tableStyleElement2.Copy(tableStyleElement);
			base.InnerList.Add(tableStyleElement2);
		}
	}
}
