using System.Drawing;
using System.IO;
using Aspose.Words;
using Aspose.Words.Saving;
using x077e797660ceec8d;
using x1c8faa688b1f0b0c;
using x6c95d9cf46ff5f25;

namespace xe9fa6af9e1184312;

internal class x4bb20e393c4d7846
{
	private readonly SizeF x3b77a41bd57164d6;

	private readonly x4fdf549af9de6b97 x87f8561aebf828bc;

	internal SizeF x437e3b626c0fdd43 => x3b77a41bd57164d6;

	internal x4fdf549af9de6b97 xefb7a8f84373ac04 => x87f8561aebf828bc;

	internal x4bb20e393c4d7846(x4fdf549af9de6b97 apsContainer, SizeF size)
	{
		x87f8561aebf828bc = apsContainer;
		x3b77a41bd57164d6 = size;
	}

	internal void x0acd3c2012ea2ee8(Stream xcf18e5243f8d5fd3, xfe2ff3c162b47c70 x0182a6dae298f8a4)
	{
		ImageSaveOptions xc27f01f21f67608c = new ImageSaveOptions(FileFormatUtil.x9ac6b4aed1d86203(x0182a6dae298f8a4));
		x0a376fc3a80043f7.x53c5cdce403a6243(x87f8561aebf828bc, x3b77a41bd57164d6, xcf18e5243f8d5fd3, xc27f01f21f67608c);
	}
}
