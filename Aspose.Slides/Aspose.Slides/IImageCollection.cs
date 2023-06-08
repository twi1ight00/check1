using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("d0e444a6-8d77-46e5-be19-104d1fc2c968")]
public interface IImageCollection : ICollection, IEnumerable, IEnumerable<IPPImage>
{
	IPPImage this[int index] { get; }

	ICollection AsICollection { get; }

	IEnumerable AsIEnumerable { get; }

	IPPImage AddImage(Image image);

	IPPImage AddImage(MemoryStream stream);

	IPPImage AddImage(Stream stream);

	IPPImage AddImage(byte[] buffer);

	IPPImage AddImage(IPPImage imageSource);
}
