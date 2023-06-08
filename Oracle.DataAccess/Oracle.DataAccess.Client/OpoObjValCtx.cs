using System;

namespace Oracle.DataAccess.Client;

internal struct OpoObjValCtx
{
	public int returnProviderSpecificTypes;

	public int deleteOnFlush;

	public int TypeCode;

	public int AttrIndex;

	public IntPtr pXMLType;
}
