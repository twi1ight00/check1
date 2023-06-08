using System;
using System.Collections;
using System.IO;
using System.Reflection;
using Aspose.Words;

namespace x1a62aaf14e3c5909;

[DefaultMember("Item")]
internal class x622ccf73c1aa9e89 : ArrayList
{
	public xddf6304144fd3863 xe6d4b1b411ed94b5
	{
		get
		{
			return (xddf6304144fd3863)base[xc0c4c459c6ccbd00];
		}
		set
		{
			base[xc0c4c459c6ccbd00] = value;
		}
	}

	internal void x06b0e25aa6ad68a9(BinaryReader xe134235b3526fa75, int x961016a387451f05, IWarningCallback x57fef5933b41d0c2)
	{
		long val = xe134235b3526fa75.BaseStream.Position + x961016a387451f05;
		val = Math.Min(val, xe134235b3526fa75.BaseStream.Length);
		while (xe134235b3526fa75.BaseStream.Position < val)
		{
			xddf6304144fd3863 xddf6304144fd3864 = xeb990b4cb5dd2e44.x2785b0923dba0723(xe134235b3526fa75, x57fef5933b41d0c2);
			if (xddf6304144fd3864 != null)
			{
				Add(xddf6304144fd3864);
			}
		}
	}

	internal int x6210059f049f0d48(BinaryWriter xbdfb620b7167944b)
	{
		long position = xbdfb620b7167944b.BaseStream.Position;
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				xddf6304144fd3863 xddf6304144fd3864 = (xddf6304144fd3863)enumerator.Current;
				xddf6304144fd3864.x6210059f049f0d48(xbdfb620b7167944b);
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		return (int)(xbdfb620b7167944b.BaseStream.Position - position);
	}
}
