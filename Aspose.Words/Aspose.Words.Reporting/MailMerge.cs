using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.OleDb;
using Aspose.Words.Fields;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using xe86f37adaccef1c3;
using xfbd1009a0cbb9842;

namespace Aspose.Words.Reporting;

public class MailMerge
{
	private readonly Document xd1424e1a0bb4a72b;

	private bool x560c0117bdf3c975;

	private bool xc331c46a6b6bd059;

	private MailMergeCleanupOptions x4d00b8816aaaafa2;

	private MailMergeRtlCleanupMode x8b87e365e62465ec;

	private bool xb113d19db2eef1a5;

	private MappedDataFieldCollection x85f1f631bb2bc6af;

	private IFieldMergingCallback xe7af039fd9d4344b;

	private bool x620b7c6d716bfe18;

	private Hashtable x1a5c1a9ee4851f2c;

	private readonly x6bb00c4998eedd39 x50fc6da2450cdc0f = new x6bb00c4998eedd39();

	internal bool xd37772460577fc57 => x620b7c6d716bfe18;

	internal x15a33f6d96885286 x422d34b3419d8be0 => x50fc6da2450cdc0f;

	internal bool x1a980306a733f105
	{
		get
		{
			if (!xc331c46a6b6bd059)
			{
				return (x4d00b8816aaaafa2 & MailMergeCleanupOptions.RemoveUnusedRegions) == MailMergeCleanupOptions.RemoveUnusedRegions;
			}
			return true;
		}
	}

	internal bool x6f8b96bfa12bb473
	{
		get
		{
			if (!x560c0117bdf3c975)
			{
				return (x4d00b8816aaaafa2 & MailMergeCleanupOptions.RemoveEmptyParagraphs) == MailMergeCleanupOptions.RemoveEmptyParagraphs;
			}
			return true;
		}
	}

	internal bool x19a7586a42d9e390 => (x4d00b8816aaaafa2 & MailMergeCleanupOptions.RemoveUnusedFields) == MailMergeCleanupOptions.RemoveUnusedFields;

	internal bool xe28d255488c46bd6 => (x4d00b8816aaaafa2 & MailMergeCleanupOptions.RemoveContainingFields) == MailMergeCleanupOptions.RemoveContainingFields;

	[Obsolete("Use the CleanupOptions property.")]
	public bool RemoveEmptyParagraphs
	{
		get
		{
			return x560c0117bdf3c975;
		}
		set
		{
			x560c0117bdf3c975 = value;
		}
	}

	[Obsolete("Use the CleanupOptions property.")]
	public bool RemoveEmptyRegions
	{
		get
		{
			return xc331c46a6b6bd059;
		}
		set
		{
			xc331c46a6b6bd059 = value;
		}
	}

	public MailMergeCleanupOptions CleanupOptions
	{
		get
		{
			return x4d00b8816aaaafa2;
		}
		set
		{
			x4d00b8816aaaafa2 = value;
		}
	}

	[Obsolete("This property does not affect anything anymore.")]
	public MailMergeRtlCleanupMode RtlCleanupMode
	{
		get
		{
			return x8b87e365e62465ec;
		}
		set
		{
			switch (value)
			{
			case MailMergeRtlCleanupMode.DontRemove:
			case MailMergeRtlCleanupMode.RemoveAll:
			case MailMergeRtlCleanupMode.RemoveForLtrText:
				x8b87e365e62465ec = value;
				break;
			default:
				throw new ArgumentOutOfRangeException("value");
			}
		}
	}

	public bool UseNonMergeFields
	{
		get
		{
			return xb113d19db2eef1a5;
		}
		set
		{
			xb113d19db2eef1a5 = value;
		}
	}

	public MappedDataFieldCollection MappedDataFields
	{
		get
		{
			if (x85f1f631bb2bc6af == null)
			{
				x85f1f631bb2bc6af = new MappedDataFieldCollection();
			}
			return x85f1f631bb2bc6af;
		}
	}

	public IFieldMergingCallback FieldMergingCallback
	{
		get
		{
			return xe7af039fd9d4344b;
		}
		set
		{
			xe7af039fd9d4344b = value;
		}
	}

	internal Document x2c8c6741422a1298 => xd1424e1a0bb4a72b;

	internal MailMerge(Document doc)
	{
		xd1424e1a0bb4a72b = doc;
	}

	public void Execute(IMailMergeDataSource dataSource)
	{
		x18dfca7c5fd2402f(xc5100786b43214b6.x19382cb261a59e98(dataSource));
	}

	private void x18dfca7c5fd2402f(xa11a4c48b53f49a6 xef1769c4fe6ae4ca)
	{
		if (xef1769c4fe6ae4ca == null)
		{
			throw new ArgumentNullException("dataSource");
		}
		xd9966d60dd956f74();
		xc5c3f438428cb03b xc5c3f438428cb03b = new xc5c3f438428cb03b(xd1424e1a0bb4a72b);
		if (xc5c3f438428cb03b.xd5da23b762ce52a2(xef1769c4fe6ae4ca, xc9c7b90943167aed: false) == 0)
		{
			xd1424e1a0bb4a72b.EnsureMinimum();
		}
		x99102507a84b9498();
	}

	public void Execute(string[] fieldNames, object[] values)
	{
		x18dfca7c5fd2402f(new x8be2a8d4eef95c79(this, fieldNames, values));
	}

	public void Execute(DataTable table)
	{
		if (table == null)
		{
			throw new ArgumentNullException("table");
		}
		x18dfca7c5fd2402f(new x615b80dcc88fc837(this, table));
	}

	[JavaDelete("Not porting COM ADO mail merge to Java.")]
	public void ExecuteADO(object recordset)
	{
		if (recordset == null)
		{
			throw new ArgumentNullException("recordset");
		}
		Execute(xff2626fe3b2e1c3f(recordset));
	}

	[JavaDelete("Not porting IDataReader mail merge to Java.")]
	public void Execute(IDataReader dataReader)
	{
		if (dataReader == null)
		{
			throw new ArgumentNullException("dataReader");
		}
		x18dfca7c5fd2402f(new x4bc13e36748f1327(dataReader, ""));
	}

	[JavaDelete("Not porting DataView mail merge to Java.")]
	public void Execute(DataView dataView)
	{
		if (dataView == null)
		{
			throw new ArgumentNullException("dataView");
		}
		x18dfca7c5fd2402f(new xa55af765126dd665(this, dataView));
	}

	[JavaDelete("Not porting DataRow mail merge to Java.")]
	public void Execute(DataRow row)
	{
		if (row == null)
		{
			throw new ArgumentNullException("row");
		}
		x18dfca7c5fd2402f(new x64ebacfbfa979901(this, row));
	}

	public void ExecuteWithRegions(IMailMergeDataSource dataSource)
	{
		xde367ad9e467ebf9(xc5100786b43214b6.x19382cb261a59e98(dataSource));
	}

	private void xde367ad9e467ebf9(xa11a4c48b53f49a6 xef1769c4fe6ae4ca)
	{
		if (xef1769c4fe6ae4ca == null)
		{
			throw new ArgumentNullException("dataSource");
		}
		xd9966d60dd956f74();
		bool flag = false;
		xcbf34d70634239ae xcbf34d70634239ae = x69699a35aa7dd867.xf3baad719840beed(xd1424e1a0bb4a72b);
		foreach (xc5c3f438428cb03b item in xcbf34d70634239ae)
		{
			if (x0d299f323d241756.x90637a473b1ceaaa(item.x759aa16c2016a289, xef1769c4fe6ae4ca.x0e167222a6700ac9))
			{
				if (!flag)
				{
					item.xd5da23b762ce52a2(xef1769c4fe6ae4ca, xc9c7b90943167aed: true);
					flag = true;
				}
				else
				{
					x2f94219b2e8dfd41(item);
				}
			}
			else
			{
				x2f94219b2e8dfd41(item);
			}
		}
		x99102507a84b9498();
	}

	public void ExecuteWithRegions(IMailMergeDataSourceRoot dataSourceRoot)
	{
		xde367ad9e467ebf9(xdba4bc229f323b10.x19382cb261a59e98(dataSourceRoot));
	}

	private void xde367ad9e467ebf9(xe0a98df97f5fe1f3 xa62cbc5ccf369616)
	{
		if (xa62cbc5ccf369616 == null)
		{
			throw new ArgumentNullException("dataSourceRoot");
		}
		xd9966d60dd956f74();
		xcbf34d70634239ae xcbf34d70634239ae = x69699a35aa7dd867.xf3baad719840beed(xd1424e1a0bb4a72b);
		foreach (xc5c3f438428cb03b item in xcbf34d70634239ae)
		{
			xa11a4c48b53f49a6 xa11a4c48b53f49a = xa62cbc5ccf369616.xf6d2c418f136d715(item.x759aa16c2016a289);
			if (xa11a4c48b53f49a != null)
			{
				item.xd5da23b762ce52a2(xa11a4c48b53f49a, xc9c7b90943167aed: true);
			}
			else
			{
				x2f94219b2e8dfd41(item);
			}
		}
		x99102507a84b9498();
	}

	private void x2f94219b2e8dfd41(xc5c3f438428cb03b xa4d52e34b62b5495)
	{
		if (x1a980306a733f105)
		{
			xa4d52e34b62b5495.x52b190e626f65140();
		}
	}

	public void ExecuteWithRegions(DataSet dataSet)
	{
		if (dataSet == null)
		{
			throw new ArgumentNullException("dataSet");
		}
		xde367ad9e467ebf9(new xd27a132efeac62e8(this, dataSet));
	}

	public void ExecuteWithRegions(DataTable dataTable)
	{
		if (dataTable == null)
		{
			throw new ArgumentNullException("dataTable");
		}
		xde367ad9e467ebf9(new x615b80dcc88fc837(this, dataTable));
	}

	[JavaDelete("Not porting COM ADO mail merge to Java.")]
	public void ExecuteWithRegionsADO(object recordset, string tableName)
	{
		if (recordset == null)
		{
			throw new ArgumentNullException("recordset");
		}
		DataTable dataTable = xff2626fe3b2e1c3f(recordset);
		dataTable.TableName = tableName;
		ExecuteWithRegions(dataTable);
	}

	[JavaDelete("Not porting COM ADO mail merge to Java.")]
	private static DataTable xff2626fe3b2e1c3f(object x16e91e1651b85618)
	{
		OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter();
		DataTable dataTable = new DataTable();
		oleDbDataAdapter.Fill(dataTable, x16e91e1651b85618);
		return dataTable;
	}

	[JavaDelete("Not porting DataView mail merge to Java.")]
	public void ExecuteWithRegions(DataView dataView)
	{
		if (dataView == null)
		{
			throw new ArgumentNullException("dataView");
		}
		xde367ad9e467ebf9(new xa55af765126dd665(this, dataView));
	}

	[JavaDelete("Not porting IDataReader mail merge to Java.")]
	public void ExecuteWithRegions(IDataReader dataReader, string tableName)
	{
		if (dataReader == null)
		{
			throw new ArgumentNullException("dataReader");
		}
		xde367ad9e467ebf9(new x4bc13e36748f1327(dataReader, tableName));
	}

	public string[] GetFieldNames()
	{
		x6435b7bbb0879a04 x6435b7bbb0879a = xe25d778fe9f1252a.x105bab38d511372f(xd1424e1a0bb4a72b);
		StringCollection stringCollection = new StringCollection();
		for (int i = 0; i < x6435b7bbb0879a.Count; i++)
		{
			Field field = x6435b7bbb0879a.get_xe6d4b1b411ed94b5(i);
			if (field is x561fa53c007d3597)
			{
				x561fa53c007d3597 x561fa53c007d = (x561fa53c007d3597)field;
				if (x561fa53c007d.xd8a1c7c41bfbcde0.Length > 0)
				{
					stringCollection.Add($"{x561fa53c007d.xd8a1c7c41bfbcde0}:{x561fa53c007d.xae9d2e3eea32978f}");
				}
				else
				{
					stringCollection.Add(x561fa53c007d.xae9d2e3eea32978f);
				}
			}
		}
		string[] array = new string[stringCollection.Count];
		stringCollection.CopyTo(array, 0);
		return array;
	}

	public void DeleteFields()
	{
		x6435b7bbb0879a04 x6435b7bbb0879a = xe25d778fe9f1252a.x105bab38d511372f(xd1424e1a0bb4a72b);
		foreach (Field item in x6435b7bbb0879a)
		{
			if (item.Type == FieldType.FieldMergeField || item.Type == FieldType.FieldNext)
			{
				item.Remove();
			}
		}
	}

	private void xd9966d60dd956f74()
	{
		x620b7c6d716bfe18 = true;
		if (xb113d19db2eef1a5)
		{
			xe0349bafdcd42e3b.x8f1e2d70dda35215(xd1424e1a0bb4a72b);
		}
		x50fc6da2450cdc0f.x3ef8d9eab8302a17(xd1424e1a0bb4a72b);
	}

	private void x99102507a84b9498()
	{
		xd1424e1a0bb4a72b.MailMergeSettings.Clear();
		x1a5c1a9ee4851f2c = null;
		x50fc6da2450cdc0f.x09cb5d25e0058445();
		x620b7c6d716bfe18 = false;
	}

	internal string x8b00baeb99adecc8(string x9c7bb53e9df3f620)
	{
		if (x85f1f631bb2bc6af != null)
		{
			string text = x85f1f631bb2bc6af[x9c7bb53e9df3f620];
			if (text != null)
			{
				return text;
			}
		}
		return x9c7bb53e9df3f620;
	}

	internal void x338aa1b17bb2a0c8(FieldMergingArgs xfbf34718e704c6bc)
	{
		if (xe7af039fd9d4344b != null)
		{
			xe7af039fd9d4344b.FieldMerging(xfbf34718e704c6bc);
		}
	}

	internal void x8ac49bb85e2a468f(ImageFieldMergingArgs xfbf34718e704c6bc)
	{
		if (xe7af039fd9d4344b != null)
		{
			xe7af039fd9d4344b.ImageFieldMerging(xfbf34718e704c6bc);
		}
	}

	internal bool x843bae94cdba15fa(Node x3b2496727a21f4a2, out object x8d3f74e5f925679c)
	{
		x8d3f74e5f925679c = null;
		if (x1a5c1a9ee4851f2c == null)
		{
			return false;
		}
		object key = xf39c106b43956987(x3b2496727a21f4a2);
		if (!x1a5c1a9ee4851f2c.Contains(key))
		{
			return false;
		}
		x8d3f74e5f925679c = x1a5c1a9ee4851f2c[key];
		return true;
	}

	internal void xf48048669b1237bc(Node x3b2496727a21f4a2, object x8d3f74e5f925679c)
	{
		if (x1a5c1a9ee4851f2c == null)
		{
			x1a5c1a9ee4851f2c = new Hashtable();
		}
		x1a5c1a9ee4851f2c[xf39c106b43956987(x3b2496727a21f4a2)] = x8d3f74e5f925679c;
	}

	private object xf39c106b43956987(Node x3b2496727a21f4a2)
	{
		return x50fc6da2450cdc0f.xf39c106b43956987(x3b2496727a21f4a2);
	}
}
