using System.Runtime.InteropServices;

namespace Oracle.DataAccess.Types;

[StructLayout(LayoutKind.Explicit)]
internal struct OpoITLValCtx
{
	[FieldOffset(0)]
	internal IYMCtx m_ym;

	[FieldOffset(0)]
	internal IDSCtx m_ds;

	[FieldOffset(20)]
	internal byte m_type;

	[FieldOffset(21)]
	internal short m_regid;
}
