using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("1469C473-95A4-48E4-A158-D3BD8BF9DFA4")]
public interface IImageWrapper : IDisposable
{
	Image Image { get; }

	Size Size { get; }

	IDisposable AsIDisposable { get; }

	void Save(string fileName);

	void Save(Stream stream, PPImageFormat imageFormat);

	void Save(string fileName, PPImageFormat imageFormat);
}
