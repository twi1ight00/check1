using System;
using System.IO;
using Aspose;
using Aspose.Words.Drawing;
using x011d489fb9df7027;
using x13f1efc79617a47b;

namespace x1a62aaf14e3c5909;

internal abstract class xd959c7c7ca733332 : xddf6304144fd3863
{
	protected const int xc5f403e1c8e160a7 = 16;

	private Guid x2e368c44c54c3e9a = Guid.Empty;

	private Guid x59bf9ac60fbbdd40 = Guid.Empty;

	internal Guid x0217cda8370c1f17 => x2e368c44c54c3e9a;

	internal ImageType x688d6f6524ba3c8b
	{
		get
		{
			return xbb964bcaea5d065b(base.x1ea60bde2b5d0d28.x3146d638ec378671);
		}
		set
		{
			base.x1ea60bde2b5d0d28.x3146d638ec378671 = x7c04dfdc39678183(value);
			base.x1ea60bde2b5d0d28.x9834ddb0e0bd5996 = (int)xee039d0366191524(value);
		}
	}

	[JavaThrows(true)]
	internal abstract byte[] xcc18177a965e0313 { get; }

	internal abstract x10884bb8036bcee0 x10884bb8036bcee0 { get; }

	internal xd959c7c7ca733332()
	{
	}

	internal xd959c7c7ca733332(Guid guid)
	{
		x2e368c44c54c3e9a = guid;
	}

	private static ImageType xbb964bcaea5d065b(x773fe540042dad03 xc1674de501b364d0)
	{
		return (ImageType)(xc1674de501b364d0 - 61464);
	}

	private static x773fe540042dad03 x7c04dfdc39678183(ImageType x0182a6dae298f8a4)
	{
		return (x773fe540042dad03)(x0182a6dae298f8a4 + 61464);
	}

	private static xbb5a1542d7013c29 xee039d0366191524(ImageType x0182a6dae298f8a4)
	{
		return x0182a6dae298f8a4 switch
		{
			ImageType.Wmf => xbb5a1542d7013c29.xb5fe04c34562f438, 
			ImageType.Emf => xbb5a1542d7013c29.xd69df86e2a88ddb2, 
			ImageType.Pict => xbb5a1542d7013c29.x26c36dd85013b919, 
			ImageType.Jpeg => xbb5a1542d7013c29.x796ab23ce57ee1e0, 
			ImageType.Png => xbb5a1542d7013c29.x6339cdb9e2b512c7, 
			ImageType.Bmp => xbb5a1542d7013c29.xc2746d872ce402e9, 
			_ => throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("cpchiakhcabicaiiaapifagjjpmjikdkookkpoblaoildoplongmgjnmjnenpnlnpncohnjoimapinhppiop", 174879389))), 
		};
	}

	protected void x46acc5353d0f1389(BinaryReader xe134235b3526fa75)
	{
		x2e368c44c54c3e9a = x4aab09bdfc81a44f(xe134235b3526fa75);
		if (((uint)base.x1ea60bde2b5d0d28.x9834ddb0e0bd5996 & (true ? 1u : 0u)) != 0)
		{
			x59bf9ac60fbbdd40 = x4aab09bdfc81a44f(xe134235b3526fa75);
		}
	}

	protected void x356b036984855690(BinaryWriter xbdfb620b7167944b)
	{
		xbdfb620b7167944b.Write(x2e368c44c54c3e9a.ToByteArray());
		if (((uint)base.x1ea60bde2b5d0d28.x9834ddb0e0bd5996 & (true ? 1u : 0u)) != 0)
		{
			xbdfb620b7167944b.Write(x59bf9ac60fbbdd40.ToByteArray());
		}
	}

	private static Guid x4aab09bdfc81a44f(BinaryReader xe134235b3526fa75)
	{
		return new Guid(xe134235b3526fa75.ReadBytes(16));
	}
}
