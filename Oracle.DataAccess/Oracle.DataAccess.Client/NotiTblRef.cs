using System.Runtime.InteropServices;

namespace Oracle.DataAccess.Client;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal class NotiTblRef
{
	internal string tableName;

	public NotiTblRef()
	{
		tableName = null;
	}
}
