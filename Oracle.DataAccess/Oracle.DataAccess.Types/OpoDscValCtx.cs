using System;

namespace Oracle.DataAccess.Types;

internal struct OpoDscValCtx
{
	public ushort TypeCode;

	public ushort CollTypeCode;

	public uint NumAttrs;

	public byte bIsFinalType;

	public unsafe AttrMetaVal* pAttrMetaVals;

	public IntPtr pAttrMetaRefs;

	public int bDescribedUdt;

	public int bFetchedNumObjAttrs;

	public int bInvalidTDO;

	public byte bIsInstantiableType;

	public int IndSize;

	public int bIsArrayType;
}
