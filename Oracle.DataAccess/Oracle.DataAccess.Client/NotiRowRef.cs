using System.Runtime.InteropServices;

namespace Oracle.DataAccess.Client;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal class NotiRowRef
{
	internal string rowid;

	public NotiRowRef()
	{
		rowid = null;
	}
}
