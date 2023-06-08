using System.IO;
using Aspose;
using Aspose.Words;
using x6c95d9cf46ff5f25;

namespace x1a62aaf14e3c5909;

internal abstract class xddf6304144fd3863
{
	private xebb8e4f90b5c1d33 xf49591a44359232f;

	private IWarningCallback xa056586c1f99e199;

	private byte[] x039f2310d5e80ce0;

	internal static bool x492f529cee830a40;

	internal xebb8e4f90b5c1d33 x1ea60bde2b5d0d28 => xf49591a44359232f;

	protected IWarningCallback xf69ca7a9bb4a4a51 => xa056586c1f99e199;

	internal xddf6304144fd3863()
	{
		xf49591a44359232f = new xebb8e4f90b5c1d33();
	}

	internal xddf6304144fd3863(x773fe540042dad03 type, int version)
		: this()
	{
		xf49591a44359232f.x3146d638ec378671 = type;
		xf49591a44359232f.x77fa6322561797a0 = version;
	}

	public override string ToString()
	{
		return $"{GetType().Name}, Header:{xf49591a44359232f.ToString()}, Data:{xcd4bd3abd72ff2da.xd20e56ce95eb96ff(x039f2310d5e80ce0)}";
	}

	internal void x06b0e25aa6ad68a9(BinaryReader xe134235b3526fa75, IWarningCallback x57fef5933b41d0c2)
	{
		x06b0e25aa6ad68a9(new xebb8e4f90b5c1d33(xe134235b3526fa75), xe134235b3526fa75, x57fef5933b41d0c2);
	}

	internal void x06b0e25aa6ad68a9(xebb8e4f90b5c1d33 x6b0ad9f73c48ad53, BinaryReader xe134235b3526fa75, IWarningCallback x57fef5933b41d0c2)
	{
		xf49591a44359232f = x6b0ad9f73c48ad53;
		xa056586c1f99e199 = x57fef5933b41d0c2;
		int num = (int)xe134235b3526fa75.BaseStream.Position;
		DoRead(xe134235b3526fa75);
		int num2 = (int)xe134235b3526fa75.BaseStream.Position - num;
		if (num2 != xf49591a44359232f.x1be93eed8950d961)
		{
			xbbf9a1ead81dd3a1(WarningType.UnexpectedContent, "Read wrong number of bytes from OfficeArt record, ignored.");
		}
		if (x492f529cee830a40)
		{
			xe134235b3526fa75.BaseStream.Position = num;
			x039f2310d5e80ce0 = xe134235b3526fa75.ReadBytes(xf49591a44359232f.x1be93eed8950d961);
		}
	}

	internal int x6210059f049f0d48(BinaryWriter xbdfb620b7167944b)
	{
		int num = (int)xbdfb620b7167944b.BaseStream.Position;
		x1ea60bde2b5d0d28.x6210059f049f0d48(xbdfb620b7167944b);
		int num2 = (int)xbdfb620b7167944b.BaseStream.Position;
		DoWrite(xbdfb620b7167944b);
		int num3 = (int)xbdfb620b7167944b.BaseStream.Position;
		x1ea60bde2b5d0d28.x1be93eed8950d961 = num3 - num2;
		xbdfb620b7167944b.BaseStream.Seek(num, SeekOrigin.Begin);
		x1ea60bde2b5d0d28.x6210059f049f0d48(xbdfb620b7167944b);
		xbdfb620b7167944b.BaseStream.Seek(num3, SeekOrigin.Begin);
		return num3 - num;
	}

	[JavaThrows(true)]
	protected abstract void DoRead(BinaryReader reader);

	[JavaThrows(true)]
	protected abstract void DoWrite(BinaryWriter writer);

	protected void xbbf9a1ead81dd3a1(WarningType x9f91de645a9fe01a, string xc2358fbac7da3d45)
	{
		if (xa056586c1f99e199 != null)
		{
			xa056586c1f99e199.Warning(new WarningInfo(x9f91de645a9fe01a, WarningSource.Doc, xc2358fbac7da3d45));
		}
	}
}
