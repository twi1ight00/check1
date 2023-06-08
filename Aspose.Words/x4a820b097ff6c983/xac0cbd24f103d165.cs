using System;
using System.Drawing;
using System.IO;
using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Rendering;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace x4a820b097ff6c983;

internal class xac0cbd24f103d165
{
	private xac0cbd24f103d165()
	{
	}

	internal static void xcd715bf43e919c00(Document x3664041d21d73fdc, ThumbnailGeneratingOptions xdfde339da46db651)
	{
		if (x3664041d21d73fdc == null)
		{
			throw new ArgumentNullException("document");
		}
		if (xdfde339da46db651 == null)
		{
			throw new ArgumentNullException("options");
		}
		byte[] array = xad571dcb435fc1e6(x3664041d21d73fdc, xdfde339da46db651);
		if (array != null)
		{
			x3664041d21d73fdc.BuiltInDocumentProperties.Thumbnail = array;
		}
	}

	private static byte[] xad571dcb435fc1e6(Document x3664041d21d73fdc, ThumbnailGeneratingOptions xdfde339da46db651)
	{
		using x3cd5d648729cd9b6 x3cd5d648729cd9b = x4692d6a7501e6f72(x3664041d21d73fdc, xdfde339da46db651);
		if (x3cd5d648729cd9b == null)
		{
			return null;
		}
		xfe2ff3c162b47c70 x0182a6dae298f8a = xfe2ff3c162b47c70.x6339cdb9e2b512c7;
		using MemoryStream memoryStream = new MemoryStream();
		x3cd5d648729cd9b.x0acd3c2012ea2ee8(memoryStream, x0182a6dae298f8a);
		return memoryStream.ToArray();
	}

	private static x3cd5d648729cd9b6 x4692d6a7501e6f72(Document x3664041d21d73fdc, ThumbnailGeneratingOptions xdfde339da46db651)
	{
		x3cd5d648729cd9b6 x3cd5d648729cd9b = null;
		if (!xdfde339da46db651.GenerateFromFirstPage)
		{
			x3cd5d648729cd9b = x242f0898c87ad70b(x3664041d21d73fdc, xdfde339da46db651);
		}
		if (x3cd5d648729cd9b != null)
		{
			return x3cd5d648729cd9b;
		}
		return xf35dbe2d96bf95b7(x3664041d21d73fdc, xdfde339da46db651);
	}

	private static x3cd5d648729cd9b6 x242f0898c87ad70b(Document x3664041d21d73fdc, ThumbnailGeneratingOptions xdfde339da46db651)
	{
		x8e28d0731c3bcab3 matcher = new x07232060576f6c33();
		NodeCollection nodeCollection = new NodeCollection(x3664041d21d73fdc, matcher, isDeep: true);
		if (nodeCollection.Count == 0)
		{
			return null;
		}
		byte[] x43e181e083db6cdf = null;
		switch (nodeCollection[0].NodeType)
		{
		case NodeType.DrawingML:
			x43e181e083db6cdf = ((DrawingML)nodeCollection[0]).ImageData.ToByteArray();
			break;
		case NodeType.Shape:
			x43e181e083db6cdf = ((Shape)nodeCollection[0]).ImageData.ToByteArray();
			break;
		}
		return x73ccc6ab00212968(x43e181e083db6cdf, xdfde339da46db651);
	}

	private static x3cd5d648729cd9b6 x73ccc6ab00212968(byte[] x43e181e083db6cdf, ThumbnailGeneratingOptions xdfde339da46db651)
	{
		if (x43e181e083db6cdf == null)
		{
			return null;
		}
		using x3cd5d648729cd9b6 x3cd5d648729cd9b2 = new x3cd5d648729cd9b6(x43e181e083db6cdf);
		int width = xdfde339da46db651.ThumbnailSize.Width;
		int height = xdfde339da46db651.ThumbnailSize.Height;
		x3cd5d648729cd9b6 x3cd5d648729cd9b = new x3cd5d648729cd9b6(width, height);
		x3cd5d648729cd9b2.x558cc83610335d8b(new Rectangle(0, 0, x3cd5d648729cd9b2.xdc1bf80853046136, x3cd5d648729cd9b2.xb0f146032f47c24e), x3cd5d648729cd9b, new Rectangle(0, 0, width, height));
		return x3cd5d648729cd9b;
	}

	private static x3cd5d648729cd9b6 xf35dbe2d96bf95b7(Document x3664041d21d73fdc, ThumbnailGeneratingOptions xdfde339da46db651)
	{
		x3cd5d648729cd9b6 x3cd5d648729cd9b = new x3cd5d648729cd9b6(xdfde339da46db651.ThumbnailSize.Width, xdfde339da46db651.ThumbnailSize.Height);
		using x3dacf8cbb5aec9f0 x3dacf8cbb5aec9f = new x3dacf8cbb5aec9f0(x3cd5d648729cd9b);
		x3dacf8cbb5aec9f.x24670816c6fb8451();
		x3664041d21d73fdc.RenderToSize(0, x3dacf8cbb5aec9f.x0c16bcbc7d053d08(), 0f, 0f, xdfde339da46db651.ThumbnailSize.Width, xdfde339da46db651.ThumbnailSize.Height);
		return x3cd5d648729cd9b;
	}
}
