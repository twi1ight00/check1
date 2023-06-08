using System.Drawing;
using x5794c252ba25e723;
using x66dd9eaee57cfba4;

namespace xeb665d1aeef09d64;

internal abstract class x29ade4ed2382a039
{
	public abstract x6b1a899052c71a60 FetchTTFont(string familyName, FontStyle style, string altFamilyName);

	public xe39d06eee35dd23d x491f5a7224612753(string xa79a9f649c74f4a4, float xdb421875a5f5258b, FontStyle x44ecfea61c937b8e)
	{
		return x491f5a7224612753(xa79a9f649c74f4a4, xdb421875a5f5258b, x44ecfea61c937b8e, null);
	}

	public xe39d06eee35dd23d x491f5a7224612753(string xa79a9f649c74f4a4, float xdb421875a5f5258b, FontStyle x44ecfea61c937b8e, string x050683ee5a5f962b)
	{
		return x491f5a7224612753(xa79a9f649c74f4a4, xdb421875a5f5258b, x44ecfea61c937b8e, x050683ee5a5f962b, x44ecfea61c937b8e);
	}

	public xe39d06eee35dd23d x491f5a7224612753(string xa79a9f649c74f4a4, float xdb421875a5f5258b, FontStyle x859cb06f97fbd90a, string x050683ee5a5f962b, FontStyle x183d1a5479ec50ad)
	{
		return new xe39d06eee35dd23d(xdb421875a5f5258b, x859cb06f97fbd90a, FetchTTFont(xa79a9f649c74f4a4, x183d1a5479ec50ad, x050683ee5a5f962b));
	}

	internal abstract x6b1a899052c71a60 xdc2247c8d4648ae8(string xa79a9f649c74f4a4, FontStyle x44ecfea61c937b8e);

	internal abstract x6b1a899052c71a60 x96e7db792b9f6e0e(FontStyle x44ecfea61c937b8e);

	internal abstract x6b1a899052c71a60 xd3f8e541b341f67a();
}
