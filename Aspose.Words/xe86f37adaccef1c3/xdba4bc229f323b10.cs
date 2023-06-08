using Aspose.Words.Reporting;

namespace xe86f37adaccef1c3;

internal class xdba4bc229f323b10 : xe0a98df97f5fe1f3
{
	private readonly IMailMergeDataSourceRoot xd921ab3d3436ba2a;

	private xdba4bc229f323b10(IMailMergeDataSourceRoot adaptee)
	{
		xd921ab3d3436ba2a = adaptee;
	}

	internal static xe0a98df97f5fe1f3 x19382cb261a59e98(IMailMergeDataSourceRoot xa67e59cb7a5640d8)
	{
		if (xa67e59cb7a5640d8 != null)
		{
			return new xdba4bc229f323b10(xa67e59cb7a5640d8);
		}
		return null;
	}

	private xa11a4c48b53f49a6 xd80a6f71e431b210(string xde5031b4f06bf874)
	{
		return xc5100786b43214b6.x19382cb261a59e98(xd921ab3d3436ba2a.GetDataSource(xde5031b4f06bf874));
	}

	xa11a4c48b53f49a6 xe0a98df97f5fe1f3.xf6d2c418f136d715(string xde5031b4f06bf874)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xd80a6f71e431b210
		return this.xd80a6f71e431b210(xde5031b4f06bf874);
	}
}
