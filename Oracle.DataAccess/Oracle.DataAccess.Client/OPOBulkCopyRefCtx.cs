using System.Runtime.InteropServices;

namespace Oracle.DataAccess.Client;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal class OPOBulkCopyRefCtx
{
	public string pTableName;

	public string pPartitionName;

	public string pSchemaName;

	public string pDateFormatString;

	public string pObjType;
}
