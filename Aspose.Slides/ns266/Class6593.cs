using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using ns235;
using ns236;

namespace ns266;

internal class Class6593
{
	[Flags]
	private enum Enum880
	{
		flag_0 = 0,
		flag_1 = 1,
		flag_2 = 2,
		flag_3 = 4
	}

	private static int int_0 = 7;

	private static int int_1 = 8;

	[DllImport("gdiplus.dll")]
	private static extern uint GdipEmfToWmfBits(IntPtr hEmf, uint bufferSize, byte[] buffer, int mappingMode, Enum880 flags);

	[DllImport("gdi32.dll")]
	private static extern IntPtr SetMetaFileBitsEx(uint bufferSize, byte[] buffer);

	[DllImport("gdi32.dll")]
	private static extern IntPtr CopyMetaFile(IntPtr hWmf, string filename);

	[DllImport("gdi32.dll")]
	private static extern bool DeleteMetaFile(IntPtr hWmf);

	[DllImport("gdi32.dll")]
	private static extern bool DeleteEnhMetaFile(IntPtr hEmf);

	public void method_0(Class6216 page, string fileName, Enum879 format)
	{
		if (File.Exists(fileName))
		{
			File.Delete(fileName);
		}
		Class6190 @class = new Class6190();
		Bitmap bitmap = new Bitmap(page.WidthPixels, page.HeightPixels, PixelFormat.Format32bppArgb);
		Graphics graphics = Graphics.FromImage(bitmap);
		IntPtr hdc = graphics.GetHdc();
		using (MemoryStream memoryStream = new MemoryStream())
		{
			Metafile metafile = new Metafile(memoryStream, hdc, new Rectangle(0, 0, bitmap.Width, bitmap.Height), MetafileFrameUnit.Pixel, EmfType.EmfOnly);
			Graphics graphics2 = Graphics.FromImage(metafile);
			@class.method_0(page, graphics2);
			graphics2.Dispose();
			graphics.ReleaseHdc(hdc);
			if (format == Enum879.const_1)
			{
				IntPtr henhmetafile = metafile.GetHenhmetafile();
				int mappingMode = int_1;
				uint num = GdipEmfToWmfBits(henhmetafile, 0u, null, mappingMode, Enum880.flag_1);
				byte[] buffer = new byte[num];
				GdipEmfToWmfBits(henhmetafile, num, buffer, mappingMode, Enum880.flag_1);
				IntPtr hWmf = SetMetaFileBitsEx(num, buffer);
				IntPtr intPtr = CopyMetaFile(hWmf, fileName);
				DeleteMetaFile(hWmf);
				DeleteEnhMetaFile(henhmetafile);
				if (intPtr == IntPtr.Zero)
				{
					graphics.Dispose();
					bitmap.Dispose();
					throw new Exception60();
				}
				DeleteMetaFile(intPtr);
			}
			else
			{
				FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
				memoryStream.WriteTo(fileStream);
				fileStream.Close();
			}
		}
		graphics.Dispose();
		bitmap.Dispose();
	}
}
