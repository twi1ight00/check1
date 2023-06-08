using System.Runtime.InteropServices;

namespace Oracle.DataAccess.Types;

[StructLayout(LayoutKind.Explicit)]
internal struct OpoUdtAttrValCtx
{
	[FieldOffset(0)]
	public byte m_byte;

	[FieldOffset(0)]
	public short m_short;

	[FieldOffset(0)]
	public int m_int;

	[FieldOffset(0)]
	public long m_long;

	[FieldOffset(0)]
	public float m_float;

	[FieldOffset(0)]
	public double m_double;
}
