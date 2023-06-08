using System;
using System.Runtime.InteropServices;

namespace Oracle.DataAccess.Client;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal class OpoMetRefCtx
{
	public string pTableName;

	public string pSchemaName;

	public IntPtr pColMetaRef;
}
