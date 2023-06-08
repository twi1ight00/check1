using System.Drawing;
using System.IO;
using Aspose.Words.Fields;

namespace Aspose.Words.Reporting;

public class ImageFieldMergingArgs : FieldMergingArgsBase
{
	private string x7c0b2c3ae14d9668;

	private Stream x7492bd16e718c2a0;

	private Image x262034d5fec7782b;

	private MergeFieldImageDimension x42e5c99daad7b47e;

	private MergeFieldImageDimension xc870c20d40920a8c;

	public string ImageFileName
	{
		get
		{
			return x7c0b2c3ae14d9668;
		}
		set
		{
			x7c0b2c3ae14d9668 = value;
		}
	}

	public Stream ImageStream
	{
		get
		{
			return x7492bd16e718c2a0;
		}
		set
		{
			x7492bd16e718c2a0 = value;
		}
	}

	public Image Image
	{
		get
		{
			return x262034d5fec7782b;
		}
		set
		{
			x262034d5fec7782b = value;
		}
	}

	public MergeFieldImageDimension ImageWidth
	{
		get
		{
			return x42e5c99daad7b47e;
		}
		set
		{
			x42e5c99daad7b47e = value;
		}
	}

	public MergeFieldImageDimension ImageHeight
	{
		get
		{
			return xc870c20d40920a8c;
		}
		set
		{
			xc870c20d40920a8c = value;
		}
	}

	internal ImageFieldMergingArgs(Document document, string tableName, int recordIndex, Field field, string fieldName, string documentFieldName, object fieldValue, MergeFieldImageDimension imageWidth, MergeFieldImageDimension imageHeight)
		: base(document, tableName, recordIndex, field, fieldName, documentFieldName, fieldValue)
	{
		x42e5c99daad7b47e = imageWidth;
		xc870c20d40920a8c = imageHeight;
	}
}
