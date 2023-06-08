using System;
using System.Collections;
using System.Drawing;
using System.IO;
using Aspose;
using x13f1efc79617a47b;
using x66dd9eaee57cfba4;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace xeb665d1aeef09d64;

internal class x9d888f53892d94df : x29ade4ed2382a039
{
	private readonly object x8f5ba7dd7ce36e75 = new object();

	private x551d3b1862a114b1[] x7a35c05d128a8e9d;

	private volatile x6b1a899052c71a60 x81acfa2904334464;

	private volatile xe1f670dfbcd03c5c x154caea24cfa721a;

	private string xbd9310393a5907ff = "Times New Roman";

	private static readonly x9d888f53892d94df x2da51bf57dd99b26 = new x9d888f53892d94df();

	private xe1f670dfbcd03c5c x2445f4cefb3cff80
	{
		get
		{
			if (x154caea24cfa721a == null)
			{
				lock (x8f5ba7dd7ce36e75)
				{
					if (x154caea24cfa721a == null)
					{
						x154caea24cfa721a = x34ef7a0ea5d7fab4();
					}
				}
			}
			return x154caea24cfa721a;
		}
	}

	private x6b1a899052c71a60 x4c3ea27d3641dbb0
	{
		get
		{
			if (x81acfa2904334464 == null)
			{
				lock (x8f5ba7dd7ce36e75)
				{
					if (x81acfa2904334464 == null)
					{
						x81acfa2904334464 = xf8e64ab842c242c7();
					}
				}
			}
			return x81acfa2904334464;
		}
	}

	public string x24fe1274033c7866
	{
		get
		{
			lock (x8f5ba7dd7ce36e75)
			{
				return xbd9310393a5907ff;
			}
		}
		set
		{
			lock (x8f5ba7dd7ce36e75)
			{
				xbd9310393a5907ff = ((value != null) ? value : string.Empty);
			}
		}
	}

	public static x9d888f53892d94df x9834ddb0e0bd5996 => x2da51bf57dd99b26;

	[JavaThrows(false)]
	private x9d888f53892d94df()
	{
		x74f5a1ef3906e23c();
	}

	public void xe085d0969cf4c4d7(x551d3b1862a114b1[] x224a10c5a9aa52ca)
	{
		if (x224a10c5a9aa52ca == null)
		{
			throw new ArgumentNullException("sources");
		}
		lock (x8f5ba7dd7ce36e75)
		{
			x7a35c05d128a8e9d = (x551d3b1862a114b1[])x224a10c5a9aa52ca.Clone();
			x154caea24cfa721a = null;
		}
	}

	public x551d3b1862a114b1[] x157ffd4aa001e74b()
	{
		return (x551d3b1862a114b1[])x7a35c05d128a8e9d.Clone();
	}

	public void x74f5a1ef3906e23c()
	{
		xe085d0969cf4c4d7(new x551d3b1862a114b1[1]
		{
			new x829cfec1381601a4()
		});
	}

	public override x6b1a899052c71a60 FetchTTFont(string familyName, FontStyle style, string altFamilyName)
	{
		x6b1a899052c71a60 x6b1a899052c71a = xdc2247c8d4648ae8(familyName, style);
		if (x6b1a899052c71a == null && x0d299f323d241756.x5959bccb67bbf051(altFamilyName))
		{
			x6b1a899052c71a = xdc2247c8d4648ae8(altFamilyName, style);
		}
		if (x6b1a899052c71a == null)
		{
			x6b1a899052c71a = x96e7db792b9f6e0e(style);
		}
		if (x6b1a899052c71a == null)
		{
			x6b1a899052c71a = xd3f8e541b341f67a();
		}
		if (x6b1a899052c71a == null)
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("ligigknialejnkljlkcknkjkgfaljjhljjolljfmoimmhednfiknpibohjioldpoohgpeinpaieadilaphcbjcjbpgacbhhcdhocbhfdlfmddgdeagkegfbfcfiflapfhfggdfngcaehdflheeciodjigppigehjjeojaefkodmkmcdlbdklpoam", 184583752)));
		}
		return x6b1a899052c71a;
	}

	internal override x6b1a899052c71a60 xdc2247c8d4648ae8(string xa79a9f649c74f4a4, FontStyle x44ecfea61c937b8e)
	{
		return x2445f4cefb3cff80.xdc2247c8d4648ae8(xa79a9f649c74f4a4, x44ecfea61c937b8e);
	}

	internal override x6b1a899052c71a60 x96e7db792b9f6e0e(FontStyle x44ecfea61c937b8e)
	{
		return x2445f4cefb3cff80.xdc2247c8d4648ae8(x24fe1274033c7866, x44ecfea61c937b8e);
	}

	internal override x6b1a899052c71a60 xd3f8e541b341f67a()
	{
		x6b1a899052c71a60 x6b1a899052c71a = x2445f4cefb3cff80.xd3f8e541b341f67a();
		if (x6b1a899052c71a == null)
		{
			return x4c3ea27d3641dbb0;
		}
		return x6b1a899052c71a;
	}

	[JavaThrows(false)]
	private xe1f670dfbcd03c5c x34ef7a0ea5d7fab4()
	{
		x551d3b1862a114b1[] array;
		lock (x8f5ba7dd7ce36e75)
		{
			array = x157ffd4aa001e74b();
		}
		ArrayList arrayList = new ArrayList();
		x551d3b1862a114b1[] array2 = array;
		foreach (x551d3b1862a114b1 x551d3b1862a114b2 in array2)
		{
			arrayList.AddRange(x551d3b1862a114b2.xe8752f84ee2ed522());
		}
		return new xe1f670dfbcd03c5c((x25998da3963930e9[])arrayList.ToArray(typeof(x25998da3963930e9)));
	}

	[JavaConvertCheckedExceptions]
	private static x6b1a899052c71a60 xf8e64ab842c242c7()
	{
		using Stream x23cda4cfdf81f2cf = xed747ca236d86aa0.xe1cd764b6fb0d6f6("Aspose.Resources.GenBasR.ttf");
		byte[] x0db5e88527e18b = x0d299f323d241756.xa0aed4cd3b3d5d92(x23cda4cfdf81f2cf);
		x6412d0c71c34c05c x6412d0c71c34c05c = new x6412d0c71c34c05c();
		return x6412d0c71c34c05c.x06b0e25aa6ad68a9(x0db5e88527e18b, null);
	}
}
