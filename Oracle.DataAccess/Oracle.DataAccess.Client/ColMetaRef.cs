using System;
using System.Runtime.InteropServices;

namespace Oracle.DataAccess.Client;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal class ColMetaRef
{
	public string pColAlias;

	public IntPtr pTabAlias;

	public string pColName;

	public string pTabName;

	public string pSchemaName;

	public string pUdtSchemaName;

	public string pUdtTypeName;
}
