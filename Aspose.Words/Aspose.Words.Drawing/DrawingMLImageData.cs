using System.Drawing;
using System.IO;
using x011d489fb9df7027;

namespace Aspose.Words.Drawing;

public class DrawingMLImageData : IImageData
{
	private readonly DrawingML x61f18ca85b7c2226;

	private readonly x8e500baeffc6e539 xbf762ca9cde15360;

	public byte[] ImageBytes
	{
		get
		{
			return xbf762ca9cde15360.xcc18177a965e0313;
		}
		set
		{
			xbf762ca9cde15360.xcc18177a965e0313 = value;
		}
	}

	public bool HasImage => xbf762ca9cde15360.x13055c95ca5083f1;

	public ImageSize ImageSize => xbf762ca9cde15360.x8d0c72c5b2891cbc;

	public ImageType ImageType => xbf762ca9cde15360.x688d6f6524ba3c8b;

	public bool IsLink => xbf762ca9cde15360.xce9657aabb6b6e6f;

	public bool IsLinkOnly => xbf762ca9cde15360.x66b8b219d7a8c7b2;

	public string SourceFullName
	{
		get
		{
			return xbf762ca9cde15360.x9f8e4dc805c6986e;
		}
		set
		{
			xbf762ca9cde15360.x9f8e4dc805c6986e = value;
		}
	}

	internal bool x169baa05e57bf312
	{
		get
		{
			if (ImageBytes != null)
			{
				return ImageBytes.Length > 0;
			}
			return false;
		}
	}

	internal DrawingMLImageData(DrawingML drawingML, Document document)
	{
		x61f18ca85b7c2226 = drawingML;
		xbf762ca9cde15360 = new x8e500baeffc6e539(document, new xc349e998e159a27c(x61f18ca85b7c2226));
	}

	public void SetImage(Image image)
	{
		xbf762ca9cde15360.xdb835d73003565c5(image);
	}

	[JavaInternal]
	public void SetImage(Stream stream)
	{
		xbf762ca9cde15360.xdb835d73003565c5(stream);
	}

	public void SetImage(string fileName)
	{
		xbf762ca9cde15360.xdb835d73003565c5(fileName);
	}

	public Image ToImage()
	{
		return xbf762ca9cde15360.x83e84e1d3bc59160();
	}

	public Stream ToStream()
	{
		return xbf762ca9cde15360.x3fd9dd6564874d14();
	}

	public byte[] ToByteArray()
	{
		return xbf762ca9cde15360.x2797b998ab68f4ab();
	}

	[JavaInternal]
	public void Save(Stream stream)
	{
		xbf762ca9cde15360.x0acd3c2012ea2ee8(stream);
	}

	public void Save(string fileName)
	{
		xbf762ca9cde15360.x0acd3c2012ea2ee8(fileName);
	}
}
