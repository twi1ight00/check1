using System.Data;
using Aspose;
using Aspose.Words.Reporting;

namespace xe86f37adaccef1c3;

[JavaManual("In Java this works with JDBC instead of ADO.NET.")]
internal class x6e6727b879a56b1a : x77c422f73b569bd1, xa11a4c48b53f49a6
{
	private readonly DataRow[] x00b023d6a2bf9648;

	private readonly string x36e76b649e6f4ede;

	string xa11a4c48b53f49a6.x1d7098e1d9b923c4 => x36e76b649e6f4ede;

	int xa11a4c48b53f49a6.x7114f795b22529ae => x75b182f2ca311c3a();

	internal x6e6727b879a56b1a(MailMerge mailMerge, DataRow parentRow, DataRelation childRelation)
		: base(mailMerge)
	{
		x00b023d6a2bf9648 = parentRow.GetChildRows(childRelation);
		x36e76b649e6f4ede = childRelation.ChildTable.TableName;
	}

	protected override bool IsEof()
	{
		return base.x88ea13b6283cc215 >= x00b023d6a2bf9648.Length;
	}

	protected override DataRow GetCurrentDataRowCore()
	{
		return x00b023d6a2bf9648[base.x88ea13b6283cc215];
	}

	private int x3f345eb74cf9a2f5(string x66ac3558868cc255)
	{
		return x74b8d10dd9d29ac2(x66ac3558868cc255);
	}

	int xa11a4c48b53f49a6.x74b8d10dd9d29ac2(string x66ac3558868cc255)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x3f345eb74cf9a2f5
		return this.x3f345eb74cf9a2f5(x66ac3558868cc255);
	}

	private bool x8eea839d9ccd81d6(int x8e9b5f316bf9cf3d, out object x5fc53c4ffd3eb8c9)
	{
		return x3f88a25febd23896(x8e9b5f316bf9cf3d, out x5fc53c4ffd3eb8c9);
	}

	bool xa11a4c48b53f49a6.x3f88a25febd23896(int x8e9b5f316bf9cf3d, out object x5fc53c4ffd3eb8c9)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x8eea839d9ccd81d6
		return this.x8eea839d9ccd81d6(x8e9b5f316bf9cf3d, out x5fc53c4ffd3eb8c9);
	}

	private bool x8eea839d9ccd81d6(string x66ac3558868cc255, out object x5fc53c4ffd3eb8c9)
	{
		return x3f88a25febd23896(x66ac3558868cc255, out x5fc53c4ffd3eb8c9);
	}

	bool xa11a4c48b53f49a6.x3f88a25febd23896(string x66ac3558868cc255, out object x5fc53c4ffd3eb8c9)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x8eea839d9ccd81d6
		return this.x8eea839d9ccd81d6(x66ac3558868cc255, out x5fc53c4ffd3eb8c9);
	}

	private xa11a4c48b53f49a6 x24ae333dbfd93ca8(string xde5031b4f06bf874)
	{
		return x438eef0af7e648c2(xde5031b4f06bf874);
	}

	xa11a4c48b53f49a6 xa11a4c48b53f49a6.x438eef0af7e648c2(string xde5031b4f06bf874)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x24ae333dbfd93ca8
		return this.x24ae333dbfd93ca8(xde5031b4f06bf874);
	}
}
