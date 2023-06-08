using System.Data;
using Aspose;
using x6c95d9cf46ff5f25;

namespace xe86f37adaccef1c3;

[JavaDelete("Not porting to Java.")]
internal class x4bc13e36748f1327 : xa11a4c48b53f49a6
{
	private readonly IDataReader x3e80e5ec36f43a17;

	private readonly string x36e76b649e6f4ede;

	private bool x3e61945adbb4ad79;

	string xa11a4c48b53f49a6.x1d7098e1d9b923c4 => x36e76b649e6f4ede;

	bool xa11a4c48b53f49a6.x710a6c34ca8a70b0 => true;

	int xa11a4c48b53f49a6.x7114f795b22529ae => x3e80e5ec36f43a17.FieldCount;

	internal x4bc13e36748f1327(IDataReader dataReader, string tableName)
	{
		x3e80e5ec36f43a17 = dataReader;
		x36e76b649e6f4ede = tableName;
	}

	private int x3f345eb74cf9a2f5(string x66ac3558868cc255)
	{
		for (int i = 0; i < x3e80e5ec36f43a17.FieldCount; i++)
		{
			if (x0d299f323d241756.x90637a473b1ceaaa(x3e80e5ec36f43a17.GetName(i), x66ac3558868cc255))
			{
				return i;
			}
		}
		return -1;
	}

	int xa11a4c48b53f49a6.x74b8d10dd9d29ac2(string x66ac3558868cc255)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x3f345eb74cf9a2f5
		return this.x3f345eb74cf9a2f5(x66ac3558868cc255);
	}

	private bool x8eea839d9ccd81d6(int x8e9b5f316bf9cf3d, out object x5fc53c4ffd3eb8c9)
	{
		if (!x69c36a228a9b3b39.xda36a3450e67c2d7(this, x8e9b5f316bf9cf3d))
		{
			x5fc53c4ffd3eb8c9 = null;
			return false;
		}
		x5fc53c4ffd3eb8c9 = x3e80e5ec36f43a17[x8e9b5f316bf9cf3d];
		return true;
	}

	bool xa11a4c48b53f49a6.x3f88a25febd23896(int x8e9b5f316bf9cf3d, out object x5fc53c4ffd3eb8c9)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x8eea839d9ccd81d6
		return this.x8eea839d9ccd81d6(x8e9b5f316bf9cf3d, out x5fc53c4ffd3eb8c9);
	}

	private bool x8eea839d9ccd81d6(string x66ac3558868cc255, out object x5fc53c4ffd3eb8c9)
	{
		return x69c36a228a9b3b39.x5f21ccf084377ea8(this, x66ac3558868cc255, out x5fc53c4ffd3eb8c9);
	}

	bool xa11a4c48b53f49a6.x3f88a25febd23896(string x66ac3558868cc255, out object x5fc53c4ffd3eb8c9)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x8eea839d9ccd81d6
		return this.x8eea839d9ccd81d6(x66ac3558868cc255, out x5fc53c4ffd3eb8c9);
	}

	private bool x39bb8a77b0e35781()
	{
		if (x3e61945adbb4ad79)
		{
			return false;
		}
		x3e61945adbb4ad79 = !x3e80e5ec36f43a17.Read();
		return !x3e61945adbb4ad79;
	}

	bool xa11a4c48b53f49a6.x47f176deff0d42e2()
	{
		//ILSpy generated this explicit interface implementation from .override directive in x39bb8a77b0e35781
		return this.x39bb8a77b0e35781();
	}

	private xa11a4c48b53f49a6 x24ae333dbfd93ca8(string xde5031b4f06bf874)
	{
		return null;
	}

	xa11a4c48b53f49a6 xa11a4c48b53f49a6.x438eef0af7e648c2(string xde5031b4f06bf874)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x24ae333dbfd93ca8
		return this.x24ae333dbfd93ca8(xde5031b4f06bf874);
	}
}
