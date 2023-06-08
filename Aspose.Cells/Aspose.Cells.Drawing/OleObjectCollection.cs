using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace Aspose.Cells.Drawing;

/// <summary>
///       Represents embedded OLE objects.
///       </summary>
public class OleObjectCollection : CollectionBase
{
	private ShapeCollection shapeCollection_0;

	/// <summary>
	///        Gets the <see cref="T:Aspose.Cells.Drawing.OleObject" /> element at the specified index.
	///        </summary>
	/// <param name="index">The zero based index of the element.</param>
	/// <returns>The element at the specified index.</returns>
	public OleObject this[int index] => (OleObject)base.InnerList[index];

	internal OleObjectCollection(ShapeCollection shapeCollection_1)
	{
		shapeCollection_0 = shapeCollection_1;
	}

	[SpecialName]
	internal bool method_0()
	{
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				OleObject oleObject = (OleObject)enumerator.Current;
				if (!oleObject.method_69())
				{
					return false;
				}
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		return true;
	}

	/// <summary>
	///       Adds an OleObject to the collection.
	///       </summary>
	/// <param name="upperLeftRow">Upper left row index.</param>
	/// <param name="upperLeftColumn">Upper left column index.</param>
	/// <param name="height">Height of oleObject, in unit of pixel.</param>
	/// <param name="width">Width of oleObject, in unit of pixel.</param>
	/// <param name="imageData"> Image of ole object as byte array.</param>
	/// <returns>
	///   <see cref="T:Aspose.Cells.Drawing.OleObject" /> object index.</returns>
	public int Add(int upperLeftRow, int upperLeftColumn, int height, int width, byte[] imageData)
	{
		shapeCollection_0.AddOleObject(upperLeftRow, 0, upperLeftColumn, 0, height, width, imageData);
		return base.Count - 1;
	}

	internal void Add(OleObject oleObject_0)
	{
		base.InnerList.Add(oleObject_0);
	}

	internal void Remove(OleObject oleObject_0)
	{
		base.InnerList.Remove(oleObject_0);
	}
}
