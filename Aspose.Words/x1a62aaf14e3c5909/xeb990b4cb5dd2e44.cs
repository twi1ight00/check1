using System.IO;
using Aspose.Words;
using x28925c9b27b37a46;

namespace x1a62aaf14e3c5909;

internal class xeb990b4cb5dd2e44
{
	internal static xddf6304144fd3863 x2785b0923dba0723(BinaryReader xe134235b3526fa75, IWarningCallback x57fef5933b41d0c2)
	{
		xebb8e4f90b5c1d33 xebb8e4f90b5c1d34 = new xebb8e4f90b5c1d33(xe134235b3526fa75);
		Stream baseStream = xe134235b3526fa75.BaseStream;
		if (xebb8e4f90b5c1d34.x1be93eed8950d961 < 0 || baseStream.Position + xebb8e4f90b5c1d34.x1be93eed8950d961 > baseStream.Length)
		{
			x98b0e09ccece0a5a.x3dc950453374051a(x57fef5933b41d0c2, WarningSource.Doc, "Invalid OfficeArt record length, corrected.");
			xebb8e4f90b5c1d34.x1be93eed8950d961 = (int)(baseStream.Length - baseStream.Position);
		}
		xddf6304144fd3863 xddf6304144fd3864 = xe6b192050061ba71(xebb8e4f90b5c1d34, x57fef5933b41d0c2);
		xddf6304144fd3864.x06b0e25aa6ad68a9(xebb8e4f90b5c1d34, xe134235b3526fa75, x57fef5933b41d0c2);
		return xddf6304144fd3864;
	}

	private static xddf6304144fd3863 xe6b192050061ba71(xebb8e4f90b5c1d33 x6b0ad9f73c48ad53, IWarningCallback x57fef5933b41d0c2)
	{
		switch (x6b0ad9f73c48ad53.x3146d638ec378671)
		{
		case x773fe540042dad03.xad9b6174740c7664:
			return new x57b6730bb29ba4a9();
		case x773fe540042dad03.x6da9472bbc4fce2c:
			return new xef64b8221aa2a96c();
		case x773fe540042dad03.xfd0364e33cd32983:
			return new xc2d70347f7484382();
		case x773fe540042dad03.x1a32cef9417f917a:
			return new xfbb3f4be330f4086();
		case x773fe540042dad03.xcdcac80ab78b806b:
		case x773fe540042dad03.x0bb34b8e0b166632:
		case x773fe540042dad03.xde0acc3a1f9bfc90:
			return new x05e3661630595852();
		case x773fe540042dad03.xd3c9fc7d08aaa070:
		case x773fe540042dad03.x8a52fab6c91f17ab:
		case x773fe540042dad03.x9e4b591cdff9a164:
		case x773fe540042dad03.x01f3385b3c4532b4:
			return new x681808f408a7efac();
		case x773fe540042dad03.xfee552314006c468:
			return new x5f3a67c2a92bcd0b();
		case x773fe540042dad03.x91ac32ef4a85c752:
			return new x3ed37e433e884f79();
		case x773fe540042dad03.xf556a619f6f995f0:
			return new x0c6eac1af67f9f81();
		case x773fe540042dad03.x873e507a3bc924e4:
			return new x1f112a7e89020b14();
		case x773fe540042dad03.xf6e35fb163f1c232:
			return new xc6764e97e740ec5a();
		case x773fe540042dad03.xa9993ed2e0c64574:
			return new x00f3419456bbf9dc();
		case x773fe540042dad03.x25010a8486e00671:
		case x773fe540042dad03.xb80a65a936e596c7:
			return new x7307718157e7e7c1();
		case x773fe540042dad03.x1962dcc80a92cc09:
			return new x60a83a1c77a6b0d0();
		case x773fe540042dad03.x5381fc3ac16f2f52:
			return new x753e51109756f7c2();
		case x773fe540042dad03.x8615a69be17cd289:
			return new xa8c46bf9cb77fa81();
		case x773fe540042dad03.xbdcae400829f58c2:
			return new x7cc5116ad29b31ca();
		case x773fe540042dad03.xa3ef8c286944e3ed:
			return new x4eec0870fb341d7e();
		case x773fe540042dad03.x21b2da74ae5ae1d8:
			x98b0e09ccece0a5a.x3dc950453374051a(x57fef5933b41d0c2, WarningSource.Doc, "DeletedPspl OfficeArt record is not supported, ignored.");
			return new xf6779bbc50998d69();
		case x773fe540042dad03.xc7cd88af843152f9:
			x98b0e09ccece0a5a.x3dc950453374051a(x57fef5933b41d0c2, WarningSource.Doc, "ColorMru OfficeArt record is not supported, ignored.");
			return new xf6779bbc50998d69();
		case x773fe540042dad03.x66105e422ac8a42a:
			return new x9ced206c3c179783();
		case x773fe540042dad03.x6299a07c6a18ef52:
			return new xccdb3c81ecbef978();
		case x773fe540042dad03.x4d4c1c7ea2b00c54:
			return new x5b34b03376e22f41();
		case x773fe540042dad03.xbc9fe6190e5749fa:
			return new xe98b7313e69b63e3();
		case x773fe540042dad03.x5e0bc8119f757f1b:
			return new xf6779bbc50998d69();
		default:
			x98b0e09ccece0a5a.x3dc950453374051a(x57fef5933b41d0c2, WarningSource.Doc, "Unknown OfficeArt record 0x{0:x4} found, ignored.", (int)x6b0ad9f73c48ad53.x3146d638ec378671);
			return new xf6779bbc50998d69();
		}
	}
}
