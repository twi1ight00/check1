using Aspose.Words;
using x6c95d9cf46ff5f25;

namespace x28925c9b27b37a46;

internal class x7c8328a75e9baa2d : x54b98d0096d7251a
{
	private readonly IWarningCallback xa056586c1f99e199;

	internal x7c8328a75e9baa2d(IWarningCallback warningCallback)
	{
		xa056586c1f99e199 = warningCallback;
	}

	private void xa69b5bb3332785f8(x6d058fdf61831c39 x9f91de645a9fe01a, x3959df40367ac8a3 x337e217cb3ba0627, string xc2358fbac7da3d45)
	{
		if (xa056586c1f99e199 != null)
		{
			WarningType warningType = WarningInfo.x0e253203059fba0d(x9f91de645a9fe01a);
			WarningSource source = WarningInfo.xe21c54c20bac02ec(x337e217cb3ba0627);
			xa056586c1f99e199.Warning(new WarningInfo(warningType, source, xc2358fbac7da3d45));
		}
	}

	void x54b98d0096d7251a.xbbf9a1ead81dd3a1(x6d058fdf61831c39 x9f91de645a9fe01a, x3959df40367ac8a3 x337e217cb3ba0627, string xc2358fbac7da3d45)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xa69b5bb3332785f8
		this.xa69b5bb3332785f8(x9f91de645a9fe01a, x337e217cb3ba0627, xc2358fbac7da3d45);
	}

	private void xa69b5bb3332785f8(x6d058fdf61831c39 x9f91de645a9fe01a, x3959df40367ac8a3 x337e217cb3ba0627, string x5786461d089b10a0, object xe88104aeaa19b45d)
	{
		if (xa056586c1f99e199 != null)
		{
			string xc2358fbac7da3d = string.Format(x5786461d089b10a0, xe88104aeaa19b45d);
			((x54b98d0096d7251a)this).xbbf9a1ead81dd3a1(x9f91de645a9fe01a, x337e217cb3ba0627, xc2358fbac7da3d);
		}
	}

	void x54b98d0096d7251a.xbbf9a1ead81dd3a1(x6d058fdf61831c39 x9f91de645a9fe01a, x3959df40367ac8a3 x337e217cb3ba0627, string x5786461d089b10a0, object xe88104aeaa19b45d)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xa69b5bb3332785f8
		this.xa69b5bb3332785f8(x9f91de645a9fe01a, x337e217cb3ba0627, x5786461d089b10a0, xe88104aeaa19b45d);
	}
}
