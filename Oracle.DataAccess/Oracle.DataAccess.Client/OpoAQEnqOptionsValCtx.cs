using System.Runtime.InteropServices;

namespace Oracle.DataAccess.Client;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal struct OpoAQEnqOptionsValCtx
{
	internal int isDirty;

	internal int deliveryMode;

	internal int visibility;
}
