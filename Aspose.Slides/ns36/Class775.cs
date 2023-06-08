using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using ns221;
using ns33;

namespace ns36;

internal class Class775
{
	private int int_0;

	public Class775(int colorDiffTolerance)
	{
		int_0 = colorDiffTolerance;
	}

	public Class775()
	{
	}

	public bool method_0(string fileName1, string fileName2)
	{
		Stream stream = File.OpenRead(fileName1);
		Stream stream2 = File.OpenRead(fileName2);
		bool result = method_1(stream, stream2);
		stream?.Close();
		stream2?.Close();
		return result;
	}

	public bool method_1(Stream fileStream1, Stream fileStream2)
	{
		if (method_2(fileStream1, fileStream2))
		{
			return true;
		}
		if (method_4(fileStream1, fileStream2))
		{
			return true;
		}
		return false;
	}

	private bool method_2(Stream fileStream1, Stream fileStream2)
	{
		if (fileStream1.Length != fileStream2.Length)
		{
			return false;
		}
		byte[] array = method_3(fileStream1);
		byte[] array2 = method_3(fileStream2);
		return method_10(array, array2);
	}

	private byte[] method_3(Stream strm)
	{
		byte[] array = new byte[strm.Length];
		strm.Read(array, 0, (int)strm.Length);
		return array;
	}

	[Attribute7(true)]
	private bool method_4(Stream fileStream1, Stream fileStream2)
	{
		Bitmap bmp = (Bitmap)Image.FromStream(fileStream1);
		Bitmap bmp2 = (Bitmap)Image.FromStream(fileStream2);
		return method_5(bmp, bmp2);
	}

	public bool method_5(Bitmap bmp1, Bitmap bmp2)
	{
		bool flag = true;
		if (bmp1.Size != bmp2.Size)
		{
			flag = false;
		}
		else
		{
			for (int i = 0; i < bmp1.Width; i++)
			{
				for (int j = 0; j < bmp1.Height; j++)
				{
					Color pixel = bmp1.GetPixel(i, j);
					Color pixel2 = bmp2.GetPixel(i, j);
					if (!method_8(pixel, pixel2, int_0))
					{
						flag = false;
						break;
					}
				}
				if (!flag)
				{
					break;
				}
			}
		}
		bmp1?.Dispose();
		bmp2?.Dispose();
		return flag;
	}

	internal Bitmap method_6(Bitmap newBmp, Bitmap goldBmp)
	{
		if (newBmp.Size != goldBmp.Size)
		{
			return null;
		}
		Bitmap bitmap = new Bitmap(goldBmp.Width, goldBmp.Height);
		bitmap.SetResolution(goldBmp.HorizontalResolution, goldBmp.VerticalResolution);
		Graphics graphics = Graphics.FromImage(bitmap);
		graphics.DrawImage(goldBmp, 0, 0);
		graphics.CompositingMode = CompositingMode.SourceOver;
		ImageAttributes imageAttributes = new ImageAttributes();
		float[][] newColorMatrix = new float[5][]
		{
			new float[5] { 1f, 0f, 0f, 0f, 0f },
			new float[5] { 0f, 1f, 0f, 0f, 0f },
			new float[5] { 0f, 0f, 1f, 0f, 0f },
			new float[5] { 0f, 0f, 0f, 0.5f, 0f },
			new float[5] { 0.2f, 0.2f, 0.2f, 0f, 1f }
		};
		ColorMatrix newColorMatrix2 = new ColorMatrix(newColorMatrix);
		imageAttributes.SetColorMatrix(newColorMatrix2, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
		graphics.DrawImage(newBmp, new Rectangle(0, 0, newBmp.Width, newBmp.Height), 0, 0, newBmp.Width, newBmp.Height, GraphicsUnit.Pixel, imageAttributes);
		graphics?.Dispose();
		return bitmap;
	}

	internal Bitmap method_7(Bitmap newBmp, Bitmap goldBmp)
	{
		if (newBmp.Size != goldBmp.Size)
		{
			Bitmap bitmap = new Bitmap(480, 288);
			using Graphics graphics = Graphics.FromImage(bitmap);
			string text = "The Size of 2 charts are different. The new is " + newBmp.Size.ToString() + ". The gold is " + goldBmp.Size.ToString();
			Rectangle rectangle = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
			string familyName = "Microsoft Sans Serif";
			Font font = new Font(familyName, 15f);
			SolidBrush brush = new SolidBrush(Color.Red);
			SizeF sizeF;
			lock (Class1164.Lock)
			{
				sizeF = graphics.MeasureString(text, font, (int)((double)rectangle.Width * 0.8));
			}
			float x = (float)rectangle.Left + ((float)rectangle.Width - sizeF.Width) / 2f;
			float y = (float)rectangle.Top + ((float)rectangle.Height - sizeF.Height) / 2f;
			RectangleF layoutRectangle = new RectangleF(x, y, sizeF.Width, sizeF.Height);
			graphics.DrawString(text, font, brush, layoutRectangle);
			return bitmap;
		}
		Bitmap bitmap2 = new Bitmap(goldBmp.Width, goldBmp.Height);
		bitmap2.SetResolution(goldBmp.HorizontalResolution, goldBmp.VerticalResolution);
		for (int i = 0; i < newBmp.Width; i++)
		{
			for (int j = 0; j < newBmp.Height; j++)
			{
				Color pixel = newBmp.GetPixel(i, j);
				Color pixel2 = goldBmp.GetPixel(i, j);
				if (!method_8(pixel, pixel2, int_0))
				{
					bitmap2.SetPixel(i, j, Color.Red);
				}
			}
		}
		return bitmap2;
	}

	private bool method_8(Color color1, Color color2, int tolerance)
	{
		if (!method_9(color1.A, color2.A, tolerance))
		{
			return false;
		}
		if (!method_9(color1.R, color2.R, tolerance))
		{
			return false;
		}
		if (!method_9(color1.G, color2.G, tolerance))
		{
			return false;
		}
		if (!method_9(color1.B, color2.B, tolerance))
		{
			return false;
		}
		return true;
	}

	private bool method_9(int a, int b, int tolerance)
	{
		return Math.Abs(a - b) <= tolerance;
	}

	private bool method_10(byte[] array1, byte[] array2)
	{
		if (array1.Length != array2.Length)
		{
			return false;
		}
		int num = 0;
		while (true)
		{
			if (num < array1.Length)
			{
				if (array1[num] != array2[num])
				{
					break;
				}
				num++;
				continue;
			}
			return true;
		}
		return false;
	}
}
