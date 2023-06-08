using System;
using System.IO;
using Aspose.Words.Drawing;
using x13f1efc79617a47b;
using x6c95d9cf46ff5f25;
using xe8730a664ff488a4;
using xf989f31a236ff98c;

namespace Aspose.Words;

public class FileFormatUtil
{
	private static readonly x09ce2c02826e31a6 xa0f67301bdd0a552;

	private static readonly x09ce2c02826e31a6 x6296ba9c6c96dc5a;

	private static readonly x09ce2c02826e31a6 x647d9816014e3baa;

	private static readonly x09ce2c02826e31a6 xef3a88a1b35991be;

	private static readonly x09ce2c02826e31a6 xb6ec8b982e701429;

	private static readonly x09ce2c02826e31a6 x992dd9abb430aeeb;

	private FileFormatUtil()
	{
	}

	public static FileFormatInfo DetectFileFormat(string fileName)
	{
		x0d299f323d241756.x48501aec8e48c869(fileName, "fileName");
		using Stream stream = File.OpenRead(fileName);
		return DetectFileFormat(stream);
	}

	[JavaInternal]
	public static FileFormatInfo DetectFileFormat(Stream stream)
	{
		if (stream == null)
		{
			throw new ArgumentNullException("stream");
		}
		try
		{
			x53dc82a419732f24 x53dc82a419732f = new x53dc82a419732f24();
			return x53dc82a419732f.xdef7f68a22ec051d(stream);
		}
		catch (Exception xfbf34718e704c6bc)
		{
			throw x9c29bee5df34fc46(xfbf34718e704c6bc);
		}
	}

	public static LoadFormat ContentTypeToLoadFormat(string contentType)
	{
		LoadFormat loadFormat = x3042ed00c1dfcf90(xb9015fe823e7e228.x79cfeb58677e6765(contentType));
		if (loadFormat != LoadFormat.Unknown)
		{
			return loadFormat;
		}
		throw new ArgumentException("Cannot convert this content type to a load format.");
	}

	public static SaveFormat ContentTypeToSaveFormat(string contentType)
	{
		SaveFormat saveFormat = x9ac6b4aed1d86203(xb9015fe823e7e228.x79cfeb58677e6765(contentType));
		if (saveFormat != 0)
		{
			return saveFormat;
		}
		throw new ArgumentException("Cannot convert this content type to a save format.");
	}

	public static string LoadFormatToExtension(LoadFormat loadFormat)
	{
		string text = xb9015fe823e7e228.xac88cb4f794761a9(x5547de8211dd1fc7(loadFormat));
		if (x0d299f323d241756.x5959bccb67bbf051(text))
		{
			return "." + text;
		}
		throw new ArgumentException("Cannot convert this load format to a file extension.");
	}

	public static LoadFormat SaveFormatToLoadFormat(SaveFormat saveFormat)
	{
		LoadFormat loadFormat = x3042ed00c1dfcf90(xa07d2187ecc55182(saveFormat));
		if (loadFormat != LoadFormat.Unknown)
		{
			return loadFormat;
		}
		throw new ArgumentException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("mdcphfjpbgaaofhamfoaoffbhambhedcafkcmebdbfidndpdhegegenepodfaelfbdcgpcjggdahaoghadohlbfincmijbdjbnjjebbkkbikkbpkcbgldanldbemmlkmnacnfajndlpnbpgonknogpepgplpfocafojaojabbohbhoobhofcpnmcanddaokdhjbe", 1759965689)));
	}

	public static SaveFormat LoadFormatToSaveFormat(LoadFormat loadFormat)
	{
		SaveFormat saveFormat = x9ac6b4aed1d86203(x5547de8211dd1fc7(loadFormat));
		if (saveFormat != 0)
		{
			return saveFormat;
		}
		throw new ArgumentException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("opmgjbehdclhacciobjiacajjmgjjaojcbfkoamkdbdlppjljabmiaimblomcagndpmnbpdoipkockbploiploppkngaknnadjebgnlbmnccmnjcenadfmhdfnodohfepmmehmdffhkfdlbgpgigplpgkkghmlnhikeiaglidkcjjkjjjkakbkhkcjokckfljfml", 442068155)));
	}

	public static string SaveFormatToExtension(SaveFormat saveFormat)
	{
		string text = xb9015fe823e7e228.xac88cb4f794761a9(xa07d2187ecc55182(saveFormat));
		if (x0d299f323d241756.x5959bccb67bbf051(text))
		{
			return "." + text;
		}
		throw new ArgumentException("Cannot convert this save format to a file extension.");
	}

	public static SaveFormat ExtensionToSaveFormat(string extension)
	{
		if (extension == null)
		{
			throw new ArgumentNullException("extension");
		}
		return x9ac6b4aed1d86203(xb9015fe823e7e228.x0f2906e6dae0813a(extension));
	}

	public static string ImageTypeToExtension(ImageType imageType)
	{
		switch (imageType)
		{
		case ImageType.NoImage:
		case ImageType.Unknown:
			throw new ArgumentException("Cannot convert this image type to a file extension.");
		default:
			return "." + xb9015fe823e7e228.xac88cb4f794761a9(x087a7d663d48e144(imageType));
		}
	}

	internal static Exception x9c29bee5df34fc46(Exception xfbf34718e704c6bc)
	{
		if (xfbf34718e704c6bc is InvalidOperationException)
		{
			return new FileCorruptedException(xfbf34718e704c6bc);
		}
		if (xfbf34718e704c6bc is EndOfStreamException)
		{
			return new FileCorruptedException(xfbf34718e704c6bc);
		}
		if (xfbf34718e704c6bc is IndexOutOfRangeException)
		{
			return new FileCorruptedException(xfbf34718e704c6bc);
		}
		if (xfbf34718e704c6bc is ArgumentException)
		{
			return new FileCorruptedException(xfbf34718e704c6bc);
		}
		if (xfbf34718e704c6bc is NullReferenceException)
		{
			return new FileCorruptedException(xfbf34718e704c6bc);
		}
		if (xfbf34718e704c6bc is FormatException)
		{
			return new FileCorruptedException(xfbf34718e704c6bc);
		}
		if (xfbf34718e704c6bc is xc5e345d2a919c94b)
		{
			return new FileCorruptedException(xfbf34718e704c6bc);
		}
		return xfbf34718e704c6bc;
	}

	internal static string x92e978705943edc1(SaveFormat xd003f66121eb36a0)
	{
		return xb9015fe823e7e228.ToString(xa07d2187ecc55182(xd003f66121eb36a0));
	}

	internal static SaveFormat x9ac6b4aed1d86203(xfe2ff3c162b47c70 x4e17f25eeff90cf4)
	{
		object obj = xb6ec8b982e701429.get_xe6d4b1b411ed94b5((int)x4e17f25eeff90cf4);
		if (obj != null)
		{
			return (SaveFormat)obj;
		}
		return SaveFormat.Unknown;
	}

	internal static ImageType xd93505cfb3e61804(xfe2ff3c162b47c70 x4e17f25eeff90cf4)
	{
		object obj = x992dd9abb430aeeb.get_xe6d4b1b411ed94b5((int)x4e17f25eeff90cf4);
		if (obj == null)
		{
			return ImageType.Unknown;
		}
		return (ImageType)obj;
	}

	private static xfe2ff3c162b47c70 x5547de8211dd1fc7(LoadFormat xdef7b99b7fc67519)
	{
		object obj = xa0f67301bdd0a552.get_xe6d4b1b411ed94b5((int)xdef7b99b7fc67519);
		if (obj != null)
		{
			return (xfe2ff3c162b47c70)obj;
		}
		return xfe2ff3c162b47c70.xf6c17f648b65c793;
	}

	private static xfe2ff3c162b47c70 xa07d2187ecc55182(SaveFormat xd003f66121eb36a0)
	{
		object obj = x6296ba9c6c96dc5a.get_xe6d4b1b411ed94b5((int)xd003f66121eb36a0);
		if (obj != null)
		{
			return (xfe2ff3c162b47c70)obj;
		}
		return xfe2ff3c162b47c70.xf6c17f648b65c793;
	}

	private static xfe2ff3c162b47c70 x087a7d663d48e144(ImageType x0182a6dae298f8a4)
	{
		object obj = x647d9816014e3baa.get_xe6d4b1b411ed94b5((int)x0182a6dae298f8a4);
		if (obj != null)
		{
			return (xfe2ff3c162b47c70)obj;
		}
		return xfe2ff3c162b47c70.xf6c17f648b65c793;
	}

	private static LoadFormat x3042ed00c1dfcf90(xfe2ff3c162b47c70 x4e17f25eeff90cf4)
	{
		object obj = xef3a88a1b35991be.get_xe6d4b1b411ed94b5((int)x4e17f25eeff90cf4);
		if (obj != null)
		{
			return (LoadFormat)obj;
		}
		return LoadFormat.Unknown;
	}

	private static void x70fa1602ceccddee(params object[] x337e217cb3ba0627)
	{
		for (int i = 0; i < x337e217cb3ba0627.Length; i += 4)
		{
			object obj = x337e217cb3ba0627[i];
			object obj2 = x337e217cb3ba0627[i + 1];
			object obj3 = x337e217cb3ba0627[i + 2];
			object obj4 = x337e217cb3ba0627[i + 3];
			if (obj2 != null)
			{
				xb6ec8b982e701429.xd6b6ed77479ef68c((int)obj, obj2);
				x6296ba9c6c96dc5a.xd6b6ed77479ef68c((int)obj2, obj);
			}
			if (obj3 != null)
			{
				if (!xef3a88a1b35991be.x263d579af1d0d43f((int)obj))
				{
					xef3a88a1b35991be.xd6b6ed77479ef68c((int)obj, obj3);
				}
				xa0f67301bdd0a552.xd6b6ed77479ef68c((int)obj3, obj);
			}
			if (obj4 != null)
			{
				x992dd9abb430aeeb.xd6b6ed77479ef68c((int)obj, obj4);
				x647d9816014e3baa.xd6b6ed77479ef68c((int)obj4, obj);
			}
		}
	}

	static FileFormatUtil()
	{
		xa0f67301bdd0a552 = new x09ce2c02826e31a6();
		x6296ba9c6c96dc5a = new x09ce2c02826e31a6();
		x647d9816014e3baa = new x09ce2c02826e31a6();
		xef3a88a1b35991be = new x09ce2c02826e31a6();
		xb6ec8b982e701429 = new x09ce2c02826e31a6();
		x992dd9abb430aeeb = new x09ce2c02826e31a6();
		x70fa1602ceccddee(xfe2ff3c162b47c70.xf29d447b35560f87, SaveFormat.Doc, LoadFormat.Doc, null, xfe2ff3c162b47c70.xf29d447b35560f87, null, LoadFormat.Auto, null, xfe2ff3c162b47c70.x3cb6807e93737c2d, SaveFormat.Dot, LoadFormat.Dot, null, xfe2ff3c162b47c70.xf2aa2ce921557bd6, SaveFormat.Docx, LoadFormat.Docx, null, xfe2ff3c162b47c70.x59bc1d2d01a89f08, SaveFormat.Docm, LoadFormat.Docm, null, xfe2ff3c162b47c70.x4fbfadbc48a8b0ff, SaveFormat.Dotx, LoadFormat.Dotx, null, xfe2ff3c162b47c70.xeab79a7b060cfae0, SaveFormat.Dotm, LoadFormat.Dotm, null, xfe2ff3c162b47c70.xb50ee49625ffa9b3, SaveFormat.FlatOpc, LoadFormat.FlatOpc, null, xfe2ff3c162b47c70.x13677b8122a7e4b9, SaveFormat.FlatOpcMacroEnabled, LoadFormat.FlatOpcMacroEnabled, null, xfe2ff3c162b47c70.x8b05d5ed9c1cf9d8, SaveFormat.FlatOpcTemplate, LoadFormat.FlatOpcTemplate, null, xfe2ff3c162b47c70.x2a828bc9fd060b65, SaveFormat.FlatOpcTemplateMacroEnabled, LoadFormat.FlatOpcTemplateMacroEnabled, null, xfe2ff3c162b47c70.x5896ed36f2cf9162, SaveFormat.Rtf, LoadFormat.Rtf, null, xfe2ff3c162b47c70.x13f5b6016cd2e8b8, SaveFormat.WordML, LoadFormat.WordML, null, xfe2ff3c162b47c70.x4bc88de02db3a00d, SaveFormat.Html, LoadFormat.Html, null, xfe2ff3c162b47c70.x23a8fbf7780a9c30, SaveFormat.Mhtml, LoadFormat.Mhtml, null, xfe2ff3c162b47c70.xdc5b90a3edb706a6, SaveFormat.Odt, LoadFormat.Odt, null, xfe2ff3c162b47c70.xf81522cc52524aa3, SaveFormat.Ott, LoadFormat.Ott, null, xfe2ff3c162b47c70.x6fcc29eace04fce1, SaveFormat.Pdf, null, null, xfe2ff3c162b47c70.x64a7e1d48dfb2e43, SaveFormat.Xps, null, null, xfe2ff3c162b47c70.xce63990f9b88e8f7, SaveFormat.XamlFixed, null, null, xfe2ff3c162b47c70.xffe454f29a855c10, SaveFormat.Swf, null, null, xfe2ff3c162b47c70.x6b60f7630a7ba83e, SaveFormat.Svg, null, null, xfe2ff3c162b47c70.xbaa6d01bddb61fad, SaveFormat.Epub, null, null, xfe2ff3c162b47c70.x6575e3132c2315a1, SaveFormat.Text, LoadFormat.Text, null, xfe2ff3c162b47c70.x996f98c23f508228, SaveFormat.XamlFlow, null, null, xfe2ff3c162b47c70.x15c106572f1e1fbf, SaveFormat.Tiff, null, null, xfe2ff3c162b47c70.x6339cdb9e2b512c7, SaveFormat.Png, null, ImageType.Png, xfe2ff3c162b47c70.xc2746d872ce402e9, SaveFormat.Bmp, null, ImageType.Bmp, xfe2ff3c162b47c70.x796ab23ce57ee1e0, SaveFormat.Jpeg, null, ImageType.Jpeg, xfe2ff3c162b47c70.x26c36dd85013b919, null, null, ImageType.Pict, xfe2ff3c162b47c70.xb5fe04c34562f438, null, null, ImageType.Wmf, xfe2ff3c162b47c70.x52164632cde900c3, SaveFormat.XamlFlowPack, null, null, xfe2ff3c162b47c70.xd69df86e2a88ddb2, SaveFormat.Emf, null, ImageType.Emf);
	}
}
