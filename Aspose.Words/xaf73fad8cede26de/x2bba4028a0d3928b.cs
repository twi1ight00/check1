using System;
using System.IO;
using x66dd9eaee57cfba4;
using x6c95d9cf46ff5f25;
using xfc5388ad7dff404f;

namespace xaf73fad8cede26de;

internal class x2bba4028a0d3928b
{
	public static xa2f1c3dcbd86f20a x8572e146dc2654a2(xcd986872cf3bcf68 xdf4e8adcb2e5e03b, string x82a6dc2f9d1d6f6b)
	{
		byte[] x250450c8714b357d;
		using (MemoryStream memoryStream = new MemoryStream())
		{
			xdf4e8adcb2e5e03b.WriteToStream(memoryStream);
			x250450c8714b357d = x0d299f323d241756.xa0aed4cd3b3d5d92(memoryStream);
		}
		return x8572e146dc2654a2(x250450c8714b357d, x82a6dc2f9d1d6f6b);
	}

	private static xa2f1c3dcbd86f20a x8572e146dc2654a2(byte[] x250450c8714b357d, string x82a6dc2f9d1d6f6b)
	{
		byte[] array = xe7a1784db8e68ebc(x250450c8714b357d, x82a6dc2f9d1d6f6b);
		xa2f1c3dcbd86f20a xa2f1c3dcbd86f20a = new xa2f1c3dcbd86f20a(x82a6dc2f9d1d6f6b, "application/vnd.ms-package.obfuscated-opentype");
		xa2f1c3dcbd86f20a.xb8a774e0111d0fbe.Write(array, 0, array.Length);
		return xa2f1c3dcbd86f20a;
	}

	private static byte[] xe7a1784db8e68ebc(byte[] x250450c8714b357d, string xc0f970673ec61199)
	{
		byte[] array = xef435572d9e78c85(xc0f970673ec61199);
		for (int i = 0; i < 32; i++)
		{
			int num = array.Length - i % array.Length - 1;
			x250450c8714b357d[i] ^= array[num];
		}
		return x250450c8714b357d;
	}

	private static byte[] xef435572d9e78c85(string x9e9070c6c983bbc0)
	{
		string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(x9e9070c6c983bbc0);
		return x0d299f323d241756.x90000f01e9f4b628(new Guid(fileNameWithoutExtension));
	}
}
