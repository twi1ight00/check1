using Aspose.Words.Reporting;

namespace xe86f37adaccef1c3;

internal class xc5100786b43214b6 : xa11a4c48b53f49a6
{
	private const string xeaca206afa09ea18 = "This class member can not be used as field by index access is not supported.";

	private readonly IMailMergeDataSource xd921ab3d3436ba2a;

	string xa11a4c48b53f49a6.x1d7098e1d9b923c4 => xd921ab3d3436ba2a.TableName;

	bool xa11a4c48b53f49a6.x710a6c34ca8a70b0 => false;

	int xa11a4c48b53f49a6.x7114f795b22529ae => 0;

	private xc5100786b43214b6(IMailMergeDataSource adaptee)
	{
		xd921ab3d3436ba2a = adaptee;
	}

	internal static xa11a4c48b53f49a6 x19382cb261a59e98(IMailMergeDataSource xa67e59cb7a5640d8)
	{
		if (xa67e59cb7a5640d8 != null)
		{
			return new xc5100786b43214b6(xa67e59cb7a5640d8);
		}
		return null;
	}

	private bool x39bb8a77b0e35781()
	{
		return xd921ab3d3436ba2a.MoveNext();
	}

	bool xa11a4c48b53f49a6.x47f176deff0d42e2()
	{
		//ILSpy generated this explicit interface implementation from .override directive in x39bb8a77b0e35781
		return this.x39bb8a77b0e35781();
	}

	private int x3f345eb74cf9a2f5(string x66ac3558868cc255)
	{
		return -1;
	}

	int xa11a4c48b53f49a6.x74b8d10dd9d29ac2(string x66ac3558868cc255)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x3f345eb74cf9a2f5
		return this.x3f345eb74cf9a2f5(x66ac3558868cc255);
	}

	private bool x8eea839d9ccd81d6(int x8e9b5f316bf9cf3d, out object x5fc53c4ffd3eb8c9)
	{
		x5fc53c4ffd3eb8c9 = null;
		return false;
	}

	bool xa11a4c48b53f49a6.x3f88a25febd23896(int x8e9b5f316bf9cf3d, out object x5fc53c4ffd3eb8c9)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x8eea839d9ccd81d6
		return this.x8eea839d9ccd81d6(x8e9b5f316bf9cf3d, out x5fc53c4ffd3eb8c9);
	}

	private bool x8eea839d9ccd81d6(string x66ac3558868cc255, out object x5fc53c4ffd3eb8c9)
	{
		return xd921ab3d3436ba2a.GetValue(x66ac3558868cc255, out x5fc53c4ffd3eb8c9);
	}

	bool xa11a4c48b53f49a6.x3f88a25febd23896(string x66ac3558868cc255, out object x5fc53c4ffd3eb8c9)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x8eea839d9ccd81d6
		return this.x8eea839d9ccd81d6(x66ac3558868cc255, out x5fc53c4ffd3eb8c9);
	}

	private xa11a4c48b53f49a6 x24ae333dbfd93ca8(string xde5031b4f06bf874)
	{
		return x19382cb261a59e98(xd921ab3d3436ba2a.GetChildDataSource(xde5031b4f06bf874));
	}

	xa11a4c48b53f49a6 xa11a4c48b53f49a6.x438eef0af7e648c2(string xde5031b4f06bf874)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x24ae333dbfd93ca8
		return this.x24ae333dbfd93ca8(xde5031b4f06bf874);
	}
}
