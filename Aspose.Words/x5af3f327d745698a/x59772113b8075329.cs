using System;
using System.IO;
using Aspose;

namespace x5af3f327d745698a;

internal abstract class x59772113b8075329
{
	internal static x59772113b8075329 x06b0e25aa6ad68a9(BinaryReader xe134235b3526fa75)
	{
		xe134235b3526fa75.ReadInt32();
		switch (xe134235b3526fa75.ReadInt32())
		{
		case 0:
			return new xd19c736ea89ed0bc();
		default:
			throw new InvalidOperationException("Unexpected FormatID value, PresentationObject is corrupted.");
		case 5:
		{
			string text = x9ac0da7388ceac43.x58db9aaa4a730e59(xe134235b3526fa75);
			string text2;
			if ((text2 = text) != null && text2 == "METAFILEPICT")
			{
				return new x103f5cc254d14402(xe134235b3526fa75);
			}
			return new xd19c736ea89ed0bc();
		}
		}
	}

	[JavaThrows(true)]
	internal abstract void x6210059f049f0d48(BinaryWriter xbdfb620b7167944b);
}
