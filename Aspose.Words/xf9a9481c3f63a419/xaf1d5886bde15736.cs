using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using Aspose;
using x38a89dee67fc7a16;
using x6c95d9cf46ff5f25;

namespace xf9a9481c3f63a419;

[JavaManual("Manual porting by design.")]
internal class xaf1d5886bde15736
{
	private xaf1d5886bde15736()
	{
	}

	public static byte[] x9ae3c76542ff5bd7(byte[] x43e181e083db6cdf, SizeF x1de68a531466236f)
	{
		using MemoryStream xc8f3f690897a858e = new MemoryStream(x43e181e083db6cdf);
		return x9ae3c76542ff5bd7(xc8f3f690897a858e, x1de68a531466236f);
	}

	public static byte[] x9ae3c76542ff5bd7(Stream xc8f3f690897a858e, SizeF x1de68a531466236f)
	{
		using Image image = Image.FromStream(xc8f3f690897a858e);
		int num = 300;
		int num4;
		int num5;
		while (true)
		{
			float num2 = (float)num / x1de68a531466236f.Height;
			float num3 = (float)num / x1de68a531466236f.Width;
			num4 = (int)((float)image.Size.Width * num3);
			num5 = (int)((float)image.Size.Height * num2);
			if (!xdd1b8f14cc8ba86d.x92d069eca6ec3dfb(num4, num5))
			{
				break;
			}
			num /= 2;
		}
		using Bitmap bitmap = new Bitmap(num4, num5);
		bitmap.SetResolution(num, num);
		using (Graphics graphics = x2c0e2b36cc23e6ca(bitmap))
		{
			graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			graphics.DrawImage(image, 0, 0);
		}
		using MemoryStream memoryStream = new MemoryStream();
		bitmap.Save(memoryStream, ImageFormat.Png);
		return x0d299f323d241756.xa0aed4cd3b3d5d92(memoryStream);
	}

	public static Graphics x2c0e2b36cc23e6ca(Image xe058541ca798c059)
	{
		return Graphics.FromImage(xe058541ca798c059);
	}
}
