using System;

namespace Oracle.DataAccess.Client;

internal struct ColMetaVal
{
	public ushort Ordinal;

	public ushort OraType;

	public int Size;

	public byte Precision;

	public sbyte Scale;

	public byte NullOK;

	public byte Updatable;

	public byte bIsUnique;

	public byte bIsKeyColumn;

	public byte bIsHiddenCol;

	public byte bIsExpression;

	public int bIsByteSemantic;

	public uint Offset;

	public DacDef Define;

	public ushort CharSetForm;

	public ushort UCS2Character;

	public ushort ROWIDOrd;

	public int bIsXmlType;

	public IntPtr pOpsDscCtx;

	public int ociTypeCode;

	public int bIsFinalType;
}
