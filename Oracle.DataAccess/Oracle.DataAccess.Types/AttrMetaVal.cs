using Oracle.DataAccess.Client;

namespace Oracle.DataAccess.Types;

internal struct AttrMetaVal
{
	public ushort TypeCode;

	public ushort OraType;

	public byte Precision;

	public sbyte Scale;

	public uint Size;

	public byte CharsetForm;

	public int bDescribed;

	public int Offset;

	public int IndOffset;

	public unsafe OpoDscValCtx* pOpoDscValCtx;

	public int IsNullable;

	public CustomTypeCode CustTypeCode;
}
