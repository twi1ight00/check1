using System;
using Aspose.Words;
using Aspose.Words.Drawing;
using x55b2bd426d41d30c;
using x5f3520a4b31ea90f;
using xbe73d5820f7f4ae3;

namespace xfce5b6a304778b89;

internal class x0ab4ab4e1edb4c1e
{
	private x0ab4ab4e1edb4c1e()
	{
	}

	internal static void x06b0e25aa6ad68a9(xf871da68decec406 xe134235b3526fa75, CompositeNode x8b2c3c076d5a7daf, Shape x5770cdefd8931aa9)
	{
		xe134235b3526fa75.xe5ffcf1e3f9bd387 = null;
		x9249ee1ddf74fddd(xe134235b3526fa75, x5770cdefd8931aa9);
		x07554c988446f22e(xe134235b3526fa75, x5770cdefd8931aa9);
		x8b2c3c076d5a7daf.AppendChild(x5770cdefd8931aa9);
	}

	internal static void x9249ee1ddf74fddd(xf871da68decec406 xe134235b3526fa75, Shape x5770cdefd8931aa9)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		while (xca994afbcb9073a.x1ac1960adc8c4c39())
		{
			string xa66385d80d4d296f;
			if (xe134235b3526fa75.x81c468031b83f5fc(xca994afbcb9073a) || (xa66385d80d4d296f = xca994afbcb9073a.xa66385d80d4d296f) == null || !(xa66385d80d4d296f == "href"))
			{
				continue;
			}
			string xd2f68ee6f47e9dfb = xca994afbcb9073a.xd2f68ee6f47e9dfb;
			if (xd2f68ee6f47e9dfb.StartsWith("http:") || xd2f68ee6f47e9dfb.StartsWith("https:") || xd2f68ee6f47e9dfb.StartsWith("file:"))
			{
				x5770cdefd8931aa9.ImageData.SourceFullName = xbb857c9fc36f5054.x573fbc1b32ee4645(xd2f68ee6f47e9dfb);
				continue;
			}
			byte[] array = x59907187ecf7052c(xe134235b3526fa75);
			if (array != null)
			{
				x5770cdefd8931aa9.ImageData.x7a0cb9855dd2eab1(array);
			}
		}
	}

	internal static void x07554c988446f22e(xf871da68decec406 xe134235b3526fa75, Shape x5770cdefd8931aa9)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		while (xca994afbcb9073a.x152cbadbfa8061b1("image"))
		{
			if (!xe134235b3526fa75.xb18e918c8e329f66(x5770cdefd8931aa9.xf7125312c7ee115c))
			{
				_ = xe134235b3526fa75.xca994afbcb9073a2.xa66385d80d4d296f;
				xca994afbcb9073a.IgnoreElement();
			}
		}
	}

	internal static byte[] x59907187ecf7052c(xf871da68decec406 xe134235b3526fa75)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		string arg = xca994afbcb9073a.xd2f68ee6f47e9dfb.Replace("./", "");
		arg = $"/{arg}";
		x0ca5e8b532953a51 x0ca5e8b532953a = xe134235b3526fa75.x39c7aeeec1af9dd0.x5621ebad67e4df79(arg);
		if (x0ca5e8b532953a == null)
		{
			return null;
		}
		byte[] array = x0ca5e8b532953a.xb8a774e0111d0fbe.ToArray();
		Guid guid = x66cdafe77e7aa42b.x8341ba999ffebb91(array);
		if (!xe134235b3526fa75.x315cb47baef59522.ContainsKey(guid))
		{
			xe134235b3526fa75.x315cb47baef59522.Add(guid, array);
			return array;
		}
		return (byte[])xe134235b3526fa75.x315cb47baef59522[guid];
	}
}
