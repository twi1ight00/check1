using System.Runtime.InteropServices;

namespace Oracle.DataAccess.Client;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal class OPOBulkCopyColRefCtx
{
	public string pColName;

	public string pObjTypeName;
}
