using System.Data;
using Aspose;
using Aspose.Words.Reporting;
using x6c95d9cf46ff5f25;

namespace xe86f37adaccef1c3;

internal abstract class x77c422f73b569bd1
{
	private readonly MailMerge x17e7624bcb28c892;

	private int x6124087465d51967;

	public bool x0180a8f719ebb034 => true;

	[JavaThrows(true)]
	protected int x88ea13b6283cc215 => x6124087465d51967;

	protected x77c422f73b569bd1(MailMerge mailMerge)
	{
		x17e7624bcb28c892 = mailMerge;
		x6124087465d51967 = -1;
	}

	[JavaThrows(true)]
	public bool x47f176deff0d42e2()
	{
		if (IsEof())
		{
			return false;
		}
		x6124087465d51967++;
		return !IsEof();
	}

	[JavaThrows(true)]
	protected abstract bool IsEof();

	private DataRow xbfcc35eb2432ead6()
	{
		return GetCurrentDataRowCore();
	}

	protected virtual DataRow GetCurrentDataRowCore()
	{
		return null;
	}

	protected bool x3f88a25febd23896(string x66ac3558868cc255, out object x5fc53c4ffd3eb8c9)
	{
		return x3f88a25febd23896(xbfcc35eb2432ead6(), x66ac3558868cc255, out x5fc53c4ffd3eb8c9);
	}

	private bool x3f88a25febd23896(DataRow xa806b754814b9ae0, string x66ac3558868cc255, out object x5fc53c4ffd3eb8c9)
	{
		if (x3f88a25febd23896(xa806b754814b9ae0, x74b8d10dd9d29ac2(xa806b754814b9ae0, x66ac3558868cc255), out x5fc53c4ffd3eb8c9))
		{
			return true;
		}
		if (!x17e7624bcb28c892.UseNonMergeFields)
		{
			return false;
		}
		int num = x69c36a228a9b3b39.x85f795c533a8433f(x66ac3558868cc255);
		if (num == -1)
		{
			return false;
		}
		string xd30816dd72b = x69c36a228a9b3b39.x08b8822c2b320c6a(x66ac3558868cc255, num);
		string x66ac3558868cc256 = x69c36a228a9b3b39.x7a72474f72a62daf(x66ac3558868cc255, num);
		DataRow dataRow = x6fe186ea0f2b4711(xa806b754814b9ae0, xd30816dd72b);
		if (dataRow == null)
		{
			return false;
		}
		return x3f88a25febd23896(dataRow, x66ac3558868cc256, out x5fc53c4ffd3eb8c9);
	}

	private static DataRow x6fe186ea0f2b4711(DataRow xfbf9d376a0c88d8d, string xd30816dd72b54510)
	{
		DataTable table = xfbf9d376a0c88d8d.Table;
		DataSet dataSet = table.DataSet;
		if (dataSet == null)
		{
			return null;
		}
		DataRelation dataRelation = x87441343ca505fb4(dataSet, table.TableName, xd30816dd72b54510);
		if (dataRelation != null)
		{
			DataRow[] childRows = xfbf9d376a0c88d8d.GetChildRows(dataRelation);
			if (childRows.Length <= 0)
			{
				return null;
			}
			return childRows[0];
		}
		DataTable dataTable = dataSet.Tables[xd30816dd72b54510];
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			return dataTable.Rows[0];
		}
		return null;
	}

	protected bool x3f88a25febd23896(int x8e9b5f316bf9cf3d, out object x5fc53c4ffd3eb8c9)
	{
		return x3f88a25febd23896(xbfcc35eb2432ead6(), x8e9b5f316bf9cf3d, out x5fc53c4ffd3eb8c9);
	}

	private bool x3f88a25febd23896(DataRow xa806b754814b9ae0, int x8e9b5f316bf9cf3d, out object x5fc53c4ffd3eb8c9)
	{
		if (x8e9b5f316bf9cf3d < 0 || x8e9b5f316bf9cf3d >= x75b182f2ca311c3a(xa806b754814b9ae0))
		{
			x5fc53c4ffd3eb8c9 = null;
			return false;
		}
		x5fc53c4ffd3eb8c9 = xa806b754814b9ae0[x8e9b5f316bf9cf3d];
		return true;
	}

	protected int x74b8d10dd9d29ac2(string x66ac3558868cc255)
	{
		return x74b8d10dd9d29ac2(xbfcc35eb2432ead6(), x66ac3558868cc255);
	}

	private int x74b8d10dd9d29ac2(DataRow xa806b754814b9ae0, string x66ac3558868cc255)
	{
		return xa806b754814b9ae0.Table.Columns.IndexOf(x66ac3558868cc255);
	}

	protected int x75b182f2ca311c3a()
	{
		return x75b182f2ca311c3a(xbfcc35eb2432ead6());
	}

	private int x75b182f2ca311c3a(DataRow xa806b754814b9ae0)
	{
		return xa806b754814b9ae0.Table.Columns.Count;
	}

	protected xa11a4c48b53f49a6 x438eef0af7e648c2(string xd30816dd72b54510)
	{
		return x438eef0af7e648c2(xbfcc35eb2432ead6(), xd30816dd72b54510);
	}

	private xa11a4c48b53f49a6 x438eef0af7e648c2(DataRow xfbf9d376a0c88d8d, string xd30816dd72b54510)
	{
		DataTable table = xfbf9d376a0c88d8d.Table;
		DataSet dataSet = table.DataSet;
		if (dataSet == null)
		{
			return null;
		}
		DataRelation dataRelation = x87441343ca505fb4(dataSet, table.TableName, xd30816dd72b54510);
		if (dataRelation != null)
		{
			return new x6e6727b879a56b1a(x17e7624bcb28c892, xfbf9d376a0c88d8d, dataRelation);
		}
		DataTable dataTable = dataSet.Tables[xd30816dd72b54510];
		if (dataTable != null)
		{
			return new x615b80dcc88fc837(x17e7624bcb28c892, dataTable);
		}
		return null;
	}

	private static DataRelation x87441343ca505fb4(DataSet xb84e142a2d790b60, string x4008193de221d9e1, string xd30816dd72b54510)
	{
		foreach (DataRelation relation in xb84e142a2d790b60.Relations)
		{
			if (x0d299f323d241756.x90637a473b1ceaaa(relation.ParentTable.TableName, x4008193de221d9e1) && x0d299f323d241756.x90637a473b1ceaaa(relation.ChildTable.TableName, xd30816dd72b54510))
			{
				return relation;
			}
		}
		return null;
	}
}
