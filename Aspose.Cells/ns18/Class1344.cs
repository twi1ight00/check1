using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ns18;

internal class Class1344
{
	internal static void smethod_0(Bitmap bitmap, out byte[] bitmapData, out int stride)
	{
		MemoryStream memoryStream = new MemoryStream();
		bitmap.Save(memoryStream, ImageFormat.Bmp);
		memoryStream.Position = 0L;
		BinaryReader binaryReader = new BinaryReader(memoryStream);
		binaryReader.ReadBytes(2);
		int num = binaryReader.ReadInt32();
		binaryReader.ReadBytes(4);
		int num2 = binaryReader.ReadInt32();
		binaryReader.ReadInt32();
		binaryReader.ReadInt32();
		binaryReader.ReadInt32();
		binaryReader.ReadInt16();
		binaryReader.ReadInt16();
		binaryReader.ReadInt32();
		binaryReader.ReadInt32();
		binaryReader.ReadInt32();
		binaryReader.ReadInt32();
		binaryReader.ReadInt32();
		binaryReader.ReadInt32();
		memoryStream.Position = num2;
		bitmapData = new byte[num - num2];
		stride = bitmapData.Length / bitmap.Height;
		for (int num3 = bitmap.Height - 1; num3 >= 0; num3--)
		{
			memoryStream.Read(bitmapData, num3 * stride, stride);
		}
		memoryStream.Close();
		memoryStream = null;
	}
}
