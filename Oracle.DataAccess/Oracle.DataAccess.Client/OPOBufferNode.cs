using System;

namespace Oracle.DataAccess.Client;

internal struct OPOBufferNode
{
	public IntPtr pBuffer;

	public IntPtr pNext;
}
