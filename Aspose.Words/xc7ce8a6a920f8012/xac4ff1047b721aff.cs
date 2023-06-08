using System.IO;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace xc7ce8a6a920f8012;

internal class xac4ff1047b721aff
{
	private static volatile byte[] x1bb6ed4c114d1ca8;

	private static object x017586199ec6edf6 = new object();

	private static volatile byte[] x9e1b0f048b0b81dc;

	private static object xf014dc51810d1e7d = new object();

	private static volatile byte[] x7a01248eac5bbec2;

	private static object xd74a24d8379dcb0a = new object();

	public static byte[] xbaeb8b895cf26378
	{
		get
		{
			if (x1bb6ed4c114d1ca8 == null)
			{
				lock (x017586199ec6edf6)
				{
					if (x1bb6ed4c114d1ca8 == null)
					{
						using Stream stream = xed747ca236d86aa0.xe1cd764b6fb0d6f6("Aspose.Resources.Viewer.swf");
						using MemoryStream memoryStream = new MemoryStream();
						using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
						byte[] buffer = new byte[8];
						stream.Read(buffer, 0, 8);
						binaryWriter.Write(buffer);
						byte[] x3b4efd51efae57c = x0d299f323d241756.x0c3d0a26320bf3c4(stream, (int)(stream.Length - 8));
						byte[] buffer2 = xf1da3993f05a75b7.x4671919d08389f8e(x3b4efd51efae57c, 0, x2e6ebe7013ab34b9.x1455a9a8b1cd9f39);
						binaryWriter.Write(buffer2);
						binaryWriter.BaseStream.Position = 38L;
						x1bb6ed4c114d1ca8 = x0d299f323d241756.x0c3d0a26320bf3c4(memoryStream, (int)(memoryStream.Length - 42));
					}
				}
			}
			return x1bb6ed4c114d1ca8;
		}
	}

	public static byte[] x25c0263bd07a71a1
	{
		get
		{
			if (x9e1b0f048b0b81dc == null)
			{
				lock (xf014dc51810d1e7d)
				{
					if (x9e1b0f048b0b81dc == null)
					{
						using Stream x23cda4cfdf81f2cf = xed747ca236d86aa0.xe1cd764b6fb0d6f6("Aspose.Resources.PageAbcData.bin");
						x9e1b0f048b0b81dc = x0d299f323d241756.xa0aed4cd3b3d5d92(x23cda4cfdf81f2cf);
					}
				}
			}
			return x9e1b0f048b0b81dc;
		}
	}

	public static byte[] xb2b05fdc63164cc3
	{
		get
		{
			if (x7a01248eac5bbec2 == null)
			{
				lock (xd74a24d8379dcb0a)
				{
					if (x7a01248eac5bbec2 == null)
					{
						using Stream x23cda4cfdf81f2cf = xed747ca236d86aa0.xe1cd764b6fb0d6f6("Aspose.Resources.DocumentDescriptorAbcData.bin");
						x7a01248eac5bbec2 = x0d299f323d241756.xa0aed4cd3b3d5d92(x23cda4cfdf81f2cf);
					}
				}
			}
			return x7a01248eac5bbec2;
		}
	}

	private xac4ff1047b721aff()
	{
	}
}
