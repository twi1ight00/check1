using Aspose.Words;

namespace x28925c9b27b37a46;

internal class x98b0e09ccece0a5a
{
	private x98b0e09ccece0a5a()
	{
	}

	internal static void xbbf9a1ead81dd3a1(IWarningCallback x57fef5933b41d0c2, WarningType x9f91de645a9fe01a, WarningSource x697d2859ebdde9ec, string xc2358fbac7da3d45)
	{
		x57fef5933b41d0c2?.Warning(new WarningInfo(x9f91de645a9fe01a, x697d2859ebdde9ec, xc2358fbac7da3d45));
	}

	internal static void xbbf9a1ead81dd3a1(IWarningCallback x57fef5933b41d0c2, WarningType x9f91de645a9fe01a, WarningSource x697d2859ebdde9ec, string xc2358fbac7da3d45, params object[] xce8d8c7e3c2c2426)
	{
		x57fef5933b41d0c2?.Warning(new WarningInfo(x9f91de645a9fe01a, x697d2859ebdde9ec, string.Format(xc2358fbac7da3d45, xce8d8c7e3c2c2426)));
	}

	internal static void x3dc950453374051a(IWarningCallback x57fef5933b41d0c2, WarningSource x697d2859ebdde9ec, string xc2358fbac7da3d45, params object[] xce8d8c7e3c2c2426)
	{
		xbbf9a1ead81dd3a1(x57fef5933b41d0c2, WarningType.UnexpectedContent, x697d2859ebdde9ec, xc2358fbac7da3d45, xce8d8c7e3c2c2426);
	}

	internal static void x3dc950453374051a(IWarningCallback x57fef5933b41d0c2, string xc2358fbac7da3d45, params object[] xce8d8c7e3c2c2426)
	{
		xbbf9a1ead81dd3a1(x57fef5933b41d0c2, WarningType.UnexpectedContent, WarningSource.Unknown, xc2358fbac7da3d45, xce8d8c7e3c2c2426);
	}

	internal static void xd28f53fd94b9c0e4(IWarningCallback x57fef5933b41d0c2, WarningSource x697d2859ebdde9ec, string xc2358fbac7da3d45, params object[] xce8d8c7e3c2c2426)
	{
		xbbf9a1ead81dd3a1(x57fef5933b41d0c2, WarningType.DataLoss, x697d2859ebdde9ec, xc2358fbac7da3d45, xce8d8c7e3c2c2426);
	}

	internal static void xd28f53fd94b9c0e4(IWarningCallback x57fef5933b41d0c2, string xc2358fbac7da3d45, params object[] xce8d8c7e3c2c2426)
	{
		xbbf9a1ead81dd3a1(x57fef5933b41d0c2, WarningType.DataLoss, WarningSource.Unknown, xc2358fbac7da3d45, xce8d8c7e3c2c2426);
	}
}
