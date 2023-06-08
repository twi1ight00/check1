using System;
using System.Runtime.InteropServices;

namespace Oracle.DataAccess.Types;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal class AttrMetaRef
{
	public string AttrName;

	public string AttrSchemaName;

	public string AttrTypeName;

	public IntPtr AttrNameConverted;

	public int AttrNameCovertedLen;

	public AttrMetaRef()
	{
		AttrName = null;
		AttrSchemaName = null;
		AttrTypeName = null;
	}
}
