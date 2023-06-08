using System;

namespace Oracle.DataAccess.Client;

internal struct OPOBulkCopyColCtx
{
	public uint MaxSize;

	public uint MaxCharSize;

	public uint ColumnFlag;

	public uint IsPtrData;

	public unsafe OPOBulkCopyObjCtx* pOPOBulkCopyObjCtx;

	public IntPtr pOPOBulkCopyColRefCtx;

	public ushort Ordinal;

	public ushort OraType;

	public ushort OraDbType;

	public ushort CharsetID;

	public byte CharsetForm;

	public byte Precision;

	public sbyte Scale;
}
