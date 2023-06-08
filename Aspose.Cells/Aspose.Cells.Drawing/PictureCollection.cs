using System.Collections;
using System.IO;

namespace Aspose.Cells.Drawing;

/// <summary>
///       Encapsulates a collection of <see cref="T:Aspose.Cells.Drawing.Picture" /> objects.
///       </summary>
public class PictureCollection : CollectionBase
{
	private ShapeCollection shapeCollection_0;

	/// <summary>
	///        Gets the <see cref="T:Aspose.Cells.Drawing.Picture" /> element at the specified index.
	///        </summary>
	/// <param name="index">The zero based index of the element.</param>
	/// <returns>The element at the specified index.</returns>
	public Picture this[int index] => (Picture)base.InnerList[index];

	internal PictureCollection(ShapeCollection shapeCollection_1)
	{
		shapeCollection_0 = shapeCollection_1;
	}

	/// <summary>
	///       Adds a picture to the collection.
	///       </summary>
	/// <param name="upperLeftRow">Upper left row index.</param>
	/// <param name="upperLeftColumn">Upper left column index.</param>
	/// <param name="lowerRightRow">Lower right row index</param>
	/// <param name="lowerRightColumn">Lower right column index</param>
	/// <param name="stream">Stream object which contains the image data.</param>
	/// <returns>
	///   <see cref="T:Aspose.Cells.Drawing.Picture" /> object index.</returns>
	public int Add(int upperLeftRow, int upperLeftColumn, int lowerRightRow, int lowerRightColumn, Stream stream)
	{
		shapeCollection_0.AddPicture(upperLeftRow, upperLeftColumn, lowerRightRow, lowerRightColumn, stream);
		return base.Count - 1;
	}

	/// <summary>
	///       Adds a picture to the collection.
	///       </summary>
	/// <param name="upperLeftRow">Upper left row index.</param>
	/// <param name="upperLeftColumn">Upper left column index.</param>
	/// <param name="lowerRightRow">Lower right row index</param>
	/// <param name="lowerRightColumn">Lower right column index</param>
	/// <param name="fileName">Image filename.</param>
	/// <returns>
	///   <see cref="T:Aspose.Cells.Drawing.Picture" /> object index.</returns>
	public int Add(int upperLeftRow, int upperLeftColumn, int lowerRightRow, int lowerRightColumn, string fileName)
	{
		if (!File.Exists(fileName))
		{
			throw new CellsException(ExceptionType.InvalidData, "File does not exist.");
		}
		FileStream fileStream = File.OpenRead(fileName);
		Add(upperLeftRow, upperLeftColumn, lowerRightRow, lowerRightColumn, fileStream);
		fileStream.Close();
		return base.Count - 1;
	}

	/// <summary>
	///       Adds a picture to the collection.
	///       </summary>
	/// <param name="upperLeftRow">Upper left row index.</param>
	/// <param name="upperLeftColumn">Upper left column index.</param>
	/// <param name="stream">Stream object which contains the image data.</param>
	/// <returns>
	///   <see cref="T:Aspose.Cells.Drawing.Picture" /> object index.</returns>
	public int Add(int upperLeftRow, int upperLeftColumn, Stream stream)
	{
		return Add(upperLeftRow, upperLeftColumn, stream, 100, 100);
	}

	/// <summary>
	///       Adds a picture to the collection.
	///       </summary>
	/// <param name="upperLeftRow">Upper left row index.</param>
	/// <param name="upperLeftColumn">Upper left column index.</param>
	/// <param name="fileName">Image filename.</param>
	/// <returns>
	///   <see cref="T:Aspose.Cells.Drawing.Picture" /> object index.</returns>
	public int Add(int upperLeftRow, int upperLeftColumn, string fileName)
	{
		if (!File.Exists(fileName))
		{
			throw new CellsException(ExceptionType.InvalidData, "File does not exist.");
		}
		FileStream fileStream = File.OpenRead(fileName);
		Add(upperLeftRow, upperLeftColumn, fileStream);
		fileStream.Close();
		return base.Count - 1;
	}

	/// <summary>
	///       Adds a picture to the collection.
	///       </summary>
	/// <param name="upperLeftRow">Upper left row index.</param>
	/// <param name="upperLeftColumn">Upper left column index.</param>
	/// <param name="stream">Stream object which contains the image data.</param>
	/// <param name="widthScale">Scale of image width, a percentage.</param>
	/// <param name="heightScale">Scale of image height, a percentage.</param>
	/// <returns>
	///   <see cref="T:Aspose.Cells.Drawing.Picture" /> object index.</returns>
	public int Add(int upperLeftRow, int upperLeftColumn, Stream stream, int widthScale, int heightScale)
	{
		shapeCollection_0.AddPicture(upperLeftRow, upperLeftColumn, stream, widthScale, heightScale);
		return base.Count - 1;
	}

	/// <summary>
	///       Adds a picture to the collection.
	///       </summary>
	/// <param name="upperLeftRow">Upper left row index.</param>
	/// <param name="upperLeftColumn">Upper left column index.</param>
	/// <param name="fileName">Image filename.</param>
	/// <param name="widthScale">Scale of image width, a percentage.</param>
	/// <param name="heightScale">Scale of image height, a percentage.</param>
	/// <returns>
	///   <see cref="T:Aspose.Cells.Drawing.Picture" /> object index.</returns>
	public int Add(int upperLeftRow, int upperLeftColumn, string fileName, int widthScale, int heightScale)
	{
		if (!File.Exists(fileName))
		{
			throw new CellsException(ExceptionType.InvalidData, "File does not exist.");
		}
		FileStream fileStream = File.OpenRead(fileName);
		Add(upperLeftRow, upperLeftColumn, fileStream, widthScale, heightScale);
		fileStream.Close();
		return base.Count - 1;
	}

	/// <summary>
	///       Clear all pictures.
	///       </summary>
	public new void Clear()
	{
		for (int i = 0; i < base.InnerList.Count; i++)
		{
			Picture shape_ = (Picture)base.InnerList[i--];
			shapeCollection_0.method_26(shape_);
		}
	}

	/// <summary>
	///       Remove shapes at the specific index
	///       </summary>
	public new void RemoveAt(int index)
	{
		Picture shape_ = (Picture)base.InnerList[index];
		shapeCollection_0.method_26(shape_);
	}

	internal int Add(Picture picture_0)
	{
		base.InnerList.Add(picture_0);
		return base.Count - 1;
	}

	internal void Remove(Picture picture_0)
	{
		base.InnerList.Remove(picture_0);
	}
}
